using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Teamcenter.Schemas.Soa.Objectpropertypolicy;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Common;

namespace Teamcenter.Soa.Internal.Common;

public class PolicyMarshaller
{
	private static readonly string PROPERTY = "Property";

	private static readonly string COMMENTS = "#comment";

	public static Teamcenter.Schemas.Soa._2006_03.Base.PolicyProperty ToWire(Teamcenter.Soa.Common.PolicyProperty policyProperty)
	{
		Teamcenter.Schemas.Soa._2006_03.Base.PolicyProperty policyProperty2 = new Teamcenter.Schemas.Soa._2006_03.Base.PolicyProperty();
		policyProperty2.setName(policyProperty.Name);
		ArrayList arrayList = new ArrayList();
		foreach (string modifierName in policyProperty.ModifierNames)
		{
			Modifiers modifiers = new Modifiers();
			modifiers.setName(modifierName);
			modifiers.setValue(policyProperty.GetBooleanModifier(modifierName) ? "1" : "0");
			arrayList.Add(modifiers);
		}
		policyProperty2.setModifiers(arrayList);
		return policyProperty2;
	}

	public static Teamcenter.Schemas.Soa._2006_03.Base.PolicyType ToWire(Teamcenter.Soa.Common.PolicyType policyType)
	{
		Teamcenter.Schemas.Soa._2006_03.Base.PolicyType policyType2 = new Teamcenter.Schemas.Soa._2006_03.Base.PolicyType();
		policyType2.setName(policyType.Name);
		ArrayList arrayList = new ArrayList();
		foreach (string modifierName in policyType.ModifierNames)
		{
			Modifiers modifiers = new Modifiers();
			modifiers.setName(modifierName);
			modifiers.setValue(policyType.GetBooleanModifier(modifierName) ? "1" : "0");
			arrayList.Add(modifiers);
		}
		policyType2.setModifiers(arrayList);
		ArrayList arrayList2 = new ArrayList();
		foreach (KeyValuePair<string, Teamcenter.Soa.Common.PolicyProperty> property in policyType.Properties)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.PolicyProperty value = ToWire(property.Value);
			arrayList2.Add(value);
		}
		policyType2.setProperties(arrayList2);
		return policyType2;
	}

	public static Teamcenter.Schemas.Soa._2006_03.Base.ObjectPropertyPolicy ToWire(Teamcenter.Soa.Common.ObjectPropertyPolicy objectPropertyPolicy)
	{
		Teamcenter.Schemas.Soa._2006_03.Base.ObjectPropertyPolicy objectPropertyPolicy2 = new Teamcenter.Schemas.Soa._2006_03.Base.ObjectPropertyPolicy();
		ArrayList arrayList = new ArrayList();
		foreach (string modifierName in objectPropertyPolicy.ModifierNames)
		{
			Modifiers modifiers = new Modifiers();
			modifiers.setName(modifierName);
			modifiers.setValue(objectPropertyPolicy.GetBooleanModifier(modifierName) ? "1" : "0");
			arrayList.Add(modifiers);
		}
		objectPropertyPolicy2.setModifiers(arrayList);
		ArrayList arrayList2 = new ArrayList();
		foreach (KeyValuePair<string, Teamcenter.Soa.Common.PolicyType> type in objectPropertyPolicy.Types)
		{
			arrayList2.Add(ToWire(type.Value));
		}
		objectPropertyPolicy2.setTypes(arrayList2);
		return objectPropertyPolicy2;
	}

	public static Teamcenter.Soa.Common.PolicyProperty ToLocal(Teamcenter.Schemas.Soa._2006_03.Base.PolicyProperty xsdProperty)
	{
		Teamcenter.Soa.Common.PolicyProperty policyProperty = new Teamcenter.Soa.Common.PolicyProperty(xsdProperty.getName());
		foreach (Modifiers modifier in xsdProperty.getModifiers())
		{
			string name = modifier.Name;
			bool value = ((modifier.Value.Equals("1") || modifier.Value.Equals("true")) ? true : false);
			policyProperty.SetModifier(name, value);
		}
		return policyProperty;
	}

	public static Teamcenter.Soa.Common.PolicyType ToLocal(Teamcenter.Schemas.Soa._2006_03.Base.PolicyType xsdType)
	{
		Teamcenter.Soa.Common.PolicyType policyType = new Teamcenter.Soa.Common.PolicyType(xsdType.getName());
		foreach (Modifiers modifier in xsdType.getModifiers())
		{
			string name = modifier.Name;
			bool value = ((modifier.Value.Equals("1") || modifier.Value.Equals("true")) ? true : false);
			policyType.SetModifier(name, value);
		}
		foreach (Teamcenter.Schemas.Soa._2006_03.Base.PolicyProperty property in xsdType.getProperties())
		{
			Teamcenter.Soa.Common.PolicyProperty prop = ToLocal(property);
			policyType.AddProperty(prop);
		}
		return policyType;
	}

	public static Teamcenter.Soa.Common.ObjectPropertyPolicy ToLocal(Teamcenter.Schemas.Soa._2006_03.Base.ObjectPropertyPolicy wire)
	{
		Teamcenter.Soa.Common.ObjectPropertyPolicy objectPropertyPolicy = new Teamcenter.Soa.Common.ObjectPropertyPolicy();
		ArrayList modifiers = wire.getModifiers();
		foreach (Modifiers item in modifiers)
		{
			string name = item.getName();
			bool value = ((item.Value.Equals("1") || item.Value.Equals("true")) ? true : false);
			objectPropertyPolicy.SetModifier(name, value);
		}
		foreach (Teamcenter.Schemas.Soa._2006_03.Base.PolicyType type in wire.getTypes())
		{
			objectPropertyPolicy.AddType(ToLocal(type));
		}
		return objectPropertyPolicy;
	}

	public static Teamcenter.Soa.Common.PolicyProperty ParseProperty(XmlNode typeNode)
	{
		Teamcenter.Soa.Common.PolicyProperty policyProperty = null;
		for (int i = 0; i < typeNode.Attributes.Count; i++)
		{
			XmlAttribute xmlAttribute = typeNode.Attributes[i];
			if (xmlAttribute.Name.Equals("name"))
			{
				policyProperty = new Teamcenter.Soa.Common.PolicyProperty(xmlAttribute.Value);
			}
		}
		for (int i = 0; i < typeNode.Attributes.Count; i++)
		{
			XmlAttribute xmlAttribute = typeNode.Attributes[i];
			if (!xmlAttribute.Name.Equals("name"))
			{
				policyProperty.SetModifier(xmlAttribute.Name, Convert.ToBoolean(xmlAttribute.Value));
			}
		}
		return policyProperty;
	}

	public static Teamcenter.Soa.Common.PolicyType ParseType(XmlNode typeNode)
	{
		Teamcenter.Soa.Common.PolicyType policyType = null;
		for (int i = 0; i < typeNode.Attributes.Count; i++)
		{
			XmlAttribute xmlAttribute = typeNode.Attributes[i];
			if (xmlAttribute.Name.Equals("name"))
			{
				policyType = new Teamcenter.Soa.Common.PolicyType(xmlAttribute.Value);
			}
		}
		for (int i = 0; i < typeNode.Attributes.Count; i++)
		{
			XmlAttribute xmlAttribute = typeNode.Attributes[i];
			if (!xmlAttribute.Name.Equals("name"))
			{
				policyType.SetModifier(xmlAttribute.Name, Convert.ToBoolean(xmlAttribute.Value));
			}
		}
		XmlNodeList childNodes = typeNode.ChildNodes;
		try
		{
			for (int j = 0; j < childNodes.Count; j++)
			{
				XmlNode xmlNode = childNodes[j];
				if (xmlNode.Name.Equals(PROPERTY))
				{
					policyType.AddProperty(ParseProperty(xmlNode));
				}
				else if (!xmlNode.Name.Equals(COMMENTS))
				{
					throw new IOException("\nThe policy file does not conform to the schema, and refer to the Teamcenter Services Guide for more information");
				}
			}
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException(ex.Message);
		}
		return policyType;
	}

	public static void Serialize(object objProperty, Dictionary<string, string> modifiers)
	{
		Type type = objProperty.GetType();
		foreach (KeyValuePair<string, string> modifier in modifiers)
		{
			string text = char.ToUpper(modifier.Key[0]) + modifier.Key.Substring(1);
			MethodInfo method = type.GetMethod("set" + text);
			object[] parameters = new object[1] { modifier.Value };
			method.Invoke(objProperty, parameters);
		}
	}

	public static Teamcenter.Schemas.Soa.Objectpropertypolicy.Property Serialize(Teamcenter.Soa.Common.PolicyProperty policyProperty)
	{
		Teamcenter.Schemas.Soa.Objectpropertypolicy.Property property = new Teamcenter.Schemas.Soa.Objectpropertypolicy.Property();
		property.setName(policyProperty.Name);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (string modifierName in policyProperty.ModifierNames)
		{
			dictionary.Add(modifierName, Convert.ToString(policyProperty.GetBooleanModifier(modifierName)));
		}
		Serialize(property, dictionary);
		return property;
	}

	public static ObjectType Serialize(Teamcenter.Soa.Common.PolicyType policyType)
	{
		ObjectType objectType = new ObjectType();
		objectType.setName(policyType.Name);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (string modifierName in policyType.ModifierNames)
		{
			dictionary.Add(modifierName, Convert.ToString(policyType.GetBooleanModifier(modifierName)));
		}
		Serialize(objectType, dictionary);
		ArrayList arrayList = new ArrayList();
		foreach (KeyValuePair<string, Teamcenter.Soa.Common.PolicyProperty> property in policyType.Properties)
		{
			arrayList.Add(Serialize(property.Value));
		}
		objectType.setProperty(arrayList);
		return objectType;
	}
}
