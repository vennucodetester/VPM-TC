namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteriaSavedQry : ApprSearchCriteria
{
	public string Name => GetProperty("name").StringValue;

	public string[] Entries => GetProperty("entries").StringArrayValue;

	public string[] Values => GetProperty("values").StringArrayValue;

	public ApprSearchCriteriaSavedQry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
