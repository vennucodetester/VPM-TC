namespace Teamcenter.Soa.Client.Model.Strong;

public class AppearanceAttr : POM_object
{
	public string Value => GetProperty("value").StringValue;

	public AppearanceAttrDefinition Definition => (AppearanceAttrDefinition)GetProperty("definition").ModelObjectValue;

	public Appearance Appearance => (Appearance)GetProperty("appearance").ModelObjectValue;

	public AppearanceAttr(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
