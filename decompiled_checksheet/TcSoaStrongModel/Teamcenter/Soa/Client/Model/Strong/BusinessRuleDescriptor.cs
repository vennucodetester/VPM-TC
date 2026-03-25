namespace Teamcenter.Soa.Client.Model.Strong;

public class BusinessRuleDescriptor : POM_object
{
	public string Version => GetProperty("version").StringValue;

	public BusinessRuleDescriptor(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
