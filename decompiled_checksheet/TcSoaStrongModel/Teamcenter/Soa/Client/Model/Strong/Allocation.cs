namespace Teamcenter.Soa.Client.Model.Strong;

public class Allocation : ManagedRelation
{
	public AbsOccurrence Source_absOcc_tag => (AbsOccurrence)GetProperty("source_absOcc_tag").ModelObjectValue;

	public AbsOccurrence Target_absOcc_tag => (AbsOccurrence)GetProperty("target_absOcc_tag").ModelObjectValue;

	public ModelObject Config_condition => GetProperty("config_condition").ModelObjectValue;

	public AllocationMapRevision Map_rev_tag => (AllocationMapRevision)GetProperty("map_rev_tag").ModelObjectValue;

	public string Alloc_reason_string => GetProperty("alloc_reason_string").StringValue;

	public Allocation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
