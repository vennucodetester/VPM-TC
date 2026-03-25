namespace Teamcenter.Soa.Client.Model.Strong;

public class CadAttrMappingDefPartSNoff : CadAttrMappingDefPart
{
	public string Role_name => GetProperty("role_name").StringValue;

	public string Level_name => GetProperty("level_name").StringValue;

	public CadAttrMappingDefPartSNoff(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
