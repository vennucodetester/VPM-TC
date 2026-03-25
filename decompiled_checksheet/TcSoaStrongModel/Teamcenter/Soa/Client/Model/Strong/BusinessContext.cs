namespace Teamcenter.Soa.Client.Model.Strong;

public class BusinessContext : BusinessElement
{
	public ModelObject[] Accessor => GetProperty("accessor").ModelObjectArrayValue;

	public BusinessContext(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
