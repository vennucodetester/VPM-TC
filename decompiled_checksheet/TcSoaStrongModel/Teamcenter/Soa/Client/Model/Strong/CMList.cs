namespace Teamcenter.Soa.Client.Model.Strong;

public class CMList : POM_object
{
	public string List_name => GetProperty("list_name").StringValue;

	public string[] List_code => GetProperty("list_code").StringArrayValue;

	public string[] List_text => GetProperty("list_text").StringArrayValue;

	public CMList(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
