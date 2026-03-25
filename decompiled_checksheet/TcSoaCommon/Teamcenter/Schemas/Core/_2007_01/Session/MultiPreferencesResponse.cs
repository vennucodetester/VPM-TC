using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class MultiPreferencesResponse
{
	private ReturnedPreferences[] PreferencesField;

	private ServiceData ServiceDataField;

	[XmlElement("preferences")]
	public ReturnedPreferences[] Preferences
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

	public ArrayList getPreferences()
	{
		if (PreferencesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(PreferencesField);
	}

	public void setPreferences(ArrayList val)
	{
		PreferencesField = new ReturnedPreferences[val.Count];
		val.CopyTo(PreferencesField);
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
