using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
public class ExtraInfo
{
	private string KeyField;

	private string ValueField;

	[XmlAttribute(AttributeName = "key")]
	public string Key
	{
		get
		{
			return KeyField;
		}
		set
		{
			KeyField = value;
		}
	}

	[XmlAttribute(AttributeName = "value")]
	public string Value
	{
		get
		{
			return ValueField;
		}
		set
		{
			ValueField = value;
		}
	}

	public string getKey()
	{
		return KeyField;
	}

	public void setKey(string val)
	{
		KeyField = val;
	}

	public string getValue()
	{
		return ValueField;
	}

	public void setValue(string val)
	{
		ValueField = val;
	}
}
