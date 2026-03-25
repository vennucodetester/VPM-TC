namespace Teamcenter.Soa.Client.Model.Strong;

public class Authentication : POM_object
{
	public string Proxy_username => GetProperty("proxy_username").StringValue;

	public string Proxy_password => GetProperty("proxy_password").StringValue;

	public int Account_type => GetProperty("account_type").IntValue;

	public Authentication(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
