namespace Teamcenter.Soa.Client.Model.Strong;

public class DCt_GraphicPriority : WorkspaceObject
{
	public string GrphPrioName => GetProperty("grphPrioName").StringValue;

	public int GrphPrioMaxOptions => GetProperty("grphPrioMaxOptions").IntValue;

	public string AdminComment => GetProperty("adminComment").StringValue;

	public string[] GraphicUsages => GetProperty("graphicUsages").StringArrayValue;

	public DCt_GraphicPriority(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
