using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CPBriefRevision : RequirementSpec_Revision
{
	public DateTime Initiative_target_date => GetProperty("initiative_target_date").DateValue;

	public string Target_market => GetProperty("target_market").StringValue;

	public string Product_category => GetProperty("product_category").StringValue;

	public CPBriefRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
