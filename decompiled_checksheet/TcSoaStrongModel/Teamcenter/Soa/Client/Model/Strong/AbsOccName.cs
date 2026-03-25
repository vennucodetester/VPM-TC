namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccName : AbsOccData
{
	public string Occ_name => GetProperty("occ_name").StringValue;

	public AbsOccName(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
