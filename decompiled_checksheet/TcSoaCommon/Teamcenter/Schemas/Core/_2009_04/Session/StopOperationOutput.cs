using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2009_04.Session;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2009-04/Session", IsNullable = false)]
public class StopOperationOutput
{
	private bool OutField;

	[XmlAttribute(AttributeName = "out")]
	public bool Out
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

	public bool getOut()
	{
		return OutField;
	}

	public void setOut(bool val)
	{
		OutField = val;
	}
}
