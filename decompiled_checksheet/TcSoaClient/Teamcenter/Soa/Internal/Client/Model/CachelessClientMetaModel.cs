using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Teamcenter.Schemas.Soa._2011_06.Metamodel;
using Teamcenter.Services.Loose.Core;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Common;
using log4net;

namespace Teamcenter.Soa.Internal.Client.Model;

public class CachelessClientMetaModel : DefaultClientMetaModel
{
	private static readonly Teamcenter.Soa.Common.Version MINIMUM_SERVER_VERSION = new Teamcenter.Soa.Common.Version(9000, 1, 0);

	private static ILog logger = LogManager.GetLogger(typeof(CachelessClientMetaModel));

	protected override void LoadTypes(IList<string> typeKeys, Connection connection)
	{
		Initialize(typeKeys);
		if (connection.ServerVersion < MINIMUM_SERVER_VERSION)
		{
			base.LoadTypes(typeKeys, connection);
			return;
		}
		List<string> list = new List<string>();
		foreach (string typeKey in typeKeys)
		{
			if (typeKey.IndexOf(":") != -1)
			{
				string[] array = typeKey.Split(new char[1] { ':' }, StringSplitOptions.RemoveEmptyEntries);
				string item = array[1];
				list.Add(item);
			}
			else
			{
				list.Add(typeKey);
			}
		}
		GetTypeDescriptions(list, connection);
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

	private void GetTypeDescriptions(List<string> typeNames, Connection connection)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		if (typeNames.Contains(DefaultClientMetaModel.UNKNOWN_TYPE))
		{
			typeNames.Remove(DefaultClientMetaModel.UNKNOWN_TYPE);
		}
		if (typeNames.Count != 0)
		{
			ModelManagerImpl.LogDebug(ClassNames.CachelessClientMetaModel, logger, "getTypeMetaData", DefaultClientMetaModel.GetListOfNames(typeNames));
			SessionService service = SessionService.getService(connection);
			LoadTypeSchema(service.GetTypeDescriptions(typeNames.ToArray()), connection);
			stopwatch.Stop();
			ModelManagerImpl.LogDebug(ClassNames.CachelessClientMetaModel, logger, "getTypeMetaData( Recieved types", stopwatch.ElapsedMilliseconds + "ms)");
		}
	}

