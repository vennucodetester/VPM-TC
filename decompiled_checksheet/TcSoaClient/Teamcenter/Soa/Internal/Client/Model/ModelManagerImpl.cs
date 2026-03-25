using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Internal.Loose.Core;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Exceptions;
using log4net;

namespace Teamcenter.Soa.Internal.Client.Model;

public class ModelManagerImpl : ModelManager, PopulateModel
{
	private static ILog logger = LogManager.GetLogger(typeof(ModelManagerImpl));

	public static readonly string USER_SESSION = "UserSession";

	public static readonly string USER_SESSION_GROUP = "group";

	public static readonly string USER_SESSION_ROLE = "role";

	public static readonly string USER_SESSION_PROJECT = "project";

	public static readonly string USER_SESSION_WORKCTX = "workcontext";

	public static readonly string USER_SESSION_VOLUME = "volume";

	public static readonly string USER_SESSION_LOCAL_VOLUME = "fnd0LocalVolume";

	private ClientDataModel mClientDataModel = null;

	private ClientMetaModel mClientMetaModel = null;

	private Connection mConnection = null;

	private Dictionary<ModelEventListener, ModelEventListener> m_eventListener = new Dictionary<ModelEventListener, ModelEventListener>();

	private Dictionary<ChangeListener, ChangeListener> m_changeListeners = new Dictionary<ChangeListener, ChangeListener>();

	private Dictionary<DeleteListener, DeleteListener> m_deleteListeners = new Dictionary<DeleteListener, DeleteListener>();

	private Dictionary<CreateListener, CreateListener> m_createListeners = new Dictionary<CreateListener, CreateListener>();

	private Dictionary<PartialErrorListener, PartialErrorListener> m_errorListeners = new Dictionary<PartialErrorListener, PartialErrorListener>();

	private Dictionary<SessionHandler, SessionHandler> m_sessionHandlers = new Dictionary<SessionHandler, SessionHandler>();

	protected EventSharerImpl m_eventSharer;

	protected Teamcenter.Soa.Client.Model.ModelObject m_userSession;

	private ModelLock m_modelLock = null;

	private static Dictionary<string, ClientMetaModel> metaModels = new Dictionary<string, ClientMetaModel>();

	private static readonly int PARTIAL_PROPERTY_RETURN = 214012;

	public ClientMetaModel ClientMetaModel
	{
		get
		{
			if (mClientMetaModel == null)
			{
				mClientMetaModel = ConstructClientMetaModel(mConnection);
			}
			return mClientMetaModel;
		}
	}

	public ClientDataModel ClientDataModel
	{
		get
		{
			if (mClientDataModel == null)
			{
				mClientDataModel = ConstructClientDataModel();
			}
			return mClientDataModel;
		}
	}

	public static void RegisterModelObjectFactory(ModelObjectFactory factory)
	{
		DefaultObjectFactory.RegisterModelObjectFactory(factory);
	}

	public ModelManagerImpl(Connection connection, Teamcenter.Soa.Client.Model.ModelObject userSession)
	{
		mConnection = connection;
		m_eventSharer = (EventSharerImpl)connection.EventSharer;
		m_userSession = userSession;
		m_modelLock = new ModelLock(connection);
		if (m_userSession != null)
		{
			ClientDataModel.AddObject(m_userSession);
		}
	}

	public void LoadModelSchema(ModelSchema wireModelSchema)
	{
		throw new ArgumentException("Not expecting this to be called anymore");
	}

	public Teamcenter.Soa.Client.Model.ModelObject GetObject(string uid)
	{
		return ClientDataModel.GetObject(uid);
	}

	public IList<Teamcenter.Soa.Client.Model.ModelObject> GetAllObjectsFromStore()
	{
		return ClientDataModel.GetAllObjectsFromStore();
	}

	public SoaType GetSoaType(string typeName)
	{
		return ClientMetaModel.GetType(typeName, mConnection);
	}

