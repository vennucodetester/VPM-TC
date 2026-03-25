namespace Teamcenter.Soa.Client.Model.Strong;

public class DerivedObj : POM_object
{
	public DatasetType Der_dataset_type_name => (DatasetType)GetProperty("der_dataset_type_name").ModelObjectValue;

	public bool Der_required => GetProperty("der_required").BoolValue;

	public string Defining_irdc => GetProperty("defining_irdc").StringValue;

	public ImanType Item_revision_relation => (ImanType)GetProperty("item_revision_relation").ModelObjectValue;

	public DerivedObj(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
