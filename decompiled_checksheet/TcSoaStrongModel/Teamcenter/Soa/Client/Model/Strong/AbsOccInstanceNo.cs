namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccInstanceNo : AbsOccData
{
	public int Instance_number => GetProperty("instance_number").IntValue;

	public AbsOccInstanceNo(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
