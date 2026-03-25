namespace Teamcenter.Soa.Client.Model.Strong;

public class CAELoadItem_Master : Form
{
	public string Project_id => GetProperty("project_id").StringValue;

	public string Previous_version_id => GetProperty("previous_version_id").StringValue;

	public string Serial_number => GetProperty("serial_number").StringValue;

	public string Item_comment => GetProperty("item_comment").StringValue;

	public string User_data_1 => GetProperty("user_data_1").StringValue;

	public string User_data_2 => GetProperty("user_data_2").StringValue;

	public string User_data_3 => GetProperty("user_data_3").StringValue;

	public CAELoadItem_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
