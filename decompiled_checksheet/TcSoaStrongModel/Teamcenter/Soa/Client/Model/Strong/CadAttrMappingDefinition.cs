using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CadAttrMappingDefinition : POM_object
{
	public string Attr_title => GetProperty("attr_title").StringValue;

	public string Item_type_name => GetProperty("item_type_name").StringValue;

	public string Dataset_type_name => GetProperty("dataset_type_name").StringValue;

	public bool Cad_master => GetProperty("cad_master").BoolValue;

	public bool Iman_master => GetProperty("iman_master").BoolValue;

	public bool Freezable => GetProperty("freezable").BoolValue;

	public bool Required => GetProperty("required").BoolValue;

	public bool Write_once => GetProperty("write_once").BoolValue;

	public bool Allow_null_value => GetProperty("allow_null_value").BoolValue;

	public string Description => GetProperty("description").StringValue;

	public string Default_value => GetProperty("default_value").StringValue;

	public int State => GetProperty("state").IntValue;

	public int Mapping_type => GetProperty("mapping_type").IntValue;

	public string Constant_value => GetProperty("constant_value").StringValue;

	public string Preference_name => GetProperty("preference_name").StringValue;

	public int Preference_scope => GetProperty("preference_scope").IntValue;

	public CadAttrMappingDefPart[] Mapping_parts
	{
		get
		{
			IList modelObjectListValue = GetProperty("mapping_parts").ModelObjectListValue;
			CadAttrMappingDefPart[] array = new CadAttrMappingDefPart[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public bool Is_hard_coded => GetProperty("is_hard_coded").BoolValue;

	public CadAttrMappingDefinition(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
