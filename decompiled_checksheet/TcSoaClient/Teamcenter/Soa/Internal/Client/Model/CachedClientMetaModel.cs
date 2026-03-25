using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Schemas.Soa._2011_06.Metamodel;
using Teamcenter.Services.Internal.Loose.Core;
using Teamcenter.Services.Loose.Core;
using Teamcenter.Services.Loose.Core._2011_06.Session;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Common;
using Teamcenter.Soa.Common.Utils;
using log4net;

namespace Teamcenter.Soa.Internal.Client.Model;

public class CachedClientMetaModel : CachelessClientMetaModel
{
	private static XmlBindingUtils xmlBindingUtils = new XmlBindingUtils();

	private static ILog logger = LogManager.GetLogger(typeof(CachedClientMetaModel));

	private static readonly string TypesDataset = "Types";

	private static readonly string TypesFile = "%type%.xml";

	private static readonly string LovDataset = "Lov";

	private static readonly string LovIndexFile = "index.xml";

	private static readonly string ToolsDataset = "ToolsData";

	private static readonly string ToolsFile = "ToolsData.xml";

	private static readonly string TypeLocaleDataset = "type_%locale%";

	private static readonly string TypeLocaleFile = "%type%_%locale%.xml";

	private static readonly string LovLocaleDataset = "lov_%locale%";

	private static readonly string lovDoubleFormat = "###################0.0####################";

	private ObjectFactory factory = null;

	private Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool> toolData = null;

	private Dictionary<string, ZipEntry> lovIndex = null;

	private Dictionary<string, ZipEntry>[] lovL10NIndex = null;

	private bool initialized = false;

	private string[] locales = new string[1] { "en_US" };

	private Dictionary<string, ZipFile> datasetName2ZipFileMap = new Dictionary<string, ZipFile>();

