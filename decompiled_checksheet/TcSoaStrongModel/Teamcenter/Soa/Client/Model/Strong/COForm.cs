namespace Teamcenter.Soa.Client.Model.Strong;

public class COForm : Form
{
	public string Cm_reason => GetProperty("cm_reason").StringValue;

	public string Cm_reason_desc => GetProperty("cm_reason_desc").StringValue;

	public string Cm_desc => GetProperty("cm_desc").StringValue;

	public string Co_state => GetProperty("co_state").StringValue;

	public string Cm_sub_by => GetProperty("cm_sub_by").StringValue;

	public string Cm_sub_on => GetProperty("cm_sub_on").StringValue;

	public string Rev_charge => GetProperty("rev_charge").StringValue;

	public COForm(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
