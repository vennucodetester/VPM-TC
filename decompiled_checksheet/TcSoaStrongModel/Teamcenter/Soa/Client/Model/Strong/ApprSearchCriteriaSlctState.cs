using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaSlctState : ApprSearchCriteria
{
	public MEAppearancePathNode[] Selected_meapprpathnodes
	{
		get
		{
			IList modelObjectListValue = GetProperty("selected_meapprpathnodes").ModelObjectListValue;
			MEAppearancePathNode[] array = new MEAppearancePathNode[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public MEAppearancePathNode[] Unselected_meapprpathnodes
	{
		get
		{
			IList modelObjectListValue = GetProperty("unselected_meapprpathnodes").ModelObjectListValue;
			MEAppearancePathNode[] array = new MEAppearancePathNode[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public string[] Fnd0selected_occ_list => GetProperty("fnd0selected_occ_list").StringArrayValue;

	public string[] Fnd0unselected_occ_list => GetProperty("fnd0unselected_occ_list").StringArrayValue;

	public ApprSearchCriteriaSlctState(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
