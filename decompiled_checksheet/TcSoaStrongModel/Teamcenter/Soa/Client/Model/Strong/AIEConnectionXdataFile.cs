namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEConnectionXdataFile : POM_application_object
{
	public string Connection_filespec => GetProperty("connection_filespec").StringValue;

	public string Client_timestamp => GetProperty("client_timestamp").StringValue;

	public AIEConnectionXdataFile(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
