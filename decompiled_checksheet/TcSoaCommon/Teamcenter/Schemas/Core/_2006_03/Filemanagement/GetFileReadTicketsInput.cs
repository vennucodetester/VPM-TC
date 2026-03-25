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
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetFileReadTicketsInput
{
	private ModelObject[] FilesField;

	[XmlElement("files")]
	public ModelObject[] Files
	{
		get
		{
			return FilesField;
		}
		set
		{
			FilesField = value;
		}
	}

	public ArrayList getFiles()
	{
		if (FilesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(FilesField);
	}

	public void setFiles(ArrayList val)
	{
		FilesField = new ModelObject[val.Count];
		val.CopyTo(FilesField);
	}
}
