namespace Teamcenter.Soa.Client.Model.Strong;

public class DLF_Attribute_Form : Form
{
	public double Dlf_i_value => GetProperty("Dlf_i_value").DoubleValue;

	public double Dlf_j_value => GetProperty("Dlf_j_value").DoubleValue;

	public double Dlf_k_value => GetProperty("Dlf_k_value").DoubleValue;

	public string Type => GetProperty("Type").StringValue;

	public string Section_plane_name => GetProperty("Section_plane_name").StringValue;

	public string Id => GetProperty("Id").StringValue;

	public string Control_direction => GetProperty("Control_direction").StringValue;

	public bool Fixed_location => GetProperty("Fixed_location").BoolValue;

	public bool Mature => GetProperty("Mature").BoolValue;

	public string Direction_of_check => GetProperty("Direction_of_check").StringValue;

	public string Body_section_line => GetProperty("Body_section_line").StringValue;

	public string Connected_part_1 => GetProperty("Connected_part_1").StringValue;

	public string Connected_part_2 => GetProperty("Connected_part_2").StringValue;

	public string Connected_part_3 => GetProperty("Connected_part_3").StringValue;

	public string Connected_part_4 => GetProperty("Connected_part_4").StringValue;

	public string Connected_part_5 => GetProperty("Connected_part_5").StringValue;

	public string Connected_part_6 => GetProperty("Connected_part_6").StringValue;

	public string Connected_part_7 => GetProperty("Connected_part_7").StringValue;

	public string Connected_part_8 => GetProperty("Connected_part_8").StringValue;

	public string Connected_part_9 => GetProperty("Connected_part_9").StringValue;

	public double Mfg0CSYS_i_value => GetProperty("Mfg0CSYS_i_value").DoubleValue;

	public double Mfg0CSYS_j_value => GetProperty("Mfg0CSYS_j_value").DoubleValue;

	public double Mfg0CSYS_k_value => GetProperty("Mfg0CSYS_k_value").DoubleValue;

	public string Mfg0Datum_Type => GetProperty("Mfg0Datum_Type").StringValue;

	public string Mfg0Major_cntl_coordinate => GetProperty("Mfg0Major_cntl_coordinate").StringValue;

	public double Mfg0x_pos => GetProperty("Mfg0x_pos").DoubleValue;

	public double Mfg0y_pos => GetProperty("Mfg0y_pos").DoubleValue;

	public double Mfg0z_pos => GetProperty("Mfg0z_pos").DoubleValue;

	public bool Mfg0cntrl_i_direction => GetProperty("Mfg0cntrl_i_direction").BoolValue;

	public bool Mfg0cntrl_j_direction => GetProperty("Mfg0cntrl_j_direction").BoolValue;

	public bool Mfg0cntrl_k_direction => GetProperty("Mfg0cntrl_k_direction").BoolValue;

	public DLF_Attribute_Form(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
