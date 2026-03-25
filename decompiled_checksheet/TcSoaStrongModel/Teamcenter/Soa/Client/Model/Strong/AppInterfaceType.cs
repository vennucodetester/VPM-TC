using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AppInterfaceType : POM_application_object
{
	public string Name => GetProperty("name").StringValue;

	public string Desc => GetProperty("desc").StringValue;

	public bool IsICrequired => GetProperty("isICrequired").BoolValue;

	public bool IsUsedForIDC => GetProperty("isUsedForIDC").BoolValue;

	public ImanType[] ObjectTypes
	{
		get
		{
			IList modelObjectListValue = GetProperty("objectTypes").ModelObjectListValue;
			ImanType[] array = new ImanType[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public PSViewType[] ViewTypes
	{
		get
		{
			IList modelObjectListValue = GetProperty("viewTypes").ModelObjectListValue;
			PSViewType[] array = new PSViewType[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public Tool Tool => (Tool)GetProperty("tool").ModelObjectValue;

	public TransferMode Tm_export => (TransferMode)GetProperty("tm_export").ModelObjectValue;

	public TransferMode Tm_import => (TransferMode)GetProperty("tm_import").ModelObjectValue;

	public AppInterfaceType(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
