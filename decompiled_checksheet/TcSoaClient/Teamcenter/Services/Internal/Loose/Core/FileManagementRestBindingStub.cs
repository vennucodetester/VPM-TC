using System;
using System.Collections;
using Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement;
using Teamcenter.Schemas.Internal.Core._2010_09.Filemanagement;
using Teamcenter.Schemas.Soa._2006_03.Base;
using Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement;
using Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;

namespace Teamcenter.Services.Internal.Loose.Core;

public class FileManagementRestBindingStub : FileManagementService
{
	private Sender restSender;

	private PopulateModel modelManager;

	private Connection localConnection;

	private static readonly string FILEMANAGEMENT_200806_PORT_NAME = "Internal-Core-2008-06-FileManagement";

	private static readonly string FILEMANAGEMENT_201009_PORT_NAME = "Internal-Core-2010-09-FileManagement";

	public FileManagementRestBindingStub(Connection connection)
	{
		localConnection = connection;
		restSender = connection.Sender;
		modelManager = (PopulateModel)connection.ModelManager;
	}

	public static Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesInput toWire(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesInput local)
	{
		Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesInput commitUploadedRegularFilesInput = new Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesInput();
		commitUploadedRegularFilesInput.setFileName(local.FileName);
		commitUploadedRegularFilesInput.setFileTicket(local.FileTicket);
		commitUploadedRegularFilesInput.setClientId(local.ClientId);
		return commitUploadedRegularFilesInput;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesInput toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesInput commitUploadedRegularFilesInput = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesInput();
		commitUploadedRegularFilesInput.FileName = wire.getFileName();
		commitUploadedRegularFilesInput.FileTicket = wire.getFileTicket();
		commitUploadedRegularFilesInput.ClientId = wire.getClientId();
		return commitUploadedRegularFilesInput;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesResponse toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesResponse commitUploadedRegularFilesResponse = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesResponse();
		commitUploadedRegularFilesResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		commitUploadedRegularFilesResponse.Files = toLocalImanFilesMap(wire.getFiles(), modelManager);
		return commitUploadedRegularFilesResponse;
	}

	public static Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfo toWire(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfo local)
	{
		Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfo fileInfo = new Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfo();
		fileInfo.setClientFileId(local.ClientFileId);
		fileInfo.setRefName(local.RefName);
		fileInfo.setIsText(local.IsText);
		fileInfo.setFileName(local.FileName);
		return fileInfo;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfo toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfo fileInfo = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfo();
		fileInfo.ClientFileId = wire.getClientFileId();
		fileInfo.RefName = wire.getRefName();
		fileInfo.IsText = wire.IsText;
		fileInfo.FileName = wire.getFileName();
		return fileInfo;
	}

	public static Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfoTicket toWire(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket local)
	{
		Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfoTicket fileInfoTicket = new Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfoTicket();
		fileInfoTicket.setClientFileId(local.ClientFileId);
		fileInfoTicket.setTicket(local.Ticket);
		return fileInfoTicket;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfoTicket wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket fileInfoTicket = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket();
		fileInfoTicket.ClientFileId = wire.getClientFileId();
		fileInfoTicket.Ticket = wire.getTicket();
		return fileInfoTicket;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileTicketsResponse toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileTicketsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileTicketsResponse fileTicketsResponse = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileTicketsResponse();
		fileTicketsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		fileTicketsResponse.Tickets = toLocalTicketMap(wire.getTickets(), modelManager);
		return fileTicketsResponse;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetFileTransferTicketsResponse toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetFileTransferTicketsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetFileTransferTicketsResponse getFileTransferTicketsResponse = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetFileTransferTicketsResponse();
		getFileTransferTicketsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getFileTransferTicketsResponse.ReadTickets = toLocalTransferTicketMap(wire.getReadTickets(), modelManager);
		getFileTransferTicketsResponse.WriteTickets = toLocalTransferTicketMap(wire.getWriteTickets(), modelManager);
		return getFileTransferTicketsResponse;
	}

