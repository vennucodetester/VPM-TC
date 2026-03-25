using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using Teamcenter.Net.TcServerProxy.Admin;
using Teamcenter.Net.TcServerProxy.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Common;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;
using log4net;

namespace Teamcenter.Soa.Client;

[Serializable]
public class Connection : ISerializable, IDeserializationCallback
{
	[Serializable]
	private class ListenerNotifier : NotifyRequestListeners
	{
		public void NotifyRequestListeners(ServiceInfo requestInfo)
		{
			try
			{
				if (requestListeners == null)
				{
					return;
				}
				requestListeners.GetEnumerator();
				foreach (KeyValuePair<RequestListener, RequestListener> requestListener in requestListeners)
				{
					RequestListener value = requestListener.Value;
					value.ServiceRequest(requestInfo);
				}
			}
			catch (Exception exception)
			{
				if (logger != null)
				{
					logger.Warn("Error calling RequestListener", exception);
				}
			}
		}

		public void NotifyResponseListeners(ServiceInfo responseInfo)
		{
			try
			{
				if (requestListeners == null)
				{
					return;
				}
				requestListeners.GetEnumerator();
				foreach (KeyValuePair<RequestListener, RequestListener> requestListener in requestListeners)
				{
					RequestListener value = requestListener.Value;
					value.ServiceResponse(responseInfo);
				}
			}
			catch (Exception exception)
			{
				if (logger != null)
				{
					logger.Warn("Error calling ResponseListener", exception);
				}
			}
		}
	}

	private static ILog logger = null;

	public static readonly string OPT_USE_COMPRESSION = "OPT_USE_COMPRESSION";

	public static readonly string OPT_READ_WRITE_TIMEOUT = "OPT_READ_WRITE_TIMEOUT";

	public static readonly string OPT_TIMEOUT = "OPT_TIMEOUT";

	public static readonly string OPT_SERVER_REASSIGNMENT = "OPT_SERVER_REASSIGNMENT";

	public static readonly string OPT_CACHE_MODEL_OBJECTS = "OPT_CACHE_MODEL_OBJECTS";

	public static readonly string WEBSEAL_FORM_URL = "WEBSEAL_FORM_URL";

	public static readonly string OPT_SSO_LOGIN_URL = "OPT_SSO_LOGIN_URL";

	public static readonly string TCCS_ENV_NAME = "TCCS_ENV_NAME";

	public static readonly string TCCS_HOST_URL = "TCCS_HOST_URL";

	public static readonly string TCCS_USE_CALLBACK = "Use-Callback";

	public static readonly string TCCS_SESSION_ID = "SessionID";

	public static readonly string OPT_SHARED_EVENTS = "OPT_SHARED_EVENTS";

	public static readonly string OPT_SHARED_DISCRIMINATOR = "OPT_SHARED_DISCRIMINATOR";

	public static readonly string OPT_USE_CLIENT_META_MODEL_CACHE = "OPT_USE_CLIENT_META_MODEL_CACHE";

	public static readonly string JSON_TUNNEL_BINDING = "JsonTunnel";

	private static Hashtable userSessions = new Hashtable();

	private static readonly string OPTION_KEY = "OPTION_KEY";

	private static readonly string OPTION_VALUE = "OPTION_VALUE";

	private static readonly string RESTSENDER = "RESTSENDER";

	private static readonly string SESSIONMANAGER = "SESSIONMANAGER";

	private static readonly string HOSTPATH = "HOSTPATH";

	private static readonly string COOKIE = "COOKIE";

	private static readonly string BINDINGS = "BINDINGS";

	private static readonly string PROTOCOL = "PROTOCOL";

	private static EnvironmentInfoWrapper tccsEnvInfo = null;

	private SessionManager sessionManager;

	private TSPSession tspSession;

	private CookieCollection cookieCollection;

	private string hostPath;

	private string protocol;

	private string binding;

	private CredentialProvider proxyCredentialProvider;

	private Hashtable options = new Hashtable();