	public IList<SoaType> GetSoaTypes(IList<string> typeNames)
	{
		ClientMetaModel clientMetaModel = ClientMetaModel;
		IList<SoaType> types = clientMetaModel.GetTypes(typeNames, mConnection);
		if (types.Count != typeNames.Count)
		{
			string text = "";
			int num = 0;
			for (int i = 0; i < typeNames.Count; i++)
			{
				if (num >= types.Count || !typeNames[i].Equals(types[num].Name))
				{
					text += ((text.Length == 0) ? typeNames[i] : (", " + typeNames[i]));
				}
				else
				{
					num++;
				}
			}
			throw new NotLoadedException("Failed to load the type(s): " + text);
		}
		List<SoaType> list = new List<SoaType>();
		foreach (SoaType item in types)
		{
			list.Add(item);
		}
		return list;
	}

	public List<SoaType> GetTypes(string[] typeNames)
	{
		ClientMetaModel clientMetaModel = ClientMetaModel;
		IList<SoaType> types = clientMetaModel.GetTypes(typeNames, mConnection);
		if (types.Count != typeNames.Length)
		{
			string text = "";
			int num = 0;
			for (int i = 0; i < typeNames.Length; i++)
			{
				if (num >= types.Count || !typeNames[i].Equals(types[num].Name))
				{
					text += ((text.Length == 0) ? typeNames[i] : (", " + typeNames[i]));
				}
				else
				{
					num++;
				}
			}
			throw new NotLoadedException("Failed to load the type(s): " + text);
		}
		List<SoaType> list = new List<SoaType>();
		foreach (SoaType item in types)
		{
			list.Add(item);
		}
		return list;
	}

	public Teamcenter.Soa.Client.Model.ModelObject ConstructObject(string typeStr, string uid)
	{
		return ClientDataModel.ConstructObject(ClientMetaModel.GetType(typeStr, mConnection), uid);
	}

	public Teamcenter.Soa.Client.Model.ModelObject ConstructObject(string uid)
	{
		return ConstructObject(SoaTypeImpl.UNKNOWN_TYPE_NAME, uid);
	}

	public void RemoveObjectsFromStore(Teamcenter.Soa.Client.Model.ModelObject[] objects)
	{
		ClientDataModel.RemoveObjects(objects);
	}

	public void RemoveObjectsFromStore(string[] uids)
	{
		ClientDataModel.RemoveObjects(uids);
	}

	public void RemoveAllObjectsFromStore()
	{
		ClientDataModel.RemoveAllObjects();
	}

	public void AddModelEventListener(ModelEventListener listener)
	{
		m_eventListener[listener] = listener;
	}

	public void RemoveModelEventListener(ModelEventListener listener)
	{
		m_eventListener.Remove(listener);
	}

	public void AddChangeListener(ChangeListener listener)
	{
		m_changeListeners[listener] = listener;
	}

	public void RemoveChangeListener(ChangeListener listener)
	{
		m_changeListeners.Remove(listener);
	}

	public void AddCreateListener(CreateListener listener)
	{
		m_createListeners[listener] = listener;
	}

	public void RemoveCreateListener(CreateListener listener)
	{
		m_createListeners.Remove(listener);
	}

	public void AddDeleteListener(DeleteListener listener)
	{
		m_deleteListeners[listener] = listener;
	}

	public void RemoveDeleteListener(DeleteListener listener)
	{
		m_deleteListeners.Remove(listener);
	}

	public void AddPartialErrorListener(PartialErrorListener listener)
	{
		m_errorListeners[listener] = listener;
	}

	public void RemovePartialErrorListener(PartialErrorListener listener)
	{
		m_errorListeners.Remove(listener);
	}

	public void AddSharedSessionHandler(SessionHandler handler)
	{
		m_sessionHandlers[handler] = handler;
		m_eventSharer.AddSharedSessionHandler(handler);
	}

	public void RemoveSharedSessionHandler(SessionHandler handler)
	{
		m_sessionHandlers.Remove(handler);
		m_eventSharer.RemoveSharedSessionHandler(handler);
	}

	public void LockModel()
	{
		m_modelLock.Lock();
	}

	public void UnlockModel()
	{
		m_modelLock.Unlock();
	}

