namespace Teamcenter.Soa.Client.Model.Strong;

public class AuditLog : POM_application_object
{
	public string Name => GetProperty("name").StringValue;

	public AuditLog(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
