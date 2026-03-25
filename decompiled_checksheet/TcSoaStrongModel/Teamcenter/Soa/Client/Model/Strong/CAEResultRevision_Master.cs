namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEResultRevision_Master : CAERevision_Master
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string Analysis_type => GetProperty("analysis_type").StringValue;

	public CAEResultRevision_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
