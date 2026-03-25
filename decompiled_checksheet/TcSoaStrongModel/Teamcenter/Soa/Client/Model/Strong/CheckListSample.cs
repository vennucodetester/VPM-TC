namespace Teamcenter.Soa.Client.Model.Strong;

public class CheckListSample : POM_object
{
	public string Eco_prepare => GetProperty("eco_prepare").StringValue;

	public string Cost_calc => GetProperty("cost_calc").StringValue;

	public string Weight_calc => GetProperty("weight_calc").StringValue;

	public string Eng_estimate => GetProperty("eng_estimate").StringValue;

	public CheckListSample(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
