using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprHistoryEntry : POM_object
{
	public DateTime Mod_date => GetProperty("mod_date").DateValue;

	public Appearance Appearance => (Appearance)GetProperty("appearance").ModelObjectValue;

	public ApprHistoryEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
