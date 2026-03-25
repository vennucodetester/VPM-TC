namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMEndItemEntry : CFMRuleEntry
{
	public ModelObject End_item => GetProperty("end_item").ModelObjectValue;

	public CFMEndItemEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
