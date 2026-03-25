namespace Teamcenter.Soa.Client.Model.Strong;

public class AssemblyArrangement : WorkspaceObject
{
	public string External_uid => GetProperty("external_uid").StringValue;

	public AssemblyArrangementAnchor Arrangement_anchor => (AssemblyArrangementAnchor)GetProperty("arrangement_anchor").ModelObjectValue;

	public AssemblyArrangement(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
