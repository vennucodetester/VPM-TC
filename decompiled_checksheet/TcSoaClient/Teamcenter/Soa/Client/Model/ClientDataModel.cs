using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Teamcenter.Soa.Exceptions;
using Teamcenter.Soa.Internal.Client.Model;
using log4net;

namespace Teamcenter.Soa.Client.Model;

public abstract class ClientDataModel
{
	protected Dictionary<string, ModelObject> mObjectMap = new Dictionary<string, ModelObject>();

	private static ILog logger = LogManager.GetLogger(typeof(ClientDataModel));

	protected abstract ModelObject LoadObject(SoaType type, string uid);

	protected abstract void RefineType(ModelObject obj, SoaType type);

	[MethodImpl(MethodImplOptions.Synchronized)]
	public ModelObject ConstructObject(SoaType type, string uid)
	{
		if (!ValidateUID(uid))
		{
			ArgumentException ex = new ArgumentException("Invalid UID specified: " + uid);
			logger.Error("Invalid UID specified: " + uid, ex);
			throw ex;
		}
		if (!ContainsObject(uid))
		{
			ModelObject modelObject = LoadObject(type, uid);
			AddObject(modelObject);
		}
		else if (DefaultClientMetaModel.UnknownType == GetObject(uid).SoaType)
		{
			RefineType(GetObject(uid), type);
		}
		return GetObject(uid);
	}

	public ModelObject ConstructObject(string uid)
	{
		return ConstructObject(DefaultClientMetaModel.UnknownType, uid);
	}

	public bool ContainsObject(string uid)
	{
		lock (this)
		{
			return mObjectMap.ContainsKey(uid);
		}
	}

	public ModelObject GetObject(string uid)
	{
		if (uid == null || uid.Length == 0)
		{
			return null;
		}
		lock (this)
		{
			if (ContainsObject(uid))
			{
				return mObjectMap[uid];
			}
		}
		ArgumentException ex = new ArgumentException("The object " + uid + " has not been loaded.");
		logger.Debug(ex.Message, ex);
		throw ex;
	}

	public void RemoveObject(string uid)
	{
		lock (this)
		{
			if (ContainsObject(uid))
			{
				mObjectMap.Remove(uid);
			}
		}
	}

	public void RemoveObjects(ModelObject[] objects)
	{
		foreach (ModelObject modelObject in objects)
		{
			if (modelObject != null)
			{
				RemoveObject(modelObject.Uid);
			}
		}
	}

	public void RemoveObjects(string[] uids)
	{
		foreach (string uid in uids)
		{
			RemoveObject(uid);
		}
	}

	public void RemoveAllObjects()
	{
		lock (this)
		{
			mObjectMap.Clear();
		}
	}

	public void RemoveObjectsRecursively(ModelObject[] objects)
	{
		foreach (ModelObject obj in objects)
		{
			RecursiveDelete(obj);
		}
	}

	public IList<ModelObject> GetAllObjectsFromStore()
	{
		lock (this)
		{
			List<ModelObject> list = new List<ModelObject>();
			foreach (KeyValuePair<string, ModelObject> item in mObjectMap)
			{
				list.Add(item.Value);
			}
			return list;
		}
	}

	public void AddObject(ModelObject modelObject)
	{
		lock (this)
		{
			mObjectMap[modelObject.Uid] = modelObject;
		}
	}

	private void RecursiveDelete(ModelObject obj)
	{
		string[] propertyNames = obj.PropertyNames;
		foreach (string text in propertyNames)
		{
			Property property;
			try
			{
				property = obj.GetProperty(text);
			}
			catch (NotLoadedException)
			{
				logger.Debug("During the recursiveDelete an attempt was made to reference the property" + text + " on the object " + obj.Uid + " (" + obj.SoaType.Name + ")");
				continue;
			}
			PropertyDescription propertyDescription = property.PropertyDescription;
			int type = propertyDescription.Type;
			if (type != 8)
			{
				continue;
			}
			if (propertyDescription.Array)
			{
				ModelObject[] modelObjectArrayValue = property.ModelObjectArrayValue;
				foreach (ModelObject modelObject in modelObjectArrayValue)
				{
					if (modelObject != null)
					{
						RecursiveDelete(modelObject);
					}
				}
			}
			else
			{
				ModelObject modelObjectValue = property.ModelObjectValue;
				if (modelObjectValue != null)
				{
					RecursiveDelete(modelObjectValue);
				}
			}
		}
		RemoveObjects(new string[1] { obj.Uid });
	}

	private bool ValidateUID(string uid)
	{
		if (uid.StartsWith("BOM::") || uid.StartsWith("TYPE::") || uid.StartsWith("SR::") || uid.Length == 14 || uid.Length == 28 || uid.Length == 29)
		{
			return true;
		}
		return false;
	}
}
