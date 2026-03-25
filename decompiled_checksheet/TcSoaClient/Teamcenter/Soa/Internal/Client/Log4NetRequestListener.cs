using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Teamcenter.Soa.Client;
using log4net;

namespace Teamcenter.Soa.Internal.Client;

public class Log4NetRequestListener : RequestListener
{
	private class RequestData
	{
		public Stopwatch startTime = new Stopwatch();

		public int sizeOut;

		public int sizeIn;
	}

	private bool details = false;

	private ILog logger = null;

	private static Dictionary<Thread, RequestData> startInfo = new Dictionary<Thread, RequestData>();

	private static string ToSizeString(int size)
	{
		string result = $"{size,9:D}bytes";
		if (size > 1024)
		{
			size /= 1024;
			result = $"{size,9:D}Kb   ";
			if (size > 1024)
			{
				size /= 1024;
				result = $"{size,9:D}Mb   ";
			}
		}
		return result;
	}

	public Log4NetRequestListener(ILog connectionLogger)
	{
		logger = connectionLogger;
		details = logger.IsDebugEnabled;
	}

	public void ServiceRequest(ServiceInfo info)
	{
		if (details)
		{
			logger.Debug(info.Id + ": " + info.Service + "." + info.Operation + "\n" + info.XmlDocument + "\n\n");
		}
		else
		{
			RequestData requestData = new RequestData();
			requestData.startTime.Start();
			requestData.sizeOut = info.XmlDocument.Length;
			startInfo[Thread.CurrentThread] = requestData;
		}
	}

	public void ServiceResponse(ServiceInfo info)
	{
		if (details)
		{
			logger.Debug(info.Id + "\n" + info.XmlDocument + "\n\n");
			return;
		}
		RequestData requestData = startInfo[Thread.CurrentThread];
		requestData.sizeIn = info.XmlDocument.Length;
		requestData.startTime.Stop();
		long elapsedMilliseconds = requestData.startTime.ElapsedMilliseconds;
		logger.Info(info.Id + ": " + string.Format("{0,-65:s}", info.Service + "." + info.Operation) + "(Time: " + $"{elapsedMilliseconds,9:D}ms" + ", Request: " + ToSizeString(requestData.sizeOut) + ", Response: " + ToSizeString(requestData.sizeIn) + ")");
	}
}
