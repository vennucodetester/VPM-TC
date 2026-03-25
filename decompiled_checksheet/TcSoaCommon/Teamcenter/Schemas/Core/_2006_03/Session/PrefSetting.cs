using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/Session", IsNullable = false)]
public class PrefSetting
{
	private string PrefScopeField;

	private string PrefNameField;

	private string[] PrefValuesField;

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

	[XmlAttribute(AttributeName = "prefName")]
	public string PrefName
	{
		get
		{
			return PrefNameField;
		}
		set
		{
			PrefNameField = value;
		}
	}

	[XmlElement("prefValues")]
	public string[] PrefValues
	{
		get
		{
			return PrefValuesField;
		}
		set
		{
			PrefValuesField = value;
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

	public string getPrefName()
	{
		return PrefNameField;
	}

	public void setPrefName(string val)
	{
		PrefNameField = val;
	}

	public ArrayList getPrefValues()
	{
		if (PrefValuesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(PrefValuesField);
	}

	public void setPrefValues(ArrayList val)
	{
		PrefValuesField = new string[val.Count];
		val.CopyTo(PrefValuesField);
	}
}
