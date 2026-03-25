namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccPosRef : AbsOccData
{
	public string Logical_pos => GetProperty("logical_pos").StringValue;

	public AbsOccPosRef(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
