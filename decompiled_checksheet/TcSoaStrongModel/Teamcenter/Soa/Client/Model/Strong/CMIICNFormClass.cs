namespace Teamcenter.Soa.Client.Model.Strong;

public class CMIICNFormClass : POM_object
{
	public string Cn_priority => GetProperty("cn_priority").StringValue;

	public string Fast_track => GetProperty("fast_track").StringValue;

	public string Spec_instr => GetProperty("spec_instr").StringValue;

	public ModelObject Change_rev => GetProperty("change_rev").ModelObjectValue;

	public CMIICNFormClass(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
