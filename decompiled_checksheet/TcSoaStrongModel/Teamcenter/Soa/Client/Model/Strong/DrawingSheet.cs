namespace Teamcenter.Soa.Client.Model.Strong;

public class DrawingSheet : Dataset
{
	public ModelObject[] Session => GetProperty("Session").ModelObjectArrayValue;

	public ModelObject[] DMI_markup => GetProperty("DMI_markup").ModelObjectArrayValue;

	public DrawingSheet(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
