namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEResultRevMasterStore : CAERevMasterStore
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string Analysis_type => GetProperty("analysis_type").StringValue;

	public CAEResultRevMasterStore(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
