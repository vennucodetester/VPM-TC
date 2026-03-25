namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEAnalysisRevision_Master : CAERevision_Master
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string Analysis_type => GetProperty("analysis_type").StringValue;

	public string Solution_type => GetProperty("solution_type").StringValue;

	public string Solution_step => GetProperty("solution_step").StringValue;

	public string Version_name => GetProperty("version_name").StringValue;

	public ModelObject Owner_form_obj => GetProperty("owner_form_obj").ModelObjectValue;

	public CAEAnalysisRevision_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
