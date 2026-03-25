using System;

namespace Teamcenter.Soa.Internal.Client;

public interface Sender
{
	Transport TheTransport { get; }

	Transport getTransport();

	object Invoke(string service, string operation, object requestObject, Type type, Type[] extraTypes);

	void PushRequestId();

	void PopRequestId();
}
