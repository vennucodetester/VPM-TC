namespace Teamcenter.Soa.Client.Model.Strong;

public class ClientDataMaster : POM_object
{
	public ModelObject Class_id => GetProperty("class_id").ModelObjectValue;

	public string[] Attr_names => GetProperty("attr_names").StringArrayValue;

	public ModelObject[] Attr_classes => GetProperty("attr_classes").ModelObjectArrayValue;

	public int[] Properties => GetProperty("properties").IntArrayValue;

	public ClientDataMaster(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
