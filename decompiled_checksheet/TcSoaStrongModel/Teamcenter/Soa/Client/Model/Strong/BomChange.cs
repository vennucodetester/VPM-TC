namespace Teamcenter.Soa.Client.Model.Strong;

public class BomChange : POM_object
{
	public int Change_type => GetProperty("change_type").IntValue;

	public bool Is_derived => GetProperty("is_derived").BoolValue;

	public ModelObject Ec_rev_tag => GetProperty("ec_rev_tag").ModelObjectValue;

	public ModelObject Bvr_tag => GetProperty("bvr_tag").ModelObjectValue;

	public ModelObject Occurrence_tag => GetProperty("occurrence_tag").ModelObjectValue;

	public ModelObject Custom_obj_tag => GetProperty("custom_obj_tag").ModelObjectValue;

	public double Bomchange_qty => GetProperty("bomchange_qty").DoubleValue;

	public string Object_name => GetProperty("object_name").StringValue;

	public double Quantity_diff => GetProperty("quantity_diff").DoubleValue;

	public ModelObject Supersedure => GetProperty("supersedure").ModelObjectValue;

	public ModelObject Problem_bvr => GetProperty("problem_bvr").ModelObjectValue;

	public string Object_type => GetProperty("object_type").StringValue;

	public string Object_full_name => GetProperty("object_full_name").StringValue;

	public BomChange(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
