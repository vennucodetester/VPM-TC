using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ArroDateEffsHistoryEntry : ArroHistoryEntry
{
	public DateTime[] Date_effectivities => GetProperty("date_effectivities").DateArrayValue;

	public ArroDateEffsHistoryEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
