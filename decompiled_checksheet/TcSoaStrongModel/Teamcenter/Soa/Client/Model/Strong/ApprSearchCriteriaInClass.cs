namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaInClass : ApprSearchCriteria
{
	public ModelObject Ics_class => GetProperty("ics_class").ModelObjectValue;

	public int Ics_options => GetProperty("ics_options").IntValue;

	public int[] Uncts => GetProperty("uncts").IntArrayValue;

	public string[] Unct_values => GetProperty("unct_values").StringArrayValue;

	public ApprSearchCriteriaInClass(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
