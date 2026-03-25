using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyBoolArrayImpl : PropertyImpl
{
	private bool[] m_boolArray;

	public override bool[] BoolArrayValue => m_boolArray;

	public PropertyBoolArrayImpl()
	{
		m_boolArray = new bool[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(5, bArray: true, vals.Length);
		m_boolArray = new bool[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			m_boolArray[i] = Teamcenter.Soa.Client.Model.Property.ParseBoolean(vals[i].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyBoolArrayImpl))
		{
			return false;
		}
		PropertyBoolArrayImpl propertyBoolArrayImpl = (PropertyBoolArrayImpl)obj;
		if (m_boolArray == null)
		{
			if (propertyBoolArrayImpl.m_boolArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyBoolArrayImpl.m_boolArray == null)
		{
			return false;
		}
		if (m_boolArray.Length.Equals(propertyBoolArrayImpl.m_boolArray.Length))
		{
			for (int i = 0; i < m_boolArray.Length; i++)
			{
				ArrayList arrayList = Sort(m_boolArray);
				ArrayList arrayList2 = Sort(propertyBoolArrayImpl.m_boolArray);
				if (!arrayList[i].Equals(arrayList2[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ArrayList Sort(bool[] unOrderdArray)
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
