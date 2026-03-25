namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprHistoryUnitNoEntry : ApprHistoryEntry
{
	public int In_unit_no => GetProperty("in_unit_no").IntValue;

	public int Out_unit_no => GetProperty("out_unit_no").IntValue;

	public ApprHistoryUnitNoEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
