namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEAnalysisRevision : CAEItemRevision
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string Analysis_type => GetProperty("analysis_type").StringValue;

	public string Solution_type => GetProperty("solution_type").StringValue;

	public string Solution_step => GetProperty("solution_step").StringValue;

	public ModelObject[] Fnd0ObjectCheckStatusRel => GetProperty("Fnd0ObjectCheckStatusRel").ModelObjectArrayValue;

	public CAEAnalysisRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
