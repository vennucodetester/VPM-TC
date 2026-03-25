using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2007_01.Filemanagement;

[Serializable]
[DesignerCategory("code")]
[GeneratedCode("xsd2csharp", "1.0")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-01/FileManagement", IsNullable = false)]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
public class TransientFileInfo
{
	private bool IsBinaryField;

	private bool DeleteFlagField;

	private string FileNameField;

	[XmlAttribute(AttributeName = "isBinary")]
	public bool IsBinary
	{
		get
		{
			return IsBinaryField;
		}
		set
		{
			IsBinaryField = value;
		}
	}

	[XmlAttribute(AttributeName = "deleteFlag")]
	public bool DeleteFlag
	{
		get
		{
			return DeleteFlagField;
		}
		set
		{
			DeleteFlagField = value;
		}
	}

	[XmlAttribute(AttributeName = "fileName")]
	public string FileName
	{
		get
		{
			return FileNameField;
		}
		set
		{
			FileNameField = value;
		}
	}

	public bool getIsBinary()
	{
		return IsBinaryField;
	}

	public void setIsBinary(bool val)
	{
		IsBinaryField = val;
	}

	public bool getDeleteFlag()
	{
		return DeleteFlagField;
	}

	public void setDeleteFlag(bool val)
	{
		DeleteFlagField = val;
	}

	public string getFileName()
	{
		return FileNameField;
	}

	public void setFileName(string val)
	{
		FileNameField = val;
	}
}
