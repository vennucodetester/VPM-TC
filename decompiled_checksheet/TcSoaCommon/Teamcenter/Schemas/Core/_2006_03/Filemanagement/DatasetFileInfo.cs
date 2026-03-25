using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2006_03.Filemanagement;

[Serializable]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2006-03/FileManagement", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
public class DatasetFileInfo
{
	private string ClientIdField;

	private bool AllowReplaceField;

	private string NamedReferencedNameField;

	private bool IsTextField;

	private string FileNameField;

	[XmlAttribute(AttributeName = "clientId")]
	public string ClientId
	{
		get
		{
			return ClientIdField;
		}
		set
		{
			ClientIdField = value;
		}
	}

	[XmlAttribute(AttributeName = "allowReplace")]
	public bool AllowReplace
	{
		get
		{
			return AllowReplaceField;
		}
		set
		{
			AllowReplaceField = value;
		}
	}

	[XmlAttribute(AttributeName = "namedReferencedName")]
	public string NamedReferencedName
	{
		get
		{
			return NamedReferencedNameField;
		}
		set
		{
			NamedReferencedNameField = value;
		}
	}

	[XmlAttribute(AttributeName = "isText")]
	public bool IsText
	{
		get
		{
			return IsTextField;
		}
		set
		{
			IsTextField = value;
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

	public string getClientId()
	{
		return ClientIdField;
	}

	public void setClientId(string val)
	{
		ClientIdField = val;
	}

	public bool getAllowReplace()
	{
		return AllowReplaceField;
	}

	public void setAllowReplace(bool val)
	{
		AllowReplaceField = val;
	}

	public string getNamedReferencedName()
	{
		return NamedReferencedNameField;
	}

	public void setNamedReferencedName(string val)
	{
		NamedReferencedNameField = val;
	}

	public bool getIsText()
	{
		return IsTextField;
	}

	public void setIsText(bool val)
	{
		IsTextField = val;
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
