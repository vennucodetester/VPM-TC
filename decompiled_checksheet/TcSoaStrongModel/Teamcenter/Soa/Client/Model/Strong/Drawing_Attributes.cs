namespace Teamcenter.Soa.Client.Model.Strong;

public class Drawing_Attributes : Form
{
	public string Page_Number => GetProperty("Page_Number").StringValue;

	public string Sheet_Number => GetProperty("Sheet_Number").StringValue;

	public string Change_Number => GetProperty("Change_Number").StringValue;

	public Drawing_Attributes(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
