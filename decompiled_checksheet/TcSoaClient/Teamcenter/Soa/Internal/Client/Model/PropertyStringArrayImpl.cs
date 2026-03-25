using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyStringArrayImpl : PropertyImpl
{
	private string[] m_stringArray;

	public override string[] StringArrayValue => m_stringArray;

	public PropertyStringArrayImpl()
	{
		m_stringArray = new string[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(7, bArray: true, vals.Length);
		m_stringArray = new string[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			m_stringArray[i] = vals[i].Value;
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyStringArrayImpl))
		{
			return false;
		}
		PropertyStringArrayImpl propertyStringArrayImpl = (PropertyStringArrayImpl)obj;
		if (m_stringArray == null)
		{
			if (propertyStringArrayImpl.m_stringArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyStringArrayImpl.m_stringArray == null)
		{
			return false;
		}
		if (m_stringArray.Length.Equals(propertyStringArrayImpl.m_stringArray.Length))
		{
			for (int i = 0; i < m_stringArray.Length; i++)
			{
				ArrayList arrayList = Sort(m_stringArray);
				ArrayList arrayList2 = Sort(propertyStringArrayImpl.m_stringArray);
				if (!arrayList[i].Equals(arrayList2[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ArrayList Sort(string[] unOrderdArray)
	{
		ArrayList arrayList = new ArrayList();
		try
		{
			for (int i = 0; i < unOrderdArray.Length; i++)
			{
				arrayList.Add(unOrderdArray[i]);
			}
			arrayList.Sort();
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException(ex.Message);
		}
		return arrayList;
	}
}