	[NonSerialized]
	private Hashtable overridOptions = new Hashtable();

	[NonSerialized]
	private ExceptionHandler iseHandler = new DefaultExceptionHandler();

	[NonSerialized]
	protected EventSharerImpl eventSharer;

	protected Sender sender;

	[NonSerialized]
	protected ModelManagerImpl modelManager;

	private SerializationInfo _savedSI;

	protected Transport m_transport;

	[NonSerialized]
	protected NotifyRequestListeners m_notifier;

	private static Dictionary<RequestListener, RequestListener> requestListeners = new Dictionary<RequestListener, RequestListener>();

	public ExceptionHandler ExceptionHandler
	{
		get
		{
			return iseHandler;
		}
		set
		{
			iseHandler = value;
		}
	}

	public string Binding => binding;

	public CookieCollection Cookies => cookieCollection;

	public string HostPath => hostPath;

	public EventSharer EventSharer => eventSharer;

	public ModelManager ModelManager => modelManager;

	public ClientDataModel ClientDataModel => modelManager.ClientDataModel;

	public ClientMetaModel ClientMetaModel => modelManager.ClientMetaModel;

	public CredentialManager CredentialManager
	{
		get
		{
			return sessionManager.CredentialManager;
		}
		set
		{
			sessionManager.CredentialManager = value;
		}
	}

	public string Protocol => protocol;

	public Sender Sender
	{
		get
		{
			if (sender == null)
			{
				throw new ArgumentException("The protocol " + protocol + ", is not supported.");
			}
			return sender;
		}
	}

	public ObjectPropertyPolicyManager ObjectPropertyPolicyManager => sessionManager.PolicyManager;

	[Obsolete("Use ObjectPropertyPolicyManager")]
	public string CurrentObjectPropertyPolicy => sessionManager.PolicyManager.CurrentPolicy;

	[Obsolete("Use ObjectPropertyPolicyManager")]
	public string PreviousObjectPropertyPolicy => sessionManager.PolicyManager.PreviousPolicy;

	public Teamcenter.Soa.Common.Version ClientVersion => new Teamcenter.Soa.Common.Version(Teamcenter.Soa.Common.Version.TEAMCENTER_VERSION);

	public Teamcenter.Soa.Common.Version ServerVersion => new Teamcenter.Soa.Common.Version(sessionManager.ServerVersion);

	public string Locale => sessionManager.Locale;

	public string SiteLocale => sessionManager.SiteLocale;

	private Connection()
	{
	}

	public Connection(string hostPath, CookieCollection cookieCollection, CredentialManager credentialManager, string binding, string protocol, bool useCompression)
	{
		if (logger == null)
		{
			logger = LogManager.GetLogger(typeof(Connection));
			if (logger.IsInfoEnabled)
			{
				AddRequestListener(new Log4NetRequestListener(logger));
			}
		}
		this.hostPath = (hostPath.EndsWith("/") ? hostPath : (hostPath + "/"));
		if (cookieCollection == null)
		{
			this.cookieCollection = new CookieCollection();
		}
		else
		{
			this.cookieCollection = cookieCollection;
		}
		this.binding = binding;
		this.protocol = protocol;
		setDefaultOptions();
		options[OPT_USE_COMPRESSION] = (useCompression ? "true" : "false");
		eventSharer = new EventSharerImpl(this);
		modelManager = new ModelManagerImpl(this, null);
		sessionManager = new SessionManager(credentialManager, this);
		m_notifier = new ListenerNotifier();
		CreateSender(hostPath, protocol);
		logger.Info("Teamcenter Services Client Version: " + Teamcenter.Soa.Common.Version.TEAMCENTER_VERSION_LABLEL);
	}

	private void CreateSender(string hostPath, string protocol)
	{
		if (protocol.Equals(SoaConstants.HTTP))
		{
			this.hostPath = (hostPath.EndsWith("/") ? hostPath : (hostPath + "/"));
			m_transport = new HttpTransport(this);
			sender = new XmlRestSender(this, sessionManager, m_transport, m_notifier);
		}
		else if (protocol.Equals(SoaConstants.TCCS))
		{
			this.hostPath = "";
			tspSession = new TSPSession();
			m_transport = new TccsTransport(this, sessionManager);
			sender = new XmlRestSender(this, sessionManager, m_transport, m_notifier);
		}
		else
		{
			sender = null;
			m_transport = null;
		}
	}

