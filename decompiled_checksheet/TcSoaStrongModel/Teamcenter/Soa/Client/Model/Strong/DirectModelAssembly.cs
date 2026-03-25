namespace Teamcenter.Soa.Client.Model.Strong;

public class DirectModelAssembly : Dataset
{
	public ModelObject[] IMAN_capture => GetProperty("IMAN_capture").ModelObjectArrayValue;

	public ModelObject[] Session => GetProperty("Session").ModelObjectArrayValue;

	public ModelObject[] _3DMarkup => GetProperty("3DMarkup").ModelObjectArrayValue;

	public DirectModelAssembly(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
