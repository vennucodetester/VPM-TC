using Teamcenter.Soa.Client;

namespace Teamcenter.Soa.Internal.Client;

public interface NotifyRequestListeners
{
	void NotifyRequestListeners(ServiceInfo requestInfo);

	void NotifyResponseListeners(ServiceInfo responseInfo);
}
