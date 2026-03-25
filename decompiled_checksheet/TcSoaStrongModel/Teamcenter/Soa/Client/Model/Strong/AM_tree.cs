namespace Teamcenter.Soa.Client.Model.Strong;

public class AM_tree : POM_object
{
	public string Rule_name => GetProperty("rule_name").StringValue;

	public string Rule_arg => GetProperty("rule_arg").StringValue;

	public AM_tree Parent => (AM_tree)GetProperty("parent").ModelObjectValue;

	public AM_tree Prev => (AM_tree)GetProperty("prev").ModelObjectValue;

	public bool Edit_children => GetProperty("edit_children").BoolValue;

	public bool Expand_below => GetProperty("expand_below").BoolValue;

	public bool Cut => GetProperty("cut").BoolValue;

	public AM_ACL Acl => (AM_ACL)GetProperty("acl").ModelObjectValue;

	public AM_tree(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
