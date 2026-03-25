namespace Teamcenter.Soa.Client.Model.Strong;

public class CFMWorkingEntry : CFMRuleEntry
{
	public bool Current_user => GetProperty("current_user").BoolValue;

	public bool Current_group => GetProperty("current_group").BoolValue;

	public Group Group_tag => (Group)GetProperty("group_tag").ModelObjectValue;

	public User User_tag => (User)GetProperty("user_tag").ModelObjectValue;

	public CFMWorkingEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
