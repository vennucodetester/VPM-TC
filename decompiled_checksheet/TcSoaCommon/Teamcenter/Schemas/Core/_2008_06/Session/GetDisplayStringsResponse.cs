using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2008_06.Session;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2008-06/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
public class GetDisplayStringsResponse
{
	private GetDisplayStringsOutput[] OutputField;

	private ServiceData ServiceDataField;

	[XmlElement("output")]
	public GetDisplayStringsOutput[] Output
	{
		get
		{
			return OutputField;
		}
		set
		{
			OutputField = value;
		}
	}

	[XmlElement(ElementName = "ServiceData", Namespace = "http://teamcenter.com/Schemas/Soa/2006-03/Base")]
	public ServiceData ServiceData
	{
		get
		{
			return ServiceDataField;
		}
		set
		{
			ServiceDataField = value;
		}
	}

	public ArrayList getOutput()
	{
		if (OutputField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(OutputField);
	}

	public void setOutput(ArrayList val)
	{
		OutputField = new GetDisplayStringsOutput[val.Count];
		val.CopyTo(OutputField);
	}

	public ServiceData getServiceData()
	{
		return ServiceDataField;
	}

	public void setServiceData(ServiceData val)
	{
		ServiceDataField = val;
	}
}
