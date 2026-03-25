using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2012_02.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2012-02/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class SetObjectPropertyPolicyInput
{
	private bool UseRefCountingField;

	private string PolicyNameField;

	[XmlAttribute(AttributeName = "useRefCounting")]
	public bool UseRefCounting
	{
		get
		{
			return UseRefCountingField;
		}
		set
		{
			UseRefCountingField = value;
		}
	}

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

	public bool getUseRefCounting()
	{
		return UseRefCountingField;
	}

	public void setUseRefCounting(bool val)
	{
		UseRefCountingField = val;
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
