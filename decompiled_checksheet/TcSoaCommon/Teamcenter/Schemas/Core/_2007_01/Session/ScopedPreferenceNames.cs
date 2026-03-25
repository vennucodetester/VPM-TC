using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class ScopedPreferenceNames
{
	private string ScopeField;

	private string[] NamesField;

	[XmlAttribute(AttributeName = "scope")]
	public string Scope
	{
		get
		{
			return ScopeField;
		}
		set
		{
			ScopeField = value;
		}
	}

	[XmlElement("names")]
	public string[] Names
	{
		get
		{
			return NamesField;
		}
		set
		{
			NamesField = value;
		}
	}

	public string getScope()
	{
		return ScopeField;
	}

	public void setScope(string val)
	{
		ScopeField = val;
	}

	public ArrayList getNames()
	{
		if (NamesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(NamesField);
	}

	public void setNames(ArrayList val)
	{
		NamesField = new string[val.Count];
		val.CopyTo(NamesField);
	}
}
