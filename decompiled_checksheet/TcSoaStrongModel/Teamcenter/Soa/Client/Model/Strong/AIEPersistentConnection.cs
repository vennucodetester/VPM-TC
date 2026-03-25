using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEPersistentConnection : AIEConnection
{
	public AIEBatchOperation[] Batch_refs
	{
		get
		{
			IList modelObjectListValue = GetProperty("batch_refs").ModelObjectListValue;
			AIEBatchOperation[] array = new AIEBatchOperation[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AIEPersistentConnection(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
