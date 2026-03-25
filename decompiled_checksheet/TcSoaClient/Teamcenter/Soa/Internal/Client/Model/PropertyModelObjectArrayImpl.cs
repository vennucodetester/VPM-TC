using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public class PropertyModelObjectArrayImpl : PropertyImpl
{
	private Teamcenter.Soa.Client.Model.ModelObject[] m_objectArray;

	private IList m_objectList;

	public override Teamcenter.Soa.Client.Model.ModelObject[] ModelObjectArrayValue => m_objectArray;

	public override IList ModelObjectListValue => m_objectList;

	public PropertyModelObjectArrayImpl()
	{
		m_objectArray = new Teamcenter.Soa.Client.Model.ModelObject[0];
		m_objectList = new ArrayList();
	}

	internal override void convert(PropertyValue[] vals, ClientDataModel clientDataModel)
	{
		typeMismatch(8, bArray: true, vals.Length);
		m_objectList = new ArrayList(vals.Length);
		m_objectArray = new Teamcenter.Soa.Client.Model.ModelObject[vals.Length];
		for (int i = 0; i < vals.Length; i++)
		{
			Teamcenter.Soa.Client.Model.ModelObject modelObject = clientDataModel.GetObject(vals[i].Value);
			m_objectArray[i] = modelObject;
			if (modelObject != null)
			{
				m_objectList.Add(modelObject);
			}
		}
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyModelObjectArrayImpl))
		{
			return false;
		}
		PropertyModelObjectArrayImpl propertyModelObjectArrayImpl = (PropertyModelObjectArrayImpl)obj;
		if (m_objectArray == null)
		{
			if (propertyModelObjectArrayImpl.m_objectArray == null)
			{
				return true;
			}
			return false;
		}
		if (propertyModelObjectArrayImpl.m_objectArray == null)
		{
			return false;
		}
		if (m_objectArray.Length.Equals(propertyModelObjectArrayImpl.m_objectArray.Length))
		{
			ArrayList arrayList = Sort(m_objectArray);
			ArrayList arrayList2 = Sort(propertyModelObjectArrayImpl.m_objectArray);
			for (int i = 0; i < arrayList.Count; i++)
			{
				if (!arrayList[i].Equals(arrayList2[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ArrayList Sort(Teamcenter.Soa.Client.Model.ModelObject[] unOrderdArray)
	{
		ArrayList arrayList = new ArrayList();
		try
		{
			for (int i = 0; i < unOrderdArray.Length; i++)
			{
				arrayList.Add(unOrderdArray[i].Uid);
			}
			arrayList.Sort();
		}
		catch (ArgumentException ex)
		{
			throw new ArgumentException(ex.Message);
		}
		return arrayList;
	}
}
