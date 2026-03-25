using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
public class GetTCSessionInfoResponse
{
	private int ModuleNumberField;

	private string TransientVolRootDirField;

	private bool AdmJournalingField;

	private string ServerVersionField;

	private bool AppJournalingField;

	private bool BypassField;

	private bool IsSubscriptionMgrEnabledField;

	private bool JournalingField;

	private bool SecJournalingField;

	private bool IsPartBOMUsageEnabledField;

	private bool IsInV7ModeField;

	private bool PrivilegedField;

	private ModelObject UserField;

	private ModelObject GroupField;

	private ModelObject RoleField;

	private ModelObject TcVolumeField;

	private ModelObject ProjectField;

	private ModelObject WorkContextField;

	private ModelObject SiteField;

	private TextInfo[] TextInfosField;

	private ExtraInfo[] ExtraInfoField;

	private ServiceData ServiceDataField;

	[XmlAttribute(AttributeName = "moduleNumber")]
	public int ModuleNumber
	{
		get
		{
			return ModuleNumberField;
		}
		set
		{
			ModuleNumberField = value;
		}
	}

	[XmlAttribute(AttributeName = "transientVolRootDir")]
	public string TransientVolRootDir
	{
		get
		{
			return TransientVolRootDirField;
		}
		set
		{
			TransientVolRootDirField = value;
		}
	}

	[XmlAttribute(AttributeName = "admJournaling")]
	public bool AdmJournaling
	{
		get
		{
			return AdmJournalingField;
		}
		set
		{
			AdmJournalingField = value;
		}
	}

	[XmlAttribute(AttributeName = "serverVersion")]
	public string ServerVersion
	{
		get
		{
			return ServerVersionField;
		}
		set
		{
			ServerVersionField = value;
		}
	}

	[XmlAttribute(AttributeName = "appJournaling")]
	public bool AppJournaling
	{
		get
		{
			return AppJournalingField;
		}
		set
		{
			AppJournalingField = value;
		}
	}

	[XmlAttribute(AttributeName = "bypass")]
	public bool Bypass
	{
		get
		{
			return BypassField;
		}
		set
		{
			BypassField = value;
		}
	}

	[XmlAttribute(AttributeName = "isSubscriptionMgrEnabled")]
	public bool IsSubscriptionMgrEnabled
	{
		get
		{
			return IsSubscriptionMgrEnabledField;
		}
		set
		{
			IsSubscriptionMgrEnabledField = value;
		}
	}

	[XmlAttribute(AttributeName = "journaling")]
	public bool Journaling
	{
		get
		{
			return JournalingField;
		}
		set
		{
			JournalingField = value;
		}
	}

	[XmlAttribute(AttributeName = "secJournaling")]
	public bool SecJournaling
	{
		get
		{
			return SecJournalingField;
		}
		set
		{
			SecJournalingField = value;
		}
	}

	[XmlAttribute(AttributeName = "isPartBOMUsageEnabled")]
	public bool IsPartBOMUsageEnabled
	{
		get
		{
			return IsPartBOMUsageEnabledField;
		}
		set
		{
			IsPartBOMUsageEnabledField = value;
		}
	}

	[XmlAttribute(AttributeName = "isInV7Mode")]
	public bool IsInV7Mode
	{
		get
		{
			return IsInV7ModeField;
		}
		set
		{
			IsInV7ModeField = value;
		}
	}

	[XmlAttribute(AttributeName = "privileged")]
	public bool Privileged
	{
		get
		{
			return PrivilegedField;
		}
		set
		{
			PrivilegedField = value;
		}
	}

	[XmlElement("user")]
	public ModelObject User
	{
		get
		{
			return UserField;
		}
		set
		{
			UserField = value;
		}
	}

	[XmlElement("group")]
	public ModelObject Group
	{
		get
		{
			return GroupField;
		}
		set
		{
			GroupField = value;
		}
	}

	[XmlElement("role")]
	public ModelObject Role
	{
		get
		{
			return RoleField;
		}
		set
		{
			RoleField = value;
		}
	}

	[XmlElement("tcVolume")]
	public ModelObject TcVolume
	{
		get
		{
			return TcVolumeField;
		}
		set
		{
			TcVolumeField = value;
		}
	}

	[XmlElement("project")]
	public ModelObject Project
	{
		get
		{
			return ProjectField;
		}
		set
		{
			ProjectField = value;
		}
	}

	[XmlElement("workContext")]
	public ModelObject WorkContext
	{
		get
		{
			return WorkContextField;
		}
		set
		{
			WorkContextField = value;
		}
	}

