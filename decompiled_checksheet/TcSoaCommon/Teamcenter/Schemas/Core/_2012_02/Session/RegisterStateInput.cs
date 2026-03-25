using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2012_02.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2012-02/Session", IsNullable = false)]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
public class RegisterStateInput
{
	private string LevelField;

	[XmlAttribute(AttributeName = "level")]
	public string Level
	{
		get
		{
			return LevelField;
		}
		set
		{
			LevelField = value;
		}
	}

	public string getLevel()
	{
		return LevelField;
	}

	public void setLevel(string val)
	{
		LevelField = val;
	}
}
