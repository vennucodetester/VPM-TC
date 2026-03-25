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
public class StartOperationOutput
{
	private string OutField;

	[XmlAttribute(AttributeName = "out")]
	public string Out
	{
		get
		{
			return OutField;
		}
		set
		{
			OutField = value;
		}
	}

	public string getOut()
	{
		return OutField;
	}

	public void setOut(string val)
	{
		OutField = val;
	}
}
