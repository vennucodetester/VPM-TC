namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEModelRevMasterStore : CAERevMasterStore
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string[] Analysis_types => GetProperty("analysis_types").StringArrayValue;

	public CAEModelRevMasterStore(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
