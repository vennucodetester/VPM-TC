namespace Teamcenter.Soa.Client.Model.Strong;

public class Drawing_Revision_Master : Form
{
	public string Drawing_Type => GetProperty("Drawing_Type").StringValue;

	public Drawing_Revision_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
