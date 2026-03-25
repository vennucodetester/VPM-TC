using Teamcenter.Schemas.Soa._2006_03.Exceptions;

namespace Teamcenter.Soa.Client;

public abstract class AbstractCredentialManager : CredentialManager
{
	public static int CLIENT_CREDENTIAL_TYPE_SSO = 1;

	public static int CLIENT_CREDENTIAL_TYPE_STD = 2;

	public abstract int CredentialType { get; }

	public abstract string[] GetCredentials(InvalidCredentialsException invalidCredentials);

	public abstract string[] GetCredentials(InvalidUserException invalidUser);

	public abstract void SetUserPassword(string user, string password, string discriminator);

	public abstract void SetGroupRole(string group, string role);
}
