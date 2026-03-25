namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprSearchCriteria : POM_object
{
	public string Type => GetProperty("type").StringValue;

	public bool Fnd0_tso_flag => GetProperty("fnd0_tso_flag").BoolValue;

	public ApprSearchCriteria(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
