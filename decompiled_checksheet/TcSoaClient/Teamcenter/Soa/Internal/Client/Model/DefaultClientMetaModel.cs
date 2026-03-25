using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Internal.Loose.Core;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using log4net;

namespace Teamcenter.Soa.Internal.Client.Model;

public class DefaultClientMetaModel : ClientMetaModel
{
	private static ILog logger = LogManager.GetLogger(typeof(DefaultClientMetaModel));

	protected static readonly string UNKNOWN_TYPE = "unknownType";

	private static readonly string[] preLoadTypes = new string[36]
	{
		"BusinessObject", "POM_object", "POM_system_class", "POM_application_object", "ImanType", "POM_data_manager", "POM_group", "WorkspaceObject", "POM_user", "POM_member",
		"Folder", "RuntimeBusinessObject", "ListOfValues", "ListOfValuesChar", "ListOfValuesExternalCharExtent", "ListOfValuesDate", "ListOfValuesExternalDateExtent", "ListOfValuesDouble", "ListOfValuesExternalDoubleExtent", "ListOfValuesTag",
		"ListOfValuesTagExtent", "ListOfValuesTagRDVSearchRevRule", "ListOfValuesInteger", "ListOfValuesExternalIntExtent", "ListOfValuesIntegerExtentSite", "ListOfValuesString", "ListOfValuesExternalStringExtent", "ListOfValuesStringExtent", "ListOfValuesStringExtentStatus", "ListOfValuesStringExtentUsName",
		"ListOfValuesStringExtentPubrType", "ListOfValuesStringExtentUserId", "ListOfValuesStringExtentWSOClass", "ListOfValuesStringExtentGrName", "ListOfValuesFilter", "ListOfValuesIpClassification"
	};

	private bool initialized = false;

	private static SoaType sUnknownType = null;

	public static SoaType UnknownType
	{
		get
		{
			if (sUnknownType == null)
			{
				ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
				sUnknownType = objectFactory.ConstructType(SoaTypeImpl.UNKNOWN_TYPE_UID, SoaTypeImpl.UNKNOWN_TYPE_UID, SoaTypeImpl.UNKNOWN_TYPE_NAME, SoaTypeImpl.UNKNOWN_TYPE_NAME, SoaTypeImpl.UNKNOWN_TYPE_CLASS, new List<string>(), null, "", new Dictionary<string, PropertyDescription>(), new Dictionary<string, string>(), null, RevisionRuleCategory.None);
			}
			return sUnknownType;
		}
	}

	public static int GetLovValueType(SoaType lovType)
	{
		if (lovType.IsInstanceOf("ListOfValuesChar"))
		{
			return 0;
		}
		if (lovType.IsInstanceOf("ListOfValuesDate"))
		{
			return 1;
		}
		if (lovType.IsInstanceOf("ListOfValuesDouble"))
		{
			return 2;
		}
		if (lovType.IsInstanceOf("ListOfValuesInteger"))
		{
			return 4;
		}
		if (lovType.IsInstanceOf("ListOfValuesString"))
		{
			return 7;
		}
		if (lovType.IsInstanceOf("ListOfValuesTag"))
		{
			return 8;
		}
		if (lovType.IsInstanceOf("Fnd0ListOfValuesDynamic"))
		{
			return 0;
		}
		logger.Debug("Unknown LOV value type: " + lovType.Name);
		throw new ArgumentException("Unknown LOV value type: " + lovType.Name);
	}

	protected void Initialize(IList<string> typeKeys)
	{
		if (!initialized)
		{
			initialized = true;
			for (int i = 0; i < preLoadTypes.Length; i++)
			{
				typeKeys.Add(preLoadTypes[i]);
			}
		}
	}

	protected override void LoadTypes(IList<string> typeKeys, Connection connection)
	{
		Initialize(typeKeys);
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		foreach (string typeKey in typeKeys)
		{
			if (typeKey.IndexOf(":") == -1)
			{
				list.Add(typeKey);
			}
			else
			{
				list2.Add(typeKey);
			}
		}
		LoadTypesByName(list, connection);
		LoadTypesByUid(list2, connection);
	}

