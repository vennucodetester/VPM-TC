using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyCharArrayImpl : PropertyImpl
{
	private char[] m_charArray;

	public override char[] CharArrayValue => m_charArray;

	public PropertyCharArrayImpl()
	{
		m_charArray = new char[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(0, bArray: true, vals.Length);
		m_charArray = new char[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			m_charArray[i] = Teamcenter.Soa.Client.Model.Property.ParseChar(vals[i].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyCharArrayImpl))
		{
			return false;
		}
		PropertyCharArrayImpl propertyCharArrayImpl = (PropertyCharArrayImpl)obj;
		if (m_charArray == null)
		{
			if (propertyCharArrayImpl.m_charArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyCharArrayImpl.m_charArray == null)
		{
			return false;
		}
		if (m_charArray.Length.Equals(propertyCharArrayImpl.m_charArray.Length))
		{
			for (int i = 0; i < m_charArray.Length; i++)
			{
				ArrayList arrayList = Sort(m_charArray);
				ArrayList arrayList2 = Sort(propertyCharArrayImpl.m_charArray);
				if (!arrayList[i].Equals(arrayList2[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ArrayList Sort(char[] unOrderdArray)
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
