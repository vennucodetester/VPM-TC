namespace Teamcenter.Soa.Client.Model.Strong;

public class AppearanceTrackedItemInfo : POM_object
{
	public Item Tracked_item => (Item)GetProperty("tracked_item").ModelObjectValue;

	public PSBOMView Bom_view => (PSBOMView)GetProperty("bom_view").ModelObjectValue;

	public AppearanceTrackedItemInfo(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
