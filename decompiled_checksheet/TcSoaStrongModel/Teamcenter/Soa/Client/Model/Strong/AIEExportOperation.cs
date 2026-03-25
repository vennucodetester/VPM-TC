using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEExportOperation : POM_object
{
	public string Conn_dir_name => GetProperty("conn_dir_name").StringValue;

	public int Export_rule => GetProperty("export_rule").IntValue;

	public string Export_msg => GetProperty("export_msg").StringValue;

	public string Co_msg => GetProperty("co_msg").StringValue;

	public string Change_id => GetProperty("change_id").StringValue;

	public string Reason => GetProperty("reason").StringValue;

	public int Num_assemblies => GetProperty("num_assemblies").IntValue;

	public string Tool_name => GetProperty("tool_name").StringValue;

	public string Logfile_name => GetProperty("logfile_name").StringValue;

	public int Num_ds => GetProperty("num_ds").IntValue;

	public Dataset[] Ds_refs
	{
		get
		{
			IList modelObjectListValue = GetProperty("ds_refs").ModelObjectListValue;
			Dataset[] array = new Dataset[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AIEPersistentConnection Conn_ref => (AIEPersistentConnection)GetProperty("conn_ref").ModelObjectValue;

	public AIEExportAssembly[] Assembly_refs
	{
		get
		{
			IList modelObjectListValue = GetProperty("assembly_refs").ModelObjectListValue;
			AIEExportAssembly[] array = new AIEExportAssembly[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public VariantRule Variantrule_ref => (VariantRule)GetProperty("variantrule_ref").ModelObjectValue;

	public RevisionRule Revrule_ref => (RevisionRule)GetProperty("revrule_ref").ModelObjectValue;

	public AIEExportOperation(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
