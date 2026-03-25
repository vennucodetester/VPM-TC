using System.Collections.Generic;
using Teamcenter.Soa.Internal.Client.Model;
using log4net;

namespace Teamcenter.Soa.Client.Model;

public abstract class ClientMetaModel
{
	private static ILog logger = LogManager.GetLogger(typeof(ClientMetaModel));

	protected Dictionary<string, SoaType> mTypeCache = new Dictionary<string, SoaType>(500);

	protected Dictionary<string, LovInfo> mLovCache = new Dictionary<string, LovInfo>(100);

	protected string dateFormat = "yyyy-MM-dd HH:mm";

	protected string numberFormat = "0.0###";

	private object mMapLock = new object();

	private object mLoadLock = new object();

	public void SetDateDisplayFormat(string dFormat)
	{
		dateFormat = dFormat;
	}

	public string GetDateDisplayFormat()
	{
		return dateFormat;
	}

	public void SetDoublePrecision(int precision)
	{
		numberFormat = "0.0";
		for (int i = 1; i < precision; i++)
		{
			numberFormat += "#";
		}
	}

	public string GetDoublePrecision()
	{
		return numberFormat;
	}

	public bool ContainsType(string typeKey)
	{
		lock (mMapLock)
		{
			return mTypeCache.ContainsKey(typeKey);
		}
	}

	public abstract bool IsTypeValid(string typeName, Connection connection);

	public SoaType GetType(string typeKey, Connection connection)
	{
		if (typeKey == null || typeKey.Length == 0)
		{
			return null;
		}
		lock (mLoadLock)
		{
			string[] typeKeys = new string[1] { typeKey };
			EnsureTypesAreLoaded(typeKeys, connection);
			return mTypeCache[typeKey];
		}
	}

	public IList<SoaType> GetTypes(IList<string> typeKeys, Connection connection)
	{
		string[] array = new string[typeKeys.Count];
		for (int i = 0; i < typeKeys.Count; i++)
		{
			array[i] = typeKeys[i];
		}
		return GetTypes(array, connection);
	}

	public IList<SoaType> GetTypes(string[] typeKeys, Connection connection)
	{
		lock (mLoadLock)
		{
			EnsureTypesAreLoaded(typeKeys, connection);
			List<SoaType> list = new List<SoaType>(typeKeys.Length);
			foreach (string key in typeKeys)
			{
				SoaType soaType = mTypeCache[key];
				if (soaType != null)
				{
					list.Add(soaType);
				}
			}
			return list;
		}
	}

	public void RemoveType(string typeKey)
	{
		lock (mLoadLock)
		{
			lock (mMapLock)
			{
				mTypeCache.Remove(typeKey);
			}
		}
	}

	protected abstract void LoadTypes(IList<string> typeKeys, Connection connection);

	protected void AddType(SoaType type)
	{
		if (type != null)
		{
			lock (mMapLock)
			{
				mTypeCache[type.Name] = type;
				mTypeCache[type.Uid] = type;
			}
		}
	}

	public bool ContainsLovInfo(string uid)
	{
		lock (mMapLock)
		{
			return mLovCache.ContainsKey(uid);
		}
	}

	public LovInfo GetLovInfo(string uid, SoaType type, Connection connection)
	{
		if (uid == null || uid.Length == 0)
		{
			return null;
		}
		lock (mLoadLock)
		{
			EnsureLovIsLoaded(uid, type, connection);
			try
			{
				return mLovCache[uid];
			}
			catch (KeyNotFoundException)
			{
				logger.Warn("Attempt to get definition for the LOV UID " + uid);
				return null;
			}
		}
	}

	protected abstract void LoadLovInfo(string uid, SoaType type, Connection connection);

	protected void AddLovInfo(LovInfo lovInfo)
	{
		if (lovInfo != null)
		{
			lock (mMapLock)
			{
				mLovCache[lovInfo.Uid] = lovInfo;
			}
		}
	}

	private void EnsureTypesAreLoaded(string[] typeKeys, Connection connection)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (string text in typeKeys)
		{
			if (ContainsType(text))
			{
				continue;
			}
			if (text.Equals(SoaTypeImpl.UNKNOWN_TYPE_NAME) || text.Equals(SoaTypeImpl.UNKNOWN_TYPE_UID))
			{
				SoaType unknownType = DefaultClientMetaModel.UnknownType;
				AddType(unknownType);
			}
			else if (!text.Equals(NullModelObject.UNKNOWN_TYPE))
			{
				dictionary[text] = text;
			}
			else
			{
				lock (mMapLock)
				{
					mTypeCache[text] = null;
				}
			}
		}
		if (dictionary.Count <= 0)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			list.Add(item.Key);
		}
		LoadTypes(list, connection);
		lock (mMapLock)
		{
			foreach (string item2 in list)
			{
				if (!mTypeCache.ContainsKey(item2))
				{
					mTypeCache[item2] = null;
					logger.Warn("The type '" + item2 + "' is and invalid type name.");
				}
			}
		}
	}

	private void EnsureLovIsLoaded(string uid, SoaType type, Connection connection)
	{
		if (!ContainsLovInfo(uid))
		{
			LoadLovInfo(uid, type, connection);
		}
	}
}
