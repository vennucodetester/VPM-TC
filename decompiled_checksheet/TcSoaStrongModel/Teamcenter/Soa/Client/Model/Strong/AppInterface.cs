using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AppInterface : WorkspaceObject
{
	public ModelObject[] Base_refs => GetProperty("base_refs").ModelObjectArrayValue;

	public RequestObject[] Request_objects
	{
		get
		{
			IList modelObjectListValue = GetProperty("request_objects").ModelObjectListValue;
			RequestObject[] array = new RequestObject[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public MasterRecord Master_record => (MasterRecord)GetProperty("master_record").ModelObjectValue;

	public ItemRevision Incremental_change => (ItemRevision)GetProperty("incremental_change").ModelObjectValue;

	public POMImc Site_id => (POMImc)GetProperty("site_id").ModelObjectValue;

	public POMImc[] Fnd0target_site_ids
	{
		get
		{
			IList modelObjectListValue = GetProperty("fnd0target_site_ids").ModelObjectListValue;
			POMImc[] array = new POMImc[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public TransferMode Tm_export => (TransferMode)GetProperty("tm_export").ModelObjectValue;

	public TransferMode Tm_import => (TransferMode)GetProperty("tm_import").ModelObjectValue;

	public ModelObject[] IMAN_TCPublishedPortfolio => GetProperty("IMAN_TCPublishedPortfolio").ModelObjectArrayValue;

	public bool Can_add_sync => GetProperty("can_add_sync").BoolValue;

	public string Project_id => GetProperty("project_id").StringValue;

	public bool Can_add_publish => GetProperty("can_add_publish").BoolValue;

	public ModelObject[] Fnd0LogRelation => GetProperty("Fnd0LogRelation").ModelObjectArrayValue;

	public AppInterface(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
