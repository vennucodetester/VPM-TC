namespace Teamcenter.Soa.Client.Model.Strong;

public class Architecture : Item
{
	public string Generic_component_id => GetProperty("generic_component_id").StringValue;

	public bool Has_shared_nves => GetProperty("has_shared_nves").BoolValue;

	public bool Has_consistent_nves => GetProperty("has_consistent_nves").BoolValue;

	public bool Is_partial_breakdown => GetProperty("is_partial_breakdown").BoolValue;

	public bool Has_hierarchical_variabilty => GetProperty("has_hierarchical_variabilty").BoolValue;

	public bool Has_basedon_preexist_elemnt => GetProperty("has_basedon_preexist_elemnt").BoolValue;

	public Architecture Instantiating_arch => (Architecture)GetProperty("instantiating_arch").ModelObjectValue;

	public VariantExpressionBlock Var_exp_block => (VariantExpressionBlock)GetProperty("var_exp_block").ModelObjectValue;

	public Architecture(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
