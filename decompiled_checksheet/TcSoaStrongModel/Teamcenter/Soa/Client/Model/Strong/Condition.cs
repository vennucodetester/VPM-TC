using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class Condition : POM_object
{
	public string Condition_name => GetProperty("condition_name").StringValue;

	public string Condition_desc => GetProperty("condition_desc").StringValue;

	public ConditionParameter[] Parameters
	{
		get
		{
			IList modelObjectListValue = GetProperty("parameters").ModelObjectListValue;
			ConditionParameter[] array = new ConditionParameter[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public string Expression => GetProperty("expression").StringValue;

	public bool Secure_flag => GetProperty("secure_flag").BoolValue;

	public Condition(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
