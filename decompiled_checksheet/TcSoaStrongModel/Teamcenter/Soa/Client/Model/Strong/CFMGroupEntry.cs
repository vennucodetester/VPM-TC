using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMGroupEntry : CFMRuleEntry
{
	public CFMRuleEntry[] Sub_entries
	{
		get
		{
			IList modelObjectListValue = GetProperty("sub_entries").ModelObjectListValue;
			CFMRuleEntry[] array = new CFMRuleEntry[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public CFMGroupEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
