namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEModelRevision_Master : CAERevision_Master
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string[] Analysis_types => GetProperty("analysis_types").StringArrayValue;

	public CAEModelRevision_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
