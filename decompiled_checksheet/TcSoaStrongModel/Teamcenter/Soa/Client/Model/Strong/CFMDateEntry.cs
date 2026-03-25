using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMDateEntry : CFMRuleEntry
{
	public bool Date_today => GetProperty("date_today").BoolValue;

	public DateTime Effective_date => GetProperty("effective_date").DateValue;

	public CFMDateEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
