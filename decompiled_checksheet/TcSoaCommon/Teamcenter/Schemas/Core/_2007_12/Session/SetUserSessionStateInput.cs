using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_12.Session;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-12/Session", IsNullable = false)]
public class SetUserSessionStateInput
{
	private StateNameValue[] PairsField;

	[XmlElement("pairs")]
	public StateNameValue[] Pairs
	{
		get
		{
			return PairsField;
		}
		set
		{
			PairsField = value;
		}
	}

	public ArrayList getPairs()
	{
		if (PairsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(PairsField);
	}

	public void setPairs(ArrayList val)
	{
		PairsField = new StateNameValue[val.Count];
		val.CopyTo(PairsField);
	}
}
