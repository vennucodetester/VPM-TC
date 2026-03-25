namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccQuantity : AbsOccData
{
	public int Occ_flags => GetProperty("occ_flags").IntValue;

	public double Qty_value => GetProperty("qty_value").DoubleValue;

	public AbsOccQuantity(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
