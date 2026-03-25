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

namespace Teamcenter.Soa.Client;

public class FSCStreamingUtility
{
	private class FmsServiceData : ServiceData
	{
		private ArrayList updatedIds = new ArrayList();

		private ArrayList partialErrors = new ArrayList();

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

	private class ValidationResult
	{
		public Dictionary<string, string> fileNameToPhysicalPath = new Dictionary<string, string>();

		public GetDatasetWriteTicketsInputData[] inputs;

		public ArrayList partialErrors = new ArrayList();
	}

	private FileManagementService fileManagementService;

	private FMSWrapper fscWrapper = null;

	private Connection connection;

	private bool debug = false;

	public FSCStreamingUtility(Connection connection, string clientIPAddress, string[] assignedFSCURIs, string[] bootstrapFSCURIs)
	{
		InitFSC(connection, clientIPAddress, assignedFSCURIs, bootstrapFSCURIs);
		Init(connection);
	}

	private void InitFSC(Connection connection, string clientIPAddress, string[] assignedFSCURIs, string[] bootstrapFSCURIs)
	{
		try
		{
			fscWrapper = FMSLoader.GetFSCInstance(clientIPAddress, assignedFSCURIs, bootstrapFSCURIs, null);
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
			fscWrapper.Term();
		}
		catch (FMSException)
		{
		}
	}

