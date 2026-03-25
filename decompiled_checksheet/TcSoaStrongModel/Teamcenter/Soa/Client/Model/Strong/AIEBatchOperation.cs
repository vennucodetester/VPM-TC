namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEBatchOperation : POM_object
{
	public int Batch_kind => GetProperty("batch_kind").IntValue;

	public ModelObject Op_ref => GetProperty("op_ref").ModelObjectValue;

	public AIEBatchOperation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
