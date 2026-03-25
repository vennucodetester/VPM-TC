namespace Teamcenter.Soa.Client.Model.Strong;

public class DMTemplate_Master : Form
{
	public string ApplicationName => GetProperty("ApplicationName").StringValue;

	public string ApplicationVersion => GetProperty("ApplicationVersion").StringValue;

	public string[] TemplateType => GetProperty("TemplateType").StringArrayValue;

	public string TemplateUnits => GetProperty("TemplateUnits").StringValue;

	public string[] ItemTypesToCreate => GetProperty("ItemTypesToCreate").StringArrayValue;

	public string ApplicationRelation => GetProperty("ApplicationRelation").StringValue;

	public DMTemplate_Master(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
