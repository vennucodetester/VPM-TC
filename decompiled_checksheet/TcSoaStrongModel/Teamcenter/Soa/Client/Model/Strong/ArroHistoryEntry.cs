using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ArroHistoryEntry : POM_object
{
	public ApprRevRelation Arro => (ApprRevRelation)GetProperty("arro").ModelObjectValue;

	public DateTime Mod_date => GetProperty("mod_date").DateValue;

	public ArroHistoryEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
