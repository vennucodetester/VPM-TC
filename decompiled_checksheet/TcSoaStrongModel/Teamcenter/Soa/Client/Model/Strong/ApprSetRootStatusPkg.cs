using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSetRootStatusPkg : ApprUpdChangePkg
{
	public DateTime Queue_date => GetProperty("queue_date").DateValue;

	public AppearanceRoot Appearance_root => (AppearanceRoot)GetProperty("appearance_root").ModelObjectValue;

	public int Target_status => GetProperty("target_status").IntValue;

	public ApprSetRootStatusPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
