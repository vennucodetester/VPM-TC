using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using log4net;

namespace Teamcenter.Soa.Internal.Client;

[Serializable]
public class ClientManager
{
	public class ClientInfo
	{
		public string mHostName = "";

		public string mAppName = "";

		public int mPid = 0;

		public string mIpAddress = "";

		public string mClientId = "";

		public int mCount = 0;

		public ClientInfo()
		{
			mAppName = Process.GetCurrentProcess().ProcessName;
			mAppName = mAppName.Replace('.', '_');
			mPid = Process.GetCurrentProcess().Id;
			mHostName = GetHostName();
			mIpAddress = GetIpAddress();
		}

		public ClientInfo(ClientInfo that)
		{
			if (that == null)
			{
				that = new ClientInfo();
			}
			if (sMyInfo == null)
			{
				sMyInfo = that;
			}
			mHostName = that.mHostName;
			mAppName = that.mAppName;
			mPid = that.mPid;
			mIpAddress = that.mIpAddress;
		}
	}

	private static int sConnectionCount = 0;

	private static readonly string sActiveClientsFileName = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Teamcenter\\SOA\\activeClients.properties";

	private static readonly ILog sLogger = LogManager.GetLogger(typeof(ClientManager));

	private static ClientInfo sMyInfo = null;

	private FileStream mFileStream = null;

	private Dictionary<string, string> mActiveClients = new Dictionary<string, string>();

	private Dictionary<int, int> mPids = null;

	private bool mSafeToWrite = true;

	public static ClientInfo ReserveClientId()
	{
		ClientManager clientManager = new ClientManager();
		return clientManager.ReserveThisClientId();
	}

	public static void RegisterClient(string clientId)
	{
		ClientManager clientManager = new ClientManager();
		clientManager.RegisterThisClient(clientId);
	}

	public static void UnregisterClient(string clientId)
	{
		ClientManager clientManager = new ClientManager();
		clientManager.UnregisterThisClient(clientId);
	}

	public static void ClearClientList()
	{
		ClientManager clientManager = new ClientManager();
		clientManager.WriteActiveClients();
	}

	public static Dictionary<string, string> GetActiveClients()
	{
		ClientManager clientManager = new ClientManager();
		return clientManager.ReadActiveClients(releaseLock: true);
	}

	public static ClientInfo GetClientInfo()
	{
		if (sMyInfo == null)
		{
			sMyInfo = new ClientInfo();
		}
		return sMyInfo;
	}

	private ClientManager()
	{
	}

	private ClientInfo ReserveThisClientId()
	{
		ReadActiveClients(releaseLock: false);
		ClientInfo clientInfo = new ClientInfo(sMyInfo);
		string text = clientInfo.mPid.ToString("00000");
		clientInfo.mCount = ++sConnectionCount;
		string text2 = clientInfo.mCount.ToString("00");
		clientInfo.mClientId = clientInfo.mHostName + "." + text + "." + text2;
		if (mActiveClients.Count > 0)
		{
			CollectAllPIDs();
			foreach (KeyValuePair<string, string> mActiveClient in mActiveClients)
			{
				string[] array = mActiveClient.Key.Split('.');
				string text3 = array[0];
				string text4 = array[1];
				int key = int.Parse(array[2]);
				if (text3.Equals(clientInfo.mAppName) && text4.Equals(clientInfo.mHostName) && !mPids.ContainsKey(key))
				{
					sLogger.Warn("Using abandoned clinetID " + mActiveClient.Key + ":" + mActiveClient.Value);
					clientInfo.mClientId = mActiveClient.Value;
					mActiveClients.Remove(mActiveClient.Key);
					break;
				}
			}
		}
		sLogger.Debug("Reserving " + clientInfo.mClientId);
		WriteActiveClients();
		return clientInfo;
	}

	private void RegisterThisClient(string clientId)
	{
		ReadActiveClients(releaseLock: false);
		ClientInfo clientInfo = new ClientInfo(sMyInfo);
		string text = clientInfo.mPid.ToString("00000");
		string[] array = clientId.Split('.');
		string text2 = array[1];
		string text3 = clientInfo.mAppName + "." + clientId;
		if (text != text2)
		{
			clientInfo.mCount = ++sConnectionCount;
			string text4 = clientInfo.mCount.ToString("00");
			text3 = clientInfo.mAppName + "." + clientInfo.mHostName + "." + text + "." + text4;
		}
		sLogger.Debug("Registering " + text3 + ":" + clientId);
		mActiveClients[text3] = clientId;
		WriteActiveClients();
	}

