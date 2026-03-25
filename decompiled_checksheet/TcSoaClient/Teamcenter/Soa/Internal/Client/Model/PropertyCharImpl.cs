using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyCharImpl : PropertyImpl
{
	private char m_char;

	public override char CharValue => m_char;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(0, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_char = Teamcenter.Soa.Client.Model.Property.ParseChar(vals[0].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyCharImpl)
		{
			PropertyCharImpl propertyCharImpl = (PropertyCharImpl)obj;
			return m_char.Equals(propertyCharImpl.m_char);
		}
		return false;
	}
}
