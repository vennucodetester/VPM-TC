namespace Teamcenter.Soa.Client.Model.Strong;

public class AuthorizationRule : BusinessRule
{
	public string Name => GetProperty("name").StringValue;

	public string Rule_domain => GetProperty("rule_domain").StringValue;

	public ModelObject[] Accessor_list => GetProperty("accessor_list").ModelObjectArrayValue;

	public AuthorizationRule(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
