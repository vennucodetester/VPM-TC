namespace Teamcenter.Soa.Client.Model.Strong;

public class CAESolution : Dataset
{
	public ModelObject[] IMAN_UG_promotion => GetProperty("IMAN_UG_promotion").ModelObjectArrayValue;

	public ModelObject[] IMAN_UG_wave_geometry => GetProperty("IMAN_UG_wave_geometry").ModelObjectArrayValue;

	public ModelObject[] IMAN_UG_wave_part_link => GetProperty("IMAN_UG_wave_part_link").ModelObjectArrayValue;

	public ModelObject[] IMAN_UG_wave_position => GetProperty("IMAN_UG_wave_position").ModelObjectArrayValue;

	public ModelObject[] IMAN_UG_expression => GetProperty("IMAN_UG_expression").ModelObjectArrayValue;

	public CAESolution(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
