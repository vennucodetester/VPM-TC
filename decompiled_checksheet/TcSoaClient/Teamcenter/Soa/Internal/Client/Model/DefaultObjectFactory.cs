using System.Collections.Generic;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class DefaultObjectFactory : ObjectFactory
{
	private static ModelObjectFactory sFactory = new LooseObjectFactory();

	public static void RegisterModelObjectFactory(ModelObjectFactory factory)
	{
		sFactory = factory;
	}

	public override SoaType ConstructType(string uid, string typeUid, string name, string displayName, string className, IList<string> classNameHierarchy, SoaType parent, string owningType, Dictionary<string, PropertyDescription> properties, Dictionary<string, string> constants, ConditionChoices<RevNameRule> revRules, RevisionRuleCategory ruleCategory)
	{
		return new SoaTypeImpl(uid, typeUid, name, displayName, className, classNameHierarchy, parent, owningType, properties, constants, revRules, ruleCategory);
	}

	public override RevNameRule ConstructRevNameRule(string name, string initStart, string initDescription, RuleType initType, string secondStart, string secondDescription, RuleType secondType, bool excludeLetters, string skipLetters, AlphabeticCase alphaCase, SupplementalRuleType suppRuleType)
	{
		return new RevNameRuleImpl(name, initStart, initDescription, initType, secondStart, secondDescription, secondType, excludeLetters, skipLetters, alphaCase, suppRuleType);
	}

	public override PropertyDescription ConstructPropertyDescription(string typeUid, string name, string displayName, int valueType, int propertyType, int maxLength, bool isArray, int maxArraySize, int fieldType, string compoundObjType, int lovCategory, Dictionary<string, string> constants, ConditionChoices<Lov> lovs, ConditionChoices<NamingRule> namingRules, ConditionChoices<string> renderers, RuleCategory ruleCategory, string minValue, string maxValue, BasedOn basedOn)
	{
		return new PropertyDescriptionImpl(typeUid, name, displayName, valueType, propertyType, maxLength, isArray, maxArraySize, fieldType, compoundObjType, lovCategory, ruleCategory, constants, lovs, namingRules, renderers, minValue, maxValue, basedOn);
	}

	public override NamingRule ConstructNamingRule(string pattern, RuleCase caze, IList<RulePattern> patterns)
	{
		return new NamingRuleImpl(pattern, caze, patterns);
	}

	public override RulePattern ConstructeRulePattern(string pattern, bool autoGen, int initVal, int maxVal)
	{
		return new RulePatternImpl(pattern, autoGen, initVal, maxVal);
	}

	public override BasedOn ConstructBasedOn(string sourceType, string sourceProperty)
	{
		return new BasedOnImpl(sourceType, sourceProperty);
	}

	public override LovValue ConstructLovValue(object value, string dislayValue, string description, string displayDescription, ConditionChoices<LovInfo> childLovChoices)
	{
		return new LovValueImpl(value, dislayValue, description, displayDescription, childLovChoices);
	}

	public override LovInfo ConstructLovInfo(string uid, string name, string displayName, string description, string displayDescription, SoaType type, int lovValueType, Usage usage, IList<string> typeNames, IList<string> propNames, IList<int> specifiers, ConditionChoices<LovValue> values)
	{
		return new LovInfoImpl(uid, name, displayName, description, displayDescription, type, lovValueType, usage, values);
	}

	public override Lov ConstructLov(Style style, IList<string> dependProps, IList<Style> dependStyles, string uid, int specifier, LovInfo info)
	{
		return new LovImpl(style, dependProps, dependStyles, uid, specifier, info);
	}

	public override Teamcenter.Soa.Client.Model.ModelObject ConstructModelObject(SoaType type, string uid)
	{
		return sFactory.ConstructObject(type, uid);
	}

	public override Teamcenter.Soa.Client.Model.Property AddProperty(Teamcenter.Soa.Client.Model.ModelObject modelObj, PropertyDescription propertyDescription, Teamcenter.Schemas.Soa._2006_03.Base.Property xmlProperty, ClientDataModel clientDataModel)
	{
		bool modifiable = (xmlProperty.IsModifiableSet ? xmlProperty.Modifiable : propertyDescription.Modifiable);
		PropertyImpl propertyImpl = PropertyImpl.createPropertyObject(xmlProperty.UiValues, xmlProperty.UiValue, modifiable, (PropertyDescriptionImpl)propertyDescription);
		PropertyValue[] values = xmlProperty.Values;
		if (values != null)
		{
			propertyImpl.AddRawValues(values, clientDataModel);
		}
		((ModelObjectImpl)modelObj).AddProperty(propertyDescription.Name, propertyImpl);
		return propertyImpl;
	}

	public override void AddProperty(Teamcenter.Soa.Client.Model.ModelObject modelObj, string name, string[] values)
	{
		((ModelObjectImpl)modelObj).AddProperty(name, values);
	}

	public override void UpdateVersion(Teamcenter.Soa.Client.Model.ModelObject modelObj, string objectID, string cParamID, bool isHistorical, bool isObsolete)
	{
		((ModelObjectImpl)modelObj).UpdateVersion(objectID, cParamID, isHistorical, isObsolete);
	}

	public override bool RefineType(Teamcenter.Soa.Client.Model.ModelObject obj, SoaType newType)
	{
		return ((ModelObjectImpl)obj).RefineType(newType);
	}

	public override Teamcenter.Soa.Client.Model.ErrorStack ConstructPartialError(ClientDataModel clientDataModel, Teamcenter.Schemas.Soa._2006_03.Base.ErrorStack xmlPartialError)
	{
		return new ErrorStackImpl(xmlPartialError, clientDataModel);
	}

	public override Teamcenter.Soa.Client.Model.PartialErrors ConstructPartialErrors(Teamcenter.Soa.Client.Model.ErrorStack[] partialErrors)
	{
		PartialErrorsImpl partialErrorsImpl = new PartialErrorsImpl();
		partialErrorsImpl.SetPartialErrors(partialErrors);
		return partialErrorsImpl;
	}

	public override Teamcenter.Soa.Client.Model.Preferences ConstructPreferences(Teamcenter.Schemas.Soa._2006_03.Base.Preferences xmlPreferences)
	{
		return new PreferencesImpl(xmlPreferences);
	}

	public override Teamcenter.Soa.Client.Model.ServiceData ConstructServiceData(ClientDataModel clientDataModel, Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData, Teamcenter.Soa.Client.Model.ErrorStack[] partialErrors)
	{
		return new ServiceDataImpl(clientDataModel, wireServiceData.getCreatedObjs(), wireServiceData.getDeletedObjs(), wireServiceData.getUpdatedObjs(), wireServiceData.getChildChangeObjs(), wireServiceData.getPlainObjs(), partialErrors);
	}

	public override DatasetType ConstructDatasetType(string uid, string typeUid, string name, string displayName, string className, IList<string> classNameHierarchy, SoaType parent, string owningType, Dictionary<string, PropertyDescription> properties, Dictionary<string, string> constants, ConditionChoices<RevNameRule> revRules, RevisionRuleCategory ruleCategory, IList<Tool> viewTools, IList<Tool> editTools, IList<Reference> references)
	{
		return new DatasetTypeImpl(uid, typeUid, name, displayName, className, classNameHierarchy, parent, owningType, properties, constants, revRules, ruleCategory, viewTools, editTools, references);
	}

	public override Tool ConstructTool(string name, string description, string[] inputFormats, string[] outputFormats, string launchCommandMac, string mimeType, string packageName, string releaseDate, string symbol, string vendorName, string version, bool callbackEnabled, bool digitalSignatureCapable, bool downloadRequired, bool embedApplication, bool markupCapable, bool viewCapable, bool vviRequired, IList<ToolAction> actions)
	{
		return new ToolImpl(name, description, inputFormats, outputFormats, launchCommandMac, mimeType, packageName, releaseDate, symbol, vendorName, version, callbackEnabled, digitalSignatureCapable, downloadRequired, embedApplication, markupCapable, viewCapable, vviRequired, actions);
	}

	public override ToolAction ConstructToolAction(string name, Dictionary<string, ActionReference> references)
	{
		return new ToolActionImpl(name, references);
	}

	public override ActionReference ConstructActionReference(string name, bool export, Reference reference)
	{
		return new ActionReferenceImpl(name, export, reference);
	}

	public override Reference ConstructReference(string name, IList<string> templates, IList<string> formats)
	{
		return new ReferenceImpl(name, templates, formats);
	}
}
