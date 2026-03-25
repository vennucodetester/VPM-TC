using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class LHNSectionComponentsMap
{
	private string KeyField;

	private LHNSectionComponents ValueField;

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

	[XmlElement("value")]
	public LHNSectionComponents Value
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

	public LHNSectionComponents getValue()
	{
		return ValueField;
	}

	public void setValue(LHNSectionComponents val)
	{
		ValueField = val;
	}
}
