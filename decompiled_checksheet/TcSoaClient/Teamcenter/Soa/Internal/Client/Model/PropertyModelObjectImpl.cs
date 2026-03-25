using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyModelObjectImpl : PropertyImpl
{
	private Teamcenter.Soa.Client.Model.ModelObject m_object;

	public override Teamcenter.Soa.Client.Model.ModelObject ModelObjectValue => m_object;

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(8, bArray: false, vals.Length);
		if (vals.Length == 1)
		{
			Teamcenter.Soa.Client.Model.ModelObject modelObject = null;
			modelObject = clientDataModel.GetObject(vals[0].Value);
			m_object = modelObject;
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyModelObjectImpl))
		{
			return false;
		}
		PropertyModelObjectImpl propertyModelObjectImpl = (PropertyModelObjectImpl)obj;
		if (m_object == null)
		{
			if (propertyModelObjectImpl.m_object == null)
			{
				return true;
			}
			return false;
		}
		if (propertyModelObjectImpl.m_object == null)
		{
			return false;
		}
		return m_object.Uid.Equals(propertyModelObjectImpl.m_object.Uid);
	}
}
