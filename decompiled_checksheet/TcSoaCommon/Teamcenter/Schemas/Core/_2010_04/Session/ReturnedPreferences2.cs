using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Core._2010_04.Session;

[Serializable]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2010-04/Session", IsNullable = false)]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
public class ReturnedPreferences2
{
	private bool IsDisabledField;

	private bool IsArrayField;

	private string NameField;

	private int PrefTypeField;

	private string ScopeField;

	private string DescriptionField;

	private string CategoryField;

	private string[] ValuesField;

	[XmlAttribute(AttributeName = "isDisabled")]
	public bool IsDisabled
	{
		get
		{
			return IsDisabledField;
		}
		set
		{
			IsDisabledField = value;
		}
	}

	[XmlAttribute(AttributeName = "isArray")]
	public bool IsArray
	{
		get
		{
			return IsArrayField;
		}
		set
		{
			IsArrayField = value;
		}
	}

	[XmlAttribute(AttributeName = "name")]
	public string Name
	{
		get
		{
			return NameField;
		}
		set
		{
			NameField = value;
		}
	}

	[XmlAttribute(AttributeName = "prefType")]
	public int PrefType
	{
		get
		{
			return PrefTypeField;
		}
		set
		{
			PrefTypeField = value;
		}
	}

	[XmlAttribute(AttributeName = "scope")]
	public string Scope
	{
		get
		{
			return ScopeField;
		}
		set
		{
			ScopeField = value;
		}
	}

	[XmlAttribute(AttributeName = "description")]
	public string Description
	{
		get
		{
			return DescriptionField;
		}
		set
		{
			DescriptionField = value;
		}
	}

	[XmlAttribute(AttributeName = "category")]
	public string Category
	{
		get
		{
			return CategoryField;
		}
		set
		{
			CategoryField = value;
		}
	}

	[XmlElement("values")]
	public string[] Values
	{
		get
		{
			return ValuesField;
		}
		set
		{
			ValuesField = value;
		}
	}

	public bool getIsDisabled()
	{
		return IsDisabledField;
	}

	public void setIsDisabled(bool val)
	{
		IsDisabledField = val;
	}

	public bool getIsArray()
	{
		return IsArrayField;
	}

	public void setIsArray(bool val)
	{
		IsArrayField = val;
	}

	public string getName()
	{
		return NameField;
	}

	public void setName(string val)
	{
		NameField = val;
	}

	public int getPrefType()
	{
		return PrefTypeField;
	}

	public void setPrefType(int val)
	{
		PrefTypeField = val;
	}

	public string getScope()
	{
		return ScopeField;
	}

	public void setScope(string val)
	{
		ScopeField = val;
	}

	public string getDescription()
	{
		return DescriptionField;
	}

	public void setDescription(string val)
	{
		DescriptionField = val;
	}

	public string getCategory()
	{
		return CategoryField;
	}

	public void setCategory(string val)
	{
		CategoryField = val;
	}

	public ArrayList getValues()
	{
		if (ValuesField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ValuesField);
	}

	public void setValues(ArrayList val)
	{
		ValuesField = new string[val.Count];
		val.CopyTo(ValuesField);
	}
}
