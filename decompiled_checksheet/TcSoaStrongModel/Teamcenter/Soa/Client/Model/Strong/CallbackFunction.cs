namespace Teamcenter.Soa.Client.Model.Strong;

public class CallbackFunction : POM_object
{
	public string Type => GetProperty("type").StringValue;

	public string Library => GetProperty("library").StringValue;

	public string Function => GetProperty("function").StringValue;

	public string Name => GetProperty("name").StringValue;

	public CallbackFunction(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
