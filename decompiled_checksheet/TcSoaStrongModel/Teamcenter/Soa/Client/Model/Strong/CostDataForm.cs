namespace Teamcenter.Soa.Client.Model.Strong;

public class CostDataForm : Form
{
	public double CostAmount => GetProperty("CostAmount").DoubleValue;

	public CostDataForm(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
