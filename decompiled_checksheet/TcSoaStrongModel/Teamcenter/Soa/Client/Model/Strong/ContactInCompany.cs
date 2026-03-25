namespace Teamcenter.Soa.Client.Model.Strong;

public class ContactInCompany : ImanRelation
{
	public string Contact_role => GetProperty("contact_role").StringValue;

	public string Contact_type => GetProperty("contact_type").StringValue;

	public ContactInCompany(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
