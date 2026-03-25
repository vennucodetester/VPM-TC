using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyShortImpl : PropertyImpl
{
	private short m_short;

	public override short ShortValue => m_short;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(6, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_short = Teamcenter.Soa.Client.Model.Property.ParseShort(vals[0].Value);
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyShortImpl)
		{
			PropertyShortImpl propertyShortImpl = (PropertyShortImpl)obj;
			return m_short.Equals(propertyShortImpl.m_short);
		}
		return false;
	}
}
