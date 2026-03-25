namespace Teamcenter.Soa.Client.Model.Strong;

public class ConstantChoice : POM_object
{
	public string Choice_name => GetProperty("choice_name").StringValue;

	public bool Secured => GetProperty("secured").BoolValue;

	public ConstantChoice(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
