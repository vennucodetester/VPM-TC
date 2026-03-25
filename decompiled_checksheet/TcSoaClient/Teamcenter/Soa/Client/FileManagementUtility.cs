using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Services.Loose.Core;
using Teamcenter.Services.Loose.Core._2006_03.FileManagement;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Internal.Client;
using Teamcenter.Soa.Internal.Client.Model;
using log4net;

namespace Teamcenter.Soa.Client;

public class FileManagementUtility
{
	private class FmsServiceData : ServiceData
	{
		private ArrayList updatedIds = new ArrayList();

		internal ArrayList partialErrors = new ArrayList();

		private ModelManager manager = null;

		public FmsServiceData(ModelManager manager)
		{
			this.manager = manager;
		}

		public int sizeOfCreatedObjects()
		{
			return 0;
		}

		public int sizeOfDeletedObjects()
		{
			return 0;
		}

		public int sizeOfUpdatedObjects()
		{
			return updatedIds.Count;
		}

		public int sizeOfPlainObjects()
		{
			return 0;
		}

		public int sizeOfPartialErrors()
		{
			return partialErrors.Count;
		}

		public ModelObject GetCreatedObject(int index)
		{
			return null;
		}

		public string GetDeletedObject(int index)
		{
			return null;
		}

		internal void addUpdateObject(string uid)
		{
			updatedIds.Add(uid);
		}

		public ModelObject GetUpdatedObject(int index)
		{
			return manager.GetObject((string)updatedIds[index]);
		}

		public ModelObject GetPlainObject(int index)
		{
			return null;
		}

		internal void addPartialError(ErrorStack paritalError)
		{
			partialErrors.Add(paritalError);
		}

		public ErrorStack GetPartialError(int index)
		{
			return (ErrorStack)partialErrors[index];
		}
	}

	private static ILog logger = LogManager.GetLogger(typeof(FileManagementUtility));

	private FileManagementService fileManagementService;

	private FMSWrapper fmsWrapper = null;

	private Connection connection;

	private bool debug = false;

	public FileManagementUtility(Connection connection)
	{
		int num = 0;
		while (fmsWrapper == null && num++ < 10)
		{
			try
			{
				fmsWrapper = FMSLoader.GetFCCInstance();
			}
			catch (Exception ex)
			{
				ExceptionHandler exceptionHandler = connection.ExceptionHandler;
				exceptionHandler.HandleException(new InternalServerException(ex.Message, ex));
			}
		}
		Init(connection);
	}

	public FileManagementUtility(Connection connection, string clientIPAddress, string[] assignedFSCURIs, string[] bootstrapFSCURIs, string cacheDir)
	{
		InitFSC(connection, clientIPAddress, assignedFSCURIs, bootstrapFSCURIs, cacheDir);
		Init(connection);
	}