	[XmlElement("site")]
	public ModelObject Site
	{
		get
		{
			return SiteField;
		}
		set
		{
			SiteField = value;
		}
	}

	[XmlElement("textInfos")]
	public TextInfo[] TextInfos
	{
		get
		{
			return TextInfosField;
		}
		set
		{
			TextInfosField = value;
		}
	}

	[XmlElement("extraInfo")]
	public ExtraInfo[] ExtraInfo
	{
		get
		{
			return ExtraInfoField;
		}
		set
		{
			ExtraInfoField = value;
		}
	}

	[XmlElement(ElementName = "ServiceData", Namespace = "http://teamcenter.com/Schemas/Soa/2006-03/Base")]
	public ServiceData ServiceData
	{
		get
		{
			return ServiceDataField;
		}
		set
		{
			ServiceDataField = value;
		}
	}

	public int getModuleNumber()
	{
		return ModuleNumberField;
	}

	public void setModuleNumber(int val)
	{
		ModuleNumberField = val;
	}

	public string getTransientVolRootDir()
	{
		return TransientVolRootDirField;
	}

	public void setTransientVolRootDir(string val)
	{
		TransientVolRootDirField = val;
	}

	public bool getAdmJournaling()
	{
		return AdmJournalingField;
	}

	public void setAdmJournaling(bool val)
	{
		AdmJournalingField = val;
	}

	public string getServerVersion()
	{
		return ServerVersionField;
	}

	public void setServerVersion(string val)
	{
		ServerVersionField = val;
	}

	public bool getAppJournaling()
	{
		return AppJournalingField;
	}

	public void setAppJournaling(bool val)
	{
		AppJournalingField = val;
	}

	public bool getBypass()
	{
		return BypassField;
	}

	public void setBypass(bool val)
	{
		BypassField = val;
	}

	public bool getIsSubscriptionMgrEnabled()
	{
		return IsSubscriptionMgrEnabledField;
	}

	public void setIsSubscriptionMgrEnabled(bool val)
	{
		IsSubscriptionMgrEnabledField = val;
	}

	public bool getJournaling()
	{
		return JournalingField;
	}

	public void setJournaling(bool val)
	{
		JournalingField = val;
	}

	public bool getSecJournaling()
	{
		return SecJournalingField;
	}

	public void setSecJournaling(bool val)
	{
		SecJournalingField = val;
	}

	public bool getIsPartBOMUsageEnabled()
	{
		return IsPartBOMUsageEnabledField;
	}

	public void setIsPartBOMUsageEnabled(bool val)
	{
		IsPartBOMUsageEnabledField = val;
	}

	public bool getIsInV7Mode()
	{
		return IsInV7ModeField;
	}

	public void setIsInV7Mode(bool val)
	{
		IsInV7ModeField = val;
	}

	public bool getPrivileged()
	{
		return PrivilegedField;
	}

	public void setPrivileged(bool val)
	{
		PrivilegedField = val;
	}

	public ModelObject getUser()
	{
		return UserField;
	}

	public void setUser(ModelObject val)
	{
		UserField = val;
	}

	public ModelObject getGroup()
	{
		return GroupField;
	}

	public void setGroup(ModelObject val)
	{
		GroupField = val;
	}

	public ModelObject getRole()
	{
		return RoleField;
	}

	public void setRole(ModelObject val)
	{
		RoleField = val;
	}

	public ModelObject getTcVolume()
	{
		return TcVolumeField;
	}

	public void setTcVolume(ModelObject val)
	{
		TcVolumeField = val;
	}

	public ModelObject getProject()
	{
		return ProjectField;
	}

	public void setProject(ModelObject val)
	{
		ProjectField = val;
	}

	public ModelObject getWorkContext()
	{
		return WorkContextField;
	}

	public void setWorkContext(ModelObject val)
	{
		WorkContextField = val;
	}

	public ModelObject getSite()
	{
		return SiteField;
	}

	public void setSite(ModelObject val)
	{
		SiteField = val;
	}

	public ArrayList getTextInfos()
	{
		if (TextInfosField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(TextInfosField);
	}

	public void setTextInfos(ArrayList val)
	{
		TextInfosField = new TextInfo[val.Count];
		val.CopyTo(TextInfosField);
	}

	public ArrayList getExtraInfo()
	{
		if (ExtraInfoField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ExtraInfoField);
	}

	public void setExtraInfo(ArrayList val)
	{
		ExtraInfoField = new ExtraInfo[val.Count];
		val.CopyTo(ExtraInfoField);
	}

	public ServiceData getServiceData()
	{
		return ServiceDataField;
	}

	public void setServiceData(ServiceData val)
	{
		ServiceDataField = val;
	}
}
