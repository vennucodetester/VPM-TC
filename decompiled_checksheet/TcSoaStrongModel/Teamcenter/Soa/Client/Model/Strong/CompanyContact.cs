namespace Teamcenter.Soa.Client.Model.Strong;

public class CompanyContact : WorkspaceObject
{
	public string First_name => GetProperty("first_name").StringValue;

	public string Last_name => GetProperty("last_name").StringValue;

	public string Title => GetProperty("title").StringValue;

	public string Suffix => GetProperty("suffix").StringValue;

	public string Phone_business => GetProperty("phone_business").StringValue;

	public string Phone_home => GetProperty("phone_home").StringValue;

	public string Phone_mobile => GetProperty("phone_mobile").StringValue;

	public string Fax_number => GetProperty("fax_number").StringValue;

	public string Pager_number => GetProperty("pager_number").StringValue;

	public string Email_address => GetProperty("email_address").StringValue;

	public CompanyContact(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
