using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
public class LHNTcObjectSectionComponentMap
{
	private int KeyField;

	private LHNTcObjectSectionComponent ValueField;

	[XmlAttribute(AttributeName = "key")]
	public int Key
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
	public LHNTcObjectSectionComponent Value
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

	public int getKey()
	{
		return KeyField;
	}

	public void setKey(int val)
	{
		KeyField = val;
	}

	public LHNTcObjectSectionComponent getValue()
	{
		return ValueField;
	}

	public void setValue(LHNTcObjectSectionComponent val)
	{
		ValueField = val;
	}
}
