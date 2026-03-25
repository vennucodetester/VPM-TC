using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_06.Session;

[Serializable]
[DebuggerStepThrough]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-06/Session", IsNullable = false)]
public class RefreshPOMCachePerRequestOutput
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