	protected override void LoadLovInfo(string uid, SoaType type, Connection connection)
	{
		string owningType = "Unknown";
		string owningProp = "Unknown";
		DynamicLovInfo dynamicLovInfo = new DynamicLovInfo(uid, type, connection, owningType, owningProp);
		AddLovInfo(dynamicLovInfo.Resolve());
	}

	public override bool IsTypeValid(string typeName, Connection connection)
	{
		if (ContainsType(typeName))
		{
			if (GetType(typeName, connection) != null)
			{
				return true;
			}
			return false;
		}
		if (GetType(typeName, connection) != null)
		{
			return true;
		}
		return false;
	}

	public void AddDynamicLovInfo(LovInfo lovInfo)
	{
		AddLovInfo(lovInfo);
	}

	private void LoadTypesByName(List<string> typeNames, Connection connection)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		if (typeNames.Contains(UNKNOWN_TYPE))
		{
			typeNames.Remove(UNKNOWN_TYPE);
		}
		if (typeNames.Count != 0)
		{
			ModelManagerImpl.LogDebug(ClassNames.DefaultClientMetaModel, logger, "loadTypesByName", GetListOfNames(typeNames));
			SessionService service = SessionService.getService(connection);
			LoadModelSchema(service.InitTypeByNames(typeNames.ToArray()), connection);
			stopwatch.Stop();
			ModelManagerImpl.LogDebug(ClassNames.DefaultClientMetaModel, logger, "loadTypesByName( Recieved types", stopwatch.ElapsedMilliseconds + "ms)");
		}
	}

	private void LoadTypesByUid(List<string> typeUids, Connection connection)
	{
		if (typeUids.Count != 0)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			ModelManagerImpl.LogDebug(ClassNames.DefaultClientMetaModel, logger, "loadTypesByUid", GetListOfNames(typeUids));
			SessionService service = SessionService.getService(connection);
			LoadModelSchema(service.InitTypeByUids(typeUids.ToArray()), connection);
			stopwatch.Stop();
			ModelManagerImpl.LogDebug(ClassNames.DefaultClientMetaModel, logger, "loadTypesByUid( Recieved types", stopwatch.ElapsedMilliseconds + "ms)");
		}
	}

	private void LoadModelSchema(ModelSchema xmlModelSchema, Connection connection)
	{
		Dictionary<string, List<string>> classNameHierarchyMap = LoadClassNameHierarchy(xmlModelSchema);
		ArrayList types = xmlModelSchema.getTypes();
		Dictionary<string, ModelType> dictionary = new Dictionary<string, ModelType>();
		foreach (ModelType item in types)
		{
			if (dictionary.ContainsKey(item.Name))
			{
				if (item.PropDescriptor != null && dictionary[item.getName()].PropDescriptor != null && dictionary[item.getName()].PropDescriptor.Length < item.PropDescriptor.Length)
				{
					dictionary[item.Name] = item;
				}
			}
			else
			{
				dictionary[item.Name] = item;
			}
		}
		LoadParentTypes(dictionary, classNameHierarchyMap, connection);
		foreach (ModelType item2 in types)
		{
			try
			{
				if (item2.getName().StartsWith("ListOfValues"))
				{
					loadSchemaTypeAndParent(item2, dictionary, classNameHierarchyMap, connection);
				}
			}
			catch (SystemException ex)
			{
				logger.Debug("DefaultClientMetaModel::LoadModelSchema -- Failed to load data for " + item2.getName());
				logger.Debug("DefaultClientMetaModel::LoadModelSchema -- " + ex.Message);
			}
		}
		foreach (ModelType item3 in types)
		{
			try
			{
				loadSchemaTypeAndParent(item3, dictionary, classNameHierarchyMap, connection);
			}
			catch (SystemException ex)
			{
				logger.Debug("DefaultClientMetaModel::LoadModelSchema -- Failed to load data for " + item3.getName());
				logger.Debug("DefaultClientMetaModel::LoadModelSchema -- " + ex.Message);
			}
		}
	}

	private void loadSchemaTypeAndParent(ModelType xmlType, Dictionary<string, ModelType> types, Dictionary<string, List<string>> classNameHierarchyMap, Connection connection)
	{
		string parentTypeName = xmlType.getParentTypeName();
		if (parentTypeName != null && parentTypeName.Length > 0 && !ContainsType(parentTypeName))
		{
			if (!types.ContainsKey(parentTypeName))
			{
				logger.Debug("loadParentTypes did not load " + parentTypeName);
				throw new ArgumentException("loadParentTypes did not load " + parentTypeName);
			}
			ModelType xmlType2 = types[parentTypeName];
			loadSchemaTypeAndParent(xmlType2, types, classNameHierarchyMap, connection);
		}
		LoadSchemaType(xmlType, classNameHierarchyMap, connection);
	}

	private void LoadSchemaType(ModelType xmlType, Dictionary<string, List<string>> classNameHierarchyMap, Connection connection)
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		if (ContainsType(xmlType.getName()))
		{
			return;
		}
		ArrayList propDescriptor = xmlType.getPropDescriptor();
		Dictionary<string, PropDescriptor> dictionary = new Dictionary<string, PropDescriptor>();
		foreach (PropDescriptor item in propDescriptor)
		{
			dictionary[item.getName()] = item;
		}
		Dictionary<string, PropertyDescription> dictionary2 = new Dictionary<string, PropertyDescription>();
		ModelManagerImpl.LogDebug(ClassNames.DefaultClientMetaModel, logger, "ObjectFactory.constructPropertyDescription", GetPropertyDescriptorNames(propDescriptor));
		foreach (PropDescriptor item2 in propDescriptor)
		{
			int lovCategory = 0;
			ConditionChoices<Lov> conditionChoices = new ConditionChoices<Lov>();
			if (item2.getLovUid().Length > 0)
			{
				lovCategory = 1;
				int attachedSpecifier = item2.AttachedSpecifier;
				List<string> list = new List<string>();
				foreach (PropDependant propDependant in item2.getPropDependants())
				{
					if (propDependant.getName().Length > 0)
					{
						list.Add(propDependant.getName());
					}
				}
				if (list.Count == 0)
				{
					list.Add(item2.getName());
				}
				IList<Style> styleList = GetStyleList(list, dictionary);
				DynamicLov choice = new DynamicLov(item2.getLovUid(), GetType(item2.getLovTypeUid(), connection), attachedSpecifier, list, styleList, xmlType.getName(), item2.getName(), connection);
				conditionChoices.addChoice(choice);
			}
			int maxArraySize = 1;
			if (item2.AnArray)
			{
				maxArraySize = item2.MaxArraySize;
			}
			ConditionChoices<NamingRule> namingRules = new ConditionChoices<NamingRule>();
			ConditionChoices<string> renderers = new ConditionChoices<string>();
			Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
			if (item2.Modifiable)
			{
				dictionary3[PropertyConstants.MODIFIABLE] = Teamcenter.Soa.Client.Model.Property.ToBooleanString(item2.Modifiable);
			}
			if (item2.Displayable)
			{
				dictionary3[PropertyConstants.DISPLAYABLE] = Teamcenter.Soa.Client.Model.Property.ToBooleanString(item2.Displayable);
			}
			if (item2.Enabled)
			{
				dictionary3[PropertyConstants.EDITABLE] = Teamcenter.Soa.Client.Model.Property.ToBooleanString(item2.Enabled);
			}
			if (item2.Required)
			{
				dictionary3[PropertyConstants.REQUIRED] = Teamcenter.Soa.Client.Model.Property.ToBooleanString(item2.Required);
			}
			PropertyDescription propertyDescription = objectFactory.ConstructPropertyDescription(xmlType.Uid, item2.Name, item2.Uiname, item2.Type, item2.Ptype, item2.MaxLength, item2.AnArray, maxArraySize, 0, "", lovCategory, dictionary3, conditionChoices, namingRules, renderers, RuleCategory.None, "", "", null);
			dictionary2[propertyDescription.Name] = propertyDescription;
		}
		List<string> list2 = null;
		list2 = ((!classNameHierarchyMap.ContainsKey(xmlType.ClassName)) ? new List<string>() : classNameHierarchyMap[xmlType.ClassName]);
		ConditionChoices<RevNameRule> revRules = new ConditionChoices<RevNameRule>();
		ModelManagerImpl.LogDebug(ClassNames.DefaultClientMetaModel, logger, "ObjectFactory.constructType", xmlType.getName());
		Dictionary<string, string> constants = new Dictionary<string, string>();
		SoaType type = objectFactory.ConstructType(xmlType.Uid, xmlType.TypeUid, xmlType.Name, xmlType.UifName, xmlType.ClassName, list2, GetType(xmlType.ParentTypeName, connection), "", dictionary2, constants, revRules, RevisionRuleCategory.None);
		AddType(type);
	}

	private void LoadParentTypes(Dictionary<string, ModelType> xmlTypes, Dictionary<string, List<string>> classNameHierarchyMap, Connection connection)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (List<string> value in classNameHierarchyMap.Values)
		{
			for (int i = 1; i < value.Count; i++)
			{
				string text = value[i];
				if (ContainsType(text) || xmlTypes.ContainsKey(text))
				{
					continue;
				}
				int index = i;
				for (; i < value.Count; i++)
				{
					text = value[index];
					if (!ContainsType(text))
					{
						dictionary[text] = text;
					}
				}
				break;
			}
		}
		foreach (ModelType value2 in xmlTypes.Values)
		{
			string text = value2.ParentTypeName;
			if (text.Length != 0 && !ContainsType(text) && !dictionary.ContainsKey(text) && !xmlTypes.ContainsKey(text))
			{
				dictionary[text] = text;
			}
		}
		if (dictionary.ContainsKey("POM_object"))
		{
			dictionary["BusinessObject"] = "BusinessObject";
		}
		List<string> list = new List<string>();
		foreach (string key in dictionary.Keys)
		{
			list.Add(key);
		}
		GetTypes(list, connection);
	}

	private Dictionary<string, List<string>> LoadClassNameHierarchy(ModelSchema wireModelSchema)
	{
		ModelClass[] classes = wireModelSchema.Classes;
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		if (classes == null)
		{
			return dictionary;
		}
		List<string> list = new List<string>();
		ModelClass[] array = classes;
		foreach (ModelClass modelClass in array)
		{
			list.Add(modelClass.Name);
			if (modelClass.getParentClassName().Length == 0)
			{
				dictionary[list[0]] = list;
				list = new List<string>();
			}
		}
		return dictionary;
	}

	public static List<string> GetClassHierarchy(string typeName, string className, string parentTypeName, string owningType, Connection connection)
	{
		ClientMetaModel clientMetaModel = connection.ClientMetaModel;
		List<string> list = new List<string>();
		if (!typeName.Equals("BusinessObject") && !typeName.Equals("RuntimeBusinessObject") && owningType.Equals(""))
		{
			list.Add(className);
			SoaType soaType = clientMetaModel.GetType(parentTypeName, connection);
			while (soaType != null)
			{
				string className2 = soaType.ClassName;
				if (className2.Equals("RuntimeBusinessObject"))
				{
					list = new List<string>();
					break;
				}
				soaType = soaType.Parent;
				if (!className2.Equals("BusinessObject") && soaType != null && !className2.Equals(list[list.Count - 1]))
				{
					list.Add(className2);
				}
			}
		}
		return list;
	}

	public static IList<string> GetTypeHierarchy(string typeName, string parentTypeName, Connection connection)
	{
		ClientMetaModel clientMetaModel = connection.ClientMetaModel;
		List<string> list = new List<string>();
		list.Add(typeName);
		if (parentTypeName == null)
		{
			parentTypeName = clientMetaModel.GetType(typeName, connection).Parent.Name;
		}
		SoaType soaType = clientMetaModel.GetType(parentTypeName, connection);
		while (soaType != null)
		{
			string name = soaType.Name;
			soaType = soaType.Parent;
			if (!name.Equals("BusinessObject") && soaType != null && !name.Equals(list[list.Count - 1]))
			{
				list.Add(name);
			}
		}
		return list;
	}

	public static object ParseLovValue(int valueType, string sValue, Connection connection)
	{
		switch (valueType)
		{
		case 0:
			return sValue.ToCharArray()[0];
		case 5:
			return Teamcenter.Soa.Client.Model.Property.ParseBoolean(sValue);
		case 1:
			return Teamcenter.Soa.Client.Model.Property.ParseDate(sValue);
		case 2:
			return Teamcenter.Soa.Client.Model.Property.ParseDouble(sValue);
		case 4:
			return Teamcenter.Soa.Client.Model.Property.ParseInt(sValue);
		case 6:
			return Teamcenter.Soa.Client.Model.Property.ParseShort(sValue);
		case 7:
			return sValue;
		case 8:
			return connection.ClientDataModel.GetObject(sValue);
		default:
			logger.Debug("Unknown LOV value type, " + valueType + ", while processing the LOV value of " + sValue);
			throw new ArgumentException("Unknown LOV value type, " + valueType + ", while processing the LOV value of " + sValue);
		}
	}

	protected static IList<string> GetStringList(string names)
	{
		List<string> list = new List<string>();
		if (names != null && names.Length > 0)
		{
			string[] array = names.Split(',');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string item = text.Trim();
				list.Add(item);
			}
		}
		return list;
	}

	public static Usage ParseUsage(string s)
	{
		Usage result = Usage.Exhaustive;
		if (s.Equals("Suggestive") || s.Equals("2"))
		{
			result = Usage.Suggestive;
		}
		if (s.Equals("Range") || s.Equals("3"))
		{
			result = Usage.Range;
		}
		return result;
	}

	public static RuleCase ParseRuleCase(string s)
	{
		RuleCase result = RuleCase.Mixed;
		if (s.Equals("1") || s.Equals("Lower"))
		{
			result = RuleCase.Lower;
		}
		if (s.Equals("2") || s.Equals("Upper"))
		{
			result = RuleCase.Upper;
		}
		return result;
	}

	public static Style ParseStyle(string s)
	{
		Style result = Style.Standard;
		if (s.Equals("Hierarchical"))
		{
			result = Style.Hierarchical;
		}
		if (s.Equals("Interdependent"))
		{
			result = Style.Interdependent;
		}
		if (s.Equals("Coordinated"))
		{
			result = Style.Coordinated;
		}
		if (s.Equals("Description"))
		{
			result = Style.Description;
		}
		return result;
	}

	protected static string GetListOfNames(List<string> typeKeys)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = "";
		foreach (string typeKey in typeKeys)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += typeKey;
		}
		return text;
	}

	private static string GetPropertyDescriptorNames(ArrayList descriptors)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = "";
		foreach (PropDescriptor descriptor in descriptors)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += descriptor.Name;
		}
		return text;
	}

	protected static IList<Style> GetStyleList(IList<string> propNames, Dictionary<string, PropDescriptor> otherXmlDescriptors)
	{
		IList<Style> list = new List<Style>();
		foreach (string propName in propNames)
		{
			PropDescriptor propDescriptor = otherXmlDescriptors[propName];
			Style item = Style.Standard;
			int num = 0;
			num = propDescriptor.AttachedSpecifier;
			if ((num & 2) == 2)
			{
				item = Style.Coordinated;
			}
			if ((num & 1) == 1)
			{
				item = Style.Description;
			}
			list.Add(item);
		}
		return list;
	}
}
