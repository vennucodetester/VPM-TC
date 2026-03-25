namespace Teamcenter.Soa.Client.Model.Strong;

public class BomChange_Form : Form
{
	public string Disposition => GetProperty("disposition").StringValue;

	public BomChange_Form(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
