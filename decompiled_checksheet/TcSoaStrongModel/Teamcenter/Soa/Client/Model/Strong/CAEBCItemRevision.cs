namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEBCItemRevision : ItemRevision
{
	public string Vault_mode => GetProperty("vault_mode").StringValue;

	public string Eint_form_type => GetProperty("eint_form_type").StringValue;

	public string[] Criteria_names => GetProperty("criteria_names").StringArrayValue;

	public string[] Criteria_values => GetProperty("criteria_values").StringArrayValue;

	public string Link_path => GetProperty("link_path").StringValue;

	public CAEBCItemRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
