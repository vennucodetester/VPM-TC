using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Teamcenter.Schemas.Soa.Objectpropertypolicy;

[Serializable]
[XmlType(AnonymousType = true)]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Soa/ObjectPropertyPolicy", IsNullable = false)]
[GeneratedCode("xsd2csharp", "1.0")]
[DesignerCategory("code")]
public class ObjectPropertyPolicy
{
	private string WithPropertiesField;

	private bool WithPropertiesFieldSet = false;

	private string ExcludeParentPropertiesField;

	private bool ExcludeParentPropertiesFieldSet = false;

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

	private ObjectType[] ObjectTypeField;

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

	[XmlElement("ObjectType")]
	public ObjectType[] ObjectType
	{
		get
		{
			return ObjectTypeField;
		}
		set
		{
			ObjectTypeField = value;
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

	public ArrayList getObjectType()
	{
		if (ObjectTypeField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(ObjectTypeField);
	}

	public void setObjectType(ArrayList val)
	{
		ObjectTypeField = new ObjectType[val.Count];
		val.CopyTo(ObjectTypeField);
	}
}
