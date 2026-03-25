namespace Teamcenter.Soa.Client.Model.Strong;

public class CPRForm : Form
{
	public string Cm_reason => GetProperty("cm_reason").StringValue;

	public string Cm_reason_desc => GetProperty("cm_reason_desc").StringValue;

	public string Cm_desc => GetProperty("cm_desc").StringValue;

	public string Rev_state => GetProperty("rev_state").StringValue;

	public string Cm_sub_by => GetProperty("cm_sub_by").StringValue;

	public string Cm_sub_on => GetProperty("cm_sub_on").StringValue;

	public string Rev_charge => GetProperty("rev_charge").StringValue;

	public CPRForm(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
