using Teamcenter.Schemas.Soa._2006_03.Exceptions;

namespace Teamcenter.Soa.Client;

public interface CredentialManager
{
	int CredentialType { get; }

	string[] GetCredentials(InvalidCredentialsException invalidCredentials);

	string[] GetCredentials(InvalidUserException invalidUser);

	void SetUserPassword(string user, string password, string discriminator);

	void SetGroupRole(string group, string role);
}
