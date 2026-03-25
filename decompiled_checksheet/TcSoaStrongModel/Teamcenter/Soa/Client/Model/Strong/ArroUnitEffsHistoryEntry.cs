namespace Teamcenter.Soa.Client.Model.Strong;

public class ArroUnitEffsHistoryEntry : ArroHistoryEntry
{
	public int[] Unit_effectivities => GetProperty("unit_effectivities").IntArrayValue;

	public ArroUnitEffsHistoryEntry(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
