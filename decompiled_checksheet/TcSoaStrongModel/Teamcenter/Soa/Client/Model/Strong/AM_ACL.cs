namespace Teamcenter.Soa.Client.Model.Strong;

public class AM_ACL : POM_object
{
	public string ACL_Name => GetProperty("ACL_Name").StringValue;

	public bool Acl_loaded => GetProperty("acl_loaded").BoolValue;

	public ModelObject[] ACE_Ids => GetProperty("ACE_Ids").ModelObjectArrayValue;

	public ModelObject[] ACE_Ids_togo => GetProperty("ACE_Ids_togo").ModelObjectArrayValue;

	public string ACL_Flag => GetProperty("ACL_Flag").StringValue;

	public AM_ACL(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
