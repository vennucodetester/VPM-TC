using System;
using Teamcenter.Net.TcSSProxy.Client;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Exceptions;

namespace Teamcenter.Soa.Client;

public class SsoCredentials : CredentialManager
{
	protected readonly bool TC_SSO_SESSION_FLAG = true;

	private string ssoServerUrl;

	private string ssoAppID;

	private string group;

	private string role;

	private string discriminator;

	public int CredentialType => SoaConstants.CLIENT_CREDENTIAL_TYPE_SSO;

	public string SSOUrl => ssoServerUrl;

	public SsoCredentials(string ssoServerUrl, string ssoAppID)
	{
		this.ssoServerUrl = ssoServerUrl;
		this.ssoAppID = ssoAppID;
		group = null;
		role = null;
		discriminator = null;
	}

	public string[] GetCredentials(InvalidCredentialsException invalidCredentials)
	{
		throw new CanceledOperationException(invalidCredentials.Message, invalidCredentials);
	}

	public string[] GetCredentials(InvalidUserException invalidUser)
	{
		//IL_0014: Expected O, but got Unknown
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Expected O, but got Unknown
		//IL_0061: Expected O, but got Unknown
		//IL_009c: Expected O, but got Unknown
		//IL_00b0: Expected O, but got Unknown
		ISSOClient val = null;
		try
		{
			val = NetBindingLoader.GetISSOClientInstance(ssoServerUrl);
		}
		catch (CSSOConfigurationException ex)
		{
			CSSOConfigurationException e = ex;
			HandleException((Exception)(object)e, "SSOConfiguration: probably malformedURL");
		}
		ISSOSession val2 = null;
		try
		{
			val2 = val.getSSOSession(TC_SSO_SESSION_FLAG);
		}
		catch (CSSOLoginCancelledException ex2)
		{
			CSSOLoginCancelledException e2 = ex2;
			HandleException((Exception)(object)e2, "loginCancelled");
		}
		catch (CSSOLoginFailureException ex3)
		{
			CSSOLoginFailureException e3 = ex3;
			HandleException((Exception)(object)e3, "loginFailed");
		}
		catch (CSSOException ex4)
		{
			CSSOException e4 = ex4;
			HandleException((Exception)(object)e4, "SSOException");
		}
		string text = null;
		string text2 = null;
		ISSOAppToken val3 = null;
		if (val2 != null)
		{
			try
			{
				val3 = val2.generateSSOAppToken(ssoAppID);
			}
			catch (CSSOLoginFailureException ex5)
			{
				CSSOLoginFailureException e5 = ex5;
				HandleException((Exception)(object)e5, "loginFailed");
			}
			catch (CSSOException ex6)
			{
				CSSOException e4 = ex6;
				HandleException((Exception)(object)e4, "SSOException");
			}
			if (val3 != null)
			{
				text = val3.getAppUserId();
				text2 = val3.getSSOSessionKey();
			}
		}
		return new string[5]
		{
			(text == null) ? string.Empty : text,
			(text2 == null) ? string.Empty : text2,
			(group == null) ? string.Empty : group,
			(role == null) ? string.Empty : role,
			(discriminator == null) ? string.Empty : discriminator
		};
	}

	private void HandleException(Exception e, string errorText)
	{
		Console.Error.WriteLine(errorText + " - " + e);
		throw new CanceledOperationException(errorText + " - " + e.Message, e);
	}

	public void SetUserPassword(string user, string password, string discriminator)
	{
		this.discriminator = discriminator;
	}

	public void SetGroupRole(string group, string role)
	{
		this.group = group;
		this.role = role;
	}
}
