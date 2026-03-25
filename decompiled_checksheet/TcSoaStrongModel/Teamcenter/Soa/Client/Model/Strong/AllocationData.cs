namespace Teamcenter.Soa.Client.Model.Strong;

public class AllocationData : POM_object
{
	public ModelObject[] ChangeSourceList => GetProperty("changeSourceList").ModelObjectArrayValue;

	public ModelObject[] ChangeTargetList => GetProperty("changeTargetList").ModelObjectArrayValue;

	public ModelObject ChangeCondition => GetProperty("changeCondition").ModelObjectValue;

	public string ChangeReason => GetProperty("changeReason").StringValue;

	public int ChangeType => GetProperty("changeType").IntValue;

	public Allocation AllocationTag => (Allocation)GetProperty("allocationTag").ModelObjectValue;

	public string Object_type => GetProperty("object_type").StringValue;

	public string Absocc_attr_name => GetProperty("absocc_attr_name").StringValue;

	public AllocationData(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
