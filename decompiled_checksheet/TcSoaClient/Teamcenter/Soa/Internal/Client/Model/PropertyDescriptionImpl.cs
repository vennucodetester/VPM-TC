using System;
using System.Collections;
using System.Collections.Generic;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyDescriptionImpl : PropertyDescription
{
	private static Hashtable serverToClientMap;

	private readonly int m_type;

	private readonly int m_serverType;

	private readonly string m_name;

	private readonly bool m_isArray;

	private readonly string m_uiName;

	private readonly string m_typeUid;

	private readonly int m_maxLength;

	private readonly string m_minValue;

	private readonly string m_maxValue;

	private readonly int m_serverPropteryType;

	private readonly int m_maxArraySize;

	private readonly PropertyFieldType m_fieldType;

	private readonly string m_compoundObjType;

	private readonly LovCategory m_lovCategory;

	private readonly Dictionary<string, string> m_constants;

	private readonly ConditionChoices<Lov> m_lovs;

	private readonly string m_rootPropName;

	private readonly ConditionChoices<NamingRule> m_namingRules;

	private readonly ConditionChoices<string> m_renderers;

	private readonly RuleCategory m_ruleCategory;

	private readonly BasedOn m_basedOn;

	public string Name => m_name;

	public int Type => m_type;

	public bool Array => m_isArray;

	public string UiName => m_uiName;

	public string TypeUid => m_typeUid;

	public int MaxLength => m_maxLength;

	public int ServerType => m_serverType;

	public int ServerPropertyType => m_serverPropteryType;

	public int MaxArraySize => m_maxArraySize;

	public string CompoundObjectType => m_compoundObjType;

	public PropertyFieldType FieldType => m_fieldType;

	public LovCategory LovCategory => m_lovCategory;

	public Lov LovReference => m_lovs.getFirst();

	public string RootLovPropertyName => m_rootPropName;

	public NamingRule NamingRule => m_namingRules.getFirst();

	public RuleCategory NamingRuleCategory => m_ruleCategory;

	public string Renderer => m_renderers.getFirst();

	public bool Modifiable
	{
		get
		{
			if (!m_constants.ContainsKey(PropertyConstants.MODIFIABLE))
			{
				return false;
			}
			return Property.ParseBoolean(m_constants[PropertyConstants.MODIFIABLE]);
		}
	}

	public bool Displayable
	{
		get
		{
			if (!m_constants.ContainsKey(PropertyConstants.DISPLAYABLE))
			{
				return false;
			}
			return Property.ParseBoolean(m_constants[PropertyConstants.DISPLAYABLE]);
		}
	}

	public bool Required
	{
		get
		{
			if (!m_constants.ContainsKey(PropertyConstants.REQUIRED))
			{
				return false;
			}
			return Property.ParseBoolean(m_constants[PropertyConstants.REQUIRED]);
		}
	}

	public bool Enabled
	{
		get
		{
			if (!m_constants.ContainsKey(PropertyConstants.EDITABLE))
			{
				return false;
			}
			return Property.ParseBoolean(m_constants[PropertyConstants.EDITABLE]);
		}
	}

	public string InitialValue
	{
		get
		{
			if (!m_constants.ContainsKey(PropertyConstants.INITIAL_VALUE))
			{
				return null;
			}
			return m_constants[PropertyConstants.INITIAL_VALUE];
		}
	}

	public bool Localizable
	{
		get
		{
			if (!m_constants.ContainsKey(PropertyConstants.LOCALIZABLE))
			{
				return false;
			}
			return Property.ParseBoolean(m_constants[PropertyConstants.LOCALIZABLE]);
		}
	}

	public int AttachedSpecifier => LovReference?.Specifier ?? 0;

	public string LovTypeUid => LovReference?.LovInfo.Type.Uid;

	public string[] PropDependants
	{
		get
		{
			Lov lovReference = LovReference;
			if (lovReference != null)
			{
				string[] array = new string[lovReference.DependantProperties.Count];
				for (int i = 0; i < lovReference.DependantProperties.Count; i++)
				{
					array[i] = lovReference.DependantProperties[i];
				}
				return array;
			}
			return null;
		}
	}

	public string LovUid => LovReference?.Uid;

	public string MaxValue => m_maxValue;

	public string MinValue => m_minValue;

	public BasedOn BasedOn => m_basedOn;

	static PropertyDescriptionImpl()
	{
		serverToClientMap = new Hashtable();
		serverToClientMap.Add(1, 0);
		serverToClientMap.Add(2, 1);
		serverToClientMap.Add(3, 2);
		serverToClientMap.Add(4, 3);
		serverToClientMap.Add(5, 4);
		serverToClientMap.Add(6, 5);
		serverToClientMap.Add(7, 6);
		serverToClientMap.Add(8, 7);
		serverToClientMap.Add(9, 8);
		serverToClientMap.Add(10, 8);
		serverToClientMap.Add(11, 8);
		serverToClientMap.Add(12, 7);
		serverToClientMap.Add(13, 8);
		serverToClientMap.Add(14, 8);
	}

	public static int serverTypeToClientType(int serverType)
	{
		if (serverType == 0)
		{
			throw new ArgumentException("The server returned an invalid property code " + serverType);
		}
		if (!serverToClientMap.ContainsKey(serverType))
		{
			throw new ArgumentException("The server returned an invalid property code " + serverType);
		}
		return (int)serverToClientMap[serverType];
	}

	public PropertyDescriptionImpl(string typeUid, string name, string displayName, int valueType, int propertyType, int maxLength, bool isArray, int maxArraySize, int fieldType, string compoundObjType, int lovCategory, RuleCategory ruleCategory, Dictionary<string, string> constants, ConditionChoices<Lov> lovs, ConditionChoices<NamingRule> namingRules, ConditionChoices<string> renderers, string minValue, string maxValue, BasedOn basedOn)
	{
		m_type = serverTypeToClientType(valueType);
		m_name = name;
		m_uiName = displayName;
		m_typeUid = typeUid;
		m_maxLength = maxLength;
		m_isArray = isArray;
		m_maxArraySize = maxArraySize;
		m_serverType = valueType;
		m_serverPropteryType = propertyType;
		m_fieldType = (PropertyFieldType)fieldType;
		m_compoundObjType = compoundObjType;
		m_lovCategory = (LovCategory)lovCategory;
		m_constants = constants;
		m_lovs = lovs;
		m_namingRules = namingRules;
		m_ruleCategory = ruleCategory;
		m_renderers = renderers;
		m_rootPropName = null;
		m_minValue = minValue;
		m_maxValue = maxValue;
		m_basedOn = basedOn;
		Lov lov = m_lovs.peek();
		if (lov != null)
		{
			IList<string> dependantProperties = lov.DependantProperties;
			if (dependantProperties.Count > 1 && !dependantProperties[0].Equals(m_name))
			{
				m_rootPropName = dependantProperties[0];
				m_lovs = new ConditionChoices<Lov>();
			}
			else
			{
				m_rootPropName = m_name;
			}
		}
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
