using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2008_06.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-06/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
public class GetDisplayStringsInput
{
	private string[] InfoField;

	[XmlElement("info")]
	public string[] Info
	{
		get
		{
			return InfoField;
		}
		set
		{
			InfoField = value;
		}
	}

	public ArrayList getInfo()
	{
		if (InfoField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(InfoField);
	}

	public void setInfo(ArrayList val)
	{
		InfoField = new string[val.Count];
		val.CopyTo(InfoField);
	}
}
