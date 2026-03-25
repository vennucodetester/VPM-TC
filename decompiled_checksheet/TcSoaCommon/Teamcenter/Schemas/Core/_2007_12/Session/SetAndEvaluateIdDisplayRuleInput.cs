using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Teamcenter.Schemas.Soa._2006_03.Base;

namespace Teamcenter.Schemas.Core._2007_12.Session;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[GeneratedCode("xsd2csharp", "1.0")]
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://teamcenter.com/Schemas/Core/2007-12/Session", IsNullable = false)]
public class SetAndEvaluateIdDisplayRuleInput
{
	private bool SetRuleAsCurrentInDBField;

	private ModelObject[] IdentifiableObjectsField;

	private ModelObject DisplayRuleField;

	[XmlAttribute(AttributeName = "setRuleAsCurrentInDB")]
	public bool SetRuleAsCurrentInDB
	{
		get
		{
			return SetRuleAsCurrentInDBField;
		}
		set
		{
			SetRuleAsCurrentInDBField = value;
		}
	}

	[XmlElement("identifiableObjects")]
	public ModelObject[] IdentifiableObjects
	{
		get
		{
			return IdentifiableObjectsField;
		}
		set
		{
			IdentifiableObjectsField = value;
		}
	}

	[XmlElement("displayRule")]
	public ModelObject DisplayRule
	{
		get
		{
			return DisplayRuleField;
		}
		set
		{
			DisplayRuleField = value;
		}
	}

	public bool getSetRuleAsCurrentInDB()
	{
		return SetRuleAsCurrentInDBField;
	}

	public void setSetRuleAsCurrentInDB(bool val)
	{
		SetRuleAsCurrentInDBField = val;
	}

	public ArrayList getIdentifiableObjects()
	{
		if (IdentifiableObjectsField == null)
		{
			return new ArrayList();
		}
		return new ArrayList(IdentifiableObjectsField);
	}

	public void setIdentifiableObjects(ArrayList val)
	{
		IdentifiableObjectsField = new ModelObject[val.Count];
		val.CopyTo(IdentifiableObjectsField);
	}

	public ModelObject getDisplayRule()
	{
		return DisplayRuleField;
	}

	public void setDisplayRule(ModelObject val)
	{
		DisplayRuleField = val;
	}
}
