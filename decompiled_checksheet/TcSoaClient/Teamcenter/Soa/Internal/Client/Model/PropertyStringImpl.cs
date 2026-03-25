using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyStringImpl : PropertyImpl
{
	private string m_string;

	public override string StringValue => m_string;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(7, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			m_string = vals[0].Value;
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyStringImpl)
		{
			PropertyStringImpl propertyStringImpl = (PropertyStringImpl)obj;
			return m_string.Equals(propertyStringImpl.m_string);
		}
		return false;
	}
}
