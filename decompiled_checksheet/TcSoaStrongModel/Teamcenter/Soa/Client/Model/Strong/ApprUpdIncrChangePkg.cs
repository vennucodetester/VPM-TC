namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdIncrChangePkg : ApprUpdStructureChangePkg
{
	public ItemRevision Approved_incr_change_rev => (ItemRevision)GetProperty("approved_incr_change_rev").ModelObjectValue;

	public ApprUpdIncrChangePkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
