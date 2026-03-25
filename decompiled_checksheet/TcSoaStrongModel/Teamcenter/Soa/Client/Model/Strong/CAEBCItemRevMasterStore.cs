namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEBCItemRevMasterStore : POM_object
{
	public string Bc_name => GetProperty("bc_name").StringValue;

	public string Bc_desc => GetProperty("bc_desc").StringValue;

	public string Bc_type => GetProperty("bc_type").StringValue;

	public string Geometry => GetProperty("geometry").StringValue;

	public string Constraint_type => GetProperty("constraint_type").StringValue;

	public string Coord_type => GetProperty("coord_type").StringValue;

	public string Components => GetProperty("components").StringValue;

	public string Magnitude => GetProperty("magnitude").StringValue;

	public ModelObject Owner_form_obj => GetProperty("owner_form_obj").ModelObjectValue;

	public string Bc_link_path => GetProperty("bc_link_path").StringValue;

	public string Bc_eint_form_type => GetProperty("bc_eint_form_type").StringValue;

	public string Bc_vault_mode => GetProperty("bc_vault_mode").StringValue;

	public string Bc_rev_id => GetProperty("bc_rev_id").StringValue;

	public string Bc_rev_name => GetProperty("bc_rev_name").StringValue;

	public CAEBCItemRevMasterStore(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
