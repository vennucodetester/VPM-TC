using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using RevisionManager;
using SolidEdgeFileProperties;

namespace Rapid_Check;

[StandardModule]
internal sealed class SolidEdgeFunctions
{
	public static bool GetSolidEdgeRevisionMgrSession(ref RevisionManager.Application objSEApp)
	{
		bool flag = false;
		try
		{
			objSEApp = new ApplicationClass();
			objSEApp.DisplayAlerts = 0;
			flag = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			flag = false;
			MessageBox.Show("Unable to Start or Connect SolidEdge Revision Manager (" + ex2.Message + ")", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return flag;
	}

	public static void CloseSolidEdgeRevisionMgrSession(ref RevisionManager.Application objSEApp)
	{
		try
		{
			if (objSEApp != null)
			{
				objSEApp.Quit();
				Marshal.ReleaseComObject(objSEApp);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		objSEApp = null;
	}

	public static bool ConnectSE(ref SolidEdgeFileProperties.PropertySets objSEptyset)
	{
		bool result;
		try
		{
			objSEptyset = new SolidEdgeFileProperties.PropertySetsClass();
			result = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void CloseSE(ref SolidEdgeFileProperties.PropertySets objSEptyset)
	{
		try
		{
			objSEptyset.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		objSEptyset = null;
	}

	public static string GetSEFileProperty(SolidEdgeFileProperties.PropertySets objSEptyset, string strProSet, string strProName)
	{
		string result = "";
		try
		{
			SolidEdgeFileProperties.Properties properties = (SolidEdgeFileProperties.Properties)objSEptyset[strProSet];
			if (properties != null)
			{
				SolidEdgeFileProperties.Property property = (SolidEdgeFileProperties.Property)properties[strProName];
				result = Conversions.ToString(property.Value);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string GetSEChildFilenames(string strFileName, ref string withOutExt)
	{
		RevisionManager.Application objSEApp = null;
		string text = string.Empty;
		if (GetSolidEdgeRevisionMgrSession(ref objSEApp))
		{
			Document document = null;
			System.Windows.Forms.Application.DoEvents();
			try
			{
				document = (Document)objSEApp.Open(strFileName, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				if (document != null)
				{
					int num = Conversions.ToInteger(NewLateBinding.LateGet(((IDocAuto)document).get_LinkedDocuments(RuntimeHelpers.GetObjectValue(Missing.Value)), null, "Count", new object[0], null, null, null));
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						string empty = string.Empty;
						object[] array;
						bool[] array2;
						object instance = NewLateBinding.LateGet(((IDocAuto)document).get_LinkedDocuments(RuntimeHelpers.GetObjectValue(Missing.Value)), null, "item", array = new object[1] { i }, null, null, array2 = new bool[1] { true });
						if (array2[0])
						{
							i = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
						}
						empty = Conversions.ToString(NewLateBinding.LateGet(instance, null, "FullName", new object[0], null, null, null));
						withOutExt = withOutExt + "| " + Path.GetFileNameWithoutExtension(empty);
						text = text + "| " + Path.GetFileName(empty);
					}
				}
				if (Operators.CompareString(withOutExt, "", TextCompare: false) != 0)
				{
					withOutExt = withOutExt.Substring(2);
					text = text.Substring(2);
				}
				NewLateBinding.LateCall(document, null, "close", new object[0], null, null, null, IgnoreReturn: true);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
		CloseSolidEdgeRevisionMgrSession(ref objSEApp);
		GC.Collect();
		return text;
	}
}
