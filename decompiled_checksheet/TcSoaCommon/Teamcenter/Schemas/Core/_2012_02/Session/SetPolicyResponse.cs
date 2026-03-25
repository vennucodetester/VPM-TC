using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2012_02.Session;

[Serializable]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2012-02/Session", IsNullable = false)]
public class SetPolicyResponse
{
	private string PolicyIdField;

	private ObjectPropertyPolicy ObjectPropertyPolicyField;

	[XmlAttribute(AttributeName = "policyId")]
	public string PolicyId
	{
		get
		{
			return PolicyIdField;
		}
		set
		{
			PolicyIdField = value;
		}
	}

	[XmlElement(ElementName = "ObjectPropertyPolicy", Namespace = "http://teamcenter.com/Schemas/Soa/2006-03/Base")]
	public ObjectPropertyPolicy ObjectPropertyPolicy
	{
		get
		{
			return ObjectPropertyPolicyField;
		}
		set
		{
			ObjectPropertyPolicyField = value;
		}
	}

	public string getPolicyId()
	{
		return PolicyIdField;
	}

	public void setPolicyId(string val)
	{
		PolicyIdField = val;
	}

	public ObjectPropertyPolicy getObjectPropertyPolicy()
	{
		return ObjectPropertyPolicyField;
	}

	public void setObjectPropertyPolicy(ObjectPropertyPolicy val)
	{
		ObjectPropertyPolicyField = val;
	}
}
