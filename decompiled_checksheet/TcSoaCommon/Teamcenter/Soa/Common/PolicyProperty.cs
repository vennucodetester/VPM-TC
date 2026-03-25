using System;
using System.Collections.Generic;

namespace Teamcenter.Soa.Common;

[Serializable]
public class PolicyProperty
{
	public static readonly string WITH_PROPERTIES = "withProperties";

	public static readonly string EXCLUDE_UI_VALUE = "excludeUiValues";

	public static readonly string EXCLUDE_MODIFIABLE = "excludeIsModifiable";

	public static readonly string INCLUDE_MODIFIABLE = "includeIsModifiable";

	public static readonly string AS_ATTRIBUTE = "asAttribute";

	public static readonly string UI_VALUE_ONLY = "uIValueOnly";

	public static readonly string EXCLUDE_PARENT_PROPERTIES = "excludeParentProperties";

	private string mName;

	private Dictionary<string, string> mPropertyModifiers = new Dictionary<string, string>();

	public List<string> ModifierNames
	{
		get
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> mPropertyModifier in mPropertyModifiers)
			{
				list.Add(mPropertyModifier.Key);
			}
			return list;
		}
	}

	public string Name => mName;

	public PolicyProperty(string name)
	{
		mName = name;
	}

	public PolicyProperty(string name, string[] modifiers)
	{
		mName = name;
		for (int i = 0; i < modifiers.Length; i++)
		{
			SetModifier(modifiers[i], value: true);
		}
	}

	public void SetModifier(string name, bool value)
	{
		string value2 = (value ? "1" : "0");
		mPropertyModifiers[name] = value2;
	}

	public bool GetBooleanModifier(string name)
	{
		if (mPropertyModifiers.ContainsKey(name))
		{
			return (mPropertyModifiers[name].Equals("1") || mPropertyModifiers[name].Equals("true")) ? true : false;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PolicyProperty))
		{
			return false;
		}
		PolicyProperty policyProperty = (PolicyProperty)obj;
		if (mName != policyProperty.mName)
		{
			return false;
		}
		if (mPropertyModifiers.Count != policyProperty.mPropertyModifiers.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, string> mPropertyModifier in mPropertyModifiers)
		{
			string text = mPropertyModifiers[mPropertyModifier.Key];
			string value = policyProperty.mPropertyModifiers[mPropertyModifier.Key];
			if (!text.Equals(value))
			{
				return false;
			}
		}
		return true;
	}
}
