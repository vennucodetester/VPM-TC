namespace Teamcenter.Soa.Client.Model.Strong;

public class AM_privileges : POM_object
{
	public string Privilege_Name => GetProperty("Privilege_Name").StringValue;

	public int Privilege_Offset => GetProperty("Privilege_Offset").IntValue;

	public AM_privileges(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
