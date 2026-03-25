namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaAttribute : ApprSearchCriteria
{
	public string Name => GetProperty("name").StringValue;

	public string Value => GetProperty("value").StringValue;

	public int Operator => GetProperty("operator").IntValue;

	public ApprSearchCriteriaAttribute(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
