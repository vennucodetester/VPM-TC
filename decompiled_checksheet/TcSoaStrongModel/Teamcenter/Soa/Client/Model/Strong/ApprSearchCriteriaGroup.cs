using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaGroup : ApprSearchCriteria
{
	public int Operator => GetProperty("operator").IntValue;

	public ApprSearchCriteria[] Sub_criteria
	{
		get
		{
			IList modelObjectListValue = GetProperty("sub_criteria").ModelObjectListValue;
			ApprSearchCriteria[] array = new ApprSearchCriteria[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ApprSearchCriteriaGroup(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
