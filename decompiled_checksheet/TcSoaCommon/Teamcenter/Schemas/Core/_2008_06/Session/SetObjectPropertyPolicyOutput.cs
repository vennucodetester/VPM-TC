using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2008_06.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-06/Session", IsNullable = false)]
[DesignerCategory("code")]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
public class SetObjectPropertyPolicyOutput
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
