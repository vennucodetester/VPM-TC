namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMDerivedDefault : RuntimeBusinessObject
{
	public string As_string => GetProperty("as_string").StringValue;

	public BOMDerivedDefault(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