	public Teamcenter.Soa.Client.Model.ServiceData LoadServiceData(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData localXmlSD)
	{
		ClientDataModel clientDataModel = ClientDataModel;
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		bool userSessionChanged = false;
		bool userSessionChanged2 = false;
		Teamcenter.Schemas.Soa._2006_03.Base.ServiceData sharedEvents = m_eventSharer.GetSharedEvents();
		ArrayList dataObjects = localXmlSD.getDataObjects();
		int count = dataObjects.Count;
		LoadObjectData(dataObjects, ref userSessionChanged);
		LogDebug(ClassNames.ModelMangerImpl, logger, "ObjectFactory.constructServiceData", " ");
		Teamcenter.Soa.Client.Model.ErrorStack[] partialErrors = LoadPartialErrors(localXmlSD.getPartialErrors(), localXmlSD);
		Teamcenter.Soa.Client.Model.ServiceData serviceData = objectFactory.ConstructServiceData(clientDataModel, localXmlSD, partialErrors);
		Teamcenter.Soa.Client.Model.ServiceData serviceData2 = null;
		if (sharedEvents != null && (sharedEvents.getCreatedObjs().Count > 0 || sharedEvents.getUpdatedObjs().Count > 0 || sharedEvents.getDeletedObjs().Count > 0))
		{
			ConsolidateEvents(sharedEvents, localXmlSD);
			LoadObjectData(sharedEvents.getDataObjects(), ref userSessionChanged2);
			partialErrors = LoadPartialErrors(sharedEvents.getPartialErrors(), sharedEvents);
			serviceData2 = objectFactory.ConstructServiceData(clientDataModel, sharedEvents, partialErrors);
		}
		if (m_eventSharer.IsServerSharedCached())
		{
			m_eventSharer.PushSharedEvents(localXmlSD);
		}
		if (userSessionChanged2)
		{
			NotifySharedSessionHandler();
		}
		if (userSessionChanged)
		{
			NotifyLocalSessionHandler();
		}
		NotifyLocalModelListeners(serviceData);
		NotifySharedModelListeners(serviceData2);
		return serviceData;
	}

	protected void ConsolidateEvents(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData sharedWireSD, Teamcenter.Schemas.Soa._2006_03.Base.ServiceData localWireSD)
	{
		Dictionary<string, string> uids = GetUids(localWireSD.getUpdatedObjs());
		Dictionary<string, string> uids2 = GetUids(localWireSD.getDeletedObjs());
		List<RefId> list = new List<RefId>();
		List<RefId> list2 = new List<RefId>();
		foreach (RefId createdObj in sharedWireSD.getCreatedObjs())
		{
			if (uids2.ContainsKey(createdObj.Uid))
			{
				list.Add(createdObj);
			}
		}
		if (list.Count > 0)
		{
			ArrayList createdObjs = sharedWireSD.getCreatedObjs();
			for (int i = 0; i < list.Count; i++)
			{
				RefId obj = list[i];
				createdObjs.Remove(obj);
			}
			sharedWireSD.setCreatedObjs(createdObjs);
		}
		foreach (RefId updatedObj in sharedWireSD.getUpdatedObjs())
		{
			if (uids.ContainsKey(updatedObj.Uid) || uids2.ContainsKey(updatedObj.Uid))
			{
				list2.Add(updatedObj);
			}
		}
		if (list2.Count > 0)
		{
			ArrayList updatedObjs = sharedWireSD.getUpdatedObjs();
			for (int i = 0; i < list2.Count; i++)
			{
				RefId obj = list2[i];
				updatedObjs.Remove(obj);
			}
			sharedWireSD.setUpdatedObjs(updatedObjs);
		}
		Dictionary<string, string> objUids = GetObjUids(localWireSD.getDataObjects());
		List<Teamcenter.Schemas.Soa._2006_03.Base.ModelObject> list3 = new List<Teamcenter.Schemas.Soa._2006_03.Base.ModelObject>();
		foreach (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject dataObject in sharedWireSD.getDataObjects())
		{
			if (objUids.ContainsKey(dataObject.Uid))
			{
				list3.Add(dataObject);
			}
		}
		if (list3.Count > 0)
		{
			ArrayList dataObjects = sharedWireSD.getDataObjects();
			for (int i = 0; i < list3.Count; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject obj2 = list3[i];
				dataObjects.Remove(obj2);
			}
			sharedWireSD.setDataObjects(dataObjects);
		}
	}

	protected void NotifyLocalSessionHandler()
	{
		foreach (SessionHandler key in m_sessionHandlers.Keys)
		{
			Debug("invoke local Session handler");
			key.LocalSessionChange(m_userSession);
		}
	}

