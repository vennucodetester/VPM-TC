namespace Teamcenter.Soa.Client.Model.Strong;

public class AssemblyArrangementAnchor : POM_object
{
	public string External_uid => GetProperty("external_uid").StringValue;

	public AssemblyArrangementAnchor(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
