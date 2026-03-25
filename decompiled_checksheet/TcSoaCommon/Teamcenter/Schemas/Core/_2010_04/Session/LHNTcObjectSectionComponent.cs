using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class LHNTcObjectSectionComponent
{
	private ModelObject TcObjectField;

	private LHNSectionComponentDetails[] DetailsField;

	[XmlElement("tcObject")]
	public ModelObject TcObject
	{
		get
		{
			return TcObjectField;
		}
		set
		{
			TcObjectField = value;
		}
	}

	[XmlElement("details")]
	public LHNSectionComponentDetails[] Details
	{
		get
		{
			return DetailsField;
		}
		set
		{
			DetailsField = value;
		}
	}

	public ModelObject getTcObject()
	{
		return TcObjectField;
	}

	public void setTcObject(ModelObject val)
	{
		TcObjectField = val;
	}

	public ArrayList getDetails()
	{
		if (DetailsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(DetailsField);
	}

	public void setDetails(ArrayList val)
	{
		DetailsField = new LHNSectionComponentDetails[val.Count];
		val.CopyTo(DetailsField);
	}
}
