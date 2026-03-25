namespace Teamcenter.Soa.Client.Model.Strong;

public class CPMarketingBriefRevision : CPBriefRevision
{
	public string Competition => GetProperty("competition").StringValue;

	public string Region => GetProperty("region").StringValue;

	public string Currency => GetProperty("currency").StringValue;

	public double Target_cost => GetProperty("target_cost").DoubleValue;

	public string Primary_contact_person => GetProperty("primary_contact_person").StringValue;

	public ModelObject[] CP_Has_ThemeBoard => GetProperty("CP_Has_ThemeBoard").ModelObjectArrayValue;

	public CPMarketingBriefRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
