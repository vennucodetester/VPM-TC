namespace Teamcenter.Soa.Client.Model.Strong;

public class CMState : POM_object
{
	public int State_int => GetProperty("state_int").IntValue;

	public string State_string => GetProperty("state_string").StringValue;

	public CMState(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
