using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
public class PreferencesResponse
{
	private Preferences PreferencesField;

	private ServiceData ServiceDataField;

	[XmlElement(ElementName = "Preferences", Namespace = "http://teamcenter.com/Schemas/Soa/2006-03/Base")]
	public Preferences Preferences
	{
		get
		{
			return PreferencesField;
		}
		set
		{
			PreferencesField = value;
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

	public Preferences getPreferences()
	{
		return PreferencesField;
	}

	public void setPreferences(Preferences val)
	{
		PreferencesField = val;
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
