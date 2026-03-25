using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class BMOperation : BusinessRule
{
	public string Operation_name => GetProperty("operation_name").StringValue;

	public ExtensionPoint[] Extensionpoints
	{
		get
		{
			IList modelObjectListValue = GetProperty("extensionpoints").ModelObjectListValue;
			ExtensionPoint[] array = new ExtensionPoint[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public BMOperation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
