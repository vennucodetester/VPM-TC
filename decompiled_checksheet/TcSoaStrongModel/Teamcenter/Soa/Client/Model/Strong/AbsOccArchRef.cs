namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccArchRef : AbsOccData
{
	public string Arch_type => GetProperty("arch_type").StringValue;

	public string Arch_elem_id => GetProperty("arch_elem_id").StringValue;

	public AbsOccArchRef(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
