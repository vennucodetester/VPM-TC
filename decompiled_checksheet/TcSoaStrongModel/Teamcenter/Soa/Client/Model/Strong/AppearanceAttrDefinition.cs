namespace Teamcenter.Soa.Client.Model.Strong;

public class AppearanceAttrDefinition : POM_object
{
	public string Name => GetProperty("name").StringValue;

	public AppearanceAttrDefinition(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
