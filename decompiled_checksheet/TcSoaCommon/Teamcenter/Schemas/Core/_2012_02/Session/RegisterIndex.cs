using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2012_02.Session;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2012-02/Session", IsNullable = false)]
public class RegisterIndex
{
	private int RegistryIndexField;

	[XmlAttribute(AttributeName = "registryIndex")]
	public int RegistryIndex
	{
		get
		{
			return RegistryIndexField;
		}
		set
		{
			RegistryIndexField = value;
		}
	}

	public int getRegistryIndex()
	{
		return RegistryIndexField;
	}

	public void setRegistryIndex(int val)
	{
		RegistryIndexField = val;
	}
}
