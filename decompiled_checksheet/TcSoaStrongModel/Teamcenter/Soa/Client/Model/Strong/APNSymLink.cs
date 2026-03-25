using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class APNSymLink : POM_object
{
	public ModelObject Config_bvr => GetProperty("config_bvr").ModelObjectValue;

	public bool Orig_visible => GetProperty("orig_visible").BoolValue;

	public string Seqno => GetProperty("seqno").StringValue;

	public DateTime Last_mod_date => GetProperty("last_mod_date").DateValue;

	public MEAppearancePathNode Orig_apn => (MEAppearancePathNode)GetProperty("orig_apn").ModelObjectValue;

	public MEAppearancePathNode Symbolic_apn => (MEAppearancePathNode)GetProperty("symbolic_apn").ModelObjectValue;

	public MEAppearancePathNode Destination_parent_apn => (MEAppearancePathNode)GetProperty("destination_parent_apn").ModelObjectValue;

	public APNSymLink(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
