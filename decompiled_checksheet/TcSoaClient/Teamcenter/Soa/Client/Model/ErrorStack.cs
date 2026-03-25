namespace Teamcenter.Soa.Client.Model;

public interface ErrorStack
{
	string ClientId { get; }

	int ClientIndex { get; }

	ModelObject AssociatedObject { get; }

	string[] Messages { get; }

	int[] Codes { get; }

	int[] Levels { get; }

	ErrorValue[] ErrorValues { get; }

	bool HasClientId();

	bool HasClientIndex();

	bool HasAssociatedObject();
}
