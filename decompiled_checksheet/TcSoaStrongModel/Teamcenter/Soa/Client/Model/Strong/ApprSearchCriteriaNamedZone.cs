namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaNamedZone : ApprSearchCriteria
{
	public string Name => GetProperty("name").StringValue;

	public int Operator => GetProperty("operator").IntValue;

	public ApprSearchCriteriaNamedZone(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
