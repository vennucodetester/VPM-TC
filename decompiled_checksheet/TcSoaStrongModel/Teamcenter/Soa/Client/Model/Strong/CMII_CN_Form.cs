namespace Teamcenter.Soa.Client.Model.Strong;

public class CMII_CN_Form : Form
{
	public string Cn_priority => GetProperty("cn_priority").StringValue;

	public string Fast_track => GetProperty("fast_track").StringValue;

	public string Spec_instr => GetProperty("spec_instr").StringValue;

	public ModelObject Change_rev => GetProperty("change_rev").ModelObjectValue;

	public CMII_CN_Form(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
