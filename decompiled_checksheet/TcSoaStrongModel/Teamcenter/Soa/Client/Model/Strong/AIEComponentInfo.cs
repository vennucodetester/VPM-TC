using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEComponentInfo : POM_object
{
	public string Bl_tag => GetProperty("bl_tag").StringValue;

	public string Bl_name => GetProperty("bl_name").StringValue;

	public string Viewtype_name => GetProperty("viewtype_name").StringValue;

	public int Num_ds => GetProperty("num_ds").IntValue;

	public AIEDatasetInfo[] Ds_refs
	{
		get
		{
			IList modelObjectListValue = GetProperty("ds_refs").ModelObjectListValue;
			AIEDatasetInfo[] array = new AIEDatasetInfo[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ItemRevision Ir_ref => (ItemRevision)GetProperty("ir_ref").ModelObjectValue;

	public PSBOMViewRevision Bvr_ref => (PSBOMViewRevision)GetProperty("bvr_ref").ModelObjectValue;

	public AIEComponentInfo(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
