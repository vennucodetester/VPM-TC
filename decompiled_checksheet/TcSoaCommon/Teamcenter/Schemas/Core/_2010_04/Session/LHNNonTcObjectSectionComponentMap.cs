using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
public class LHNNonTcObjectSectionComponentMap
{
	private int KeyField;

	private LHNNonTcObjectSectionComponent ValueField;

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
	public LHNNonTcObjectSectionComponent Value
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

	public LHNNonTcObjectSectionComponent getValue()
	{
		return ValueField;
	}

	public void setValue(LHNNonTcObjectSectionComponent val)
	{
		ValueField = val;
	}
}
