using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
public class ReturnedPreferences
{
	private string NameField;

	private string ScopeField;

	private string[] ValuesField;

	[XmlAttribute(AttributeName = "name")]
	public string Name
	{
		get
		{
			return NameField;
		}
		set
		{
			NameField = value;
		}
	}

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

	[XmlElement("values")]
	public string[] Values
	{
		get
		{
			return ValuesField;
		}
		set
		{
			ValuesField = value;
		}
	}

	public string getName()
	{
		return NameField;
	}

	public void setName(string val)
	{
		NameField = val;
	}

	public string getScope()
	{
		return ScopeField;
	}

	public void setScope(string val)
	{
		ScopeField = val;
	}

	public ArrayList getValues()
	{
		if (ValuesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ValuesField);
	}

	public void setValues(ArrayList val)
	{
		ValuesField = new string[val.Count];
		val.CopyTo(ValuesField);
	}
}
