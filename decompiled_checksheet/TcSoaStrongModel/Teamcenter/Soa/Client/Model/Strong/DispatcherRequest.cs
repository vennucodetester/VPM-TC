using System;
using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class DispatcherRequest : POM_application_object
{
	public string ProviderName => GetProperty("providerName").StringValue;

	public string ServiceName => GetProperty("serviceName").StringValue;

	public int Priority => GetProperty("priority").IntValue;

	public ModelObject[] PrimaryObjects => GetProperty("primaryObjects").ModelObjectArrayValue;

	public ModelObject[] SecondaryObjects => GetProperty("secondaryObjects").ModelObjectArrayValue;

	public string TaskID => GetProperty("taskID").StringValue;

	public string[] ArgumentKeys => GetProperty("argumentKeys").StringArrayValue;

	public string[] ArgumentData => GetProperty("argumentData").StringArrayValue;

	public string Type => GetProperty("type").StringValue;

	public DateTime StartTime => GetProperty("startTime").DateValue;

	public DateTime EndTime => GetProperty("endTime").DateValue;

	public int Interval => GetProperty("interval").IntValue;

	public string[] DataFilesKeys => GetProperty("dataFilesKeys").StringArrayValue;

	public ImanFile[] DataFiles
	{
		get
		{
			IList modelObjectListValue = GetProperty("dataFiles").ModelObjectListValue;
			ImanFile[] array = new ImanFile[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public string[] HistoryStates => GetProperty("historyStates").StringArrayValue;

	public DateTime[] HistoryDates => GetProperty("historyDates").DateArrayValue;

	public string CurrentState => GetProperty("currentState").StringValue;

	public int Mode => GetProperty("mode").IntValue;

	public DispatcherRequest(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
