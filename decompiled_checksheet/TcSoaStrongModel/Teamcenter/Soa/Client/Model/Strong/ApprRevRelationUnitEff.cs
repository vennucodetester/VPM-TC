namespace Teamcenter.Soa.Client.Model.Strong;

public class ApprRevRelationUnitEff : ApprRevRelation
{
	public int[] Unit_effectivity => GetProperty("unit_effectivity").IntArrayValue;

	public ApprRevRelationUnitEff(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
