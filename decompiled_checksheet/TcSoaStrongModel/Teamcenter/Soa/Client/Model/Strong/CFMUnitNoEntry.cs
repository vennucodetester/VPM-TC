namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMUnitNoEntry : CFMRuleEntry
{
	public int Unit_no => GetProperty("unit_no").IntValue;

	public CFMUnitNoEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
