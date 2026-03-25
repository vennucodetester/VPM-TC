namespace Teamcenter.Soa.Client.Model.Strong;

public class CfgAttachmentLine : MECfgLine
{
	public int Child_has_ice_types => GetProperty("child_has_ice_types").IntValue;

	public bool Child_removed_by_current_ic => GetProperty("child_removed_by_current_ic").BoolValue;

	public bool Child_added_by_current_ic => GetProperty("child_added_by_current_ic").BoolValue;

	public bool Reln_added_by_current_ic => GetProperty("reln_added_by_current_ic").BoolValue;

	public ModelObject Al_object => GetProperty("al_object").ModelObjectValue;

	public ModelObject Al_structure_line => GetProperty("al_structure_line").ModelObjectValue;

	public ModelObject[] Al_ices_of_reln => GetProperty("al_ices_of_reln").ModelObjectArrayValue;

	public string Al_reln_ic_list => GetProperty("al_reln_ic_list").StringValue;

	public ModelObject[] Al_ices_of_child_edits => GetProperty("al_ices_of_child_edits").ModelObjectArrayValue;

	public ModelObject[] Al_ices_of_child => GetProperty("al_ices_of_child").ModelObjectArrayValue;

	public string Al_child_ic_list => GetProperty("al_child_ic_list").StringValue;

	public string Al_source_type => GetProperty("al_source_type").StringValue;

	public string Al_source_class => GetProperty("al_source_class").StringValue;

	public string Al_child_edits_ic_list => GetProperty("al_child_edits_ic_list").StringValue;

	public string Al_context => GetProperty("al_context").StringValue;

	public ModelObject Al_absocc_rootline => GetProperty("al_absocc_rootline").ModelObjectValue;

	public int Reln_has_ice_types => GetProperty("reln_has_ice_types").IntValue;

	public bool Reln_removed_by_current_ic => GetProperty("reln_removed_by_current_ic").BoolValue;

	public string Al_absocc_rootline_string => GetProperty("al_absocc_rootline_string").StringValue;

	public CfgAttachmentLine(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
