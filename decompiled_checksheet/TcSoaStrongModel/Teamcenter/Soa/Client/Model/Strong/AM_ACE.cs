namespace Teamcenter.Soa.Client.Model.Strong;

public class AM_ACE : POM_object
{
	public ModelObject Accessor_id => GetProperty("Accessor_id").ModelObjectValue;

	public string Protection_id => GetProperty("Protection_id").StringValue;

	public AM_ACL ACL_id => (AM_ACL)GetProperty("ACL_id").ModelObjectValue;

	public AM_ACE(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
