namespace Teamcenter.Soa.Client.Model.Strong;

public class Bitmap : Dataset
{
	public ModelObject[] DMI_markup => GetProperty("DMI_markup").ModelObjectArrayValue;

	public Bitmap(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
