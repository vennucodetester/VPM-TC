namespace Teamcenter.Soa.Client.Model.Strong;

public class ConstantAttach : POM_object
{
	public string Value => GetProperty("value").StringValue;

	public string[] Values => GetProperty("values").StringArrayValue;

	public ConstantAttach(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
