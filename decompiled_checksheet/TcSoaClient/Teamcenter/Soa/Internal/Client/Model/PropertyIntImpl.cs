using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyIntImpl : PropertyImpl
{
	private int m_int;

	public override int IntValue => m_int;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(4, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_int = Teamcenter.Soa.Client.Model.Property.ParseInt(vals[0].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyIntImpl)
		{
			PropertyIntImpl propertyIntImpl = (PropertyIntImpl)obj;
			return m_int.Equals(propertyIntImpl.m_int);
		}
		return false;
	}
}