	private Connection(SerializationInfo info, StreamingContext context)
	{
		binding = info.GetString(BINDINGS);
		hostPath = info.GetString(HOSTPATH);
		protocol = info.GetString(PROTOCOL);
		cookieCollection = (CookieCollection)info.GetValue(COOKIE, typeof(CookieCollection));
		sessionManager = (SessionManager)info.GetValue(SESSIONMANAGER, typeof(SessionManager));
		sender = (Sender)info.GetValue(RESTSENDER, typeof(Sender));
		_savedSI = info;
	}

	public Connection(CredentialManager credentialManager, string fileName)
	{
		if (logger == null)
		{
			logger = LogManager.GetLogger(typeof(Connection));
			if (logger.IsInfoEnabled)
			{
				AddRequestListener(new Log4NetRequestListener(logger));
			}
		}
		Hashtable hashtable = new Hashtable();
		if (!fileName.Equals(""))
		{
			string text = "";
			string value = null;
			try
			{
				TextReader textReader = new StreamReader(fileName);
				bool flag = true;
				for (string text2 = textReader.ReadLine(); text2 != null; text2 = textReader.ReadLine())
				{
					if (flag)
					{
						value = text2;
						flag = false;
					}
					else
					{
						string[] array = text2.Trim().Split('=');
						string key = array[0].Trim();
						string text3 = "";
						if (array.Length > 1)
						{
							text3 = array[1];
						}
						hashtable[key] = text3.Trim();
						text = text + text2 + "\n";
					}
				}
				textReader.Close();
			}
			catch (IOException ex)
			{
				throw new IOException("Error reading serialized connection object file" + ex.ToString());
			}
			if (!md5Hash(text).Equals(value))
			{
				throw new IOException("The content of the serialized connection file (" + fileName + ") has been corrupted/changed since it was saved. Or the file was saved prior to the 10.1.3 release, and is no longer supported.");
			}
			cookieCollection = new CookieCollection();
			hostPath = hashtable["soa.host"].ToString();
			protocol = hashtable["soa.protocol"].ToString();
			binding = hashtable["soa.binding"].ToString();
			eventSharer = new EventSharerImpl(this);
			modelManager = new ModelManagerImpl(this, null);
			setDefaultOptions();
			options[OPT_USE_COMPRESSION] = hashtable["soa.compression"].ToString();
			if (hashtable["soa.readWriteTimeout"] != null)
			{
				options[OPT_READ_WRITE_TIMEOUT] = hashtable["soa.readWriteTimeout"].ToString();
			}
			else
			{
				options[OPT_READ_WRITE_TIMEOUT] = (-1).ToString();
			}
			if (hashtable["soa.timeout"] != null)
			{
				options[OPT_TIMEOUT] = hashtable["soa.timeout"].ToString();
			}
			else
			{
				options[OPT_TIMEOUT] = (-1).ToString();
			}
			if (hashtable["soa.useClientMetaModelCache"] != null)
			{
				options[OPT_USE_CLIENT_META_MODEL_CACHE] = hashtable["soa.useClientMetaModelCache"].ToString();
			}
			sessionManager = new SessionManager(credentialManager, this);
			setSessionState(sessionManager, hashtable);
			sessionManager.SetSerializedUserName(hashtable["soa.userid"].ToString());
			m_notifier = new ListenerNotifier();
			CreateSender(hostPath, protocol);
			if (protocol.Equals(SoaConstants.TCCS))
			{
				SetOption(TCCS_ENV_NAME, (string)hashtable["soa.tccsEnvName"]);
				SetOption(TCCS_SESSION_ID, (string)hashtable["soa.sessionId"]);
			}
			logger.Info("Teamcenter Services Client Version: " + Teamcenter.Soa.Common.Version.TEAMCENTER_VERSION_LABLEL);
			return;
		}
		throw new IOException("Invalid input file name");
	}

