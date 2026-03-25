using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class SetPreferencesInput
{
	private PrefSetting[] SettingsField;

	[XmlElement("settings")]
	public PrefSetting[] Settings
	{
		get
		{
			return SettingsField;
		}
		set
		{
			SettingsField = value;
		}
	}

	public ArrayList getSettings()
	{
		if (SettingsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(SettingsField);
	}

	public void setSettings(ArrayList val)
	{
		SettingsField = new PrefSetting[val.Count];
		val.CopyTo(SettingsField);
	}
}
