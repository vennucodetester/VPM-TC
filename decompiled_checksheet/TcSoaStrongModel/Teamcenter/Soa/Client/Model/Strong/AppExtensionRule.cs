using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AppExtensionRule : BusinessElement
{
	public string Id => GetProperty("id").StringValue;

	public AppExtensionRuleType Rule_type => (AppExtensionRuleType)GetProperty("rule_type").ModelObjectValue;

	public BusinessContext[] Contexts
	{
		get
		{
			IList modelObjectListValue = GetProperty("contexts").ModelObjectListValue;
			BusinessContext[] array = new BusinessContext[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public bool Secure => GetProperty("secure").BoolValue;

	public AppExtensionRule(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
