namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEConnItemRevMasterStore : POM_object
{
	public string Conn_name => GetProperty("conn_name").StringValue;

	public string Conn_desc => GetProperty("conn_desc").StringValue;

	public string Conn_type => GetProperty("conn_type").StringValue;

	public string Geometry => GetProperty("geometry").StringValue;

	public string[] Conn_links => GetProperty("conn_links").StringArrayValue;

	public string Strength => GetProperty("strength").StringValue;

	public ModelObject Owner_form_obj => GetProperty("owner_form_obj").ModelObjectValue;

	public string Conn_rev_name => GetProperty("conn_rev_name").StringValue;

	public string Conn_rev_id => GetProperty("conn_rev_id").StringValue;

	public CAEConnItemRevMasterStore(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
