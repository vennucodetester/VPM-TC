namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdBootstrapPkg : ApprUpdChangePkg
{
	public AppearanceRoot Appr_root => (AppearanceRoot)GetProperty("appr_root").ModelObjectValue;

	public ApprUpdBootstrapPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
