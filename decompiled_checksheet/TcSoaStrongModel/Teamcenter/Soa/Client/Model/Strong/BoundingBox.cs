namespace Teamcenter.Soa.Client.Model.Strong;

public class BoundingBox : POM_object
{
	public double X_min => GetProperty("x_min").DoubleValue;

	public double Y_min => GetProperty("y_min").DoubleValue;

	public double Z_min => GetProperty("z_min").DoubleValue;

	public double X_max => GetProperty("x_max").DoubleValue;

	public double Y_max => GetProperty("y_max").DoubleValue;

	public double Z_max => GetProperty("z_max").DoubleValue;

	public BoundingMultiBox Parent => (BoundingMultiBox)GetProperty("parent").ModelObjectValue;

	public BoundingBox(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
