using System.Collections.Generic;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Soa.Client.Model;

public abstract class ObjectFactory
{
	private static ObjectFactory theObjectFactory = null;

	public static void RegisterObjectFactory(ObjectFactory factory)
	{
		theObjectFactory = factory;
	}

	public static ObjectFactory GetObjectFactory()
	{
		if (theObjectFactory == null)
		{
			theObjectFactory = new DefaultObjectFactory();
		}
		return theObjectFactory;
	}

	public abstract ModelObject ConstructModelObject(SoaType type, string uid);

	public abstract Property AddProperty(ModelObject modelObj, PropertyDescription propertyDescription, Teamcenter.Schemas.Soa._2006_03.Base.Property xmlProperty, ClientDataModel clientDataModel);

	public abstract void AddProperty(ModelObject modelObj, string name, string[] values);

	public abstract void UpdateVersion(ModelObject modelObj, string objectID, string cParamID, bool isHistorical, bool isObsolete);

	public abstract bool RefineType(ModelObject modelObject, SoaType newType);

	public abstract ServiceData ConstructServiceData(ClientDataModel clientDataModel, Teamcenter.Schemas.Soa._2006_03.Base.ServiceData xmlServiceData, ErrorStack[] partialErrors);

	public abstract ErrorStack ConstructPartialError(ClientDataModel clientDataModel, Teamcenter.Schemas.Soa._2006_03.Base.ErrorStack xmlPartialError);

	public abstract PartialErrors ConstructPartialErrors(ErrorStack[] partialErrors);

	public abstract Preferences ConstructPreferences(Teamcenter.Schemas.Soa._2006_03.Base.Preferences xmlPreferences);

	public abstract SoaType ConstructType(string uid, string typeUid, string name, string displayName, string className, IList<string> classNameHierarchy, SoaType parent, string owningType, Dictionary<string, PropertyDescription> properties, Dictionary<string, string> constants, ConditionChoices<RevNameRule> revRules, RevisionRuleCategory ruleCategory);

	public abstract RevNameRule ConstructRevNameRule(string name, string initStart, string initDescription, RuleType initType, string secondStart, string secondDescription, RuleType secondType, bool excludeLetters, string skipLetters, AlphabeticCase alphaCase, SupplementalRuleType suppRuleType);

	public abstract PropertyDescription ConstructPropertyDescription(string typeUid, string name, string displayName, int valueType, int propertyType, int maxLength, bool isArray, int maxArraySize, int fieldType, string compoundObjType, int lovCategory, Dictionary<string, string> constants, ConditionChoices<Lov> lovs, ConditionChoices<NamingRule> namingRules, ConditionChoices<string> renderers, RuleCategory ruleCategory, string minValue, string maxValue, BasedOn basedOn);

	public abstract NamingRule ConstructNamingRule(string pattern, RuleCase caze, IList<RulePattern> patterns);

	public abstract RulePattern ConstructeRulePattern(string pattern, bool autoGen, int initVal, int maxVal);

	public abstract BasedOn ConstructBasedOn(string sourceType, string sourceProperty);

	public abstract LovValue ConstructLovValue(object value, string dislayValue, string description, string displayDescription, ConditionChoices<LovInfo> childLovChoices);

	public abstract LovInfo ConstructLovInfo(string uid, string name, string displayName, string description, string displayDescription, SoaType type, int lovValueType, Usage usage, IList<string> typeNames, IList<string> propNames, IList<int> specifiers, ConditionChoices<LovValue> values);

	public abstract Lov ConstructLov(Style style, IList<string> dependProps, IList<Style> dependStyles, string uid, int specifier, LovInfo info);

	public abstract DatasetType ConstructDatasetType(string uid, string typeUid, string name, string displayName, string className, IList<string> classNameHierarchy, SoaType parent, string owningType, Dictionary<string, PropertyDescription> properties, Dictionary<string, string> constants, ConditionChoices<RevNameRule> revRules, RevisionRuleCategory ruleCategory, IList<Tool> viewTools, IList<Tool> editTools, IList<Reference> references);

	public abstract Tool ConstructTool(string name, string description, string[] inputFormats, string[] outputFormats, string launchCommandMac, string mimeType, string packageName, string releaseDate, string symbol, string vendorName, string version, bool callbackEnabled, bool digitalSignatureCapable, bool downloadRequired, bool embedApplication, bool markupCapable, bool viewCapable, bool vviRequired, IList<ToolAction> actions);

	public abstract ToolAction ConstructToolAction(string name, Dictionary<string, ActionReference> references);

	public abstract ActionReference ConstructActionReference(string name, bool export, Reference reference);

	public abstract Reference ConstructReference(string name, IList<string> templates, IList<string> formats);
}