	private void LoadTypeSchema(TypeSchema xmlModelSchema, Connection connection)
	{
		ArrayList types = xmlModelSchema.getTypes();
		ArrayList tools = xmlModelSchema.getTools();
		Dictionary<string, ModelType> dictionary = new Dictionary<string, ModelType>();
		Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool> dictionary2 = new Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool>();
		foreach (ModelType item in types)
		{
			dictionary[item.Name] = item;
		}
		foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool item2 in tools)
		{
			dictionary2[item2.Name] = item2;
		}
		LoadParentTypes(dictionary, connection);
		foreach (ModelType item3 in types)
		{
			try
			{
				if (item3.Name.StartsWith("ListOfValues"))
				{
					LoadSchemaTypeAndParent(item3, dictionary, dictionary2, connection);
				}
			}
			catch (SystemException ex)
			{
				logger.Debug("CachelessClientMetaModel::LoadTypeSchema -- Failed to load data for " + item3.getName());
				logger.Debug("CachelessClientMetaModel::LoadTypeSchema -- " + ex.Message);
			}
		}
		foreach (ModelType item4 in types)
		{
			try
			{
				LoadSchemaTypeAndParent(item4, dictionary, dictionary2, connection);
			}
			catch (SystemException ex)
			{
				logger.Debug("CachelessClientMetaModel::LoadTypeSchema -- Failed to load data for " + item4.getName());
				logger.Debug("CachelessClientMetaModel::LoadTypeSchema -- " + ex.Message);
			}
		}
	}

	private void LoadParentTypes(Dictionary<string, ModelType> xmlTypes, Connection connection)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (ModelType value in xmlTypes.Values)
		{
			IList<string> stringList = DefaultClientMetaModel.GetStringList(value.getTypeHierarchy());
			foreach (string item in stringList)
			{
				if (!ContainsType(item) && !xmlTypes.ContainsKey(item))
				{
					dictionary[item] = item;
				}
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

	private void LoadSchemaTypeAndParent(ModelType xmlType, Dictionary<string, ModelType> types, Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool> tools, Connection connection)
	{
		string parentTypeName = xmlType.ParentTypeName;
		if (parentTypeName != null && parentTypeName.Length > 0 && !ContainsType(parentTypeName))
		{
			if (!types.ContainsKey(parentTypeName))
			{
				logger.Error("loadParentTypes did not load " + parentTypeName);
				throw new ArgumentException("loadParentTypes did not load " + parentTypeName);
			}
			ModelType xmlType2 = types[parentTypeName];
			LoadSchemaTypeAndParent(xmlType2, types, tools, connection);
		}
		LoadSchemaType(xmlType, tools, connection);
	}

	private void LoadSchemaType(ModelType xmlType, Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool> tools, Connection connection)
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		if (ContainsType(xmlType.getName()))
		{
			return;
		}
		ArrayList propertyDescriptors = xmlType.getPropertyDescriptors();
		Dictionary<string, PropertyDescriptor> dictionary = new Dictionary<string, PropertyDescriptor>();
		foreach (PropertyDescriptor item in propertyDescriptors)
		{
			dictionary[item.getName()] = item;
		}
		Dictionary<string, PropertyDescription> dictionary2 = new Dictionary<string, PropertyDescription>();
		ModelManagerImpl.LogDebug(ClassNames.CachelessClientMetaModel, logger, "ObjectFactory.constructPropertyDescription", GetPropertyDescriptorNames(propertyDescriptors));
		foreach (PropertyDescriptor item2 in propertyDescriptors)
		{
			ConditionChoices<Lov> conditionChoices = new ConditionChoices<Lov>(connection);
			foreach (LovReference lov in item2.getLovs())
			{
				Style style = DefaultClientMetaModel.ParseStyle(lov.Style);
				int specifier = Convert.ToInt32(lov.Specifier);
				IList<string> stringList = DefaultClientMetaModel.GetStringList(lov.getPropDependents());
				IList<Style> styleList = GetStyleList(stringList, lov.getConditionName(), dictionary);
				Teamcenter.Soa.Client.Model.LovInfo info = new DynamicLovInfo(lov.LovUid, GetType(lov.LovTypeUid, connection), connection, xmlType.Name, item2.Name);
				ModelManagerImpl.LogDebug(ClassNames.CachelessClientMetaModel, logger, "ObjectFactory.constructLov", item2.getName());
				Lov choice = objectFactory.ConstructLov(style, stringList, styleList, lov.getLovUid(), specifier, info);
				conditionChoices.addChoice(lov.ConditionName, choice);
			}
			int maxArraySize = 1;
			if (item2.AnArray)
			{
				maxArraySize = item2.MaxArraySize;
			}
			int fieldType = item2.FieldType;
			string compoundObjType = ((item2.CompoundObjType != null) ? item2.CompoundObjType : "");
			int lovCategory = GetLovCategory(item2);
			Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
			foreach (Constant constant3 in item2.getConstants())
			{
				dictionary3[constant3.Name] = constant3.Value;
			}
			ConditionChoices<Teamcenter.Soa.Client.Model.NamingRule> conditionChoices2 = ParseNamingRule(item2, connection);
			ConditionChoices<string> renderers = ParseRenderers(item2, connection);
			RuleCategory ruleCategory = RuleCategory.None;
			if (conditionChoices2.peekAtCondition() != null)
			{
				ruleCategory = (conditionChoices2.peekAtCondition().Equals(ConditionResolver.IS_TRUE) ? RuleCategory.IsTrue : RuleCategory.SessionCondition);
			}
			Teamcenter.Soa.Client.Model.BasedOn basedOn = parseBasedOn(item2);
			PropertyDescription propertyDescription = objectFactory.ConstructPropertyDescription(xmlType.Uid, item2.Name, item2.DisplayName, item2.ValueType, item2.PropertyType, item2.MaxLength, item2.AnArray, maxArraySize, fieldType, compoundObjType, lovCategory, dictionary3, conditionChoices, conditionChoices2, renderers, ruleCategory, item2.MinValue, item2.MaxValue, basedOn);
			dictionary2[propertyDescription.Name] = propertyDescription;
		}
		string owningType = ((xmlType.OwningType == null) ? "" : xmlType.OwningType);
		IList<string> classHierarchy = DefaultClientMetaModel.GetClassHierarchy(xmlType.Name, xmlType.ClassName, xmlType.ParentTypeName, owningType, connection);
		Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
		foreach (Constant constant4 in xmlType.getConstants())
		{
			dictionary4[constant4.Name] = constant4.Value;
		}
		ConditionChoices<Teamcenter.Soa.Client.Model.RevNameRule> conditionChoices3 = ParseRevNameRule(xmlType, connection);
		RevisionRuleCategory ruleCategory2 = RevisionRuleCategory.None;
		if (conditionChoices3.peekAtCondition() != null)
		{
			ruleCategory2 = (conditionChoices3.peekAtCondition().Equals(ConditionResolver.IS_TRUE) ? RevisionRuleCategory.IsTrue : RevisionRuleCategory.SessionCondition);
		}
		SoaType soaType = null;
		if (xmlType is Teamcenter.Schemas.Soa._2011_06.Metamodel.DatasetType)
		{
			Teamcenter.Schemas.Soa._2011_06.Metamodel.DatasetType datasetType = (Teamcenter.Schemas.Soa._2011_06.Metamodel.DatasetType)xmlType;
			Dictionary<string, Reference> dictionary5 = new Dictionary<string, Reference>();
			IList<Reference> list = new List<Reference>();
			foreach (DatasetReference reference2 in datasetType.getReferences())
			{
				IList<string> list2 = new List<string>();
				IList<string> list3 = new List<string>();
				foreach (DatasetReferenceInfo item3 in reference2.getInfo())
				{
					list2.Add(item3.getTmplate());
					list3.Add(item3.getFormat());
				}
				Reference reference = objectFactory.ConstructReference(reference2.getName(), list2, list3);
				list.Add(reference);
				dictionary5[reference.Name] = reference;
			}
			IList<Teamcenter.Soa.Client.Model.Tool> editTools = ParseTools(xmlType.Name, datasetType.getEditTools(), datasetType.getActions(), dictionary5, tools);
			IList<Teamcenter.Soa.Client.Model.Tool> viewTools = ParseTools(xmlType.Name, datasetType.getViewTools(), datasetType.getActions(), dictionary5, tools);
			ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "ObjectFactory.constructDatasetType", xmlType.getName());
			soaType = objectFactory.ConstructDatasetType(xmlType.Uid, xmlType.TypeUid, xmlType.Name, xmlType.DisplayName, xmlType.ClassName, classHierarchy, GetType(xmlType.ParentTypeName, connection), owningType, dictionary2, dictionary4, conditionChoices3, ruleCategory2, viewTools, editTools, list);
		}
		else
		{
			ModelManagerImpl.LogDebug(ClassNames.CachelessClientMetaModel, logger, "ObjectFactory.constructType", xmlType.getName());
			soaType = objectFactory.ConstructType(xmlType.Uid, xmlType.TypeUid, xmlType.Name, xmlType.DisplayName, xmlType.ClassName, classHierarchy, GetType(xmlType.ParentTypeName, connection), owningType, dictionary2, dictionary4, conditionChoices3, ruleCategory2);
		}
		AddType(soaType);
	}

	protected ConditionChoices<Teamcenter.Soa.Client.Model.NamingRule> ParseNamingRule(PropertyDescriptor xmlPd, Connection connection)
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		ConditionChoices<Teamcenter.Soa.Client.Model.NamingRule> conditionChoices = new ConditionChoices<Teamcenter.Soa.Client.Model.NamingRule>(connection);
		ArrayList namingRules = xmlPd.getNamingRules();
		foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.NamingRule item in namingRules)
		{
			RuleCase caze = DefaultClientMetaModel.ParseRuleCase(item.Caze);
			ArrayList rulePatterns = item.getRulePatterns();
			IList<Teamcenter.Soa.Client.Model.RulePattern> list = new List<Teamcenter.Soa.Client.Model.RulePattern>();
			foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.RulePattern item2 in rulePatterns)
			{
				list.Add(objectFactory.ConstructeRulePattern(item2.getPattern(), item2.getAutogenerated(), item2.getInitialValue(), item2.getMaxValue()));
			}
			Teamcenter.Soa.Client.Model.NamingRule choice = objectFactory.ConstructNamingRule(item.getPattern(), caze, list);
			conditionChoices.addChoice(item.ConditionName, choice);
		}
		return conditionChoices;
	}

	protected Teamcenter.Soa.Client.Model.BasedOn parseBasedOn(PropertyDescriptor xmlPd)
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		Teamcenter.Schemas.Soa._2011_06.Metamodel.BasedOn basedOn = xmlPd.getBasedOn();
		if (basedOn == null || basedOn.getSourceProperty().Length == 0 || basedOn.getSourceType().Length == 0)
		{
			return null;
		}
		return objectFactory.ConstructBasedOn(basedOn.getSourceType(), basedOn.getSourceProperty());
	}

	protected ConditionChoices<string> ParseRenderers(PropertyDescriptor xmlPd, Connection connection)
	{
		ConditionChoices<string> conditionChoices = new ConditionChoices<string>(connection);
		ArrayList renderers = xmlPd.getRenderers();
		foreach (Renderer item in renderers)
		{
			conditionChoices.addChoice(item.getConditionName(), item.getRenderData());
		}
		return conditionChoices;
	}

	protected ConditionChoices<Teamcenter.Soa.Client.Model.RevNameRule> ParseRevNameRule(ModelType xmlType, Connection connection)
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		ConditionChoices<Teamcenter.Soa.Client.Model.RevNameRule> conditionChoices = new ConditionChoices<Teamcenter.Soa.Client.Model.RevNameRule>(connection);
		ArrayList revNameRules = xmlType.getRevNameRules();
		foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.RevNameRule item in revNameRules)
		{
			string description = item.getDescription();
			string secondaryStartRevision = item.getSecondaryStartRevision();
			string secondaryDescription = item.getSecondaryDescription();
			int secondaryType = item.getSecondaryType();
			string skipLetters = item.getSkipLetters();
			int alphabecticCase = item.getAlphabecticCase();
			int supplementalType = item.getSupplementalType();
			RuleType initType = RevNameRuleImpl.ConstructRuleType(item.getType());
			RuleType secondType = RevNameRuleImpl.ConstructRuleType(secondaryType);
			AlphabeticCase alphaCase = RevNameRuleImpl.ConstructAlphaCase(alphabecticCase);
			SupplementalRuleType suppRuleType = RevNameRuleImpl.ConstructSuppRuleType(supplementalType);
			Teamcenter.Soa.Client.Model.RevNameRule choice = objectFactory.ConstructRevNameRule(item.getName(), item.getStartRevision(), description, initType, secondaryStartRevision, secondaryDescription, secondType, item.getExcludeSkipLetters(), skipLetters, alphaCase, suppRuleType);
			conditionChoices.addChoice(item.getConditionName(), choice);
		}
		return conditionChoices;
	}

	private static string GetPropertyDescriptorNames(ArrayList descriptors)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = "";
		foreach (PropertyDescriptor descriptor in descriptors)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += descriptor.getName();
		}
		return text;
	}

	protected int GetLovCategory(PropertyDescriptor xmlDescriptor)
	{
		return xmlDescriptor.LovCategory;
	}

	protected IList<Teamcenter.Soa.Client.Model.Tool> ParseTools(string typeName, ArrayList xmlToolNames, ArrayList xmlDatasetActions, Dictionary<string, Reference> dataSetReferences, Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool> toolData)
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "ObjectFactory.constructTool", GetListOfNames(typeName, xmlToolNames));
		List<Teamcenter.Soa.Client.Model.Tool> list = new List<Teamcenter.Soa.Client.Model.Tool>();
		foreach (string xmlToolName in xmlToolNames)
		{
			if (!toolData.ContainsKey(xmlToolName))
			{
				logger.Warn(xmlToolName + " does not exist in the cache data.");
				continue;
			}
			Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool tool = toolData[xmlToolName];
			List<ToolAction> list2 = new List<ToolAction>();
			foreach (DatasetAction xmlDatasetAction in xmlDatasetActions)
			{
				if (!xmlDatasetAction.ToolName.Equals(xmlToolName))
				{
					continue;
				}
				Dictionary<string, Teamcenter.Soa.Client.Model.ActionReference> dictionary = new Dictionary<string, Teamcenter.Soa.Client.Model.ActionReference>();
				foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.ActionReference actionReference in xmlDatasetAction.getActionReferences())
				{
					string referenceName = actionReference.getReferenceName();
					Reference reference = dataSetReferences[referenceName];
					if (reference != null)
					{
						dictionary[referenceName] = objectFactory.ConstructActionReference(referenceName, actionReference.IsExprtSet && actionReference.Exprt, reference);
					}
				}
				list2.Add(objectFactory.ConstructToolAction(xmlDatasetAction.Action, dictionary));
			}
			list.Add(objectFactory.ConstructTool(tool.Name, tool.Description, tool.InputFormats, tool.OutputFormats, tool.LaunchCommandMac, tool.MimeType, tool.PackageName, tool.ReleaseDate, tool.Symbol, tool.VendorName, tool.Version, tool.CallbackEnabled, tool.DigitalSignatureCapable, tool.DownloadRequired, tool.EmbedApplication, tool.MarkupCapable, tool.ViewCapable, tool.VviRequired, list2));
		}
		return list;
	}

	private static string GetListOfNames(string typeName, ArrayList names)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = typeName + ": ";
		foreach (string name in names)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += name;
		}
		return text;
	}

	protected static IList<Style> GetStyleList(IList<string> propNames, string condition, Dictionary<string, PropertyDescriptor> otherXmlDescriptors)
	{
		IList<Style> list = new List<Style>();
		foreach (string propName in propNames)
		{
			PropertyDescriptor propertyDescriptor = otherXmlDescriptors[propName];
			foreach (LovReference lov in propertyDescriptor.getLovs())
			{
				if (lov.getConditionName().Equals(condition))
				{
					list.Add(DefaultClientMetaModel.ParseStyle(lov.Style));
					break;
				}
			}
		}
		if (list.Count != propNames.Count)
		{
			logger.Error("The computed list of Styles does not match the Dependent Property Names.");
			throw new ArgumentException("The computed list of Styles does not match the Dependent Property Names.");
		}
		return list;
	}
}
