using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_12.Session;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-12/Session", IsNullable = false)]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
public class StateNameValue
{
	private string NameField;

	private string ValueField;

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

	public string getName()
	{
		return NameField;
	}

	public void setName(string val)
	{
		NameField = val;
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
