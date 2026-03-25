namespace Teamcenter.Soa.Client.Model.Strong;

public class BOSWindow : BOPWindow
{
	public ModelObject Source_line => GetProperty("source_line").ModelObjectValue;

	public BOSWindow(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
