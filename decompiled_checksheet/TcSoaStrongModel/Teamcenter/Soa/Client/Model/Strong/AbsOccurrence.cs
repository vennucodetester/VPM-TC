using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccurrence : POM_object
{
	public string Abs_occ_id => GetProperty("abs_occ_id").StringValue;

	public string Usage_address => GetProperty("usage_address").StringValue;

	public string Logical_position => GetProperty("logical_position").StringValue;

	public DateTime Last_mod_date => GetProperty("last_mod_date").DateValue;

	public AbsOccurrence(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