	public static Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsInput toWire(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsInput local)
	{
		Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsInput getRegularFileWriteTicketsInput = new Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsInput();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.RegularFileInfos.Length; i++)
		{
			arrayList.Add(toWire(local.RegularFileInfos[i]));
		}
		getRegularFileWriteTicketsInput.setRegularFileInfos(arrayList);
		getRegularFileWriteTicketsInput.setClientId(local.ClientId);
		return getRegularFileWriteTicketsInput;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsInput toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsInput getRegularFileWriteTicketsInput = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsInput();
		IList regularFileInfos = wire.getRegularFileInfos();
		getRegularFileWriteTicketsInput.RegularFileInfos = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.RegularFileInfo[regularFileInfos.Count];
		for (int i = 0; i < regularFileInfos.Count; i++)
		{
			getRegularFileWriteTicketsInput.RegularFileInfos[i] = toLocal((Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.RegularFileInfo)regularFileInfos[i], modelManager);
		}
		getRegularFileWriteTicketsInput.ClientId = wire.getClientId();
		return getRegularFileWriteTicketsInput;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsResponse toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsResponse getRegularFileWriteTicketsResponse = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsResponse();
		getRegularFileWriteTicketsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		getRegularFileWriteTicketsResponse.WriteTickets = toLocalWriteTicketsMap(wire.getWriteTickets(), modelManager);
		return getRegularFileWriteTicketsResponse;
	}

	public static Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.RegularFileInfo toWire(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.RegularFileInfo local)
	{
		Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.RegularFileInfo regularFileInfo = new Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.RegularFileInfo();
		regularFileInfo.setFileName(local.FileName);
		regularFileInfo.setIsText(local.IsText);
		return regularFileInfo;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.RegularFileInfo toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.RegularFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.RegularFileInfo regularFileInfo = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.RegularFileInfo();
		regularFileInfo.FileName = wire.getFileName();
		regularFileInfo.IsText = wire.IsText;
		return regularFileInfo;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.UpdateImanFileCommitsResponse toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.UpdateImanFileCommitsResponse wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.UpdateImanFileCommitsResponse updateImanFileCommitsResponse = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.UpdateImanFileCommitsResponse();
		updateImanFileCommitsResponse.ServiceData = modelManager.LoadServiceData(wire.getServiceData());
		updateImanFileCommitsResponse.Delays = toLocalDelayMap(wire.getDelays(), modelManager);
		updateImanFileCommitsResponse.WriteTickets = toLocalTransferTicketMap(wire.getWriteTickets(), modelManager);
		return updateImanFileCommitsResponse;
	}

	public static Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.WriteTicketsInput toWire(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.WriteTicketsInput local)
	{
		Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.WriteTicketsInput writeTicketsInput = new Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.WriteTicketsInput();
		writeTicketsInput.setClientId(local.ClientId);
		writeTicketsInput.setDatasetTypeName(local.DatasetTypeName);
		writeTicketsInput.setVersion(local.Version);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < local.FileInfos.Length; i++)
		{
			arrayList.Add(toWire(local.FileInfos[i]));
		}
		writeTicketsInput.setFileInfos(arrayList);
		return writeTicketsInput;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.WriteTicketsInput toLocal(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.WriteTicketsInput wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.WriteTicketsInput writeTicketsInput = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.WriteTicketsInput();
		writeTicketsInput.ClientId = wire.getClientId();
		writeTicketsInput.DatasetTypeName = wire.getDatasetTypeName();
		writeTicketsInput.Version = wire.getVersion();
		IList fileInfos = wire.getFileInfos();
		writeTicketsInput.FileInfos = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfo[fileInfos.Count];
		for (int i = 0; i < fileInfos.Count; i++)
		{
			writeTicketsInput.FileInfos[i] = toLocal((Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfo)fileInfos[i], modelManager);
		}
		return writeTicketsInput;
	}

	public static ArrayList toWireDelayMap(IDictionary DelayMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in DelayMap)
		{
			object key = item.Key;
			object value = item.Value;
			DelayMap delayMap = new DelayMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			delayMap.setKey(modelObject);
			delayMap.setValue((int)value);
			arrayList.Add(delayMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalDelayMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			DelayMap delayMap = (DelayMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(delayMap.getKey());
			int value = delayMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireImanFilesMap(IDictionary ImanFilesMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in ImanFilesMap)
		{
			object key = item.Key;
			object value = item.Value;
			ImanFilesMap imanFilesMap = new ImanFilesMap();
			imanFilesMap.setKey(Convert.ToString(key));
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)value == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)value).Uid);
			}
			imanFilesMap.setValue(modelObject);
			arrayList.Add(imanFilesMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalImanFilesMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			ImanFilesMap imanFilesMap = (ImanFilesMap)wire[i];
			string key = imanFilesMap.getKey();
			Teamcenter.Soa.Client.Model.ModelObject value = modelManager.LoadObjectData(imanFilesMap.getValue());
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireTicketMap(IDictionary TicketMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in TicketMap)
		{
			object key = item.Key;
			object value = item.Value;
			TicketMap ticketMap = new TicketMap();
			ticketMap.setKey(Convert.ToString(key));
			IList value2 = ticketMap.getValue();
			Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket[] array = (Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket[])value;
			for (int i = 0; i < array.Length; i++)
			{
				value2.Add(toWire(array[i]));
			}
			ticketMap.setValue((ArrayList)value2);
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
			string key = ticketMap.getKey();
			IList value = ticketMap.getValue();
			Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket[] array = new Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileInfoTicket[value.Count];
			for (int j = 0; j < value.Count; j++)
			{
				array[j] = toLocal((Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileInfoTicket)value[j], modelManager);
			}
			hashtable.Add(key, array);
		}
		return hashtable;
	}

	public static ArrayList toWireTransferTicketMap(IDictionary TransferTicketMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in TransferTicketMap)
		{
			object key = item.Key;
			object value = item.Value;
			TransferTicketMap transferTicketMap = new TransferTicketMap();
			Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
			if ((Teamcenter.Soa.Client.Model.ModelObject)key == null)
			{
				modelObject.setUid(NullModelObject.NULL_ID);
			}
			else
			{
				modelObject.setUid(((Teamcenter.Soa.Client.Model.ModelObject)key).Uid);
			}
			transferTicketMap.setKey(modelObject);
			transferTicketMap.setValue(Convert.ToString(value));
			arrayList.Add(transferTicketMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalTransferTicketMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			TransferTicketMap transferTicketMap = (TransferTicketMap)wire[i];
			Teamcenter.Soa.Client.Model.ModelObject key = modelManager.LoadObjectData(transferTicketMap.getKey());
			string value = transferTicketMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public static ArrayList toWireWriteTicketsMap(IDictionary WriteTicketsMap)
	{
		ArrayList arrayList = new ArrayList();
		foreach (DictionaryEntry item in WriteTicketsMap)
		{
			object key = item.Key;
			object value = item.Value;
			WriteTicketsMap writeTicketsMap = new WriteTicketsMap();
			writeTicketsMap.setKey(Convert.ToString(key));
			writeTicketsMap.setValue(Convert.ToString(value));
			arrayList.Add(writeTicketsMap);
		}
		return arrayList;
	}

	public static Hashtable toLocalWriteTicketsMap(ArrayList wire, PopulateModel modelManager)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < wire.Count; i++)
		{
			WriteTicketsMap writeTicketsMap = (WriteTicketsMap)wire[i];
			string key = writeTicketsMap.getKey();
			string value = writeTicketsMap.getValue();
			hashtable.Add(key, value);
		}
		return hashtable;
	}

	public override Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesResponse CommitRegularFiles(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesInput[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			CommitRegularFilesInput commitRegularFilesInput = new CommitRegularFilesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			commitRegularFilesInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200806_PORT_NAME, "CommitRegularFiles", commitRegularFilesInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesResponse wire = (Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.CommitUploadedRegularFilesResponse)obj;
			Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.CommitUploadedRegularFilesResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetFileTransferTicketsResponse GetFileTransferTickets(Teamcenter.Soa.Client.Model.ModelObject[] ImanFiles)
	{
		try
		{
			restSender.PushRequestId();
			GetFileTransferTicketsInput getFileTransferTicketsInput = new GetFileTransferTicketsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < ImanFiles.Length; i++)
			{
				Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
				if (ImanFiles[i] == null)
				{
					modelObject.setUid(NullModelObject.NULL_ID);
				}
				else
				{
					modelObject.setUid(ImanFiles[i].Uid);
				}
				arrayList.Add(modelObject);
			}
			getFileTransferTicketsInput.setImanFiles(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetFileTransferTicketsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200806_PORT_NAME, "GetFileTransferTickets", getFileTransferTicketsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetFileTransferTicketsResponse wire = (Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetFileTransferTicketsResponse)obj;
			Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetFileTransferTicketsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsResponse GetRegularFileTicketsForUpload(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsInput[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetRegularFileTicketsForUploadInput getRegularFileTicketsForUploadInput = new GetRegularFileTicketsForUploadInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getRegularFileTicketsForUploadInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200806_PORT_NAME, "GetRegularFileTicketsForUpload", getRegularFileTicketsForUploadInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsResponse wire = (Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.GetRegularFileWriteTicketsResponse)obj;
			Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.GetRegularFileWriteTicketsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileTicketsResponse GetWriteTickets(Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.WriteTicketsInput[] Inputs)
	{
		try
		{
			restSender.PushRequestId();
			GetWriteTicketsInput getWriteTicketsInput = new GetWriteTicketsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < Inputs.Length; i++)
			{
				arrayList.Add(toWire(Inputs[i]));
			}
			getWriteTicketsInput.setInputs(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileTicketsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200806_PORT_NAME, "GetWriteTickets", getWriteTicketsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileTicketsResponse wire = (Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.FileTicketsResponse)obj;
			Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.FileTicketsResponse result = toLocal(wire, modelManager);
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

	public override Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.UpdateImanFileCommitsResponse UpdateImanFileCommits(string[] CleanupInfo)
	{
		try
		{
			restSender.PushRequestId();
			UpdateImanFileCommitsInput updateImanFileCommitsInput = new UpdateImanFileCommitsInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < CleanupInfo.Length; i++)
			{
				arrayList.Add(CleanupInfo[i]);
			}
			updateImanFileCommitsInput.setCleanupInfo(arrayList);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.UpdateImanFileCommitsResponse);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_200806_PORT_NAME, "UpdateImanFileCommits", updateImanFileCommitsInput, typeFromHandle, extraTypes);
			modelManager.LockModel();
			Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.UpdateImanFileCommitsResponse wire = (Teamcenter.Schemas.Internal.Core._2008_06.Filemanagement.UpdateImanFileCommitsResponse)obj;
			Teamcenter.Services.Internal.Loose.Core._2008_06.FileManagement.UpdateImanFileCommitsResponse result = toLocal(wire, modelManager);
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

	public static Teamcenter.Schemas.Internal.Core._2010_09.Filemanagement.CommitReplacedFileInfo toWire(Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement.CommitReplacedFileInfo local)
	{
		Teamcenter.Schemas.Internal.Core._2010_09.Filemanagement.CommitReplacedFileInfo commitReplacedFileInfo = new Teamcenter.Schemas.Internal.Core._2010_09.Filemanagement.CommitReplacedFileInfo();
		commitReplacedFileInfo.setReplaceFileTicket(local.ReplaceFileTicket);
		commitReplacedFileInfo.setNewOriginalFileName(local.NewOriginalFileName);
		Teamcenter.Schemas.Soa._2006_03.Base.ModelObject modelObject = new Teamcenter.Schemas.Soa._2006_03.Base.ModelObject();
		if (local.ImanFile == null)
		{
			modelObject.setUid(NullModelObject.NULL_ID);
		}
		else
		{
			modelObject.setUid(local.ImanFile.Uid);
		}
		commitReplacedFileInfo.setImanFile(modelObject);
		return commitReplacedFileInfo;
	}

	public static Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement.CommitReplacedFileInfo toLocal(Teamcenter.Schemas.Internal.Core._2010_09.Filemanagement.CommitReplacedFileInfo wire, PopulateModel modelManager)
	{
		Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement.CommitReplacedFileInfo commitReplacedFileInfo = new Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement.CommitReplacedFileInfo();
		commitReplacedFileInfo.ReplaceFileTicket = wire.getReplaceFileTicket();
		commitReplacedFileInfo.NewOriginalFileName = wire.getNewOriginalFileName();
		commitReplacedFileInfo.ImanFile = modelManager.LoadObjectData(wire.getImanFile());
		return commitReplacedFileInfo;
	}

	public override Teamcenter.Soa.Client.Model.ServiceData CommitReplacedFiles(Teamcenter.Services.Internal.Loose.Core._2010_09.FileManagement.CommitReplacedFileInfo[] CommitInfos, bool[] Flags)
	{
		try
		{
			restSender.PushRequestId();
			CommitReplacedFilesInput commitReplacedFilesInput = new CommitReplacedFilesInput();
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < CommitInfos.Length; i++)
			{
				arrayList.Add(toWire(CommitInfos[i]));
			}
			commitReplacedFilesInput.setCommitInfos(arrayList);
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < Flags.Length; i++)
			{
				arrayList2.Add(Flags[i]);
			}
			commitReplacedFilesInput.setFlags(arrayList2);
			Type typeFromHandle = typeof(Teamcenter.Schemas.Soa._2006_03.Base.ServiceData);
			Type[] extraTypes = null;
			object obj = restSender.Invoke(FILEMANAGEMENT_201009_PORT_NAME, "CommitReplacedFiles", commitReplacedFilesInput, typeFromHandle, extraTypes);
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
}
