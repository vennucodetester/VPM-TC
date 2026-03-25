namespace Teamcenter.Soa.Client.Model.Strong;

public class AllocationLine : RuntimeBusinessObject
{
	public string Allocation_line_reason => GetProperty("allocation_line_reason").StringValue;

	public ModelObject Allocation_line_allocation => GetProperty("allocation_line_allocation").ModelObjectValue;

	public string Allocation_line_type_name => GetProperty("allocation_line_type_name").StringValue;

	public ModelObject[] Allocation_line_data_ice_tags => GetProperty("allocation_line_data_ice_tags").ModelObjectArrayValue;

	public bool Allocation_line_is_removed_by_ic => GetProperty("allocation_line_is_removed_by_ic").BoolValue;

	public bool Allocation_line_is_added_by_ic => GetProperty("allocation_line_is_added_by_ic").BoolValue;

	public string[] Allocation_line_data_props_list => GetProperty("allocation_line_data_props_list").StringArrayValue;

	public string Allocation_line_ic_release_status => GetProperty("allocation_line_ic_release_status").StringValue;

	public string Allocation_line_ic_effectivity => GetProperty("allocation_line_ic_effectivity").StringValue;

	public string Allocation_line_name => GetProperty("allocation_line_name").StringValue;

	public ModelObject[] Allocation_line_source_occs => GetProperty("allocation_line_source_occs").ModelObjectArrayValue;

	public ModelObject[] Allocation_line_sources => GetProperty("allocation_line_sources").ModelObjectArrayValue;

	public ModelObject Allocation_line_window => GetProperty("allocation_line_window").ModelObjectValue;

	public string Allocation_line_conf_ic_name_list => GetProperty("allocation_line_conf_ic_name_list").StringValue;

	public bool Allocation_line_is_conf_by_ic => GetProperty("allocation_line_is_conf_by_ic").BoolValue;

	public ModelObject[] Allocation_line_ice_tags => GetProperty("allocation_line_ice_tags").ModelObjectArrayValue;

	public string Allocation_line_ic_intent => GetProperty("allocation_line_ic_intent").StringValue;

	public string Allocation_line_ic_name_list => GetProperty("allocation_line_ic_name_list").StringValue;

	public bool Allocation_line_is_changed_by_ic => GetProperty("allocation_line_is_changed_by_ic").BoolValue;

	public ModelObject[] Allocation_line_target_occs => GetProperty("allocation_line_target_occs").ModelObjectArrayValue;

	public ModelObject[] Allocation_line_targets => GetProperty("allocation_line_targets").ModelObjectArrayValue;

	public ModelObject Allocation_line_type => GetProperty("allocation_line_type").ModelObjectValue;

	public string[] Allocation_line_data_values_list => GetProperty("allocation_line_data_values_list").StringArrayValue;

	public int Allocation_line_affecting_ice_types => GetProperty("allocation_line_affecting_ice_types").IntValue;

	public ModelObject Allocation_line_condition => GetProperty("allocation_line_condition").ModelObjectValue;

	public AllocationLine(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
