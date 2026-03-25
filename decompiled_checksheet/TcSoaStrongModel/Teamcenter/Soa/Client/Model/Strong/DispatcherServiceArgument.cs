namespace Teamcenter.Soa.Client.Model.Strong;

public class DispatcherServiceArgument : POM_object
{
	public string Key => GetProperty("key").StringValue;

	public int Interface_type => GetProperty("interface_type").IntValue;

	public string Default_value => GetProperty("default_value").StringValue;

	public string Argument_name => GetProperty("argument_name").StringValue;

	public string Defining_dspsvcconfig => GetProperty("defining_dspsvcconfig").StringValue;

	public DispatcherServiceArgument(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
