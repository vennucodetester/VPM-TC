namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdaterAuditRecord : POM_object
{
	public string Info => GetProperty("info").StringValue;

	public ApprUpdaterAuditRecord(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
