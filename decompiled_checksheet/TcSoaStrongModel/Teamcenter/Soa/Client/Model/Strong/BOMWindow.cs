namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMWindow : RuntimeBusinessObject
{
	public int Ove_message_error_level => GetProperty("ove_message_error_level").IntValue;

	public ModelObject Appearance_root => GetProperty("appearance_root").ModelObjectValue;

	public bool Show_suppressed_occurrences => GetProperty("show_suppressed_occurrences").BoolValue;

	public bool Reposition_all_arrangements => GetProperty("reposition_all_arrangements").BoolValue;

	public bool Show_out_of_context_lines => GetProperty("show_out_of_context_lines").BoolValue;

	public bool Has_visible_line => GetProperty("has_visible_line").BoolValue;

	public bool Absocc_edit_for_itemrev => GetProperty("absocc_edit_for_itemrev").BoolValue;

	public bool Has_occupancy_cache => GetProperty("has_occupancy_cache").BoolValue;

	public bool Ove_ignore_errors => GetProperty("ove_ignore_errors").BoolValue;

	public ModelObject Incr_change_rev => GetProperty("incr_change_rev").ModelObjectValue;

	public bool Icm_flag => GetProperty("icm_flag").BoolValue;

	public bool Show_unconfigured_variants => GetProperty("show_unconfigured_variants").BoolValue;

	public ModelObject Engineering_change => GetProperty("engineering_change").ModelObjectValue;

	public ModelObject Revision_rule => GetProperty("revision_rule").ModelObjectValue;

	public bool Is_tracking_appearances => GetProperty("is_tracking_appearances").BoolValue;

	public ModelObject Active_arrangement => GetProperty("active_arrangement").ModelObjectValue;

	public bool Absocc_specific_edit_mode => GetProperty("absocc_specific_edit_mode").BoolValue;

	public bool Ec_flag => GetProperty("ec_flag").BoolValue;

	public bool Show_unconfigured_changes => GetProperty("show_unconfigured_changes").BoolValue;

	public bool Ignore_arrangements => GetProperty("ignore_arrangements").BoolValue;

	public ModelObject Top_line => GetProperty("top_line").ModelObjectValue;

	public ModelObject Absocc_ctxtline => GetProperty("absocc_ctxtline").ModelObjectValue;

	public bool Is_packed_by_default => GetProperty("is_packed_by_default").BoolValue;

	public bool In_pending_edit_mode => GetProperty("in_pending_edit_mode").BoolValue;

	public bool Fnd0bw_in_markup_mode => GetProperty("fnd0bw_in_markup_mode").BoolValue;

	public bool Fnd0bw_in_cv_cfg_to_load_md => GetProperty("fnd0bw_in_cv_cfg_to_load_md").BoolValue;

	public bool Fnd0show_gcs_cps => GetProperty("fnd0show_gcs_cps").BoolValue;

	public bool Fnd0show_uncnf_occ_eff => GetProperty("fnd0show_uncnf_occ_eff").BoolValue;

	public bool Fnd0IsOccTypeFilterApplied => GetProperty("fnd0IsOccTypeFilterApplied").BoolValue;

	public int Fnd0bwVariantRuleMode => GetProperty("fnd0bwVariantRuleMode").IntValue;

	public ModelObject Fnd0appliedClosureRule => GetProperty("fnd0appliedClosureRule").ModelObjectValue;

	public bool Fnd0bw_is_mono_mode => GetProperty("fnd0bw_is_mono_mode").BoolValue;

	public BOMWindow(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
