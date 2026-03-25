using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CFM_date_info : POM_object
{
	public string Id => GetProperty("id").StringValue;

	public DateTime Auth_date => GetProperty("auth_date").DateValue;

	public DateTime[] Eff_date => GetProperty("eff_date").DateArrayValue;

	public POM_user Auth_user => (POM_user)GetProperty("auth_user").ModelObjectValue;

	public string Effectivity_id => GetProperty("effectivity_id").StringValue;

	public string Range_text => GetProperty("range_text").StringValue;

	public CFM_date_info(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
