using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
public class SetObjectPropertyPolicyOutput
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
