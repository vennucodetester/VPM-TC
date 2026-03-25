namespace Teamcenter.Soa.Client.Model.Strong;

public class CadAttrMappingDefPartGRM : CadAttrMappingDefPart
{
	public string Relationship_name => GetProperty("relationship_name").StringValue;

	public string Type_name => GetProperty("type_name").StringValue;

	public CadAttrMappingDefPartGRM(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
