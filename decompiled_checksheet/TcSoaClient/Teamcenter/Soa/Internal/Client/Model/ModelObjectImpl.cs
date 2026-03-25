using System;
using System.Collections;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Exceptions;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ModelObjectImpl : Teamcenter.Soa.Client.Model.ModelObject
{
	private Hashtable m_props = new Hashtable();

	private Hashtable m_propsUIValues = new Hashtable();

	private string m_uid;

	private SoaType m_type;

	private string m_objectID = "";

	private string m_cParamID = "";

	private bool m_isHistorical = false;

	private bool m_isObsolete = false;

	public string Uid => m_uid;

	public SoaType SoaType => m_type;

	public bool IsHistorical => m_isHistorical;

	public bool IsObsolete => m_isObsolete;

	public string[] PropertyNames
	{
		get
		{
			lock (this)
			{
				string[] array = new string[m_props.Count];
				m_props.Keys.CopyTo(array, 0);
				return array;
			}
		}
	}

	public ModelObjectImpl(SoaType type, string uid)
	{
		m_uid = uid;
		m_type = type;
	}

	public void UpdateVersion(string objectID, string cParamID, bool isHistorical, bool isObsolete)
	{
		m_objectID = (objectID.Equals("") ? m_uid : objectID);
		m_cParamID = cParamID;
		m_isHistorical = isHistorical;
		m_isObsolete = isObsolete;
	}

	public void CopyProperties(ModelObjectImpl source)
	{
		lock (this)
		{
			m_props = (Hashtable)source.m_props.Clone();
		}
	}

	public Hashtable CopyProperties()
	{
		lock (this)
		{
			return (Hashtable)m_props.Clone();
		}
	}

	public bool RefineType(SoaType newType)
	{
		if (newType.Name.Equals(SoaTypeImpl.UNKNOWN_TYPE_NAME) && !IsTypeOf(newType))
		{
			return false;
		}
		m_type = newType;
		return true;
	}

	private bool IsTypeOf(SoaType target)
	{
		if (m_type.Name.Equals(SoaTypeImpl.UNKNOWN_TYPE_NAME) || m_type.Name.Equals("ModelObject"))
		{
			return true;
		}
		if (target.Name.Equals(m_type.Name))
		{
			return true;
		}
		if (target.Parent != null)
		{
			return IsTypeOf(target.Parent);
		}
		return false;
	}

	public Teamcenter.Soa.Client.Model.Property GetProperty(string name)
	{
		lock (this)
		{
			Teamcenter.Soa.Client.Model.Property property = (Teamcenter.Soa.Client.Model.Property)m_props[name];
			if (property == null)
			{
				if (SoaType.GetPropDesc(name) == null)
				{
					string message = "The property " + name + " is not defined for the type " + SoaType.Name;
					throw new ArgumentException(message);
				}
				throw new NotLoadedException("The " + name + " property is not loaded in the client model.");
			}
			return property;
		}
	}

	public string GetPropertyDisplayableValue(string name)
	{
		lock (this)
		{
			string[] array = (string[])m_propsUIValues[name];
			if (array == null)
			{
				return GetProperty(name).DisplayableValue;
			}
			string result = "";
			if (array.Length != 0)
			{
				result = array[0];
			}
			return result;
		}
	}

	public string[] GetPropertyDisplayableValues(string name)
	{
		lock (this)
		{
			string[] array = (string[])m_propsUIValues[name];
			if (array == null)
			{
				return GetProperty(name).DisplayableValues;
			}
			return array;
		}
	}

	internal void ClearProperties()
	{
		lock (this)
		{
			m_props.Clear();
		}
	}

	internal void AddProperty(string name, Teamcenter.Soa.Client.Model.Property property)
	{
		lock (this)
		{
			m_props[name] = property;
		}
	}

	internal void AddProperty(string name, string[] values)
	{
		lock (this)
		{
			m_propsUIValues[name] = values;
		}
	}

	public bool HasSameObjectID(Teamcenter.Soa.Client.Model.ModelObject targetObject)
	{
		if (!(targetObject is ModelObjectImpl))
		{
			return false;
		}
		ModelObjectImpl modelObjectImpl = (ModelObjectImpl)targetObject;
		return m_objectID.Equals(modelObjectImpl.m_objectID);
	}

	public bool HasSameCParam(Teamcenter.Soa.Client.Model.ModelObject targetObject)
	{
		if (m_cParamID.Length == 0)
		{
			return false;
		}
		if (!(targetObject is ModelObjectImpl))
		{
			return false;
		}
		ModelObjectImpl modelObjectImpl = (ModelObjectImpl)targetObject;
		return m_cParamID.Equals(modelObjectImpl.m_cParamID);
	}

	public bool PutProperty(ClientDataModel clientDataModel, Teamcenter.Schemas.Soa._2006_03.Base.Property wireProp, bool checkForChange)
	{
		bool result = false;
		string name = wireProp.Name;
		PropertyImpl propertyImpl = PropertyImpl.createPropertyObject(wireProp.UiValues, wireProp.getUiValue(), ((PropertyDescriptionImpl)m_type.PropDescs[name]).Modifiable, (PropertyDescriptionImpl)m_type.PropDescs[name]);
		PropertyValue[] values = wireProp.Values;
		if (values != null)
		{
			propertyImpl.AddRawValues(values, clientDataModel);
		}
		if (checkForChange)
		{
			try
			{
				PropertyImpl obj = (PropertyImpl)GetProperty(name);
				if (!propertyImpl.Equals(obj))
				{
					result = true;
				}
			}
			catch (NotLoadedException)
			{
				result = true;
			}
		}
		AddProperty(name, propertyImpl);
		return result;
	}
}
