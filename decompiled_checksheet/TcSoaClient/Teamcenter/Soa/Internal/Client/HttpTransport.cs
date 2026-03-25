using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Internal.Utils;
using com.teamcenter._ss.client.cookie;
using com.teamcenter.ss;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
internal class HttpTransport : Transport
{
	private Dictionary<string, Cookie> lastCookies = new Dictionary<string, Cookie>();

	protected Connection connection;

	public HttpTransport(Connection connection)
	{
		this.connection = connection;
	}

	public string ExecuteRequest(string service, string operation, byte[] requestBytes, string servletURI)
	{
		string text = "";
		try
		{
			string uriString = connection.HostPath + servletURI + "/" + service + "/" + operation;
			Uri uRL = new Uri(uriString);
			HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
			HttpClient httpClient = new HttpClient(connection.Cookies);
			httpClient.Configuration.TIMEOUT = int.Parse(connection.GetOption(Connection.OPT_TIMEOUT));
			httpClient.Configuration.READWRITE_TIMEOUT = int.Parse(connection.GetOption(Connection.OPT_READ_WRITE_TIMEOUT));
			string option = connection.GetOption(Connection.OPT_USE_COMPRESSION);
			httpClient.Configuration.USE_COMPRESSION = (option.Equals("true") ? true : false);
			string id = LogCorrelation.GetId();
			httpClient.Configuration.LOG_CORRELATIONID = id;
			try
			{
				text = httpClient.MakeWebRequest(uRL, HttpMethods.POST, requestBytes);
			}
			catch (ProtocolViolationException ex)
			{
				string text2 = ex.Message;
				Exception baseException = ex.GetBaseException();
				if (baseException != null)
				{
					text2 = text2 + "\n" + baseException.Message;
				}
				throw new ProtocolException(text2);
			}
			catch (WebException ex2)
			{
				string text2 = ex2.Message;
				Exception baseException = ex2.GetBaseException();
				if (baseException != null)
				{
					text2 = text2 + "\n" + baseException.Message;
				}
				throw new ConnectionException(text2);
			}
			catch (InvalidOperationException ex3)
			{
				string text2 = ex3.Message;
				Exception baseException = ex3.GetBaseException();
				if (baseException != null)
				{
					text2 = text2 + "\n" + baseException.Message;
				}
				throw new ProtocolException(text2);
			}
			string responseContentType = httpClient.ResponseContentType;
			try
			{
				httpStatusCode = httpClient.ResponseStatusCode;
			}
			catch (ObjectDisposedException innerException)
			{
				throw new Exception("Object Disposed Exception Occured while trying to get StatusCode of HttpWebResponse", innerException);
			}
			if (responseContentType.Contains("text/html") && httpStatusCode != HttpStatusCode.OK)
			{
				throw new InternalServerException(text);
			}
			if (httpStatusCode != HttpStatusCode.OK && httpStatusCode != HttpStatusCode.Unauthorized && httpStatusCode != HttpStatusCode.InternalServerError)
			{
				throw new ProtocolException(string.Concat("Unexpected http response: ", httpStatusCode, "\n", text));
			}
			if (httpStatusCode == HttpStatusCode.OK && IsWebSealChallange(httpClient, text))
			{
				if (connection.CredentialManager.CredentialType != SoaConstants.CLIENT_CREDENTIAL_TYPE_SSO)
				{
					throw new InternalServerException("Can not authenticate against a WebSEAL server unless client is configured for SSO.");
				}
				UpdateWebSealCookies(httpClient);
				return ExecuteRequest(service, operation, requestBytes, servletURI);
			}
			return text;
		}
		catch (UriFormatException ex4)
		{
			throw new ProtocolException(ex4.Message);
		}
	}

	private bool IsWebSealChallange(HttpClient httpClient, string body)
	{
		string responseContentType = httpClient.ResponseContentType;
		string text = connection.GetOption(Connection.WEBSEAL_FORM_URL);
		if (text == null || text.Equals(""))
		{
			text = "<FORM METHOD=POST ACTION=\"/pkmslogin.form\">";
		}
		if (!responseContentType.Contains("text/html"))
		{
			return false;
		}
		string responseServerHeader = httpClient.ResponseServerHeader;
		if (responseServerHeader == null)
		{
			throw new ProtocolException("Received an unexpected response from the server, a 200 with Content-Type: text/html, but it does not have the Http header 'server:'.\n" + body);
		}
		if (!responseServerHeader.Contains("WebSEAL"))
		{
			throw new ProtocolException("Received an unexpected HTML response from the server\n" + body);
		}
		if (!body.Contains(text))
		{
			throw new ProtocolException("Received an unexpected response from the WebSEAL server, could not find the proper POST action.\n" + body);
		}
		return true;
	}

	public void UpdateWebSealCookies(HttpClient httpClient)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		string text;
		if (connection.CredentialManager is SsoCredentials)
		{
			SsoCredentials ssoCredentials = (SsoCredentials)connection.CredentialManager;
			text = ssoCredentials.SSOUrl;
		}
		else
		{
			text = connection.GetOption(Connection.OPT_SSO_LOGIN_URL);
			if (text.Length == 0)
			{
				text = Environment.GetEnvironmentVariable("TCSSO_LOGIN_SERVICE_URL");
				if (text == null || text.Length == 0)
				{
					string text2 = "Can not authenticate against a WebSEAL server unless configured for SSO.\n";
					text2 += "The client is not using SsoCredential class nor was the TCSSO_LOGIN_SERVICE_URL environment variable set.";
					throw new InternalServerException(text2);
				}
			}
		}
		Uri uri = new Uri(connection.HostPath);
		Dictionary<string, Cookie> dictionary = new Dictionary<string, Cookie>();
		Dictionary<string, Cookie> dictionary2 = new Dictionary<string, Cookie>();
		BasicTcSSOCookieManager val = new BasicTcSSOCookieManager();
		IList list = val.processFormChallenge((string)null, text, (IDictionary)null, (IDictionary)null);
		for (int i = 0; i < list.Count; i++)
		{
			HttpCookieToken val2 = (HttpCookieToken)list[i];
			string path = ((val2.getPath() == null) ? "/" : val2.getPath());
			Cookie cookie = new Cookie(val2.getName(), val2.getValue(), path, uri.Host);
			dictionary[cookie.Name] = cookie;
		}
		if (dictionary.Count == 0)
		{
			throw new InternalServerException("The SSO Client did not provide any Cookies.");
		}
		CookieCollection cookies = httpClient.Cookies;
		for (int i = 0; i < cookies.Count; i++)
		{
			Cookie cookie = cookies[i];
			dictionary2[cookie.Name] = cookie;
		}
		if (!hasNewCookies(dictionary, lastCookies))
		{
			throw new InternalServerException("The SSO Client failed to give us any cookies that satisfy the WebSEAL server.");
		}
		lastCookies = dictionary;
		if (!hasNewCookies(dictionary, dictionary2))
		{
			throw new InternalServerException("The SSO Client only gave us Cookies that we already have.");
		}
		foreach (string key in dictionary.Keys)
		{
			httpClient.Cookies.Add(dictionary[key]);
		}
	}

	private bool hasNewCookies(Dictionary<string, Cookie> newCookies, Dictionary<string, Cookie> oldCookies)
	{
		foreach (string key in newCookies.Keys)
		{
			if (!oldCookies.ContainsKey(key))
			{
				return true;
			}
			Cookie cookie = newCookies[key];
			Cookie cookie2 = oldCookies[key];
			if (!cookie.Value.Equals(cookie2.Value))
			{
				return true;
			}
		}
		return false;
	}
}
