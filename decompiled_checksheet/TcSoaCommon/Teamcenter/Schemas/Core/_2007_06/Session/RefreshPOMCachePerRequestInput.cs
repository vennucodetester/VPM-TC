using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_06.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-06/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class RefreshPOMCachePerRequestInput
{
	private bool RefreshField;

	[XmlAttribute(AttributeName = "refresh")]
	public bool Refresh
	{
		get
		{
			return RefreshField;
		}
		set
		{
			RefreshField = value;
		}
	}

	public bool getRefresh()
	{
		return RefreshField;
	}

	public void setRefresh(bool val)
	{
		RefreshField = val;
	}
}
