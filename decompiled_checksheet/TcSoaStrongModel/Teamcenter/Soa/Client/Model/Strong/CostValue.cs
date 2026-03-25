namespace Teamcenter.Soa.Client.Model.Strong;

public class CostValue : POM_object
{
	public string Cost => GetProperty("cost").StringValue;

	public string Currency => GetProperty("currency").StringValue;

	public CostValue(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
