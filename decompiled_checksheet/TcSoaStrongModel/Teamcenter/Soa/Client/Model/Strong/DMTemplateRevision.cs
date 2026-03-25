namespace Teamcenter.Soa.Client.Model.Strong;

public class DMTemplateRevision : ItemRevision
{
	public string ApplicationName => GetProperty("ApplicationName").StringValue;

	public string ApplicationRelation => GetProperty("ApplicationRelation").StringValue;

	public string ApplicationVersion => GetProperty("ApplicationVersion").StringValue;

	public string[] ItemTypesToCreate => GetProperty("ItemTypesToCreate").StringArrayValue;

	public string[] TemplateType => GetProperty("TemplateType").StringArrayValue;

	public string TemplateUnits => GetProperty("TemplateUnits").StringValue;

	public DMTemplateRevision(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
