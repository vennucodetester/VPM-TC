namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaPlaneZone : ApprSearchCriteria
{
	public double[] Coordinates => GetProperty("coordinates").DoubleArrayValue;

	public int Operator => GetProperty("operator").IntValue;

	public ApprSearchCriteriaPlaneZone(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
