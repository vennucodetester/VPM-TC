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
public class GetPreferencesInput
{
	private string PrefScopeField;

	private string[] PrefNamesField;

	[XmlAttribute(AttributeName = "prefScope")]
	public string PrefScope
	{
		get
		{
			return PrefScopeField;
		}
		set
		{
			PrefScopeField = value;
		}
	}

	[XmlElement("prefNames")]
	public string[] PrefNames
	{
		get
		{
			return PrefNamesField;
		}
		set
		{
			PrefNamesField = value;
		}
	}

	public string getPrefScope()
	{
		return PrefScopeField;
	}

	public void setPrefScope(string val)
	{
		PrefScopeField = val;
	}

	public ArrayList getPrefNames()
	{
		if (PrefNamesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(PrefNamesField);
	}

	public void setPrefNames(ArrayList val)
	{
		PrefNamesField = new string[val.Count];
		val.CopyTo(PrefNamesField);
	}
}
