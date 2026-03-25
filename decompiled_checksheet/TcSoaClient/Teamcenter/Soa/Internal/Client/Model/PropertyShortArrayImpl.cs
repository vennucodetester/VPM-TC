using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyShortArrayImpl : PropertyImpl
{
	private short[] m_shortArray;

	public override short[] ShortArrayValue => m_shortArray;

	public PropertyShortArrayImpl()
	{
		m_shortArray = new short[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(6, bArray: true, vals.Length);
		m_shortArray = new short[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			m_shortArray[i] = Teamcenter.Soa.Client.Model.Property.ParseShort(vals[i].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyShortArrayImpl))
		{
			return false;
		}
		PropertyShortArrayImpl propertyShortArrayImpl = (PropertyShortArrayImpl)obj;
		if (m_shortArray == null)
		{
			if (propertyShortArrayImpl.m_shortArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyShortArrayImpl.m_shortArray == null)
		{
			return false;
		}
		if (m_shortArray.Length.Equals(propertyShortArrayImpl.m_shortArray.Length))
		{
			for (int i = 0; i < m_shortArray.Length; i++)
			{
				ArrayList arrayList = Sort(m_shortArray);
				ArrayList arrayList2 = Sort(propertyShortArrayImpl.m_shortArray);
				if (!arrayList[i].Equals(arrayList2[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ArrayList Sort(short[] unOrderdArray)
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
