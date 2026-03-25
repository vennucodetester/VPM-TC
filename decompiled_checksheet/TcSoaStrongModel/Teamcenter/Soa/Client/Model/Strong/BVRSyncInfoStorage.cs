using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class BVRSyncInfoStorage : POM_object
{
	public DateTime Last_sync_date => GetProperty("last_sync_date").DateValue;

	public DateTime Last_struct_mod => GetProperty("last_struct_mod").DateValue;

	public string View_type => GetProperty("view_type").StringValue;

	public string Appl_data => GetProperty("appl_data").StringValue;

	public BVRSyncInfoStorage(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
