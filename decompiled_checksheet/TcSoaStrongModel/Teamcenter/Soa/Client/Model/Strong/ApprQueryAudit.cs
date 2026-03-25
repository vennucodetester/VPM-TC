using System;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprQueryAudit : POM_object
{
	public DateTime Start_date => GetProperty("start_date").DateValue;

	public DateTime End_date => GetProperty("end_date").DateValue;

	public int Start_unit_no => GetProperty("start_unit_no").IntValue;

	public int End_unit_no => GetProperty("end_unit_no").IntValue;

	public DateTime Last_worthiness_update_date => GetProperty("last_worthiness_update_date").DateValue;

	public double Validation_worthiness => GetProperty("validation_worthiness").DoubleValue;

	public int Count => GetProperty("count").IntValue;

	public AppearanceRoot Appearance_root => (AppearanceRoot)GetProperty("appearance_root").ModelObjectValue;

	public ApprQueryAudit(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
