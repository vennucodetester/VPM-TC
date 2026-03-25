using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyFloatArrayImpl : PropertyImpl
{
	private double[] m_floatArray;

	[Obsolete]
	public override float[] FloatArrayValue
	{
		get
		{
			float[] array = new float[m_floatArray.Length];
			for (int i = 0; i < m_floatArray.Length; i++)
			{
				array[i] = (float)m_floatArray[i];
			}
			return array;
		}
	}

	public override double[] FloatArrayValueAsDoubles => m_floatArray;

	public PropertyFloatArrayImpl()
	{
		m_floatArray = new double[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(3, bArray: true, vals.Length);
		m_floatArray = new double[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			m_floatArray[i] = Teamcenter.Soa.Client.Model.Property.ParseDouble(vals[i].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyFloatArrayImpl))
		{
			return false;
		}
		PropertyFloatArrayImpl propertyFloatArrayImpl = (PropertyFloatArrayImpl)obj;
		if (m_floatArray == null)
		{
			if (propertyFloatArrayImpl.m_floatArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyFloatArrayImpl.m_floatArray == null)
		{
			return false;
		}
		if (m_floatArray.Length.Equals(propertyFloatArrayImpl.m_floatArray.Length))
		{
			for (int i = 0; i < m_floatArray.Length; i++)
			{
				ArrayList arrayList = Sort(m_floatArray);
				ArrayList arrayList2 = Sort(propertyFloatArrayImpl.m_floatArray);
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
