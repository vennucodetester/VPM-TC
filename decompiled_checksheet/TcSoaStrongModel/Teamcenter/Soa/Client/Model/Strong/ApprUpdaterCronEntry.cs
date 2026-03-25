namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprUpdaterCronEntry : POM_object
{
	public string Machine => GetProperty("machine").StringValue;

	public string Osuser => GetProperty("osuser").StringValue;

	public string Minute => GetProperty("minute").StringValue;

	public string Hour => GetProperty("hour").StringValue;

	public string Day_of_month => GetProperty("day_of_month").StringValue;

	public string Month_of_year => GetProperty("month_of_year").StringValue;

	public string Day_of_week => GetProperty("day_of_week").StringValue;

	public ApprUpdaterCronEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
