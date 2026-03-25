namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMFixedDefault : RuntimeBusinessObject
{
	public string As_string => GetProperty("as_string").StringValue;

	public BOMFixedDefault(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
