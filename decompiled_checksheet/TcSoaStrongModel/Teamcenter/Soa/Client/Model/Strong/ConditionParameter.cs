namespace Teamcenter.Soa.Client.Model.Strong;

public class ConditionParameter : POM_object
{
	public string Parameter_name => GetProperty("parameter_name").StringValue;

	public string Parameter_type => GetProperty("parameter_type").StringValue;

	public ConditionParameter(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
