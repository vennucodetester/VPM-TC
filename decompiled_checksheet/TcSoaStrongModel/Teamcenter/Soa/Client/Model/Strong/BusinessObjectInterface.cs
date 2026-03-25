namespace Teamcenter.Soa.Client.Model.Strong;

public class BusinessObjectInterface : MetaInterface
{
	public string TypeName => GetProperty("typeName").StringValue;

	public bool PrimaryInterface => GetProperty("primaryInterface").BoolValue;

	public BusinessObjectInterface(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
