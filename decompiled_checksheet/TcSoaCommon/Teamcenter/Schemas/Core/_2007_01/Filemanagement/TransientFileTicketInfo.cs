using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Filemanagement;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/FileManagement", IsNullable = false)]
[XmlType(AnonymousType = true)]
public class TransientFileTicketInfo
{
	private string TicketField;

	private TransientFileInfo TransientFileInfoField;

	[XmlAttribute(AttributeName = "ticket")]
	public string Ticket
	{
		get
		{
			return TicketField;
		}
		set
		{
			TicketField = value;
		}
	}

	[XmlElement("transientFileInfo")]
	public TransientFileInfo TransientFileInfo
	{
		get
		{
			return TransientFileInfoField;
		}
		set
		{
			TransientFileInfoField = value;
		}
	}

	public string getTicket()
	{
		return TicketField;
	}

	public void setTicket(string val)
	{
		TicketField = val;
	}

	public TransientFileInfo getTransientFileInfo()
	{
		return TransientFileInfoField;
	}

	public void setTransientFileInfo(TransientFileInfo val)
	{
		TransientFileInfoField = val;
	}
}
