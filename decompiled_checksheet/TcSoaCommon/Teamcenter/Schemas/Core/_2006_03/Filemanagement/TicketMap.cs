using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[DesignerCategory("code")]
public class TicketMap
{
	private string ValueField;

	private ModelObject KeyField;

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

	[XmlElement("key")]
	public ModelObject Key
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

	public string getValue()
	{
		return ValueField;
	}

	public void setValue(string val)
	{
		ValueField = val;
	}

	public ModelObject getKey()
	{
		return KeyField;
	}

	public void setKey(ModelObject val)
	{
		KeyField = val;
	}
}
