using System.Collections;
using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class SoaTypeImpl : SoaType
{
	public static readonly string UNKNOWN_TYPE_UID = "TYPE::UnknownType::UnknownClass::UnknownParent";

	public static readonly string UNKNOWN_TYPE_NAME = "UnknownModelObjectName";

	public static readonly string UNKNOWN_TYPE_CLASS = "UnknownModelObjectClass";

	private readonly string m_uid;

	private readonly string m_name;

	private readonly Dictionary<string, PropertyDescription> m_propDescs;

	private readonly SoaType m_parent;

	private readonly string m_uifValue;

	private readonly string m_className;

	private readonly string m_typeUid;

	private readonly bool m_isMatchType;

	private readonly List<string> m_classNameHierarchy;

	private readonly string m_OwningType;

	private readonly Dictionary<string, string> m_constants;

	private ConditionChoices<RevNameRule> m_revisionNamingRules;

	private readonly RevisionRuleCategory m_ruleCategory;

	public string Uid => m_uid;

	public string Name => m_name;

	public SoaType Parent => m_parent;

	public string UIFValue => m_uifValue;

	public bool MatchType => m_isMatchType;

	public string ClassName => m_className;

	public string TypeUid => m_typeUid;

	public Hashtable PropDescs
	{
		get
		{
			Hashtable hashtable = new Hashtable();
			foreach (KeyValuePair<string, PropertyDescription> propDesc in m_propDescs)
			{
				hashtable[propDesc.Key] = propDesc.Value;
			}
			return hashtable;
		}
	}

	public string OwningType => m_OwningType;

	public Dictionary<string, string> Constants => m_constants;

	public RevNameRule RevisionNamingRule => m_revisionNamingRules.getFirst();

	public RevisionRuleCategory RevisionNamingRuleCategory => m_ruleCategory;

	public SoaTypeImpl(string uid, string typeUid, string name, string displayName, string className, IList<string> classNameHierarchy, SoaType parent, string owningType, Dictionary<string, PropertyDescription> properties, Dictionary<string, string> constants, ConditionChoices<RevNameRule> revRules, RevisionRuleCategory ruleCategory)
	{
		m_uid = uid;
		m_name = name;
		m_uifValue = displayName;
		m_className = className;
		m_typeUid = typeUid;
		m_isMatchType = false;
		m_classNameHierarchy = new List<string>(classNameHierarchy);
		m_parent = parent;
		m_OwningType = owningType;
		m_propDescs = properties;
		m_constants = constants;
		m_revisionNamingRules = revRules;
		m_ruleCategory = ruleCategory;
	}

	public PropertyDescription GetPropDesc(string propName)
	{
		try
		{
			return m_propDescs[propName];
		}
		catch (KeyNotFoundException)
		{
			return null;
		}
	}

	public List<string> GetClassNameHierarchy()
	{
		return m_classNameHierarchy;
	}

	public bool IsInstanceOf(string className)
	{
		if (m_classNameHierarchy == null || m_classNameHierarchy.Count == 0)
		{
			if (IsInstance(className))
			{
				return true;
			}
		}
		else
		{
			foreach (string item in m_classNameHierarchy)
			{
				if (item == className)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool IsInstance(string className)
	{
		if (m_name.Equals(className))
		{
			return true;
		}
		if (m_parent == null)
		{
			return false;
		}
		return ((SoaTypeImpl)m_parent).IsInstance(className);
	}

	public string GetConstant(string name)
	{
		if (m_constants.ContainsKey(name))
		{
			return m_constants[name];
		}
		return null;
	}
}