	protected void NotifySharedSessionHandler()
	{
		foreach (SessionHandler key in m_sessionHandlers.Keys)
		{
			Info("invoke *shared* Session handler");
			key.SharedSessionChange(m_userSession);
		}
	}

	public void ProcessSharedEvents(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData sharedWireSD)
	{
		ClientDataModel clientDataModel = ClientDataModel;
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		bool userSessionChanged = false;
		LoadObjectData(sharedWireSD.getDataObjects(), ref userSessionChanged);
		Teamcenter.Soa.Client.Model.ServiceData serviceData = objectFactory.ConstructServiceData(clientDataModel, sharedWireSD, LoadPartialErrors(sharedWireSD.getPartialErrors(), sharedWireSD));
		if (userSessionChanged)
		{
			NotifySharedSessionHandler();
		}
		NotifySharedModelListeners(serviceData);
	}

	private void NotifyLocalModelListeners(Teamcenter.Soa.Client.Model.ServiceData serviceData)
	{
		int num = serviceData.sizeOfUpdatedObjects();
		if (num > 0)
		{
			Teamcenter.Soa.Client.Model.ModelObject[] array = new Teamcenter.Soa.Client.Model.ModelObject[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = serviceData.GetUpdatedObject(i);
			}
			foreach (ModelEventListener key in m_eventListener.Keys)
			{
				key.LocalObjectChange(array);
			}
			foreach (ChangeListener key2 in m_changeListeners.Keys)
			{
				key2.ModelObjectChange(array);
			}
		}
		int num2 = serviceData.sizeOfCreatedObjects();
		if (num2 > 0)
		{
			Teamcenter.Soa.Client.Model.ModelObject[] array2 = new Teamcenter.Soa.Client.Model.ModelObject[num2];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = serviceData.GetCreatedObject(i);
			}
			foreach (ModelEventListener key3 in m_eventListener.Keys)
			{
				key3.LocalObjectCreate(array2);
			}
			foreach (CreateListener key4 in m_createListeners.Keys)
			{
				key4.ModelObjectCreate(array2);
			}
		}
		int num3 = serviceData.sizeOfDeletedObjects();
		if (num3 > 0)
		{
			string[] array3 = new string[num3];
			for (int i = 0; i < num3; i++)
			{
				array3[i] = serviceData.GetDeletedObject(i);
			}
			foreach (ModelEventListener key5 in m_eventListener.Keys)
			{
				key5.LocalObjectDelete(array3);
			}
			foreach (DeleteListener key6 in m_deleteListeners.Keys)
			{
				key6.ModelObjectDelete(array3);
			}
		}
		for (int i = 0; i < serviceData.sizeOfDeletedObjects(); i++)
		{
			ClientDataModel.RemoveObject(serviceData.GetDeletedObject(i));
		}
	}

	private void NotifySharedModelListeners(Teamcenter.Soa.Client.Model.ServiceData serviceData)
	{
		if (m_eventListener == null || serviceData == null)
		{
			return;
		}
		int num = serviceData.sizeOfUpdatedObjects();
		if (num > 0)
		{
			Teamcenter.Soa.Client.Model.ModelObject[] array = new Teamcenter.Soa.Client.Model.ModelObject[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = serviceData.GetUpdatedObject(i);
			}
			foreach (ModelEventListener key in m_eventListener.Keys)
			{
				key.SharedObjectChange(array);
			}
		}
		int num2 = serviceData.sizeOfCreatedObjects();
		if (num2 > 0)
		{
			Teamcenter.Soa.Client.Model.ModelObject[] array2 = new Teamcenter.Soa.Client.Model.ModelObject[num2];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = serviceData.GetCreatedObject(i);
			}
			foreach (ModelEventListener key2 in m_eventListener.Keys)
			{
				key2.SharedObjectCreate(array2);
			}
		}
		int num3 = serviceData.sizeOfDeletedObjects();
		if (num3 > 0)
		{
			string[] array3 = new string[num3];
			for (int i = 0; i < num3; i++)
			{
				array3[i] = serviceData.GetDeletedObject(i);
			}
			foreach (ModelEventListener key3 in m_eventListener.Keys)
			{
				key3.SharedObjectDelete(array3);
			}
		}
		for (int i = 0; i < serviceData.sizeOfDeletedObjects(); i++)
		{
			ClientDataModel.RemoveObject(serviceData.GetDeletedObject(i));
		}
	}

	public Teamcenter.Soa.Client.Model.PartialErrors LoadPartialErrors(Teamcenter.Schemas.Soa._2006_03.Base.PartialErrors xmlPartialErrors)
	{
		return ObjectFactory.GetObjectFactory().ConstructPartialErrors(LoadPartialErrors(xmlPartialErrors.getErrors(), null));
	}

	private Teamcenter.Soa.Client.Model.ErrorStack[] LoadPartialErrors(ArrayList wirePartial, Teamcenter.Schemas.Soa._2006_03.Base.ServiceData xmlServiceData)
	{
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		ClientDataModel clientDataModel = ClientDataModel;
		List<Teamcenter.Soa.Client.Model.ErrorStack> list = new List<Teamcenter.Soa.Client.Model.ErrorStack>();
		foreach (Teamcenter.Schemas.Soa._2006_03.Base.ErrorStack item in wirePartial)
		{
			Teamcenter.Soa.Client.Model.ErrorStack errorStack = objectFactory.ConstructPartialError(clientDataModel, item);
			if (!CheckForPartialPropertyInflate(errorStack, xmlServiceData))
			{
				list.Add(errorStack);
			}
		}
		Teamcenter.Soa.Client.Model.ErrorStack[] array = list.ToArray();
		if (list.Count > 0)
		{
			foreach (PartialErrorListener key in m_errorListeners.Keys)
			{
				key.HandlePartialError(array);
			}
		}
		return array;
	}

	private bool CheckForPartialPropertyInflate(Teamcenter.Soa.Client.Model.ErrorStack stack, Teamcenter.Schemas.Soa._2006_03.Base.ServiceData xmlServiceData)
	{
		int[] codes = stack.Codes;
		foreach (int num in codes)
		{
			if (num == PARTIAL_PROPERTY_RETURN)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject[] dataObjects = xmlServiceData.DataObjects;
				if (dataObjects == null)
				{
					return true;
				}
				string[] array = stack.ClientId.Split(':');
				int num2 = Convert.ToInt32(array[0]);
				int num3 = Convert.ToInt32(array[1]);
				Teamcenter.Soa.Client.Model.ModelObject[] array2 = new Teamcenter.Soa.Client.Model.ModelObject[num3 - num2];
				int num4 = 0;
				for (int j = num2; j < num3; j++)
				{
					Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = dataObjects[j];
					array2[num4++] = GetObject(modelObject.Uid);
				}
				string[] attributes = new string[0];
				SessionService service = SessionService.getService(mConnection);
				service.GetProperties(array2, attributes);
				return true;
			}
		}
		return false;
	}

	public Teamcenter.Soa.Client.Model.ModelObject LoadObjectData(Teamcenter.Schemas.Soa._2006_03.Base.ModelObject xmlObject)
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(xmlObject);
		Teamcenter.Soa.Client.Model.ModelObject[] array = LoadObjectData(arrayList);
		return array[0];
	}

	public Teamcenter.Soa.Client.Model.ModelObject[] LoadObjectData(ArrayList wireObjs)
	{
		bool userSessionChanged = false;
		return LoadObjectData(wireObjs, ref userSessionChanged);
	}

	private Teamcenter.Soa.Client.Model.ModelObject[] LoadObjectData(ArrayList xmlObjects, ref bool userSessionChanged)
	{
		Teamcenter.Soa.Client.Model.ModelObject[] array = new Teamcenter.Soa.Client.Model.ModelObject[xmlObjects.Count];
		ClientMetaModel clientMetaModel = ClientMetaModel;
		ClientDataModel clientDataModel = ClientDataModel;
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		LoadTypesForModelObjects(xmlObjects);
		for (int i = 0; i < xmlObjects.Count; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)xmlObjects[i];
			string uid = modelObject.Uid;
			string type = modelObject.Type;
			if (uid.Equals(NullModelObject.NULL_ID))
			{
				array[i] = null;
				continue;
			}
			SoaType type2 = clientMetaModel.GetType(type, mConnection);
			if (type2 == null)
			{
				string message = "Cannot construct an ModelObject for " + uid + ". The type " + type + " does not exist in the Client Meta Model.";
				logger.Error(message);
				throw new ArgumentException(message);
			}
			array[i] = clientDataModel.ConstructObject(type2, uid);
			string objectID = (modelObject.IsObjectIDSet ? modelObject.ObjectID : "");
			string cParamID = (modelObject.IsCParamIDSet ? modelObject.CParamID : "");
			bool isHistorical = modelObject.IsIsHistoricalSet && modelObject.IsHistorical;
			bool isObsolete = modelObject.IsIsObsoleteSet && modelObject.IsObsolete;
			objectFactory.UpdateVersion(array[i], objectID, cParamID, isHistorical, isObsolete);
		}
		foreach (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject xmlObject in xmlObjects)
		{
			string uid = xmlObject.Uid;
			if (uid.Equals(NullModelObject.NULL_ID))
			{
				continue;
			}
			string type3 = xmlObject.Type;
			Teamcenter.Soa.Client.Model.ModelObject modelObject2 = clientDataModel.GetObject(uid);
			SoaType type4 = clientMetaModel.GetType(type3, mConnection);
			ArrayList properties = xmlObject.getProperties();
			if (USER_SESSION.Equals(type3))
			{
				if (m_userSession == null)
				{
					Debug("First UserSession");
					m_userSession = modelObject2;
					userSessionChanged = true;
				}
				else
				{
					Info("Received UserSession");
					foreach (Teamcenter.Schemas.Soa._2006_03.Base.Property item in properties)
					{
						string value = null;
						string text = "";
						try
						{
							value = PropertyImpl.RetrievePropertyValue(m_userSession.GetProperty(item.Name));
						}
						catch (NotLoadedException)
						{
						}
						objectFactory.AddProperty(modelObject2, type4.GetPropDesc(item.Name), item, clientDataModel);
						try
						{
							text = PropertyImpl.RetrievePropertyValue(m_userSession.GetProperty(item.Name));
						}
						catch (NotLoadedException)
						{
						}
						if (!text.Equals(value))
						{
							userSessionChanged = true;
							Debug("US change: " + item.Name + ":" + item.UiValue);
						}
					}
				}
			}
			LogDebug(ClassNames.ModelMangerImpl, logger, "ObjectFactory.addProperty", GetPropertyNames(modelObject2, properties));
			foreach (Teamcenter.Schemas.Soa._2006_03.Base.Property item2 in properties)
			{
				PropertyDescription propDesc = type4.GetPropDesc(item2.Name);
				if (propDesc == null)
				{
					throw new ArgumentException("Propdesc doesn't exist for the Property, " + item2.Name);
				}
				objectFactory.AddProperty(modelObject2, propDesc, item2, clientDataModel);
			}
			ArrayList uiproperties = xmlObject.getUiproperties();
			LogDebug(ClassNames.ModelMangerImpl, logger, "ObjectFactory.addProperty(", GetUiPropertyNames(modelObject2, uiproperties));
			foreach (DisplayProperty item3 in uiproperties)
			{
				objectFactory.AddProperty(modelObject2, item3.Name, item3.UiValues);
			}
		}
		return array;
	}

	public Teamcenter.Soa.Client.Model.Preferences LoadPreferences(Teamcenter.Schemas.Soa._2006_03.Base.Preferences xmlPreferences)
	{
		return ObjectFactory.GetObjectFactory().ConstructPreferences(xmlPreferences);
	}

	private void LoadTypesForModelObjects(ArrayList wireObjs)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		ClientMetaModel clientMetaModel = ClientMetaModel;
		ClientDataModel clientDataModel = ClientDataModel;
		ObjectFactory objectFactory = ObjectFactory.GetObjectFactory();
		for (int i = 0; i < wireObjs.Count; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)wireObjs[i];
			string type = modelObject.Type;
			if (modelObject.UpdateDesc)
			{
				IList<Teamcenter.Soa.Client.Model.ModelObject> allObjectsFromStore = clientDataModel.GetAllObjectsFromStore();
				foreach (Teamcenter.Soa.Client.Model.ModelObject item in allObjectsFromStore)
				{
					if (item.SoaType.Name.Equals(type))
					{
						objectFactory.RefineType(item, clientMetaModel.GetType(SoaTypeImpl.UNKNOWN_TYPE_NAME, mConnection));
					}
				}
				if (type == null)
				{
					continue;
				}
				clientMetaModel.RemoveType(type);
			}
			dictionary[type] = type;
		}
		List<string> list = new List<string>();
		foreach (string key in dictionary.Keys)
		{
			list.Add(key);
		}
		clientMetaModel.GetTypes(list, mConnection);
	}

	public void RemoveObjectsRecursivelyFromStore(IList<Teamcenter.Soa.Client.Model.ModelObject> objects)
	{
		ClientDataModel.RemoveObjectsRecursively(((List<Teamcenter.Soa.Client.Model.ModelObject>)objects).ToArray());
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	private ClientMetaModel ConstructClientMetaModel(Connection connection)
	{
		string fullName = typeof(DefaultClientMetaModel).FullName;
		fullName = ((connection.GetOption(Connection.OPT_USE_CLIENT_META_MODEL_CACHE).IndexOf(".") != -1) ? connection.GetOption(Connection.OPT_USE_CLIENT_META_MODEL_CACHE) : ((!connection.GetOption(Connection.OPT_USE_CLIENT_META_MODEL_CACHE).ToLower().Equals("true")) ? typeof(CachelessClientMetaModel).FullName : typeof(CachedClientMetaModel).FullName));
		string text = connection.HostPath + "::" + connection.Locale + "::" + fullName;
		if (!metaModels.ContainsKey(text))
		{
			logger.Debug(LogCorrelation.GetId() + ": Constructing " + fullName + " for " + text);
			if (fullName.Equals(typeof(CachedClientMetaModel).FullName))
			{
				metaModels[text] = new CachedClientMetaModel();
			}
			else if (fullName.Equals(typeof(CachelessClientMetaModel).FullName))
			{
				metaModels[text] = new CachelessClientMetaModel();
			}
			else
			{
				if (!fullName.Equals(typeof(DefaultClientMetaModel).FullName))
				{
					string message = "Failed to construct the ClientMetaModel. Do not recognize the class " + fullName;
					ArgumentException ex = new ArgumentException(message);
					throw ex;
				}
				metaModels[text] = new DefaultClientMetaModel();
			}
		}
		logger.Debug(LogCorrelation.GetId() + ": Using existing Client Meta Model for " + text);
		return metaModels[text];
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	private ClientDataModel ConstructClientDataModel()
	{
		return new DefaultClientDataModel();
	}

	public Teamcenter.Soa.Client.Model.ModelObject GetUserSessionObject()
	{
		return m_userSession;
	}

	private void FindReferencedObjects(Dictionary<string, Teamcenter.Schemas.Soa._2006_03.Base.ModelObject> objectMap, Teamcenter.Schemas.Soa._2006_03.Base.ModelObject obj, Dictionary<string, string> referencedUids)
	{
		if (obj == null || obj.getProperties().Count == 0)
		{
			return;
		}
		SoaType type;
		try
		{
			type = ClientMetaModel.GetType(obj.getType(), mConnection);
		}
		catch (NotLoadedException)
		{
			throw new ArgumentException("The Shared Event data contains an instance of " + obj.getType() + "(" + obj.Uid + ") that does not have Meta Model definition.");
		}
		ArrayList properties = obj.getProperties();
		for (int i = 0; i < properties.Count; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.Property property = (Teamcenter.Schemas.Soa._2006_03.Base.Property)properties[i];
			property.getValues();
			PropertyDescriptionImpl propertyDescriptionImpl = (PropertyDescriptionImpl)type.PropDescs[property.getName()];
			if (propertyDescriptionImpl == null)
			{
				throw new ArgumentException("Propdesc doesn't exist for the Property, " + property.getName());
			}
			PropertyImpl propertyImpl = PropertyImpl.createPropertyObject(property.UiValues, property.Name, propertyDescriptionImpl.Modifiable, propertyDescriptionImpl);
			PropertyValue[] values = property.Values;
			if (values != null)
			{
				propertyImpl.AddRawValues(values, ClientDataModel);
			}
			int type2 = propertyDescriptionImpl.Type;
			if (type2 != 8)
			{
				continue;
			}
			if (propertyDescriptionImpl.Array)
			{
				if (propertyImpl.ModelObjectArrayValue == null)
				{
					continue;
				}
				Teamcenter.Soa.Client.Model.ModelObject[] modelObjectArrayValue = propertyImpl.ModelObjectArrayValue;
				foreach (Teamcenter.Soa.Client.Model.ModelObject modelObject in modelObjectArrayValue)
				{
					if (modelObject != null && !referencedUids.ContainsKey(modelObject.Uid))
					{
						referencedUids[modelObject.Uid] = modelObject.Uid;
						Teamcenter.Schemas.Soa._2006_03.Base.ModelObject obj2 = objectMap[modelObject.Uid];
						FindReferencedObjects(objectMap, obj2, referencedUids);
					}
				}
			}
			else
			{
				Teamcenter.Soa.Client.Model.ModelObject modelObject = propertyImpl.ModelObjectValue;
				if (modelObject != null && !referencedUids.ContainsKey(modelObject.Uid))
				{
					referencedUids[modelObject.Uid] = modelObject.Uid;
					Teamcenter.Schemas.Soa._2006_03.Base.ModelObject obj2 = objectMap[modelObject.Uid];
					FindReferencedObjects(objectMap, obj2, referencedUids);
				}
			}
		}
	}

	public void RemoveUnreferencedObjects(ArrayList objects, List<string> eventObjs)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Dictionary<string, Teamcenter.Schemas.Soa._2006_03.Base.ModelObject> dictionary2 = new Dictionary<string, Teamcenter.Schemas.Soa._2006_03.Base.ModelObject>();
		for (int i = 0; i < objects.Count; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i];
			dictionary2[modelObject.Uid] = modelObject;
		}
		for (int i = 0; i < objects.Count; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i];
			if (eventObjs.Contains(modelObject.getUid()))
			{
				FindReferencedObjects(dictionary2, modelObject, dictionary);
			}
		}
		List<Teamcenter.Schemas.Soa._2006_03.Base.ModelObject> list = new List<Teamcenter.Schemas.Soa._2006_03.Base.ModelObject>();
		for (int i = 0; i < objects.Count; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)objects[i];
			if (!dictionary.ContainsKey(modelObject.getUid()) && !eventObjs.Contains(modelObject.getUid()))
			{
				list.Add(modelObject);
			}
		}
		if (list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = list[i];
				objects.Remove(modelObject);
			}
		}
	}

	private Dictionary<string, string> GetObjUids(ArrayList dataObjects)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (Teamcenter.Schemas.Soa._2006_03.Base.ModelObject dataObject in dataObjects)
		{
			dictionary[dataObject.Uid] = dataObject.Uid;
		}
		return dictionary;
	}

	protected Dictionary<string, string> GetUids(ArrayList eventObjs)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (RefId eventObj in eventObjs)
		{
			dictionary[eventObj.Uid] = eventObj.Uid;
		}
		return dictionary;
	}

	protected void Info(string msg)
	{
		m_eventSharer.Info(msg);
	}

	protected void Debug(string msg)
	{
		m_eventSharer.Debug(msg);
	}

	private static string GetPropertyNames(Teamcenter.Soa.Client.Model.ModelObject modObj, ArrayList properties)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = "";
		foreach (Teamcenter.Schemas.Soa._2006_03.Base.Property property in properties)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += property.Name;
		}
		if (text.Length == 0)
		{
			return null;
		}
		return modObj.Uid + " - " + text;
	}

	private static string GetUiPropertyNames(Teamcenter.Soa.Client.Model.ModelObject modObj, ArrayList xmlProperties)
	{
		if (!logger.IsDebugEnabled)
		{
			return null;
		}
		string text = "";
		foreach (DisplayProperty xmlProperty in xmlProperties)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += xmlProperty.Name;
		}
		if (text.Length == 0)
		{
			return null;
		}
		return modObj.Uid + " - " + text;
	}

	public static void LogDebug(ClassNames className, ILog theLogger, string label, string arg)
	{
		if (theLogger.IsDebugEnabled && arg != null && arg.Length != 0)
		{
			theLogger.Debug(LogCorrelation.GetId() + ": " + $"{label,-45:s}" + "( " + arg + " )");
		}
	}
}
