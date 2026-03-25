namespace Teamcenter.Soa.Client.Model.Strong;

public class ChangeTypeData : POM_object
{
	public string Name => GetProperty("name").StringValue;

	public bool Is_effectivity_shared => GetProperty("is_effectivity_shared").BoolValue;

	public ModelObject Id_format => GetProperty("id_format").ModelObjectValue;

	public ModelObject Rev_id_format => GetProperty("rev_id_format").ModelObjectValue;

	public ModelObject[] Form_types => GetProperty("form_types").ModelObjectArrayValue;

	public string[] Processes => GetProperty("processes").StringArrayValue;

	public string Object_type => GetProperty("object_type").StringValue;

	public string Object_name => GetProperty("object_name").StringValue;

	public string Object_full_name => GetProperty("object_full_name").StringValue;

	public ChangeTypeData(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
