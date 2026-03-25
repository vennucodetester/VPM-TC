using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
public class CommitDatasetFilesInput
{
	private CommitDatasetFileInfo[] CommitInputField;

	[XmlElement("commitInput")]
	public CommitDatasetFileInfo[] CommitInput
	{
		get
		{
			return CommitInputField;
		}
		set
		{
			CommitInputField = value;
		}
	}

	public ArrayList getCommitInput()
	{
		if (CommitInputField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(CommitInputField);
	}

	public void setCommitInput(ArrayList val)
	{
		CommitInputField = new CommitDatasetFileInfo[val.Count];
		val.CopyTo(CommitInputField);
	}
}
