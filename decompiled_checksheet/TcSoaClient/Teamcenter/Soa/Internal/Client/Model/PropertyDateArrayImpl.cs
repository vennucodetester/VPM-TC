using System;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyDateArrayImpl : PropertyImpl
{
	private DateTime[] m_dateArray;

	public override DateTime[] DateArrayValue => m_dateArray;

	public PropertyDateArrayImpl()
	{
		m_dateArray = new DateTime[0];
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(1, bArray: true, vals.Length);
		m_dateArray = new DateTime[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			ref DateTime reference = ref m_dateArray[i];
			reference = Teamcenter.Soa.Client.Model.Property.ParseDate(vals[i].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyDateArrayImpl))
		{
			return false;
		}
		PropertyDateArrayImpl propertyDateArrayImpl = (PropertyDateArrayImpl)obj;
		if (m_dateArray == null)
		{
			if (propertyDateArrayImpl.m_dateArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyDateArrayImpl.m_dateArray == null)
		{
			return false;
		}
		if (m_dateArray.Length.Equals(propertyDateArrayImpl.m_dateArray.Length))
		{
			for (int i = 0; i < m_dateArray.Length; i++)
			{
				if (m_dateArray[i].Date.CompareTo(propertyDateArrayImpl.m_dateArray[i].Date) != 0)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