	public void Download(ModelObject[] files, Stream[] downloadStreams)
	{
		Log("Start: Download");
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
			string[] messages = getFileResponse.GetPartialError(0).Messages;
			int[] codes = getFileResponse.GetPartialError(0).Codes;
			string[] array;
			(array = messages)[0] = array[0] + " \n Error while getting file tickets for FMS download. It returned error code " + codes[0];
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(messages[0]));
			return;
		}
		string[] ticketsFromMap = GetTicketsFromMap(fileReadTickets.Tickets);
		string[] array2;
		try
		{
			array2 = fscWrapper.RegisterTickets(ticketsFromMap);
			Log("Register Tickets succeeded");
		}
		catch (FMSException ex)
		{
			string message = ex.Message;
			message = message + " \n Error while registering tickets with FMS for download. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			return;
		}
		try
		{
			for (int j = 0; j < array2.Length; j++)
			{
				fscWrapper.StreamDownload(array2[j], downloadStreams[j]);
			}
			Log(" Stream download from PLM succeeded");
		}
		catch (FMSException ex)
		{
			Cleanup(array2, terminateFCC: true);
			string message = ex.Message;
			message = message + " \n Error while Downloading files from PLM using FMS. It returned error code " + ex.ErrorCode;
			ExceptionHandler exceptionHandler = connection.ExceptionHandler;
			exceptionHandler.HandleException(new InternalServerException(message, ex));
			return;
		}
		Cleanup(array2, terminateFCC: false);
		Log("End :Download");
	}

	public ServiceData Upload(GetDatasetWriteTicketsInputData[] inputs, Stream[] uploadStreams, long[] streamLength)
	{
		Log("Start : Upload");
		string[] array = null;
		string[] array2 = null;
		FmsServiceData fmsServiceData = new FmsServiceData(connection.ModelManager);
		ValidationResult validationResult = Validate(inputs, uploadStreams);
		for (int i = 0; i < validationResult.partialErrors.Count; i++)
		{
			fmsServiceData.addPartialError((ErrorStack)validationResult.partialErrors[i]);
		}
		if (validationResult.inputs.Length == 0)
		{
			return fmsServiceData;
		}
		GetDatasetWriteTicketsResponse datasetWriteTickets = fileManagementService.GetDatasetWriteTickets(validationResult.inputs);
		int num = datasetWriteTickets.ServiceData.sizeOfPartialErrors();
		Log("getDatasetWriteTickets  succeeded with partialErrorSize=" + num);
		for (int i = 0; i < num; i++)
		{
			fmsServiceData.addPartialError(datasetWriteTickets.ServiceData.GetPartialError(i));
		}
		CommitDatasetFileInfo[] commitInfo = datasetWriteTickets.CommitInfo;
		for (int i = 0; i < commitInfo.Length; i++)
		{
			Log("Start Commiting Dataset " + i);
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			CommitDatasetFileInfo commitDatasetFileInfo = commitInfo[i];
			DatasetFileTicketInfo[] datasetFileTicketInfos = commitDatasetFileInfo.DatasetFileTicketInfos;
			int num2 = datasetFileTicketInfos.Length;
			array = new string[num2];
			string text = null;
			for (int j = 0; j < num2; j++)
			{
				array[j] = datasetFileTicketInfos[j].Ticket;
				text = datasetFileTicketInfos[j].DatasetFileInfo.ClientId;
				if (text != null)
				{
					Log("   clientId=" + text);
					dictionary.Add(text, j);
				}
			}
			try
			{
				array2 = fscWrapper.RegisterTickets(array);
				Log("    Register Tickets succeeded");
			}
			catch (FMSException ex)
			{
				string message = ex.Message;
				message = message + " \n Error while registering tickets with FMS for upload. It returned error code " + ex.ErrorCode;
				ExceptionHandler exceptionHandler = connection.ExceptionHandler;
				exceptionHandler.HandleException(new InternalServerException(ex.Message, ex));
				return Upload(inputs, uploadStreams, streamLength);
			}
			string[] array3 = new string[array2.Length];
			try
			{
				for (int k = 0; k < array2.Length; k++)
				{
					array3[k] = fscWrapper.StreamUpload(array2[k], uploadStreams[k], streamLength[k]);
				}
				Log("    StreamUpload succeeded");
			}
			catch (FMSException ex)
			{
				Cleanup(array2, terminateFCC: true);
				string message = ex.Message;
				message = message + " \n Error while uploading files from PLM using FMS. It returned error code " + ex.ErrorCode;
				ExceptionHandler exceptionHandler = connection.ExceptionHandler;
				exceptionHandler.HandleException(new InternalServerException(ex.Message, ex));
				return Upload(inputs, uploadStreams, streamLength);
			}
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
			ServiceData serviceData = null;
			CommitDatasetFileInfo[] commitInput = new CommitDatasetFileInfo[1] { commitInfo[i] };
			serviceData = fileManagementService.CommitDatasetFiles(commitInput);
			for (int l = 0; l < serviceData.sizeOfUpdatedObjects(); l++)
			{
				fmsServiceData.addUpdateObject(serviceData.GetUpdatedObject(l).Uid);
			}
			int num3 = serviceData.sizeOfPartialErrors();
			Log("commitDatasetFiles succeeded with PartialErrorsSize=" + num3);
			string text2 = null;
			int num4 = 0;
			for (int j = 0; j < num3; j++)
			{
				fmsServiceData.addPartialError(serviceData.GetPartialError(j));
				text2 = serviceData.GetPartialError(j).ClientId;
				num4 = dictionary[text2];
				if (text2 != null)
				{
					dictionary2.Add(text2, num4);
				}
			}
			if (dictionary2.Count > 0)
			{
				try
				{
					Log("    trying rollback");
					PerformRollback(array2, array3, dictionary2);
					Log("    completed rollback");
				}
				catch (FMSException)
				{
					num3 = serviceData.sizeOfPartialErrors();
					foreach (KeyValuePair<string, int> item in dictionary2)
					{
						text2 = item.Key;
						for (int j = 0; j < num3; j++)
						{
							ErrorStack partialError = serviceData.GetPartialError(j);
							if (partialError.ClientId.Equals(text2))
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
		Log("End: Upload");
		return fmsServiceData;
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
		fscWrapper.RollBackFilesUploadedToPLM(array, volumeIds);
	}

	private void Cleanup(string[] uids, bool terminateFCC)
	{
		try
		{
			fscWrapper.UnRegisterTickets(uids);
		}
		catch (Exception)
		{
		}
		if (terminateFCC)
		{
			try
			{
				fscWrapper.Term();
			}
			catch (Exception)
			{
			}
		}
	}

	private ValidationResult Validate(GetDatasetWriteTicketsInputData[] data, Stream[] uploadStreams)
	{
		ValidationResult validationResult = new ValidationResult();
		List<GetDatasetWriteTicketsInputData> list = new List<GetDatasetWriteTicketsInputData>();
		string text = "";
		for (int i = 0; i < data.Length; i++)
		{
			DatasetFileInfo[] datasetFileInfos = data[i].DatasetFileInfos;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			string text5 = null;
			FileInfo fileInfo = null;
			for (int j = 0; j < datasetFileInfos.Length; j++)
			{
				text2 = datasetFileInfos[j].FileName;
				text5 = datasetFileInfos[j].ClientId;
				fileInfo = new FileInfo(text2);
				if (uploadStreams[j] == null)
				{
					text = "For clientId: " + text5 + " the dataset file " + text3 + " does not exist.\n";
					validationResult.partialErrors.Add(new FmsErrorStackImpl(text, text5));
				}
				else
				{
					text3 = fileInfo.Name;
					text4 = fileInfo.FullName;
					validationResult.fileNameToPhysicalPath.Add(text3, text4);
					datasetFileInfos[j].FileName = text3;
					if (!list.Contains(data[i]))
					{
						list.Add(data[i]);
					}
				}
			}
		}
		validationResult.inputs = list.ToArray();
		return validationResult;
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
