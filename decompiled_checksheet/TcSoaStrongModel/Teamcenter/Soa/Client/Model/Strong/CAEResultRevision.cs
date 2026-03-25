namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEResultRevision : CAEItemRevision
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string Analysis_type => GetProperty("analysis_type").StringValue;

	public CAEResultRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
