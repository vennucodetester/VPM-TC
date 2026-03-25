namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdByApprRootWorkingPkg : ApprUpdByApprRootPkg
{
	public AppearanceRoot Appr_root => (AppearanceRoot)GetProperty("appr_root").ModelObjectValue;

	public ApprUpdByApprRootWorkingPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
