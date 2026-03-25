using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2008_06.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-06/Session", IsNullable = false)]
public class SetObjectPropertyPolicyInput
{
	private ObjectPropertyPolicy ObjectPropertyPolicyField;

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

	public ObjectPropertyPolicy getObjectPropertyPolicy()
	{
		return ObjectPropertyPolicyField;
	}

	public void setObjectPropertyPolicy(ObjectPropertyPolicy val)
	{
		ObjectPropertyPolicyField = val;
	}
}
