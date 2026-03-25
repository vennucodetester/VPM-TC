namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccFlags : AbsOccData
{
	public int Flag => GetProperty("flag").IntValue;

	public int Flag_mask => GetProperty("flag_mask").IntValue;

	public AbsOccFlags(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