	private static FileManagementUtility fmu = null;

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void Initialize(Dictionary<string, FileInfo> dsFolderMap, Connection connection)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		initialized = true;
		factory = ObjectFactory.GetObjectFactory();
		datasetName2ZipFileMap = new Dictionary<string, ZipFile>();
		try
		{
			foreach (string key in dsFolderMap.Keys)
			{
				datasetName2ZipFileMap[key] = new ZipFile(File.OpenRead(dsFolderMap[key].FullName));
			}
		}
		catch (IOException ex)
		{
			logger.Warn("Failed to read a Client Meta Model cache Zip file. " + ex.Message);
			datasetName2ZipFileMap.Clear();
			return;
		}
		InitLocales(connection);
		bool flag = true;
		for (int i = 0; i < locales.Length; i++)
		{
			if (!datasetName2ZipFileMap.ContainsKey(TypesDataset) || !datasetName2ZipFileMap.ContainsKey(LovDataset) || !datasetName2ZipFileMap.ContainsKey(ToolsDataset) || !datasetName2ZipFileMap.ContainsKey(TypeLocaleDataset.Replace("%locale%", locales[i])) || !datasetName2ZipFileMap.ContainsKey(LovLocaleDataset.Replace("%locale%", locales[i])))
			{
				flag = false;
			}
		}
		if (!flag)
		{
			string text = TypesDataset + ", " + LovDataset + ", " + ToolsDataset + ", ";
			for (int i = 0; i < locales.Length; i++)
			{
				string text2 = text;
				text = text2 + TypeLocaleDataset.Replace("%locale%", locales[i]) + ", " + LovLocaleDataset.Replace("%locale%", locales[i]) + ", ";
			}
			string text3 = "";
			IEnumerator enumerator2 = datasetName2ZipFileMap.Keys.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				if (text3.Length > 0)
				{
					text3 += ", ";
				}
				text3 += enumerator2.Current;
			}
			string text4 = "Failed to initialize the Client Meta Model cache. Need Datasets for " + text + ", but was supplied with only these Datasets " + text3;
			logger.Warn(LogCorrelation.GetId() + ": " + text4);
			datasetName2ZipFileMap.Clear();
			return;
		}
		lovIndex = IndexLovData(datasetName2ZipFileMap[LovDataset]);
		if (lovIndex == null)
		{
			datasetName2ZipFileMap.Clear();
			return;
		}
		lovL10NIndex = IndexLovL10nData(datasetName2ZipFileMap, locales);
		toolData = IndexTools(datasetName2ZipFileMap[ToolsDataset]);
		if (toolData == null)
		{
			datasetName2ZipFileMap.Clear();
		}
	}

	private void InitLocales(Connection connection)
	{
		locales = (connection.Locale.Equals(connection.SiteLocale) ? new string[1] : new string[2]);
		locales[0] = connection.Locale;
		if (locales.Length == 2)
		{
			locales[1] = connection.SiteLocale;
		}
		for (int i = 0; i < locales.Length; i++)
		{
			if (locales[i] == null || locales[i].Length == 0)
			{
				locales[i] = "en_US";
			}
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	private void Initialize(Connection connection)
	{
		if (initialized)
		{
			return;
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Dictionary<string, FileInfo> dictionary = null;
		Teamcenter.Soa.Common.Version version = new Teamcenter.Soa.Common.Version(9000, 1, 0);
		if (connection.ServerVersion >= version)
		{
			Teamcenter.Services.Loose.Core.SessionService service = Teamcenter.Services.Loose.Core.SessionService.getService(connection);
			ClientCacheInfo clientCacheData = service.GetClientCacheData(new string[1] { "ClientMetaModel" });
			if (clientCacheData.Features.Length == 1 && clientCacheData.Features[0].Name == "ClientMetaModel")
			{
				InitLocales(connection);
				dictionary = GetCacheZipFiles(clientCacheData.Features[0], connection, locales);
			}
			else
			{
				logger.Warn("The Client Meta Model Cache is not available. See your administrator about generating a client cache.");
			}
		}
		if (dictionary != null && dictionary.Count != 0)
		{
			Initialize(dictionary, connection);
		}
		else
		{
			initialized = true;
			factory = ObjectFactory.GetObjectFactory();
			datasetName2ZipFileMap = new Dictionary<string, ZipFile>();
		}
		stopwatch.Stop();
		logger.Info("CachedClientMetaModel.initialize " + stopwatch.ElapsedMilliseconds + "ms");
	}

	protected override void LoadTypes(IList<string> typeKeys, Connection connection)
	{
		Initialize(connection);
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		if (!datasetName2ZipFileMap.ContainsKey(TypesDataset))
		{
			base.LoadTypes(typeKeys, connection);
			return;
		}
		List<string> list = new List<string>();
		for (int i = 0; i < typeKeys.Count; i++)
		{
			string text = typeKeys[i];
			if (text.IndexOf(":") != -1)
			{
				string[] array = text.Split(':');
				string item = array[1];
				list.Add(item);
			}
			else
			{
				list.Add(text);
			}
		}
		IList<string> list2 = LoadTypesFromCache(list, connection);
		if (logger.IsInfoEnabled)
		{
			stopwatch.Stop();
			string listOfNames = GetListOfNames(typeKeys, logger.IsInfoEnabled);
			string message = LogCorrelation.GetId() + ":" + string.Format("{0,-65:s}", " CachedClientMetaModel.loadTypes") + "(Time: " + $"{stopwatch.ElapsedMilliseconds,9:D}ms" + ", Types Retrieved: " + listOfNames + ")";
			logger.Info(message);
		}
		if (list2.Count > 0)
		{
			base.LoadTypes(list2, connection);
		}
	}

	protected override void LoadLovInfo(string uid, SoaType type, Connection connection)
	{
		Initialize(connection);
		if (datasetName2ZipFileMap[TypesDataset] == null)
		{
			base.LoadLovInfo(uid, type, connection);
			return;
		}
		try
		{
			Teamcenter.Soa.Client.Model.LovInfo lovInfo = null;
			Teamcenter.Schemas.Soa._2011_06.Metamodel.LovInfo lovInfo2 = ParseLovInfo(uid);
			if (lovInfo2 == null)
			{
				logger.Warn("The Type/LOV data contains a LOV UID (" + uid + ") that does not exist.");
				return;
			}
			string typeKey = ((lovInfo2.BasedOnType != null) ? lovInfo2.BasedOnType : lovInfo2.TypeName);
			SoaType type2 = GetType(typeKey, connection);
			Usage usage = DefaultClientMetaModel.ParseUsage(lovInfo2.Usage);
			int lovValueType = DefaultClientMetaModel.GetLovValueType(type2);
			ConditionChoices<Teamcenter.Soa.Client.Model.LovValue> conditionChoices = null;
			LovL10N[] lovL10Ns = GetLovL10Ns(uid);
			conditionChoices = ((!usage.Equals(Usage.Range)) ? ParseLovValues(uid, type2, lovValueType, usage, lovInfo2.Name, lovInfo2.getValues(), lovL10Ns, connection) : ParseLovRange(uid, type2, lovValueType, lovInfo2, lovL10Ns, connection));
			string text = ((lovInfo2.Description == null) ? "" : lovInfo2.Description);
			string localizedLovName = GetLocalizedLovName(lovL10Ns, lovInfo2.Name);
			string localizedLovDescription = GetLocalizedLovDescription(lovL10Ns, text);
			IList<string> stringList = DefaultClientMetaModel.GetStringList(lovInfo2.AttachedTypes);
			IList<string> stringList2 = DefaultClientMetaModel.GetStringList(lovInfo2.AttachedProps);
			IList<int> integerList = GetIntegerList(lovInfo2.AttachedSpecs);
			lovInfo = factory.ConstructLovInfo(uid, lovInfo2.Name, localizedLovName, text, localizedLovDescription, type2, lovValueType, usage, stringList, stringList2, integerList, conditionChoices);
			AddLovInfo(lovInfo);
		}
		catch (SystemException ex)
		{
			logger.Warn("Failed to load data for LOV UID (" + uid + ")");
			logger.Debug(ex.Message);
		}
	}

	public override bool IsTypeValid(string typeName, Connection connection)
	{
		if (!datasetName2ZipFileMap.ContainsKey(TypesDataset))
		{
			return base.IsTypeValid(typeName, connection);
		}
		if (ContainsType(typeName))
		{
			if (GetType(typeName, connection) != null)
			{
				return true;
			}
			return false;
		}
		ZipFile val = datasetName2ZipFileMap[TypesDataset];
		ZipEntry entry = val.GetEntry(TypesFile.Replace("%type%", typeName));
		return entry != null;
	}

	private IList<string> LoadTypesFromCache(IList<string> typeKeys, Connection connection)
	{
		List<string> list = new List<string>();
		if (typeKeys.Count == 0)
		{
			return list;
		}
		ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "loadTypesFromCache", GetListOfNames(typeKeys, logger.IsDebugEnabled));
		ZipFile val = datasetName2ZipFileMap[TypesDataset];
		foreach (string typeKey in typeKeys)
		{
			ZipEntry entry = val.GetEntry(TypesFile.Replace("%type%", typeKey));
			if (entry == null)
			{
				logger.Info(LogCorrelation.GetId() + ": CachedClientMetaModel.loadTypes -- Schema for " + typeKey + " does not exist. Load it from server");
				continue;
			}
			object obj = ParseXMLInputStream(val.GetInputStream(entry), typeof(ModelSchema));
			ModelSchema modelSchema = (ModelSchema)obj;
			if (modelSchema == null || modelSchema.Types.Length != 1)
			{
				logger.Warn(LogCorrelation.GetId() + ": CachedClientMetaModel.loadTypes -- Failed to parse schema for " + TypesFile.Replace("%type%", typeKey));
				continue;
			}
			try
			{
				ParseModelType(typeKey, modelSchema.Types[0], connection);
			}
			catch (SystemException ex)
			{
				logger.Warn("CachedClientMetaModel.loadTypes -- Failed to load data for " + TypesFile.Replace("%type%", typeKey));
				logger.Warn("CachedClientMetaModel.loadTypes -- " + ex.Message);
			}
		}
		foreach (string typeKey2 in typeKeys)
		{
			if (typeKey2 != null && typeKey2 != "" && !ContainsType(typeKey2))
			{
				list.Add(typeKey2);
			}
		}
		return list;
	}

	private void ParseModelType(string typeName, ModelType xmlType, Connection connection)
	{
		TypeL10N[] array = GeTypeL10ns(typeName);
		ArrayList propertyDescriptors = xmlType.getPropertyDescriptors();
		string localizedTypeName = GetLocalizedTypeName(array, typeName);
		SoaType type = GetType(xmlType.ParentTypeName, connection);
		string owningType = ((xmlType.OwningType == null) ? "" : xmlType.OwningType);
		string parentTypeName = ((xmlType.ParentTypeName == null) ? "" : xmlType.ParentTypeName);
		IList<string> classHierarchy = DefaultClientMetaModel.GetClassHierarchy(xmlType.Name, xmlType.ClassName, parentTypeName, owningType, connection);
		IList<string> typeHierarchy = DefaultClientMetaModel.GetTypeHierarchy(xmlType.Name, parentTypeName, connection);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Constant constant in xmlType.getConstants())
		{
			dictionary[constant.Name] = constant.Value;
		}
		ConditionChoices<Teamcenter.Soa.Client.Model.RevNameRule> conditionChoices = ParseRevNameRule(xmlType, connection);
		RevisionRuleCategory ruleCategory = RevisionRuleCategory.None;
		if (conditionChoices.peekAtCondition() != null)
		{
			ruleCategory = (conditionChoices.peekAtCondition().Equals(ConditionResolver.IS_TRUE) ? RevisionRuleCategory.IsTrue : RevisionRuleCategory.SessionCondition);
		}
		Dictionary<string, PropertyDescription> properties = ParsePropertyDescriptorFromCache(xmlType.Uid, typeHierarchy, propertyDescriptors, array, connection);
		SoaType soaType = null;
		if (xmlType is Teamcenter.Schemas.Soa._2011_06.Metamodel.DatasetType)
		{
			Teamcenter.Schemas.Soa._2011_06.Metamodel.DatasetType datasetType = (Teamcenter.Schemas.Soa._2011_06.Metamodel.DatasetType)xmlType;
			Dictionary<string, Reference> dictionary2 = new Dictionary<string, Reference>();
			IList<Reference> list = new List<Reference>();
			foreach (DatasetReference reference2 in datasetType.getReferences())
			{
				IList<string> list2 = new List<string>();
				IList<string> list3 = new List<string>();
				foreach (DatasetReferenceInfo item in reference2.getInfo())
				{
					list2.Add(item.getTmplate());
					list3.Add(item.getFormat());
				}
				Reference reference = factory.ConstructReference(reference2.getName(), list2, list3);
				list.Add(reference);
				dictionary2[reference.Name] = reference;
			}
			IList<Teamcenter.Soa.Client.Model.Tool> editTools = ParseTools(xmlType.Name, datasetType.getEditTools(), datasetType.getActions(), dictionary2, toolData);
			IList<Teamcenter.Soa.Client.Model.Tool> viewTools = ParseTools(xmlType.Name, datasetType.getViewTools(), datasetType.getActions(), dictionary2, toolData);
			ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "ObjectFactory.constructDatasetType", xmlType.getName());
			soaType = factory.ConstructDatasetType(xmlType.Uid, xmlType.TypeUid, xmlType.Name, localizedTypeName, xmlType.ClassName, classHierarchy, type, owningType, properties, dictionary, conditionChoices, ruleCategory, viewTools, editTools, list);
		}
		else
		{
			ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "ObjectFactory.constructType", xmlType.getName());
			soaType = factory.ConstructType(xmlType.Uid, xmlType.TypeUid, xmlType.getName(), localizedTypeName, xmlType.ClassName, classHierarchy, type, owningType, properties, dictionary, conditionChoices, ruleCategory);
		}
		AddType(soaType);
	}

	private Dictionary<string, PropertyDescription> ParsePropertyDescriptorFromCache(string typeUid, IList<string> typeNameHierarchy, ArrayList xmlDescriptors, TypeL10N[] typeL10Ns, Connection connection)
	{
		Dictionary<string, PropertyDescription> dictionary = new Dictionary<string, PropertyDescription>();
		Dictionary<string, PropertyDescriptor> dictionary2 = new Dictionary<string, PropertyDescriptor>();
		foreach (PropertyDescriptor xmlDescriptor in xmlDescriptors)
		{
			dictionary2[xmlDescriptor.getName()] = xmlDescriptor;
		}
		ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "ObjectFactory.constructPropertyDescription", GetPropertyDescriptorNames(typeNameHierarchy[0], xmlDescriptors));
		foreach (PropertyDescriptor xmlDescriptor2 in xmlDescriptors)
		{
			string localizedPropName = GetLocalizedPropName(typeL10Ns, xmlDescriptor2.Name);
			int arraySize = GetArraySize(xmlDescriptor2);
			int lovCategory = GetLovCategory(xmlDescriptor2);
			ConditionChoices<Teamcenter.Soa.Client.Model.NamingRule> conditionChoices = ParseNamingRule(xmlDescriptor2, connection);
			ConditionChoices<Lov> lovs = ParseLovReferences(typeNameHierarchy, xmlDescriptor2, dictionary2, connection);
			ConditionChoices<string> renderers = ParseRenderers(xmlDescriptor2, connection);
			int fieldType = xmlDescriptor2.FieldType;
			string compoundObjType = ((xmlDescriptor2.CompoundObjType != null) ? xmlDescriptor2.CompoundObjType : "");
			Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
			foreach (Constant constant in xmlDescriptor2.getConstants())
			{
				dictionary3[constant.Name] = constant.Value;
			}
			RuleCategory ruleCategory = RuleCategory.None;
			if (conditionChoices.peekAtCondition() != null)
			{
				ruleCategory = (conditionChoices.peekAtCondition().Equals(ConditionResolver.IS_TRUE) ? RuleCategory.IsTrue : RuleCategory.SessionCondition);
			}
			Teamcenter.Soa.Client.Model.BasedOn basedOn = parseBasedOn(xmlDescriptor2);
			PropertyDescription value = factory.ConstructPropertyDescription(typeUid, xmlDescriptor2.Name, localizedPropName, xmlDescriptor2.ValueType, xmlDescriptor2.PropertyType, xmlDescriptor2.MaxLength, xmlDescriptor2.AnArray, arraySize, fieldType, compoundObjType, lovCategory, dictionary3, lovs, conditionChoices, renderers, ruleCategory, xmlDescriptor2.MinValue, xmlDescriptor2.MaxValue, basedOn);
			dictionary[xmlDescriptor2.Name] = value;
		}
		return dictionary;
	}

	private int GetArraySize(PropertyDescriptor xmlDescriptor)
	{
		int result = 1;
		if (xmlDescriptor.AnArray)
		{
			result = xmlDescriptor.MaxArraySize;
		}
		return result;
	}

	private IList<int> GetIntegerList(string numbers)
	{
		List<int> list = new List<int>();
		if (numbers != null && numbers.Length > 0)
		{
			string[] array = numbers.Split(',');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = text.Trim();
				if (text2.Length != 0)
				{
					list.Add(Convert.ToInt32(text2));
				}
			}
		}
		return list;
	}

	private ConditionChoices<Lov> ParseLovReferences(IList<string> typeNameHierarchy, PropertyDescriptor xmlDescriptor, Dictionary<string, PropertyDescriptor> xmlDescriptors, Connection connection)
	{
		ConditionChoices<Lov> conditionChoices = new ConditionChoices<Lov>(connection);
		ArrayList lovs = xmlDescriptor.getLovs();
		foreach (LovReference item in lovs)
		{
			Teamcenter.Soa.Client.Model.LovInfo lovInfo = GetLovInfo(item.LovUid, GetType(item.LovTypeUid, connection), connection);
			if (lovInfo != null)
			{
				Style style = DefaultClientMetaModel.ParseStyle(item.Style);
				IList<string> stringList = DefaultClientMetaModel.GetStringList(item.PropDependents);
				IList<Style> styleList = CachelessClientMetaModel.GetStyleList(stringList, item.getConditionName(), xmlDescriptors);
				int specifier = Convert.ToInt32(item.Specifier);
				ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "ObjectFactory.constructLov", xmlDescriptor.Name);
				Lov choice = factory.ConstructLov(style, stringList, styleList, item.LovUid, specifier, lovInfo);
				string conditionName = item.ConditionName;
				if (conditionName == null)
				{
					logger.Error("The cached LOV data for " + typeNameHierarchy[0] + "/" + xmlDescriptor.Name + " does not have a condition");
				}
				conditionChoices.addChoice(conditionName, choice);
			}
		}
		return conditionChoices;
	}

	private ConditionChoices<Teamcenter.Soa.Client.Model.LovValue> ParseLovRange(string lovUid, SoaType lovType, int lovValueType, Teamcenter.Schemas.Soa._2011_06.Metamodel.LovInfo xmlLovInfo, LovL10N[] lovL10Ns, Connection connection)
	{
		ConditionChoices<Teamcenter.Soa.Client.Model.LovValue> conditionChoices = new ConditionChoices<Teamcenter.Soa.Client.Model.LovValue>();
		object obj = DefaultClientMetaModel.ParseLovValue(lovValueType, xmlLovInfo.Range.LowerBound, connection);
		object obj2 = DefaultClientMetaModel.ParseLovValue(lovValueType, xmlLovInfo.Range.UpperBound, connection);
		conditionChoices = new ConditionChoices<Teamcenter.Soa.Client.Model.LovValue>();
		string localizedLovValue = GetLocalizedLovValue(lovL10Ns, xmlLovInfo.Range.LowerBound, "", obj, isRange: true);
		string localizedLovValue2 = GetLocalizedLovValue(lovL10Ns, xmlLovInfo.Range.UpperBound, "", obj2, isRange: true);
		Teamcenter.Soa.Client.Model.LovValue choice = factory.ConstructLovValue(obj, localizedLovValue, "", "", new ConditionChoices<Teamcenter.Soa.Client.Model.LovInfo>());
		Teamcenter.Soa.Client.Model.LovValue choice2 = factory.ConstructLovValue(obj2, localizedLovValue2, "", "", new ConditionChoices<Teamcenter.Soa.Client.Model.LovInfo>());
		conditionChoices.addChoice(choice);
		conditionChoices.addChoice(choice2);
		return conditionChoices;
	}

	private ConditionChoices<Teamcenter.Soa.Client.Model.LovValue> ParseLovValues(string lovUid, SoaType lovType, int lovValueType, Usage usage, string lovName, ArrayList xmlValues, LovL10N[] lovL10Ns, Connection connection)
	{
		if (xmlValues.Count == 0)
		{
			ConditionChoices<Teamcenter.Soa.Client.Model.LovValue> conditionChoices = new ConditionChoices<Teamcenter.Soa.Client.Model.LovValue>();
			Teamcenter.Soa.Client.Model.LovValue choice = new DynamicLovValues(lovUid, lovName, lovType, usage, connection);
			conditionChoices.addChoice(choice);
			return conditionChoices;
		}
		ModelManagerImpl.LogDebug(ClassNames.CachedClientMetaModel, logger, "ObjectFactory.constructLovValue", GetPropertyLovValues(lovName, xmlValues));
		ConditionChoices<Teamcenter.Soa.Client.Model.LovValue> conditionChoices2 = new ConditionChoices<Teamcenter.Soa.Client.Model.LovValue>(connection);
		LoadModelObjects(lovName, lovValueType, xmlValues, connection);
		foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.LovValue xmlValue in xmlValues)
		{
			ConditionChoices<Teamcenter.Soa.Client.Model.LovInfo> conditionChoices3 = new ConditionChoices<Teamcenter.Soa.Client.Model.LovInfo>(connection);
			ArrayList attachedLov = xmlValue.getAttachedLov();
			foreach (AttachedLov item in attachedLov)
			{
				Teamcenter.Soa.Client.Model.LovInfo lovInfo = GetLovInfo(item.LovUid, lovType, connection);
				if (lovInfo != null)
				{
					conditionChoices3.addChoice(item.ConditionName, lovInfo);
				}
			}
			object obj = DefaultClientMetaModel.ParseLovValue(lovValueType, xmlValue.Value, connection);
			string text = ((xmlValue.Description == null) ? "" : xmlValue.Description);
			string localizedLovValue = GetLocalizedLovValue(lovL10Ns, xmlValue.Value, text, obj, isRange: false);
			string localizedLovValueDescription = GetLocalizedLovValueDescription(lovL10Ns, text);
			Teamcenter.Soa.Client.Model.LovValue choice2 = factory.ConstructLovValue(obj, localizedLovValue, text, localizedLovValueDescription, conditionChoices3);
			conditionChoices2.addChoice(xmlValue.ConditionName, choice2);
		}
		return conditionChoices2;
	}

	private void LoadModelObjects(string lovName, int lovValueType, ArrayList xmlValues, Connection connection)
	{
		if (lovValueType != 8)
		{
			return;
		}
		ClientDataModel clientDataModel = connection.ClientDataModel;
		List<ModelObject> list = new List<ModelObject>();
		foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.LovValue xmlValue in xmlValues)
		{
			if (!clientDataModel.ContainsObject(xmlValue.Value))
			{
				list.Add(clientDataModel.ConstructObject(xmlValue.Value));
			}
		}
		Teamcenter.Services.Internal.Loose.Core.SessionService service = Teamcenter.Services.Internal.Loose.Core.SessionService.getService(connection);
		logger.Info("Loading Referenced Object for LOV " + lovName);
		service.GetProperties(list.ToArray(), new string[0]);
	}

	private TypeL10N[] GeTypeL10ns(string typeName)
	{
		TypeL10N[] array = new TypeL10N[locales.Length];
		for (int i = 0; i < locales.Length; i++)
		{
			array[i] = null;
			ZipFile val = datasetName2ZipFileMap[TypeLocaleDataset.Replace("%locale%", locales[i])];
			ZipEntry entry = val.GetEntry(TypeLocaleFile.Replace("%locale%", locales[i]).Replace("%type%", typeName));
			if (entry != null)
			{
				object obj = ParseXMLInputStream(val.GetInputStream(entry), typeof(L10NData));
				L10NData l10NData = (L10NData)obj;
				if (l10NData != null && l10NData.Types.Length == 1)
				{
					array[i] = l10NData.Types[0];
				}
			}
		}
		return array;
	}

	private string GetLocalizedTypeName(TypeL10N[] typeL10ns, string typeName)
	{
		foreach (TypeL10N typeL10N in typeL10ns)
		{
			if (typeL10N != null)
			{
				string uiName = typeL10N.UiName;
				if (uiName != null && uiName.Length > 0)
				{
					return uiName;
				}
			}
		}
		return typeName;
	}

	private string GetLocalizedPropName(TypeL10N[] typeL10ns, string propName)
	{
		foreach (TypeL10N typeL10N in typeL10ns)
		{
			if (typeL10N == null)
			{
				continue;
			}
			foreach (PropertyL10N propertyDescriptor in typeL10N.getPropertyDescriptors())
			{
				if (propertyDescriptor.Name.Equals(propName))
				{
					string uiName = propertyDescriptor.UiName;
					if (uiName != null && uiName.Length > 0)
					{
						return uiName;
					}
				}
			}
		}
		return propName;
	}

	private LovL10N[] GetLovL10Ns(string uid)
	{
		LovL10N[] array = new LovL10N[lovL10NIndex.Length];
		for (int i = 0; i < lovL10NIndex.Length; i++)
		{
			Dictionary<string, ZipEntry> dictionary = lovL10NIndex[i];
			array[i] = null;
			if (dictionary != null && dictionary.ContainsKey(uid))
			{
				ZipFile lovLocaleZipFile = datasetName2ZipFileMap[LovLocaleDataset.Replace("%locale%", locales[i])];
				LovL10N lovL10N = ParseLovL10NInfo(lovLocaleZipFile, dictionary[uid]);
				if (lovL10N != null)
				{
					array[i] = lovL10N;
				}
			}
		}
		return array;
	}

	private string GetLocalizedLovName(LovL10N[] myLovL10Ns, string lovName)
	{
		foreach (LovL10N lovL10N in myLovL10Ns)
		{
			if (lovL10N != null)
			{
				string uiName = lovL10N.UiName;
				if (uiName != null && uiName.Length > 0)
				{
					return uiName;
				}
			}
		}
		return lovName;
	}

	private string GetLocalizedLovDescription(LovL10N[] myLovL10Ns, string lovDescription)
	{
		foreach (LovL10N lovL10N in myLovL10Ns)
		{
			if (lovL10N != null)
			{
				string uiDescription = lovL10N.UiDescription;
				if (uiDescription != null && uiDescription.Length > 0)
				{
					return uiDescription;
				}
			}
		}
		return lovDescription;
	}

	private string GetLocalizedLovValue(LovL10N[] myLovL10Ns, string xmlValue, string xmlDescription, object realValue, bool isRange)
	{
		foreach (LovL10N lovL10N in myLovL10Ns)
		{
			if (lovL10N == null)
			{
				continue;
			}
			foreach (LovValueL10N value in lovL10N.getValues())
			{
				if (value.Value.Equals(xmlValue))
				{
					string uiValue = value.UiValue;
					if (uiValue != null && uiValue.Length > 0)
					{
						return uiValue;
					}
				}
			}
		}
		if (realValue is DateTime dateTime)
		{
			return dateTime.ToString(dateFormat);
		}
		if (realValue is double num)
		{
			if (isRange)
			{
				return num.ToString(numberFormat);
			}
			return num.ToString(lovDoubleFormat);
		}
		if (realValue is ModelObject)
		{
			return ((ModelObject)realValue).Uid;
		}
		return realValue.ToString();
	}

	private string GetLocalizedLovValueDescription(LovL10N[] myLovL10Ns, string description)
	{
		if (description == null)
		{
			return null;
		}
		foreach (LovL10N lovL10N in myLovL10Ns)
		{
			if (lovL10N == null)
			{
				continue;
			}
			foreach (LovValueL10N value in lovL10N.getValues())
			{
				if (value.Value.Equals(description))
				{
					string uiValue = value.UiValue;
					if (uiValue != null && uiValue.Length > 0)
					{
						return uiValue;
					}
				}
			}
		}
		return description;
	}

	private static string GetListOfNames(IList<string> typeKeys, bool enablbled)
	{
		if (!enablbled)
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

	private static string GetPropertyDescriptorNames(string typeName, ArrayList descriptors)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = "";
		text += typeName;
		text += ": ";
		foreach (PropertyDescriptor descriptor in descriptors)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += descriptor.Name;
		}
		return text;
	}

	private static string GetPropertyLovValues(string name, ArrayList values)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = "";
		text += name;
		text += ": ";
		foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.LovValue value in values)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += value.Value;
		}
		return text;
	}

	private static object ParseXMLInputStream(Stream zipStream, Type xmlType)
	{
		Type[] extraTypes = null;
		try
		{
			byte[] array = new byte[4096];
			using StringWriter stringWriter = new StringWriter();
			for (int num = zipStream.Read(array, 0, 4096); num > 0; num = zipStream.Read(array, 0, 4096))
			{
				string value = Encoding.UTF8.GetString(array, 0, num);
				stringWriter.Write(value);
			}
			stringWriter.Flush();
			string inpXml = stringWriter.ToString();
			stringWriter.Close();
			return xmlBindingUtils.Deserialize(inpXml, xmlType, extraTypes);
		}
		catch (Exception ex)
		{
			logger.Info(LogCorrelation.GetId() + ": Failed to read from the Zip file" + ex.Message);
			return null;
		}
	}

	private static void GetADatasetFile(Feature clientMetaModelFeature, Connection connection, string dataset, Dictionary<string, FileInfo> dsFolderMap)
	{
		string text = (string)clientMetaModelFeature.CacheTickets[dataset];
		if (text == null)
		{
			ICollection keys = clientMetaModelFeature.CacheTickets.Keys;
			string text2 = "";
			foreach (string item in keys)
			{
				if (text2.Length > 0)
				{
					text2 += ", ";
				}
				text2 += item;
			}
			string msg = "Failed to get ticket for " + dataset + ". Available Datasets are: " + text2;
			throw new InternalServerException(msg, 531, 3);
		}
		if (fmu == null)
		{
			fmu = new FileManagementUtility(connection);
		}
		FileInfo file = fmu.GetFile(text);
		dsFolderMap[dataset] = file;
	}

	private static Dictionary<string, FileInfo> GetCacheZipFiles(Feature clientMetaModelFeature, Connection connection, string[] locales)
	{
		Dictionary<string, FileInfo> dictionary = new Dictionary<string, FileInfo>();
		try
		{
			GetADatasetFile(clientMetaModelFeature, connection, TypesDataset, dictionary);
			GetADatasetFile(clientMetaModelFeature, connection, LovDataset, dictionary);
			GetADatasetFile(clientMetaModelFeature, connection, ToolsDataset, dictionary);
			foreach (string newValue in locales)
			{
				GetADatasetFile(clientMetaModelFeature, connection, TypeLocaleDataset.Replace("%locale%", newValue), dictionary);
				GetADatasetFile(clientMetaModelFeature, connection, LovLocaleDataset.Replace("%locale%", newValue), dictionary);
			}
			return dictionary;
		}
		catch (InternalServerException ex)
		{
			logger.Info(LogCorrelation.GetId() + ": " + ex.Message);
			return new Dictionary<string, FileInfo>();
		}
	}

	private static Dictionary<string, ZipEntry> IndexLovData(ZipFile lovZipFile)
	{
		Dictionary<string, ZipEntry> dictionary = null;
		ZipEntry entry = lovZipFile.GetEntry(LovIndexFile);
		if (entry == null)
		{
			logger.Warn(LogCorrelation.GetId() + ": Filed to get the LOV Index file.");
			return null;
		}
		object obj = ParseXMLInputStream(lovZipFile.GetInputStream(entry), typeof(Index));
		if (obj != null)
		{
			Index index = (Index)obj;
			KeyValue[] pairs = index.Pairs;
			if (pairs.Length == 0)
			{
				logger.Warn(LogCorrelation.GetId() + ": The LOV Data file appears to be empty.");
				return null;
			}
			dictionary = new Dictionary<string, ZipEntry>();
			KeyValue[] array = pairs;
			foreach (KeyValue keyValue in array)
			{
				ZipEntry entry2 = lovZipFile.GetEntry(keyValue.Value);
				if (entry2 == null)
				{
					logger.Warn(LogCorrelation.GetId() + ": Failed to get the LOV " + keyValue.Value + " file.");
					return null;
				}
				dictionary[keyValue.Name] = entry2;
			}
			return dictionary;
		}
		return null;
	}

	private Teamcenter.Schemas.Soa._2011_06.Metamodel.LovInfo ParseLovInfo(string uid)
	{
		if (!lovIndex.ContainsKey(uid))
		{
			logger.Warn("LOV UID " + uid + " does not exist in the cache data.");
			return null;
		}
		ZipFile val = datasetName2ZipFileMap[LovDataset];
		ZipEntry val2 = lovIndex[uid];
		object obj = ParseXMLInputStream(val.GetInputStream(val2), typeof(LovData));
		if (obj != null)
		{
			LovData lovData = (LovData)obj;
			Teamcenter.Schemas.Soa._2011_06.Metamodel.LovInfo[] lovs = lovData.Lovs;
			if (lovs.Length == 0)
			{
				logger.Warn(string.Concat(LogCorrelation.GetId(), ": The LOV Data file,", val2, ", appears to be empty."));
				return null;
			}
			return lovs[0];
		}
		return null;
	}

	private static Dictionary<string, ZipEntry>[] IndexLovL10nData(Dictionary<string, ZipFile> lovLocaleData, string[] locales)
	{
		ZipFile[] array = (ZipFile[])(object)new ZipFile[locales.Length];
		Dictionary<string, ZipEntry>[] array2 = new Dictionary<string, ZipEntry>[locales.Length];
		for (int i = 0; i < locales.Length; i++)
		{
			array[i] = lovLocaleData[LovLocaleDataset.Replace("%locale%", locales[i])];
			array2[i] = null;
			object obj = ParseXMLInputStream(array[i].GetInputStream(array[i].GetEntry(LovIndexFile)), typeof(Index));
			if (obj == null)
			{
				continue;
			}
			Index index = (Index)obj;
			Dictionary<string, ZipEntry> dictionary = new Dictionary<string, ZipEntry>();
			ArrayList pairs = index.getPairs();
			foreach (KeyValue item in pairs)
			{
				ZipEntry entry = array[i].GetEntry(item.Value);
				if (entry == null)
				{
					logger.Warn(LogCorrelation.GetId() + ": Failed to get the LOV Data file " + item.Value + ".");
					return null;
				}
				dictionary[item.Name] = entry;
			}
			array2[i] = dictionary;
		}
		return array2;
	}

	private LovL10N ParseLovL10NInfo(ZipFile lovLocaleZipFile, ZipEntry lovLocalEntry)
	{
		object obj = ParseXMLInputStream(lovLocaleZipFile.GetInputStream(lovLocalEntry), typeof(L10NData));
		if (obj != null)
		{
			L10NData l10NData = (L10NData)obj;
			LovL10N[] lovs = l10NData.Lovs;
			if (lovs.Length == 0)
			{
				logger.Warn(LogCorrelation.GetId() + ": The LOV L10N Data file," + lovLocalEntry.Name + ", appears to be empty.");
				return null;
			}
			return lovs[0];
		}
		return null;
	}

	private static Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool> IndexTools(ZipFile toolsZipFile)
	{
		Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool> dictionary = null;
		object obj = ParseXMLInputStream(toolsZipFile.GetInputStream(toolsZipFile.GetEntry(ToolsFile)), typeof(ToolData));
		if (obj != null)
		{
			ToolData toolData = (ToolData)obj;
			ArrayList tools = toolData.getTools();
			if (tools.Count == 0)
			{
				logger.Warn(LogCorrelation.GetId() + ": The Tools Data file appears to be empty.");
				return null;
			}
			dictionary = new Dictionary<string, Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool>();
			foreach (Teamcenter.Schemas.Soa._2011_06.Metamodel.Tool item in tools)
			{
				dictionary[item.Name] = item;
			}
			return dictionary;
		}
		return null;
	}
}
