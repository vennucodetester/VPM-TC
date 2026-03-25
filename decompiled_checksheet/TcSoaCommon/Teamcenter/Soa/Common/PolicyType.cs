using System;
using System.Collections.Generic;
using System.Text;

namespace Teamcenter.Soa.Common;

[Serializable]
public class PolicyType
{
	private string mName;

	private bool mUseRefCounting = false;

	private Dictionary<string, string> mTypeModifiers = new Dictionary<string, string>();

	private Dictionary<string, PolicyProperty> mProperties = new Dictionary<string, PolicyProperty>();

	public List<string> ModifierNames
	{
		get
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> mTypeModifier in mTypeModifiers)
			{
				list.Add(mTypeModifier.Key);
			}
			return list;
		}
	}

	public string Name => mName;

	public List<string> PropertyNames
	{
		get
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, PolicyProperty> mProperty in mProperties)
			{
				list.Add(mProperty.Key);
			}
			return list;
		}
	}

	public Dictionary<string, PolicyProperty> Properties
	{
		get
		{
			Dictionary<string, PolicyProperty> dictionary = new Dictionary<string, PolicyProperty>();
			foreach (KeyValuePair<string, PolicyProperty> mProperty in mProperties)
			{
				dictionary[mProperty.Key] = mProperty.Value;
			}
			return dictionary;
		}
	}

	public PolicyType()
	{
		mName = "Any";
	}

	public PolicyType(string name)
	{
		string[] array = name.Split('{');
		mName = array[0].Trim();
		if (array.Length > 1)
		{
			SetProperties(name);
		}
	}

	public PolicyType(string name, string[] properties)
	{
		mName = name;
		for (int i = 0; i < properties.Length; i++)
		{
			AddProperty(new PolicyProperty(properties[i]));
		}
	}

	public PolicyType(string name, string[] properties, string[] modifiers)
	{
		mName = name;
		for (int i = 0; i < properties.Length; i++)
		{
			AddProperty(new PolicyProperty(properties[i], modifiers));
		}
	}

	public bool HasProperty(string propertyName)
	{
		foreach (KeyValuePair<string, PolicyProperty> mProperty in mProperties)
		{
			if (mProperty.Key.Equals(propertyName))
			{
				return true;
			}
		}
		return false;
	}

	public void SetModifier(string name, bool value)
	{
		string value2 = (value ? "1" : "0");
		mTypeModifiers[name] = value2;
		foreach (KeyValuePair<string, PolicyProperty> mProperty in mProperties)
		{
			MergeModifiers(mProperty.Value);
		}
	}

	public bool GetBooleanModifier(string name)
	{
		if (mTypeModifiers.ContainsKey(name))
		{
			return (mTypeModifiers[name].Equals("1") || mTypeModifiers[name].Equals("true")) ? true : false;
		}
		return false;
	}

	public PolicyProperty GetProperty(string name)
	{
		foreach (KeyValuePair<string, PolicyProperty> mProperty in mProperties)
		{
			if (mProperty.Key.Equals(name))
			{
				return mProperty.Value;
			}
		}
		return null;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(mName);
		stringBuilder.Append("{");
		bool flag = true;
		foreach (KeyValuePair<string, PolicyProperty> mProperty in mProperties)
		{
			if (!flag)
			{
				stringBuilder.Append(", ");
			}
			flag = false;
			stringBuilder.Append(mProperty.Key);
		}
		stringBuilder.Append("}");
		return Convert.ToString(stringBuilder);
	}

	public void AddProperty(string propName)
	{
		AddProperty(new PolicyProperty(propName));
	}

	public void AddProperty(PolicyProperty prop)
	{
		addPropertyWithCount(prop);
	}

	private void addPropertyWithCount(PolicyProperty prop)
	{
		MergeModifiers(prop);
		if (HasProperty(prop.Name))
		{
			mProperties.Remove(prop.Name);
		}
		mProperties[prop.Name] = prop;
	}

	public void EraseProperty(string propName)
	{
		if (HasProperty(propName))
		{
			mProperties.Remove(propName);
		}
	}

	public void AddProperties(string props)
	{
		string[] array = props.Trim().Split('{', '}');
		string text = ((array.Length == 3) ? array[1] : array[0]);
		string[] array2 = text.Split(',');
		string[] array3 = array2;
		foreach (string text2 in array3)
		{
			AddProperty(text2.Trim());
		}
	}

	public void SetProperties(string props)
	{
		mProperties.Clear();
		AddProperties(props);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PolicyType))
		{
			return false;
		}
		PolicyType policyType = (PolicyType)obj;
		if (mName != policyType.mName)
		{
			return false;
		}
		if (mTypeModifiers.Count != policyType.mTypeModifiers.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, string> mTypeModifier in mTypeModifiers)
		{
			string text = mTypeModifiers[mTypeModifier.Key];
			string value = policyType.mTypeModifiers[mTypeModifier.Key];
			if (!text.Equals(value))
			{
				return false;
			}
		}
		if (mProperties.Count != policyType.mProperties.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, PolicyProperty> mProperty in mProperties)
		{
			PolicyProperty policyProperty = mProperties[mProperty.Key];
			PolicyProperty obj2 = policyType.mProperties[mProperty.Key];
			if (!policyProperty.Equals(obj2))
			{
				return false;
			}
		}
		return true;
	}

	private void MergeModifiers(PolicyProperty policyProperty)
	{
		List<string> modifierNames = policyProperty.ModifierNames;
		foreach (KeyValuePair<string, string> mTypeModifier in mTypeModifiers)
		{
			bool flag = false;
			for (int i = 0; i < modifierNames.Count; i++)
			{
				if (mTypeModifier.Key == modifierNames[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				policyProperty.SetModifier(mTypeModifier.Key, (mTypeModifier.Value.Equals("1") || mTypeModifier.Value.Equals("true")) ? true : false);
			}
		}
	}
}
