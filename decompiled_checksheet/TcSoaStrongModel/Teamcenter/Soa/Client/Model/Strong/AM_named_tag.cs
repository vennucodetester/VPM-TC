namespace Teamcenter.Soa.Client.Model.Strong;

public class AM_named_tag : POM_object
{
	public string Name => GetProperty("Name").StringValue;

	public AM_named_tag(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
