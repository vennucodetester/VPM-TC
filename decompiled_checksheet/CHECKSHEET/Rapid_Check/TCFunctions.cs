using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Teamcenter.Services.Strong.Cad;
using Teamcenter.Services.Strong.Cad._2007_01.StructureManagement;
using Teamcenter.Services.Strong.Core;
using Teamcenter.Services.Strong.Core._2006_03.Session;
using Teamcenter.Services.Strong.Core._2007_06.DataManagement;
using Teamcenter.Services.Strong.Core._2007_09.DataManagement;
using Teamcenter.Services.Strong.Query;
using Teamcenter.Services.Strong.Query._2007_09.SavedQuery;
using Teamcenter.Services.Strong.Query._2008_06.SavedQuery;
using Teamcenter.Services.Strong.Query._2010_04.SavedQuery;
using Teamcenter.Soa;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;
using Teamcenter.Soa.Client.Model.Strong;
using Teamcenter.Soa.Common;

namespace Rapid_Check;

[StandardModule]
internal sealed class TCFunctions
{
	private static Teamcenter.Soa.Client.Connection objCon;

	[Obsolete]
	public static Teamcenter.Soa.Client.Connection TC_login(string Url, string username, string password)
	{
		Tc_CredentialManager tc_CredentialManager = new Tc_CredentialManager();
		string[] array = tc_CredentialManager.PromptForCredentials(username, password);
		try
		{
			objCon = new Teamcenter.Soa.Client.Connection(Url, new CookieCollection(), tc_CredentialManager, SoaConstants.REST, SoaConstants.HTTP, useCompression: false);
			objCon.ExceptionHandler = new Tc_ExceptionHandler();
			SessionService service = SessionService.getService(objCon);
			LoginResponse loginResponse = service.Login(array[0], array[1], array[2], array[3], "", array[4]);
			return objCon;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Unable to Connect or Login", "InputData", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		return null;
	}

	public static bool TC_Logout(Teamcenter.Soa.Client.Connection objCon)
	{
		bool result = false;
		try
		{
			SessionService service = SessionService.getService(objCon);
			service.Logout();
			objCon = null;
			GC.Collect();
			result = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void setObjectPolicy_ECN(Teamcenter.Soa.Client.Connection TC_Conn, string strClass)
	{
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		try
		{
			SessionService service = SessionService.getService(TC_Conn);
			objectPropertyPolicy.AddType(strClass, Declarations.HSM_ECN_POLICY_PROPETIES);
			service.SetObjectPropertyPolicy(objectPropertyPolicy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void setObjectPolicy_Item(Teamcenter.Soa.Client.Connection TC_Conn)
	{
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		try
		{
			SessionService service = SessionService.getService(TC_Conn);
			objectPropertyPolicy.AddType("H4_Hussmann_Item", Declarations.HSM_ITEM_POLICY_PROPETIES);
			service.SetObjectPropertyPolicy(objectPropertyPolicy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void setObjectPolicy_ItemRev(Teamcenter.Soa.Client.Connection TC_Conn)
	{
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		try
		{
			SessionService service = SessionService.getService(TC_Conn);
			objectPropertyPolicy.AddType("H4_Hussmann_ItemRevision", Declarations.HSM_ITEM_REV_POLICY_PROPETIES);
			service.SetObjectPropertyPolicy(objectPropertyPolicy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void setObjectPolicy_CheckSheet(Teamcenter.Soa.Client.Connection TC_Conn)
	{
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		try
		{
			SessionService service = SessionService.getService(TC_Conn);
			objectPropertyPolicy.AddType("H4_Hussmann_ItemRevision", Declarations.HSM_Check_Sheet_POLICY_PROPETIES);
			service.SetObjectPropertyPolicy(objectPropertyPolicy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void setObjectPolicy_BOM(Teamcenter.Soa.Client.Connection TC_Conn)
	{
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		try
		{
			SessionService service = SessionService.getService(TC_Conn);
			objectPropertyPolicy.AddType("BOMLine", Declarations.BOM_LINE_POLICY_PROPETIES);
			objectPropertyPolicy.AddType("RevisionRule", Declarations.REV_RULE_POLICY_PROPETIES);
			service.SetObjectPropertyPolicy(objectPropertyPolicy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void setObjectPolicy_Form(Teamcenter.Soa.Client.Connection TC_Conn, string strSecondaryObjectName)
	{
		ObjectPropertyPolicy objectPropertyPolicy = new ObjectPropertyPolicy();
		try
		{
			SessionService service = SessionService.getService(TC_Conn);
			objectPropertyPolicy.AddType(strSecondaryObjectName, Declarations.HSM_Check_Sheet_Form_PROPETIES);
			service.SetObjectPropertyPolicy(objectPropertyPolicy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private static List<ModelObject> ExecuteSavedQry(Teamcenter.Soa.Client.Connection TC_Conn, string QueryName, string[] Entries, string[] Values, ref string strError)
	{
		ImanQuery imanQuery = null;
		List<ModelObject> list = null;
		checked
		{
			try
			{
				strError = "";
				Teamcenter.Services.Strong.Core.DataManagementService service = Teamcenter.Services.Strong.Core.DataManagementService.getService(TC_Conn);
				SavedQueryService service2 = SavedQueryService.getService(TC_Conn);
				try
				{
					FindSavedQueriesCriteriaInput findSavedQueriesCriteriaInput = new FindSavedQueriesCriteriaInput();
					findSavedQueriesCriteriaInput.QueryNames = new string[1] { QueryName };
					findSavedQueriesCriteriaInput.QueryType = 0;
					FindSavedQueriesResponse findSavedQueriesResponse = service2.FindSavedQueries(new FindSavedQueriesCriteriaInput[1] { findSavedQueriesCriteriaInput });
					if (findSavedQueriesResponse.SavedQueries.Length > 0)
					{
						imanQuery = findSavedQueriesResponse.SavedQueries[0];
						if (imanQuery == null)
						{
							strError = "Saved Query is missing in TC";
						}
						else
						{
							Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput[] array = new Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput[2];
							array[1] = new Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput();
							array[0] = new Teamcenter.Services.Strong.Query._2008_06.SavedQuery.QueryInput();
							array[0].Query = imanQuery;
							array[0].MaxNumToReturn = 0;
							array[0].LimitList = new ModelObject[0];
							array[0].Entries = Entries;
							array[0].Values = Values;
							SavedQueriesResponse savedQueriesResponse = service2.ExecuteSavedQueries(array);
							if (savedQueriesResponse.ArrayOfResults.Length > 0)
							{
								QueryResults queryResults = savedQueriesResponse.ArrayOfResults[0];
								ServiceData serviceData = service.LoadObjects(queryResults.ObjectUIDS);
								list = new List<ModelObject>();
								int num = serviceData.sizeOfPlainObjects() - 1;
								for (int i = 0; i <= num; i++)
								{
									list.Add(serviceData.GetPlainObject(i));
								}
							}
							else
							{
								strError = "Model Object is missing in TC";
							}
						}
					}
					else
					{
						strError = "Saved Query is missing in TC";
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					strError = ex2.Message;
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				strError = ex4.Message;
				ProjectData.ClearProjectError();
			}
			return list;
		}
	}

	private static RevisionRule GetRevisionRule(Teamcenter.Services.Strong.Cad.StructureManagementService objStser, string RevRuleName)
	{
		RevisionRule result = null;
		try
		{
			GetRevisionRulesResponse revisionRules = objStser.GetRevisionRules();
			RevisionRuleInfo[] output = revisionRules.Output;
			RevisionRuleInfo[] array = output;
			foreach (RevisionRuleInfo revisionRuleInfo in array)
			{
				if (revisionRuleInfo.RevRule.Object_name.Equals(RevRuleName))
				{
					result = revisionRuleInfo.RevRule;
					break;
				}
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

	private static ModelObject GetBOMViewObject(Teamcenter.Soa.Client.Connection TC_Conn, ModelObject objItem)
	{
		ModelObject result = null;
		try
		{
			Teamcenter.Services.Strong.Core.DataManagementService service = Teamcenter.Services.Strong.Core.DataManagementService.getService(TC_Conn);
			service.GetProperties(new ModelObject[1] { objItem }, new string[1] { "bom_view_tags" });
			ModelObject[] modelObjectArrayValue = objItem.GetProperty("bom_view_tags").ModelObjectArrayValue;
			ModelObject[] array = modelObjectArrayValue;
			foreach (ModelObject modelObject in array)
			{
				service.GetProperties(new ModelObject[1] { modelObject }, new string[1] { "view_type" });
				if (Operators.CompareString(modelObject.GetProperty("view_type").DisplayableValue, "PLM View", TextCompare: false) == 0)
				{
					result = modelObject;
					break;
				}
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

	public static ModelObject GetLatestItem(Teamcenter.Soa.Client.Connection TC_Conn, string sItemType, string ItemVal, ref string strError)
	{
		ModelObject result = null;
		try
		{
			string[] entries = new string[2] { "Type", "Item ID" };
			string[] values = new string[2] { sItemType, ItemVal };
			setObjectPolicy_Item(TC_Conn);
			List<ModelObject> list = ExecuteSavedQry(TC_Conn, "Item...", entries, values, ref strError);
			if (list.Count > 0)
			{
				result = list[0];
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

	public static ModelObject GetLatestItemRevision(Teamcenter.Soa.Client.Connection TC_Conn, string sItemType, string ItemVal, ref string strError)
	{
		ModelObject result = null;
		try
		{
			string[] entries = new string[1] { "Item ID" };
			string[] values = new string[1] { ItemVal };
			List<ModelObject> list = ExecuteSavedQry(TC_Conn, "Item Revision...", entries, values, ref strError);
			if (list.Count > 0)
			{
				result = list[0];
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

	public static List<ModelObject> GetSecondaryObjects(Teamcenter.Soa.Client.Connection TC_Conn, ModelObject objMod, string strRelationName, string strSecondaryObjectName)
	{
		List<ModelObject> list = null;
		checked
		{
			try
			{
				Teamcenter.Services.Strong.Core.DataManagementService service = Teamcenter.Services.Strong.Core.DataManagementService.getService(TC_Conn);
				ExpandGRMRelationsPref2 expandGRMRelationsPref = new ExpandGRMRelationsPref2();
				Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter relationAndTypesFilter = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter();
				relationAndTypesFilter.OtherSideObjectTypes = new string[1] { strSecondaryObjectName };
				relationAndTypesFilter.RelationTypeName = strRelationName;
				expandGRMRelationsPref.ExpItemRev = false;
				expandGRMRelationsPref.ReturnRelations = false;
				expandGRMRelationsPref.Info = new Teamcenter.Services.Strong.Core._2007_06.DataManagement.RelationAndTypesFilter[1] { relationAndTypesFilter };
				ExpandGRMRelationsResponse2 expandGRMRelationsResponse = service.ExpandGRMRelationsForPrimary(new ModelObject[1] { objMod }, expandGRMRelationsPref);
				ExpandGRMRelationsOutput2[] output = expandGRMRelationsResponse.Output;
				if (output.Length > 0)
				{
					ExpandGRMRelationsData2[] relationshipData = output[0].RelationshipData;
					if (relationshipData.Length > 0)
					{
						ExpandGRMRelationship[] relationshipObjects = relationshipData[0].RelationshipObjects;
						if (relationshipObjects.Length > 0)
						{
							list = new List<ModelObject>();
							int num = relationshipObjects.Length - 1;
							for (int i = 0; i <= num; i++)
							{
								list.Add(relationshipObjects[i].OtherSideObject);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			return list;
		}
	}

	public static string GetItemProperty(ModelObject objModel, string strProName)
	{
		string result = string.Empty;
		try
		{
			result = objModel.GetProperty(strProName).DisplayableValue;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string GetItemProperty_MultiValues(ModelObject objModel, string strProName)
	{
		string text = string.Empty;
		try
		{
			string[] displayableValues = objModel.GetProperty(strProName).DisplayableValues;
			foreach (string text2 in displayableValues)
			{
				text = text + ", " + text2;
			}
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				text = text.Substring(2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return text;
	}

	public static string GetChildNames(Teamcenter.Soa.Client.Connection TC_Conn, ModelObject objItemRev)
	{
		RevisionRule revisionRule = null;
		string text = string.Empty;
		try
		{
			setObjectPolicy_BOM(TC_Conn);
			Teamcenter.Services.Strong.Cad.StructureManagementService service = Teamcenter.Services.Strong.Cad.StructureManagementService.getService(TC_Conn);
			ModelObject modelObjectValue = objItemRev.GetProperty("items_tag").ModelObjectValue;
			if (modelObjectValue != null)
			{
				ModelObject bOMViewObject = GetBOMViewObject(TC_Conn, modelObjectValue);
				if (bOMViewObject != null)
				{
					revisionRule = GetRevisionRule(service, "HSM_WIP_Latest_Production_Released");
					CreateBOMWindowsInfo createBOMWindowsInfo = new CreateBOMWindowsInfo();
					createBOMWindowsInfo.Item = (Item)modelObjectValue;
					createBOMWindowsInfo.ItemRev = (ItemRevision)objItemRev;
					createBOMWindowsInfo.BomView = (PSBOMView)bOMViewObject;
					if (revisionRule != null)
					{
						RevisionRuleConfigInfo revisionRuleConfigInfo = new RevisionRuleConfigInfo();
						revisionRuleConfigInfo.RevRule = revisionRule;
						createBOMWindowsInfo.RevRuleConfigInfo = revisionRuleConfigInfo;
					}
					CreateBOMWindowsResponse createBOMWindowsResponse = service.CreateBOMWindows(new CreateBOMWindowsInfo[1] { createBOMWindowsInfo });
					if (createBOMWindowsResponse.Output.Count() > 0)
					{
						ExpandPSOneLevelInfo expandPSOneLevelInfo = new ExpandPSOneLevelInfo();
						ExpandPSOneLevelPref expandPSOneLevelPref = new ExpandPSOneLevelPref();
						expandPSOneLevelInfo.ParentBomLines = new BOMLine[1] { createBOMWindowsResponse.Output[0].BomLine };
						expandPSOneLevelInfo.ExcludeFilter = "None";
						expandPSOneLevelPref.ExpItemRev = false;
						ExpandPSOneLevelResponse expandPSOneLevelResponse = service.ExpandPSOneLevel(expandPSOneLevelInfo, expandPSOneLevelPref);
						if (expandPSOneLevelResponse.Output.Count() > 0)
						{
							ExpandPSData[] children = expandPSOneLevelResponse.Output[0].Children;
							foreach (ExpandPSData expandPSData in children)
							{
								if (expandPSData.BomLine.GetProperty("bl_rev_item_revision_id").DisplayableValue.Length > 0)
								{
									text = text + "| " + expandPSData.BomLine.GetProperty("bl_item_item_id").DisplayableValue;
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		if (Operators.CompareString(text, "", TextCompare: false) != 0)
		{
			text = text.Substring(2);
		}
		return text;
	}
}
