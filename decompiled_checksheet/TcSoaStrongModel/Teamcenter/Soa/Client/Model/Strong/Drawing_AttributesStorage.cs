namespace Teamcenter.Soa.Client.Model.Strong;

public class Drawing_AttributesStorage : POM_object
{
	public string Page_Number => GetProperty("Page_Number").StringValue;

	public string Sheet_Number => GetProperty("Sheet_Number").StringValue;

	public string Change_Number => GetProperty("Change_Number").StringValue;

	public Drawing_AttributesStorage(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
