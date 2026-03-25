using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyDoubleArrayImpl : PropertyImpl
{
	private double[] m_doubleArray;

	public override double[] DoubleArrayValue => m_doubleArray;

	public PropertyDoubleArrayImpl()
	{
		m_doubleArray = new double[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(2, bArray: true, vals.Length);
		m_doubleArray = new double[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			m_doubleArray[i] = Teamcenter.Soa.Client.Model.Property.ParseDouble(vals[i].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyDoubleArrayImpl))
		{
			return false;
		}
		PropertyDoubleArrayImpl propertyDoubleArrayImpl = (PropertyDoubleArrayImpl)obj;
		if (m_doubleArray == null)
		{
			if (propertyDoubleArrayImpl.m_doubleArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyDoubleArrayImpl.m_doubleArray == null)
		{
			return false;
		}
		if (m_doubleArray.Length.Equals(propertyDoubleArrayImpl.m_doubleArray.Length))
		{
			for (int i = 0; i < m_doubleArray.Length; i++)
			{
				ArrayList arrayList = Sort(m_doubleArray);
				ArrayList arrayList2 = Sort(propertyDoubleArrayImpl.m_doubleArray);
				if (!arrayList[i].Equals(arrayList2[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ArrayList Sort(double[] unOrderdArray)
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
