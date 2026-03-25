namespace Teamcenter.Soa.Client.Model.Strong;

public class CompanyLocation : WorkspaceObject
{
	public string Street => GetProperty("street").StringValue;

	public string City => GetProperty("city").StringValue;

	public string State_province => GetProperty("state_province").StringValue;

	public string Postal_code => GetProperty("postal_code").StringValue;

	public string Country => GetProperty("country").StringValue;

	public string Region => GetProperty("region").StringValue;

	public string Url => GetProperty("url").StringValue;

	public string Fnd0LocationType => GetProperty("fnd0LocationType").StringValue;

	public string Fnd0LocationCode => GetProperty("fnd0LocationCode").StringValue;

	public ModelObject[] ContactInCompany => GetProperty("ContactInCompany").ModelObjectArrayValue;

	public CompanyLocation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
