namespace Teamcenter.Soa.Client.Model.Strong;

public class BOMView : PSBOMView
{
	public ModelObject[] IMAN_external_object_link => GetProperty("IMAN_external_object_link").ModelObjectArrayValue;

	public BOMView(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
