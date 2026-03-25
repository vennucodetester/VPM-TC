using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2007_01.Filemanagement;

[Serializable]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/FileManagement", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetTransientFileTicketsResponse
{
	private TransientFileTicketInfo[] TransientFileTicketInfosField;

	private ServiceData ServiceDataField;

	[XmlElement("transientFileTicketInfos")]
	public TransientFileTicketInfo[] TransientFileTicketInfos
	{
		get
		{
			return TransientFileTicketInfosField;
		}
		set
		{
			TransientFileTicketInfosField = value;
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

	public ArrayList getTransientFileTicketInfos()
	{
		if (TransientFileTicketInfosField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(TransientFileTicketInfosField);
	}

	public void setTransientFileTicketInfos(ArrayList val)
	{
		TransientFileTicketInfosField = new TransientFileTicketInfo[val.Count];
		val.CopyTo(TransientFileTicketInfosField);
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
