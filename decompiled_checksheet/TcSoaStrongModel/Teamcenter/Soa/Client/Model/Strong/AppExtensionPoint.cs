using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AppExtensionPoint : BusinessElement
{
	public string Id => GetProperty("id").StringValue;

	public int Rule_type => GetProperty("rule_type").IntValue;

	public string Category => GetProperty("category").StringValue;

	public RBFInput[] Inputs
	{
		get
		{
			IList modelObjectListValue = GetProperty("inputs").ModelObjectListValue;
			RBFInput[] array = new RBFInput[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public RBFOutput[] Outputs
	{
		get
		{
			IList modelObjectListValue = GetProperty("outputs").ModelObjectListValue;
			RBFOutput[] array = new RBFOutput[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AppExtensionPoint(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
