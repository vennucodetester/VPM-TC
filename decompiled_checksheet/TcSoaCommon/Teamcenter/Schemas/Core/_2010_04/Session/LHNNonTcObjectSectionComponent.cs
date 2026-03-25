using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
public class LHNNonTcObjectSectionComponent
{
	private LHNSectionComponentDetails[] NonTcObjectsField;

	[XmlElement("nonTcObjects")]
	public LHNSectionComponentDetails[] NonTcObjects
	{
		get
		{
			return NonTcObjectsField;
		}
		set
		{
			NonTcObjectsField = value;
		}
	}

	public ArrayList getNonTcObjects()
	{
		if (NonTcObjectsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(NonTcObjectsField);
	}

	public void setNonTcObjects(ArrayList val)
	{
		NonTcObjectsField = new LHNSectionComponentDetails[val.Count];
		val.CopyTo(NonTcObjectsField);
	}
}
