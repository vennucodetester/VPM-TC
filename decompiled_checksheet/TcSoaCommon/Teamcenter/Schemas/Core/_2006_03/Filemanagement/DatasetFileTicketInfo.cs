using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[DesignerCategory("code")]
[DebuggerStepThrough]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
public class DatasetFileTicketInfo
{
	private string TicketField;

	private DatasetFileInfo DatasetFileInfoField;

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

	[XmlElement("datasetFileInfo")]
	public DatasetFileInfo DatasetFileInfo
	{
		get
		{
			return DatasetFileInfoField;
		}
		set
		{
			DatasetFileInfoField = value;
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

	public DatasetFileInfo getDatasetFileInfo()
	{
		return DatasetFileInfoField;
	}

	public void setDatasetFileInfo(DatasetFileInfo val)
	{
		DatasetFileInfoField = val;
	}
}
