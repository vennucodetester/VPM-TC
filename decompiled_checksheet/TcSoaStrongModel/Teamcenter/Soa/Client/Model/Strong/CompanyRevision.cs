namespace Teamcenter.Soa.Client.Model.Strong;

public class CompanyRevision : ItemRevision
{
	public string ContactName => GetProperty("ContactName").StringValue;

	public string Address => GetProperty("Address").StringValue;

	public string Phone => GetProperty("Phone").StringValue;

	public string Website => GetProperty("Website").StringValue;

	public CompanyRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
