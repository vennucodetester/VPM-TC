namespace Teamcenter.Soa.Client.Model.Strong;

public class DirectModel : Dataset
{
	public ModelObject[] IMAN_capture => GetProperty("IMAN_capture").ModelObjectArrayValue;

	public ModelObject[] Session => GetProperty("Session").ModelObjectArrayValue;

	public ModelObject[] DMI_markup => GetProperty("DMI_markup").ModelObjectArrayValue;

	public ModelObject[] _3DMarkup => GetProperty("3DMarkup").ModelObjectArrayValue;

	public DirectModel(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