	public void Serialize(string fileName)
	{
		try
		{
			string text = "";
			text = text + "soa.host = " + HostPath + "\n";
			text = text + "soa.protocol = " + Protocol + "\n";
			text = text + "soa.binding = " + Binding + "\n";
			text = text + "soa.compression = " + GetOption(OPT_USE_COMPRESSION) + "\n";
			text = text + "soa.readWriteTimeout = " + GetOption(OPT_READ_WRITE_TIMEOUT) + "\n";
			text = text + "soa.timeout = " + GetOption(OPT_TIMEOUT) + "\n";
			text = text + "soa.useClientMetaModelCache = " + GetOption(OPT_USE_CLIENT_META_MODEL_CACHE) + "\n";
			if (protocol.Equals(SoaConstants.TCCS))
			{
				text = text + "soa.tccsEnvName = " + GetOption(TCCS_ENV_NAME) + "\n";
				text = text + "soa.sessionId = " + GetOption(TCCS_SESSION_ID) + "\n";
			}
			text += outSessionState();
			string text2 = md5Hash(text);
			TextWriter textWriter = new StreamWriter(fileName);
			textWriter.Write(text2 + "\n");
			textWriter.Write(text);
			textWriter.Close();
		}
		catch (IOException ex)
		{
			throw new IOException("Error writing serialized connection object file" + ex.ToString());
		}
	}

	public static void AddRequestListener(RequestListener listener)
	{
		requestListeners[listener] = listener;
	}

	public static void RemoveRequestListener(RequestListener listener)
	{
		requestListeners.Remove(listener);
	}

	public Sender GetAlternateSender(string altBinding)
	{
		Sender result = null;
		if (!string.IsNullOrEmpty(altBinding) && altBinding.Equals(JSON_TUNNEL_BINDING) && sender != null)
		{
			Transport transport = sender.getTransport();
			if (transport != null)
			{
				JsonTunnelSender jsonTunnelSender = new JsonTunnelSender(this, sessionManager, transport, m_notifier);
				result = jsonTunnelSender;
			}
		}
		return result;
	}

	public string getServerAddress()
	{
		string result = "";
		if (protocol.Equals(SoaConstants.HTTP))
		{
			result = HostPath;
		}
		else if (protocol.Equals(SoaConstants.TCCS))
		{
			try
			{
				Teamcenter.Net.TcServerProxy.Admin.Environment environment = getEnvironment(GetOption(TCCS_ENV_NAME));
				result = environment.GetService("tcserver").GetProperty("endpoint");
			}
			catch (TSPException)
			{
				result = "TCCS:" + GetOption(TCCS_ENV_NAME);
			}
		}
		return result;
	}

	[Obsolete("Use ObjectPropertyPolicyManager")]
	public ObjectPropertyPolicy GetObjectPropertyPolicy(string name)
	{
		return sessionManager.PolicyManager.GetPolicy(name);
	}

	private void setDefaultOption(string key, string value)
	{
		options[key] = value;
		string environmentVariable = System.Environment.GetEnvironmentVariable(key);
		if (environmentVariable != null)
		{
			overridOptions[key] = environmentVariable;
		}
	}

	private void setDefaultOptions()
	{
		setDefaultOption(OPT_USE_COMPRESSION, "true");
		setDefaultOption(OPT_READ_WRITE_TIMEOUT, (-1).ToString());
		setDefaultOption(OPT_TIMEOUT, (-1).ToString());
		setDefaultOption(OPT_SERVER_REASSIGNMENT, "false");
		setDefaultOption(OPT_CACHE_MODEL_OBJECTS, "true");
		setDefaultOption(WEBSEAL_FORM_URL, "<FORM METHOD=POST ACTION=\"/pkmslogin.form\">");
		setDefaultOption(OPT_SSO_LOGIN_URL, "");
		setDefaultOption(TCCS_ENV_NAME, "");
		setDefaultOption(TCCS_SESSION_ID, "");
		setDefaultOption(TCCS_USE_CALLBACK, "false");
		setDefaultOption(OPT_SHARED_EVENTS, "false");
		setDefaultOption(OPT_SHARED_DISCRIMINATOR, "false");
		setDefaultOption(OPT_USE_CLIENT_META_MODEL_CACHE, "false");
	}

