using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class DispatcherServiceConfig : BusinessElement
{
	public string Der_dataset_named_ref => GetProperty("der_dataset_named_ref").StringValue;

	public DatasetType Der_dataset_type_name => (DatasetType)GetProperty("der_dataset_type_name").ModelObjectValue;

	public bool Dispatcher_svc_available => GetProperty("dispatcher_svc_available").BoolValue;

	public string Dispatcher_svc_display_name => GetProperty("dispatcher_svc_display_name").StringValue;

	public string Dispatcher_svc_name => GetProperty("dispatcher_svc_name").StringValue;

	public int Priority => GetProperty("priority").IntValue;

	public string Provider_name => GetProperty("provider_name").StringValue;

	public string Provider_display_name => GetProperty("provider_display_name").StringValue;

	public int Sort_order => GetProperty("sort_order").IntValue;

	public string Src_dataset_named_ref => GetProperty("src_dataset_named_ref").StringValue;

	public DatasetType Src_dataset_type_name => (DatasetType)GetProperty("src_dataset_type_name").ModelObjectValue;

	public ImanType Item_revision_relation => (ImanType)GetProperty("item_revision_relation").ModelObjectValue;

	public ImanType Der_from_dataset_relation => (ImanType)GetProperty("der_from_dataset_relation").ModelObjectValue;

	public DispatcherServiceArgument[] Dispatcher_svc_arguments
	{
		get
		{
			IList modelObjectListValue = GetProperty("dispatcher_svc_arguments").ModelObjectListValue;
			DispatcherServiceArgument[] array = new DispatcherServiceArgument[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public DispatcherServiceConfig(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
