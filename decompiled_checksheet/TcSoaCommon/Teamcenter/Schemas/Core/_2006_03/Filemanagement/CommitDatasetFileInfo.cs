using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
public class CommitDatasetFileInfo
{
	private bool CreateNewVersionField;

	private ModelObject DatasetField;

	private DatasetFileTicketInfo[] DatasetFileTicketInfosField;

	[XmlAttribute(AttributeName = "createNewVersion")]
	public bool CreateNewVersion
	{
		get
		{
			return CreateNewVersionField;
		}
		set
		{
			CreateNewVersionField = value;
		}
	}

	[XmlElement("dataset")]
	public ModelObject Dataset
	{
		get
		{
			return DatasetField;
		}
		set
		{
			DatasetField = value;
		}
	}

	[XmlElement("datasetFileTicketInfos")]
	public DatasetFileTicketInfo[] DatasetFileTicketInfos
	{
		get
		{
			return DatasetFileTicketInfosField;
		}
		set
		{
			DatasetFileTicketInfosField = value;
		}
	}

	public bool getCreateNewVersion()
	{
		return CreateNewVersionField;
	}

	public void setCreateNewVersion(bool val)
	{
		CreateNewVersionField = val;
	}

	public ModelObject getDataset()
	{
		return DatasetField;
	}

	public void setDataset(ModelObject val)
	{
		DatasetField = val;
	}

	public ArrayList getDatasetFileTicketInfos()
	{
		if (DatasetFileTicketInfosField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(DatasetFileTicketInfosField);
	}

	public void setDatasetFileTicketInfos(ArrayList val)
	{
		DatasetFileTicketInfosField = new DatasetFileTicketInfo[val.Count];
		val.CopyTo(DatasetFileTicketInfosField);
	}
}
