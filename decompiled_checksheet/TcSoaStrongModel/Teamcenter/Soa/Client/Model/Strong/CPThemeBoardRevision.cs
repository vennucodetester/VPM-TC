namespace Teamcenter.Soa.Client.Model.Strong;

public class CPThemeBoardRevision : DocumentRevision
{
	public ModelObject[] CP_marketing_briefs => GetProperty("CP_marketing_briefs").ModelObjectArrayValue;

	public CPThemeBoardRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
