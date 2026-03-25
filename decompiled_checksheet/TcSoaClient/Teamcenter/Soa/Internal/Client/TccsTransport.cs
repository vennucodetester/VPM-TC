using System;
using System.Globalization;
using System.IO;
using Teamcenter.Net.TcServerProxy.Client;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
internal class TccsTransport : Transport
{
	protected Connection connection;

	protected SessionManager sessionManager;

	public TccsTransport(Connection conn, SessionManager sessionMgr)
	{
		connection = conn;
		sessionManager = sessionMgr;
		try
		{
			TcServerRequestWrapper.Init();
		}
		catch (TSPException ex)
		{
			string message = ex.Message;
			throw new ConnectionException(message);
		}
	}

	~TccsTransport()
	{
		connection = null;
		sessionManager = null;
	}

	public string ExecuteRequest(string service, string operation, byte[] requestBytes, string servletURI)
	{
		string text = "";
		TcServerRequestWrapper tcServerRequestWrapper = null;
		tcServerRequestWrapper = new TcServerRequestWrapper(connection.GetTSPSession());
		string option = connection.GetOption(Connection.TCCS_HOST_URL);
		if (option != null && !option.Equals(""))
		{
			tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_SERVER_URL, option);
		}
		else
		{
			tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_ENV_NAME, connection.GetOption(Connection.TCCS_ENV_NAME));
		}
		tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_USE_COMPRESSION, connection.GetOption(Connection.OPT_USE_COMPRESSION));
		tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_LOG_CORRELATION, LogCorrelation.GetId());
		tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_USE_CALLBACK, connection.GetOption(Connection.TCCS_USE_CALLBACK));
		tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_SERVICENAME, service);
		tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_OPERATIONNAME, operation);
		string option2 = connection.GetOption(Connection.TCCS_SESSION_ID);
		if (option2 != null && option2 != "")
		{
			tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_SESSIONID, option2);
		}
		string text2 = sessionManager.GetStringState(SessionManager.STATE_LOCALE);
		if (text2 == null || text2.Length == 0 || text2 == "null" || text2 == "")
		{
			text2 = CultureInfo.CurrentCulture.Name;
		}
		text2 = text2.Replace('-', '_');
		tcServerRequestWrapper.SetHeader(TcServerRequestWrapper.HEADER_LOCALE, text2);
		try
		{
			Stream body = new MemoryStream(requestBytes);
			tcServerRequestWrapper.SetCredentialProvider(connection.GetProxyCredentialProvider());
			tcServerRequestWrapper.SetBody(body);
			return tcServerRequestWrapper.Execute();
		}
		catch (TSPException ex)
		{
			if (ex is TSPConnectionException)
			{
				string message = ex.Message;
				throw new ConnectionException(message);
			}
			throw new ProtocolException(ex.Message);
		}
	}
}
