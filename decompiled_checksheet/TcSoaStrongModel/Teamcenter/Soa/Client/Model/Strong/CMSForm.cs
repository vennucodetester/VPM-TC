namespace Teamcenter.Soa.Client.Model.Strong;

public class CMSForm : Form
{
	public string Series_num => GetProperty("series_num").StringValue;

	public string Series_desc => GetProperty("series_desc").StringValue;

	public int Series_seq => GetProperty("series_seq").IntValue;

	public CMSForm(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
