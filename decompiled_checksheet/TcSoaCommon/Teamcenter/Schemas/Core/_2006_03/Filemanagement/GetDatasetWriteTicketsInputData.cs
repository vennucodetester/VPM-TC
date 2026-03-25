using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetDatasetWriteTicketsInputData
{
	private bool CreateNewVersionField;

	private ModelObject DatasetField;

	private DatasetFileInfo[] DatasetFileInfosField;

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

	[XmlElement("datasetFileInfos")]
	public DatasetFileInfo[] DatasetFileInfos
	{
		get
		{
			return DatasetFileInfosField;
		}
		set
		{
			DatasetFileInfosField = value;
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

	public ArrayList getDatasetFileInfos()
	{
		if (DatasetFileInfosField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(DatasetFileInfosField);
	}

	public void setDatasetFileInfos(ArrayList val)
	{
		DatasetFileInfosField = new DatasetFileInfo[val.Count];
		val.CopyTo(DatasetFileInfosField);
	}
}
