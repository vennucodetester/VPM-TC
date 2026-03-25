using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyBoolImpl : PropertyImpl
{
	private bool m_bool;

	public override bool BoolValue => m_bool;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(5, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_bool = Teamcenter.Soa.Client.Model.Property.ParseBoolean(vals[0].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyBoolImpl)
		{
			PropertyBoolImpl propertyBoolImpl = (PropertyBoolImpl)obj;
			return m_bool.Equals(propertyBoolImpl.m_bool);
		}
		return false;
	}
}
