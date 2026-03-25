namespace Teamcenter.Soa.Client.Model.Strong;

public class CAE_AIF_Form : Form
{
	public string Solver_name => GetProperty("solver_name").StringValue;

	public string Analysis_type => GetProperty("analysis_type").StringValue;

	public string Solution_type => GetProperty("solution_type").StringValue;

	public string Solution_step => GetProperty("solution_step").StringValue;

	public string Version_name => GetProperty("version_name").StringValue;

	public ModelObject Owner_form_obj => GetProperty("owner_form_obj").ModelObjectValue;

	public string Project_id => GetProperty("project_id").StringValue;

	public string Previous_version_id => GetProperty("previous_version_id").StringValue;

	public string Serial_number => GetProperty("serial_number").StringValue;

	public string Item_comment => GetProperty("item_comment").StringValue;

	public string User_data_1 => GetProperty("user_data_1").StringValue;

	public string User_data_2 => GetProperty("user_data_2").StringValue;

	public string User_data_3 => GetProperty("user_data_3").StringValue;

	public CAE_AIF_Form(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
