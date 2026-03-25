namespace Teamcenter.Soa.Client.Model.Strong;

public class CadAttrMappingDefPartICS : CadAttrMappingDefPart
{
	public string Type_id => GetProperty("type_id").StringValue;

	public int Attr_id => GetProperty("attr_id").IntValue;

	public string Class_id => GetProperty("class_id").StringValue;

	public int Fnd0attr_vla => GetProperty("fnd0attr_vla").IntValue;

	public CadAttrMappingDefPartICS(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
