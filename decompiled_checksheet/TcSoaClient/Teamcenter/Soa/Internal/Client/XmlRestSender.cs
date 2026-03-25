using System;
using System.Runtime.CompilerServices;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Common.Utils;
using Teamcenter.Soa.Exceptions;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
public class XmlRestSender : Sender
{
	private static XmlBindingUtils xmlBindingUtils = new XmlBindingUtils();

	private int SOA_FRAMEWORK_server_reassignment = 214016;

	private string conId = SessionManager.connectionCount.ToString("00");

	private int reqId = 0;

	protected Connection connection;

	protected SessionManager sessionManager;

	protected Transport m_transport;

	protected NotifyRequestListeners m_notifier;

	public Transport TheTransport => m_transport;

	public XmlRestSender(Connection connection, SessionManager sessionManager, Transport transport, NotifyRequestListeners notifier)
	{
		this.connection = connection;
		this.sessionManager = sessionManager;
		m_transport = transport;
		m_notifier = notifier;
	}

	public Transport getTransport()
	{
		return m_transport;
	}

	public object Invoke(string service, string operation, object requestObject, Type type, Type[] extraTypes)
	{
		try
		{
			sessionManager.ValidateUser(service, operation, requestObject);
		}
		catch (InvalidCredentialsException result)
		{
			return result;
		}
		try
		{
			sessionManager.PolicyManager.SendPendingUpdate();
			requestObject = sessionManager.ModifyInput(service, operation, requestObject);
			string text;
			string xmlString;
			lock (this)
			{
				sessionManager.SetState(SessionManager.STATE_LOGCORRELATION_ID, LogCorrelation.GetId());
				byte[] chars = xmlBindingUtils.Serialize(requestObject);
				text = XmlBindingUtils.UTF8ByteArrayToString(chars);
				xmlString = sessionManager.ConstructRequestEnvelope(text);
			}
			string operation2 = ((!operation[0].Equals('I')) ? (new string(operation[0], 1).ToLower() + operation.Substring(1)) : (new string('i', 1) + operation.Substring(1)));
			ServiceInfo requestInfo = new ServiceInfo(LogCorrelation.GetId(), service, operation2, text);
			if (m_notifier != null)
			{
				m_notifier.NotifyRequestListeners(requestInfo);
			}
			byte[] requestBytes = XmlBindingUtils.StringToUTF8ByteArray(xmlString);
			string text2 = m_transport.ExecuteRequest(service, operation2, requestBytes, SoaConstants.REST_SERVICES);
			ServiceInfo responseInfo = new ServiceInfo(LogCorrelation.GetId(), service, operation2, text2);
			if (m_notifier != null)
			{
				m_notifier.NotifyResponseListeners(responseInfo);
			}
			if (ExceptionMapper.IsException(text2))
			{
				ExceptionMapper exceptionMapper = new ExceptionMapper();
				try
				{
					exceptionMapper.ParseExceptionString(text2);
				}
				catch (InvalidCredentialsException result2)
				{
					return result2;
				}
				catch (ServiceException result3)
				{
					return result3;
				}
			}
			object obj = xmlBindingUtils.Deserialize(text2, type, extraTypes);
			sessionManager.CacheStateInformation(service, operation, requestObject, obj);
			return obj;
		}
		catch (InvalidUserException exception)
		{
			try
			{
				LogCorrelation.Push("ReAuthenticate");
				sessionManager.Login(exception);
			}
			catch (CanceledOperationException coe)
			{
				try
				{
					LogCorrelation.Push("HandleCanceledOperation");
					connection.ExceptionHandler.HandleException(coe);
				}
				finally
				{
					LogCorrelation.Pop();
				}
			}
			finally
			{
				LogCorrelation.Pop();
			}
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
