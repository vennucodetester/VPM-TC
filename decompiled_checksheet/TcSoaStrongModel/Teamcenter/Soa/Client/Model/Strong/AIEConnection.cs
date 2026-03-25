namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEConnection : POM_application_object
{
	public string Name => GetProperty("name").StringValue;

	public string Desc => GetProperty("desc").StringValue;

	public bool Export_only => GetProperty("export_only").BoolValue;

	public ModelObject Import_folder => GetProperty("import_folder").ModelObjectValue;

	public AIEConnectionFileList File_list => (AIEConnectionFileList)GetProperty("file_list").ModelObjectValue;

	public ModelObject[] Cko_pom_list => GetProperty("cko_pom_list").ModelObjectArrayValue;

	public ImanFile Transaction_log => (ImanFile)GetProperty("transaction_log").ModelObjectValue;

	public AIEConnection(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
