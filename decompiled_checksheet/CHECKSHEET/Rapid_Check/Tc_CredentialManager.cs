using System.Collections.Generic;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;

namespace Rapid_Check;

public class Tc_CredentialManager : CredentialManager
{
	private string group;

	private string role;

	private string discriminator;

	public int CredentialType => 0;

	public Tc_CredentialManager()
	{
		group = "";
		role = "";
		discriminator = "SoaAppX";
	}

	public string[] PromptForCredentials(string name, string password)
	{
		return new string[5] { name, password, group, role, discriminator };
	}

	public string[] GetCredentials(InvalidCredentialsException invalidCredentials)
	{
		return new List<string>().ToArray();
	}

	string[] CredentialManager.GetCredentials(InvalidCredentialsException invalidCredentials)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCredentials
		return this.GetCredentials(invalidCredentials);
	}

	public string[] GetCredentials(InvalidUserException invalidUser)
	{
		return new List<string>().ToArray();
	}

	string[] CredentialManager.GetCredentials(InvalidUserException invalidUser)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetCredentials
		return this.GetCredentials(invalidUser);
	}

	public void SetGroupRole(string group, string role)
	{
	}

	void CredentialManager.SetGroupRole(string group, string role)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetGroupRole
		this.SetGroupRole(group, role);
	}

	public void SetUserPassword(string user, string password, string discriminator)
	{
	}

	void CredentialManager.SetUserPassword(string user, string password, string discriminator)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetUserPassword
		this.SetUserPassword(user, password, discriminator);
	}
}
