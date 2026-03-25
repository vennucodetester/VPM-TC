namespace Teamcenter.Soa.Client.Model.Strong;

public class CAELoadItemRevision_Master : Form
{
	public string Load_name => GetProperty("load_name").StringValue;

	public string Load_desc => GetProperty("load_desc").StringValue;

	public string Load_type => GetProperty("load_type").StringValue;

	public string Geometry => GetProperty("geometry").StringValue;

	public string Load_component_type => GetProperty("load_component_type").StringValue;

	public string Load_component_value => GetProperty("load_component_value").StringValue;

	public ModelObject Owner_form_obj => GetProperty("owner_form_obj").ModelObjectValue;

	public string Load_rev_name => GetProperty("load_rev_name").StringValue;

	public string Load_rev_id => GetProperty("load_rev_id").StringValue;

	public string Load_link_path => GetProperty("load_link_path").StringValue;

	public string Load_eint_form_type => GetProperty("load_eint_form_type").StringValue;

	public string Load_vault_mode => GetProperty("load_vault_mode").StringValue;

	public CAELoadItemRevision_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
