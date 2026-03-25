using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprHistoryDateEntry : ApprHistoryEntry
{
	public DateTime In_date => GetProperty("in_date").DateValue;

	public DateTime Out_date => GetProperty("out_date").DateValue;

	public ApprHistoryDateEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
