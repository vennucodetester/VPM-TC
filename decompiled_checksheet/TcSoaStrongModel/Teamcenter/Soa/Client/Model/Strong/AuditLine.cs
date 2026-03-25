namespace Teamcenter.Soa.Client.Model.Strong;

public class AuditLine : RuntimeBusinessObject
{
	public ModelObject Matched_lines => GetProperty("matched_lines").ModelObjectValue;

	public ModelObject Audited_line => GetProperty("audited_line").ModelObjectValue;

	public AuditLine(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