	[Obsolete("Use ObjectPropertyPolicyManager")]
	public void SetObjectPropertyPolicy(string policyName)
	{
		sessionManager.PolicyManager.AddPolicy(policyName, PolicyStyle.Fixed);
		sessionManager.PolicyManager.SetPolicy(policyName);
	}

	[Obsolete("Use ObjectPropertyPolicyManager")]
	public void SetObjectPropertyPolicyPerThread(string policyName)
	{
		sessionManager.PolicyManager.AddPolicy(policyName, PolicyStyle.Fixed);
		sessionManager.PolicyManager.SetPolicyPerThread(policyName);
	}

	[Obsolete("Use ObjectPropertyPolicyManager")]
	public void ClearObjectPropertyPolicyPerThread()
	{
		sessionManager.PolicyManager.ClearPolicyPerThread();
	}

	public void SetOption(string optionName, string value)
	{
		options[optionName] = value;
		if (optionName.Equals(OPT_SHARED_DISCRIMINATOR) && value.ToLower().Equals("true"))
		{
			options[OPT_SHARED_EVENTS] = "true";
		}
	}

	public string GetOption(string optionName)
	{
		if (overridOptions.ContainsKey(optionName))
		{
			return (string)overridOptions[optionName];
		}
		return (string)options[optionName];
	}

	public Hashtable getSessionState()
	{
		Hashtable stateMap = sessionManager.GetStateMap();
		Hashtable hashtable = new Hashtable();
		IDictionaryEnumerator enumerator = stateMap.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string key = enumerator.Key.ToString();
			string value = enumerator.Value.ToString();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	private string outSessionState()
	{
		string text = "";
		Hashtable stateMap = sessionManager.GetStateMap();
		text = text + "soa.session.currentPolicy = " + ObjectPropertyPolicyManager.CurrentPolicy + "\n";
		text = text + "soa.session.previousPolicy = " + ObjectPropertyPolicyManager.PreviousPolicy + "\n";
		text = text + "soa.userid = " + sessionManager.GetUserID() + "\n";
		IDictionaryEnumerator enumerator = stateMap.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string text2 = enumerator.Key.ToString();
			if (!enumerator.Value.Equals(null))
			{
				if (enumerator.Value is int)
				{
					string text3 = text;
					text = text3 + "soa.session." + text2 + ".Integer = " + enumerator.Value.ToString() + "\n";
				}
				else if (enumerator.Value is bool)
				{
					string text3 = text;
					text = text3 + "soa.session." + text2 + ".Boolean = " + enumerator.Value.ToString() + "\n";
				}
				else if (enumerator.Value is string && !text2.Equals("logCorrelationID"))
				{
					string text3 = text;
					text = text3 + "soa.session." + text2 + ".String = " + enumerator.Value.ToString() + "\n";
				}
			}
		}
		return text;
	}

