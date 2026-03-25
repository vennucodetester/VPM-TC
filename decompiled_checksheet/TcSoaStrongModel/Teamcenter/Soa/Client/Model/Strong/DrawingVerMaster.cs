namespace Teamcenter.Soa.Client.Model.Strong;

public class DrawingVerMaster : POM_object
{
	public string Drawing_Type => GetProperty("Drawing_Type").StringValue;

	public DrawingVerMaster(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
