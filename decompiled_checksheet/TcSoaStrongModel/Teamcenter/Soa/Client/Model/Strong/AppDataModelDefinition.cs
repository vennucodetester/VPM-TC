namespace Teamcenter.Soa.Client.Model.Strong;

public class AppDataModelDefinition : POM_object
{
	public string Dataset_type_name => GetProperty("dataset_type_name").StringValue;

	public int Definition_type => GetProperty("definition_type").IntValue;

	public string[] Info => GetProperty("info").StringArrayValue;

	public AppDataModelDefinition(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
