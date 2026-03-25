namespace Teamcenter.Soa.Client.Model.Strong;

public class Bldb1 : POM_object
{
	public int Sind => GetProperty("sind").IntValue;

	public int Attr_index => GetProperty("attr_index").IntValue;

	public string Min_value => GetProperty("min_value").StringValue;

	public string Max_value => GetProperty("max_value").StringValue;

	public int Aflags => GetProperty("aflags").IntValue;

	public string Text => GetProperty("text").StringValue;

	public int Flags_1 => GetProperty("flags_1").IntValue;

	public string Text_1 => GetProperty("text_1").StringValue;

	public int Flags_2 => GetProperty("flags_2").IntValue;

	public string Text_2 => GetProperty("text_2").StringValue;

	public string Ext_1 => GetProperty("ext_1").StringValue;

	public string Ext_2 => GetProperty("ext_2").StringValue;

	public string[] Groups => GetProperty("groups").StringArrayValue;

	public string DefaultValue => GetProperty("defaultValue").StringValue;

	public string Descr => GetProperty("descr").StringValue;

	public string Comment => GetProperty("comment").StringValue;

	public string Name => GetProperty("name").StringValue;

	public string Userfcn => GetProperty("userfcn").StringValue;

	public string Userfcnparam => GetProperty("userfcnparam").StringValue;

	public string DefaultValue2 => GetProperty("defaultValue2").StringValue;

	public string Max_value2 => GetProperty("max_value2").StringValue;

	public string Min_value2 => GetProperty("min_value2").StringValue;

	public Bldb0 Tag_to_header => (Bldb0)GetProperty("tag_to_header").ModelObjectValue;

	public Bldb1(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
