using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Teamcenter.Soa.Internal.Client;

public class LogCorrelation
{
	private static Hashtable logs = new Hashtable();

	private Stack<string> stack = new Stack<string>();

	private static int processId = new Random().Next(9000);

	private LogCorrelation()
	{
		string item;
		try
		{
			item = Dns.GetHostName();
		}
		catch (SocketException)
		{
			item = "localhost";
		}
		int num = processId + Thread.CurrentThread.GetHashCode();
		stack.Push(item);
		stack.Push(num.ToString("00000"));
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	private static LogCorrelation GetCurrent()
	{
		Thread currentThread = Thread.CurrentThread;
		LogCorrelation logCorrelation = (LogCorrelation)logs[currentThread];
		if (logCorrelation == null)
		{
			logCorrelation = new LogCorrelation();
			logs[currentThread] = logCorrelation;
		}
		return logCorrelation;
	}

	public static void Push(string id)
	{
		LogCorrelation current = GetCurrent();
		current.stack.Push(id);
	}

	public static string Pop()
	{
		LogCorrelation current = GetCurrent();
		if (current.stack.Count > 0)
		{
			return current.stack.Pop();
		}
		return "";
	}

	public static string GetId()
	{
		string text = "";
		LogCorrelation current = GetCurrent();
		string[] array = current.stack.ToArray();
		for (int num = array.Length - 1; num >= 0; num--)
		{
			if (text.Length > 0)
			{
				text += ".";
			}
			text += array[num];
		}
		return text;
	}
}
