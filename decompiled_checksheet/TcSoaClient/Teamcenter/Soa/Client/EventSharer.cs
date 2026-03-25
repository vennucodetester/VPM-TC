namespace Teamcenter.Soa.Client;

public interface EventSharer
{
	bool IsEventSharingFunctioning();

	bool IsServerShared();

	void ProcessSharedEvents();
}
