namespace Teamcenter.Soa.Client.Model.Strong;

public class CfgAttachmentWindow : MECfgWindow
{
	public ModelObject Attach_source_bom_win => GetProperty("attach_source_bom_win").ModelObjectValue;

	public CfgAttachmentWindow(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