	private void InitFSC(Connection connection, string clientIPAddress, string[] assignedFSCURIs, string[] bootstrapFSCURIs, string cacheDir)
	{
		try
		{
			fmsWrapper = FMSLoader.GetFSCInstance(clientIPAddress, assignedFSCURIs, bootstrapFSCURIs, cacheDir);
		}
		catch (Exception ex)
		{
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(ex.Message, ex));
		}
	}

	private void Init(Connection connection)
	{
		this.connection = connection;
		fileManagementService = FileManagementService.getService(connection);
		string environmentVariable = Environment.GetEnvironmentVariable("DebugFMUtility");
		if (environmentVariable != null && environmentVariable.ToLower().Equals("true"))
		{
			debug = true;
		}
	}

	public void Term()
	{
		try
		{
			fmsWrapper.Term();
		}
		catch (FMSException)
		{
		}
	}

	public GetFileResponse GetFiles(ModelObject[] files)
	{
		return DoGetFiles(files, null, null);
	}

	public GetFileResponse GetFiles(ModelObject[] files, FMS_Progress_Callback cb, object callbackContext)
	{
		return DoGetFiles(files, cb, callbackContext);
	}

	public FileInfo GetFile(string fmsTicket)
	{
		return GetFiles(new string[1] { fmsTicket }, null, null)[0];
	}

	public FileInfo GetFile(string fmsTicket, FMS_Progress_Callback cb, object callbackContext)
	{
		return GetFiles(new string[1] { fmsTicket }, cb, callbackContext)[0];
	}

	public FileInfo[] GetFiles(string[] fmsTickets)
	{
		return GetFiles(fmsTickets, null, null);
	}

	public FileInfo[] GetFiles(string[] fmsTickets, FMS_Progress_Callback cb, object callbackContext)
	{
		FileInfo[] array = new FileInfo[fmsTickets.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = null;
		}
		string[] array2 = null;
		try
		{
			array2 = fmsWrapper.RegisterTickets(fmsTickets);
		}
		catch (FMSException ex)
		{
			logger.Error("Failed to register the FMS tickets." + ex.Message);
			return array;
		}
		try
		{
			string[] array3 = fmsWrapper.DownLoadFilesFromPLM("IMD", cb, callbackContext, array2);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new FileInfo(array3[i]);
			}
		}
		catch (FMSException ex)
		{
			logger.Error("Failed to download the files." + ex.Message);
			return array;
		}
		return array;
	}

	private GetFileResponse DoGetFiles(ModelObject[] files, FMS_Progress_Callback cb, object callbackContext)
	{
		Log("Start: GetFiles");
		GetFileResponse getFileResponse = new GetFileResponse();
		FileTicketsResponse fileReadTickets = fileManagementService.GetFileReadTickets(files);
		int num = fileReadTickets.ServiceData.sizeOfPartialErrors();
		Log("getFileReadTickets succeeded: No. of partialErrors =" + num);
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				getFileResponse.AddPartialError(fileReadTickets.ServiceData.GetPartialError(i));
			}
		}
		if (fileReadTickets.Tickets.Count == 0)
		{
			Log("Zero tickets returned");
			return getFileResponse;
		}
		string[] ticketsFromMap = GetTicketsFromMap(fileReadTickets.Tickets);
		string[] uids;
		try
		{
			uids = fmsWrapper.RegisterTickets(ticketsFromMap);
			Log("Register Tickets succeeded");
		}
		catch (FMSException ex)
		{
			string message = ex.Message;
			message = message + " \n Error while registering tickets with FMS for download. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			return DoGetFiles(files, cb, callbackContext);
		}
		string[] files2;
		try
		{
			files2 = fmsWrapper.DownLoadFilesFromPLM("IMD", cb, callbackContext, uids);
			Log("DownloadedFilesFromPLM succeeded");
		}
		catch (FMSException ex)
		{
			Cleanup(uids, terminateFCC: true);
			string message = ex.Message;
			message = message + " \n Error while Downloading files from PLM using FMS. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			return DoGetFiles(files, cb, callbackContext);
		}
		getFileResponse.SetFiles(FilePathsToHandlers(files2));
		Cleanup(uids, terminateFCC: false);
		Log("End :GetFile");
		return getFileResponse;
	}

	public GetFileResponse GetFileToLocation(ModelObject file, string destinationFilePath, FMS_Progress_Callback cb, object callbackContext)
	{
		return DoGetFileToLocation(file, destinationFilePath, cb, callbackContext);
	}

	private GetFileResponse DoGetFileToLocation(ModelObject namedRef, string destinationFilePath, FMS_Progress_Callback cb, object callbackContext)
	{
		Log("Start: DoGetFileToLocation");
		GetFileResponse getFileResponse = new GetFileResponse();
		ModelObject[] files = new ModelObject[1] { namedRef };
		FileTicketsResponse fileReadTickets = fileManagementService.GetFileReadTickets(files);
		int num = fileReadTickets.ServiceData.sizeOfPartialErrors();
		Log("getFileReadTickets succeeded: No. of partialErrors =" + num);
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				getFileResponse.AddPartialError(fileReadTickets.ServiceData.GetPartialError(i));
			}
		}
		if (fileReadTickets.Tickets.Count == 0)
		{
			Log("Zero tickets returned");
			return getFileResponse;
		}
		string[] ticketsFromMap = GetTicketsFromMap(fileReadTickets.Tickets);
		string[] array = new string[1];
		string uID;
		try
		{
			uID = (array[0] = fmsWrapper.RegisterTicket(ticketsFromMap[0]));
			Log("Register Tickets succeeded");
		}
		catch (FMSException ex)
		{
			string message = ex.Message;
			message = message + " \n Error while registering tickets with FMS for download to location. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			return DoGetFileToLocation(namedRef, destinationFilePath, cb, callbackContext);
		}
		FileInfo fileInfo;
		try
		{
			fileInfo = fmsWrapper.DownLoadTransientFile("IMD", cb, callbackContext, uID, destinationFilePath);
			Log("DownLoadTransientFile succeeded");
		}
		catch (FMSException ex)
		{
			Cleanup(array, terminateFCC: true);
			string message = ex.Message;
			message = message + " \n Error while Downloading files to location using FMS. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			return DoGetFileToLocation(namedRef, destinationFilePath, cb, callbackContext);
		}
		getFileResponse.SetFiles(new FileInfo[1] { fileInfo });
		Cleanup(array, terminateFCC: false);
		Log("End :DoGetFileToLocation");
		return getFileResponse;
	}

	public ServiceData PutFiles(GetDatasetWriteTicketsInputData[] inputs)
	{
		try
		{
			return DoPutFiles(inputs, validate: true, null, null);
		}
		catch (ServiceException ex)
		{
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(ex.Message, ex));
			return PutFiles(inputs);
		}
	}

	public ServiceData PutFiles(GetDatasetWriteTicketsInputData[] inputs, FMS_Progress_Callback cb, object callbackContext)
	{
		return DoPutFiles(inputs, validate: true, cb, callbackContext);
	}

	private ServiceData DoPutFiles(GetDatasetWriteTicketsInputData[] inputs, bool validate, FMS_Progress_Callback cb, object callbackContext)
	{
		Log("Start : DoPutFile");
		string[] array = null;
		string[] array2 = null;
		string[] array3 = null;
		string[] array4 = null;
		FmsServiceData fmsServiceData = new FmsServiceData(connection.ModelManager);
		for (int i = 0; i < inputs.Length; i++)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!Validate(inputs[i], fmsServiceData.partialErrors, dictionary))
			{
				continue;
			}
			GetDatasetWriteTicketsInputData[] inputs2 = new GetDatasetWriteTicketsInputData[1] { inputs[i] };
			GetDatasetWriteTicketsResponse datasetWriteTickets = fileManagementService.GetDatasetWriteTickets(inputs2);
			int num = datasetWriteTickets.ServiceData.sizeOfPartialErrors();
			Log("getDatasetWriteTickets  succeeded with partialErrorSize=" + num);
			for (int j = 0; j < num; j++)
			{
				fmsServiceData.addPartialError(datasetWriteTickets.ServiceData.GetPartialError(j));
			}
			if (datasetWriteTickets.CommitInfo.Length == 0)
			{
				continue;
			}
			CommitDatasetFileInfo commitDatasetFileInfo = datasetWriteTickets.CommitInfo[0];
			Log("Prepare to upload files and commit dataset " + i);
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			DatasetFileTicketInfo[] datasetFileTicketInfos = commitDatasetFileInfo.DatasetFileTicketInfos;
			int num2 = datasetFileTicketInfos.Length;
			array = new string[num2];
			array3 = new string[num2];
			for (int k = 0; k < num2; k++)
			{
				string clientId = datasetFileTicketInfos[k].DatasetFileInfo.ClientId;
				array[k] = datasetFileTicketInfos[k].Ticket;
				array3[k] = dictionary[datasetFileTicketInfos[k].DatasetFileInfo.FileName];
				if (!dictionary2.ContainsKey(clientId))
				{
					Log("   clientId=" + clientId);
					dictionary2.Add(clientId, k);
					continue;
				}
				string msg = "The input array of DatasetFileInfo has a duplicate clientId field ('" + clientId + "'). All clientIds must be unique.";
				ServiceException ex = new ServiceException(msg);
				throw ex;
			}
			try
			{
				array2 = fmsWrapper.RegisterTickets(array);
				Log("    Register Tickets succeeded");
			}
			catch (FMSException ex2)
			{
				string msg = ex2.Message;
				msg = msg + " \n Error while registering tickets with FMS for upload. It returned error code " + ex2.ErrorCode;
				ServiceException ex = new ServiceException(msg, ex2);
				throw ex;
			}
			try
			{
				array4 = fmsWrapper.UploadFilesToPlm(array2, cb, callbackContext, array3);
				for (int j = 0; j < array3.Length; j++)
				{
					Log("     + " + array3[j]);
				}
			}
			catch (FMSException ex2)
			{
				Cleanup(array2, terminateFCC: true);
				string msg = ex2.Message;
				msg = msg + " \n Error while uploading files from PLM using FMS. It returned error code " + ex2.ErrorCode;
				ServiceException ex = new ServiceException(msg, ex2);
				throw ex;
			}
			Dictionary<string, int> dictionary3 = new Dictionary<string, int>();
			ServiceData serviceData = null;
			CommitDatasetFileInfo[] commitInput = new CommitDatasetFileInfo[1] { commitDatasetFileInfo };
			serviceData = fileManagementService.CommitDatasetFiles(commitInput);
			for (int j = 0; j < serviceData.sizeOfUpdatedObjects(); j++)
			{
				fmsServiceData.addUpdateObject(serviceData.GetUpdatedObject(j).Uid);
			}
			int num3 = serviceData.sizeOfPartialErrors();
			Log("commitDatasetFiles succeeded with PartialErrorsSize=" + num3);
			int value = 0;
			for (int k = 0; k < num3; k++)
			{
				fmsServiceData.addPartialError(serviceData.GetPartialError(k));
				string clientId2 = serviceData.GetPartialError(k).ClientId;
				if (clientId2 == null)
				{
					value = dictionary2[clientId2];
				}
				else
				{
					dictionary3.Add(clientId2, value);
				}
			}
			if (dictionary3.Count > 0)
			{
				try
				{
					Log("    trying rollback");
					PerformRollback(array2, array4, dictionary3);
					Log("    completed rollback");
				}
				catch (FMSException)
				{
					num3 = serviceData.sizeOfPartialErrors();
					foreach (KeyValuePair<string, int> item in dictionary3)
					{
						string clientId2 = item.Key;
						for (int k = 0; k < num3; k++)
						{
							ErrorStack partialError = serviceData.GetPartialError(k);
							if (partialError.ClientId.Equals(clientId2))
							{
								fmsServiceData.addPartialError(partialError);
							}
						}
					}
				}
			}
			Cleanup(array2, terminateFCC: false);
		}
		Cleanup(array2, terminateFCC: false);
		Log("End: PutFiles");
		return fmsServiceData;
	}

	public ErrorStack PutFileViaTicket(string writeTicket, FileInfo localFile)
	{
		try
		{
			return DoPutFileViaTicket(writeTicket, localFile, null, null);
		}
		catch (ServiceException ex)
		{
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(ex.Message, ex));
			return PutFileViaTicket(writeTicket, localFile);
		}
	}

	public ErrorStack PutFileViaTicket(string writeTicket, FileInfo localFile, FMS_Progress_Callback cb, object callbackContext)
	{
		return DoPutFileViaTicket(writeTicket, localFile, cb, callbackContext);
	}

	private ErrorStack DoPutFileViaTicket(string writeTicket, FileInfo localFile, FMS_Progress_Callback cb, object callbackContext)
	{
		Log("DoPutFileViaTicket : Start");
		if (string.IsNullOrEmpty(writeTicket))
		{
			throw new ArgumentException("writeTicket");
		}
		if (localFile == null)
		{
			throw new ArgumentNullException("localFile");
		}
		ErrorStack result = null;
		if (!localFile.Exists)
		{
			string message = "The file does not exist: " + localFile.FullName;
			return new FmsErrorStackImpl(message, string.Empty);
		}
		string[] tickets = new string[1] { writeTicket };
		string[] array = null;
		try
		{
			array = fmsWrapper.RegisterTickets(tickets);
			Log("    Register Tickets succeeded");
		}
		catch (FMSException ex)
		{
			string message = ex.Message;
			message = message + " \n Error while registering tickets with FMS for upload. It returned error code " + ex.ErrorCode;
			ServiceException ex2 = new ServiceException(message, ex);
			throw ex2;
		}
		string[] filePaths = new string[1] { localFile.FullName };
		try
		{
			fmsWrapper.UploadFilesToPlm(array, cb, callbackContext, filePaths);
			Log("    uploadFileToPlm succeeded");
		}
		catch (FMSException ex)
		{
			Cleanup(array, terminateFCC: true);
			string message = ex.Message;
			message = message + " \n Error while uploading file to PLM using FMS. It returned error code " + ex.ErrorCode;
			ServiceException ex2 = new ServiceException(message, ex);
			throw ex2;
		}
		Cleanup(array, terminateFCC: false);
		Log("End: DoPutFileViaTicket");
		return result;
	}

	public FileInfo GetTransientFile(string fmsTicket, string destinationFilePath)
	{
		return DoGetTransientFile(fmsTicket, destinationFilePath, null, null);
	}

	public FileInfo GetTransientFile(string fmsTicket, string destinationFilePath, FMS_Progress_Callback cb, object callbackContext)
	{
		return DoGetTransientFile(fmsTicket, destinationFilePath, cb, callbackContext);
	}

	protected FileInfo DoGetTransientFile(string fmsTicket, string destinationFilePath, FMS_Progress_Callback cb, object callbackContext)
	{
		Log("DoGetTransientFile : Start");
		FileInfo fileInfo = null;
		string uID = null;
		string[] array = new string[1];
		try
		{
			uID = (array[0] = fmsWrapper.RegisterTicket(fmsTicket));
			Log("Register Ticket succeeded");
		}
		catch (FMSException ex)
		{
			string message = ex.Message;
			message = message + " \n Error while registering ticket with FMS for download. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			fileInfo = GetTransientFile(fmsTicket, destinationFilePath, cb, callbackContext);
		}
		try
		{
			fileInfo = fmsWrapper.DownLoadTransientFile("IMD", cb, callbackContext, uID, destinationFilePath);
		}
		catch (FMSException ex)
		{
			Cleanup(array, terminateFCC: true);
			string message = ex.Message;
			message = message + " \n Error while Downloading Transient file using FMS. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			fileInfo = GetTransientFile(fmsTicket, destinationFilePath, cb, callbackContext);
		}
		Cleanup(array, terminateFCC: false);
		return fileInfo;
	}

	private void PerformRollback(string[] uids, string[] volumeIds, Dictionary<string, int> matchedIndexes)
	{
		int count = matchedIndexes.Count;
		if (count == 0)
		{
			return;
		}
		string[] array = new string[count];
		string[] array2 = new string[count];
		int num = 0;
		foreach (KeyValuePair<string, int> matchedIndex in matchedIndexes)
		{
			int value = matchedIndex.Value;
			array[num] = uids[value];
			array2[num] = volumeIds[value];
			num++;
		}
		fmsWrapper.RollBackFilesUploadedToPLM(array, volumeIds);
	}

	private void Cleanup(string[] uids, bool terminateFCC)
	{
		try
		{
			fmsWrapper.UnRegisterTickets(uids);
		}
		catch (Exception)
		{
		}
		if (terminateFCC)
		{
			try
			{
				fmsWrapper.Term();
			}
			catch (Exception)
			{
			}
		}
	}

	private static FileInfo[] FilePathsToHandlers(string[] files)
	{
		if (files == null)
		{
			return null;
		}
		FileInfo[] array = new FileInfo[files.Length];
		for (int i = 0; i < files.Length; i++)
		{
			array[i] = new FileInfo(files[i]);
		}
		return array;
	}

	private bool Validate(GetDatasetWriteTicketsInputData input, ArrayList partialErrors, Dictionary<string, string> fileNameToPhysicalPath)
	{
		bool result = false;
		List<DatasetFileInfo> list = new List<DatasetFileInfo>(input.DatasetFileInfos.Length);
		for (int i = 0; i < input.DatasetFileInfos.Length; i++)
		{
			DatasetFileInfo datasetFileInfo = input.DatasetFileInfos[i];
			string clientId = datasetFileInfo.ClientId;
			string fileName = datasetFileInfo.FileName;
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				string message = "For clientId: " + clientId + " the dataset file " + fileName + " does not exist.\n";
				partialErrors.Add(new FmsErrorStackImpl(message, clientId));
			}
			else
			{
				string fullName = fileInfo.FullName;
				string name = fileInfo.Name;
				fileNameToPhysicalPath.Add(name, fullName);
				datasetFileInfo.FileName = name;
				list.Add(datasetFileInfo);
				result = true;
			}
		}
		input.DatasetFileInfos = list.ToArray();
		return result;
	}

	private void Log(string message)
	{
		if (debug)
		{
			Console.WriteLine(message);
		}
	}

	private string[] GetTicketsFromMap(Hashtable ticketMap)
	{
		if (ticketMap == null)
		{
			return null;
		}
		string[] array = new string[ticketMap.Count];
		int num = 0;
		foreach (DictionaryEntry item in ticketMap)
		{
			array[num++] = (string)item.Value;
		}
		return array;
	}
}
