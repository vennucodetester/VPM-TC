using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprRevRelationDateEff : ApprRevRelation
{
	public DateTime[] Date_effectivity => GetProperty("date_effectivity").DateArrayValue;

	public ApprRevRelationDateEff(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
