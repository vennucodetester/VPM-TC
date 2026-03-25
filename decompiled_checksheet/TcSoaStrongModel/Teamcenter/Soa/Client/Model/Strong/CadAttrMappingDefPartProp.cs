namespace Teamcenter.Soa.Client.Model.Strong;

public class CadAttrMappingDefPartProp : CadAttrMappingDefPart
{
	public string Property_name => GetProperty("property_name").StringValue;

	public CadAttrMappingDefPartProp(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
