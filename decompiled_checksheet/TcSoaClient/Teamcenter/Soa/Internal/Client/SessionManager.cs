using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Teamcenter.Schemas.Core._2006_03.Session;
using Teamcenter.Schemas.Core._2007_01.Session;
using Teamcenter.Schemas.Core._2007_06.Session;
using Teamcenter.Schemas.Core._2007_12.Session;
using Teamcenter.Schemas.Core._2008_03.Session;
using Teamcenter.Schemas.Core._2008_06.Session;
using Teamcenter.Schemas.Core._2011_06.Session;
using Teamcenter.Schemas.Internal.Core._2007_05.Session;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Schemas.Soa._2006_09.Clientcontext;
using Teamcenter.Services.Loose.Core;
using Teamcenter.Services.Loose.Core._2007_12.Session;
using Teamcenter.Services.Loose.Core._2008_03.Session;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Common;
using Teamcenter.Soa.Common.Utils;
using Teamcenter.Soa.Exceptions;
using Teamcenter.Soa.Internal.Client.Model;
using Teamcenter.Soa.Internal.Common;
using log4net;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
public class SessionManager : ExceptionHandler
{
	private const string CONTEXT_NAMESPACE = "http://teamcenter.com/Schemas/Soa/2006-09/ClientContext";

	private static readonly string SESSION_0603_SERVICE = "Core-2006-03-Session";

	private static readonly string SESSION_0701_SERVICE = "Core-2007-01-Session";

	private static readonly string SESSION_0705_SERVICE = "Internal-Core-2007-05-Session";

	private static readonly string SESSION_0706_SERVICE = "Core-2007-06-Session";

	private static readonly string SESSION_0712_SERVICE = "Core-2007-12-Session";

	private static readonly string SESSION_0803_SERVICE = "Core-2008-03-Session";

	private static readonly string LOGOUT_METHOD_NAME = SESSION_0603_SERVICE + ".Logout";

	private static readonly string REFRESH_POM_METHOD_0706 = SESSION_0706_SERVICE + ".RefreshPOMCachePerRequest";

	private static readonly string REFRESH_POM_METHOD_0705 = SESSION_0705_SERVICE + ".RefreshPOMCachePerRequest";

	private static readonly string SETGROUPMEMBER_METHOD_NAME = SESSION_0603_SERVICE + ".SetSessionGroupMember";

	private static readonly string SET_DISPLAY_RULE_METHOD = SESSION_0712_SERVICE + ".SetAndEvaluateIdDisplayRule";

	private static readonly string SET_USERSESSION_STATE = SESSION_0712_SERVICE + ".SetUserSessionState";

	private static readonly string LICENSE_CONNECT = SESSION_0803_SERVICE + ".Connect";

	private static readonly string GET_TCSESSION_INFO_METHOD = SESSION_0701_SERVICE + ".GetTCSessionInfo";

	private static XmlBindingUtils xmlBindingUtils = new XmlBindingUtils();

	public static int connectionCount = 0;

	private string serializedUserId = "";

	private Dictionary<string, string> licenseTokens = new Dictionary<string, string>();

	private bool checkServerVersion = true;

	[NonSerialized]
	private CredentialManager cm;

	private Connection connection;

	private PolicyManager mPolicyManager = null;

	private Hashtable clientContextMap = new Hashtable();

	private string usrId = "Anonymous";

	private string serverVersion = "V0.0.0.0";

	private string hostName = "localhost";

	private bool clientIsRegisterd = false;

	private bool sentIP = false;

	private static ILog _logger = LogManager.GetLogger(typeof(SessionManager));

	protected string clientId = "AnonClient";

	private string locale = "";

	private string siteLocale = "";

	private bool clearPolicyForServerReAssign = false;

	private string loginDescrimator = "";

	private bool registeredTcMEM = false;

	private static bool firstPass = true;

	public static readonly string STATE_LOCALE = "locale";

	public static readonly string STATE_TIMEZONE = "timezone";

	public static readonly string STATE_ALLOW_PAGING = "allowPaging";

