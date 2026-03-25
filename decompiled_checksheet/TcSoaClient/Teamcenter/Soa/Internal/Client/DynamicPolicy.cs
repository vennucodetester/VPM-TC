using System;
using System.Collections.Generic;
using Teamcenter.Soa.Common;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
public class DynamicPolicy
{
	public string mPolicyName = null;

	public bool mUseRefCounting = false;

	public ObjectPropertyPolicy mThePolicy = null;

	public Dictionary<string, PolicyType> mPendingAdds = new Dictionary<string, PolicyType>();

	public Dictionary<string, PolicyType> mPendingRemoves = new Dictionary<string, PolicyType>();

	public Dictionary<string, int> mPropRefCounts = new Dictionary<string, int>();

	public DynamicPolicy(string policyName, ObjectPropertyPolicy policy, bool useRefCounting)
	{
		mPolicyName = policyName;
		mThePolicy = policy;
		mUseRefCounting = useRefCounting;
		foreach (string typeName in mThePolicy.TypeNames)
		{
			PolicyType type = mThePolicy.GetType(typeName);
			foreach (string propertyName in type.PropertyNames)
			{
				mPropRefCounts[typeName + "/" + propertyName] = 1;
			}
		}
	}

	public void RemoveProperties(PolicyType policyType, bool colllectUpdates)
	{
		PolicyType type = mThePolicy.GetType(policyType.Name);
		if (type == null)
		{
			return;
		}
		List<string> propertyNames = policyType.PropertyNames;
		if (propertyNames.Count == 0)
		{
			propertyNames = type.PropertyNames;
		}
		List<string> list = new List<string>();
		foreach (string item in propertyNames)
		{
			if (type.GetProperty(item) != null)
			{
				string key = policyType.Name + "/" + item;
				int num = ((!mPropRefCounts.ContainsKey(key)) ? 1 : mPropRefCounts[key]);
				int num2 = num - 1;
				if (num2 == 0)
				{
					list.Add(item);
					mPropRefCounts.Remove(key);
				}
				else
				{
					mPropRefCounts[key] = num2;
				}
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		PolicyType policyType2 = new PolicyType(policyType.Name, list.ToArray());
		mThePolicy.RemoveProperties(policyType2);
		if (colllectUpdates)
		{
			if (mPendingRemoves.ContainsKey(policyType.Name))
			{
				PolicyType policyType3 = mPendingRemoves[policyType.Name];
				foreach (string propertyName in policyType3.PropertyNames)
				{
					policyType2.AddProperties(propertyName);
				}
			}
			mPendingRemoves[policyType.Name] = policyType2;
		}
		if (PolicyManager.logger.IsDebugEnabled)
		{
			PolicyManager.logger.Debug("Update policy " + mPolicyName + ": " + policyType2.ToString());
		}
	}

	public void AddProperties(PolicyType policyType, bool collectUpdates)
	{
		if (mUseRefCounting)
		{
			foreach (string propertyName in policyType.PropertyNames)
			{
				string key = policyType.Name + "/" + propertyName;
				int num = (mPropRefCounts.ContainsKey(key) ? mPropRefCounts[key] : 0);
				int value = num + 1;
				mPropRefCounts[key] = value;
			}
		}
		bool flag = TypeHasChanges(mThePolicy.GetType(policyType.Name), policyType);
		mThePolicy.AddType(policyType);
		if (flag)
		{
			if (collectUpdates)
			{
				mPendingAdds[policyType.Name] = mThePolicy.GetType(policyType.Name);
			}
			if (PolicyManager.logger.IsDebugEnabled)
			{
				PolicyManager.logger.Debug("Update policy " + mPolicyName + ": " + policyType.ToString());
			}
		}
	}

	private bool TypeHasChanges(PolicyType left, PolicyType right)
	{
		if (left == null)
		{
			return true;
		}
		foreach (string propertyName in right.PropertyNames)
		{
			PolicyProperty property = right.GetProperty(propertyName);
			PolicyProperty property2 = left.GetProperty(propertyName);
			if (property2 == null)
			{
				return true;
			}
			List<string> modifierNames = property.ModifierNames;
			List<string> modifierNames2 = property2.ModifierNames;
			if (modifierNames.Count != modifierNames2.Count)
			{
				return true;
			}
			string[] array = modifierNames.ToArray();
			string[] array2 = modifierNames2.ToArray();
			Array.Sort(array);
			Array.Sort(array2);
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].Equals(array2[i]))
				{
					return true;
				}
				if (property.GetBooleanModifier(array[i]) != property2.GetBooleanModifier(array[i]))
				{
					return true;
				}
			}
		}
		return false;
	}
}
