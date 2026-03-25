using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ConfigurationContext : WorkspaceObject
{
	public VariantRule Variant_rule => (VariantRule)GetProperty("variant_rule").ModelObjectValue;

	public StoredOptionSet Sos => (StoredOptionSet)GetProperty("sos").ModelObjectValue;

	public string[] Revrule_strings => GetProperty("revrule_strings").StringArrayValue;

	public AssemblyArrangement Active_arrangement => (AssemblyArrangement)GetProperty("active_arrangement").ModelObjectValue;

	public string Mfg0VisibilityUncnfVar => GetProperty("Mfg0VisibilityUncnfVar").StringValue;

	public string Mfg0VisibilityUncnfAssgnOcc => GetProperty("Mfg0VisibilityUncnfAssgnOcc").StringValue;

	public string Mfg0VisibilityUncnfOccEff => GetProperty("Mfg0VisibilityUncnfOccEff").StringValue;

	public string Mfg0VisibilitySuppOcc => GetProperty("Mfg0VisibilitySuppOcc").StringValue;

	public string Mfg0VisibilityGCSConn => GetProperty("Mfg0VisibilityGCSConn").StringValue;

	public string Mfg0VisibilityUncnfChanges => GetProperty("Mfg0VisibilityUncnfChanges").StringValue;

	public bool Mfg0ApplyOccTypeFilters => GetProperty("Mfg0ApplyOccTypeFilters").BoolValue;

	public string[] Mfg0OccTypeFilters => GetProperty("Mfg0OccTypeFilters").StringArrayValue;

	public VariantRule[] Variant_rules
	{
		get
		{
			IList modelObjectListValue = GetProperty("variant_rules").ModelObjectListValue;
			VariantRule[] array = new VariantRule[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public int Fnd0cc_flags => GetProperty("fnd0cc_flags").IntValue;

	public Fnd0EffectvtyGrpRevision[] Fnd0EffectvtyGrpList
	{
		get
		{
			IList modelObjectListValue = GetProperty("Fnd0EffectvtyGrpList").ModelObjectListValue;
			Fnd0EffectvtyGrpRevision[] array = new Fnd0EffectvtyGrpRevision[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public RevisionRule Revision_rule => (RevisionRule)GetProperty("revision_rule").ModelObjectValue;

	public ClosureRule Closure_rule => (ClosureRule)GetProperty("closure_rule").ModelObjectValue;

	public ModelObject[] IMAN_manifestation => GetProperty("IMAN_manifestation").ModelObjectArrayValue;

	public ModelObject[] IMAN_specification => GetProperty("IMAN_specification").ModelObjectArrayValue;

	public ModelObject[] IMAN_reference => GetProperty("IMAN_reference").ModelObjectArrayValue;

	public ModelObject[] IMAN_requirement => GetProperty("IMAN_requirement").ModelObjectArrayValue;

	public ConfigurationContext(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
