using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
public class GetDatasetWriteTicketsResponse
{
	private CommitDatasetFileInfo[] CommitInfoField;

	private ServiceData ServiceDataField;

	[XmlElement("commitInfo")]
	public CommitDatasetFileInfo[] CommitInfo
	{
		get
		{
			return CommitInfoField;
		}
		set
		{
			CommitInfoField = value;
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

	public ArrayList getCommitInfo()
	{
		if (CommitInfoField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(CommitInfoField);
	}

	public void setCommitInfo(ArrayList val)
	{
		CommitInfoField = new CommitDatasetFileInfo[val.Count];
		val.CopyTo(CommitInfoField);
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