	public static readonly string STATE_BASE_SCHEMA_VERSION = "baseSchemaVersion";

	public static readonly string STATE_LOGCORRELATION_ID = "logCorrelationID";

	public static readonly string STATE_BYPASS_FLAG = "bypassFlag";

	public static readonly string STATE_ROLE = "role";

	public static readonly string STATE_GROUP = "group";

	public static readonly string STATE_GROUPMEMBER = "groupMember";

	public static readonly string STATE_CURRENT_PROJECT = "curentProject";

	public static readonly string STATE_WORK_CONTEXT = "workContext";

	public static readonly string STATE_VOLUME = "volume";

	public static readonly string STATE_LOCAL_VOLUME = "local_volume";

	public static readonly string STATE_REFRESH_POM = "refreshPOM";

	public static readonly string STATE_OBJ_PROP_POLICY = "objectPropertyPolicy";

	public static readonly string STATE_CURRENT_DISPLAY_RULE = "currentDisplayRule";

	public static readonly string STATE_SERVER_ID = "reqServerID";

	public static readonly string STATE_CLIENT_ID = "clientID";

	public static readonly string STATE_CLIENT_VERSION = "clientVersion";

	public static readonly string STATE_CLIENT_IP_ADDRESS = "clientIP";

	public static readonly string USER_SESSION_GROUP = "group";

	public static readonly string USER_SESSION_ROLE = "role";

	public static readonly string USER_SESSION_PROJECT = "project";

	public static readonly string USER_SESSION_WORKCTX = "workcontext";

	public static readonly string USER_SESSION_VOLUME = "volume";

	public static readonly string USER_SESSION_LOCAL_VOLUME = "fnd0LocalVolume";

	public static readonly string USER_SESSION_GROUPMEMBER = "fnd0groupmember";

	public static readonly string USER_SESSION_DISPLAYRULE = "fnd0displayrule";

	public static readonly string USER_SESSION_BYPASSFLAG = "fnd0bypassflag";

	public static readonly string USER_SESSION_ORGANIZATION = "fnd0organization";

	public static readonly string USER_SESSION_LOCALE = "fnd0locale";

	private static List<string> sharedUsFields = new List<string>();

	private static List<string> sharedRccFields = new List<string>();

	private bool useEnvelope = false;

	private bool enablePartialRcc = false;

	private bool firstRelogin = true;

	public CredentialManager CredentialManager
	{
		get
		{
			return cm;
		}
		set
		{
			cm = value;
		}
	}

	public PolicyManager PolicyManager => mPolicyManager;

	public string ClientID => clientId;

	public string ServerVersion => serverVersion;

	public string Locale => locale;

	public string SiteLocale => siteLocale;

	public SessionManager(CredentialManager cm, Connection connection)
	{
		this.connection = connection;
		this.cm = cm;
		mPolicyManager = new PolicyManager(connection);
		InitializeContext();
		ClientManager.ClientInfo clientInfo = ClientManager.ReserveClientId();
		hostName = clientInfo.mHostName;
		clientId = clientInfo.mClientId;
		loginDescrimator = hostName + ".SharedSession";
		connectionCount = clientInfo.mCount;
		SetState(STATE_CLIENT_ID, clientId);
		SetState(STATE_CLIENT_IP_ADDRESS, clientInfo.mIpAddress);
		if (firstPass)
		{
			sharedUsFields.Add(USER_SESSION_GROUPMEMBER);
			sharedUsFields.Add(USER_SESSION_PROJECT);
			sharedUsFields.Add(USER_SESSION_WORKCTX);
			sharedUsFields.Add(USER_SESSION_VOLUME);
			sharedUsFields.Add(USER_SESSION_LOCAL_VOLUME);
			sharedUsFields.Add(USER_SESSION_DISPLAYRULE);
			sharedUsFields.Add(USER_SESSION_BYPASSFLAG);
			sharedUsFields.Add(USER_SESSION_ORGANIZATION);
			sharedUsFields.Add(USER_SESSION_LOCALE);
			sharedRccFields.Add(STATE_GROUPMEMBER);
			sharedRccFields.Add(STATE_GROUP);
			sharedRccFields.Add(STATE_ROLE);
			sharedRccFields.Add(STATE_CURRENT_PROJECT);
			sharedRccFields.Add(STATE_WORK_CONTEXT);
			sharedRccFields.Add(STATE_BYPASS_FLAG);
			sharedRccFields.Add(STATE_LOCALE);
			sharedRccFields.Add(STATE_CURRENT_DISPLAY_RULE);
			firstPass = false;
		}
	}

