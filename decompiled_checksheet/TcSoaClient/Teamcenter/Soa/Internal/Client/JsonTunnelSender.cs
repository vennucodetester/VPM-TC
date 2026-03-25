using System;
using System.Runtime.CompilerServices;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Common.Utils;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
public class JsonTunnelSender : Sender
{
	private static string JSONREST_SERVICES = "JsonRestServices";

	private int SOA_FRAMEWORK_server_reassignment = 214016;

	private string conId = SessionManager.connectionCount.ToString("00");

	private int reqId = 0;

	protected Connection connection;

	protected SessionManager sessionManager;

	protected Transport m_transport;

	protected NotifyRequestListeners m_notifier;

	public Transport TheTransport => m_transport;

	public JsonTunnelSender(Connection connection, SessionManager sm, Transport transport, NotifyRequestListeners notifier)
	{
		this.connection = connection;
		sessionManager = sm;
		m_transport = transport;
		m_notifier = notifier;
	}

	public Transport getTransport()
	{
		return m_transport;
	}

	public object Invoke(string service, string operation, object requestObject, Type type, Type[] extraTypes)
	{
		string text = requestObject as string;
		if (text == null && requestObject != null)
		{
			text = requestObject.ToString();
		}
		try
		{
			ServiceInfo requestInfo = new ServiceInfo(LogCorrelation.GetId(), service, operation, text);
			if (m_notifier != null)
			{
				m_notifier.NotifyRequestListeners(requestInfo);
			}
			byte[] requestBytes = XmlBindingUtils.StringToUTF8ByteArray(text);
			string text2 = m_transport.ExecuteRequest(service, operation, requestBytes, JSONREST_SERVICES);
			ServiceInfo responseInfo = new ServiceInfo(LogCorrelation.GetId(), service, operation, text2);
			if (m_notifier != null)
			{
				m_notifier.NotifyResponseListeners(responseInfo);
			}
			return text2;
		}
		catch (InternalServerException ex)
		{
			if (ex.Error.Code == SOA_FRAMEWORK_server_reassignment)
			{
				try
				{
					LogCorrelation.Push("ReEstablishServerAffinity");
					sessionManager.ResetServer();
				}
				catch (InternalServerException ise)
				{
					connection.ExceptionHandler.HandleException(ise);
				}
				finally
				{
					LogCorrelation.Pop();
				}
				if (connection.GetOption(Connection.OPT_SERVER_REASSIGNMENT) == "true")
				{
					try
					{
						LogCorrelation.Push("HandleServerReAssingment");
						connection.ExceptionHandler.HandleException(ex);
					}
					finally
					{
						LogCorrelation.Pop();
					}
				}
			}
			else
			{
				try
				{
					LogCorrelation.Push("HandleInternalServerException");
					connection.ExceptionHandler.HandleException(ex);
				}
				finally
				{
					LogCorrelation.Pop();
				}
			}
		}
		return RetryInvoke(service, operation, requestObject, type, extraTypes);
	}

	private object RetryInvoke(string service, string operation, object requestObject, Type type, Type[] extraTypes)
	{
		try
		{
			PushRequestId();
			return Invoke(service, operation, requestObject, type, extraTypes);
		}
		finally
		{
			PopRequestId();
		}
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public void PushRequestId()
	{
		LogCorrelation.Push(conId);
		LogCorrelation.Push(sessionManager.GetUserID());
		LogCorrelation.Push((++reqId).ToString("00000"));
	}

	public void PopRequestId()
	{
		LogCorrelation.Pop();
		LogCorrelation.Pop();
		LogCorrelation.Pop();
	}
}
