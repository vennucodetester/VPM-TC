using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyDoubleImpl : PropertyImpl
{
	private double m_double;

	public override double DoubleValue => m_double;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(2, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_double = Teamcenter.Soa.Client.Model.Property.ParseDouble(vals[0].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyDoubleImpl)
		{
			PropertyDoubleImpl propertyDoubleImpl = (PropertyDoubleImpl)obj;
			return m_double.Equals(propertyDoubleImpl.m_double);
		}
		return false;
	}
}
