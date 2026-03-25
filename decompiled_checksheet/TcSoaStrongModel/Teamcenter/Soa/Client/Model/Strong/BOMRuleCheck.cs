namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMRuleCheck : RuntimeBusinessObject
{
	public string As_string => GetProperty("as_string").StringValue;

	public BOMRuleCheck(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
