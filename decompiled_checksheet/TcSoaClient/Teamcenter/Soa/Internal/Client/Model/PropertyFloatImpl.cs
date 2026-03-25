using System;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyFloatImpl : PropertyImpl
{
	private double m_float;

	[Obsolete]
	public override float FloatValue => (float)m_float;

	public override double FloatValueAsDouble => m_float;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(3, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_float = Teamcenter.Soa.Client.Model.Property.ParseDouble(vals[0].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyFloatImpl)
		{
			PropertyFloatImpl propertyFloatImpl = (PropertyFloatImpl)obj;
			return m_float.Equals(propertyFloatImpl.m_float);
		}
		return false;
	}
}
