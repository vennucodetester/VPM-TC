namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEMapRow : POM_object
{
	public string CAERowCell1 => GetProperty("CAERowCell1").StringValue;

	public string CAERowCell2 => GetProperty("CAERowCell2").StringValue;

	public string CAERowCell3 => GetProperty("CAERowCell3").StringValue;

	public CAEMapRow(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
