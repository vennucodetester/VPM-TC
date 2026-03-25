namespace Teamcenter.Soa.Client.Model.Strong;

public class ChangeNotificationData : POM_object
{
	public string Cm_reason => GetProperty("cm_reason").StringValue;

	public string Cm_reason_desc => GetProperty("cm_reason_desc").StringValue;

	public string Cm_desc => GetProperty("cm_desc").StringValue;

	public string Cn_state => GetProperty("cn_state").StringValue;

	public ChangeNotificationData(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
