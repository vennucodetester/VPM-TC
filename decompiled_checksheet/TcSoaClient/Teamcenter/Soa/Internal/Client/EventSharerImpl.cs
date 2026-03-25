using System;
using System.Collections;
using System.Collections.Generic;
using Teamcenter.Net.TcModelEventManager.Client;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Common.Utils;
using Teamcenter.Soa.Internal.Client.Model;
using log4net;

namespace Teamcenter.Soa.Internal.Client;

public class EventSharerImpl : EventSharer
{
	private static string RUNTIME_BUSINESS_OBJECT = "RuntimeBusinessObject";

	private Connection connection;

	private ModelManagerImpl modelManagerImpl;

	private bool sharedEventsEnabled;

	private bool isTcmemReg;

	private TcMEMConnection tcmem;

	private string[] sharedClientList;

	private string clientId;

	private string locale;

	private string cmuser;

	private string cmdiscr;

	private static ILog _logger = LogManager.GetLogger(typeof(EventSharerImpl));

	private bool logInfo;

	private bool logDebug;

	private Hashtable mSessionHandlers = new Hashtable();

	public EventSharerImpl(Connection connection)
	{
		this.connection = connection;
		logInfo = _logger.IsInfoEnabled;
		logDebug = _logger.IsDebugEnabled;
	}

	public bool IsEventSharingFunctioning()
	{
		if (tcmem == null)
		{
			try
			{
				tcmem = TcMEMNetBindingLoader.GetTcMEMConnectionInstance();
			}
			catch (TcMEMConnectionException e)
			{
				HandleTcMemException(e, invokeHandler: false);
				return false;
			}
		}
		try
		{
			int status = tcmem.GetStatus();
			if (status != TcMEMConnection.TCMEM_CONNECTION_STATUS_CHECK_OK)
			{
				_logger.Warn("TcMEM status problem: " + status + " for client " + clientId);
				return false;
			}
		}
		catch (TcMEMException e2)
		{
			HandleTcMemException(e2, invokeHandler: false);
			return false;
		}
		if (!isTcmemReg && sharedEventsEnabled && cmuser != null && clientId != null)
		{
			try
			{
				Info("isEventSharingFunctioning re-registration for client " + clientId);
				RegisterWithTcMEM(cmuser, cmdiscr, clientId, locale);
				isTcmemReg = true;
			}
			catch (TcMEMException e2)
			{
				InvokeHandler(e2.Message);
			}
		}
		return true;
	}

	public void RegisterWithTcMEM(string user, string discr, string clientId, string locale)
	{
		sharedEventsEnabled = connection.GetOption(Connection.OPT_SHARED_EVENTS).Equals("true", StringComparison.OrdinalIgnoreCase);
		modelManagerImpl = (ModelManagerImpl)connection.ModelManager;
		this.locale = locale;
		if (!sharedEventsEnabled)
		{
			return;
		}
		try
		{
			if (tcmem == null)
			{
				tcmem = TcMEMNetBindingLoader.GetTcMEMConnectionInstance();
			}
			cmuser = user;
			cmdiscr = discr;
			this.clientId = clientId;
			int status = tcmem.GetStatus();
			if (status != TcMEMConnection.TCMEM_CONNECTION_STATUS_CHECK_OK)
			{
				_logger.Warn("TcMEM status problem: " + status + " for client " + clientId);
				InvokeHandler("TcMEM status problem: " + status);
				return;
			}
			string text = user + "." + discr + "." + connection.getServerAddress();
			sharedClientList = tcmem.RegisterClient(text, clientId, locale);
			isTcmemReg = true;
			_logger.Info("TcMEM registered client: " + clientId);
			if (sharedClientList == null)
			{
				_logger.Warn("TCMEM registration returned null!");
				return;
			}
			if (sharedClientList.Length < 1)
			{
				_logger.Warn("TcMEM registration returned empty client list");
				return;
			}
			Debug("tcmem REG'd: clients:" + sharedClientList.Length + " serverID: " + text);
		}
		catch (TcMEMException e)
		{
			HandleTcMemException(e, invokeHandler: true);
		}
	}

