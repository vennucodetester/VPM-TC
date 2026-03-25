namespace Teamcenter.Soa.Client.Model.Strong;

public class BoundingMultiBox : POM_object
{
	public string Geometry_source => GetProperty("geometry_source").StringValue;

	public BoundingMultiBox(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
