namespace Teamcenter.Soa.Client.Model.Strong;

public class CMIDNum : POM_object
{
	public string Series_num => GetProperty("series_num").StringValue;

	public string Series_desc => GetProperty("series_desc").StringValue;

	public int Series_seq => GetProperty("series_seq").IntValue;

	public CMIDNum(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
