namespace Teamcenter.Soa.Client.Model.Strong;

public class Connection_TerminalStorage : POM_object
{
	public string Fnd0Direction => GetProperty("fnd0Direction").StringValue;

	public Connection_TerminalStorage(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
