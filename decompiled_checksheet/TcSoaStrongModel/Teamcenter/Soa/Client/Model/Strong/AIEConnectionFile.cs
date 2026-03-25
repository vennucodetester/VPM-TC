using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEConnectionFile : POM_application_object
{
	public ModelObject File => GetProperty("file").ModelObjectValue;

	public ModelObject Item => GetProperty("item").ModelObjectValue;

	public ModelObject Item_revision => GetProperty("item_revision").ModelObjectValue;

	public ModelObject Owning_dataset => GetProperty("owning_dataset").ModelObjectValue;

	public string Named_ref_type => GetProperty("named_ref_type").StringValue;

	public string Connection_filespec => GetProperty("connection_filespec").StringValue;

	public string Client_timestamp => GetProperty("client_timestamp").StringValue;

	public ModelObject Associated_tool => GetProperty("associated_tool").ModelObjectValue;

	public bool Exported => GetProperty("exported").BoolValue;

	public bool Checked_out => GetProperty("checked_out").BoolValue;

	public string Connection_relative_path => GetProperty("connection_relative_path").StringValue;

	public AIEConnectionAssocFile[] Connection_associated_files
	{
		get
		{
			IList modelObjectListValue = GetProperty("connection_associated_files").ModelObjectListValue;
			AIEConnectionAssocFile[] array = new AIEConnectionAssocFile[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AIERootObject Root => (AIERootObject)GetProperty("root").ModelObjectValue;

	public AIEConnectionFile(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