	private void setSessionState(SessionManager sessionManager, Hashtable attr)
	{
		sessionManager.PolicyManager.Initialize(attr["soa.session.currentPolicy"].ToString(), attr["soa.session.previousPolicy"].ToString());
		IDictionaryEnumerator enumerator = attr.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string text = enumerator.Key.ToString();
			string text2 = enumerator.Value.ToString();
			string[] array = text.Split('.');
			if (array.Length > 3)
			{
				if (array[3].Equals("Integer"))
				{
					int value = Convert.ToInt32(text2);
					sessionManager.SetState(array[2], value);
				}
				else if (array[3].Equals("Boolean"))
				{
					bool flag = (text2.Equals("True") ? true : false);
					sessionManager.SetState(array[2], flag);
				}
				else if (array[3].Equals("String"))
				{
					sessionManager.SetState(array[2], text2);
				}
			}
		}
	}

	private string md5Hash(string s)
	{
		byte[] array = new byte[1];
		byte[] array2 = array;
		MD5 mD = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.Default.GetBytes(s);
		byte[] array3 = mD.ComputeHash(bytes);
		string text = "";
		for (int i = 0; i < array3.Length; i++)
		{
			array2[0] = array3[i];
			text += BitConverter.ToString(array2);
		}
		return text.ToLower();
	}

	private void SerializeOptionTable(SerializationInfo info)
	{
		try
		{
			object[] array = new object[options.Count];
			object[] array2 = new object[options.Count];
			IDictionaryEnumerator enumerator = options.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				array[num] = enumerator.Key;
				array2[num] = enumerator.Value;
				num++;
			}
			info.AddValue(OPTION_KEY, array);
			info.AddValue(OPTION_VALUE, array2);
		}
		catch (InvalidOperationException ex)
		{
			throw new InvalidOperationException(ex.Message);
		}
	}

	private void DeserializeOptionTable()
	{
		try
		{
			object[] array = (object[])_savedSI.GetValue(OPTION_KEY, typeof(object));
			object[] array2 = (object[])_savedSI.GetValue(OPTION_VALUE, typeof(object));
			for (int i = 0; i < array.Length; i++)
			{
				options.Add(array[i], array2[i]);
			}
		}
		catch (InvalidCastException ex)
		{
			throw new InvalidCastException(ex.Message);
		}
		catch (ArgumentNullException ex2)
		{
			throw new ArgumentNullException(ex2.Message);
		}
	}

	public void SetProxyCredentialProvider(CredentialProvider credProvider)
	{
		proxyCredentialProvider = credProvider;
	}

	public CredentialProvider GetProxyCredentialProvider()
	{
		return proxyCredentialProvider;
	}

	public TSPSession GetTSPSession()
	{
		if (tspSession == null)
		{
			tspSession = new TSPSession();
		}
		return tspSession;
	}

	public static ArrayList getEnvironments()
	{
		if (tccsEnvInfo == null)
		{
			tccsEnvInfo = new EnvironmentInfoWrapper();
		}
		return tccsEnvInfo.GetEnvironments();
	}

	public static ArrayList getEnvsForVersion(string expression)
	{
		if (tccsEnvInfo == null)
		{
			tccsEnvInfo = new EnvironmentInfoWrapper();
		}
		return tccsEnvInfo.GetEnvsForVersion(expression);
	}

	public static Teamcenter.Net.TcServerProxy.Admin.Environment getEnvironment(string envName)
	{
		if (tccsEnvInfo == null)
		{
			tccsEnvInfo = new EnvironmentInfoWrapper();
		}
		return tccsEnvInfo.GetEnvironment(envName);
	}

	public static ArrayList getEnvironmentsForURL(string URL)
	{
		if (tccsEnvInfo == null)
		{
			tccsEnvInfo = new EnvironmentInfoWrapper();
		}
		return tccsEnvInfo.GetEnvironmentsForURL(URL);
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		userSessions[sessionManager.ClientID] = modelManager.GetUserSessionObject();
		info.AddValue(BINDINGS, Binding);
		info.AddValue(COOKIE, Cookies);
		info.AddValue(HOSTPATH, HostPath);
		info.AddValue(PROTOCOL, Protocol);
		info.AddValue(SESSIONMANAGER, sessionManager);
		info.AddValue(RESTSENDER, sender);
		SerializeOptionTable(info);
	}

	public void OnDeserialization(object sender)
	{
		DeserializeOptionTable();
		eventSharer = new EventSharerImpl(this);
		modelManager = new ModelManagerImpl(this, (ModelObject)userSessions[sessionManager.ClientID]);
		_savedSI = null;
		userSessions.Remove(sessionManager.ClientID);
		m_notifier = new ListenerNotifier();
	}
}
