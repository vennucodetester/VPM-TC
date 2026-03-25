namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEEncapsulation : AIEConnection
{
	public string Session_id1 => GetProperty("session_id1").StringValue;

	public Tool Encapsulation_tool => (Tool)GetProperty("encapsulation_tool").ModelObjectValue;

	public AIEEncapsulation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
