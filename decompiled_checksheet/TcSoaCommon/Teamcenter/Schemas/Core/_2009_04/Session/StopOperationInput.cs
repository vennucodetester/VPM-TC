using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2009_04.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2009-04/Session", IsNullable = false)]
public class StopOperationInput
{
	private string OpIdField;

	[XmlAttribute(AttributeName = "opId")]
	public string OpId
	{
		get
		{
			return OpIdField;
		}
		set
		{
			OpIdField = value;
		}
	}

	public string getOpId()
	{
		return OpIdField;
	}

	public void setOpId(string val)
	{
		OpIdField = val;
	}
}
