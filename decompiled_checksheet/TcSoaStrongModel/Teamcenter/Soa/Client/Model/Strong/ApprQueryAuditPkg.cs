using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprQueryAuditPkg : ApprUpdChangePkg
{
	public AppearanceRoot Appearance_root => (AppearanceRoot)GetProperty("appearance_root").ModelObjectValue;

	public DateTime Queued_date => GetProperty("queued_date").DateValue;

	public DateTime Query_date_arg => GetProperty("query_date_arg").DateValue;

	public bool Query_search_on_unit_no_arg => GetProperty("query_search_on_unit_no_arg").BoolValue;

	public int Query_unit_no_arg => GetProperty("query_unit_no_arg").IntValue;

	public ApprQueryAuditPkg(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
