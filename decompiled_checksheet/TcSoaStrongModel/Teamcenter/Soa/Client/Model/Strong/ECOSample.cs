namespace Teamcenter.Soa.Client.Model.Strong;

public class ECOSample : POM_object
{
	public string Charge_number => GetProperty("charge_number").StringValue;

	public string Models_affected => GetProperty("models_affected").StringValue;

	public string Stability => GetProperty("stability").StringValue;

	public string Durability => GetProperty("durability").StringValue;

	public ECOSample(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
