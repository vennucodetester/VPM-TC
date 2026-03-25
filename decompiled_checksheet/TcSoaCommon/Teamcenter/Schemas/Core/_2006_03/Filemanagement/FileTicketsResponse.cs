using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
public class FileTicketsResponse
{
	private TicketMap[] TicketsField;

	private ServiceData ServiceDataField;

	[XmlElement("tickets")]
	public TicketMap[] Tickets
	{
		get
		{
			return TicketsField;
		}
		set
		{
			TicketsField = value;
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

	public ArrayList getTickets()
	{
		if (TicketsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(TicketsField);
	}

	public void setTickets(ArrayList val)
	{
		TicketsField = new TicketMap[val.Count];
		val.CopyTo(TicketsField);
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
