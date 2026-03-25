namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMStatusEntry : CFMRuleEntry
{
	public int Date_type => GetProperty("date_type").IntValue;

	public TaskType Status_type => (TaskType)GetProperty("status_type").ModelObjectValue;

	public CFMStatusEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
