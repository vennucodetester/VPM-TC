using System.Runtime.CompilerServices;
using Teamcenter.Net.TcServerProxy.Crypto;

namespace Teamcenter.Soa.Client;

public class PKCS7
{
	private static Teamcenter.Net.TcServerProxy.Crypto.PKCS7 pkcs7 = null;

	private PKCS7()
	{
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	private static Teamcenter.Net.TcServerProxy.Crypto.PKCS7 getInstance()
	{
		if (pkcs7 == null)
		{
			pkcs7 = new Teamcenter.Net.TcServerProxy.Crypto.PKCS7();
		}
		return pkcs7;
	}

	public static string sign(string message)
	{
		return getInstance().sign(message);
	}

	public static object[] sign(string[] messages)
	{
		return getInstance().sign(messages);
	}

	public static string sign(byte[] message)
	{
		return getInstance().sign(message);
	}

	public static object[] sign(byte[][] messages)
	{
		return getInstance().sign(messages);
	}
}
