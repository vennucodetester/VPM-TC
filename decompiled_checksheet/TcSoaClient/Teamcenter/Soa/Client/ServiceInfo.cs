namespace Teamcenter.Soa.Client;

public class ServiceInfo
{
	private static readonly string SESSION_0603_SERVICE = "Core-2006-03-Session";

	private static readonly string SESSION_0806_SERVICE = "Core-2008-06-Session";

	private static readonly string LOGIN_METHOD_NAME = "login";

	private static readonly string SSOLOGIN_METHOD_NAME = "loginSSO";

	public readonly string Id;

	public readonly string Service;

	public readonly string Operation;

	public readonly string XmlDocument;

	public ServiceInfo(string id, string service, string operation, string xmlDocument)
	{
		Id = id;
		Service = service;
		Operation = operation;
		if ((service.Equals(SESSION_0603_SERVICE) || service.Equals(SESSION_0806_SERVICE)) && (operation.Equals(LOGIN_METHOD_NAME) || operation.Equals(SSOLOGIN_METHOD_NAME)))
		{
			XmlDocument = "XML document omitted.";
		}
		else
		{
			XmlDocument = xmlDocument;
		}
	}
}
