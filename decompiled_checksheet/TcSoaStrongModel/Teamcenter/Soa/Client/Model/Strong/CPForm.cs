namespace Teamcenter.Soa.Client.Model.Strong;

public class CPForm : Form
{
	public string Cm_reason => GetProperty("cm_reason").StringValue;

	public string Cm_reason_desc => GetProperty("cm_reason_desc").StringValue;

	public string Cm_desc => GetProperty("cm_desc").StringValue;

	public string Cp_name => GetProperty("cp_name").StringValue;

	public string Cp_state => GetProperty("cp_state").StringValue;

	public string Cm_sub_by => GetProperty("cm_sub_by").StringValue;

	public string Cm_sub_on => GetProperty("cm_sub_on").StringValue;

	public CPForm(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
