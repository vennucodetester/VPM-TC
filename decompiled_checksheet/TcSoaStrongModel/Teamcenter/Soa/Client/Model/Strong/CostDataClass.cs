namespace Teamcenter.Soa.Client.Model.Strong;

public class CostDataClass : POM_application_object
{
	public double CostAmount => GetProperty("CostAmount").DoubleValue;

	public CostDataClass(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
