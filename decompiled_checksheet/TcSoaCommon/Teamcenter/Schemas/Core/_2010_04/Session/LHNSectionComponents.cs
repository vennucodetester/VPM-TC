using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class LHNSectionComponents
{
	private LHNNonTcObjectSectionComponentMap[] NonTcObjectsField;

	private LHNTcObjectSectionComponentMap[] TcObjectsField;

	[XmlElement("nonTcObjects")]
	public LHNNonTcObjectSectionComponentMap[] NonTcObjects
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

	[XmlElement("tcObjects")]
	public LHNTcObjectSectionComponentMap[] TcObjects
	{
		get
		{
			return TcObjectsField;
		}
		set
		{
			TcObjectsField = value;
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
		NonTcObjectsField = new LHNNonTcObjectSectionComponentMap[val.Count];
		val.CopyTo(NonTcObjectsField);
	}

	public ArrayList getTcObjects()
	{
		if (TcObjectsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(TcObjectsField);
	}

	public void setTcObjects(ArrayList val)
	{
		TcObjectsField = new LHNTcObjectSectionComponentMap[val.Count];
		val.CopyTo(TcObjectsField);
	}
}
