namespace Teamcenter.Soa.Client;

public interface RequestListener
{
	void ServiceRequest(ServiceInfo info);

	void ServiceResponse(ServiceInfo info);
}
