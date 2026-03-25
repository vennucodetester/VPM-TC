namespace Teamcenter.Soa.Client.Model.Strong;

public class BillRate : WorkspaceObject
{
	public int Tc_type => GetProperty("tc_type").IntValue;

	public CostValue Costvalue_form_tag => (CostValue)GetProperty("costvalue_form_tag").ModelObjectValue;

	public BillRate(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
