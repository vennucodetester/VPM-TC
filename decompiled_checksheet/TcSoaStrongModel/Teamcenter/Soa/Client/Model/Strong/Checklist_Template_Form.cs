namespace Teamcenter.Soa.Client.Model.Strong;

public class Checklist_Template_Form : Form
{
	public string Eco_prepare => GetProperty("eco_prepare").StringValue;

	public string Cost_calc => GetProperty("cost_calc").StringValue;

	public string Weight_calc => GetProperty("weight_calc").StringValue;

	public string Eng_estimate => GetProperty("eng_estimate").StringValue;

	public Checklist_Template_Form(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
