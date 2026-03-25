using System;
using System.Collections;
using Teamcenter.Schemas.Core._2006_03.Filemanagement;
using Teamcenter.Schemas.Core._2007_01.Filemanagement;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Loose.Core._2006_03.FileManagement;
using Teamcenter.Services.Loose.Core._2007_01.FileManagement;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Loose.Core;

public class FileManagementRestBindingStub : FileManagementService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Connection localConnection;

	private static readonly string FILEMANAGEMENT_200603_PORT_NAME = "Core-2006-03-FileManagement";

	private static readonly string FILEMANAGEMENT_200701_PORT_NAME = "Core-2007-01-FileManagement";

	public FileManagementRestBindingStub(Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
	}

	public static Teamcenter.Schemas.Core._2006_03.Filemanagement.CommitDatasetFileInfo toWire(Teamcenter.Services.Loose.Core._2006_03.FileManagement.CommitDatasetFileInfo local)
	{
		Teamcenter.Schemas.Core._2006_03.Filemanagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Schemas.Core._2006_03.Filemanagement.CommitDatasetFileInfo();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		commitDatasetFileInfo.setDataset(modelObject);
		commitDatasetFileInfo.setCreateNewVersion(local.CreateNewVersion);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetFileTicketInfos.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetFileTicketInfos[i]));
		}
		commitDatasetFileInfo.setDatasetFileTicketInfos(arrayList);
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Services.Loose.Core._2006_03.FileManagement.CommitDatasetFileInfo toLocal(Teamcenter.Schemas.Core._2006_03.Filemanagement.CommitDatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2006_03.FileManagement.CommitDatasetFileInfo commitDatasetFileInfo = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.CommitDatasetFileInfo();
		commitDatasetFileInfo.Dataset = modelManager.LoadObjectData(wire.getDataset());
		commitDatasetFileInfo.CreateNewVersion = wire.CreateNewVersion;
		IList datasetFileTicketInfos = wire.getDatasetFileTicketInfos();
		commitDatasetFileInfo.DatasetFileTicketInfos = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileTicketInfo[datasetFileTicketInfos.Count];
		for (int i = 0; i < datasetFileTicketInfos.Count; i++)
		{
			commitDatasetFileInfo.DatasetFileTicketInfos[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileTicketInfo)datasetFileTicketInfos[i], modelManager);
		}
		return commitDatasetFileInfo;
	}

	public static Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileInfo toWire(Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileInfo local)
	{
		Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileInfo();
		datasetFileInfo.setClientId(local.ClientId);
		datasetFileInfo.setFileName(local.FileName);
		datasetFileInfo.setNamedReferencedName(local.NamedReferencedName);
		datasetFileInfo.setIsText(local.IsText);
		datasetFileInfo.setAllowReplace(local.AllowReplace);
		return datasetFileInfo;
	}

	public static Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileInfo toLocal(Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileInfo datasetFileInfo = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileInfo();
		datasetFileInfo.ClientId = wire.getClientId();
		datasetFileInfo.FileName = wire.getFileName();
		datasetFileInfo.NamedReferencedName = wire.getNamedReferencedName();
		datasetFileInfo.IsText = wire.IsText;
		datasetFileInfo.AllowReplace = wire.AllowReplace;
		return datasetFileInfo;
	}

	public static Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileTicketInfo toWire(Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileTicketInfo local)
	{
		Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.setDatasetFileInfo(toWire(local.DatasetFileInfo));
		datasetFileTicketInfo.setTicket(local.Ticket);
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileTicketInfo toLocal(Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileTicketInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileTicketInfo datasetFileTicketInfo = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileTicketInfo();
		datasetFileTicketInfo.DatasetFileInfo = toLocal(wire.getDatasetFileInfo(), modelManager);
		datasetFileTicketInfo.Ticket = wire.getTicket();
		return datasetFileTicketInfo;
	}

	public static Teamcenter.Services.Loose.Core._2006_03.FileManagement.FileTicketsResponse toLocal(Teamcenter.Schemas.Core._2006_03.Filemanagement.FileTicketsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2006_03.FileManagement.FileTicketsResponse fileTicketsResponse = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.FileTicketsResponse();
		fileTicketsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		fileTicketsResponse.Tickets = toLocalTicketMap(wire.getTickets(), modelManager);
		return fileTicketsResponse;
	}

	public static Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsInputData toWire(Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsInputData local)
	{
		Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsInputData getDatasetWriteTicketsInputData = new Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsInputData();
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.Dataset == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.Dataset.Uid);
		}
		getDatasetWriteTicketsInputData.setDataset(modelObject);
		getDatasetWriteTicketsInputData.setCreateNewVersion(local.CreateNewVersion);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.DatasetFileInfos.Length; i++)
		{
			arrayList.Add(toWire(local.DatasetFileInfos[i]));
		}
		getDatasetWriteTicketsInputData.setDatasetFileInfos(arrayList);
		return getDatasetWriteTicketsInputData;
	}

	public static Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsInputData toLocal(Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsInputData wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsInputData getDatasetWriteTicketsInputData = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsInputData();
		getDatasetWriteTicketsInputData.Dataset = modelManager.LoadObjectData(wire.getDataset());
		getDatasetWriteTicketsInputData.CreateNewVersion = wire.CreateNewVersion;
		IList datasetFileInfos = wire.getDatasetFileInfos();
		getDatasetWriteTicketsInputData.DatasetFileInfos = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.DatasetFileInfo[datasetFileInfos.Count];
		for (int i = 0; i < datasetFileInfos.Count; i++)
		{
			getDatasetWriteTicketsInputData.DatasetFileInfos[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Filemanagement.DatasetFileInfo)datasetFileInfos[i], modelManager);
		}
		return getDatasetWriteTicketsInputData;
	}

	public static Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsResponse toLocal(Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsResponse getDatasetWriteTicketsResponse = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsResponse();
		getDatasetWriteTicketsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList commitInfo = wire.getCommitInfo();
		getDatasetWriteTicketsResponse.CommitInfo = new Teamcenter.Services.Loose.Core._2006_03.FileManagement.CommitDatasetFileInfo[commitInfo.Count];
		for (int i = 0; i < commitInfo.Count; i++)
		{
			getDatasetWriteTicketsResponse.CommitInfo[i] = toLocal((Teamcenter.Schemas.Core._2006_03.Filemanagement.CommitDatasetFileInfo)commitInfo[i], modelManager);
		}
		return getDatasetWriteTicketsResponse;
	}

	public static ArrayList toWireTicketMap(IDictionary TicketMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in TicketMap)
		{
			object key = item.Key;
			object value = item.Value;
			TicketMap ticketMap = new TicketMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			ticketMap.setKey(modelObject);
			ticketMap.setValue(Convert.ToString(value));
			arrayList.Add(ticketMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalTicketMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			TicketMap ticketMap = (TicketMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(ticketMap.getKey());
			string value = ticketMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData CommitDatasetFiles(Teamcenter.Services.Loose.Core._2006_03.FileManagement.CommitDatasetFileInfo[] CommitInput)
	{
		try
		{
			restSender.PushRequestId();
			CommitDatasetFilesInput commitDatasetFilesInput = new CommitDatasetFilesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < CommitInput.Length; i++)
			{
				arrayList.Add(toWire(CommitInput[i]));
			}
			commitDatasetFilesInput.setCommitInput(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200603_PORT_NAME, "CommitDatasetFiles", commitDatasetFilesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Soa._2006_03.Base.ServiceData wireServiceData = (Teamcenter.Schemas.Soa._2006_03.Base.ServiceData)obj;
			Teamcenter.Soa.Client.Model.ServiceData result = modelManager.LoadServiceData(wireServiceData);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
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

	public override Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsResponse GetDatasetWriteTickets(Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsInputData[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetDatasetWriteTicketsInput getDatasetWriteTicketsInput = new GetDatasetWriteTicketsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getDatasetWriteTicketsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200603_PORT_NAME, "GetDatasetWriteTickets", getDatasetWriteTicketsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsResponse wire = (Teamcenter.Schemas.Core._2006_03.Filemanagement.GetDatasetWriteTicketsResponse)obj;
			Teamcenter.Services.Loose.Core._2006_03.FileManagement.GetDatasetWriteTicketsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
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

	public override Teamcenter.Services.Loose.Core._2006_03.FileManagement.FileTicketsResponse GetFileReadTickets(Teamcenter.Soa.Client.Model.ModelObject[] Files)
	{
		try
		{
			restSender.PushRequestId();
			GetFileReadTicketsInput getFileReadTicketsInput = new GetFileReadTicketsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Files.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (Files[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(Files[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getFileReadTicketsInput.setFiles(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2006_03.Filemanagement.FileTicketsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200603_PORT_NAME, "GetFileReadTickets", getFileReadTicketsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2006_03.Filemanagement.FileTicketsResponse wire = (Teamcenter.Schemas.Core._2006_03.Filemanagement.FileTicketsResponse)obj;
			Teamcenter.Services.Loose.Core._2006_03.FileManagement.FileTicketsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
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

	public static Teamcenter.Services.Loose.Core._2007_01.FileManagement.GetTransientFileTicketsResponse toLocal(Teamcenter.Schemas.Core._2007_01.Filemanagement.GetTransientFileTicketsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2007_01.FileManagement.GetTransientFileTicketsResponse getTransientFileTicketsResponse = new Teamcenter.Services.Loose.Core._2007_01.FileManagement.GetTransientFileTicketsResponse();
		getTransientFileTicketsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		IList transientFileTicketInfos = wire.getTransientFileTicketInfos();
		getTransientFileTicketsResponse.TransientFileTicketInfos = new Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileTicketInfo[transientFileTicketInfos.Count];
		for (int i = 0; i < transientFileTicketInfos.Count; i++)
		{
			getTransientFileTicketsResponse.TransientFileTicketInfos[i] = toLocal((Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileTicketInfo)transientFileTicketInfos[i], modelManager);
		}
		return getTransientFileTicketsResponse;
	}

	public static Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileInfo toWire(Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileInfo transientFileInfo = new Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileInfo();
		transientFileInfo.setFileName(local.FileName);
		transientFileInfo.setIsBinary(local.IsBinary);
		transientFileInfo.setDeleteFlag(local.DeleteFlag);
		return transientFileInfo;
	}

	public static Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileInfo toLocal(Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileInfo transientFileInfo = new Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileInfo();
		transientFileInfo.FileName = wire.getFileName();
		transientFileInfo.IsBinary = wire.IsBinary;
		transientFileInfo.DeleteFlag = wire.DeleteFlag;
		return transientFileInfo;
	}

	public static Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileTicketInfo toWire(Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileTicketInfo local)
	{
		Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileTicketInfo transientFileTicketInfo = new Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileTicketInfo();
		transientFileTicketInfo.setTransientFileInfo(toWire(local.TransientFileInfo));
		transientFileTicketInfo.setTicket(local.Ticket);
		return transientFileTicketInfo;
	}

	public static Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileTicketInfo toLocal(Teamcenter.Schemas.Core._2007_01.Filemanagement.TransientFileTicketInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileTicketInfo transientFileTicketInfo = new Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileTicketInfo();
		transientFileTicketInfo.TransientFileInfo = toLocal(wire.getTransientFileInfo(), modelManager);
		transientFileTicketInfo.Ticket = wire.getTicket();
		return transientFileTicketInfo;
	}

	public override Teamcenter.Services.Loose.Core._2007_01.FileManagement.GetTransientFileTicketsResponse GetTransientFileTicketsForUpload(Teamcenter.Services.Loose.Core._2007_01.FileManagement.TransientFileInfo[] TransientFileInfos)
	{
		try
		{
			restSender.PushRequestId();
			GetTransientFileTicketsForUploadInput getTransientFileTicketsForUploadInput = new GetTransientFileTicketsForUploadInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < TransientFileInfos.Length; i++)
			{
				arrayList.Add(toWire(TransientFileInfos[i]));
			}
			getTransientFileTicketsForUploadInput.setTransientFileInfos(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Core._2007_01.Filemanagement.GetTransientFileTicketsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200701_PORT_NAME, "GetTransientFileTicketsForUpload", getTransientFileTicketsForUploadInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Core._2007_01.Filemanagement.GetTransientFileTicketsResponse wire = (Teamcenter.Schemas.Core._2007_01.Filemanagement.GetTransientFileTicketsResponse)obj;
			Teamcenter.Services.Loose.Core._2007_01.FileManagement.GetTransientFileTicketsResponse result = toLocal(wire, modelManager);
			if (!localConnection.GetOption(Connection.OPT_CACHE_MODEL_OBJECTS).Equals("true"))
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
