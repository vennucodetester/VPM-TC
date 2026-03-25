using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Soa.Objectpropertypolicy;

[Serializable]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Soa/ObjectPropertyPolicy", IsNullable = false)]
[XmlType(AnonymousType = true)]
public class ObjectType
{
	private string WithPropertiesField;

	private bool WithPropertiesFieldSet = false;

	private string ExcludeParentPropertiesField;

	private bool ExcludeParentPropertiesFieldSet = false;

	private string NameField;

	private string AsAttributeField;

	private bool AsAttributeFieldSet = false;

	private string UIValueOnlyField;

	private bool UIValueOnlyFieldSet = false;

	private string ExcludeUiValuesField;

	private bool ExcludeUiValuesFieldSet = false;

	private string ExcludeIsModifiableField;

	private bool ExcludeIsModifiableFieldSet = false;

	private string IncludeIsModifiableField;

	private bool IncludeIsModifiableFieldSet = false;

	private Property[] PropertyField;

	[XmlAttribute(AttributeName = "withProperties")]
	public string WithProperties
	{
		get
		{
			return WithPropertiesField;
		}
		set
		{
			WithPropertiesField = value;
			WithPropertiesFieldSet = true;
		}
	}

	public bool IsWithPropertiesSet => WithPropertiesFieldSet;

	[XmlAttribute(AttributeName = "excludeParentProperties")]
	public string ExcludeParentProperties
	{
		get
		{
			return ExcludeParentPropertiesField;
		}
		set
		{
			ExcludeParentPropertiesField = value;
			ExcludeParentPropertiesFieldSet = true;
		}
	}

	public bool IsExcludeParentPropertiesSet => ExcludeParentPropertiesFieldSet;

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

	[XmlAttribute(AttributeName = "asAttribute")]
	public string AsAttribute
	{
		get
		{
			return AsAttributeField;
		}
		set
		{
			AsAttributeField = value;
			AsAttributeFieldSet = true;
		}
	}

	public bool IsAsAttributeSet => AsAttributeFieldSet;

	[XmlAttribute(AttributeName = "uIValueOnly")]
	public string UIValueOnly
	{
		get
		{
			return UIValueOnlyField;
		}
		set
		{
			UIValueOnlyField = value;
			UIValueOnlyFieldSet = true;
		}
	}

	public bool IsUIValueOnlySet => UIValueOnlyFieldSet;

	[XmlAttribute(AttributeName = "excludeUiValues")]
	public string ExcludeUiValues
	{
		get
		{
			return ExcludeUiValuesField;
		}
		set
		{
			ExcludeUiValuesField = value;
			ExcludeUiValuesFieldSet = true;
		}
	}

	public bool IsExcludeUiValuesSet => ExcludeUiValuesFieldSet;

	[XmlAttribute(AttributeName = "excludeIsModifiable")]
	public string ExcludeIsModifiable
	{
		get
		{
			return ExcludeIsModifiableField;
		}
		set
		{
			ExcludeIsModifiableField = value;
			ExcludeIsModifiableFieldSet = true;
		}
	}

	public bool IsExcludeIsModifiableSet => ExcludeIsModifiableFieldSet;

	[XmlAttribute(AttributeName = "includeIsModifiable")]
	public string IncludeIsModifiable
	{
		get
		{
			return IncludeIsModifiableField;
		}
		set
		{
			IncludeIsModifiableField = value;
			IncludeIsModifiableFieldSet = true;
		}
	}

	public bool IsIncludeIsModifiableSet => IncludeIsModifiableFieldSet;

	[XmlElement("Property")]
	public Property[] Property
	{
		get
		{
			return PropertyField;
		}
		set
		{
			PropertyField = value;
		}
	}

	public string getWithProperties()
	{
		return WithPropertiesField;
	}

	public void setWithProperties(string val)
	{
		WithPropertiesField = val;
		WithPropertiesFieldSet = true;
	}

	public string getExcludeParentProperties()
	{
		return ExcludeParentPropertiesField;
	}

	public void setExcludeParentProperties(string val)
	{
		ExcludeParentPropertiesField = val;
		ExcludeParentPropertiesFieldSet = true;
	}

	public string getName()
	{
		return NameField;
	}

	public void setName(string val)
	{
		NameField = val;
	}

	public string getAsAttribute()
	{
		return AsAttributeField;
	}

	public void setAsAttribute(string val)
	{
		AsAttributeField = val;
		AsAttributeFieldSet = true;
	}

	public string getUIValueOnly()
	{
		return UIValueOnlyField;
	}

	public void setUIValueOnly(string val)
	{
		UIValueOnlyField = val;
		UIValueOnlyFieldSet = true;
	}

	public string getExcludeUiValues()
	{
		return ExcludeUiValuesField;
	}

	public void setExcludeUiValues(string val)
	{
		ExcludeUiValuesField = val;
		ExcludeUiValuesFieldSet = true;
	}

	public string getExcludeIsModifiable()
	{
		return ExcludeIsModifiableField;
	}

	public void setExcludeIsModifiable(string val)
	{
		ExcludeIsModifiableField = val;
		ExcludeIsModifiableFieldSet = true;
	}

	public string getIncludeIsModifiable()
	{
		return IncludeIsModifiableField;
	}

	public void setIncludeIsModifiable(string val)
	{
		IncludeIsModifiableField = val;
		IncludeIsModifiableFieldSet = true;
	}

	public ArrayList getProperty()
	{
		if (PropertyField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(PropertyField);
	}

	public void setProperty(ArrayList val)
	{
		PropertyField = new Property[val.Count];
		val.CopyTo(PropertyField);
	}
}
