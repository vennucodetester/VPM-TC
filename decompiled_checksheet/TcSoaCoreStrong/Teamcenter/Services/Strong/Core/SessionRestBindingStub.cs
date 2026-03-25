using System;
using System.Collections;
using Teamcenter.Schemas.Core._2006_03.Session;
using Teamcenter.Schemas.Core._2007_01.Session;
using Teamcenter.Schemas.Core._2007_06.Session;
using Teamcenter.Schemas.Core._2007_12.Session;
using Teamcenter.Schemas.Core._2008_03.Session;
using Teamcenter.Schemas.Core._2008_06.Session;
using Teamcenter.Schemas.Core._2009_04.Session;
using Teamcenter.Schemas.Core._2010_04.Session;
using Teamcenter.Schemas.Core._2011_06.Session;
using Teamcenter.Schemas.Core._2012_02.Session;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Schemas.Soa._2011_06.Metamodel;
using Teamcenter.Services.Strong.Core._2006_03.Session;
using Teamcenter.Services.Strong.Core._2007_01.Session;
using Teamcenter.Services.Strong.Core._2007_12.Session;
using Teamcenter.Services.Strong.Core._2008_03.Session;
using Teamcenter.Services.Strong.Core._2008_06.Session;
using Teamcenter.Services.Strong.Core._2010_04.Session;
using Teamcenter.Services.Strong.Core._2011_06.Session;
using Teamcenter.Services.Strong.Core._2012_02.Session;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Common;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;
using Teamcenter.Soa.Internal.Common;

namespace Teamcenter.Services.Strong.Core;

