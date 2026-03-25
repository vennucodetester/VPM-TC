using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2011_06.Metamodel;
using Teamcenter.Services.Strong.Core._2006_03.Session;
using Teamcenter.Services.Strong.Core._2007_01.Session;
using Teamcenter.Services.Strong.Core._2007_06.Session;
using Teamcenter.Services.Strong.Core._2007_12.Session;
using Teamcenter.Services.Strong.Core._2008_03.Session;
using Teamcenter.Services.Strong.Core._2008_06.Session;
using Teamcenter.Services.Strong.Core._2009_04.Session;
using Teamcenter.Services.Strong.Core._2010_04.Session;
using Teamcenter.Services.Strong.Core._2011_06.Session;
using Teamcenter.Services.Strong.Core._2012_02.Session;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Common;

namespace Teamcenter.Services.Strong.Core;

public abstract class SessionService : Teamcenter.Services.Strong.Core._2006_03.Session.Session, Teamcenter.Services.Strong.Core._2007_01.Session.Session, Teamcenter.Services.Strong.Core._2007_06.Session.Session, Teamcenter.Services.Strong.Core._2007_12.Session.Session, Teamcenter.Services.Strong.Core._2008_03.Session.Session, Teamcenter.Services.Strong.Core._2008_06.Session.Session, Teamcenter.Services.Strong.Core._2009_04.Session.Session, Teamcenter.Services.Strong.Core._2010_04.Session.Session, Teamcenter.Services.Strong.Core._2011_06.Session.Session, Teamcenter.Services.Strong.Core._2012_02.Session.Session
{
	public static SessionService getService(Teamcenter.Soa.Client.Connection connection)
	{
		if (connection.Binding.ToUpper().Equals(SoaConstants.REST.ToUpper()))
		{
			return new SessionRestBindingStub(connection);
		}
		throw new ArgumentOutOfRangeException("connection", "The " + connection.Binding + " binding is not supported.");
	}

	[Obsolete("As of tceng2005sr1, use the getPreferences operation from the _2007_01 namespace.", false)]
	public virtual PreferencesResponse GetPreferences(string PrefScope, string[] PrefNames)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10, use the setPreferences operation from the PreferenceManagement service in the Administration library.", false)]
	public virtual PreferencesResponse SetPreferences(PrefSetting[] Settings)
	{
		throw new NotImplementedException();
	}

	public virtual GetAvailableServicesResponse GetAvailableServices()
	{
		throw new NotImplementedException();
	}

	public virtual GetGroupMembershipResponse GetGroupMembership()
	{
		throw new NotImplementedException();
	}

	public virtual GetSessionGroupMemberResponse GetSessionGroupMember()
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10, use the login operation from the _2008_06 namespace.", false)]
	public virtual Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse Login(string Username, string Password, string Group, string Role, string SessionDiscriminator)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10, use the loginSSO operation from the _2008_06 namespace.", false)]
	public virtual Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse LoginSSO(string Username, string SsoCredentials, string Group, string Role, string SessionDiscriminator)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData Logout()
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetSessionGroupMember(GroupMember GroupMember)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10, use the getPreferences operation from the PreferenceManagement service in the Administration library.", false)]
	public virtual MultiPreferencesResponse GetPreferences(ScopedPreferenceNames[] RequestedPrefs)
	{
		throw new NotImplementedException();
	}

	public virtual GetTCSessionInfoResponse GetTCSessionInfo()
	{
		throw new NotImplementedException();
	}

	public virtual bool SetObjectPropertyPolicy(string PolicyName)
	{
		throw new NotImplementedException();
	}

	public virtual bool RefreshPOMCachePerRequest(bool Refresh)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetAndEvaluateIdDisplayRule(ModelObject[] IdentifiableObjects, IdDispRule DisplayRule, bool SetRuleAsCurrentInDB)
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetUserSessionState(StateNameValue[] Pairs)
	{
		throw new NotImplementedException();
	}

	public virtual ConnectResponse Connect(string FeatureKey, string Action)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 8.2, use the getShortcuts operation.", false)]
	public virtual FavoritesResponse GetFavorites()
	{
		throw new NotImplementedException();
	}

	public virtual ServiceData SetFavorites(FavoritesInfo Input)
	{
		throw new NotImplementedException();
	}

	public virtual GetDisplayStringsResponse GetDisplayStrings(string[] Info)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse Login(string Username, string Password, string Group, string Role, string Locale, string SessionDiscriminator)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2006_03.Session.LoginResponse LoginSSO(string Username, string SsoCredentials, string Group, string Role, string Locale, string SessionDiscriminator)
	{
		throw new NotImplementedException();
	}

	public virtual string SetObjectPropertyPolicy(ObjectPropertyPolicy Policy)
	{
		throw new NotImplementedException();
	}

	public virtual string StartOperation()
	{
		throw new NotImplementedException();
	}

	public virtual bool StopOperation(string OpId)
	{
		throw new NotImplementedException();
	}

	[Obsolete("As of Teamcenter 10, use the getPreferences operation from the PreferenceManagement service in the Administration library.", false)]
	public virtual MultiPreferenceResponse2 GetPreferences2(ScopedPreferenceNames[] PreferenceNames)
	{
		throw new NotImplementedException();
	}

	public virtual GetShortcutsResponse GetShortcuts(Hashtable ShortcutInputs)
	{
		throw new NotImplementedException();
	}

	public virtual ClientCacheInfo GetClientCacheData(string[] Features)
	{
		throw new NotImplementedException();
	}

	public virtual TypeSchema GetTypeDescriptions(string[] TypeNames)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse Login(Credentials Credentials)
	{
		throw new NotImplementedException();
	}

	public virtual Teamcenter.Services.Strong.Core._2011_06.Session.LoginResponse LoginSSO(Credentials Credentials)
	{
		throw new NotImplementedException();
	}

	public virtual string UpdateObjectPropertyPolicy(string PolicyID, PolicyType[] AddProperties, PolicyType[] RemoveProperties)
	{
		throw new NotImplementedException();
	}

	public virtual RegisterIndex RegisterState(string Level)
	{
		throw new NotImplementedException();
	}

	public virtual SetPolicyResponse SetObjectPropertyPolicy(string PolicyName, bool UseRefCounting)
	{
		throw new NotImplementedException();
	}

	public virtual bool UnregisterState(int Index)
	{
		throw new NotImplementedException();
	}
}
