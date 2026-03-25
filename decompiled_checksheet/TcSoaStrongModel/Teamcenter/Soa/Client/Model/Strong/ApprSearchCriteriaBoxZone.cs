namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaBoxZone : ApprSearchCriteria
{
	public double[] Coordinates => GetProperty("coordinates").DoubleArrayValue;

	public int Operator => GetProperty("operator").IntValue;

	public ApprSearchCriteriaBoxZone(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
