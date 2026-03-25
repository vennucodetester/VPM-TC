namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccUCC : AbsOccData
{
	public VariantExpressionBlock Ucc => (VariantExpressionBlock)GetProperty("ucc").ModelObjectValue;

	public AbsOccUCC(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
