namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaMapAttr : ApprSearchCriteria
{
	public string Name => GetProperty("name").StringValue;

	public string Value => GetProperty("value").StringValue;

	public int Operator => GetProperty("operator").IntValue;

	public ApprSearchCriteriaMapAttr(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
