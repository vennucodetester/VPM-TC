namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMOption : RuntimeBusinessObject
{
	public string Name => GetProperty("name").StringValue;

	public string Description => GetProperty("description").StringValue;

	public BOMOption(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
