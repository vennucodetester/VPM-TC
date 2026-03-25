namespace Teamcenter.Soa.Client.Model.Strong;

public class Connection_Terminal : Interfaces
{
	public string Fnd0Direction => GetProperty("fnd0Direction").StringValue;

	public Connection_Terminal(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
