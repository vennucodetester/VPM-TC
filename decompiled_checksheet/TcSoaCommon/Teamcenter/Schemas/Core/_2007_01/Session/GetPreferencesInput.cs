using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
public class GetPreferencesInput
{
	private ScopedPreferenceNames[] RequestedPrefsField;

	[XmlElement("requestedPrefs")]
	public ScopedPreferenceNames[] RequestedPrefs
	{
		get
		{
			return RequestedPrefsField;
		}
		set
		{
			RequestedPrefsField = value;
		}
	}

	public ArrayList getRequestedPrefs()
	{
		if (RequestedPrefsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(RequestedPrefsField);
	}

	public void setRequestedPrefs(ArrayList val)
	{
		RequestedPrefsField = new ScopedPreferenceNames[val.Count];
		val.CopyTo(RequestedPrefsField);
	}
}
