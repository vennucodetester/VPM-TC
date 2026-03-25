namespace Teamcenter.Soa.Client.Model.Strong;

public class ArcWeld_Attribute_Form : Form
{
	public string Id => GetProperty("Id").StringValue;

	public string Weld_type => GetProperty("Weld_type").StringValue;

	public string Setup => GetProperty("Setup").StringValue;

	public string Contour => GetProperty("Contour").StringValue;

	public string Method => GetProperty("Method").StringValue;

	public string Process => GetProperty("Process").StringValue;

	public string Group_id => GetProperty("Group_id").StringValue;

	public string Weld_length => GetProperty("Weld_length").StringValue;

	public string Weld_volume => GetProperty("Weld_volume").StringValue;

	public string First_leg => GetProperty("First_leg").StringValue;

	public string Second_leg => GetProperty("Second_leg").StringValue;

	public string Output_type => GetProperty("Output_type").StringValue;

	public string Connected_part_1 => GetProperty("Connected_part_1").StringValue;

	public string Connected_part_2 => GetProperty("Connected_part_2").StringValue;

	public string Connected_part_3 => GetProperty("Connected_part_3").StringValue;

	public string Connected_part_4 => GetProperty("Connected_part_4").StringValue;

	public string Connected_part_5 => GetProperty("Connected_part_5").StringValue;

	public string Connected_part_6 => GetProperty("Connected_part_6").StringValue;

	public string Connected_part_7 => GetProperty("Connected_part_7").StringValue;

	public string Connected_part_8 => GetProperty("Connected_part_8").StringValue;

	public string Connected_part_9 => GetProperty("Connected_part_9").StringValue;

	public string Root_opening => GetProperty("Root_opening").StringValue;

	public string Root_penetration => GetProperty("Root_penetration").StringValue;

	public string Penetration_depth_1 => GetProperty("Penetration_depth_1").StringValue;

	public string Contour_height_1 => GetProperty("Contour_height_1").StringValue;

	public string Height => GetProperty("Height").StringValue;

	public string Depth => GetProperty("Depth").StringValue;

	public string Plug_diameter => GetProperty("Plug_diameter").StringValue;

	public string Size => GetProperty("Size").StringValue;

	public string Groove_angle => GetProperty("Groove_angle").StringValue;

	public string Groove_radius => GetProperty("Groove_radius").StringValue;

	public ArcWeld_Attribute_Form(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