	private void UnregisterThisClient(string clientId)
	{
		ReadActiveClients(releaseLock: false);
		string text = null;
		foreach (KeyValuePair<string, string> mActiveClient in mActiveClients)
		{
			if (clientId.Equals(mActiveClient.Value))
			{
				text = mActiveClient.Key;
				break;
			}
		}
		if (text != null)
		{
			sLogger.Debug("Unregistering " + text + ":" + clientId);
			mActiveClients.Remove(text);
		}
		WriteActiveClients();
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	private void OpenFileWithLock()
	{
		FileInfo fileInfo = new FileInfo(sActiveClientsFileName);
		if (!fileInfo.Directory.Exists)
		{
			try
			{
				Directory.CreateDirectory(fileInfo.Directory.FullName);
			}
			catch (SystemException ex)
			{
				throw new IOException(ex.Message);
			}
		}
		for (int i = 0; i < 2; i++)
		{
			try
			{
				mFileStream = new FileStream(sActiveClientsFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
				return;
			}
			catch (SystemException)
			{
				Thread.Sleep(100);
			}
		}
		throw new IOException("Failed to obtain a lock on " + sActiveClientsFileName + " after 200ms.");
	}

	private Dictionary<string, string> ReadActiveClients(bool releaseLock)
	{
		FileInfo fileInfo = new FileInfo(sActiveClientsFileName);
		if (fileInfo.Exists)
		{
			try
			{
				OpenFileWithLock();
				string text = "";
				UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
				byte[] array = new byte[4096];
				for (int num = mFileStream.Read(array, 0, 4096); num > 0; num = mFileStream.Read(array, 0, 4096))
				{
					text += unicodeEncoding.GetString(array, 0, num);
				}
				string[] array2 = text.Split('\n');
				string[] array3 = array2;
				foreach (string text2 in array3)
				{
					string text3 = text2.Trim();
					if (!text3.StartsWith("#") && text3.Contains("="))
					{
						string[] array4 = text3.Split('=');
						mActiveClients[array4[0]] = array4[1];
					}
				}
			}
			catch (IOException ex)
			{
				sLogger.Warn("Failed to read the Active Clients file (" + sActiveClientsFileName + "). Will use an empty list of active clients.\n" + ex.Message);
				mSafeToWrite = false;
			}
			finally
			{
				if (releaseLock && mFileStream != null)
				{
					mFileStream.Close();
					mFileStream = null;
				}
			}
		}
		return mActiveClients;
	}

	private void WriteActiveClients()
	{
		if (!mSafeToWrite)
		{
			return;
		}
		try
		{
			if (mFileStream == null)
			{
				OpenFileWithLock();
			}
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			mFileStream.Seek(0L, SeekOrigin.Begin);
			foreach (KeyValuePair<string, string> mActiveClient in mActiveClients)
			{
				string s = mActiveClient.Key + "=" + mActiveClient.Value + "\n";
				byte[] bytes = aSCIIEncoding.GetBytes(s);
				mFileStream.Write(bytes, 0, bytes.Length);
			}
			mFileStream.SetLength(mFileStream.Position);
		}
		catch (IOException ex)
		{
			sLogger.Warn("Failed to write the Active Clients file (" + sActiveClientsFileName + ").\n" + ex.Message);
		}
		finally
		{
			if (mFileStream != null)
			{
				mFileStream.Close();
				mFileStream = null;
			}
			if (mActiveClients.Count == 0)
			{
				try
				{
					File.Delete(sActiveClientsFileName);
				}
				catch (IOException)
				{
					sLogger.Warn("Left empty file (" + sActiveClientsFileName + "). ");
				}
			}
		}
	}

	private void CollectAllPIDs()
	{
		mPids = new Dictionary<int, int>();
		Process[] processes = Process.GetProcesses();
		Process[] array = processes;
		foreach (Process process in array)
		{
			mPids[process.Id] = process.Id;
		}
	}

	private static string GetHostName()
	{
		string text = Dns.GetHostEntry(Dns.GetHostName()).HostName;
		int num = text.IndexOf('.');
		if (num != -1)
		{
			text = text.Substring(0, num);
		}
		return text;
	}

	private static string GetIpAddress()
	{
		string result = "127.0.0.1";
		string text = "";
		string text2 = "";
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		IPAddress[] array = addressList;
		foreach (IPAddress iPAddress in array)
		{
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				byte[] addressBytes = iPAddress.GetAddressBytes();
				bool flag = ((addressBytes[0] == 10 || (addressBytes[0] == 172 && addressBytes[1] == 16) || (addressBytes[0] == 192 && addressBytes[1] == 168)) ? true : false);
				bool flag2 = addressBytes[0] == 127;
				if (!flag2 && !flag)
				{
					text2 = iPAddress.ToString();
				}
				else if (!flag2)
				{
					text = iPAddress.ToString();
				}
			}
			else if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
			{
				byte[] addressBytes = iPAddress.GetAddressBytes();
				bool flag = (((addressBytes[0] & 0xFF) == 254 && (addressBytes[1] & 0xC0) == 192) ? true : false);
				bool flag2 = (iPAddress.ToString().Equals("::1") ? true : false);
				if (!flag2 && !flag)
				{
					text2 = iPAddress.ToString();
				}
				else if (!flag2)
				{
					text = iPAddress.ToString();
				}
			}
		}
		if (text2.Length > 0)
		{
			result = text2;
		}
		else if (text.Length > 0)
		{
			result = text;
		}
		return result;
	}
}
