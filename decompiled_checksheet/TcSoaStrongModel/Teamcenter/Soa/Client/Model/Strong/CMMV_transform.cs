namespace Teamcenter.Soa.Client.Model.Strong;

public class CMMV_transform : POM_object
{
	public double[] Transform => GetProperty("transform").DoubleArrayValue;

	public CMMV_transform(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
