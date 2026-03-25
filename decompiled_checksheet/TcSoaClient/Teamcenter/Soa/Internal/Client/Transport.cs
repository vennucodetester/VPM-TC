namespace Teamcenter.Soa.Internal.Client;

public interface Transport
{
	string ExecuteRequest(string service, string operation, byte[] requestBytes, string servletURI);
}
