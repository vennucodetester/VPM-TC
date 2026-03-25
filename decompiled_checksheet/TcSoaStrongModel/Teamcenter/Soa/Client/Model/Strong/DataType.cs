namespace Teamcenter.Soa.Client.Model.Strong;

public class DataType : POM_object
{
	public string Name => GetProperty("name").StringValue;

	public string Namespace => GetProperty("namespace").StringValue;

	public string Description => GetProperty("description").StringValue;

	public Release CreateRelease => (Release)GetProperty("createRelease").ModelObjectValue;

	public bool IsDeprecated => GetProperty("isDeprecated").BoolValue;

	public Release DeprecatedRelease => (Release)GetProperty("deprecatedRelease").ModelObjectValue;

	public string DeprecatedDescription => GetProperty("deprecatedDescription").StringValue;

	public DataType(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
