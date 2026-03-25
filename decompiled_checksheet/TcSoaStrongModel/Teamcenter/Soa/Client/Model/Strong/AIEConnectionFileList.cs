using System.Collections;

namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEConnectionFileList : POM_application_object
{
	public string Export_dir => GetProperty("export_dir").StringValue;

	public string Temp_directory => GetProperty("temp_directory").StringValue;

	public AIEConnectionXdataFile[] X_files
	{
		get
		{
			IList modelObjectListValue = GetProperty("x_files").ModelObjectListValue;
			AIEConnectionXdataFile[] array = new AIEConnectionXdataFile[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public AIEConnectionFile[] Connection_files
	{
		get
		{
			IList modelObjectListValue = GetProperty("connection_files").ModelObjectListValue;
			AIEConnectionFile[] array = new AIEConnectionFile[modelObjectListValue.Count];
			modelObjectListValue.CopyTo(array, 0);
			return array;
		}
	}

	public ImanFile Transaction_log => (ImanFile)GetProperty("transaction_log").ModelObjectValue;

	public AIEConnectionFileList(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