	public void UnregisterTcMEM()
	{
		if (isTcmemReg && tcmem != null)
		{
			try
			{
				sharedClientList = tcmem.UnregisterClient();
			}
			catch (TcMEMException ex)
			{
				InvokeHandler(ex.Message);
				_logger.Warn("Problem during unregisterTcMEM: " + ex);
			}
			isTcmemReg = false;
			if (sharedClientList != null)
			{
				Info("tcmem: UNREG'd clients: " + sharedClientList.Length);
				Debug("tcmem: UNREG'd clients: " + sharedClientList.Length);
			}
			else
			{
				_logger.Info("tcmem: UNREG'd clients: 0");
			}
		}
	}

	public Teamcenter.Schemas.Soa._2006_03.Base.ServiceData GetSharedEvents()
	{
		if (!sharedEventsEnabled || !isTcmemReg)
		{
			return null;
		}
		Teamcenter.Schemas.Soa._2006_03.Base.ServiceData serviceData = null;
		try
		{
			string events = tcmem.GetEvents(LogCorrelation.GetId(), ref sharedClientList);
			XmlBindingUtils xmlBindingUtils = new XmlBindingUtils();
			serviceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)xmlBindingUtils.Deserialize(events, typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData), null);
			if (serviceData.CreatedObjs != null || serviceData.UpdatedObjs != null || serviceData.DeletedObjs != null)
			{
				Info("tcmem GET: objs:" + serviceData.getDataObjects().Count + " created:" + serviceData.getCreatedObjs().Count + " changed:" + serviceData.getUpdatedObjs().Count + " deleted:" + serviceData.getDeletedObjs().Count);
				Debug("TcMEM GET: " + events);
			}
			return serviceData;
		}
		catch (TcMEMException e)
		{
			HandleTcMemException(e, invokeHandler: true);
		}
		return null;
	}

	public bool PushSharedEvents(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData)
	{
		if (!sharedEventsEnabled || !isTcmemReg || wireServiceData == null)
		{
			return false;
		}
		if (wireServiceData.CreatedObjs != null || wireServiceData.UpdatedObjs != null || wireServiceData.DeletedObjs != null)
		{
			CullDataObjects(wireServiceData);
			try
			{
				XmlBindingUtils xmlBindingUtils = new XmlBindingUtils();
				string serviceDataXML = XmlBindingUtils.UTF8ByteArrayToString(xmlBindingUtils.Serialize(wireServiceData));
				sharedClientList = tcmem.PutEvents(serviceDataXML, LogCorrelation.GetId());
				Info("tcmem PUT: objs:" + wireServiceData.getDataObjects().Count + " -  created:" + wireServiceData.getCreatedObjs().Count + " changed:" + wireServiceData.getUpdatedObjs().Count + " deleted:" + wireServiceData.getDeletedObjs().Count);
				return true;
			}
			catch (TcMEMException e)
			{
				HandleTcMemException(e, invokeHandler: true);
			}
		}
		return false;
	}

	private void CullDataObjects(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData serviceData)
	{
		serviceData.getPlainObjs().Clear();
		FilterUnwantedObjects(serviceData);
		ArrayList dataObjects = serviceData.getDataObjects();
		if (dataObjects.Count > 0)
		{
			List<string> list = new List<string>();
			List<string> uids = GetUids(serviceData.getCreatedObjs());
			for (int i = 0; i < uids.Count; i++)
			{
				list.Add(uids[i]);
			}
			List<string> uids2 = GetUids(serviceData.getUpdatedObjs());
			for (int i = 0; i < uids2.Count; i++)
			{
				list.Add(uids2[i]);
			}
			List<string> uids3 = GetUids(serviceData.getDeletedObjs());
			for (int i = 0; i < uids3.Count; i++)
			{
				list.Add(uids3[i]);
			}
			modelManagerImpl.RemoveUnreferencedObjects(dataObjects, list);
			serviceData.setDataObjects(dataObjects);
		}
	}

	private void FilterUnwantedObjects(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData serviceData)
	{
		ArrayList runtimeObjects = GetRuntimeObjects(serviceData.getCreatedObjs());
		ArrayList runtimeObjects2 = GetRuntimeObjects(serviceData.getUpdatedObjs());
		ArrayList runtimeObjects3 = GetRuntimeObjects(serviceData.getDeletedObjs());
		if (runtimeObjects.Count > 0)
		{
			ArrayList createdObjs = serviceData.getCreatedObjs();
			for (int i = 0; i < runtimeObjects.Count; i++)
			{
				RefId obj = (RefId)runtimeObjects[i];
				createdObjs.Remove(obj);
			}
			serviceData.setCreatedObjs(createdObjs);
		}
		if (runtimeObjects2.Count > 0)
		{
			ArrayList updatedObjs = serviceData.getUpdatedObjs();
			for (int i = 0; i < runtimeObjects2.Count; i++)
			{
				RefId obj = (RefId)runtimeObjects2[i];
				updatedObjs.Remove(obj);
			}
			serviceData.setUpdatedObjs(updatedObjs);
		}
		if (runtimeObjects3.Count > 0)
		{
			ArrayList deletedObjs = serviceData.getDeletedObjs();
			for (int i = 0; i < runtimeObjects3.Count; i++)
			{
				RefId obj = (RefId)runtimeObjects3[i];
				deletedObjs.Remove(obj);
			}
			serviceData.setDeletedObjs(deletedObjs);
		}
		if (runtimeObjects.Count + runtimeObjects2.Count > 0)
		{
			Info("Filtering runtimeObjects:" + runtimeObjects.Count + runtimeObjects2.Count);
		}
	}

	private ArrayList GetRuntimeObjects(ArrayList eventObjs)
	{
		ArrayList arrayList = new ArrayList();
		foreach (RefId eventObj in eventObjs)
		{
			SoaType soaType = null;
			try
			{
				soaType = modelManagerImpl.GetObject(eventObj.Uid).SoaType;
			}
			catch (ArgumentException)
			{
				continue;
			}
			if (soaType.IsInstanceOf(RUNTIME_BUSINESS_OBJECT) && !soaType.IsInstanceOf(ModelManagerImpl.USER_SESSION))
			{
				arrayList.Add(eventObj);
			}
		}
		return arrayList;
	}

	public bool IsServerSharedCached()
	{
		if (isTcmemReg)
		{
			return sharedClientList.Length > 1;
		}
		return false;
	}

	private List<string> GetUids(ArrayList eventObjs)
	{
		List<string> list = new List<string>();
		foreach (RefId eventObj in eventObjs)
		{
			list.Add(eventObj.getUid());
		}
		return list;
	}

	public bool IsServerShared()
	{
		if (isTcmemReg)
		{
			try
			{
				sharedClientList = tcmem.GetSharedClients();
				return sharedClientList.Length > 1;
			}
			catch (TcMEMException e)
			{
				HandleTcMemException(e, invokeHandler: true);
			}
		}
		return false;
	}

	private void HandleTcMemException(TcMEMException e, bool invokeHandler)
	{
		_logger.Warn("TcMEM problem: " + e);
		if (e is TcMEMConnectionException || e is TcMEMUnrecognisedException)
		{
			isTcmemReg = false;
		}
		if (invokeHandler)
		{
			InvokeHandler(e.Message);
		}
	}

	public void ProcessSharedEvents()
	{
		if (isTcmemReg)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData sharedEvents = GetSharedEvents();
			if (sharedEvents != null)
			{
				modelManagerImpl.ProcessSharedEvents(sharedEvents);
			}
		}
	}

	private void InvokeHandler(string msg)
	{
		IEnumerator enumerator = mSessionHandlers.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			SessionHandler sessionHandler = (SessionHandler)enumerator.Current;
			sessionHandler.HandleException(new InternalServerException(msg));
		}
	}

	public void AddSharedSessionHandler(SessionHandler handler)
	{
		mSessionHandlers[handler] = handler;
	}

	public void RemoveSharedSessionHandler(SessionHandler handler)
	{
		mSessionHandlers.Remove(handler);
	}

	public void Info(string msg)
	{
		if (logInfo)
		{
			_logger.Info(LogCorrelation.GetId() + ": " + msg);
		}
	}

	public void Debug(string msg)
	{
		if (logDebug)
		{
			_logger.Debug(LogCorrelation.GetId() + ": " + msg);
		}
	}
}
