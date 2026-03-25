namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMLine : RuntimeBusinessObject
{
	public string Bl_connected_lines => GetProperty("bl_connected_lines").StringValue;

	public ModelObject Bl_revision => GetProperty("bl_revision").ModelObjectValue;

	public string Bl_ic_intent_list => GetProperty("bl_ic_intent_list").StringValue;

	public string Bl_formatted_ancestor_name => GetProperty("bl_formatted_ancestor_name").StringValue;

	public int Bl_quick_num_children => GetProperty("bl_quick_num_children").IntValue;

	public bool Bl_is_variant => GetProperty("bl_is_variant").BoolValue;

	public string Bl_fg_colour_int_as_str => GetProperty("bl_fg_colour_int_as_str").StringValue;

	public bool Bl_has_legacy_occ_effectivity => GetProperty("bl_has_legacy_occ_effectivity").BoolValue;

	public bool Bl_is_packed => GetProperty("bl_is_packed").BoolValue;

	public ModelObject Bl_item => GetProperty("bl_item").ModelObjectValue;

	public bool Bl_ic_state => GetProperty("bl_ic_state").BoolValue;

	public ModelObject[] Bl_ices_of_occ => GetProperty("bl_ices_of_occ").ModelObjectArrayValue;

	public bool Bl_has_children => GetProperty("bl_has_children").BoolValue;

	public string Bl_config_string => GetProperty("bl_config_string").StringValue;

	public bool Bl_jt_override_children => GetProperty("bl_jt_override_children").BoolValue;

	public string Bl_ic_list => GetProperty("bl_ic_list").StringValue;

	public string Bl_network_viewer_route => GetProperty("bl_network_viewer_route").StringValue;

	public ModelObject Bl_remote_obj_pub_rec => GetProperty("bl_remote_obj_pub_rec").ModelObjectValue;

	public ModelObject[] Bl_implementedBy_lines_tags => GetProperty("bl_implementedBy_lines_tags").ModelObjectArrayValue;

	public int Bl_num_ports => GetProperty("bl_num_ports").IntValue;

	public ModelObject Bl_real_occurrence => GetProperty("bl_real_occurrence").ModelObjectValue;

	public string Bl_preferred_abs_occ_id => GetProperty("bl_preferred_abs_occ_id").StringValue;

	public string Bl_gde_abs_name => GetProperty("bl_gde_abs_name").StringValue;

	public string Bl_formatted_title => GetProperty("bl_formatted_title").StringValue;

	public ModelObject[] Bl_all_nves => GetProperty("bl_all_nves").ModelObjectArrayValue;

	public ModelObject[] Bl_all_authorised_nves => GetProperty("bl_all_authorised_nves").ModelObjectArrayValue;

	public string Bl_formula => GetProperty("bl_formula").StringValue;

	public ModelObject[] Bl_all_mandatory_splitting_nves => GetProperty("bl_all_mandatory_splitting_nves").ModelObjectArrayValue;

	public ModelObject Bl_nve_meta_expression => GetProperty("bl_nve_meta_expression").ModelObjectValue;

	public ModelObject Bl_remote_object => GetProperty("bl_remote_object").ModelObjectValue;

	public ModelObject[] Bl_all_splitting_nves => GetProperty("bl_all_splitting_nves").ModelObjectArrayValue;

	public bool Bl_changed_by_current_ic => GetProperty("bl_changed_by_current_ic").BoolValue;

	public string Bl_used_arrangement_name => GetProperty("bl_used_arrangement_name").StringValue;

	public string Bl_signal_process_variable => GetProperty("bl_signal_process_variable").StringValue;

	public bool Bl_is_occ_suppressed => GetProperty("bl_is_occ_suppressed").BoolValue;

	public bool Bl_is_dummy_parent => GetProperty("bl_is_dummy_parent").BoolValue;

	public string Bl_line_name => GetProperty("bl_line_name").StringValue;

	public string Bl_realizedBy_lines => GetProperty("bl_realizedBy_lines").StringValue;

	public string Bl_appearance_uid => GetProperty("bl_appearance_uid").StringValue;

	public string Bl_apn_uid_in_topline_context => GetProperty("bl_apn_uid_in_topline_context").StringValue;

	public string Bl_sequence_no => GetProperty("bl_sequence_no").StringValue;

	public bool Bl_is_precise => GetProperty("bl_is_precise").BoolValue;

	public bool Bl_has_substitutes => GetProperty("bl_has_substitutes").BoolValue;

	public string Bl_appearance_validity_in => GetProperty("bl_appearance_validity_in").StringValue;

	public ModelObject[] Bl_signal_associated_system_tags => GetProperty("bl_signal_associated_system_tags").ModelObjectArrayValue;

	public ModelObject Bl_parent => GetProperty("bl_parent").ModelObjectValue;

	public string Bl_formatted_view_type => GetProperty("bl_formatted_view_type").StringValue;

	public bool Bl_has_unified_occ_effectivity => GetProperty("bl_has_unified_occ_effectivity").BoolValue;

	public ModelObject[] Bl_packed_lines => GetProperty("bl_packed_lines").ModelObjectArrayValue;

	public string Bl_variant_state => GetProperty("bl_variant_state").StringValue;

	public bool Bl_is_classified => GetProperty("bl_is_classified").BoolValue;

	public string Bl_quantity_change => GetProperty("bl_quantity_change").StringValue;

	public ModelObject Bl_bomview => GetProperty("bl_bomview").ModelObjectValue;

	public string Bl_has_date_effectivity => GetProperty("bl_has_date_effectivity").StringValue;

	public ModelObject[] Bl_gatewayOf_lines_tags => GetProperty("bl_gatewayOf_lines_tags").ModelObjectArrayValue;

	public ModelObject[] Bl_child_lines => GetProperty("bl_child_lines").ModelObjectArrayValue;

	public bool Bl_children_expanded => GetProperty("bl_children_expanded").BoolValue;

	public string Bl_implementedBy_lines => GetProperty("bl_implementedBy_lines").StringValue;

	public string Bl_occurrence_name => GetProperty("bl_occurrence_name").StringValue;

	public ModelObject[] Bl_embeds_lines_tags => GetProperty("bl_embeds_lines_tags").ModelObjectArrayValue;

	public string Bl_indented_title => GetProperty("bl_indented_title").StringValue;

	public string Bl_properties_in_context => GetProperty("bl_properties_in_context").StringValue;

	public string Bl_position_designator => GetProperty("bl_position_designator").StringValue;

	public string Bl_aligned_part_occs => GetProperty("bl_aligned_part_occs").StringValue;

	public string Bl_aligned_act_occs => GetProperty("bl_aligned_act_occs").StringValue;

	public string Bl_is_published => GetProperty("bl_is_published").StringValue;

	public string Bl_is_prev_rev_published => GetProperty("bl_is_prev_rev_published").StringValue;

	public ModelObject[] Bl_all_child_lines => GetProperty("bl_all_child_lines").ModelObjectArrayValue;

	public int Bl_num_children => GetProperty("bl_num_children").IntValue;

	public bool Bl_is_suppressed => GetProperty("bl_is_suppressed").BoolValue;

	public bool Bl_has_trace_link => GetProperty("bl_has_trace_link").BoolValue;

	public ModelObject[] Bl_realizedBy_lines_tags => GetProperty("bl_realizedBy_lines_tags").ModelObjectArrayValue;

	public ModelObject[] Bl_occ_effectivity => GetProperty("bl_occ_effectivity").ModelObjectArrayValue;

	public bool Bl_occ_is_precise => GetProperty("bl_occ_is_precise").BoolValue;

	public ModelObject[] Bl_connected_apns => GetProperty("bl_connected_apns").ModelObjectArrayValue;

	public bool Bl_is_link_out_of_sync => GetProperty("bl_is_link_out_of_sync").BoolValue;

	public ModelObject Bl_rev_rule_modifier => GetProperty("bl_rev_rule_modifier").ModelObjectValue;

	public bool Bl_is_occ_suppression_constrained => GetProperty("bl_is_occ_suppression_constrained").BoolValue;

	public ModelObject Bl_rev_rule_parent_modifier => GetProperty("bl_rev_rule_parent_modifier").ModelObjectValue;

	public ModelObject Bl_occurrence => GetProperty("bl_occurrence").ModelObjectValue;

	public string Bl_occurrence_uid => GetProperty("bl_occurrence_uid").StringValue;

	public ModelObject[] Bl_predecessor_lines => GetProperty("bl_predecessor_lines").ModelObjectArrayValue;

	public bool Bl_is_orphan => GetProperty("bl_is_orphan").BoolValue;

	public int Bl_affecting_ice_types => GetProperty("bl_affecting_ice_types").IntValue;

	public ModelObject[] Bl_property_context_tags => GetProperty("bl_property_context_tags").ModelObjectArrayValue;

	public bool Bl_is_vi => GetProperty("bl_is_vi").BoolValue;

	public string Bl_ic_release_status_list => GetProperty("bl_ic_release_status_list").StringValue;

	public string Bl_signal_redundant => GetProperty("bl_signal_redundant").StringValue;

	public string Bl_appearance_validity_out => GetProperty("bl_appearance_validity_out").StringValue;

	public string Bl_plmxml_occ_xform => GetProperty("bl_plmxml_occ_xform").StringValue;

	public ModelObject Bl_visible_parent => GetProperty("bl_visible_parent").ModelObjectValue;

	public string Bl_ic_effectivity => GetProperty("bl_ic_effectivity").StringValue;

	public string Bl_variant_condition => GetProperty("bl_variant_condition").StringValue;

	public ModelObject Bl_used_arrangement => GetProperty("bl_used_arrangement").ModelObjectValue;

	public ModelObject[] Bl_routedBy_lines_tags => GetProperty("bl_routedBy_lines_tags").ModelObjectArrayValue;

	public string Bl_embeds_lines => GetProperty("bl_embeds_lines").StringValue;

	public string Bl_config_ic_list => GetProperty("bl_config_ic_list").StringValue;

	public string Bl_absocc_uid_in_topline_context => GetProperty("bl_absocc_uid_in_topline_context").StringValue;

	public double Bl_signal_value => GetProperty("bl_signal_value").DoubleValue;

	public ModelObject[] Bl_dataset_attachments => GetProperty("bl_dataset_attachments").ModelObjectArrayValue;

	public string Bl_quantity => GetProperty("bl_quantity").StringValue;

	public string Bl_part_source => GetProperty("bl_part_source").StringValue;

	public ModelObject Bl_uom => GetProperty("bl_uom").ModelObjectValue;

	public string Bl_ref_designator => GetProperty("bl_ref_designator").StringValue;

	public ModelObject[] Bl_child_item => GetProperty("bl_child_item").ModelObjectArrayValue;

	public string Bl_compare_change => GetProperty("bl_compare_change").StringValue;

	public string Bl_gc_id => GetProperty("bl_gc_id").StringValue;

	public string Bl_bomview_uid => GetProperty("bl_bomview_uid").StringValue;

	public ModelObject Bl_weld_feature_form => GetProperty("bl_weld_feature_form").ModelObjectValue;

	public bool Bl_is_all_history_line => GetProperty("bl_is_all_history_line").BoolValue;

	public string Bl_occ_date_range => GetProperty("bl_occ_date_range").StringValue;

	public bool Bl_is_pending_cut => GetProperty("bl_is_pending_cut").BoolValue;

	public string Bl_all_notes => GetProperty("bl_all_notes").StringValue;

	public string Bl_abs_occ_id => GetProperty("bl_abs_occ_id").StringValue;

	public ModelObject Bl_line_object => GetProperty("bl_line_object").ModelObjectValue;

	public ModelObject Bl_appearance => GetProperty("bl_appearance").ModelObjectValue;

	public string Bl_revision_effectivity => GetProperty("bl_revision_effectivity").StringValue;

	public string Bl_line_object_class => GetProperty("bl_line_object_class").StringValue;

	public int Bl_pack_count => GetProperty("bl_pack_count").IntValue;

	public ModelObject Bl_jt_dataset_tag => GetProperty("bl_jt_dataset_tag").ModelObjectValue;

	public string Bl_plmxml_abs_xform => GetProperty("bl_plmxml_abs_xform").StringValue;

	public ModelObject Bl_gde_bomview_rev => GetProperty("bl_gde_bomview_rev").ModelObjectValue;

	public ModelObject Bl_window => GetProperty("bl_window").ModelObjectValue;

	public ModelObject Bl_condition_tag => GetProperty("bl_condition_tag").ModelObjectValue;

	public int Bl_variant_state_int => GetProperty("bl_variant_state_int").IntValue;

	public string Bl_formatted_parent_name => GetProperty("bl_formatted_parent_name").StringValue;

	public int Bl_forced_configuration => GetProperty("bl_forced_configuration").IntValue;

	public string Bl_part_numbers => GetProperty("bl_part_numbers").StringValue;

	public string Bl_view_type => GetProperty("bl_view_type").StringValue;

	public ModelObject[] Bl_connected_lines_tags => GetProperty("bl_connected_lines_tags").ModelObjectArrayValue;

	public string Bl_dependentOn_lines => GetProperty("bl_dependentOn_lines").StringValue;

	public string Bl_abs_xform_matrix => GetProperty("bl_abs_xform_matrix").StringValue;

	public bool Bl_has_module => GetProperty("bl_has_module").BoolValue;

	public bool Bl_has_global_alternates => GetProperty("bl_has_global_alternates").BoolValue;

	public string Bl_occ_xform_matrix => GetProperty("bl_occ_xform_matrix").StringValue;

	public ModelObject[] Bl_dependentOn_lines_tags => GetProperty("bl_dependentOn_lines_tags").ModelObjectArrayValue;

	public string Bl_substitute => GetProperty("bl_substitute").StringValue;

	public string Bl_signal_associated_system => GetProperty("bl_signal_associated_system").StringValue;

	public bool Bl_is_shown_in_tree => GetProperty("bl_is_shown_in_tree").BoolValue;

	public int Bl_compare_change_int => GetProperty("bl_compare_change_int").IntValue;

	public bool Bl_removed_by_current_ic => GetProperty("bl_removed_by_current_ic").BoolValue;

	public ModelObject Bl_bomview_rev => GetProperty("bl_bomview_rev").ModelObjectValue;

	public bool Bl_has_remove_ices => GetProperty("bl_has_remove_ices").BoolValue;

	public string Bl_revision_change => GetProperty("bl_revision_change").StringValue;

	public int Bl_level_starting_0 => GetProperty("bl_level_starting_0").IntValue;

	public int Bl_load_state => GetProperty("bl_load_state").IntValue;

	public int Bl_level_starting_1 => GetProperty("bl_level_starting_1").IntValue;

	public bool Bl_has_occ_effectivity => GetProperty("bl_has_occ_effectivity").BoolValue;

	public bool Bl_is_shown_in_viewer => GetProperty("bl_is_shown_in_viewer").BoolValue;

	public ModelObject[] Bl_attachments => GetProperty("bl_attachments").ModelObjectArrayValue;

	public bool Bl_has_add_ices => GetProperty("bl_has_add_ices").BoolValue;

	public int[] Bl_property_ic_context_types => GetProperty("bl_property_ic_context_types").IntArrayValue;

	public ModelObject Bl_signal_process_variable_tag => GetProperty("bl_signal_process_variable_tag").ModelObjectValue;

	public bool Bl_is_last_child => GetProperty("bl_is_last_child").BoolValue;

	public string Bl_connected_to_absName => GetProperty("bl_connected_to_absName").StringValue;

	public string Bl_usage_address => GetProperty("bl_usage_address").StringValue;

	public string Bl_jt_refsetname => GetProperty("bl_jt_refsetname").StringValue;

	public ModelObject Bl_absocc_generator => GetProperty("bl_absocc_generator").ModelObjectValue;

	public bool Bl_has_occupancy_data => GetProperty("bl_has_occupancy_data").BoolValue;

	public bool Bl_is_occ_configured => GetProperty("bl_is_occ_configured").BoolValue;

	public ModelObject[] Bl_device_to_connector_lines_tags => GetProperty("bl_device_to_connector_lines_tags").ModelObjectArrayValue;

	public double Bl_process_variable_value => GetProperty("bl_process_variable_value").DoubleValue;

	public double Bl_real_quantity => GetProperty("bl_real_quantity").DoubleValue;

	public bool Bl_added_by_current_ic => GetProperty("bl_added_by_current_ic").BoolValue;

	public string Bl_pos_ref => GetProperty("bl_pos_ref").StringValue;

	public string Bl_gatewayOf_lines => GetProperty("bl_gatewayOf_lines").StringValue;

	public ModelObject Bl_appearance_path_node => GetProperty("bl_appearance_path_node").ModelObjectValue;

	public bool Bl_is_item_configured => GetProperty("bl_is_item_configured").BoolValue;

	public string Bl_formatted_quantity => GetProperty("bl_formatted_quantity").StringValue;

	public string Bl_bg_colour_int_as_str => GetProperty("bl_bg_colour_int_as_str").StringValue;

	public string Bl_routedBy_lines => GetProperty("bl_routedBy_lines").StringValue;

	public ModelObject Bl_pack_master => GetProperty("bl_pack_master").ModelObjectValue;

	public string Bl_abs_occ_all_ids => GetProperty("bl_abs_occ_all_ids").StringValue;

	public bool Bl_is_occ_position_constrained => GetProperty("bl_is_occ_position_constrained").BoolValue;

	public string[] Bl_note_types => GetProperty("bl_note_types").StringArrayValue;

	public ModelObject[] Bl_signal_redundant_tags => GetProperty("bl_signal_redundant_tags").ModelObjectArrayValue;

	public string Bl_fulltext_body_cleartext => GetProperty("bl_fulltext_body_cleartext").StringValue;

	public string Bl_occ_type => GetProperty("bl_occ_type").StringValue;

	public bool Bl_is_publish_link_source => GetProperty("bl_is_publish_link_source").BoolValue;

	public bool Bl_is_publish_link_target => GetProperty("bl_is_publish_link_target").BoolValue;

	public string Bl_data_published_from_source => GetProperty("bl_data_published_from_source").StringValue;

	public bool Bl_is_designed_in_place => GetProperty("bl_is_designed_in_place").BoolValue;

	public string Bl_allFlags => GetProperty("bl_allFlags").StringValue;

	public int Bl_pending_edit_status => GetProperty("bl_pending_edit_status").IntValue;

	public string[] Bl_property_overrides => GetProperty("bl_property_overrides").StringArrayValue;

	public bool Bl_req_pos_design => GetProperty("bl_req_pos_design").BoolValue;

	public string Bl_clone_stable_occurrence_id => GetProperty("bl_clone_stable_occurrence_id").StringValue;

	public ModelObject[] Bl_substitute_list => GetProperty("bl_substitute_list").ModelObjectArrayValue;

	public int Bl_proxy_shape_data_flag => GetProperty("bl_proxy_shape_data_flag").IntValue;

	public ModelObject[] Bl_ices_of_pred_reln => GetProperty("bl_ices_of_pred_reln").ModelObjectArrayValue;

	public double[] Bl_plmxml_def_abs_xform => GetProperty("bl_plmxml_def_abs_xform").DoubleArrayValue;

	public double[] Bl_plmxml_def_occ_xform => GetProperty("bl_plmxml_def_occ_xform").DoubleArrayValue;

	public string Bl_occ_assigned => GetProperty("bl_occ_assigned").StringValue;

	public double[] Bl_bounding_boxes => GetProperty("bl_bounding_boxes").DoubleArrayValue;

	public string Bl_rev_VMRepresents => GetProperty("bl_rev_VMRepresents").StringValue;

	public string[] Bl_rev_vendor_parts => GetProperty("bl_rev_vendor_parts").StringArrayValue;

	public string Bl_jt_hint_contents => GetProperty("bl_jt_hint_contents").StringValue;

	public bool Bl_has_attached_notes => GetProperty("bl_has_attached_notes").BoolValue;

	public bool Bl_window_is_BOPWin => GetProperty("bl_window_is_BOPWin").BoolValue;

	public int Bl_occ_int_order_no => GetProperty("bl_occ_int_order_no").IntValue;

	public bool Fnd0bl_has_active_markup => GetProperty("fnd0bl_has_active_markup").BoolValue;

	public ModelObject Fnd0bl_active_markup => GetProperty("fnd0bl_active_markup").ModelObjectValue;

	public ModelObject[] Fnd0bl_active_changes => GetProperty("fnd0bl_active_changes").ModelObjectArrayValue;

	public int Fnd0bl_markup_type => GetProperty("fnd0bl_markup_type").IntValue;

	public string[] Fnd0bl_markup_prop_names => GetProperty("fnd0bl_markup_prop_names").StringArrayValue;

	public string[] Fnd0bl_markup_prop_values => GetProperty("fnd0bl_markup_prop_values").StringArrayValue;

	public ModelObject Fnd0bl_markup_replace_obj => GetProperty("fnd0bl_markup_replace_obj").ModelObjectValue;

	public ModelObject[] Fnd0bl_markup_subs_objs_add => GetProperty("fnd0bl_markup_subs_objs_add").ModelObjectArrayValue;

	public ModelObject[] Fnd0bl_markup_subs_objs_del => GetProperty("fnd0bl_markup_subs_objs_del").ModelObjectArrayValue;

	public ModelObject[] Fnd0bl_markup_add_objs => GetProperty("fnd0bl_markup_add_objs").ModelObjectArrayValue;

	public string Fnd0bl_ac_check_result => GetProperty("fnd0bl_ac_check_result").StringValue;

	public string[] Fnd0bl_assigned_as => GetProperty("fnd0bl_assigned_as").StringArrayValue;

	public string Fnd0bl_real_quantity => GetProperty("fnd0bl_real_quantity").StringValue;

	public int Fnd0bl_is_filtered => GetProperty("fnd0bl_is_filtered").IntValue;

	public int Fnd0bl_has_trace_link => GetProperty("fnd0bl_has_trace_link").IntValue;

	public ModelObject[] Fnd0bl_defining_objects => GetProperty("fnd0bl_defining_objects").ModelObjectArrayValue;

	public ModelObject[] Fnd0bl_complying_objects => GetProperty("fnd0bl_complying_objects").ModelObjectArrayValue;

	public string Fnd0bl_sub_name_compare => GetProperty("fnd0bl_sub_name_compare").StringValue;

	public string Fnd0bl_sub_id_compare => GetProperty("fnd0bl_sub_id_compare").StringValue;

	public bool Fnd0bl_is_substitute => GetProperty("fnd0bl_is_substitute").BoolValue;

	public int Fnd0bl_is_mono_override => GetProperty("fnd0bl_is_mono_override").IntValue;

	public bool Fnd0bl_is_mono_present => GetProperty("fnd0bl_is_mono_present").BoolValue;

	public string Bl_arch_hint_GPA => GetProperty("bl_arch_hint_GPA").StringValue;

	public string Bl_item_item_id => GetProperty("bl_item_item_id").StringValue;

	public string Bl_item_bom_view_tags => GetProperty("bl_item_bom_view_tags").StringValue;

	public string Bl_item_item_master_tag => GetProperty("bl_item_item_master_tag").StringValue;

	public string Bl_item_fnd0OriginalLocationCode => GetProperty("bl_item_fnd0OriginalLocationCode").StringValue;

	public string Bl_item_is_configuration_item => GetProperty("bl_item_is_configuration_item").StringValue;

	public string Bl_item_has_variant_module => GetProperty("bl_item_has_variant_module").StringValue;

	public string Bl_item_is_vi => GetProperty("bl_item_is_vi").StringValue;

	public string Bl_item_global_alt_list => GetProperty("bl_item_global_alt_list").StringValue;

	public string Bl_item_preferred_global_alt => GetProperty("bl_item_preferred_global_alt").StringValue;

	public string Bl_item_fnd0is_monolithic => GetProperty("bl_item_fnd0is_monolithic").StringValue;

	public string Bl_item_configuration_object_tag => GetProperty("bl_item_configuration_object_tag").StringValue;

	public string Bl_item_uom_tag => GetProperty("bl_item_uom_tag").StringValue;

	public string Bl_item_acl_bits => GetProperty("bl_item_acl_bits").StringValue;

	public string Bl_item_creation_date => GetProperty("bl_item_creation_date").StringValue;

	public string Bl_item_archive_date => GetProperty("bl_item_archive_date").StringValue;

	public string Bl_item_last_mod_date => GetProperty("bl_item_last_mod_date").StringValue;

	public string Bl_item_backup_date => GetProperty("bl_item_backup_date").StringValue;

	public string Bl_item_owning_group => GetProperty("bl_item_owning_group").StringValue;

	public string Bl_item_last_mod_user => GetProperty("bl_item_last_mod_user").StringValue;

	public string Bl_item_owning_user => GetProperty("bl_item_owning_user").StringValue;

	public string Bl_item_timestamp => GetProperty("bl_item_timestamp").StringValue;

	public string Bl_item_pid => GetProperty("bl_item_pid").StringValue;

	public string Bl_item_object_properties => GetProperty("bl_item_object_properties").StringValue;

	public string Bl_item_lsd => GetProperty("bl_item_lsd").StringValue;

	public string Bl_item_owning_site => GetProperty("bl_item_owning_site").StringValue;

	public string Bl_item_object_name => GetProperty("bl_item_object_name").StringValue;

	public string Bl_item_object_desc => GetProperty("bl_item_object_desc").StringValue;

	public string Bl_item_object_type => GetProperty("bl_item_object_type").StringValue;

	public string Bl_item_object_application => GetProperty("bl_item_object_application").StringValue;

	public string Bl_item_revision_number => GetProperty("bl_item_revision_number").StringValue;

	public string Bl_item_revision_limit => GetProperty("bl_item_revision_limit").StringValue;

	public string Bl_item_process_stage_list => GetProperty("bl_item_process_stage_list").StringValue;

	public string Bl_item_date_released => GetProperty("bl_item_date_released").StringValue;

	public string Bl_item_ip_classification => GetProperty("bl_item_ip_classification").StringValue;

	public string Bl_item_license_list => GetProperty("bl_item_license_list").StringValue;

	public string Bl_item_gov_classification => GetProperty("bl_item_gov_classification").StringValue;

	public string Bl_item_ead_paragraph => GetProperty("bl_item_ead_paragraph").StringValue;

	public string Bl_item_active_seq => GetProperty("bl_item_active_seq").StringValue;

	public string Bl_item_fnd0RevisionId => GetProperty("bl_item_fnd0RevisionId").StringValue;

	public string Bl_item_release_status_list => GetProperty("bl_item_release_status_list").StringValue;

	public string Bl_item_wso_thread => GetProperty("bl_item_wso_thread").StringValue;

	public string Bl_item_owning_organization => GetProperty("bl_item_owning_organization").StringValue;

	public string Bl_item_project_list => GetProperty("bl_item_project_list").StringValue;

	public string Bl_item_owning_project => GetProperty("bl_item_owning_project").StringValue;

	public string Bl_item_object_string => GetProperty("bl_item_object_string").StringValue;

	public string Bl_item_fnd0objectId => GetProperty("bl_item_fnd0objectId").StringValue;

	public string Bl_item_fnd0mfkinfo => GetProperty("bl_item_fnd0mfkinfo").StringValue;

	public string Bl_item_fnd0ContextContrast => GetProperty("bl_item_fnd0ContextContrast").StringValue;

	public string Bl_item_fnd0HasEditInContext => GetProperty("bl_item_fnd0HasEditInContext").StringValue;

	public string Bl_item_fnd0IsConfiguredInContext => GetProperty("bl_item_fnd0IsConfiguredInContext").StringValue;

	public string Bl_item_fnd0DSState => GetProperty("bl_item_fnd0DSState").StringValue;

	public string Bl_item_fnd0DigitalSignAuditLogs => GetProperty("bl_item_fnd0DigitalSignAuditLogs").StringValue;

	public string Bl_item_release_statuses => GetProperty("bl_item_release_statuses").StringValue;

	public string Bl_item_reservation => GetProperty("bl_item_reservation").StringValue;

	public string Bl_item_publication_sites => GetProperty("bl_item_publication_sites").StringValue;

	public string Bl_item_export_sites => GetProperty("bl_item_export_sites").StringValue;

	public string Bl_item_project_ids => GetProperty("bl_item_project_ids").StringValue;

	public string Bl_item_last_release_status => GetProperty("bl_item_last_release_status").StringValue;

	public string Bl_item_current_job => GetProperty("bl_item_current_job").StringValue;

	public string Bl_item_current_desc => GetProperty("bl_item_current_desc").StringValue;

	public string Bl_item_checked_out_change_id => GetProperty("bl_item_checked_out_change_id").StringValue;

	public string Bl_item_has_trace_link => GetProperty("bl_item_has_trace_link").StringValue;

	public string Bl_item_process_stage => GetProperty("bl_item_process_stage").StringValue;

	public string Bl_item_external_apps => GetProperty("bl_item_external_apps").StringValue;

	public string Bl_item_projects_list => GetProperty("bl_item_projects_list").StringValue;

	public string Bl_item_ics_subclass_name => GetProperty("bl_item_ics_subclass_name").StringValue;

	public string Bl_item_ics_classified => GetProperty("bl_item_ics_classified").StringValue;

	public string Bl_item_based_on => GetProperty("bl_item_based_on").StringValue;

	public string Bl_item_item_revision => GetProperty("bl_item_item_revision").StringValue;

	public string Bl_item_change => GetProperty("bl_item_change").StringValue;

	public string Bl_item_checked_out_user => GetProperty("bl_item_checked_out_user").StringValue;

	public string Bl_item_is_modifiable => GetProperty("bl_item_is_modifiable").StringValue;

	public string Bl_item_protection => GetProperty("bl_item_protection").StringValue;

	public string Bl_item_current_name => GetProperty("bl_item_current_name").StringValue;

	public string Bl_item_proj_assign_mod_date => GetProperty("bl_item_proj_assign_mod_date").StringValue;

	public string Bl_item_expl_checkout => GetProperty("bl_item_expl_checkout").StringValue;

	public string Bl_item_checked_out => GetProperty("bl_item_checked_out").StringValue;

	public string Bl_item_checked_out_date => GetProperty("bl_item_checked_out_date").StringValue;

	public string Bl_item_ip_logged => GetProperty("bl_item_ip_logged").StringValue;

	public string Bl_item_user_can_unmanage => GetProperty("bl_item_user_can_unmanage").StringValue;

	public string Bl_item_null_logical => GetProperty("bl_item_null_logical").StringValue;

	public string Bl_item_null_string => GetProperty("bl_item_null_string").StringValue;

	public string Bl_item_fnd0defining_objects => GetProperty("bl_item_fnd0defining_objects").StringValue;

	public string Bl_item_fnd0complying_objects => GetProperty("bl_item_fnd0complying_objects").StringValue;

	public string Bl_item_fnd0IsCheckoutable => GetProperty("bl_item_fnd0IsCheckoutable").StringValue;

	public string Bl_item_fnd0WorkflowAuditLogs => GetProperty("bl_item_fnd0WorkflowAuditLogs").StringValue;

	public string Bl_item_fnd0GeneralAuditLogs => GetProperty("bl_item_fnd0GeneralAuditLogs").StringValue;

	public string Bl_item_fnd0LicenseExportAuditLogs => GetProperty("bl_item_fnd0LicenseExportAuditLogs").StringValue;

	public string Bl_item_fnd0ActuatedInteractiveTsks => GetProperty("bl_item_fnd0ActuatedInteractiveTsks").StringValue;

	public string Bl_item_IMAN_based_on => GetProperty("bl_item_IMAN_based_on").StringValue;

	public string Bl_item_Fnd0DigitalSignatureRel => GetProperty("bl_item_Fnd0DigitalSignatureRel").StringValue;

	public string Bl_item_Fnd0DigitalSignObsoleteRel => GetProperty("bl_item_Fnd0DigitalSignObsoleteRel").StringValue;

	public string Bl_item_FND_TraceLink => GetProperty("bl_item_FND_TraceLink").StringValue;

	public string Bl_item_Fnd0ShapeRelation => GetProperty("bl_item_Fnd0ShapeRelation").StringValue;

	public string Bl_item_Fnd0DiagramTmplRelation => GetProperty("bl_item_Fnd0DiagramTmplRelation").StringValue;

	public string Bl_item_Fnd0Diagram_Attaches => GetProperty("bl_item_Fnd0Diagram_Attaches").StringValue;

	public string Bl_item_Fnd0DiagramSnapshot => GetProperty("bl_item_Fnd0DiagramSnapshot").StringValue;

	public string Bl_item_more_revisions => GetProperty("bl_item_more_revisions").StringValue;

	public string Bl_item_revision_list => GetProperty("bl_item_revision_list").StringValue;

	public string Bl_item_IMAN_master_form => GetProperty("bl_item_IMAN_master_form").StringValue;

	public string Bl_item_EC_addressed_by_rel => GetProperty("bl_item_EC_addressed_by_rel").StringValue;

	public string Bl_item_EC_solution_item_rel => GetProperty("bl_item_EC_solution_item_rel").StringValue;

	public string Bl_item_id_dispdefault => GetProperty("bl_item_id_dispdefault").StringValue;

	public string Bl_item_generic_component_object_string => GetProperty("bl_item_generic_component_object_string").StringValue;

	public string Bl_item_TC_Generic_Architecture => GetProperty("bl_item_TC_Generic_Architecture").StringValue;

	public string Bl_item_IMAN_MEView => GetProperty("bl_item_IMAN_MEView").StringValue;

	public string Bl_item_IMAN_external_object_link => GetProperty("bl_item_IMAN_external_object_link").StringValue;

	public string Bl_item_altid_list => GetProperty("bl_item_altid_list").StringValue;

	public string Bl_item_has_module => GetProperty("bl_item_has_module").StringValue;

	public string Bl_item_has_global_alternates => GetProperty("bl_item_has_global_alternates").StringValue;

	public string Bl_item_EC_reference_item_rel => GetProperty("bl_item_EC_reference_item_rel").StringValue;

	public string Bl_item_EC_problem_item_rel => GetProperty("bl_item_EC_problem_item_rel").StringValue;

	public string Bl_item_has_variants => GetProperty("bl_item_has_variants").StringValue;

	public string Bl_item_TC_CAE_Defining => GetProperty("bl_item_TC_CAE_Defining").StringValue;

	public string Bl_item_IMAN_classification => GetProperty("bl_item_IMAN_classification").StringValue;

	public string Bl_item_IMAN_vi_sos => GetProperty("bl_item_IMAN_vi_sos").StringValue;

	public string Bl_item_IMAN_Rendering => GetProperty("bl_item_IMAN_Rendering").StringValue;

	public string Bl_item_IMAN_aliasid => GetProperty("bl_item_IMAN_aliasid").StringValue;

	public string Bl_item_is_linked_to_generic_component => GetProperty("bl_item_is_linked_to_generic_component").StringValue;

	public string Bl_item_TC_CAE_Source => GetProperty("bl_item_TC_CAE_Source").StringValue;

	public string Bl_item_IMAN_manifestation => GetProperty("bl_item_IMAN_manifestation").StringValue;

	public string Bl_item_IMAN_ic_intent => GetProperty("bl_item_IMAN_ic_intent").StringValue;

	public string Bl_item_displayable_revisions => GetProperty("bl_item_displayable_revisions").StringValue;

	public string Bl_item_TC_CAE_Target => GetProperty("bl_item_TC_CAE_Target").StringValue;

	public string Bl_item_TC_WorkContext_Relation => GetProperty("bl_item_TC_WorkContext_Relation").StringValue;

	public string Bl_item_IMAN_reference => GetProperty("bl_item_IMAN_reference").StringValue;

	public string Bl_item_is_variant_item => GetProperty("bl_item_is_variant_item").StringValue;

	public string Bl_item_TC_CAE_Results => GetProperty("bl_item_TC_CAE_Results").StringValue;

	public string Bl_item_EC_snapshot_rel => GetProperty("bl_item_EC_snapshot_rel").StringValue;

	public string Bl_item_EC_affected_item_rel => GetProperty("bl_item_EC_affected_item_rel").StringValue;

	public string Bl_item_current_id => GetProperty("bl_item_current_id").StringValue;

	public string Bl_item_TC_AuditLog => GetProperty("bl_item_TC_AuditLog").StringValue;

	public string Bl_item_IMAN_requirement => GetProperty("bl_item_IMAN_requirement").StringValue;

	public string Bl_item_TC_CAE_Criteria => GetProperty("bl_item_TC_CAE_Criteria").StringValue;

	public string Bl_item_TC_CAE_Include => GetProperty("bl_item_TC_CAE_Include").StringValue;

	public string Bl_item_TC_CAE_Param => GetProperty("bl_item_TC_CAE_Param").StringValue;

	public string Bl_item_TC_sst_record => GetProperty("bl_item_TC_sst_record").StringValue;

	public string Bl_item_ContactInCompany => GetProperty("bl_item_ContactInCompany").StringValue;

	public string Bl_item_LocationInCompany => GetProperty("bl_item_LocationInCompany").StringValue;

	public string Bl_item_VisItemRevCreatedSnapshot2D => GetProperty("bl_item_VisItemRevCreatedSnapshot2D").StringValue;

	public string Bl_item_Fnd0ListsCustomNotes => GetProperty("bl_item_Fnd0ListsCustomNotes").StringValue;

	public string Bl_item_Fnd0ListsParamReqments => GetProperty("bl_item_Fnd0ListsParamReqments").StringValue;

	public string Bl_item_Fnd0StruObjAttrOverride => GetProperty("bl_item_Fnd0StruObjAttrOverride").StringValue;

	public string Bl_item_current_id_context => GetProperty("bl_item_current_id_context").StringValue;

	public string Bl_item_fnd0StructureAuditLogs => GetProperty("bl_item_fnd0StructureAuditLogs").StringValue;

	public string Bl_item_fnd0VariantNamespace => GetProperty("bl_item_fnd0VariantNamespace").StringValue;

	public string Bl_item_fnd0PartIdentifier => GetProperty("bl_item_fnd0PartIdentifier").StringValue;

	public string Bl_rev_acl_bits => GetProperty("bl_rev_acl_bits").StringValue;

	public string Bl_rev_creation_date => GetProperty("bl_rev_creation_date").StringValue;

	public string Bl_rev_archive_date => GetProperty("bl_rev_archive_date").StringValue;

	public string Bl_rev_last_mod_date => GetProperty("bl_rev_last_mod_date").StringValue;

	public string Bl_rev_backup_date => GetProperty("bl_rev_backup_date").StringValue;

	public string Bl_rev_owning_group => GetProperty("bl_rev_owning_group").StringValue;

	public string Bl_rev_last_mod_user => GetProperty("bl_rev_last_mod_user").StringValue;

	public string Bl_rev_owning_user => GetProperty("bl_rev_owning_user").StringValue;

	public string Bl_rev_timestamp => GetProperty("bl_rev_timestamp").StringValue;

	public string Bl_rev_pid => GetProperty("bl_rev_pid").StringValue;

	public string Bl_rev_object_properties => GetProperty("bl_rev_object_properties").StringValue;

	public string Bl_rev_lsd => GetProperty("bl_rev_lsd").StringValue;

	public string Bl_rev_owning_site => GetProperty("bl_rev_owning_site").StringValue;

	public string Bl_rev_object_name => GetProperty("bl_rev_object_name").StringValue;

	public string Bl_rev_object_desc => GetProperty("bl_rev_object_desc").StringValue;

	public string Bl_rev_object_type => GetProperty("bl_rev_object_type").StringValue;

	public string Bl_rev_object_application => GetProperty("bl_rev_object_application").StringValue;

	public string Bl_rev_revision_number => GetProperty("bl_rev_revision_number").StringValue;

	public string Bl_rev_revision_limit => GetProperty("bl_rev_revision_limit").StringValue;

	public string Bl_rev_process_stage_list => GetProperty("bl_rev_process_stage_list").StringValue;

	public string Bl_rev_date_released => GetProperty("bl_rev_date_released").StringValue;

	public string Bl_rev_ip_classification => GetProperty("bl_rev_ip_classification").StringValue;

	public string Bl_rev_license_list => GetProperty("bl_rev_license_list").StringValue;

	public string Bl_rev_gov_classification => GetProperty("bl_rev_gov_classification").StringValue;

	public string Bl_rev_ead_paragraph => GetProperty("bl_rev_ead_paragraph").StringValue;

	public string Bl_rev_active_seq => GetProperty("bl_rev_active_seq").StringValue;

	public string Bl_rev_fnd0RevisionId => GetProperty("bl_rev_fnd0RevisionId").StringValue;

	public string Bl_rev_release_status_list => GetProperty("bl_rev_release_status_list").StringValue;

	public string Bl_rev_wso_thread => GetProperty("bl_rev_wso_thread").StringValue;

	public string Bl_rev_owning_organization => GetProperty("bl_rev_owning_organization").StringValue;

	public string Bl_rev_project_list => GetProperty("bl_rev_project_list").StringValue;

	public string Bl_rev_owning_project => GetProperty("bl_rev_owning_project").StringValue;

	public string Bl_rev_item_revision_id => GetProperty("bl_rev_item_revision_id").StringValue;

	public string Bl_rev_item_master_tag => GetProperty("bl_rev_item_master_tag").StringValue;

	public string Bl_rev_has_variant_module => GetProperty("bl_rev_has_variant_module").StringValue;

	public string Bl_rev_items_tag => GetProperty("bl_rev_items_tag").StringValue;

	public string Bl_rev_sequence_id => GetProperty("bl_rev_sequence_id").StringValue;

	public string Bl_rev_sequence_limit => GetProperty("bl_rev_sequence_limit").StringValue;

	public string Bl_rev_sequence_anchor => GetProperty("bl_rev_sequence_anchor").StringValue;

	public string Bl_rev_fnd0CurrentLocationCode => GetProperty("bl_rev_fnd0CurrentLocationCode").StringValue;

	public string Bl_rev_structure_revisions => GetProperty("bl_rev_structure_revisions").StringValue;

	public string Bl_rev_declared_options => GetProperty("bl_rev_declared_options").StringValue;

	public string Bl_rev_used_options => GetProperty("bl_rev_used_options").StringValue;

	public string Bl_rev_variant_expression_block => GetProperty("bl_rev_variant_expression_block").StringValue;

	public string Bl_rev_gde_bvr_list => GetProperty("bl_rev_gde_bvr_list").StringValue;

	public string Bl_rev_object_string => GetProperty("bl_rev_object_string").StringValue;

	public string Bl_rev_fnd0objectId => GetProperty("bl_rev_fnd0objectId").StringValue;

	public string Bl_rev_fnd0mfkinfo => GetProperty("bl_rev_fnd0mfkinfo").StringValue;

	public string Bl_rev_fnd0ContextContrast => GetProperty("bl_rev_fnd0ContextContrast").StringValue;

	public string Bl_rev_fnd0HasEditInContext => GetProperty("bl_rev_fnd0HasEditInContext").StringValue;

	public string Bl_rev_fnd0IsConfiguredInContext => GetProperty("bl_rev_fnd0IsConfiguredInContext").StringValue;

	public string Bl_rev_fnd0DSState => GetProperty("bl_rev_fnd0DSState").StringValue;

	public string Bl_rev_fnd0DigitalSignAuditLogs => GetProperty("bl_rev_fnd0DigitalSignAuditLogs").StringValue;

	public string Bl_rev_release_statuses => GetProperty("bl_rev_release_statuses").StringValue;

	public string Bl_rev_reservation => GetProperty("bl_rev_reservation").StringValue;

	public string Bl_rev_publication_sites => GetProperty("bl_rev_publication_sites").StringValue;

	public string Bl_rev_export_sites => GetProperty("bl_rev_export_sites").StringValue;

	public string Bl_rev_project_ids => GetProperty("bl_rev_project_ids").StringValue;

	public string Bl_rev_last_release_status => GetProperty("bl_rev_last_release_status").StringValue;

	public string Bl_rev_current_job => GetProperty("bl_rev_current_job").StringValue;

	public string Bl_rev_current_desc => GetProperty("bl_rev_current_desc").StringValue;

	public string Bl_rev_checked_out_change_id => GetProperty("bl_rev_checked_out_change_id").StringValue;

	public string Bl_rev_has_trace_link => GetProperty("bl_rev_has_trace_link").StringValue;

	public string Bl_rev_process_stage => GetProperty("bl_rev_process_stage").StringValue;

	public string Bl_rev_external_apps => GetProperty("bl_rev_external_apps").StringValue;

	public string Bl_rev_projects_list => GetProperty("bl_rev_projects_list").StringValue;

	public string Bl_rev_ics_subclass_name => GetProperty("bl_rev_ics_subclass_name").StringValue;

	public string Bl_rev_ics_classified => GetProperty("bl_rev_ics_classified").StringValue;

	public string Bl_rev_based_on => GetProperty("bl_rev_based_on").StringValue;

	public string Bl_rev_item_revision => GetProperty("bl_rev_item_revision").StringValue;

	public string Bl_rev_change => GetProperty("bl_rev_change").StringValue;

	public string Bl_rev_checked_out_user => GetProperty("bl_rev_checked_out_user").StringValue;

	public string Bl_rev_is_modifiable => GetProperty("bl_rev_is_modifiable").StringValue;

	public string Bl_rev_protection => GetProperty("bl_rev_protection").StringValue;

	public string Bl_rev_current_name => GetProperty("bl_rev_current_name").StringValue;

	public string Bl_rev_proj_assign_mod_date => GetProperty("bl_rev_proj_assign_mod_date").StringValue;

	public string Bl_rev_expl_checkout => GetProperty("bl_rev_expl_checkout").StringValue;

	public string Bl_rev_checked_out => GetProperty("bl_rev_checked_out").StringValue;

	public string Bl_rev_checked_out_date => GetProperty("bl_rev_checked_out_date").StringValue;

	public string Bl_rev_ip_logged => GetProperty("bl_rev_ip_logged").StringValue;

	public string Bl_rev_user_can_unmanage => GetProperty("bl_rev_user_can_unmanage").StringValue;

	public string Bl_rev_null_logical => GetProperty("bl_rev_null_logical").StringValue;

	public string Bl_rev_null_string => GetProperty("bl_rev_null_string").StringValue;

	public string Bl_rev_fnd0defining_objects => GetProperty("bl_rev_fnd0defining_objects").StringValue;

	public string Bl_rev_fnd0complying_objects => GetProperty("bl_rev_fnd0complying_objects").StringValue;

	public string Bl_rev_fnd0IsCheckoutable => GetProperty("bl_rev_fnd0IsCheckoutable").StringValue;

	public string Bl_rev_fnd0WorkflowAuditLogs => GetProperty("bl_rev_fnd0WorkflowAuditLogs").StringValue;

	public string Bl_rev_fnd0GeneralAuditLogs => GetProperty("bl_rev_fnd0GeneralAuditLogs").StringValue;

	public string Bl_rev_fnd0LicenseExportAuditLogs => GetProperty("bl_rev_fnd0LicenseExportAuditLogs").StringValue;

	public string Bl_rev_fnd0ActuatedInteractiveTsks => GetProperty("bl_rev_fnd0ActuatedInteractiveTsks").StringValue;

	public string Bl_rev_IMAN_based_on => GetProperty("bl_rev_IMAN_based_on").StringValue;

	public string Bl_rev_Fnd0DigitalSignatureRel => GetProperty("bl_rev_Fnd0DigitalSignatureRel").StringValue;

	public string Bl_rev_Fnd0DigitalSignObsoleteRel => GetProperty("bl_rev_Fnd0DigitalSignObsoleteRel").StringValue;

	public string Bl_rev_FND_TraceLink => GetProperty("bl_rev_FND_TraceLink").StringValue;

	public string Bl_rev_Fnd0ShapeRelation => GetProperty("bl_rev_Fnd0ShapeRelation").StringValue;

	public string Bl_rev_Fnd0DiagramTmplRelation => GetProperty("bl_rev_Fnd0DiagramTmplRelation").StringValue;

	public string Bl_rev_Fnd0Diagram_Attaches => GetProperty("bl_rev_Fnd0Diagram_Attaches").StringValue;

	public string Bl_rev_Fnd0DiagramSnapshot => GetProperty("bl_rev_Fnd0DiagramSnapshot").StringValue;

	public string Bl_rev_IMAN_UG_promotion => GetProperty("bl_rev_IMAN_UG_promotion").StringValue;

	public string Bl_rev_representation_for => GetProperty("bl_rev_representation_for").StringValue;

	public string Bl_rev_interpart_links => GetProperty("bl_rev_interpart_links").StringValue;

	public string Bl_rev_current_revision_id => GetProperty("bl_rev_current_revision_id").StringValue;

	public string Bl_rev_IMAN_UG_wave_geometry => GetProperty("bl_rev_IMAN_UG_wave_geometry").StringValue;

	public string Bl_rev_IMAN_MEMfgModel => GetProperty("bl_rev_IMAN_MEMfgModel").StringValue;

	public string Bl_rev_interpart_equations => GetProperty("bl_rev_interpart_equations").StringValue;

	public string Bl_rev_IMAN_UG_wave_part_link => GetProperty("bl_rev_IMAN_UG_wave_part_link").StringValue;

	public string Bl_rev_IMAN_UG_altrep => GetProperty("bl_rev_IMAN_UG_altrep").StringValue;

	public string Bl_rev_IMAN_3D_snap_shot => GetProperty("bl_rev_IMAN_3D_snap_shot").StringValue;

	public string Bl_rev_mating_constraints => GetProperty("bl_rev_mating_constraints").StringValue;

	public string Bl_rev_allowable_participant_types => GetProperty("bl_rev_allowable_participant_types").StringValue;

	public string Bl_rev_assignable_participant_types => GetProperty("bl_rev_assignable_participant_types").StringValue;

	public string Bl_rev_participants => GetProperty("bl_rev_participants").StringValue;

	public string Bl_rev_epm_proposed_reviewers => GetProperty("bl_rev_epm_proposed_reviewers").StringValue;

	public string Bl_rev_epm_proposed_responsible_party => GetProperty("bl_rev_epm_proposed_responsible_party").StringValue;

	public string Bl_rev_mvl_text => GetProperty("bl_rev_mvl_text").StringValue;

	public string Bl_rev_IMAN_specification => GetProperty("bl_rev_IMAN_specification").StringValue;

	public string Bl_rev_Fnd0ExportContent => GetProperty("bl_rev_Fnd0ExportContent").StringValue;

	public string Bl_rev_EC_solution_item_rel => GetProperty("bl_rev_EC_solution_item_rel").StringValue;

	public string Bl_rev_EC_addressed_by_rel => GetProperty("bl_rev_EC_addressed_by_rel").StringValue;

	public string Bl_rev_id_dispdefault => GetProperty("bl_rev_id_dispdefault").StringValue;

	public string Bl_rev_item_id => GetProperty("bl_rev_item_id").StringValue;

	public string Bl_rev_TC_Generic_Architecture => GetProperty("bl_rev_TC_Generic_Architecture").StringValue;

	public string Bl_rev_effectivity_text => GetProperty("bl_rev_effectivity_text").StringValue;

	public string Bl_rev_IMAN_external_object_link => GetProperty("bl_rev_IMAN_external_object_link").StringValue;

	public string Bl_rev_has_module => GetProperty("bl_rev_has_module").StringValue;

	public string Bl_rev_altid_list => GetProperty("bl_rev_altid_list").StringValue;

	public string Bl_rev_EC_problem_item_rel => GetProperty("bl_rev_EC_problem_item_rel").StringValue;

	public string Bl_rev_EC_reference_item_rel => GetProperty("bl_rev_EC_reference_item_rel").StringValue;

	public string Bl_rev_has_variants => GetProperty("bl_rev_has_variants").StringValue;

	public string Bl_rev_intent_text => GetProperty("bl_rev_intent_text").StringValue;

	public string Bl_rev_IMAN_UG_wave_position => GetProperty("bl_rev_IMAN_UG_wave_position").StringValue;

	public string Bl_rev_TC_CAE_Defining => GetProperty("bl_rev_TC_CAE_Defining").StringValue;

	public string Bl_rev_IMAN_classification => GetProperty("bl_rev_IMAN_classification").StringValue;

	public string Bl_rev_IMAN_Rendering => GetProperty("bl_rev_IMAN_Rendering").StringValue;

	public string Bl_rev_IMAN_master_form_rev => GetProperty("bl_rev_IMAN_master_form_rev").StringValue;

	public string Bl_rev_IMAN_UG_expression => GetProperty("bl_rev_IMAN_UG_expression").StringValue;

	public string Bl_rev_IMAN_UG_scenario => GetProperty("bl_rev_IMAN_UG_scenario").StringValue;

	public string Bl_rev_TCEng_rdv_plmxml_configured => GetProperty("bl_rev_TCEng_rdv_plmxml_configured").StringValue;

	public string Bl_rev_IMAN_Motion => GetProperty("bl_rev_IMAN_Motion").StringValue;

	public string Bl_rev_IMAN_aliasid => GetProperty("bl_rev_IMAN_aliasid").StringValue;

	public string Bl_rev_TC_CAE_Source => GetProperty("bl_rev_TC_CAE_Source").StringValue;

	public string Bl_rev_geometric_interfaces => GetProperty("bl_rev_geometric_interfaces").StringValue;

	public string Bl_rev_is_vi => GetProperty("bl_rev_is_vi").StringValue;

	public string Bl_rev_IMAN_manifestation => GetProperty("bl_rev_IMAN_manifestation").StringValue;

	public string Bl_rev_TC_ProductManual => GetProperty("bl_rev_TC_ProductManual").StringValue;

	public string Bl_rev_IMAN_Simulation => GetProperty("bl_rev_IMAN_Simulation").StringValue;

	public string Bl_rev_TC_CAE_Target => GetProperty("bl_rev_TC_CAE_Target").StringValue;

	public string Bl_rev_TC_WorkContext_Relation => GetProperty("bl_rev_TC_WorkContext_Relation").StringValue;

	public string Bl_rev_IMAN_reference => GetProperty("bl_rev_IMAN_reference").StringValue;

	public string Bl_rev_TC_CAE_Results => GetProperty("bl_rev_TC_CAE_Results").StringValue;

	public string Bl_rev_TC_Validation => GetProperty("bl_rev_TC_Validation").StringValue;

	public string Bl_rev_gc_updated_from_object_string => GetProperty("bl_rev_gc_updated_from_object_string").StringValue;

	public string Bl_rev_EC_affected_item_rel => GetProperty("bl_rev_EC_affected_item_rel").StringValue;

	public string Bl_rev_EC_snapshot_rel => GetProperty("bl_rev_EC_snapshot_rel").StringValue;

	public string Bl_rev_IMAN_UG_udf => GetProperty("bl_rev_IMAN_UG_udf").StringValue;

	public string Bl_rev_parametric_interfaces => GetProperty("bl_rev_parametric_interfaces").StringValue;

	public string Bl_rev_current_id => GetProperty("bl_rev_current_id").StringValue;

	public string Bl_rev_TCEng_rdv_plmxml_unconfigured => GetProperty("bl_rev_TCEng_rdv_plmxml_unconfigured").StringValue;

	public string Bl_rev_IMAN_requirement => GetProperty("bl_rev_IMAN_requirement").StringValue;

	public string Bl_rev_IMAN_snapshot => GetProperty("bl_rev_IMAN_snapshot").StringValue;

	public string Bl_rev_IMAN_MEWorkInstruction => GetProperty("bl_rev_IMAN_MEWorkInstruction").StringValue;

	public string Bl_rev_current_id_context => GetProperty("bl_rev_current_id_context").StringValue;

	public string Bl_rev_current_id_type => GetProperty("bl_rev_current_id_type").StringValue;

	public string Bl_rev_current_id_uid => GetProperty("bl_rev_current_id_uid").StringValue;

	public string Bl_rev_TC_CAE_Criteria => GetProperty("bl_rev_TC_CAE_Criteria").StringValue;

	public string Bl_rev_TC_CAE_Include => GetProperty("bl_rev_TC_CAE_Include").StringValue;

	public string Bl_rev_TC_CAE_Param => GetProperty("bl_rev_TC_CAE_Param").StringValue;

	public string Bl_rev_BOM_Rollup => GetProperty("bl_rev_BOM_Rollup").StringValue;

	public string Bl_rev_TC_Attaches => GetProperty("bl_rev_TC_Attaches").StringValue;

	public string Bl_rev_Thumbnail_Source => GetProperty("bl_rev_Thumbnail_Source").StringValue;

	public string Bl_rev_TC_sst_record => GetProperty("bl_rev_TC_sst_record").StringValue;

	public string Bl_rev_ContactInCompany => GetProperty("bl_rev_ContactInCompany").StringValue;

	public string Bl_rev_LocationInCompany => GetProperty("bl_rev_LocationInCompany").StringValue;

	public string Bl_rev_HasParticipant => GetProperty("bl_rev_HasParticipant").StringValue;

	public string Bl_rev_is_IRDC => GetProperty("bl_rev_is_IRDC").StringValue;

	public string Bl_rev_fms_tickets => GetProperty("bl_rev_fms_tickets").StringValue;

	public string Bl_rev_VisItemRevCreatedSnapshot2D => GetProperty("bl_rev_VisItemRevCreatedSnapshot2D").StringValue;

	public string Bl_rev_Fnd0ListsCustomNotes => GetProperty("bl_rev_Fnd0ListsCustomNotes").StringValue;

	public string Bl_rev_Fnd0ListsParamReqments => GetProperty("bl_rev_Fnd0ListsParamReqments").StringValue;

	public string Bl_rev_revision_list => GetProperty("bl_rev_revision_list").StringValue;

	public string Bl_rev_fnd0StructureAuditLogs => GetProperty("bl_rev_fnd0StructureAuditLogs").StringValue;

	public string Bl_rev_ps_children => GetProperty("bl_rev_ps_children").StringValue;

	public string Bl_rev_ps_parents => GetProperty("bl_rev_ps_parents").StringValue;

	public string Bl_rev_Fnd0StruObjAttrOverride => GetProperty("bl_rev_Fnd0StruObjAttrOverride").StringValue;

	public string Bl_rev_VisSession => GetProperty("bl_rev_VisSession").StringValue;

	public string Bl_rev_VisMarkup => GetProperty("bl_rev_VisMarkup").StringValue;

	public string Bl_rev_SimplifiedRendering => GetProperty("bl_rev_SimplifiedRendering").StringValue;

	public string Bl_rev_Fnd0SpatialRendering => GetProperty("bl_rev_Fnd0SpatialRendering").StringValue;

	public string Bl_rev_fnd0derived_default_rules => GetProperty("bl_rev_fnd0derived_default_rules").StringValue;

	public string Bl_rev_fnd0IRDCUsed => GetProperty("bl_rev_fnd0IRDCUsed").StringValue;

	public string Bl_rev_fnd0fixed_default_rules => GetProperty("bl_rev_fnd0fixed_default_rules").StringValue;

	public string Bl_rev_fnd0option_groups => GetProperty("bl_rev_fnd0option_groups").StringValue;

	public string Bl_rev_fnd0option_values => GetProperty("bl_rev_fnd0option_values").StringValue;

	public string Bl_rev_Fnd0TC_valdata_result => GetProperty("bl_rev_Fnd0TC_valdata_result").StringValue;

	public string Bl_rev_fnd0constraint_rules => GetProperty("bl_rev_fnd0constraint_rules").StringValue;

	public string Bl_rev_Fnd0ViewCapture => GetProperty("bl_rev_Fnd0ViewCapture").StringValue;

	public string Bl_rev_CAEAnalysis => GetProperty("bl_rev_CAEAnalysis").StringValue;

	public string Bl_rev_MEProcess => GetProperty("bl_rev_MEProcess").StringValue;

	public string Bl_rev_MESetup => GetProperty("bl_rev_MESetup").StringValue;

	public string Bl_rev_view => GetProperty("bl_rev_view").StringValue;

	public string Bl_occ_timestamp => GetProperty("bl_occ_timestamp").StringValue;

	public string Bl_occ_pid => GetProperty("bl_occ_pid").StringValue;

	public string Bl_occ_object_properties => GetProperty("bl_occ_object_properties").StringValue;

	public string Bl_occ_lsd => GetProperty("bl_occ_lsd").StringValue;

	public string Bl_occ_owning_site => GetProperty("bl_occ_owning_site").StringValue;

	public string Bl_occ_child_item => GetProperty("bl_occ_child_item").StringValue;

	public string Bl_occ_alternate_etc_ref => GetProperty("bl_occ_alternate_etc_ref").StringValue;

	public string Bl_occ_variant_condition => GetProperty("bl_occ_variant_condition").StringValue;

	public string Bl_occ_occ_type => GetProperty("bl_occ_occ_type").StringValue;

	public string Bl_occ_used_options => GetProperty("bl_occ_used_options").StringValue;

	public string Bl_occ_effectivities => GetProperty("bl_occ_effectivities").StringValue;

	public string Bl_occ_seq_no => GetProperty("bl_occ_seq_no").StringValue;

	public string Bl_occ_occurrence_type => GetProperty("bl_occ_occurrence_type").StringValue;

	public string Bl_occ_order_no => GetProperty("bl_occ_order_no").StringValue;

	public string Bl_occ_occ_flags => GetProperty("bl_occ_occ_flags").StringValue;

	public string Bl_occ_qty_value => GetProperty("bl_occ_qty_value").StringValue;

	public string Bl_occ_cd_indexes => GetProperty("bl_occ_cd_indexes").StringValue;

	public string Bl_occ_cd_tags => GetProperty("bl_occ_cd_tags").StringValue;

	public string Bl_occ_ext_transform_rot00 => GetProperty("bl_occ_ext_transform_rot00").StringValue;

	public string Bl_occ_ext_transform_rot10 => GetProperty("bl_occ_ext_transform_rot10").StringValue;

	public string Bl_occ_ext_transform_rot20 => GetProperty("bl_occ_ext_transform_rot20").StringValue;

	public string Bl_occ_ext_transform_per0 => GetProperty("bl_occ_ext_transform_per0").StringValue;

	public string Bl_occ_ext_transform_rot01 => GetProperty("bl_occ_ext_transform_rot01").StringValue;

	public string Bl_occ_ext_transform_rot11 => GetProperty("bl_occ_ext_transform_rot11").StringValue;

	public string Bl_occ_ext_transform_rot21 => GetProperty("bl_occ_ext_transform_rot21").StringValue;

	public string Bl_occ_ext_transform_per1 => GetProperty("bl_occ_ext_transform_per1").StringValue;

	public string Bl_occ_ext_transform_rot02 => GetProperty("bl_occ_ext_transform_rot02").StringValue;

	public string Bl_occ_ext_transform_rot12 => GetProperty("bl_occ_ext_transform_rot12").StringValue;

	public string Bl_occ_ext_transform_rot22 => GetProperty("bl_occ_ext_transform_rot22").StringValue;

	public string Bl_occ_ext_transform_per2 => GetProperty("bl_occ_ext_transform_per2").StringValue;

	public string Bl_occ_ext_transform_tra0 => GetProperty("bl_occ_ext_transform_tra0").StringValue;

	public string Bl_occ_ext_transform_tra1 => GetProperty("bl_occ_ext_transform_tra1").StringValue;

	public string Bl_occ_ext_transform_tra2 => GetProperty("bl_occ_ext_transform_tra2").StringValue;

	public string Bl_occ_ext_transform_invscale => GetProperty("bl_occ_ext_transform_invscale").StringValue;

	public string Bl_occ_pred_list => GetProperty("bl_occ_pred_list").StringValue;

	public string Bl_occ_occurrence_name => GetProperty("bl_occ_occurrence_name").StringValue;

	public string Bl_occ_child_bv => GetProperty("bl_occ_child_bv").StringValue;

	public string Bl_occ_parent_bvr => GetProperty("bl_occ_parent_bvr").StringValue;

	public string Bl_occ_uom_tag => GetProperty("bl_occ_uom_tag").StringValue;

	public string Bl_occ_ref_designator => GetProperty("bl_occ_ref_designator").StringValue;

	public string Bl_occ_occ_thread => GetProperty("bl_occ_occ_thread").StringValue;

	public string Bl_occ_xform => GetProperty("bl_occ_xform").StringValue;

	public string Bl_occ_notes_ref => GetProperty("bl_occ_notes_ref").StringValue;

	public string Bl_occ_object_string => GetProperty("bl_occ_object_string").StringValue;

	public string Bl_occ_fnd0objectId => GetProperty("bl_occ_fnd0objectId").StringValue;

	public string Bl_occ_fnd0mfkinfo => GetProperty("bl_occ_fnd0mfkinfo").StringValue;

	public string Bl_occ_fnd0ContextContrast => GetProperty("bl_occ_fnd0ContextContrast").StringValue;

	public string Bl_occ_fnd0HasEditInContext => GetProperty("bl_occ_fnd0HasEditInContext").StringValue;

	public string Bl_occ_fnd0IsConfiguredInContext => GetProperty("bl_occ_fnd0IsConfiguredInContext").StringValue;

	public string Bl_occ_IMAN_based_on => GetProperty("bl_occ_IMAN_based_on").StringValue;

	public string Bl_occ_IMAN_MEAppearance => GetProperty("bl_occ_IMAN_MEAppearance").StringValue;

	public string Bl_occ_IMAN_MEProductLocation => GetProperty("bl_occ_IMAN_MEProductLocation").StringValue;

	public string Bl_occ_TC_ProductManual => GetProperty("bl_occ_TC_ProductManual").StringValue;

	public string Bl_occ_IMAN_MERequiredAppr => GetProperty("bl_occ_IMAN_MERequiredAppr").StringValue;

	public string Bl_occ_IMAN_MEProductAppearance => GetProperty("bl_occ_IMAN_MEProductAppearance").StringValue;

	public string Bl_occ_IMAN_MEWorkInstruction => GetProperty("bl_occ_IMAN_MEWorkInstruction").StringValue;

	public string Bl_occ_mvl_condition => GetProperty("bl_occ_mvl_condition").StringValue;

	public string Bl_Item_Master_project_id => GetProperty("bl_Item Master_project_id").StringValue;

	public string Bl_Item_Master_previous_item_id => GetProperty("bl_Item Master_previous_item_id").StringValue;

	public string Bl_Item_Master_serial_number => GetProperty("bl_Item Master_serial_number").StringValue;

	public string Bl_Item_Master_item_comment => GetProperty("bl_Item Master_item_comment").StringValue;

	public string Bl_Item_Master_user_data_1 => GetProperty("bl_Item Master_user_data_1").StringValue;

	public string Bl_Item_Master_user_data_2 => GetProperty("bl_Item Master_user_data_2").StringValue;

	public string Bl_Item_Master_user_data_3 => GetProperty("bl_Item Master_user_data_3").StringValue;

	public string Bl_ItemRevision_Master_project_id => GetProperty("bl_ItemRevision Master_project_id").StringValue;

	public string Bl_ItemRevision_Master_previous_version_id => GetProperty("bl_ItemRevision Master_previous_version_id").StringValue;

	public string Bl_ItemRevision_Master_serial_number => GetProperty("bl_ItemRevision Master_serial_number").StringValue;

	public string Bl_ItemRevision_Master_item_comment => GetProperty("bl_ItemRevision Master_item_comment").StringValue;

	public string Bl_ItemRevision_Master_user_data_1 => GetProperty("bl_ItemRevision Master_user_data_1").StringValue;

	public string Bl_ItemRevision_Master_user_data_2 => GetProperty("bl_ItemRevision Master_user_data_2").StringValue;

	public string Bl_ItemRevision_Master_user_data_3 => GetProperty("bl_ItemRevision Master_user_data_3").StringValue;

	public string Bl_Mfg0MEEquipmentRevision_mfg0longLeadItem => GetProperty("bl_Mfg0MEEquipmentRevision_mfg0longLeadItem").StringValue;

	public string Bl_Mfg0MEEquipmentRevision_mfg0purchased => GetProperty("bl_Mfg0MEEquipmentRevision_mfg0purchased").StringValue;

	public string Bl_Mfg0MEEquipmentRevision_mfg0supplier => GetProperty("bl_Mfg0MEEquipmentRevision_mfg0supplier").StringValue;

	public string Bl_Mfg0MEEquipmentRevision_mfg0weight => GetProperty("bl_Mfg0MEEquipmentRevision_mfg0weight").StringValue;

	public string Bl_rev_fnd0rollupAccuracy => GetProperty("bl_rev_fnd0rollupAccuracy").StringValue;

	public string Bl_rev_fnd0rollupCoMx => GetProperty("bl_rev_fnd0rollupCoMx").StringValue;

	public string Bl_rev_fnd0rollupCoMy => GetProperty("bl_rev_fnd0rollupCoMy").StringValue;

	public string Bl_rev_fnd0rollupCoMz => GetProperty("bl_rev_fnd0rollupCoMz").StringValue;

	public string Bl_rev_fnd0rollupMass => GetProperty("bl_rev_fnd0rollupMass").StringValue;

	public string Bl_rev_fnd0rollupMoIxx => GetProperty("bl_rev_fnd0rollupMoIxx").StringValue;

	public string Bl_rev_fnd0rollupMoIyy => GetProperty("bl_rev_fnd0rollupMoIyy").StringValue;

	public string Bl_rev_fnd0rollupMoIzz => GetProperty("bl_rev_fnd0rollupMoIzz").StringValue;

	public string Bl_rev_fnd0rollupPoIxy => GetProperty("bl_rev_fnd0rollupPoIxy").StringValue;

	public string Bl_rev_fnd0rollupPoIxz => GetProperty("bl_rev_fnd0rollupPoIxz").StringValue;

	public string Bl_rev_fnd0rollupPoIyz => GetProperty("bl_rev_fnd0rollupPoIyz").StringValue;

	public int Fnd0_bl_rev_owning_site_id => GetProperty("fnd0_bl_rev_owning_site_id").IntValue;

	public string AIE_Exported => GetProperty("AIE_Exported").StringValue;

	public string AIE_OCC_ID => GetProperty("AIE_OCC_ID").StringValue;

	public string AIE_OCC_NAME => GetProperty("AIE_OCC_NAME").StringValue;

	public string Fnd0IgnorePartialMat => GetProperty("Fnd0IgnorePartialMat").StringValue;

	public string Fnd0MEAsgnmtStateTy => GetProperty("Fnd0MEAsgnmtStateTy").StringValue;

	public string GCS_CP => GetProperty("GCS CP").StringValue;

	public string MENXNewResourceUid => GetProperty("MENXNewResourceUid").StringValue;

	public string MEResourceID => GetProperty("MEResourceID").StringValue;

	public string MEUILocation => GetProperty("MEUILocation").StringValue;

	public string MRM_CompImportIndex => GetProperty("MRM CompImportIndex").StringValue;

	public string MRM_PSP => GetProperty("MRM PSP").StringValue;

	public string MajorFeatureVersion => GetProperty("MajorFeatureVersion").StringValue;

	public string Mfg0SensorDetRange => GetProperty("Mfg0SensorDetRange").StringValue;

	public string MinorFeatureVersion => GetProperty("MinorFeatureVersion").StringValue;

	public string TEMPLATE_ACTION => GetProperty("TEMPLATE ACTION").StringValue;

	public string UG_ALTREP => GetProperty("UG ALTREP").StringValue;

	public string UG_ENTITY_HANDLE => GetProperty("UG ENTITY HANDLE").StringValue;

	public string UG_GEOMETRY => GetProperty("UG GEOMETRY").StringValue;

	public string UG_NAME => GetProperty("UG NAME").StringValue;

	public string UG_REF_SET => GetProperty("UG REF SET").StringValue;

	public string Usage_ArchitectureId => GetProperty("Usage_ArchitectureId").StringValue;

	public string Usage_PartNumber => GetProperty("Usage_PartNumber").StringValue;

	public string Usage_Product => GetProperty("Usage_Product").StringValue;

	public string Usage_Quantity => GetProperty("Usage_Quantity").StringValue;

	public string Mfg0PLCOPCConnection => GetProperty("Mfg0PLCOPCConnection").StringValue;

	public string Mfg0ProductionRate => GetProperty("Mfg0ProductionRate").StringValue;

	public BOMLine(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
