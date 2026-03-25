using System;
using System.IO;
using System.Reflection;

namespace Teamcenter.Soa.Internal.Client;

public class FMSLoader
{
	private static Assembly fccwrapperAssm = null;

	public static FMSWrapper GetFCCInstance()
	{
		FMSWrapper result = null;
		if ((object)fccwrapperAssm == null)
		{
			string environmentVariable = Environment.GetEnvironmentVariable("Path");
			string environmentVariable2 = Environment.GetEnvironmentVariable("FMS_HOME");
			if (environmentVariable2 != null)
			{
				string text = ((!environmentVariable2.EndsWith("\\")) ? (environmentVariable2 + Path.DirectorySeparatorChar + "lib") : (environmentVariable2 + "lib"));
				if (!environmentVariable.Contains(text))
				{
					string value = environmentVariable + ";" + text;
					Environment.SetEnvironmentVariable("Path", value);
				}
			}
			fccwrapperAssm = LoadInternalAssembly();
		}
		if ((object)fccwrapperAssm != null)
		{
			object obj = fccwrapperAssm.CreateInstance("Teamcenter.Soa.Internal.Client.FCCWrapper");
			result = obj as FMSWrapper;
		}
		return result;
	}

	private static bool Is64BitProcess()
	{
		if (IntPtr.Size == 8)
		{
			return true;
		}
		return false;
	}

	private static Assembly LoadInternalAssembly()
	{
		Assembly assembly = null;
		try
		{
			AssemblyName assemblyName = new AssemblyName();
			if (Is64BitProcess())
			{
				assemblyName.Name = "TcSoaFMS64";
				return Assembly.Load(assemblyName);
			}
			assemblyName.Name = "TcSoaFMS";
			return Assembly.Load(assemblyName);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public static FMSWrapper GetFSCInstance(string clientIPAddress, string[] assignedFSCURIs, string[] bootstrapFSCURIs, string cacheDir)
	{
		FMSWrapper result = null;
		if ((object)fccwrapperAssm == null)
		{
			fccwrapperAssm = LoadInternalAssembly();
		}
		if ((object)fccwrapperAssm != null)
		{
			object[] args = new object[4] { clientIPAddress, assignedFSCURIs, bootstrapFSCURIs, cacheDir };
			object obj = fccwrapperAssm.CreateInstance("Teamcenter.Soa.Internal.Client.FSCWrapper", ignoreCase: true, BindingFlags.Default, null, args, null, null);
			result = obj as FMSWrapper;
		}
		return result;
	}
}
