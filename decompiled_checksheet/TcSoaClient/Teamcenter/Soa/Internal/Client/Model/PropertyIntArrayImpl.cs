using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyIntArrayImpl : PropertyImpl
{
	private int[] m_intArray;

	public override int[] IntArrayValue => m_intArray;

	public PropertyIntArrayImpl()
	{
		m_intArray = new int[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(4, bArray: true, vals.Length);
		m_intArray = new int[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			m_intArray[i] = Teamcenter.Soa.Client.Model.Property.ParseInt(vals[i].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyIntArrayImpl))
		{
			return false;
		}
		PropertyIntArrayImpl propertyIntArrayImpl = (PropertyIntArrayImpl)obj;
		if (m_intArray == null)
		{
			if (propertyIntArrayImpl.m_intArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyIntArrayImpl.m_intArray == null)
		{
			return false;
		}
		if (m_intArray.Length.Equals(propertyIntArrayImpl.m_intArray.Length))
		{
			for (int i = 0; i < m_intArray.Length; i++)
			{
				ArrayList arrayList = Sort(m_intArray);
				ArrayList arrayList2 = Sort(propertyIntArrayImpl.m_intArray);
				if (!arrayList[i].Equals(arrayList2[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ArrayList Sort(int[] unOrderdArray)
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
