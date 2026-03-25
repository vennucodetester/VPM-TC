namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccSeqNo : AbsOccData
{
	public string Seq_no => GetProperty("seq_no").StringValue;

	public AbsOccSeqNo(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
