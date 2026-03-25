namespace Teamcenter.Soa.Client.Model.Strong;

public class AllocationWindow : RuntimeBusinessObject
{
	public bool Allocation_window_icm_flag => GetProperty("allocation_window_icm_flag").BoolValue;

	public ModelObject Allocation_window_icrev => GetProperty("allocation_window_icrev").ModelObjectValue;

	public ModelObject Allocation_window_revrule => GetProperty("allocation_window_revrule").ModelObjectValue;

	public ModelObject Allocation_window_context => GetProperty("allocation_window_context").ModelObjectValue;

	public AllocationWindow(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
