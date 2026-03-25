using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Core._2007_01.Session;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetPreferences2Input
{
	private ScopedPreferenceNames[] PreferenceNamesField;

	[XmlElement("preferenceNames")]
	public ScopedPreferenceNames[] PreferenceNames
	{
		get
		{
			return PreferenceNamesField;
		}
		set
		{
			PreferenceNamesField = value;
		}
	}

	public ArrayList getPreferenceNames()
	{
		if (PreferenceNamesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(PreferenceNamesField);
	}

	public void setPreferenceNames(ArrayList val)
	{
		PreferenceNamesField = new ScopedPreferenceNames[val.Count];
		val.CopyTo(PreferenceNamesField);
	}
}
