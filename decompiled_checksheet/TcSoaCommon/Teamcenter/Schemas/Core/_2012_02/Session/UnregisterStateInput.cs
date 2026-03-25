using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2012_02.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2012-02/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
public class UnregisterStateInput
{
	private int IndexField;

	[XmlAttribute(AttributeName = "index")]
	public int Index
	{
		get
		{
			return IndexField;
		}
		set
		{
			IndexField = value;
		}
	}

	public int getIndex()
	{
		return IndexField;
	}

	public void setIndex(int val)
	{
		IndexField = val;
	}
}
