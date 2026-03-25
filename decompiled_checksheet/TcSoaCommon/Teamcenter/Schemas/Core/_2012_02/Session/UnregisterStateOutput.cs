using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2012_02.Session;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2012-02/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class UnregisterStateOutput
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