public class SessionRestBindingStub : SessionService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string SESSION_200603_PORT_NAME = "Core-2006-03-Session";

	private static readonly string SESSION_200701_PORT_NAME = "Core-2007-01-Session";

	private static readonly string SESSION_200706_PORT_NAME = "Core-2007-06-Session";

	private static readonly string SESSION_200712_PORT_NAME = "Core-2007-12-Session";

	private static readonly string SESSION_200803_PORT_NAME = "Core-2008-03-Session";

	private static readonly string SESSION_200806_PORT_NAME = "Core-2008-06-Session";

	private static readonly string SESSION_200904_PORT_NAME = "Core-2009-04-Session";

	private static readonly string SESSION_201004_PORT_NAME = "Core-2010-04-Session";

	private static readonly string SESSION_201106_PORT_NAME = "Core-2011-06-Session";

	private static readonly string SESSION_201202_PORT_NAME = "Core-2012-02-Session";

	public SessionRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2006_03.Session.GetAvailableServicesResponse toWire(Teamcenter.Services.Strong.Core._2006_03.Session.GetAvailableServicesResponse local)
	{
		Teamcenter.Schemas.Core._2006_03.Session.GetAvailableServicesResponse getAvailableServicesResponse = new Teamcenter.Schemas.Core._2006_03.Session.GetAvailableServicesResponse();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.ServiceNames.Length; i++)
		{
			arrayList.Add(local.ServiceNames[i]);
		}
		getAvailableServicesResponse.setServiceNames(arrayList);
		return getAvailableServicesResponse;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Session.GetAvailableServicesResponse toLocal(Teamcenter.Schemas.Core._2006_03.Session.GetAvailableServicesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Session.GetAvailableServicesResponse getAvailableServicesResponse = new Teamcenter.Services.Strong.Core._2006_03.Session.GetAvailableServicesResponse();
		IList serviceNames = wire.getServiceNames();
		getAvailableServicesResponse.ServiceNames = new string[serviceNames.Count];
		for (int i = 0; i < serviceNames.Count; i++)
		{
			getAvailableServicesResponse.ServiceNames[i] = Convert.ToString(serviceNames[i]);
		}
		return getAvailableServicesResponse;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Session.GetGroupMembershipResponse toLocal(Teamcenter.Schemas.Core._2006_03.Session.GetGroupMembershipResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Session.GetGroupMembershipResponse getGroupMembershipResponse = new Teamcenter.Services.Strong.Core._2006_03.Session.GetGroupMembershipResponse();
		getGroupMembershipResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList groupMembers = wire.getGroupMembers();
		getGroupMembershipResponse.GroupMembers = new GroupMember[groupMembers.Count];
		for (int i = 0; i < groupMembers.Count; i++)
		{
			getGroupMembershipResponse.GroupMembers[i] = (GroupMember)modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)groupMembers[i]);
		}
		return getGroupMembershipResponse;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Session.GetSessionGroupMemberResponse toLocal(Teamcenter.Schemas.Core._2006_03.Session.GetSessionGroupMemberResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Session.GetSessionGroupMemberResponse getSessionGroupMemberResponse = new Teamcenter.Services.Strong.Core._2006_03.Session.GetSessionGroupMemberResponse();
		getSessionGroupMemberResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getSessionGroupMemberResponse.GroupMember = (GroupMember)modelManager.LoadObjectData(wire.getGroupMember());
		return getSessionGroupMemberResponse;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse toLocal(Teamcenter.Schemas.Core._2006_03.Session.LoginResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse loginResponse = new Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse();
		loginResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		loginResponse.User = (User)modelManager.LoadObjectData(wire.getUser());
		loginResponse.GroupMember = (GroupMember)modelManager.LoadObjectData(wire.getGroupMember());
		return loginResponse;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Session.PreferencesResponse toLocal(Teamcenter.Schemas.Core._2006_03.Session.PreferencesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Session.PreferencesResponse preferencesResponse = new Teamcenter.Services.Strong.Core._2006_03.Session.PreferencesResponse();
		preferencesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		preferencesResponse.Preferences = modelManager.LoadPreferences(wire.getPreferences());
		return preferencesResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Session.PrefSetting toWire(Teamcenter.Services.Strong.Core._2006_03.Session.PrefSetting local)
	{
		Teamcenter.Schemas.Core._2006_03.Session.PrefSetting prefSetting = new Teamcenter.Schemas.Core._2006_03.Session.PrefSetting();
		prefSetting.setPrefScope(local.PrefScope);
		prefSetting.setPrefName(local.PrefName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PrefValues.Length; i++)
		{
			arrayList.Add(local.PrefValues[i]);
		}
		prefSetting.setPrefValues(arrayList);
		return prefSetting;
	}

	public static Teamcenter.Services.Strong.Core._2006_03.Session.PrefSetting toLocal(Teamcenter.Schemas.Core._2006_03.Session.PrefSetting wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2006_03.Session.PrefSetting prefSetting = new Teamcenter.Services.Strong.Core._2006_03.Session.PrefSetting();
		prefSetting.PrefScope = wire.getPrefScope();
		prefSetting.PrefName = wire.getPrefName();
		IList prefValues = wire.getPrefValues();
		prefSetting.PrefValues = new string[prefValues.Count];
		for (int i = 0; i < prefValues.Count; i++)
		{
			prefSetting.PrefValues[i] = Convert.ToString(prefValues[i]);
		}
		return prefSetting;
	}

	[Obsolete("As of tceng2005sr1, use the getPreferences operation from the _2007_01 namespace.", false)]
	public override Teamcenter.Services.Strong.Core._2006_03.Session.PreferencesResponse GetPreferences(string PrefScope, string[] PrefNames)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2006_03.Session.GetPreferencesInput getPreferencesInput = new Teamcenter.Schemas.Core._2006_03.Session.GetPreferencesInput();
			getPreferencesInput.setPrefScope(PrefScope);
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < PrefNames.Length; i++)
			{
				arrayList.Add(PrefNames[i]);
			}
			getPreferencesInput.setPrefNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.PreferencesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "GetPreferences", getPreferencesInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.PreferencesResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.PreferencesResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.PreferencesResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	[Obsolete("As of Teamcenter 10, use the setPreferences operation from the PreferenceManagement service in the Administration library.", false)]
	public override Teamcenter.Services.Strong.Core._2006_03.Session.PreferencesResponse SetPreferences(Teamcenter.Services.Strong.Core._2006_03.Session.PrefSetting[] Settings)
	{
		try
		{
			restSender.PushRequestId();
			SetPreferencesInput setPreferencesInput = new SetPreferencesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Settings.Length; i++)
			{
				arrayList.Add(toWire(Settings[i]));
			}
			setPreferencesInput.setSettings(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.PreferencesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "SetPreferences", setPreferencesInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.PreferencesResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.PreferencesResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.PreferencesResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2006_03.Session.GetAvailableServicesResponse GetAvailableServices()
	{
		try
		{
			restSender.PushRequestId();
			GetAvailableServicesInput requestObject = new GetAvailableServicesInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.GetAvailableServicesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "GetAvailableServices", requestObject, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Session.GetAvailableServicesResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.GetAvailableServicesResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.GetAvailableServicesResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2006_03.Session.GetGroupMembershipResponse GetGroupMembership()
	{
		try
		{
			restSender.PushRequestId();
			GetGroupMembershipInput requestObject = new GetGroupMembershipInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.GetGroupMembershipResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "GetGroupMembership", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.GetGroupMembershipResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.GetGroupMembershipResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.GetGroupMembershipResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2006_03.Session.GetSessionGroupMemberResponse GetSessionGroupMember()
	{
		try
		{
			restSender.PushRequestId();
			GetSessionGroupMemberInput requestObject = new GetSessionGroupMemberInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.GetSessionGroupMemberResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "GetSessionGroupMember", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.GetSessionGroupMemberResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.GetSessionGroupMemberResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.GetSessionGroupMemberResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	[Obsolete("As of Teamcenter 10, use the login operation from the _2008_06 namespace.", false)]
	public override Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse Login(string Username, string Password, string Group, string Role, string SessionDiscriminator)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2006_03.Session.LoginInput loginInput = new Teamcenter.Schemas.Core._2006_03.Session.LoginInput();
			loginInput.setUsername(Username);
			loginInput.setPassword(Password);
			loginInput.setGroup(Group);
			loginInput.setRole(Role);
			loginInput.setSessionDiscriminator(SessionDiscriminator);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.LoginResponse);
			Type[] array = null;
			array = new Type[1] { typeof(InvalidCredentialsException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "Login", loginInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is InvalidCredentialsException)
			{
				throw (InvalidCredentialsException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.LoginResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.LoginResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	[Obsolete("As of Teamcenter 10, use the loginSSO operation from the _2008_06 namespace.", false)]
	public override Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse LoginSSO(string Username, string SsoCredentials, string Group, string Role, string SessionDiscriminator)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput loginSSOInput = new Teamcenter.Schemas.Core._2006_03.Session.LoginSSOInput();
			loginSSOInput.setUsername(Username);
			loginSSOInput.setSsoCredentials(SsoCredentials);
			loginSSOInput.setGroup(Group);
			loginSSOInput.setRole(Role);
			loginSSOInput.setSessionDiscriminator(SessionDiscriminator);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.LoginResponse);
			Type[] array = null;
			array = new Type[1] { typeof(InvalidCredentialsException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "LoginSSO", loginSSOInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is InvalidCredentialsException)
			{
				throw (InvalidCredentialsException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.LoginResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.LoginResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Soa.Client.Model.ServiceData Logout()
	{
		try
		{
			restSender.PushRequestId();
			LogoutInput requestObject = new LogoutInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "Logout", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Soa.Client.Model.ServiceData SetSessionGroupMember(GroupMember GroupMember)
	{
		try
		{
			restSender.PushRequestId();
			SetSessionGroupMemberInput setSessionGroupMemberInput = new SetSessionGroupMemberInput();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (GroupMember == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(GroupMember.Uid);
			}
			setSessionGroupMemberInput.setGroupMember(modelObject);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200603_PORT_NAME, "SetSessionGroupMember", setSessionGroupMemberInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Services.Strong.Core._2007_01.Session.GetTCSessionInfoResponse toLocal(Teamcenter.Schemas.Core._2007_01.Session.GetTCSessionInfoResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.Session.GetTCSessionInfoResponse getTCSessionInfoResponse = new Teamcenter.Services.Strong.Core._2007_01.Session.GetTCSessionInfoResponse();
		getTCSessionInfoResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getTCSessionInfoResponse.ServerVersion = wire.getServerVersion();
		getTCSessionInfoResponse.TransientVolRootDir = wire.getTransientVolRootDir();
		getTCSessionInfoResponse.IsInV7Mode = wire.IsInV7Mode;
		getTCSessionInfoResponse.ModuleNumber = wire.getModuleNumber();
		getTCSessionInfoResponse.User = (User)modelManager.LoadObjectData(wire.getUser());
		getTCSessionInfoResponse.Group = (Group)modelManager.LoadObjectData(wire.getGroup());
		getTCSessionInfoResponse.Role = (Role)modelManager.LoadObjectData(wire.getRole());
		getTCSessionInfoResponse.TcVolume = (ImanVolume)modelManager.LoadObjectData(wire.getTcVolume());
		getTCSessionInfoResponse.Project = (TC_Project)modelManager.LoadObjectData(wire.getProject());
		getTCSessionInfoResponse.WorkContext = (TC_WorkContext)modelManager.LoadObjectData(wire.getWorkContext());
		getTCSessionInfoResponse.Site = (POM_imc)modelManager.LoadObjectData(wire.getSite());
		getTCSessionInfoResponse.Bypass = wire.Bypass;
		getTCSessionInfoResponse.Journaling = wire.Journaling;
		getTCSessionInfoResponse.AppJournaling = wire.AppJournaling;
		getTCSessionInfoResponse.SecJournaling = wire.SecJournaling;
		getTCSessionInfoResponse.AdmJournaling = wire.AdmJournaling;
		getTCSessionInfoResponse.Privileged = wire.Privileged;
		getTCSessionInfoResponse.IsPartBOMUsageEnabled = wire.IsPartBOMUsageEnabled;
		getTCSessionInfoResponse.IsSubscriptionMgrEnabled = wire.IsSubscriptionMgrEnabled;
		IList textInfos = wire.getTextInfos();
		getTCSessionInfoResponse.TextInfos = new Teamcenter.Services.Strong.Core._2007_01.Session.TextInfo[textInfos.Count];
		for (int i = 0; i < textInfos.Count; i++)
		{
			getTCSessionInfoResponse.TextInfos[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Session.TextInfo)textInfos[i], modelManager);
		}
		getTCSessionInfoResponse.ExtraInfo = toLocalExtraInfo(wire.getExtraInfo(), modelManager);
		return getTCSessionInfoResponse;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.Session.MultiPreferencesResponse toLocal(Teamcenter.Schemas.Core._2007_01.Session.MultiPreferencesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.Session.MultiPreferencesResponse multiPreferencesResponse = new Teamcenter.Services.Strong.Core._2007_01.Session.MultiPreferencesResponse();
		multiPreferencesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList preferences = wire.getPreferences();
		multiPreferencesResponse.Preferences = new Teamcenter.Services.Strong.Core._2007_01.Session.ReturnedPreferences[preferences.Count];
		for (int i = 0; i < preferences.Count; i++)
		{
			multiPreferencesResponse.Preferences[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Session.ReturnedPreferences)preferences[i], modelManager);
		}
		return multiPreferencesResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Session.ReturnedPreferences toWire(Teamcenter.Services.Strong.Core._2007_01.Session.ReturnedPreferences local)
	{
		Teamcenter.Schemas.Core._2007_01.Session.ReturnedPreferences returnedPreferences = new Teamcenter.Schemas.Core._2007_01.Session.ReturnedPreferences();
		returnedPreferences.setName(local.Name);
		returnedPreferences.setScope(local.Scope);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		returnedPreferences.setValues(arrayList);
		return returnedPreferences;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.Session.ReturnedPreferences toLocal(Teamcenter.Schemas.Core._2007_01.Session.ReturnedPreferences wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.Session.ReturnedPreferences returnedPreferences = new Teamcenter.Services.Strong.Core._2007_01.Session.ReturnedPreferences();
		returnedPreferences.Name = wire.getName();
		returnedPreferences.Scope = wire.getScope();
		IList values = wire.getValues();
		returnedPreferences.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			returnedPreferences.Values[i] = Convert.ToString(values[i]);
		}
		return returnedPreferences;
	}

	public static Teamcenter.Schemas.Core._2007_01.Session.ScopedPreferenceNames toWire(Teamcenter.Services.Strong.Core._2007_01.Session.ScopedPreferenceNames local)
	{
		Teamcenter.Schemas.Core._2007_01.Session.ScopedPreferenceNames scopedPreferenceNames = new Teamcenter.Schemas.Core._2007_01.Session.ScopedPreferenceNames();
		scopedPreferenceNames.setScope(local.Scope);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Names.Length; i++)
		{
			arrayList.Add(local.Names[i]);
		}
		scopedPreferenceNames.setNames(arrayList);
		return scopedPreferenceNames;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.Session.ScopedPreferenceNames toLocal(Teamcenter.Schemas.Core._2007_01.Session.ScopedPreferenceNames wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.Session.ScopedPreferenceNames scopedPreferenceNames = new Teamcenter.Services.Strong.Core._2007_01.Session.ScopedPreferenceNames();
		scopedPreferenceNames.Scope = wire.getScope();
		IList names = wire.getNames();
		scopedPreferenceNames.Names = new string[names.Count];
		for (int i = 0; i < names.Count; i++)
		{
			scopedPreferenceNames.Names[i] = Convert.ToString(names[i]);
		}
		return scopedPreferenceNames;
	}

	public static Teamcenter.Schemas.Core._2007_01.Session.TextInfo toWire(Teamcenter.Services.Strong.Core._2007_01.Session.TextInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Session.TextInfo textInfo = new Teamcenter.Schemas.Core._2007_01.Session.TextInfo();
		textInfo.setRealName(local.RealName);
		textInfo.setDisplayName(local.DisplayName);
		return textInfo;
	}

	public static Teamcenter.Services.Strong.Core._2007_01.Session.TextInfo toLocal(Teamcenter.Schemas.Core._2007_01.Session.TextInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_01.Session.TextInfo textInfo = new Teamcenter.Services.Strong.Core._2007_01.Session.TextInfo();
		textInfo.RealName = wire.getRealName();
		textInfo.DisplayName = wire.getDisplayName();
		return textInfo;
	}

	public static ArrayList toWireExtraInfo(IDictionary ExtraInfo)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ExtraInfo)
		{
			object key = item.Key;
			object value = item.Value;
			ExtraInfo extraInfo = new ExtraInfo();
			extraInfo.setKey(Convert.ToString(key));
			extraInfo.setValue(Convert.ToString(value));
			arrayList.Add(extraInfo);
		}
		return arrayList;
	}

	public static Hashtable toLocalExtraInfo(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ExtraInfo extraInfo = (ExtraInfo)wire[i];
			string key = extraInfo.getKey();
			string value = extraInfo.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	[Obsolete("As of Teamcenter 10, use the getPreferences operation from the PreferenceManagement service in the Administration library.", false)]
	public override Teamcenter.Services.Strong.Core._2007_01.Session.MultiPreferencesResponse GetPreferences(Teamcenter.Services.Strong.Core._2007_01.Session.ScopedPreferenceNames[] RequestedPrefs)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_01.Session.GetPreferencesInput getPreferencesInput = new Teamcenter.Schemas.Core._2007_01.Session.GetPreferencesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < RequestedPrefs.Length; i++)
			{
				arrayList.Add(toWire(RequestedPrefs[i]));
			}
			getPreferencesInput.setRequestedPrefs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Session.MultiPreferencesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200701_PORT_NAME, "GetPreferences", getPreferencesInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2007_01.Session.MultiPreferencesResponse wire = (Teamcenter.Schemas.Core._2007_01.Session.MultiPreferencesResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.Session.MultiPreferencesResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2007_01.Session.GetTCSessionInfoResponse GetTCSessionInfo()
	{
		try
		{
			restSender.PushRequestId();
			GetTCSessionInfoInput requestObject = new GetTCSessionInfoInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Session.GetTCSessionInfoResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200701_PORT_NAME, "GetTCSessionInfo", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2007_01.Session.GetTCSessionInfoResponse wire = (Teamcenter.Schemas.Core._2007_01.Session.GetTCSessionInfoResponse)obj;
			Teamcenter.Services.Strong.Core._2007_01.Session.GetTCSessionInfoResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override bool SetObjectPropertyPolicy(string PolicyName)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2007_01.Session.SetObjectPropertyPolicyInput setObjectPropertyPolicyInput = new Teamcenter.Schemas.Core._2007_01.Session.SetObjectPropertyPolicyInput();
			setObjectPropertyPolicyInput.setPolicyName(PolicyName);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Session.SetObjectPropertyPolicyOutput);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200701_PORT_NAME, "SetObjectPropertyPolicy", setObjectPropertyPolicyInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2007_01.Session.SetObjectPropertyPolicyOutput setObjectPropertyPolicyOutput = (Teamcenter.Schemas.Core._2007_01.Session.SetObjectPropertyPolicyOutput)obj;
			bool result = setObjectPropertyPolicyOutput.Out;
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override bool RefreshPOMCachePerRequest(bool Refresh)
	{
		try
		{
			restSender.PushRequestId();
			RefreshPOMCachePerRequestInput refreshPOMCachePerRequestInput = new RefreshPOMCachePerRequestInput();
			refreshPOMCachePerRequestInput.setRefresh(Refresh);
			Type typeFromHandle = typeof(RefreshPOMCachePerRequestOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200706_PORT_NAME, "RefreshPOMCachePerRequest", refreshPOMCachePerRequestInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			RefreshPOMCachePerRequestOutput refreshPOMCachePerRequestOutput = (RefreshPOMCachePerRequestOutput)obj;
			bool result = refreshPOMCachePerRequestOutput.Out;
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Core._2007_12.Session.StateNameValue toWire(Teamcenter.Services.Strong.Core._2007_12.Session.StateNameValue local)
	{
		Teamcenter.Schemas.Core._2007_12.Session.StateNameValue stateNameValue = new Teamcenter.Schemas.Core._2007_12.Session.StateNameValue();
		stateNameValue.setName(local.Name);
		stateNameValue.setValue(local.Value);
		return stateNameValue;
	}

	public static Teamcenter.Services.Strong.Core._2007_12.Session.StateNameValue toLocal(Teamcenter.Schemas.Core._2007_12.Session.StateNameValue wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2007_12.Session.StateNameValue stateNameValue = new Teamcenter.Services.Strong.Core._2007_12.Session.StateNameValue();
		stateNameValue.Name = wire.getName();
		stateNameValue.Value = wire.getValue();
		return stateNameValue;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData SetAndEvaluateIdDisplayRule(Teamcenter.Soa.Client.Model.ModelObject[] IdentifiableObjects, IdDispRule DisplayRule, bool SetRuleAsCurrentInDB)
	{
		try
		{
			restSender.PushRequestId();
			SetAndEvaluateIdDisplayRuleInput setAndEvaluateIdDisplayRuleInput = new SetAndEvaluateIdDisplayRuleInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < IdentifiableObjects.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (IdentifiableObjects[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(IdentifiableObjects[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			setAndEvaluateIdDisplayRuleInput.setIdentifiableObjects(arrayList);
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (DisplayRule == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(DisplayRule.Uid);
			}
			setAndEvaluateIdDisplayRuleInput.setDisplayRule(modelObject2);
			setAndEvaluateIdDisplayRuleInput.setSetRuleAsCurrentInDB(SetRuleAsCurrentInDB);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200712_PORT_NAME, "SetAndEvaluateIdDisplayRule", setAndEvaluateIdDisplayRuleInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Soa.Client.Model.ServiceData SetUserSessionState(Teamcenter.Services.Strong.Core._2007_12.Session.StateNameValue[] Pairs)
	{
		try
		{
			restSender.PushRequestId();
			SetUserSessionStateInput setUserSessionStateInput = new SetUserSessionStateInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Pairs.Length; i++)
			{
				arrayList.Add(toWire(Pairs[i]));
			}
			setUserSessionStateInput.setPairs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200712_PORT_NAME, "SetUserSessionState", setUserSessionStateInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Services.Strong.Core._2008_03.Session.ConnectResponse toLocal(Teamcenter.Schemas.Core._2008_03.Session.ConnectResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_03.Session.ConnectResponse connectResponse = new Teamcenter.Services.Strong.Core._2008_03.Session.ConnectResponse();
		connectResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		connectResponse.OutputVal = wire.getOutputVal();
		return connectResponse;
	}

	public static Teamcenter.Schemas.Core._2008_03.Session.FavoritesContainer toWire(Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesContainer local)
	{
		Teamcenter.Schemas.Core._2008_03.Session.FavoritesContainer favoritesContainer = new Teamcenter.Schemas.Core._2008_03.Session.FavoritesContainer();
		favoritesContainer.setClientId(local.ClientId);
		favoritesContainer.setId(local.Id);
		favoritesContainer.setType(local.Type);
		favoritesContainer.setDisplayName(local.DisplayName);
		favoritesContainer.setParentId(local.ParentId);
		return favoritesContainer;
	}

	public static Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesContainer toLocal(Teamcenter.Schemas.Core._2008_03.Session.FavoritesContainer wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesContainer favoritesContainer = new Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesContainer();
		favoritesContainer.ClientId = wire.getClientId();
		favoritesContainer.Id = wire.getId();
		favoritesContainer.Type = wire.getType();
		favoritesContainer.DisplayName = wire.getDisplayName();
		favoritesContainer.ParentId = wire.getParentId();
		return favoritesContainer;
	}

	public static Teamcenter.Schemas.Core._2008_03.Session.FavoritesList toWire(Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesList local)
	{
		Teamcenter.Schemas.Core._2008_03.Session.FavoritesList favoritesList = new Teamcenter.Schemas.Core._2008_03.Session.FavoritesList();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Containers.Length; i++)
		{
			arrayList.Add(toWire(local.Containers[i]));
		}
		favoritesList.setContainers(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.Objects.Length; i++)
		{
			arrayList2.Add(toWire(local.Objects[i]));
		}
		favoritesList.setObjects(arrayList2);
		return favoritesList;
	}

	public static Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesList toLocal(Teamcenter.Schemas.Core._2008_03.Session.FavoritesList wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesList favoritesList = new Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesList();
		IList containers = wire.getContainers();
		favoritesList.Containers = new Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesContainer[containers.Count];
		for (int i = 0; i < containers.Count; i++)
		{
			favoritesList.Containers[i] = toLocal((Teamcenter.Schemas.Core._2008_03.Session.FavoritesContainer)containers[i], modelManager);
		}
		IList objects = wire.getObjects();
		favoritesList.Objects = new Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesObject[objects.Count];
		for (int i = 0; i < objects.Count; i++)
		{
			favoritesList.Objects[i] = toLocal((Teamcenter.Schemas.Core._2008_03.Session.FavoritesObject)objects[i], modelManager);
		}
		return favoritesList;
	}

	public static Teamcenter.Schemas.Core._2008_03.Session.FavoritesInfo toWire(Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesInfo local)
	{
		Teamcenter.Schemas.Core._2008_03.Session.FavoritesInfo favoritesInfo = new Teamcenter.Schemas.Core._2008_03.Session.FavoritesInfo();
		favoritesInfo.setCurFavorites(toWire(local.CurFavorites));
		favoritesInfo.setNewFavorites(toWire(local.NewFavorites));
		return favoritesInfo;
	}

	public static Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesInfo toLocal(Teamcenter.Schemas.Core._2008_03.Session.FavoritesInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesInfo favoritesInfo = new Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesInfo();
		favoritesInfo.CurFavorites = toLocal(wire.getCurFavorites(), modelManager);
		favoritesInfo.NewFavorites = toLocal(wire.getNewFavorites(), modelManager);
		return favoritesInfo;
	}

	public static Teamcenter.Schemas.Core._2008_03.Session.FavoritesObject toWire(Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesObject local)
	{
		Teamcenter.Schemas.Core._2008_03.Session.FavoritesObject favoritesObject = new Teamcenter.Schemas.Core._2008_03.Session.FavoritesObject();
		favoritesObject.setClientId(local.ClientId);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ObjectTag == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ObjectTag.Uid);
		}
		favoritesObject.setObjectTag(modelObject);
		favoritesObject.setDisplayName(local.DisplayName);
		favoritesObject.setParentId(local.ParentId);
		return favoritesObject;
	}

	public static Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesObject toLocal(Teamcenter.Schemas.Core._2008_03.Session.FavoritesObject wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesObject favoritesObject = new Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesObject();
		favoritesObject.ClientId = wire.getClientId();
		favoritesObject.ObjectTag = modelManager.LoadObjectData(wire.getObjectTag());
		favoritesObject.DisplayName = wire.getDisplayName();
		favoritesObject.ParentId = wire.getParentId();
		return favoritesObject;
	}

	public static Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesResponse toLocal(Teamcenter.Schemas.Core._2008_03.Session.FavoritesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesResponse favoritesResponse = new Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesResponse();
		favoritesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		favoritesResponse.Output = toLocal(wire.getOutput(), modelManager);
		return favoritesResponse;
	}

	public override Teamcenter.Services.Strong.Core._2008_03.Session.ConnectResponse Connect(string FeatureKey, string Action)
	{
		try
		{
			restSender.PushRequestId();
			ConnectInput connectInput = new ConnectInput();
			connectInput.setFeatureKey(FeatureKey);
			connectInput.setAction(Action);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_03.Session.ConnectResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200803_PORT_NAME, "Connect", connectInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_03.Session.ConnectResponse wire = (Teamcenter.Schemas.Core._2008_03.Session.ConnectResponse)obj;
			Teamcenter.Services.Strong.Core._2008_03.Session.ConnectResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	[Obsolete("As of Teamcenter 8.2, use the getShortcuts operation.", false)]
	public override Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesResponse GetFavorites()
	{
		try
		{
			restSender.PushRequestId();
			GetFavoritesInput requestObject = new GetFavoritesInput();
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_03.Session.FavoritesResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200803_PORT_NAME, "GetFavorites", requestObject, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2008_03.Session.FavoritesResponse wire = (Teamcenter.Schemas.Core._2008_03.Session.FavoritesResponse)obj;
			Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Soa.Client.Model.ServiceData SetFavorites(Teamcenter.Services.Strong.Core._2008_03.Session.FavoritesInfo Input)
	{
		try
		{
			restSender.PushRequestId();
			SetFavoritesInput setFavoritesInput = new SetFavoritesInput();
			setFavoritesInput.setInput(toWire(Input));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_200803_PORT_NAME, "SetFavorites", setFavoritesInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsOutput toWire(Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsOutput local)
	{
		Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsOutput getDisplayStringsOutput = new Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsOutput();
		getDisplayStringsOutput.setKey(local.Key);
		getDisplayStringsOutput.setValue(local.Value);
		return getDisplayStringsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsOutput toLocal(Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsOutput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsOutput getDisplayStringsOutput = new Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsOutput();
		getDisplayStringsOutput.Key = wire.getKey();
		getDisplayStringsOutput.Value = wire.getValue();
		return getDisplayStringsOutput;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsResponse toLocal(Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsResponse getDisplayStringsResponse = new Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsResponse();
		getDisplayStringsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList output = wire.getOutput();
		getDisplayStringsResponse.Output = new Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsOutput[output.Count];
		for (int i = 0; i < output.Count; i++)
		{
			getDisplayStringsResponse.Output[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsOutput)output[i], modelManager);
		}
		return getDisplayStringsResponse;
	}

	public override Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsResponse GetDisplayStrings(string[] Info)
	{
		try
		{
			restSender.PushRequestId();
			GetDisplayStringsInput getDisplayStringsInput = new GetDisplayStringsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Info.Length; i++)
			{
				arrayList.Add(Info[i]);
			}
			getDisplayStringsInput.setInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200806_PORT_NAME, "GetDisplayStrings", getDisplayStringsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsResponse wire = (Teamcenter.Schemas.Core._2008_06.Session.GetDisplayStringsResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.Session.GetDisplayStringsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse Login(string Username, string Password, string Group, string Role, string Locale, string SessionDiscriminator)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2008_06.Session.LoginInput loginInput = new Teamcenter.Schemas.Core._2008_06.Session.LoginInput();
			loginInput.setUsername(Username);
			loginInput.setPassword(Password);
			loginInput.setGroup(Group);
			loginInput.setRole(Role);
			loginInput.setLocale(Locale);
			loginInput.setSessionDiscriminator(SessionDiscriminator);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.LoginResponse);
			Type[] array = null;
			array = new Type[1] { typeof(InvalidCredentialsException) };
			object obj = restSender.Invoke(SESSION_200806_PORT_NAME, "Login", loginInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is InvalidCredentialsException)
			{
				throw (InvalidCredentialsException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.LoginResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.LoginResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse LoginSSO(string Username, string SsoCredentials, string Group, string Role, string Locale, string SessionDiscriminator)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput loginSSOInput = new Teamcenter.Schemas.Core._2008_06.Session.LoginSSOInput();
			loginSSOInput.setUsername(Username);
			loginSSOInput.setSsoCredentials(SsoCredentials);
			loginSSOInput.setGroup(Group);
			loginSSOInput.setRole(Role);
			loginSSOInput.setLocale(Locale);
			loginSSOInput.setSessionDiscriminator(SessionDiscriminator);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Session.LoginResponse);
			Type[] array = null;
			array = new Type[1] { typeof(InvalidCredentialsException) };
			object obj = restSender.Invoke(SESSION_200806_PORT_NAME, "LoginSSO", loginSSOInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is InvalidCredentialsException)
			{
				throw (InvalidCredentialsException)obj;
			}
			Teamcenter.Schemas.Core._2006_03.Session.LoginResponse wire = (Teamcenter.Schemas.Core._2006_03.Session.LoginResponse)obj;
			Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override string SetObjectPropertyPolicy(Teamcenter.Soa.Common.ObjectPropertyPolicy Policy)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyInput setObjectPropertyPolicyInput = new Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyInput();
			setObjectPropertyPolicyInput.setObjectPropertyPolicy(PolicyMarshaller.ToWire(Policy));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200806_PORT_NAME, "SetObjectPropertyPolicy", setObjectPropertyPolicyInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyOutput setObjectPropertyPolicyOutput = (Teamcenter.Schemas.Core._2008_06.Session.SetObjectPropertyPolicyOutput)obj;
			string result = setObjectPropertyPolicyOutput.getOut();
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override string StartOperation()
	{
		try
		{
			restSender.PushRequestId();
			StartOperationInput requestObject = new StartOperationInput();
			Type typeFromHandle = typeof(StartOperationOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200904_PORT_NAME, "StartOperation", requestObject, typeFromHandle, extraTypes);
			modelManager.LockModel();
			StartOperationOutput startOperationOutput = (StartOperationOutput)obj;
			string result = startOperationOutput.getOut();
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override bool StopOperation(string OpId)
	{
		try
		{
			restSender.PushRequestId();
			StopOperationInput stopOperationInput = new StopOperationInput();
			stopOperationInput.setOpId(OpId);
			Type typeFromHandle = typeof(StopOperationOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_200904_PORT_NAME, "StopOperation", stopOperationInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			StopOperationOutput stopOperationOutput = (StopOperationOutput)obj;
			bool result = stopOperationOutput.Out;
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Services.Strong.Core._2010_04.Session.GetShortcutsResponse toLocal(Teamcenter.Schemas.Core._2010_04.Session.GetShortcutsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.Session.GetShortcutsResponse getShortcutsResponse = new Teamcenter.Services.Strong.Core._2010_04.Session.GetShortcutsResponse();
		getShortcutsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getShortcutsResponse.Favorites = toLocal(wire.getFavorites(), modelManager);
		getShortcutsResponse.Shortcuts = toLocalLHNSectionComponentsMap(wire.getShortcuts(), modelManager);
		return getShortcutsResponse;
	}

	public static Teamcenter.Schemas.Core._2010_04.Session.LHNNonTcObjectSectionComponent toWire(Teamcenter.Services.Strong.Core._2010_04.Session.LHNNonTcObjectSectionComponent local)
	{
		Teamcenter.Schemas.Core._2010_04.Session.LHNNonTcObjectSectionComponent lHNNonTcObjectSectionComponent = new Teamcenter.Schemas.Core._2010_04.Session.LHNNonTcObjectSectionComponent();
		lHNNonTcObjectSectionComponent.setNonTcObjects(toWireLHNSectionComponentDetails(local.NonTcObjects));
		return lHNNonTcObjectSectionComponent;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.Session.LHNNonTcObjectSectionComponent toLocal(Teamcenter.Schemas.Core._2010_04.Session.LHNNonTcObjectSectionComponent wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.Session.LHNNonTcObjectSectionComponent lHNNonTcObjectSectionComponent = new Teamcenter.Services.Strong.Core._2010_04.Session.LHNNonTcObjectSectionComponent();
		lHNNonTcObjectSectionComponent.NonTcObjects = toLocalLHNSectionComponentDetails(wire.getNonTcObjects(), modelManager);
		return lHNNonTcObjectSectionComponent;
	}

	public static Teamcenter.Schemas.Core._2010_04.Session.LHNSectionComponents toWire(Teamcenter.Services.Strong.Core._2010_04.Session.LHNSectionComponents local)
	{
		Teamcenter.Schemas.Core._2010_04.Session.LHNSectionComponents lHNSectionComponents = new Teamcenter.Schemas.Core._2010_04.Session.LHNSectionComponents();
		lHNSectionComponents.setNonTcObjects(toWireLHNNonTcObjectSectionComponentMap(local.NonTcObjects));
		lHNSectionComponents.setTcObjects(toWireLHNTcObjectSectionComponentMap(local.TcObjects));
		return lHNSectionComponents;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.Session.LHNSectionComponents toLocal(Teamcenter.Schemas.Core._2010_04.Session.LHNSectionComponents wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.Session.LHNSectionComponents lHNSectionComponents = new Teamcenter.Services.Strong.Core._2010_04.Session.LHNSectionComponents();
		lHNSectionComponents.NonTcObjects = toLocalLHNNonTcObjectSectionComponentMap(wire.getNonTcObjects(), modelManager);
		lHNSectionComponents.TcObjects = toLocalLHNTcObjectSectionComponentMap(wire.getTcObjects(), modelManager);
		return lHNSectionComponents;
	}

	public static Teamcenter.Schemas.Core._2010_04.Session.LHNTcObjectSectionComponent toWire(Teamcenter.Services.Strong.Core._2010_04.Session.LHNTcObjectSectionComponent local)
	{
		Teamcenter.Schemas.Core._2010_04.Session.LHNTcObjectSectionComponent lHNTcObjectSectionComponent = new Teamcenter.Schemas.Core._2010_04.Session.LHNTcObjectSectionComponent();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.TcObject == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.TcObject.Uid);
		}
		lHNTcObjectSectionComponent.setTcObject(modelObject);
		lHNTcObjectSectionComponent.setDetails(toWireLHNSectionComponentDetails(local.Details));
		return lHNTcObjectSectionComponent;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.Session.LHNTcObjectSectionComponent toLocal(Teamcenter.Schemas.Core._2010_04.Session.LHNTcObjectSectionComponent wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.Session.LHNTcObjectSectionComponent lHNTcObjectSectionComponent = new Teamcenter.Services.Strong.Core._2010_04.Session.LHNTcObjectSectionComponent();
		lHNTcObjectSectionComponent.TcObject = modelManager.LoadObjectData(wire.getTcObject());
		lHNTcObjectSectionComponent.Details = toLocalLHNSectionComponentDetails(wire.getDetails(), modelManager);
		return lHNTcObjectSectionComponent;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.Session.MultiPreferenceResponse2 toLocal(Teamcenter.Schemas.Core._2010_04.Session.MultiPreferenceResponse2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.Session.MultiPreferenceResponse2 multiPreferenceResponse = new Teamcenter.Services.Strong.Core._2010_04.Session.MultiPreferenceResponse2();
		multiPreferenceResponse.Data = modelManager.LoadServiceData(wire.getServiceData());
		IList preferences = wire.getPreferences();
		multiPreferenceResponse.Preferences = new Teamcenter.Services.Strong.Core._2010_04.Session.ReturnedPreferences2[preferences.Count];
		for (int i = 0; i < preferences.Count; i++)
		{
			multiPreferenceResponse.Preferences[i] = toLocal((Teamcenter.Schemas.Core._2010_04.Session.ReturnedPreferences2)preferences[i], modelManager);
		}
		return multiPreferenceResponse;
	}

	public static Teamcenter.Schemas.Core._2010_04.Session.ReturnedPreferences2 toWire(Teamcenter.Services.Strong.Core._2010_04.Session.ReturnedPreferences2 local)
	{
		Teamcenter.Schemas.Core._2010_04.Session.ReturnedPreferences2 returnedPreferences = new Teamcenter.Schemas.Core._2010_04.Session.ReturnedPreferences2();
		returnedPreferences.setScope(local.Scope);
		returnedPreferences.setCategory(local.Category);
		returnedPreferences.setDescription(local.Description);
		returnedPreferences.setPrefType(local.PrefType);
		returnedPreferences.setIsArray(local.IsArray);
		returnedPreferences.setIsDisabled(local.IsDisabled);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Values.Length; i++)
		{
			arrayList.Add(local.Values[i]);
		}
		returnedPreferences.setValues(arrayList);
		returnedPreferences.setName(local.Name);
		return returnedPreferences;
	}

	public static Teamcenter.Services.Strong.Core._2010_04.Session.ReturnedPreferences2 toLocal(Teamcenter.Schemas.Core._2010_04.Session.ReturnedPreferences2 wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2010_04.Session.ReturnedPreferences2 returnedPreferences = new Teamcenter.Services.Strong.Core._2010_04.Session.ReturnedPreferences2();
		returnedPreferences.Scope = wire.getScope();
		returnedPreferences.Category = wire.getCategory();
		returnedPreferences.Description = wire.getDescription();
		returnedPreferences.PrefType = wire.getPrefType();
		returnedPreferences.IsArray = wire.IsArray;
		returnedPreferences.IsDisabled = wire.IsDisabled;
		IList values = wire.getValues();
		returnedPreferences.Values = new string[values.Count];
		for (int i = 0; i < values.Count; i++)
		{
			returnedPreferences.Values[i] = Convert.ToString(values[i]);
		}
		returnedPreferences.Name = wire.getName();
		return returnedPreferences;
	}

	public static ArrayList toWireLHNNonTcObjectSectionComponentMap(IDictionary LHNNonTcObjectSectionComponentMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in LHNNonTcObjectSectionComponentMap)
		{
			object key = item.Key;
			object value = item.Value;
			LHNNonTcObjectSectionComponentMap lHNNonTcObjectSectionComponentMap = new LHNNonTcObjectSectionComponentMap();
			lHNNonTcObjectSectionComponentMap.setKey((int)key);
			lHNNonTcObjectSectionComponentMap.setValue(toWire((Teamcenter.Services.Strong.Core._2010_04.Session.LHNNonTcObjectSectionComponent)value));
			arrayList.Add(lHNNonTcObjectSectionComponentMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalLHNNonTcObjectSectionComponentMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			LHNNonTcObjectSectionComponentMap lHNNonTcObjectSectionComponentMap = (LHNNonTcObjectSectionComponentMap)wire[i];
			int key = lHNNonTcObjectSectionComponentMap.getKey();
			Teamcenter.Services.Strong.Core._2010_04.Session.LHNNonTcObjectSectionComponent value = toLocal(lHNNonTcObjectSectionComponentMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireLHNSectionComponentDetails(IDictionary LHNSectionComponentDetails)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry LHNSectionComponentDetail in LHNSectionComponentDetails)
		{
			object key = LHNSectionComponentDetail.Key;
			object value = LHNSectionComponentDetail.Value;
			LHNSectionComponentDetails lHNSectionComponentDetails = new LHNSectionComponentDetails();
			lHNSectionComponentDetails.setKey(Convert.ToString(key));
			lHNSectionComponentDetails.setValue(Convert.ToString(value));
			arrayList.Add(lHNSectionComponentDetails);
		}
		return arrayList;
	}

	public static Hashtable toLocalLHNSectionComponentDetails(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			LHNSectionComponentDetails lHNSectionComponentDetails = (LHNSectionComponentDetails)wire[i];
			string key = lHNSectionComponentDetails.getKey();
			string value = lHNSectionComponentDetails.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireLHNSectionComponentsMap(IDictionary LHNSectionComponentsMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in LHNSectionComponentsMap)
		{
			object key = item.Key;
			object value = item.Value;
			LHNSectionComponentsMap lHNSectionComponentsMap = new LHNSectionComponentsMap();
			lHNSectionComponentsMap.setKey(Convert.ToString(key));
			lHNSectionComponentsMap.setValue(toWire((Teamcenter.Services.Strong.Core._2010_04.Session.LHNSectionComponents)value));
			arrayList.Add(lHNSectionComponentsMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalLHNSectionComponentsMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			LHNSectionComponentsMap lHNSectionComponentsMap = (LHNSectionComponentsMap)wire[i];
			string key = lHNSectionComponentsMap.getKey();
			Teamcenter.Services.Strong.Core._2010_04.Session.LHNSectionComponents value = toLocal(lHNSectionComponentsMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireLHNShortcutInputs(IDictionary LHNShortcutInputs)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry LHNShortcutInput in LHNShortcutInputs)
		{
			object key = LHNShortcutInput.Key;
			object value = LHNShortcutInput.Value;
			LHNShortcutInputs lHNShortcutInputs = new LHNShortcutInputs();
			lHNShortcutInputs.setKey(Convert.ToString(key));
			lHNShortcutInputs.setValue(Convert.ToString(value));
			arrayList.Add(lHNShortcutInputs);
		}
		return arrayList;
	}

	public static Hashtable toLocalLHNShortcutInputs(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			LHNShortcutInputs lHNShortcutInputs = (LHNShortcutInputs)wire[i];
			string key = lHNShortcutInputs.getKey();
			string value = lHNShortcutInputs.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireLHNTcObjectSectionComponentMap(IDictionary LHNTcObjectSectionComponentMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in LHNTcObjectSectionComponentMap)
		{
			object key = item.Key;
			object value = item.Value;
			LHNTcObjectSectionComponentMap lHNTcObjectSectionComponentMap = new LHNTcObjectSectionComponentMap();
			lHNTcObjectSectionComponentMap.setKey((int)key);
			lHNTcObjectSectionComponentMap.setValue(toWire((Teamcenter.Services.Strong.Core._2010_04.Session.LHNTcObjectSectionComponent)value));
			arrayList.Add(lHNTcObjectSectionComponentMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalLHNTcObjectSectionComponentMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			LHNTcObjectSectionComponentMap lHNTcObjectSectionComponentMap = (LHNTcObjectSectionComponentMap)wire[i];
			int key = lHNTcObjectSectionComponentMap.getKey();
			Teamcenter.Services.Strong.Core._2010_04.Session.LHNTcObjectSectionComponent value = toLocal(lHNTcObjectSectionComponentMap.getValue(), modelManager);
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	[Obsolete("As of Teamcenter 10, use the getPreferences operation from the PreferenceManagement service in the Administration library.", false)]
	public override Teamcenter.Services.Strong.Core._2010_04.Session.MultiPreferenceResponse2 GetPreferences2(Teamcenter.Services.Strong.Core._2007_01.Session.ScopedPreferenceNames[] PreferenceNames)
	{
		try
		{
			restSender.PushRequestId();
			GetPreferences2Input getPreferences2Input = new GetPreferences2Input();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < PreferenceNames.Length; i++)
			{
				arrayList.Add(toWire(PreferenceNames[i]));
			}
			getPreferences2Input.setPreferenceNames(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Session.MultiPreferenceResponse2);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_201004_PORT_NAME, "GetPreferences2", getPreferences2Input, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2010_04.Session.MultiPreferenceResponse2 wire = (Teamcenter.Schemas.Core._2010_04.Session.MultiPreferenceResponse2)obj;
			Teamcenter.Services.Strong.Core._2010_04.Session.MultiPreferenceResponse2 result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2010_04.Session.GetShortcutsResponse GetShortcuts(Hashtable ShortcutInputs)
	{
		try
		{
			restSender.PushRequestId();
			GetShortcutsInput getShortcutsInput = new GetShortcutsInput();
			getShortcutsInput.setShortcutInputs(toWireLHNShortcutInputs(ShortcutInputs));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2010_04.Session.GetShortcutsResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_201004_PORT_NAME, "GetShortcuts", getShortcutsInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2010_04.Session.GetShortcutsResponse wire = (Teamcenter.Schemas.Core._2010_04.Session.GetShortcutsResponse)obj;
			Teamcenter.Services.Strong.Core._2010_04.Session.GetShortcutsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Core._2011_06.Session.ClientCacheInfo toWire(Teamcenter.Services.Strong.Core._2011_06.Session.ClientCacheInfo local)
	{
		Teamcenter.Schemas.Core._2011_06.Session.ClientCacheInfo clientCacheInfo = new Teamcenter.Schemas.Core._2011_06.Session.ClientCacheInfo();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.Features.Length; i++)
		{
			arrayList.Add(toWire(local.Features[i]));
		}
		clientCacheInfo.setFeatures(arrayList);
		return clientCacheInfo;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.Session.ClientCacheInfo toLocal(Teamcenter.Schemas.Core._2011_06.Session.ClientCacheInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.Session.ClientCacheInfo clientCacheInfo = new Teamcenter.Services.Strong.Core._2011_06.Session.ClientCacheInfo();
		IList features = wire.getFeatures();
		clientCacheInfo.Features = new Teamcenter.Services.Strong.Core._2011_06.Session.Feature[features.Count];
		for (int i = 0; i < features.Count; i++)
		{
			clientCacheInfo.Features[i] = toLocal((Teamcenter.Schemas.Core._2011_06.Session.Feature)features[i], modelManager);
		}
		clientCacheInfo.PartialErrors = modelManager.LoadPartialErrors(wire.getPartialErrors());
		return clientCacheInfo;
	}

	public static Teamcenter.Schemas.Core._2011_06.Session.Credentials toWire(Teamcenter.Services.Strong.Core._2011_06.Session.Credentials local)
	{
		Teamcenter.Schemas.Core._2011_06.Session.Credentials credentials = new Teamcenter.Schemas.Core._2011_06.Session.Credentials();
		credentials.setUser(local.User);
		credentials.setPassword(local.Password);
		credentials.setGroup(local.Group);
		credentials.setRole(local.Role);
		credentials.setLocale(local.Locale);
		credentials.setDescrimator(local.Descrimator);
		return credentials;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.Session.Credentials toLocal(Teamcenter.Schemas.Core._2011_06.Session.Credentials wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.Session.Credentials credentials = new Teamcenter.Services.Strong.Core._2011_06.Session.Credentials();
		credentials.User = wire.getUser();
		credentials.Password = wire.getPassword();
		credentials.Group = wire.getGroup();
		credentials.Role = wire.getRole();
		credentials.Locale = wire.getLocale();
		credentials.Descrimator = wire.getDescrimator();
		return credentials;
	}

	public static Teamcenter.Schemas.Core._2011_06.Session.Feature toWire(Teamcenter.Services.Strong.Core._2011_06.Session.Feature local)
	{
		Teamcenter.Schemas.Core._2011_06.Session.Feature feature = new Teamcenter.Schemas.Core._2011_06.Session.Feature();
		feature.setName(local.Name);
		feature.setCacheTickets(toWireCacheTickets(local.CacheTickets));
		return feature;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.Session.Feature toLocal(Teamcenter.Schemas.Core._2011_06.Session.Feature wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.Session.Feature feature = new Teamcenter.Services.Strong.Core._2011_06.Session.Feature();
		feature.Name = wire.getName();
		feature.CacheTickets = toLocalCacheTickets(wire.getCacheTickets(), modelManager);
		return feature;
	}

	public static Teamcenter.Schemas.Core._2011_06.Session.LoginResponse toWire(Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse local)
	{
		Teamcenter.Schemas.Core._2011_06.Session.LoginResponse loginResponse = new Teamcenter.Schemas.Core._2011_06.Session.LoginResponse();
		loginResponse.setServerInfo(toWireServerInfo(local.ServerInfo));
		return loginResponse;
	}

	public static Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse toLocal(Teamcenter.Schemas.Core._2011_06.Session.LoginResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse loginResponse = new Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse();
		loginResponse.ServerInfo = toLocalServerInfo(wire.getServerInfo(), modelManager);
		loginResponse.PartialErrors = modelManager.LoadPartialErrors(wire.getPartialErrors());
		return loginResponse;
	}

	public static ArrayList toWireCacheTickets(IDictionary CacheTickets)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry CacheTicket in CacheTickets)
		{
			object key = CacheTicket.Key;
			object value = CacheTicket.Value;
			CacheTickets cacheTickets = new CacheTickets();
			cacheTickets.setKey(Convert.ToString(key));
			cacheTickets.setValue(Convert.ToString(value));
			arrayList.Add(cacheTickets);
		}
		return arrayList;
	}

	public static Hashtable toLocalCacheTickets(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			CacheTickets cacheTickets = (CacheTickets)wire[i];
			string key = cacheTickets.getKey();
			string value = cacheTickets.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireServerInfo(IDictionary ServerInfo)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ServerInfo)
		{
			object key = item.Key;
			object value = item.Value;
			ServerInfo serverInfo = new ServerInfo();
			serverInfo.setKey(Convert.ToString(key));
			serverInfo.setValue(Convert.ToString(value));
			arrayList.Add(serverInfo);
		}
		return arrayList;
	}

	public static Hashtable toLocalServerInfo(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ServerInfo serverInfo = (ServerInfo)wire[i];
			string key = serverInfo.getKey();
			string value = serverInfo.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Strong.Core._2011_06.Session.ClientCacheInfo GetClientCacheData(string[] Features)
	{
		try
		{
			restSender.PushRequestId();
			GetClientCacheDataInput getClientCacheDataInput = new GetClientCacheDataInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Features.Length; i++)
			{
				arrayList.Add(Features[i]);
			}
			getClientCacheDataInput.setFeatures(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Session.ClientCacheInfo);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_201106_PORT_NAME, "GetClientCacheData", getClientCacheDataInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2011_06.Session.ClientCacheInfo wire = (Teamcenter.Schemas.Core._2011_06.Session.ClientCacheInfo)obj;
			Teamcenter.Services.Strong.Core._2011_06.Session.ClientCacheInfo result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override TypeSchema GetTypeDescriptions(string[] TypeNames)
	{
		try
		{
			restSender.PushRequestId();
			GetTypeDescriptionsInput getTypeDescriptionsInput = new GetTypeDescriptionsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TypeNames.Length; i++)
			{
				arrayList.Add(TypeNames[i]);
			}
			getTypeDescriptionsInput.setTypeNames(arrayList);
			Type typeFromHandle = typeof(TypeSchema);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_201106_PORT_NAME, "GetTypeDescriptions", getTypeDescriptionsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			TypeSchema typeSchema = (TypeSchema)obj;
			TypeSchema result = typeSchema;
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse Login(Teamcenter.Services.Strong.Core._2011_06.Session.Credentials Credentials)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2011_06.Session.LoginInput loginInput = new Teamcenter.Schemas.Core._2011_06.Session.LoginInput();
			loginInput.setCredentials(toWire(Credentials));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Session.LoginResponse);
			Type[] array = null;
			array = new Type[1] { typeof(InvalidCredentialsException) };
			object obj = restSender.Invoke(SESSION_201106_PORT_NAME, "Login", loginInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is InvalidCredentialsException)
			{
				throw (InvalidCredentialsException)obj;
			}
			Teamcenter.Schemas.Core._2011_06.Session.LoginResponse wire = (Teamcenter.Schemas.Core._2011_06.Session.LoginResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse LoginSSO(Teamcenter.Services.Strong.Core._2011_06.Session.Credentials Credentials)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput loginSSOInput = new Teamcenter.Schemas.Core._2011_06.Session.LoginSSOInput();
			loginSSOInput.setCredentials(toWire(Credentials));
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2011_06.Session.LoginResponse);
			Type[] array = null;
			array = new Type[1] { typeof(InvalidCredentialsException) };
			object obj = restSender.Invoke(SESSION_201106_PORT_NAME, "LoginSSO", loginSSOInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is InvalidCredentialsException)
			{
				throw (InvalidCredentialsException)obj;
			}
			Teamcenter.Schemas.Core._2011_06.Session.LoginResponse wire = (Teamcenter.Schemas.Core._2011_06.Session.LoginResponse)obj;
			Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override string UpdateObjectPropertyPolicy(string PolicyID, Teamcenter.Soa.Common.PolicyType[] AddProperties, Teamcenter.Soa.Common.PolicyType[] RemoveProperties)
	{
		try
		{
			restSender.PushRequestId();
			UpdateObjectPropertyPolicyInput updateObjectPropertyPolicyInput = new UpdateObjectPropertyPolicyInput();
			updateObjectPropertyPolicyInput.setPolicyID(PolicyID);
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < AddProperties.Length; i++)
			{
				arrayList.Add(PolicyMarshaller.ToWire(AddProperties[i]));
			}
			updateObjectPropertyPolicyInput.setAddProperties(arrayList);
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < RemoveProperties.Length; i++)
			{
				arrayList2.Add(PolicyMarshaller.ToWire(RemoveProperties[i]));
			}
			updateObjectPropertyPolicyInput.setRemoveProperties(arrayList2);
			Type typeFromHandle = typeof(UpdateObjectPropertyPolicyOutput);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_201106_PORT_NAME, "UpdateObjectPropertyPolicy", updateObjectPropertyPolicyInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			UpdateObjectPropertyPolicyOutput updateObjectPropertyPolicyOutput = (UpdateObjectPropertyPolicyOutput)obj;
			string result = updateObjectPropertyPolicyOutput.getOut();
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public static Teamcenter.Schemas.Core._2012_02.Session.RegisterIndex toWire(Teamcenter.Services.Strong.Core._2012_02.Session.RegisterIndex local)
	{
		Teamcenter.Schemas.Core._2012_02.Session.RegisterIndex registerIndex = new Teamcenter.Schemas.Core._2012_02.Session.RegisterIndex();
		registerIndex.setRegistryIndex(local.RegistryIndex);
		return registerIndex;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.Session.RegisterIndex toLocal(Teamcenter.Schemas.Core._2012_02.Session.RegisterIndex wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.Session.RegisterIndex registerIndex = new Teamcenter.Services.Strong.Core._2012_02.Session.RegisterIndex();
		registerIndex.RegistryIndex = wire.getRegistryIndex();
		return registerIndex;
	}

	public static Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse toWire(Teamcenter.Services.Strong.Core._2012_02.Session.SetPolicyResponse local)
	{
		Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse setPolicyResponse = new Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse();
		setPolicyResponse.setPolicyId(local.PolicyId);
		setPolicyResponse.setObjectPropertyPolicy(PolicyMarshaller.ToWire(local.Policy));
		return setPolicyResponse;
	}

	public static Teamcenter.Services.Strong.Core._2012_02.Session.SetPolicyResponse toLocal(Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2012_02.Session.SetPolicyResponse setPolicyResponse = new Teamcenter.Services.Strong.Core._2012_02.Session.SetPolicyResponse();
		setPolicyResponse.PolicyId = wire.getPolicyId();
		setPolicyResponse.Policy = PolicyMarshaller.ToLocal(wire.getObjectPropertyPolicy());
		return setPolicyResponse;
	}

	public override Teamcenter.Services.Strong.Core._2012_02.Session.RegisterIndex RegisterState(string Level)
	{
		try
		{
			restSender.PushRequestId();
			RegisterStateInput registerStateInput = new RegisterStateInput();
			registerStateInput.setLevel(Level);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_02.Session.RegisterIndex);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_201202_PORT_NAME, "RegisterState", registerStateInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2012_02.Session.RegisterIndex wire = (Teamcenter.Schemas.Core._2012_02.Session.RegisterIndex)obj;
			Teamcenter.Services.Strong.Core._2012_02.Session.RegisterIndex result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override Teamcenter.Services.Strong.Core._2012_02.Session.SetPolicyResponse SetObjectPropertyPolicy(string PolicyName, bool UseRefCounting)
	{
		try
		{
			restSender.PushRequestId();
			Teamcenter.Schemas.Core._2012_02.Session.SetObjectPropertyPolicyInput setObjectPropertyPolicyInput = new Teamcenter.Schemas.Core._2012_02.Session.SetObjectPropertyPolicyInput();
			setObjectPropertyPolicyInput.setPolicyName(PolicyName);
			setObjectPropertyPolicyInput.setUseRefCounting(UseRefCounting);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(SESSION_201202_PORT_NAME, "SetObjectPropertyPolicy", setObjectPropertyPolicyInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse wire = (Teamcenter.Schemas.Core._2012_02.Session.SetPolicyResponse)obj;
			Teamcenter.Services.Strong.Core._2012_02.Session.SetPolicyResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}

	public override bool UnregisterState(int Index)
	{
		try
		{
			restSender.PushRequestId();
			UnregisterStateInput unregisterStateInput = new UnregisterStateInput();
			unregisterStateInput.setIndex(Index);
			Type typeFromHandle = typeof(UnregisterStateOutput);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(SESSION_201202_PORT_NAME, "UnregisterState", unregisterStateInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			UnregisterStateOutput unregisterStateOutput = (UnregisterStateOutput)obj;
			bool result = unregisterStateOutput.Out;
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}
}
