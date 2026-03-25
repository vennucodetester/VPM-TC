using System;
using System.Collections;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Exceptions;

namespace Teamcenter.Soa.Internal.Client.Model;

public class TypeCache
{
	protected Hashtable m_typeMap = new Hashtable();

	public void AddType(object currType)
	{
		if (currType is SoaType)
		{
			SoaType soaType = (SoaType)currType;
			m_typeMap[soaType.Name] = soaType;
			m_typeMap[soaType.Uid] = soaType;
			return;
		}
		throw new ArgumentException("The type " + currType.GetType().FullName + " is not supported in the TypeCache.");
	}

	public SoaType GetType(string typeKey)
	{
		if (!m_typeMap.ContainsKey(typeKey))
		{
			throw new NotLoadedException("The type " + typeKey + " has not been loaded.");
		}
		object obj = m_typeMap[typeKey];
		if (obj is SoaType)
		{
			return (SoaType)obj;
		}
		throw new NotLoadedException("The type " + typeKey + " has been loaded but is not a Type.");
	}

	public void RemoveType(string typeKey)
	{
		if (m_typeMap.ContainsKey(typeKey))
		{
			object obj = m_typeMap[typeKey];
			if (!(obj is SoaType))
			{
				throw new ArgumentException("The type " + obj.GetType().FullName + " is not supported in the TypeCache.");
			}
			SoaType soaType = (SoaType)obj;
			m_typeMap.Remove(soaType.Name);
			m_typeMap.Remove(soaType.Uid);
		}
	}
}
