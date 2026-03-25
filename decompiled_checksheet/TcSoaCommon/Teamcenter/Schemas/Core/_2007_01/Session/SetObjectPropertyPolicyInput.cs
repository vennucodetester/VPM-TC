using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/Session", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
public class SetObjectPropertyPolicyInput
{
	private string PolicyNameField;

	[XmlAttribute(AttributeName = "policyName")]
	public string PolicyName
	{
		get
		{
			return PolicyNameField;
		}
		set
		{
			PolicyNameField = value;
		}
	}

	public string getPolicyName()
	{
		return PolicyNameField;
	}

	public void setPolicyName(string val)
	{
		PolicyNameField = val;
	}
}
