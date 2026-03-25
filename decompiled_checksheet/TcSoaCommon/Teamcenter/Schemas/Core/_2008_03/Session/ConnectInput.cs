using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2008_03.Session;

[Serializable]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-03/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[DesignerCategory("code")]
public class ConnectInput
{
	private string ActionField;

	private string FeatureKeyField;

	[XmlAttribute(AttributeName = "action")]
	public string Action
	{
		get
		{
			return ActionField;
		}
		set
		{
			ActionField = value;
		}
	}

	[XmlAttribute(AttributeName = "featureKey")]
	public string FeatureKey
	{
		get
		{
			return FeatureKeyField;
		}
		set
		{
			FeatureKeyField = value;
		}
	}

	public string getAction()
	{
		return ActionField;
	}

	public void setAction(string val)
	{
		ActionField = val;
	}

	public string getFeatureKey()
	{
		return FeatureKeyField;
	}

	public void setFeatureKey(string val)
	{
		FeatureKeyField = val;
	}
}
