using System;
using System.Collections;
using System.Collections.Generic;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Soa.Client.Model;

namespace Teamcenter.Soa.Internal.Client.Model;

public abstract class PropertyImpl : Teamcenter.Soa.Client.Model.Property
{
	protected string[] m_displayVals;

	protected PropertyDescriptionImpl m_propDesc;

	protected bool m_isNull = false;

	protected bool m_modifiable = false;

	[Obsolete("DisplayValue is deprecated!")]
	public override string DisplayValue
	{
		get
		{
			if (m_displayVals.Length == 0)
			{
				return "";
			}
			if (m_propDesc.Array)
			{
				string text = "";
				for (int i = 0; i < m_displayVals.Length; i++)
				{
					if (text.Length > 0)
					{
						text += ",";
					}
					text += m_displayVals[i];
				}
				return text;
			}
			return m_displayVals[0];
		}
	}

	public override string DisplayableValue
	{
		get
		{
			if (m_displayVals.Length == 0)
			{
				return "";
			}
			return m_displayVals[0];
		}
	}

	public override string[] DisplayableValues => m_displayVals;

	public override PropertyDescription PropertyDescription => m_propDesc;

	public override bool IsNull => m_isNull;

	public override bool Modifiable => m_modifiable;

	public override char CharValue
	{
		get
		{
			ArgumentException ex = checkValueType(0, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override char[] CharArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(0, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override DateTime DateValue
	{
		get
		{
			ArgumentException ex = checkValueType(1, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override DateTime[] DateArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(1, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override double DoubleValue
	{
		get
		{
			ArgumentException ex = checkValueType(2, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override double[] DoubleArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(2, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	[Obsolete]
	public override float FloatValue
	{
		get
		{
			ArgumentException ex = checkValueType(3, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override double FloatValueAsDouble
	{
		get
		{
			ArgumentException ex = checkValueType(3, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	[Obsolete]
	public override float[] FloatArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(3, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override double[] FloatArrayValueAsDoubles
	{
		get
		{
			ArgumentException ex = checkValueType(3, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override int IntValue
	{
		get
		{
			ArgumentException ex = checkValueType(4, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override int[] IntArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(4, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override bool BoolValue
	{
		get
		{
			ArgumentException ex = checkValueType(5, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override bool[] BoolArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(5, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override short ShortValue
	{
		get
		{
			ArgumentException ex = checkValueType(6, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override short[] ShortArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(6, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override string StringValue
	{
		get
		{
			ArgumentException ex = checkValueType(7, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override string[] StringArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(7, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override Teamcenter.Soa.Client.Model.ModelObject ModelObjectValue
	{
		get
		{
			ArgumentException ex = checkValueType(8, array: false);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override Teamcenter.Soa.Client.Model.ModelObject[] ModelObjectArrayValue
	{
		get
		{
			ArgumentException ex = checkValueType(8, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	public override IList ModelObjectListValue
	{
		get
		{
			ArgumentException ex = checkValueType(8, array: true);
			if (ex != null)
			{
				throw ex;
			}
			throw new ArgumentException("UnExpected: Tried to access property value from base class");
		}
	}

	internal void AddRawValues(PropertyValue[] values, ClientDataModel clientDataModel)
	{
		convert(values, clientDataModel);
		if (values.Length > 0)
		{
			m_isNull = values[0].IsNull;
		}
	}

	internal abstract void convert(PropertyValue[] vals, ClientDataModel clientDataModel);

	public void typeMismatch(int type, bool bArray, int nValues)
	{
		if (!m_propDesc.Type.Equals(type & 0xF) || bArray != m_propDesc.Array)
		{
			throw new ArgumentException("Type mismatch asking for property");
		}
		if (!bArray && nValues > 1)
		{
			throw new ArgumentException("Type mismatch: Single value property must contain only one value");
		}
	}

	protected ArgumentException checkValueType(int desiredType, bool array)
	{
		if (array != m_propDesc.Array)
		{
			if (array)
			{
				return new ArgumentException("Tried to access property as an array when it is a single value.");
			}
			return new ArgumentException("Tried to access property as a single value when it is an array.");
		}
		int type = m_propDesc.Type;
		if (type != desiredType)
		{
			return new ArgumentException("Tried to access property value as type " + desiredType + ", when it is a type " + type + ".");
		}
		return null;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PropertyImpl))
		{
			return false;
		}
		PropertyImpl obj2 = (PropertyImpl)obj;
		if (Equals(obj2))
		{
			return true;
		}
		return false;
	}

	public static PropertyImpl createPropertyObject(string[] displayValues, string displayValue, bool modifiable, PropertyDescriptionImpl desc)
	{
		PropertyImpl propertyImpl = null;
		if (!desc.Array)
		{
			if (desc.Type == 0)
			{
				propertyImpl = new PropertyCharImpl();
			}
			else if (desc.Type == 1)
			{
				propertyImpl = new PropertyDateImpl();
			}
			else if (desc.Type == 5)
			{
				propertyImpl = new PropertyBoolImpl();
			}
			else if (desc.Type == 2)
			{
				propertyImpl = new PropertyDoubleImpl();
			}
			else if (desc.Type == 3)
			{
				propertyImpl = new PropertyFloatImpl();
			}
			else if (desc.Type == 4)
			{
				propertyImpl = new PropertyIntImpl();
			}
			else if (desc.Type == 6)
			{
				propertyImpl = new PropertyShortImpl();
			}
			else if (desc.Type == 7)
			{
				propertyImpl = new PropertyStringImpl();
			}
			else
			{
				if (desc.Type != 8)
				{
					throw new ArgumentException("Unknown Property Type");
				}
				propertyImpl = new PropertyModelObjectImpl();
			}
			propertyImpl.m_displayVals = new string[1];
			propertyImpl.m_displayVals[0] = displayValue;
			propertyImpl.m_modifiable = modifiable;
		}
		else
		{
			if (desc.Type == 0)
			{
				propertyImpl = new PropertyCharArrayImpl();
			}
			else if (desc.Type == 1)
			{
				propertyImpl = new PropertyDateArrayImpl();
			}
			else if (desc.Type == 5)
			{
				propertyImpl = new PropertyBoolArrayImpl();
			}
			else if (desc.Type == 2)
			{
				propertyImpl = new PropertyDoubleArrayImpl();
			}
			else if (desc.Type == 3)
			{
				propertyImpl = new PropertyFloatArrayImpl();
			}
			else if (desc.Type == 4)
			{
				propertyImpl = new PropertyIntArrayImpl();
			}
			else if (desc.Type == 6)
			{
				propertyImpl = new PropertyShortArrayImpl();
			}
			else if (desc.Type == 7)
			{
				propertyImpl = new PropertyStringArrayImpl();
			}
			else
			{
				if (desc.Type != 8)
				{
					throw new ArgumentException("Unknown Property Type");
				}
				propertyImpl = new PropertyModelObjectArrayImpl();
			}
			propertyImpl.m_modifiable = modifiable;
			if (displayValues != null && displayValues.Length > 0)
			{
				propertyImpl.m_displayVals = displayValues;
			}
			else if (displayValue != null)
			{
				char[] separator = new char[1] { ',' };
				propertyImpl.m_displayVals = displayValue.Split(separator);
			}
			else
			{
				propertyImpl.m_displayVals = new string[0];
			}
		}
		propertyImpl.m_propDesc = desc;
		return propertyImpl;
	}

	public static string RetrievePropertyValue(Teamcenter.Soa.Client.Model.Property property)
	{
		if (!property.PropertyDescription.Array)
		{
			if (property.PropertyDescription.Type == 0)
			{
				return property.CharValue.ToString();
			}
			if (property.PropertyDescription.Type == 1)
			{
				_ = property.DateValue;
				bool flag = 1 == 0;
				return property.DateValue.ToString();
			}
			if (property.PropertyDescription.Type == 5)
			{
				return property.BoolValue.ToString();
			}
			if (property.PropertyDescription.Type == 2)
			{
				return property.DoubleValue.ToString();
			}
			if (property.PropertyDescription.Type == 3)
			{
				return property.FloatValueAsDouble.ToString();
			}
			if (property.PropertyDescription.Type == 4)
			{
				return property.IntValue.ToString();
			}
			if (property.PropertyDescription.Type == 6)
			{
				return property.ShortValue.ToString();
			}
			if (property.PropertyDescription.Type == 7)
			{
				return property.StringValue;
			}
			if (property.PropertyDescription.Type == 8)
			{
				if (property.ModelObjectValue != null)
				{
					return property.ModelObjectValue.Uid;
				}
				return "";
			}
			throw new ArgumentException("Unknown Property Type");
		}
		List<string> list = new List<string>();
		if (property.PropertyDescription.Type == 0)
		{
			char[] charArrayValue = property.CharArrayValue;
			for (int i = 0; i < charArrayValue.Length; i++)
			{
				list.Add(Teamcenter.Soa.Client.Model.Property.ToCharString(charArrayValue[i]));
			}
		}
		else if (property.PropertyDescription.Type == 1)
		{
			DateTime[] dateArrayValue = property.DateArrayValue;
			for (int i = 0; i < dateArrayValue.Length; i++)
			{
				list.Add(Teamcenter.Soa.Client.Model.Property.ToDateString(dateArrayValue[i]));
			}
		}
		else if (property.PropertyDescription.Type == 5)
		{
			bool[] boolArrayValue = property.BoolArrayValue;
			for (int i = 0; i < boolArrayValue.Length; i++)
			{
				list.Add(Teamcenter.Soa.Client.Model.Property.ToBooleanString(boolArrayValue[i]));
			}
		}
		else if (property.PropertyDescription.Type == 2)
		{
			double[] doubleArrayValue = property.DoubleArrayValue;
			for (int i = 0; i < doubleArrayValue.Length; i++)
			{
				list.Add(Teamcenter.Soa.Client.Model.Property.ToDoubleString(doubleArrayValue[i]));
			}
		}
		else if (property.PropertyDescription.Type == 3)
		{
			double[] doubleArrayValue = property.FloatArrayValueAsDoubles;
			for (int i = 0; i < doubleArrayValue.Length; i++)
			{
				list.Add(Teamcenter.Soa.Client.Model.Property.ToDoubleString(doubleArrayValue[i]));
			}
		}
		else if (property.PropertyDescription.Type == 4)
		{
			int[] intArrayValue = property.IntArrayValue;
			for (int i = 0; i < intArrayValue.Length; i++)
			{
				list.Add(Teamcenter.Soa.Client.Model.Property.ToIntString(intArrayValue[i]));
			}
		}
		else if (property.PropertyDescription.Type == 6)
		{
			short[] shortArrayValue = property.ShortArrayValue;
			for (int i = 0; i < shortArrayValue.Length; i++)
			{
				list.Add(Teamcenter.Soa.Client.Model.Property.ToShortString(shortArrayValue[i]));
			}
		}
		else if (property.PropertyDescription.Type == 7)
		{
			string[] stringArrayValue = property.StringArrayValue;
			for (int i = 0; i < stringArrayValue.Length; i++)
			{
				list.Add(stringArrayValue[i]);
			}
		}
		else
		{
			if (property.PropertyDescription.Type != 8)
			{
				throw new ArgumentException("Unknown Property Type");
			}
			Teamcenter.Soa.Client.Model.ModelObject[] modelObjectArrayValue = property.ModelObjectArrayValue;
			for (int i = 0; i < modelObjectArrayValue.Length; i++)
			{
				if (modelObjectArrayValue[i] != null)
				{
					list.Add(modelObjectArrayValue[i].Uid);
				}
			}
		}
		string text = "";
		foreach (string item in list)
		{
			if (text.Length > 0)
			{
				text += ",";
			}
			text += item;
		}
		return text;
	}
}
