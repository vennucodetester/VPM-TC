using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AppearanceRoot : POM_object
{
	public AppearanceConfigContext Config_context => (AppearanceConfigContext)GetProperty("config_context").ModelObjectValue;

	public AppearanceTrackedItemInfo Tracked_item_info => (AppearanceTrackedItemInfo)GetProperty("tracked_item_info").ModelObjectValue;

	public bool Has_spatial_data => GetProperty("has_spatial_data").BoolValue;

	public bool Is_for_pre_release => GetProperty("is_for_pre_release").BoolValue;

	public int Corruption_status => GetProperty("corruption_status").IntValue;

	public DateTime Ok_date => GetProperty("ok_date").DateValue;

	public bool Is_active => GetProperty("is_active").BoolValue;

	public bool Is_available => GetProperty("is_available").BoolValue;

	public DateTime Last_fix_date => GetProperty("last_fix_date").DateValue;

	public DateTime Last_check_date => GetProperty("last_check_date").DateValue;

	public ApprUpdChangePkg Last_aucp => (ApprUpdChangePkg)GetProperty("last_aucp").ModelObjectValue;

	public ModelObject Owning_group => GetProperty("owning_group").ModelObjectValue;

	public string Object_desc => GetProperty("object_desc").StringValue;

	public ModelObject Owning_user => GetProperty("owning_user").ModelObjectValue;

	public string Object_id => GetProperty("object_id").StringValue;

	public string Object_name => GetProperty("object_name").StringValue;

	public string Description => GetProperty("description").StringValue;

	public string Pubr_object_id => GetProperty("pubr_object_id").StringValue;

	public bool Is_published => GetProperty("is_published").BoolValue;

	public DateTime Creation_date => GetProperty("creation_date").DateValue;

	public string Object_type => GetProperty("object_type").StringValue;

	public int Num_appearances => GetProperty("num_appearances").IntValue;

	public AppearanceRoot(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
