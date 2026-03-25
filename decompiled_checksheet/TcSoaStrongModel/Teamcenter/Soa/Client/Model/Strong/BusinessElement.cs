namespace Teamcenter.Soa.Client.Model.Strong;

public class BusinessElement : BusinessRule
{
	public string Name => GetProperty("name").StringValue;

	public BusinessElement(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
