namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEImportOperation : POM_object
{
	public int Num_files => GetProperty("num_files").IntValue;

	public string[] File_names => GetProperty("file_names").StringArrayValue;

	public string Supplier_user => GetProperty("supplier_user").StringValue;

	public AIEPersistentConnection Conn_ref => (AIEPersistentConnection)GetProperty("conn_ref").ModelObjectValue;

	public Folder Import_folder_ref => (Folder)GetProperty("import_folder_ref").ModelObjectValue;

	public AIEImportOperation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