	public void Login(Exception exception)
	{
		if (!firstRelogin && cm.CredentialType == SoaConstants.CLIENT_CREDENTIAL_TYPE_SSO)
		{
			throw new CanceledOperationException(exception.Message, exception);
		}
		firstRelogin = false;
		string[] credentials;
		if (exception is InvalidCredentialsException)
		{
			credentials = cm.GetCredentials((InvalidCredentialsException)exception);
		}
		else
		{
			if (!(exception is InvalidUserException))
			{
				throw new CanceledOperationException(exception.Message, exception);
			}
			credentials = cm.GetCredentials((InvalidUserException)exception);
		}
		try
		{
			SessionService service = SessionService.getService(connection);
			if (cm.CredentialType == SoaConstants.CLIENT_CREDENTIAL_TYPE_SSO)
			{
				service.LoginSSO(credentials[0], credentials[1], credentials[2], credentials[3], credentials[4]);
			}
			else
			{
				service.Login(credentials[0], credentials[1], credentials[2], credentials[3], credentials[4]);
			}
			firstRelogin = true;
		}
		catch (InvalidCredentialsException exception2)
		{
			Login(exception2);
		}
	}

	public void InitializeContext()
	{
		try
		{
			SetState(STATE_ALLOW_PAGING, flag: true);
			SetState(STATE_BASE_SCHEMA_VERSION, 2);
			TimeZone currentTimeZone = TimeZone.CurrentTimeZone;
			DateTime time = currentTimeZone.ToLocalTime(DateTime.Now);
			int value = (int)currentTimeZone.GetUtcOffset(time).TotalMilliseconds;
			SetState(STATE_TIMEZONE, value);
			SetState(STATE_CLIENT_VERSION, Teamcenter.Soa.Common.Version.TEAMCENTER_VERSION_LABLEL);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}

	public Hashtable GetStateMap()
	{
		return clientContextMap;
	}

	public void SetState(string name, bool flag)
	{
		if (!IsSharedRccField(name) || !enablePartialRcc)
		{
			clientContextMap[name] = flag;
		}
	}

	public void SetState(string name, string value)
	{
		if (!IsSharedRccField(name) || !enablePartialRcc)
		{
			if (value == null || value == "")
			{
				clientContextMap.Remove(name);
			}
			else
			{
				clientContextMap[name] = value;
			}
		}
	}

	public void SetState(string name, int value)
	{
		if (!IsSharedRccField(name) || !enablePartialRcc)
		{
			clientContextMap[name] = value;
		}
	}

	public string GetStringState(string name)
	{
		return (string)clientContextMap[name];
	}

	public string GetUserID()
	{
		return usrId;
	}

	public void SetSerializedUserName(string userId)
	{
		serializedUserId = userId;
	}

	public void ValidateUser(string service, string operation, object requestObject)
	{
		if (!serializedUserId.Equals("") && AuthUtils.IsLoginOperation(service, operation))
		{
			Credentials userCredentials = AuthUtils.GetUserCredentials(requestObject);
			string user = userCredentials.User;
			SetLocales(userCredentials.Locale, null);
			if (!serializedUserId.Equals(user))
			{
				throw new InvalidCredentialsException("Invalid user ID: A serialized connection file was used. Please login with user ID " + serializedUserId);
			}
		}
	}

	private bool CheckEnvelope(string xml)
	{
		if (!useEnvelope && !enablePartialRcc)
		{
			return true;
		}
		int startIndex = 1;
		if (xml.StartsWith("<?xml"))
		{
			startIndex = xml.IndexOf('<', 1) + 1;
		}
		string text = xml.Substring(startIndex, xml.IndexOf(' ', startIndex));
		int num = text.IndexOf(':');
		string text2 = ((num != -1) ? ("xmlns:" + text.Substring(0, num) + "=\"") : "xmlns=\"");
		startIndex = xml.IndexOf(text2, startIndex) + text2.Length;
		num = xml.IndexOf('"', startIndex);
		string text3 = xml.Substring(startIndex, num);
		return text3.StartsWith("http://teamcenter.com/Schemas/Soa/2006-09/ClientContext");
	}

	public string ConstructRequestEnvelope(string requestString)
	{
		if (CheckEnvelope(requestString))
		{
			return requestString;
		}
		RequestEnvelope requestEnvelope = new RequestEnvelope();
		RequestBody requestBody = new RequestBody();
		RequestHeader requestHeader = new RequestHeader();
		requestHeader = ConstructHeader();
		requestEnvelope.setHeader(requestHeader);
		requestBody.setBodystring(requestString);
		requestEnvelope.setBody(requestBody);
		byte[] chars = xmlBindingUtils.Serialize(requestEnvelope);
		return XmlBindingUtils.UTF8ByteArrayToString(chars);
	}

	private RequestHeader ConstructHeader()
	{
		RequestHeader requestHeader = new RequestHeader();
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		if (!clearPolicyForServerReAssign)
		{
			NameStringValue nameStringValue = new NameStringValue();
			nameStringValue.setName(STATE_OBJ_PROP_POLICY);
			nameStringValue.setValue(mPolicyManager.Active);
			arrayList3.Add(nameStringValue);
		}
		IDictionaryEnumerator enumerator = clientContextMap.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Value.GetType().ToString().Equals("System.String"))
				{
					NameStringValue nameStringValue = new NameStringValue();
					nameStringValue.setName((string)enumerator.Key);
					nameStringValue.setValue((string)enumerator.Value);
					arrayList3.Add(nameStringValue);
				}
				if (enumerator.Value.GetType().ToString().Equals("System.Boolean"))
				{
					NameBooleanValue nameBooleanValue = new NameBooleanValue();
					nameBooleanValue.setName((string)enumerator.Key);
					nameBooleanValue.setValue((bool)enumerator.Value);
					arrayList.Add(nameBooleanValue);
				}
				if (enumerator.Value.GetType().ToString().Equals("System.Int32"))
				{
					NameIntegerValue nameIntegerValue = new NameIntegerValue();
					nameIntegerValue.setName((string)enumerator.Key);
					nameIntegerValue.setValue((int)enumerator.Value);
					arrayList2.Add(nameIntegerValue);
				}
			}
			requestHeader.setStringState(arrayList3);
			requestHeader.setBooleanState(arrayList);
			requestHeader.setIntegerState(arrayList2);
		}
		catch (InvalidOperationException ex)
		{
			throw new InvalidOperationException(ex.Message);
		}
		return requestHeader;
	}

	public void CacheStateInformation(string service, string operation, object requestObject, object responseObject)
	{
		if (useEnvelope && !sentIP)
		{
			sentIP = true;
			SetState(STATE_CLIENT_IP_ADDRESS, "");
		}
		if (AuthUtils.IsLoginOperation(service, operation))
		{
			Credentials userCredentials = AuthUtils.GetUserCredentials(requestObject);
			CredentialManager.SetUserPassword(userCredentials.User, userCredentials.Password, userCredentials.Descrimator);
			CredentialManager.SetGroupRole(userCredentials.Group, userCredentials.Role);
			SetState(STATE_LOCALE, userCredentials.Locale);
			loginDescrimator = userCredentials.getDescrimator();
			usrId = userCredentials.User;
			SetLocales(userCredentials.Locale, null);
			if (responseObject is Teamcenter.Schemas.Core._2006_03.Session.LoginResponse)
			{
				Teamcenter.Schemas.Core._2006_03.Session.LoginResponse loginResponse = (Teamcenter.Schemas.Core._2006_03.Session.LoginResponse)responseObject;
				string uid = loginResponse.getGroupMember().getUid();
				SetState(STATE_GROUPMEMBER, uid);
			}
			if (responseObject is Teamcenter.Schemas.Core._2011_06.Session.LoginResponse)
			{
				Teamcenter.Schemas.Core._2011_06.Session.LoginResponse loginResponse2 = (Teamcenter.Schemas.Core._2011_06.Session.LoginResponse)responseObject;
				checkServerVersion = false;
				useEnvelope = true;
				Hashtable hashtable = new Hashtable();
				ServerInfo[] serverInfo = loginResponse2.ServerInfo;
				for (int i = 0; i < serverInfo.Length; i++)
				{
					hashtable[serverInfo[i].Key] = serverInfo[i].Value;
				}
				SetLocales((string)hashtable["Locale"], (string)hashtable["SiteLocale"]);
				ILog logger = LogManager.GetLogger(typeof(Connection));
				logger.Info(string.Concat("\nServer Information:\n    Version:   ", hashtable["Version"], "\n    Host Name: ", hashtable["HostName"], "\n    Log File:  ", hashtable["LogFile"], "\n    Locale:    ", hashtable["Locale"]));
				string value = (string)hashtable["TcServerID"];
				SetState(STATE_SERVER_ID, value);
				if (hashtable.ContainsKey("UserID"))
				{
					usrId = (string)hashtable["UserID"];
				}
				serverVersion = (string)hashtable["Version"];
				RegisterWithTcMEM();
			}
		}
		mPolicyManager.CacheStateInformation(service, operation, requestObject, responseObject);
		string text = service + "." + operation;
		if (text.Equals(SETGROUPMEMBER_METHOD_NAME))
		{
			SetSessionGroupMemberInput setSessionGroupMemberInput = (SetSessionGroupMemberInput)requestObject;
			string uid = setSessionGroupMemberInput.getGroupMember().getUid();
			SetState(STATE_GROUPMEMBER, uid);
			SetState(STATE_GROUP, "");
			SetState(STATE_ROLE, "");
		}
		if (text.Equals(LOGOUT_METHOD_NAME))
		{
			((EventSharerImpl)connection.EventSharer).UnregisterTcMEM();
			ClientManager.UnregisterClient(clientId);
			clientIsRegisterd = false;
		}
		else if (!clientIsRegisterd)
		{
			ClientManager.RegisterClient(clientId);
			clientIsRegisterd = true;
		}
		if (text.Equals(REFRESH_POM_METHOD_0706))
		{
			Teamcenter.Schemas.Core._2007_06.Session.RefreshPOMCachePerRequestInput refreshPOMCachePerRequestInput = (Teamcenter.Schemas.Core._2007_06.Session.RefreshPOMCachePerRequestInput)requestObject;
			SetState(STATE_REFRESH_POM, refreshPOMCachePerRequestInput.getRefresh());
		}
		if (text.Equals(REFRESH_POM_METHOD_0705))
		{
			Teamcenter.Schemas.Internal.Core._2007_05.Session.RefreshPOMCachePerRequestInput refreshPOMCachePerRequestInput2 = (Teamcenter.Schemas.Internal.Core._2007_05.Session.RefreshPOMCachePerRequestInput)requestObject;
			SetState(STATE_REFRESH_POM, refreshPOMCachePerRequestInput2.getRefresh());
		}
		if (text.Equals(SET_DISPLAY_RULE_METHOD))
		{
			SetAndEvaluateIdDisplayRuleInput setAndEvaluateIdDisplayRuleInput = (SetAndEvaluateIdDisplayRuleInput)requestObject;
			if (setAndEvaluateIdDisplayRuleInput.DisplayRule == null)
			{
				SetState(STATE_CURRENT_DISPLAY_RULE, "");
			}
			else
			{
				SetState(STATE_CURRENT_DISPLAY_RULE, setAndEvaluateIdDisplayRuleInput.DisplayRule.Uid);
			}
		}
		if (text.Equals(SET_USERSESSION_STATE))
		{
			SetUserSessionStateInput setUserSessionStateInput = (SetUserSessionStateInput)requestObject;
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData serviceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)responseObject;
			ArrayList partialErrors = serviceData.getPartialErrors();
			Teamcenter.Schemas.Core._2007_12.Session.StateNameValue[] pairs = setUserSessionStateInput.Pairs;
			foreach (Teamcenter.Schemas.Core._2007_12.Session.StateNameValue stateNameValue in pairs)
			{
				string name = stateNameValue.getName();
				bool flag = true;
				for (int j = 0; j < partialErrors.Count; j++)
				{
					Teamcenter.Schemas.Soa._2006_03.Base.ErrorStack errorStack = (Teamcenter.Schemas.Soa._2006_03.Base.ErrorStack)partialErrors[j];
					if (errorStack.getClientId().Equals(name))
					{
						flag = false;
					}
				}
				if (flag)
				{
					SetState(name, stateNameValue.getValue());
				}
			}
		}
		if (text.Equals(LICENSE_CONNECT))
		{
			ConnectInput connectInput = (ConnectInput)requestObject;
			Teamcenter.Schemas.Core._2008_03.Session.ConnectResponse connectResponse = (Teamcenter.Schemas.Core._2008_03.Session.ConnectResponse)responseObject;
			ArrayList partialErrors = connectResponse.getServiceData().getPartialErrors();
			if (partialErrors.Count.Equals(0))
			{
				if (connectInput.getAction().Contains("init"))
				{
					if (!licenseTokens.ContainsValue(connectInput.getFeatureKey()))
					{
						licenseTokens.Add(connectInput.getFeatureKey(), connectInput.getFeatureKey());
					}
				}
				else if (connectInput.getAction().Contains("release"))
				{
					licenseTokens.Remove(connectInput.getFeatureKey());
				}
				else if (connectInput.getAction().Contains("exit"))
				{
					licenseTokens.Clear();
				}
			}
		}
		if (text.Equals(GET_TCSESSION_INFO_METHOD))
		{
			GetTCSessionInfoResponse getTCSessionInfoResponse = (GetTCSessionInfoResponse)responseObject;
			ArrayList extraInfo = getTCSessionInfoResponse.getExtraInfo();
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (ExtraInfo item in extraInfo)
			{
				dictionary[item.Key] = item.Value;
			}
			string value = dictionary["TcServerID"];
			SetState(STATE_SERVER_ID, value);
			serverVersion = getTCSessionInfoResponse.ServerVersion;
			Teamcenter.Soa.Common.Version version = new Teamcenter.Soa.Common.Version(serverVersion);
			useEnvelope = true;
			SetLocales(dictionary["TCServerLocale"], null);
			Teamcenter.Soa.Common.Version version2 = new Teamcenter.Soa.Common.Version(9000, 0, 0);
			if (version >= version2)
			{
				enablePartialRcc = true;
				RemoveSharedFieldsFromContext();
			}
			ILog logger = LogManager.GetLogger(typeof(Connection));
			logger.Info("\nServer Information:\n    Type:      " + dictionary["systemType"] + "\n    Version:   " + serverVersion + "\n    Host Name: " + dictionary["hostName"] + "\n    Log File:  " + dictionary["syslogFile"] + "\n    Locale:    " + dictionary["TCServerLocale"]);
		}
		else
		{
			GetServerInfo();
		}
	}

	private void GetServerInfo()
	{
		if (checkServerVersion)
		{
			checkServerVersion = false;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			connection.ExceptionHandler = this;
			SessionService service = SessionService.getService(connection);
			Teamcenter.Soa.Client.Model.ModelObject user = service.GetTCSessionInfo().User;
			try
			{
				usrId = user.GetProperty("user_id").StringValue;
			}
			catch (NotLoadedException)
			{
				_logger.Warn("Did not get the user_id from the TcSessionInfo. Will use the login input value.");
			}
			RegisterWithTcMEM();
			connection.ExceptionHandler = exceptionHandler;
		}
	}

	private void RegisterWithTcMEM()
	{
		if (!registeredTcMEM)
		{
			registeredTcMEM = true;
			string text = "";
			EventSharerImpl eventSharerImpl = (EventSharerImpl)connection.EventSharer;
			eventSharerImpl.RegisterWithTcMEM(usrId, loginDescrimator, clientId, text);
		}
	}

	private void RemoveSharedFieldsFromContext()
	{
		for (int i = 0; i < sharedRccFields.Count; i++)
		{
			string key = sharedRccFields[i];
			if (clientContextMap.Contains(key))
			{
				clientContextMap.Remove(key);
			}
		}
	}

	private void SetLocales(string iLocale, string iSiteLocale)
	{
		if (iLocale != null)
		{
			if (locale.Length == 0 || iLocale.Length > 0)
			{
				locale = iLocale;
			}
			if (iSiteLocale != null && iSiteLocale.Length > 0)
			{
				siteLocale = iSiteLocale;
			}
			else
			{
				siteLocale = locale;
			}
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void ResetServer()
	{
		SessionService service = SessionService.getService(connection);
		clearPolicyForServerReAssign = true;
		SetState(STATE_SERVER_ID, "");
		checkServerVersion = true;
		GetServerInfo();
		mPolicyManager.RestoreServerPolicies();
		clearPolicyForServerReAssign = false;
		SetSharedSessionState();
		string text = "";
		foreach (KeyValuePair<string, string> licenseToken in licenseTokens)
		{
			Teamcenter.Services.Loose.Core._2008_03.Session.ConnectResponse connectResponse = service.Connect(licenseToken.Key, "init_get");
			text += CheckForPartialErrors(connectResponse.ServiceData);
		}
		if (!text.Equals(""))
		{
			throw new InternalServerException(text);
		}
	}

	private string CheckForPartialErrors(Teamcenter.Soa.Client.Model.ServiceData serviceData)
	{
		string text = "";
		int num = serviceData.sizeOfPartialErrors();
		for (int i = 0; i < num; i++)
		{
			string text2 = serviceData.GetPartialError(i).ClientId;
			text = text + "\nclient id: " + text2 + "\n";
			string[] messages = serviceData.GetPartialError(i).Messages;
			int[] levels = serviceData.GetPartialError(i).Levels;
			int[] codes = serviceData.GetPartialError(i).Codes;
			for (int j = 0; j < messages.Length; j++)
			{
				object obj = text;
				text = string.Concat(obj, "\tLevel: ", levels[j], "\tCode: ", codes[j], "\tMessage: ", messages[j]);
				text += "\n";
			}
			text += "\n";
		}
		return text;
	}

	public void HandleException(InternalServerException ise)
	{
		throw new OldServerException();
	}

	public void HandleException(CanceledOperationException coe)
	{
		throw new OldServerException();
	}

	public object ModifyInput(string service, string operation, object requestObject)
	{
		if (requestObject is UpdateObjectPropertyPolicyInput)
		{
			UpdateObjectPropertyPolicyInput updateObjectPropertyPolicyInput = (UpdateObjectPropertyPolicyInput)requestObject;
			updateObjectPropertyPolicyInput.PolicyID = mPolicyManager.GetRealId(updateObjectPropertyPolicyInput.PolicyID);
			return updateObjectPropertyPolicyInput;
		}
		if (!connection.GetOption(Connection.OPT_SHARED_DISCRIMINATOR).Equals("true"))
		{
			return requestObject;
		}
		if (AuthUtils.IsLoginOperation(service, operation))
		{
			if (requestObject is Teamcenter.Schemas.Core._2006_03.Session.LoginInput)
			{
				Teamcenter.Schemas.Core._2006_03.Session.LoginInput loginInput = (Teamcenter.Schemas.Core._2006_03.Session.LoginInput)requestObject;
				loginInput.setSessionDiscriminator(hostName + ".SharedSession");
				return loginInput;
			}
			if (requestObject is Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput)
			{
				Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput loginSSOInput = (Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput)requestObject;
				loginSSOInput.setSessionDiscriminator(hostName + ".SharedSession");
				return loginSSOInput;
			}
			if (requestObject is Teamcenter.Schemas.Core._2008_06.Session.LoginInput)
			{
				Teamcenter.Schemas.Core._2008_06.Session.LoginInput loginInput2 = (Teamcenter.Schemas.Core._2008_06.Session.LoginInput)requestObject;
				loginInput2.setSessionDiscriminator(hostName + ".SharedSession");
				return loginInput2;
			}
			if (requestObject is Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput)
			{
				Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput loginSSOInput2 = (Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput)requestObject;
				loginSSOInput2.setSessionDiscriminator(hostName + ".SharedSession");
				return loginSSOInput2;
			}
			if (requestObject is Teamcenter.Schemas.Core._2011_06.Session.LoginInput)
			{
				Teamcenter.Schemas.Core._2011_06.Session.LoginInput loginInput3 = (Teamcenter.Schemas.Core._2011_06.Session.LoginInput)requestObject;
				loginInput3.Credentials.Descrimator = hostName + ".SharedSession";
				return loginInput3;
			}
			if (requestObject is Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput)
			{
				Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput loginSSOInput3 = (Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput)requestObject;
				loginSSOInput3.Credentials.Descrimator = hostName + ".SharedSession";
				return loginSSOInput3;
			}
		}
		return requestObject;
	}

	private bool IsSharedUsField(string name)
	{
		return sharedUsFields.Contains(name);
	}

	private bool IsSharedRccField(string name)
	{
		return sharedRccFields.Contains(name);
	}

	private void SetSharedSessionState()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			Teamcenter.Services.Loose.Core._2007_12.Session.StateNameValue[] array = null;
			Teamcenter.Soa.Client.Model.ModelObject userSessionObject = connection.ModelManager.GetUserSessionObject();
			if (userSessionObject != null)
			{
				for (int i = 0; i < userSessionObject.PropertyNames.Length; i++)
				{
					string name = userSessionObject.PropertyNames[i];
					if (!IsSharedUsField(name))
					{
						continue;
					}
					try
					{
						PropertyImpl property = (PropertyImpl)userSessionObject.GetProperty(name);
						string text = PropertyImpl.RetrievePropertyValue(property);
						if (!IsEmpty(text))
						{
							Teamcenter.Services.Loose.Core._2007_12.Session.StateNameValue stateNameValue = new Teamcenter.Services.Loose.Core._2007_12.Session.StateNameValue();
							stateNameValue.Name = name;
							stateNameValue.Value = text;
							arrayList.Add(stateNameValue);
						}
					}
					catch (ArgumentException)
					{
					}
					catch (NotLoadedException ex2)
					{
						_logger.Warn("Property not get loaded.\n" + ex2.Message);
					}
				}
			}
			if (arrayList.Count > 0)
			{
				array = new Teamcenter.Services.Loose.Core._2007_12.Session.StateNameValue[arrayList.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = new Teamcenter.Services.Loose.Core._2007_12.Session.StateNameValue();
					array[i] = (Teamcenter.Services.Loose.Core._2007_12.Session.StateNameValue)arrayList[i];
				}
				SessionService service = SessionService.getService(connection);
				Teamcenter.Soa.Client.Model.ServiceData serviceData = service.SetUserSessionState(array);
				string text2 = "";
				text2 = CheckForPartialErrors(serviceData);
				if (!text2.Equals(""))
				{
					throw new InternalServerException(text2);
				}
			}
		}
		catch (ServiceException ex3)
		{
			_logger.Info("UserSession is not set on the reassigned Server." + ex3.Message);
		}
	}

	private bool IsEmpty(string name)
	{
		if (name.Length <= 0)
		{
			return true;
		}
		return false;
	}
}
