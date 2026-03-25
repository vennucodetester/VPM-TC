using System;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyDateImpl : PropertyImpl
{
	private DateTime m_date;

	public override DateTime DateValue => m_date;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(1, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_date = Teamcenter.Soa.Client.Model.Property.ParseDate(vals[0].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyDateImpl))
		{
			PropertyDateImpl propertyDateImpl = (PropertyDateImpl)obj;
			return m_date.Equals(propertyDateImpl.m_date);
		}
		return false;
	}
}
