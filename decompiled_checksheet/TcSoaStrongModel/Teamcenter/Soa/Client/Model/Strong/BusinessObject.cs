using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Soa.Client.Model.Strong;

public class BusinessObject : ModelObjectImpl
{
	public string Object_string => GetProperty("object_string").StringValue;

	public BusinessObject(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
