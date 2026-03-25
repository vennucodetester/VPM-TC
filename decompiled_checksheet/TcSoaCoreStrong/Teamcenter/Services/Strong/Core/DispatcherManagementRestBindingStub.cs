using System;
using System.Collections;
using Teamcenter.Schemas.Core._2008_06.Dispatchermanagement;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Strong.Core;

public class DispatcherManagementRestBindingStub : DispatcherManagementService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Teamcenter.Soa.Client.Connection localConnection;

	private static readonly string DISPATCHERMANAGEMENT_200806_PORT_NAME = "Core-2008-06-DispatcherManagement";

	public DispatcherManagementRestBindingStub(Teamcenter.Soa.Client.Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
		StrongObjectFactory.Init();
	}

	public static Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestArgs toWire(Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestArgs local)
	{
		Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestArgs createDispatcherRequestArgs = new Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestArgs();
		createDispatcherRequestArgs.setProviderName(local.ProviderName);
		createDispatcherRequestArgs.setServiceName(local.ServiceName);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.PrimaryObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.PrimaryObjects[i] == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(local.PrimaryObjects[i].Uid);
			}
			arrayList.Add(modelObject);
		}
		createDispatcherRequestArgs.setPrimaryObjects(arrayList);
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < local.SecondaryObjects.Length; i++)
		{
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject2 = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if (local.SecondaryObjects[i] == null)
			{
				modelObject2.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject2.setUid(local.SecondaryObjects[i].Uid);
			}
			arrayList2.Add(modelObject2);
		}
		createDispatcherRequestArgs.setSecondaryObjects(arrayList2);
		createDispatcherRequestArgs.setPriority(local.Priority);
		createDispatcherRequestArgs.setStartTime(local.StartTime);
		createDispatcherRequestArgs.setEndTime(local.EndTime);
		createDispatcherRequestArgs.setInterval(local.Interval);
		ArrayList arrayList3 = new ArrayList();
		for (int i = 0; i < local.KeyValueArgs.Length; i++)
		{
			arrayList3.Add(toWire(local.KeyValueArgs[i]));
		}
		createDispatcherRequestArgs.setKeyValueArgs(arrayList3);
		ArrayList arrayList4 = new ArrayList();
		for (int i = 0; i < local.DataFiles.Length; i++)
		{
			arrayList4.Add(toWire(local.DataFiles[i]));
		}
		createDispatcherRequestArgs.setDataFiles(arrayList4);
		createDispatcherRequestArgs.setType(local.Type);
		return createDispatcherRequestArgs;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestArgs toLocal(Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestArgs wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestArgs createDispatcherRequestArgs = new Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestArgs();
		createDispatcherRequestArgs.ProviderName = wire.getProviderName();
		createDispatcherRequestArgs.ServiceName = wire.getServiceName();
		IList primaryObjects = wire.getPrimaryObjects();
		createDispatcherRequestArgs.PrimaryObjects = new Teamcenter.Soa.Client.Model.ModelObject[primaryObjects.Count];
		for (int i = 0; i < primaryObjects.Count; i++)
		{
			createDispatcherRequestArgs.PrimaryObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)primaryObjects[i]);
		}
		IList secondaryObjects = wire.getSecondaryObjects();
		createDispatcherRequestArgs.SecondaryObjects = new Teamcenter.Soa.Client.Model.ModelObject[secondaryObjects.Count];
		for (int i = 0; i < secondaryObjects.Count; i++)
		{
			createDispatcherRequestArgs.SecondaryObjects[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)secondaryObjects[i]);
		}
		createDispatcherRequestArgs.Priority = wire.getPriority();
		createDispatcherRequestArgs.StartTime = wire.getStartTime();
		createDispatcherRequestArgs.EndTime = wire.getEndTime();
		createDispatcherRequestArgs.Interval = wire.getInterval();
		IList keyValueArgs = wire.getKeyValueArgs();
		createDispatcherRequestArgs.KeyValueArgs = new Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.KeyValueArguments[keyValueArgs.Count];
		for (int i = 0; i < keyValueArgs.Count; i++)
		{
			createDispatcherRequestArgs.KeyValueArgs[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.KeyValueArguments)keyValueArgs[i], modelManager);
		}
		IList dataFiles = wire.getDataFiles();
		createDispatcherRequestArgs.DataFiles = new Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.DataFiles[dataFiles.Count];
		for (int i = 0; i < dataFiles.Count; i++)
		{
			createDispatcherRequestArgs.DataFiles[i] = toLocal((Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.DataFiles)dataFiles[i], modelManager);
		}
		createDispatcherRequestArgs.Type = wire.getType();
		return createDispatcherRequestArgs;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestResponse toLocal(Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestResponse createDispatcherRequestResponse = new Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestResponse();
		createDispatcherRequestResponse.SvcData = modelManager.LoadServiceData(wire.getServiceData());
		IList requestsCreated = wire.getRequestsCreated();
		createDispatcherRequestResponse.RequestsCreated = new Teamcenter.Soa.Client.Model.ModelObject[requestsCreated.Count];
		for (int i = 0; i < requestsCreated.Count; i++)
		{
			createDispatcherRequestResponse.RequestsCreated[i] = modelManager.LoadObjectData((Teamcenter.Schemas.Soa._2006_03.Base.ModelObject)requestsCreated[i]);
		}
		return createDispatcherRequestResponse;
	}

	public static Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.DataFiles toWire(Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.DataFiles local)
	{
		Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.DataFiles dataFiles = new Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.DataFiles();
		dataFiles.setKey(local.Key);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.File == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.File.Uid);
		}
		dataFiles.setFile(modelObject);
		return dataFiles;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.DataFiles toLocal(Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.DataFiles wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.DataFiles dataFiles = new Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.DataFiles();
		dataFiles.Key = wire.getKey();
		dataFiles.File = (ImanFile)modelManager.LoadObjectData(wire.getFile());
		return dataFiles;
	}

	public static Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.KeyValueArguments toWire(Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.KeyValueArguments local)
	{
		Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.KeyValueArguments keyValueArguments = new Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.KeyValueArguments();
		keyValueArguments.setKey(local.Key);
		keyValueArguments.setValue(local.Value);
		return keyValueArguments;
	}

	public static Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.KeyValueArguments toLocal(Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.KeyValueArguments wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.KeyValueArguments keyValueArguments = new Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.KeyValueArguments();
		keyValueArguments.Key = wire.getKey();
		keyValueArguments.Value = wire.getValue();
		return keyValueArguments;
	}

	public override Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestResponse CreateDispatcherRequest(Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestArgs[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			CreateDispatcherRequestInput createDispatcherRequestInput = new CreateDispatcherRequestInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			createDispatcherRequestInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestResponse);
			Type[] array = null;
			array = new Type[1] { typeof(ServiceException) };
			object obj = restSender.Invoke(DISPATCHERMANAGEMENT_200806_PORT_NAME, "CreateDispatcherRequest", createDispatcherRequestInput, typeFromHandle, array);
			modelManager.LockModel();
			if (obj is ServiceException)
			{
				throw (ServiceException)obj;
			}
			Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestResponse wire = (Teamcenter.Schemas.Core._2008_06.Dispatchermanagement.CreateDispatcherRequestResponse)obj;
			Teamcenter.Services.Strong.Core._2008_06.DispatcherManagement.CreateDispatcherRequestResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Teamcenter.Soa.Client.Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
			{
				localConnection.ModelManager.RemoveAllObjectsFromStore();
			}
			return result;
		}
		finally
		{
			restSender.PopRequestId();
			modelManager.UnlockModel();
		}
	}
}
