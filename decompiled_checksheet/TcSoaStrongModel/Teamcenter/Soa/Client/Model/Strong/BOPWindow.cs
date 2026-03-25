namespace Teamcenter.Soa.Client.Model.Strong;

public class BOPWindow : BOMWindow
{
	public ModelObject Product_window => GetProperty("product_window").ModelObjectValue;

	public ModelObject[] Reference_windows => GetProperty("reference_windows").ModelObjectArrayValue;

	public ModelObject Workarea_window => GetProperty("workarea_window").ModelObjectValue;

	public bool Show_unconfigured_assignment => GetProperty("show_unconfigured_assignment").BoolValue;

	public BOPWindow(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
