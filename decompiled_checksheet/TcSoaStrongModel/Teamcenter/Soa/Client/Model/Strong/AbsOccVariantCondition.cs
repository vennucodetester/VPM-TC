namespace Teamcenter.Soa.Client.Model.Strong;

public class AbsOccVariantCondition : AbsOccData
{
	public VariantExpressionBlock Variant_condition => (VariantExpressionBlock)GetProperty("variant_condition").ModelObjectValue;

	public AbsOccVariantCondition(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
