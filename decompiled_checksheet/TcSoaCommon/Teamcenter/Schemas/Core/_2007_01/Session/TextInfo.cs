using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class TextInfo
{
	private string DisplayNameField;

	private string RealNameField;

	[XmlAttribute(AttributeName = "displayName")]
	public string DisplayName
	{
		get
		{
			return DisplayNameField;
		}
		set
		{
			DisplayNameField = value;
		}
	}

	[XmlAttribute(AttributeName = "realName")]
	public string RealName
	{
		get
		{
			return RealNameField;
		}
		set
		{
			RealNameField = value;
		}
	}

	public string getDisplayName()
	{
		return DisplayNameField;
	}

	public void setDisplayName(string val)
	{
		DisplayNameField = val;
	}

	public string getRealName()
	{
		return RealNameField;
	}

	public void setRealName(string val)
	{
		RealNameField = val;
	}
}
