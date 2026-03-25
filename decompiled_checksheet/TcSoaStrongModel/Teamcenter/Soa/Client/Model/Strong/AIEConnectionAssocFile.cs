namespace Teamcenter.Soa.Client.Model.Strong;

public class AIEConnectionAssocFile : POM_application_object
{
	public ModelObject File => GetProperty("file").ModelObjectValue;

	public string Connection_filespec => GetProperty("connection_filespec").StringValue;

	public string Named_ref_type => GetProperty("named_ref_type").StringValue;

	public string Client_timestamp => GetProperty("client_timestamp").StringValue;

	public AIEConnectionAssocFile(SoaType type, string uid)
		: base(type, uid)
	{
	}
}
