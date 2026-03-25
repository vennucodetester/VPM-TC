namespace Teamcenter.Soa.Client.Model.Strong;

public class BomChangeSampleFSC : POM_object
{
	public string Disposition => GetProperty("disposition").StringValue;

	public BomChangeSampleFSC(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
