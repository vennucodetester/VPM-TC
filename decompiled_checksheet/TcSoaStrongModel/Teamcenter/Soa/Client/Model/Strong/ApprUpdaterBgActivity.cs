using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdaterBgActivity : POM_object
{
	public int Process_id => GetProperty("process_id").IntValue;

	public string Machine => GetProperty("machine").StringValue;

	public ModelObject Package => GetProperty("package").ModelObjectValue;

	public int Stage => GetProperty("stage").IntValue;

	public DateTime When => GetProperty("when").DateValue;

	public int Ifail => GetProperty("ifail").IntValue;

	public ApprUpdaterAuditRecord Audit_record => (ApprUpdaterAuditRecord)GetProperty("audit_record").ModelObjectValue;

	public ApprUpdaterBgActivity(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
