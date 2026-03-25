using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Filemanagement;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/FileManagement", IsNullable = false)]
public class GetTransientFileTicketsForUploadInput
{
	private TransientFileInfo[] TransientFileInfosField;

	[XmlElement("transientFileInfos")]
	public TransientFileInfo[] TransientFileInfos
	{
		get
		{
			return TransientFileInfosField;
		}
		set
		{
			TransientFileInfosField = value;
		}
	}

	public ArrayList getTransientFileInfos()
	{
		if (TransientFileInfosField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(TransientFileInfosField);
	}

	public void setTransientFileInfos(ArrayList val)
	{
		TransientFileInfosField = new TransientFileInfo[val.Count];
		val.CopyTo(TransientFileInfosField);
	}
}
