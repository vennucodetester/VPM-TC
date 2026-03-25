using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Teamcenter.Schemas.Soa.Objectpropertypolicy;
using Teamcenter.Soa.Common.Utils;
using Teamcenter.Soa.Internal.Common;

namespace Teamcenter.Soa.Common;

[Serializable]
public class ObjectPropertyPolicy
{
	private Dictionary<string, PolicyType> mPolicyTypes = new Dictionary<string, PolicyType>();

	private Dictionary<string, string> mPolicyModifiers = new Dictionary<string, string>();

	private static readonly string OBJTYPES = "ObjectType";

	private static readonly string OBJPROPPOLICY = "ObjectPropertyPolicy";

	private static readonly string COMMENTS = "#comment";

	private static readonly string INCLUDE = "Include";

	public Dictionary<string, PolicyType> Types => mPolicyTypes;

	public List<string> TypeNames
	{
		get
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, PolicyType> mPolicyType in mPolicyTypes)
			{
				list.Add(mPolicyType.Key);
			}
			return list;
		}
	}

	public List<string> ModifierNames
	{
		get
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> mPolicyModifier in mPolicyModifiers)
			{
				list.Add(mPolicyModifier.Key);
			}
			return list;
		}
	}

	public ObjectPropertyPolicy()
	{
	}

	public ObjectPropertyPolicy(Dictionary<string, PolicyType> objects, Dictionary<string, string> modifiers)
	{
		mPolicyTypes = objects;
		mPolicyModifiers = modifiers;
	}

	public void AddType(PolicyType policyType)
	{
		MergeModifiers(policyType);
		PolicyType type = GetType(policyType.Name);
		if (type == null)
		{
			mPolicyTypes[policyType.Name] = policyType;
			return;
		}
		foreach (KeyValuePair<string, PolicyProperty> property in policyType.Properties)
		{
			type.AddProperty(property.Value);
		}
	}

	public void AddType(string name)
	{
		AddType(new PolicyType(name));
	}

	public void AddType(string name, string[] properties)
	{
		AddType(new PolicyType(name, properties));
	}

	public PolicyType GetType(string name)
	{
		foreach (KeyValuePair<string, PolicyType> mPolicyType in mPolicyTypes)
		{
			if (mPolicyType.Key.Equals(name))
			{
				return mPolicyType.Value;
			}
		}
		return null;
	}

	public bool RemoveType(string typeName)
	{
		if (mPolicyTypes.ContainsKey(typeName))
		{
			mPolicyTypes.Remove(typeName);
			return true;
		}
		return false;
	}

	public bool RemoveProperties(PolicyType type)
	{
		PolicyType type2 = GetType(type.Name);
		if (type2 != null)
		{
			List<string> propertyNames = type.PropertyNames;
			if (propertyNames.Count == 0)
			{
				return RemoveType(type.Name);
			}
			for (int i = 0; i < propertyNames.Count; i++)
			{
				type2.EraseProperty(propertyNames[i]);
			}
			return true;
		}
		return false;
	}

	public void SetModifier(string name, bool value)
	{
		string value2 = (value ? "1" : "0");
		mPolicyModifiers[name] = value2;
		foreach (KeyValuePair<string, PolicyType> mPolicyType in mPolicyTypes)
		{
			MergeModifiers(mPolicyType.Value);
		}
	}

	public bool GetBooleanModifier(string name)
	{
		if (mPolicyModifiers.ContainsKey(name))
		{
			return (mPolicyModifiers[name].Equals("1") || mPolicyModifiers[name].Equals("true")) ? true : false;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ObjectPropertyPolicy))
		{
			return false;
		}
		ObjectPropertyPolicy objectPropertyPolicy = (ObjectPropertyPolicy)obj;
		if (mPolicyModifiers.Count != objectPropertyPolicy.mPolicyModifiers.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, string> mPolicyModifier in mPolicyModifiers)
		{
			string text = mPolicyModifiers[mPolicyModifier.Key];
			string value = objectPropertyPolicy.mPolicyModifiers[mPolicyModifier.Key];
			if (!text.Equals(value))
			{
				return false;
			}
		}
		if (mPolicyTypes.Count != objectPropertyPolicy.mPolicyTypes.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, PolicyType> mPolicyType in mPolicyTypes)
		{
			PolicyType policyType = mPolicyTypes[mPolicyType.Key];
			PolicyType obj2 = objectPropertyPolicy.mPolicyTypes[mPolicyType.Key];
			if (!policyType.Equals(obj2))
			{
				return false;
			}
		}
		return true;
	}

	private void MergeModifiers(PolicyType policyType)
	{
		List<string> modifierNames = policyType.ModifierNames;
		foreach (KeyValuePair<string, string> mPolicyModifier in mPolicyModifiers)
		{
			bool flag = false;
			for (int i = 0; i < modifierNames.Count; i++)
			{
				if (mPolicyModifier.Key == modifierNames[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				policyType.SetModifier(mPolicyModifier.Key, (mPolicyModifier.Value.Equals("1") || mPolicyModifier.Value.Equals("true")) ? true : false);
			}
		}
	}

	public void Save(string filePath)
	{
		Teamcenter.Schemas.Soa.Objectpropertypolicy.ObjectPropertyPolicy objectPropertyPolicy = new Teamcenter.Schemas.Soa.Objectpropertypolicy.ObjectPropertyPolicy();
		XmlBindingUtils xmlBindingUtils = new XmlBindingUtils();
		try
		{
			FileInfo fileInfo = new FileInfo(filePath);
			DirectoryInfo directory = fileInfo.Directory;
			if (!directory.Exists)
			{
				Directory.CreateDirectory(directory.FullName);
			}
			if (!fileInfo.Exists)
			{
				FileStream fileStream = File.Create(filePath);
				fileStream.Close();
			}
			XmlTextWriter xmlTextWriter = new XmlTextWriter(filePath, Encoding.UTF8);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (string modifierName in ModifierNames)
			{
				dictionary.Add(modifierName, Convert.ToString(GetBooleanModifier(modifierName)));
			}
			PolicyMarshaller.Serialize(objectPropertyPolicy, dictionary);
			ArrayList arrayList = new ArrayList();
			foreach (KeyValuePair<string, PolicyType> mPolicyType in mPolicyTypes)
			{
				arrayList.Add(PolicyMarshaller.Serialize(mPolicyType.Value));
			}
			objectPropertyPolicy.setObjectType(arrayList);
			string data = XmlBindingUtils.UTF8ByteArrayToString(xmlBindingUtils.Serialize(objectPropertyPolicy));
			xmlTextWriter.WriteRaw(data);
			xmlTextWriter.Close();
		}
		catch (IOException ex)
		{
			string text = "Failed to save the policy in a:- " + filePath + ex.Message;
			throw new IOException(ex.Message);
		}
	}

	public void Load(string filePath)
	{
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			XmlTextReader xmlTextReader = new XmlTextReader(filePath);
			xmlDocument.Load(xmlTextReader);
			XmlNodeList childNodes = xmlDocument.ChildNodes;
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(OBJPROPPOLICY);
			XmlNode xmlNode = elementsByTagName[0];
			XmlAttributeCollection attributes = xmlNode.Attributes;
			for (int i = 0; i < attributes.Count; i++)
			{
				XmlAttribute xmlAttribute = attributes[i];
				if (!xmlAttribute.Name.StartsWith("xmlns"))
				{
					SetModifier(xmlAttribute.Name, Convert.ToBoolean(xmlAttribute.Value));
				}
			}
			XmlNodeList childNodes2 = xmlNode.ChildNodes;
			for (int j = 0; j < childNodes2.Count; j++)
			{
				PolicyType policyType = new PolicyType();
				XmlNode xmlNode2 = childNodes2[j];
				if (xmlNode2.Name.Equals(OBJTYPES))
				{
					AddType(PolicyMarshaller.ParseType(xmlNode2));
				}
				else if (!xmlNode2.Name.Equals(COMMENTS) && !xmlNode2.Name.Equals(INCLUDE))
				{
					throw new IOException("\nThe policy file does not conform to the schema,please refer to the Teamcenter Services Guide for more information.");
				}
			}
			xmlTextReader.Close();
		}
		catch (IOException ex)
		{
			string text = "Failed to load the policy from a:- " + filePath + ex.Message;
			throw new IOException(ex.Message);
		}
	}
}
