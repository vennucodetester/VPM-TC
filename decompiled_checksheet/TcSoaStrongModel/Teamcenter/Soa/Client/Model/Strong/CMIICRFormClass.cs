namespace Teamcenter.Soa.Client.Model.Strong;

public class CMIICRFormClass : POM_object
{
	public string Cr_type => GetProperty("cr_type").StringValue;

	public string Cr_priority => GetProperty("cr_priority").StringValue;

	public string Department => GetProperty("department").StringValue;

	public string Fast_track => GetProperty("fast_track").StringValue;

	public string Impl_time => GetProperty("impl_time").StringValue;

	public string Tr_priority => GetProperty("tr_priority").StringValue;

	public string Prop_soln => GetProperty("prop_soln").StringValue;

	public string Tr_result => GetProperty("tr_result").StringValue;

	public double Rec_cost => GetProperty("rec_cost").DoubleValue;

	public double Non_rec_cost => GetProperty("non_rec_cost").DoubleValue;

	public ModelObject Change_rev => GetProperty("change_rev").ModelObjectValue;

	public CMIICRFormClass(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
