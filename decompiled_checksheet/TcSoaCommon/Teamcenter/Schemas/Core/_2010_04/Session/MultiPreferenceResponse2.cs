using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
public class MultiPreferenceResponse2
{
	private ServiceData ServiceDataField;

	private ReturnedPreferences2[] PreferencesField;

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

	[XmlElement("preferences")]
	public ReturnedPreferences2[] Preferences
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

	public ServiceData getServiceData()
	{
		return ServiceDataField;
	}

	public void setServiceData(ServiceData val)
	{
		ServiceDataField = val;
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
		PreferencesField = new ReturnedPreferences2[val.Count];
		val.CopyTo(PreferencesField);
	}
}
