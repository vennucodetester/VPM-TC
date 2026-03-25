namespace Teamcenter.Soa.Client.Model.Strong;

public class BusinessRule : POM_object
{
	public string Object_desc => GetProperty("object_desc").StringValue;

	public int Secure_bits => GetProperty("secure_bits").IntValue;

	public BusinessRuleDescriptor Rule_descriptor => (BusinessRuleDescriptor)GetProperty("rule_descriptor").ModelObjectValue;

	public Condition Condition_reference => (Condition)GetProperty("condition_reference").ModelObjectValue;

	public BusinessRule(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
