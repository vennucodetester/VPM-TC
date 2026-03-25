namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaProximity : ApprSearchCriteria
{
	public double Distance => GetProperty("distance").DoubleValue;

	public ApprSearchCriteriaSlctState Target_appearance => (ApprSearchCriteriaSlctState)GetProperty("target_appearance").ModelObjectValue;

	public ApprSearchCriteriaSlctState Background_appearance => (ApprSearchCriteriaSlctState)GetProperty("background_appearance").ModelObjectValue;

	public ApprSearchCriteriaProximity(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
