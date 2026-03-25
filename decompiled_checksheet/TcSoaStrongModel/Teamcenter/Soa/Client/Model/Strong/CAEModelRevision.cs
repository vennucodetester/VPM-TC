namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEModelRevision : CAEItemRevision
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string[] Analysis_types => GetProperty("analysis_types").StringArrayValue;

	public ModelObject[] Fnd0CAE_TargetOccurrence => GetProperty("Fnd0CAE_TargetOccurrence").ModelObjectArrayValue;

	public ModelObject[] Fnd0ObjectCheckStatusRel => GetProperty("Fnd0ObjectCheckStatusRel").ModelObjectArrayValue;

	public CAEModelRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
