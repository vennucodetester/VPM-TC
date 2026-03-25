using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class ConditionSignature : POM_object
{
	public ConditionParameter[] Condition_parameters
	{
		get
		{
			IList modelObjectListValue = GetProperty("condition_parameters").ModelObjectListValue;
			ConditionParameter[] array = new ConditionParameter[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ConditionSignature(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
