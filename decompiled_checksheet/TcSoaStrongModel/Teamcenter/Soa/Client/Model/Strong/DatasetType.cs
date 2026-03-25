using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class DatasetType : POM_application_object
{
	public string Datasettype_name => GetProperty("datasettype_name").StringValue;

	public DatasetType Parent_type => (DatasetType)GetProperty("parent_type").ModelObjectValue;

	public string Description => GetProperty("description").StringValue;

	public int Action_list => GetProperty("action_list").IntValue;

	public string[] Named_ref_list => GetProperty("named_ref_list").StringArrayValue;

	public Tool[] List_of_tools
	{
		get
		{
			IList modelObjectListValue = GetProperty("list_of_tools").ModelObjectListValue;
			Tool[] array = new Tool[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public Tool[] List_of_tools_view
	{
		get
		{
			IList modelObjectListValue = GetProperty("list_of_tools_view").ModelObjectListValue;
			Tool[] array = new Tool[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public DatasetType(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
