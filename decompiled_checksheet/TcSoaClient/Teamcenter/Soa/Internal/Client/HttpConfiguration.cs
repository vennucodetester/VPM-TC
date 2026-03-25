using System;
using System.Net;
using System.Text;

namespace Teamcenter.Soa.Internal.Client;

public class HttpConfiguration
{
	private string ProxyServer = "";

	private int ProxyPort = 80;

	private string userName = null;

	private string userPassword = null;

	private string userAgent = "";

	private int timeout = -1;

	private int readWriteTimeout = -1;

	private bool useCompression = false;

	private string logCorrelationID = null;

	private bool caching = false;

	private string contentType = "application/x-www-form-urlencoded;charset=UTF-8";

	private bool keepAlive = true;

	private Encoding requestEncoding = Encoding.UTF8;

	private Encoding responseEncoding = Encoding.UTF8;

	public string PROXY_SERVER
	{
		get
		{
			return ProxyServer;
		}
		set
		{
			ProxyServer = value;
		}
	}

	public int PROXY_PORT
	{
		get
		{
			return ProxyPort;
		}
		set
		{
			ProxyPort = value;
		}
	}

	public string USER_NAME
	{
		get
		{
			return userName;
		}
		set
		{
			userName = value;
		}
	}

	public string USER_PASSWD
	{
		get
		{
			return userPassword;
		}
		set
		{
			userPassword = value;
		}
	}

	public string USER_AGENT
	{
		get
		{
			return userAgent;
		}
		set
		{
			userAgent = value;
		}
	}

	public int TIMEOUT
	{
		get
		{
			return timeout;
		}
		set
		{
			timeout = value;
		}
	}

	public int READWRITE_TIMEOUT
	{
		get
		{
			return readWriteTimeout;
		}
		set
		{
			timeout = value;
		}
	}

	public bool USE_COMPRESSION
	{
		get
		{
			return useCompression;
		}
		set
		{
			useCompression = value;
		}
	}

	public string LOG_CORRELATIONID
	{
		get
		{
			return logCorrelationID;
		}
		set
		{
			logCorrelationID = value;
		}
	}

	public bool CACHING
	{
		get
		{
			return caching;
		}
		set
		{
			caching = value;
		}
	}

	public Encoding REQUEST_ENCODING
	{
		get
		{
			return requestEncoding;
		}
		set
		{
			requestEncoding = value;
		}
	}

	public Encoding RESPONSE_ENCODING
	{
		get
		{
			return responseEncoding;
		}
		set
		{
			responseEncoding = value;
		}
	}

	public string CONTENT_TYPE => contentType;

	public bool KEEP_ALIVE
	{
		get
		{
			return keepAlive;
		}
		set
		{
			keepAlive = value;
		}
	}

	public bool ProxySet()
	{
		return ProxyServer.Length > 0;
	}

	public WebProxy GetProxy()
	{
		if (ProxySet())
		{
			return new WebProxy(ProxyServer, ProxyPort);
		}
		return null;
	}

	public bool IsUserNamePassWordSet()
	{
		return userName != null && userPassword != null;
	}

	public ICredentials GetCredentials(Uri URL)
	{
		if (IsUserNamePassWordSet())
		{
			NetworkCredential cred = new NetworkCredential(userName, userPassword);
			CredentialCache credentialCache = new CredentialCache();
			credentialCache.Add(URL, "Basic", cred);
			return credentialCache;
		}
		return CredentialCache.DefaultCredentials;
	}
}
