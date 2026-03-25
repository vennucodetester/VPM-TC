using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEExportAssembly : POM_object
{
	public string Bw_ref => GetProperty("bw_ref").StringValue;

	public bool Co_root => GetProperty("co_root").BoolValue;

	public int Num_dstypes => GetProperty("num_dstypes").IntValue;

	public string Primary_filespec => GetProperty("primary_filespec").StringValue;

	public string Primary_path => GetProperty("primary_path").StringValue;

	public Dataset Root_ds_ref => (Dataset)GetProperty("root_ds_ref").ModelObjectValue;

	public AIEExportNode Toplevel_ref => (AIEExportNode)GetProperty("toplevel_ref").ModelObjectValue;

	public AIEExportNode[] Node_refs
	{
		get
		{
			IList modelObjectListValue = GetProperty("node_refs").ModelObjectListValue;
			AIEExportNode[] array = new AIEExportNode[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public DatasetType[] Dstype_refs
	{
		get
		{
			IList modelObjectListValue = GetProperty("dstype_refs").ModelObjectListValue;
			DatasetType[] array = new DatasetType[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AIEExportAssembly(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
