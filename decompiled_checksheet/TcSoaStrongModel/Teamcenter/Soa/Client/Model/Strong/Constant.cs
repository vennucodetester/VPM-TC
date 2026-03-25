using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class Constant : POM_object
{
	public string Default_value => GetProperty("default_value").StringValue;

	public int Data_type => GetProperty("data_type").IntValue;

	public ConstantChoice[] Constant_choices
	{
		get
		{
			IList modelObjectListValue = GetProperty("constant_choices").ModelObjectListValue;
			ConstantChoice[] array = new ConstantChoice[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public string Description => GetProperty("description").StringValue;

	public string[] Default_values => GetProperty("default_values").StringArrayValue;

	public bool Is_multivalued => GetProperty("is_multivalued").BoolValue;

	public bool Is_attachment_secured => GetProperty("is_attachment_secured").BoolValue;

	public bool AllowOpsDataUpdate => GetProperty("allowOpsDataUpdate").BoolValue;

	public bool AllowOpsDataUpdateOverride => GetProperty("allowOpsDataUpdateOverride").BoolValue;

	public Constant(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
