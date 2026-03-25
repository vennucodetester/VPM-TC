using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class CAEResultData : POM_application_object
{
	public string Name => GetProperty("name").StringValue;

	public string Type => GetProperty("type").StringValue;

	public string Description => GetProperty("description").StringValue;

	public bool External => GetProperty("external").BoolValue;

	public string[] External_files => GetProperty("external_files").StringArrayValue;

	public ImanFile Plmxml_file => (ImanFile)GetProperty("plmxml_file").ModelObjectValue;

	public ImanFile[] Internal_files
	{
		get
		{
			IList modelObjectListValue = GetProperty("internal_files").ModelObjectListValue;
			ImanFile[] array = new ImanFile[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public CAEResultData(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
