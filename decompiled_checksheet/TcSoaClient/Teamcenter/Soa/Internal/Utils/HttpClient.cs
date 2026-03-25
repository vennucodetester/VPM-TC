using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using Teamcenter.Soa.Internal.Client;

namespace Teamcenter.Soa.Internal.Utils;

internal class HttpClient
{
	private static string HEADER_ACCEPT_ENCODING = "Accept-Encoding";

	private static string HEADER_ENCODING_GZIP = "gzip";

	private static string HEADER_LOG_CORRELATION = "Log-Correlation-ID";

	private CookieContainer cookieJar = new CookieContainer();

	private CookieCollection cookies;

	private HttpWebResponse httpWResponse;

	private HttpWebRequest httpWRequest;

	private string contentType = "application/x-www-form-urlencoded;charset=UTF-8";

	private HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

	private string serverHeader = "";

	private HttpConfiguration config;

	public HttpConfiguration Configuration => config;

	public string ResponseContentType => contentType;

	public string ResponseServerHeader => serverHeader;

	public HttpStatusCode ResponseStatusCode => statusCode;

	public CookieCollection Cookies => cookies;

	public HttpClient(CookieCollection cookies)
	{
		config = new HttpConfiguration();
		if (cookies == null)
		{
			cookies = new CookieCollection();
		}
		else
		{
			this.cookies = cookies;
		}
		int count = cookies.Count;
	}

	public HttpClient(HttpConfiguration httpConfiguration)
	{
		config = httpConfiguration;
	}

	public string MakeWebRequest(Uri URL, string method, byte[] postData)
	{
		string result = "";
		try
		{
			httpWRequest = (HttpWebRequest)WebRequest.Create(URL);
			httpWRequest.CookieContainer = cookieJar;
			if (cookies != null && cookies.Count > 0)
			{
				httpWRequest.CookieContainer.Add(cookies);
			}
			httpWRequest.Method = method;
			httpWRequest.ContentType = config.CONTENT_TYPE;
			httpWRequest.UserAgent = config.USER_AGENT;
			httpWRequest.KeepAlive = config.KEEP_ALIVE;
			if (config.ProxySet())
			{
				httpWRequest.Proxy = config.GetProxy();
			}
			if (!config.CACHING)
			{
				httpWRequest.Headers.Set("Pragma", "no-cache");
			}
			httpWRequest.Timeout = config.TIMEOUT;
			httpWRequest.ReadWriteTimeout = config.READWRITE_TIMEOUT;
			if (config.USE_COMPRESSION)
			{
				httpWRequest.Headers.Add(HEADER_ACCEPT_ENCODING, HEADER_ENCODING_GZIP);
			}
			try
			{
				if (httpWRequest.Headers.Get(HEADER_LOG_CORRELATION) == null)
				{
					httpWRequest.Headers.Add(HEADER_LOG_CORRELATION, config.LOG_CORRELATIONID);
				}
				else
				{
					httpWRequest.Headers.Set(HEADER_LOG_CORRELATION, config.LOG_CORRELATIONID);
				}
			}
			catch (ArgumentNullException ex)
			{
				throw new ArgumentException(ex.Message);
			}
			catch (ArgumentOutOfRangeException ex2)
			{
				throw new ArgumentOutOfRangeException(ex2.Message);
			}
			httpWRequest.ContentLength = postData.Length;
			Stream requestStream = httpWRequest.GetRequestStream();
			requestStream.Write(postData, 0, postData.Length);
			requestStream.Close();
			if (null != httpWResponse)
			{
				httpWResponse.Close();
				httpWResponse = null;
			}
			httpWResponse = (HttpWebResponse)httpWRequest.GetResponse();
			string contentEncoding = httpWResponse.ContentEncoding;
			result = ((!contentEncoding.Equals(HEADER_ENCODING_GZIP)) ? GetResponseBody(httpWResponse.GetResponseStream()) : GetZippedResponseBody(httpWResponse.GetResponseStream()));
			contentType = httpWResponse.ContentType;
			serverHeader = httpWResponse.Server;
			statusCode = httpWResponse.StatusCode;
			cookies.Add(httpWResponse.Cookies);
			httpWResponse.Close();
		}
		catch (WebException ex3)
		{
			httpWResponse = ex3.Response as HttpWebResponse;
			if (ex3.Response == null)
			{
				throw ex3;
			}
			httpWResponse = (HttpWebResponse)ex3.Response;
			cookies.Add(httpWResponse.Cookies);
			contentType = httpWResponse.ContentType;
			serverHeader = httpWResponse.Server;
			statusCode = httpWResponse.StatusCode;
			string contentEncoding = httpWResponse.ContentEncoding;
			result = ((!contentEncoding.Equals(HEADER_ENCODING_GZIP)) ? GetResponseBody(httpWResponse.GetResponseStream()) : GetZippedResponseBody(httpWResponse.GetResponseStream()));
		}
		finally
		{
			if (httpWResponse != null)
			{
				httpWResponse.Close();
			}
		}
		return result;
	}

	private static Cookie CreateCookie(string cookieString, Uri requestURL)
	{
		Cookie cookie = new Cookie();
		bool flag = false;
		char[] separator = new char[1] { ';' };
		string[] array = cookieString.Split(separator);
		int num = 0;
		while (num < array.Length)
		{
			char[] separator2 = new char[1] { '=' };
			string[] array2 = array[num].Split(separator2);
			string text = array2[0].Trim();
			string text2 = array2[1].Trim();
			if (text.StartsWith("path"))
			{
				cookie.Path = text2;
				num++;
			}
			else if (text.StartsWith("domain"))
			{
				flag = true;
				cookie.Domain = text2;
				num++;
			}
			else if (text.StartsWith("secure"))
			{
				cookie.Secure = Convert.ToBoolean(text2);
				num++;
			}
			else if (text.StartsWith("expires"))
			{
				num++;
			}
			else
			{
				cookie.Name = text;
				cookie.Value = text2;
				num++;
			}
		}
		if (!flag)
		{
			cookie.Domain = requestURL.Host;
		}
		return cookie;
	}

	private string GetZippedResponseBody(Stream responseStream)
	{
		GZipStream gZipStream = null;
		try
		{
			long num = 4096L;
			byte[] array = new byte[num];
			gZipStream = new GZipStream(responseStream, CompressionMode.Decompress);
			int num2 = 0;
			for (int num3 = gZipStream.Read(array, 0, 100); num3 > 0; num3 = gZipStream.Read(array, num2, 100))
			{
				num2 += num3;
				if (num - num2 <= 100)
				{
					num = array.Length << 1;
					byte[] array2 = new byte[num];
					Array.Copy(array, array2, array.Length);
					array = array2;
				}
			}
			byte[] array3 = new byte[num2];
			Array.Copy(array, array3, num2);
			return Encoding.UTF8.GetString(array3);
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			gZipStream?.Close();
			responseStream?.Close();
		}
	}

	private string GetResponseBody(Stream responseStream)
	{
		StreamReader streamReader = null;
		string result = "";
		try
		{
			streamReader = new StreamReader(responseStream, Encoding.UTF8);
			result = streamReader.ReadToEnd();
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			streamReader?.Close();
			responseStream?.Close();
		}
		return result;
	}
}
