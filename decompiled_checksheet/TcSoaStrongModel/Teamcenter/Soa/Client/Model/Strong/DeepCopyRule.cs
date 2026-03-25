namespace Teamcenter.Soa.Client.Model.Strong;

public class DeepCopyRule : BusinessRule
{
	public string Type_name => GetProperty("type_name").StringValue;

	public int Operation => GetProperty("operation").IntValue;

	public int Copy_type => GetProperty("copy_type").IntValue;

	public ImanType Relation => (ImanType)GetProperty("relation").ModelObjectValue;

	public ModelObject Attach_type => GetProperty("attach_type").ModelObjectValue;

	public bool Is_required => GetProperty("is_required").BoolValue;

	public bool Is_target_primary => GetProperty("is_target_primary").BoolValue;

	public bool Copy_relation_attributes => GetProperty("copy_relation_attributes").BoolValue;

	public string Reference_property_name => GetProperty("reference_property_name").StringValue;

	public int PropertyType => GetProperty("propertyType").IntValue;

	public DeepCopyRule(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
