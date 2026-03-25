using System;
using System.Runtime.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Rapid_Check;

public class DragObject : ISerializable, ICloneable
{
	private string cColumnName;

	private string cValue;

	public string ColumnName
	{
		get
		{
			return cColumnName;
		}
		set
		{
			cColumnName = value;
		}
	}

	public string Value
	{
		get
		{
			return cValue;
		}
		set
		{
			cValue = value;
		}
	}

	public DragObject()
	{
		cColumnName = string.Empty;
		cValue = string.Empty;
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetObjectData
		this.GetObjectData(info, context);
	}

	public object Clone()
	{
		DragObject dragObject = new DragObject();
		try
		{
			dragObject.cColumnName = cColumnName;
			dragObject.cValue = cValue;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return dragObject;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clone
		return this.Clone();
	}
}
