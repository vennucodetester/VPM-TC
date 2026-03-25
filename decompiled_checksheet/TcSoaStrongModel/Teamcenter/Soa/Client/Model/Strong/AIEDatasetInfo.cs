using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEDatasetInfo : POM_object
{
	public string Ds_name => GetProperty("ds_name").StringValue;

	public string Dstype_name => GetProperty("dstype_name").StringValue;

	public int Co_status => GetProperty("co_status").IntValue;

	public int Export_status => GetProperty("export_status").IntValue;

	public string Co_info => GetProperty("co_info").StringValue;

	public bool Co_request => GetProperty("co_request").BoolValue;

	public int Num_nr => GetProperty("num_nr").IntValue;

	public Dataset Ds_ref => (Dataset)GetProperty("ds_ref").ModelObjectValue;

	public DatasetType Dstype_ref => (DatasetType)GetProperty("dstype_ref").ModelObjectValue;

	public ImanFile[] Nr_refs
	{
		get
		{
			IList modelObjectListValue = GetProperty("nr_refs").ModelObjectListValue;
			ImanFile[] array = new ImanFile[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AIEDatasetInfo(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
