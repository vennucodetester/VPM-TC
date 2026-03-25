namespace Teamcenter.Soa.Client.Model.Strong;

public class DirectModelMarkup : Dataset
{
	public ModelObject[] Session => GetProperty("Session").ModelObjectArrayValue;

	public DirectModelMarkup(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
