using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Rapid_Check.My;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Client.Model;

namespace Rapid_Check;

[StandardModule]
internal sealed class CheckSheetFunctios
{
	public static string ECN_ID;

	private static void CreateTable(ref DataTable dt, string Plant)
	{
		try
		{
			dt = new DataTable();
			dt.Columns.Add("Colour");
			dt.Columns[0].ColumnMapping = MappingType.Hidden;
			dt.Columns.Add("S.No", Type.GetType("System.Int32"));
			dt.Columns.Add("ECN Number");
			dt.Columns.Add("ID");
			dt.Columns.Add("Revision");
			dt.Columns.Add("Name");
			dt.Columns.Add("Description");
			dt.Columns.Add("Nomenclature");
			dt.Columns.Add("Source");
			dt.Columns.Add("EAU");
			dt.Columns.Add("BOM Option Code");
			dt.Columns.Add("Finish Code");
			dt.Columns.Add("Finish Color");
			dt.Columns.Add("Risk Level");
			dt.Columns.Add("High_Level_Category");
			dt.Columns.Add("Sub_Category");
			dt.Columns.Add("Hussmann Item Type");
			dt.Columns.Add("Master Template");
			dt.Columns.Add("Plant");
			dt.Columns.Add("Type");
			dt.Columns.Add("Release Status");
			dt.Columns.Add("Effectivity");
			dt.Columns.Add("UOM");
			dt.Columns.Add("Product Family");
			dt.Columns.Add("Product Line");
			dt.Columns.Add("Model Group");
			dt.Columns.Add("Analyst");
			dt.Columns.Add("Owner");
			if (Operators.CompareString(Plant, "BRIDGETON", TextCompare: false) == 0)
			{
				dt.Columns.Add("Plant Template");
				dt.Columns.Add("Template Name");
			}
			dt.Columns.Add("Plant_Form");
			dt.Columns.Add("Plant Coded");
			dt.Columns.Add("Remarks");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void Generate_CheckSheet(ref InputInfo objInput)
	{
		string text = string.Empty;
		checked
		{
			try
			{
				DataTable dt = new DataTable();
				Application.DoEvents();
				Functions.SetStatus(objInput.ProgressStatus, "Collecting solution items...");
				string strError = string.Empty;
				Application.DoEvents();
				CreateTable(ref dt, objInput.Site.ToUpper());
				TCFunctions.setObjectPolicy_ECN(objInput.TCCon, objInput.ECNType);
				ModelObject latestItemRevision = TCFunctions.GetLatestItemRevision(objInput.TCCon, objInput.ECNType, objInput.InputItem, ref strError);
				if (latestItemRevision == null)
				{
					MessageBox.Show("ECN (" + objInput.InputItem + ") not available in TC", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					TCFunctions.setObjectPolicy_CheckSheet(objInput.TCCon);
					List<ModelObject> secondaryObjects = TCFunctions.GetSecondaryObjects(objInput.TCCon, latestItemRevision, "CMHasSolutionItem", "H4_Hussmann_ItemRevision");
					if (secondaryObjects.Count > 0)
					{
						Functions.SetProgressBar(objInput.Progress_bar, secondaryObjects.Count);
						string empty = string.Empty;
						switch (objInput.Site.ToUpper())
						{
						case "BRIDGETON":
							empty = "h4_BGN_Source";
							dt.Columns[8].ColumnName = "BGN Source";
							break;
						case "MONTERREY":
						{
							empty = "h4_MTY_Source";
							dt.Columns[8].ColumnName = "MTY Source";
							DataColumn dataColumn3 = dt.Columns.Add("Mapics Item");
							dataColumn3.SetOrdinal(28);
							break;
						}
						case "CHINO":
						{
							empty = "h4_CNO_Source";
							dt.Columns[8].ColumnName = "CNO Source";
							DataColumn dataColumn2 = dt.Columns.Add("US BAAN Type");
							dataColumn2.SetOrdinal(30);
							break;
						}
						case "SUWANEE":
						{
							empty = "h4_SWN_Source";
							dt.Columns[8].ColumnName = "SWN Source";
							DataColumn dataColumn = dt.Columns.Add("US BAAN Type");
							dt.Columns[29].ColumnName = "Cross Reference Part No";
							dataColumn.SetOrdinal(30);
							break;
						}
						case "BOLINGBROOK":
							empty = "h4_BBK_Source";
							dt.Columns[8].ColumnName = "BBK Source";
							break;
						case "AFTERMARKET":
							empty = "h4_HAB_Source";
							dt.Columns[8].ColumnName = "HAB Source";
							break;
						default:
							empty = "h4_BGN_Source";
							break;
						}
						int num = secondaryObjects.Count - 1;
						int num2 = 0;
						XmlNodeList xmlNodeList14 = default(XmlNodeList);
						string innerText = default(string);
						string innerText2 = default(string);
						string innerText3 = default(string);
						string text13 = default(string);
						string innerText4 = default(string);
						string innerText5 = default(string);
						string innerText6 = default(string);
						string innerText7 = default(string);
						string innerText8 = default(string);
						string text20 = default(string);
						string right = default(string);
						string innerText9 = default(string);
						string innerText10 = default(string);
						string innerText11 = default(string);
						string innerText12 = default(string);
						string innerText13 = default(string);
						string innerText14 = default(string);
						string innerText15 = default(string);
						string innerText16 = default(string);
						string innerText17 = default(string);
						string innerText18 = default(string);
						string innerText19 = default(string);
						string innerText20 = default(string);
						string innerText21 = default(string);
						string innerText22 = default(string);
						while (num2 <= num)
						{
							DataRow dr = dt.NewRow();
							dr[1] = dt.Rows.Count + 1;
							dr[2] = objInput.InputItem;
							string text2 = (string)(dr[3] = TCFunctions.GetItemProperty(secondaryObjects[num2], "item_id"));
							dr[4] = TCFunctions.GetItemProperty(secondaryObjects[num2], "item_revision_id");
							dr[5] = TCFunctions.GetItemProperty(secondaryObjects[num2], "object_name");
							dr[6] = TCFunctions.GetItemProperty(secondaryObjects[num2], "object_desc");
							dr[7] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Nomenclature");
							dr[8] = TCFunctions.GetItemProperty(secondaryObjects[num2], empty);
							dr[9] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_EAU");
							dr[10] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_BOM_Option_Code");
							dr[11] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Finish_Code");
							dr[12] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Finish_Color");
							dr[13] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Risk_Level");
							dr[14] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_High_Level_Category");
							dr[15] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Sub_Category");
							dr[16] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Hussmann_Item_Type");
							dr[17] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Template_Name");
							dr[18] = TCFunctions.GetItemProperty(secondaryObjects[num2], "h4_Plant");
							dr[19] = TCFunctions.GetItemProperty(secondaryObjects[num2], "object_type");
							dr[20] = TCFunctions.GetItemProperty_MultiValues(secondaryObjects[num2], "release_status_list");
							dr[21] = TCFunctions.GetItemProperty(secondaryObjects[num2], "effectivity_text");
							string strError2 = string.Empty;
							ModelObject latestItem = TCFunctions.GetLatestItem(objInput.TCCon, "H4_Hussmann_Item", text2, ref strError2);
							if (latestItem != null)
							{
								dr[22] = TCFunctions.GetItemProperty(latestItem, "uom_tag");
								dr[23] = TCFunctions.GetItemProperty(latestItem, "h4_Product_Family");
								dr[24] = TCFunctions.GetItemProperty(latestItem, "h4_Product_Line");
								dr[25] = TCFunctions.GetItemProperty(latestItem, "h4_Model_Group");
								dr[26] = TCFunctions.GetItemProperty(latestItemRevision, "analyst_user_id");
								dr[27] = TCFunctions.GetItemProperty(latestItem, "owning_user");
							}
							UpdateFormProperty(objInput.TCCon, secondaryObjects[num2], ref dr, objInput.Site.ToUpper());
							if (Operators.CompareString(objInput.Site.ToUpper(), "BRIDGETON", TextCompare: false) == 0)
							{
								dr[32] = "";
							}
							else if (Operators.CompareString(objInput.Site.ToUpper(), "MONTERREY", TextCompare: false) == 0)
							{
								dr[31] = "";
							}
							if (Operators.CompareString(objInput.Site.ToUpper(), "SUWANEE", TextCompare: false) == 0)
							{
								dr[31] = "";
							}
							string left = Conversions.ToString(dr[18]);
							string left2 = Conversions.ToString(dr[16]);
							string text3 = Conversions.ToString(dr[20]);
							Functions.SetStatus(objInput.ProgressStatus, "Processing ItemID - " + text2 + " (" + Conversions.ToString(objInput.Progress_bar.Value) + "/" + Conversions.ToString(objInput.Progress_bar.Maximum) + ")");
							Application.DoEvents();
							string text60;
							string text65;
							string text66;
							string text67;
							XmlNodeList xmlNodeList18;
							XmlNodeList xmlNodeList19;
							XmlNodeList xmlNodeList20;
							XmlNodeList xmlNodeList21;
							XmlNodeList xmlNodeList22;
							XmlNodeList xmlNodeList23;
							XmlNodeList xmlNodeList25;
							string text75;
							string text76;
							string text77;
							string text78;
							string text79;
							string text80;
							string text81;
							string text82;
							if (Operators.CompareString(Declarations.SiteLoc, "Bridgeton", TextCompare: false) == 0)
							{
								if (((Operators.CompareString(left, "Bridgeton", TextCompare: false) == 0) & (Operators.CompareString(left2, "Legacy", TextCompare: false) == 0)) | (text3.Contains("BGN RELEASED") & (Operators.CompareString(left2, "Legacy", TextCompare: false) == 0)))
								{
									dr[32] = "Legacy Part - Verification not Performed, Please Cross Check the Details";
									text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
								}
								else if (((Operators.CompareString(left, "Bridgeton", TextCompare: false) == 0) & (Operators.CompareString(left2, "Legacy", TextCompare: false) != 0) & text3.Contains("BGN RELEASED") & !text3.Contains("BGN Discontinued") & (Operators.CompareString(left2, "Legacy", TextCompare: false) != 0)) || ((Operators.CompareString(left, "Bridgeton", TextCompare: false) != 0) & MyProject.Forms.frmMain.ValBGN.Checked))
								{
									XmlDocument xmlDocument = new XmlDocument();
									string filename = Application.StartupPath + "\\DataBase-Report.XML";
									try
									{
										xmlDocument.Load(filename);
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception prompt = ex;
										Interaction.MsgBox(prompt);
										ProjectData.ClearProjectError();
									}
									string text4 = Conversions.ToString(dr[16]);
									string text5 = Conversions.ToString(dr[8]);
									string left3 = Conversions.ToString(dr[15]);
									string text6 = Conversions.ToString(dr[14]);
									string text7 = null;
									string left4 = "";
									try
									{
										left4 = Conversions.ToString(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dr[28])) ? string.Empty : dr[28]);
									}
									catch (Exception ex2)
									{
										ProjectData.SetProjectError(ex2);
										Exception ex3 = ex2;
										Interaction.MsgBox(ex3.ToString());
										ProjectData.ClearProjectError();
									}
									if (Operators.CompareString(text4, "Case", TextCompare: false) == 0)
									{
										text7 = "Case";
									}
									if (Operators.CompareString(text4, "S-Kit", TextCompare: false) == 0)
									{
										text7 = "S-Kit";
									}
									if (Operators.CompareString(text4, "Material Bill - Case", TextCompare: false) == 0)
									{
										text7 = "MBC";
									}
									if (Operators.CompareString(text4, "Material Bill - ADD", TextCompare: false) == 0)
									{
										text7 = "MBA";
									}
									if (Operators.CompareString(text4, "Material Bill - ADD & Delete", TextCompare: false) == 0)
									{
										text7 = "MBAD";
									}
									if (Operators.CompareString(text4, "Material Bill - Retrofit", TextCompare: false) == 0)
									{
										text7 = "MBR";
									}
									if ((Operators.CompareString(text4, "Module", TextCompare: false) == 0) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(left3, "Welded", TextCompare: false) != 0)))
									{
										text7 = "Module";
									}
									if ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(left3, "Welded", TextCompare: false) == 0))
									{
										text7 = "Assembly-Make";
									}
									if ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text5, "Buy", TextCompare: false) == 0))
									{
										text7 = "Assembly-Buy";
									}
									if (Operators.CompareString(text4, "M-Kit", TextCompare: false) == 0)
									{
										text7 = "M-Kit";
									}
									if ((Operators.CompareString(text4, "O-Kit", TextCompare: false) == 0) | (Operators.CompareString(text4, "S3C O-Kit", TextCompare: false) == 0))
									{
										text7 = "O-Kit";
									}
									if (Operators.CompareString(text4, "Retrofit-Kit", TextCompare: false) == 0)
									{
										text7 = "Retrofit-Kit";
									}
									if (Operators.CompareString(text4, "Option-Class", TextCompare: false) == 0)
									{
										text7 = "Opt-Class";
									}
									if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Assemblies", TextCompare: false) == 0))
									{
										text7 = "Part-Weld";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Finished Tubes", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Finished Tubes", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fabricated Parts", TextCompare: false) == 0) & (Operators.CompareString(left3, "Copper Tubing", TextCompare: false) == 0)))
									{
										text7 = "Part-TUBE";
									}
									if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text5.ToLower(), "Buy", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fasteners & Hardware", TextCompare: false) != 0) & (Operators.CompareString(text6, "Formed Metal - Outsourced", TextCompare: false) != 0) & (Operators.CompareString(text6, "Aluminum", TextCompare: false) != 0))
									{
										text7 = "Part-Buy";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text5.ToLower(), "Buy", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fasteners & Hardware", TextCompare: false) != 0) & (Operators.CompareString(text6, "Formed Metal - Outsourced", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text5.ToLower(), "Buy", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fasteners & Hardware", TextCompare: false) != 0) & (Operators.CompareString(text6, "Aluminum", TextCompare: false) == 0)))
									{
										text7 = "Part-MBuy";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text5, "COP", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text5, "COP", TextCompare: false) == 0)))
									{
										text7 = "Part-COP";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Technical Publications", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Technical Publications", TextCompare: false) == 0)))
									{
										text7 = "Part-COP";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Reference MOA & Diagram", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Reference MOA & Diagram", TextCompare: false) == 0)))
									{
										text7 = "Part-MOA";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Compressors", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Compressors", TextCompare: false) == 0)))
									{
										text7 = "Part-Compr";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Indirect Material", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Indirect Material", TextCompare: false) == 0)))
									{
										text7 = "Part-IndMtl";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Copper", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Copper", TextCompare: false) == 0)))
									{
										text7 = "Part-Cu";
									}
									if ((Operators.CompareString(text4, "Generic BOM", TextCompare: false) == 0) & (Operators.CompareString(text6, "Paint", TextCompare: false) == 0))
									{
										text7 = "PA-Paint";
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fasteners & Hardware", TextCompare: false) == 0) & (Operators.CompareString(text5.ToLower(), "Buy", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fasteners & Hardware", TextCompare: false) == 0) & (Operators.CompareString(text5.ToLower(), "Buy", TextCompare: false) == 0)))
									{
										text7 = "Part-FH";
									}
									if (Operators.CompareString(left4, "CC DISCRETE", TextCompare: false) != 0)
									{
										if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fabricated Parts", TextCompare: false) == 0))
										{
											text7 = "Part-GMP";
										}
										if ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fabricated Parts", TextCompare: false) == 0))
										{
											text7 = "Part-GMP";
										}
									}
									else if (Operators.CompareString(left4, "CC DISCRETE", TextCompare: false) == 0)
									{
										if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fabricated Parts", TextCompare: false) == 0))
										{
											text7 = "Part-SMT";
										}
										if ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fabricated Parts", TextCompare: false) == 0))
										{
											text7 = "Part-SMT";
										}
									}
									if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(left3, "Lightings", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(left3, "Lightings", TextCompare: false) == 0)))
									{
										text7 = "Part-Lightings";
									}
									string left5 = Strings.Right(Conversions.ToString(dr[7]), 1);
									if ((Operators.CompareString(text4, "Generic BOM", TextCompare: false) == 0) & (Operators.CompareString(left5, "M", TextCompare: false) == 0))
									{
										text7 = "M-Kit";
									}
									else if ((Operators.CompareString(text4, "Generic BOM", TextCompare: false) == 0) & (Operators.CompareString(left5, "O", TextCompare: false) == 0))
									{
										text7 = "O-Kit";
									}
									if (Operators.CompareString(text7, "", TextCompare: false) == 0)
									{
										dr[32] = Operators.ConcatenateObject("Hussmann Item Type - Group is Missing for Item Type:-" + text4 + "High Level Cat:-" + text6 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
									}
									else
									{
										XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//" + text7 + "/High_Level_Category");
										XmlNodeList xmlNodeList2 = xmlDocument.SelectNodes("//" + text7 + "/Subcategory");
										XmlNodeList xmlNodeList3 = xmlDocument.SelectNodes("//" + text7 + "/Unit_of_Measure");
										XmlNodeList xmlNodeList4 = xmlDocument.SelectNodes("//" + text7 + "/Product_Family");
										XmlNodeList xmlNodeList5 = xmlDocument.SelectNodes("//" + text7 + "/Model_Group");
										XmlNodeList xmlNodeList6 = xmlDocument.SelectNodes("//" + text7 + "/Product_Line");
										XmlNodeList xmlNodeList7 = xmlDocument.SelectNodes("//" + text7 + "/Finish_Code");
										XmlNodeList xmlNodeList8 = xmlDocument.SelectNodes("//" + text7 + "/Finish_Color");
										XmlNodeList xmlNodeList9 = xmlDocument.SelectNodes("//" + text7 + "/Master_Template");
										XmlNodeList xmlNodeList10 = xmlDocument.SelectNodes("//" + text7 + "/BOM_Option_Code");
										XmlNodeList xmlNodeList11 = xmlDocument.SelectNodes("//" + text7 + "/Plant_Template");
										XmlNodeList xmlNodeList12 = xmlDocument.SelectNodes("//" + text7 + "/Template_Name");
										XmlNodeList xmlNodeList13 = xmlDocument.SelectNodes("//" + text7 + "/Source");
										if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) | (Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) | (Operators.CompareString(text4, "Module", TextCompare: false) == 0) | (Operators.CompareString(text4, "Option-Class", TextCompare: false) == 0))
										{
											xmlNodeList14 = xmlDocument.SelectNodes("//" + text7 + "/Nomenclature");
										}
										string text8 = Conversions.ToString(dr[14]);
										foreach (XmlNode item in xmlNodeList)
										{
											if (!item.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode in item.ChildNodes)
											{
												innerText = childNode.InnerText;
												if (Operators.CompareString(innerText, text8, TextCompare: false) == 0)
												{
													goto end_IL_1366;
												}
												if (Operators.CompareString(innerText, text8, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1366:
											break;
										}
										string text9 = Conversions.ToString(dr[15]);
										foreach (XmlNode item2 in xmlNodeList2)
										{
											if (!item2.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode2 in item2.ChildNodes)
											{
												innerText2 = childNode2.InnerText;
												if (Operators.CompareString(innerText2, text9, TextCompare: false) == 0)
												{
													goto end_IL_1442;
												}
												if (Operators.CompareString(innerText2, text9, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1442:
											break;
										}
										string text10 = Conversions.ToString(dr[22]);
										foreach (XmlNode item3 in xmlNodeList3)
										{
											if (!item3.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode3 in item3.ChildNodes)
											{
												innerText3 = childNode3.InnerText;
												if (Operators.CompareString(innerText3, text10, TextCompare: false) == 0)
												{
													goto end_IL_151e;
												}
												if (Operators.CompareString(innerText3, text10, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_151e:
											break;
										}
										string text11 = Conversions.ToString(dr[5]);
										string text12 = ((!text11.Contains("00K")) ? Conversions.ToString(dr[23]) : Strings.Left(Conversions.ToString(dr[23]), 3));
										foreach (XmlNode item4 in xmlNodeList4)
										{
											if (!item4.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode4 in item4.ChildNodes)
											{
												text13 = ((!text11.Contains("00K")) ? childNode4.InnerText : "LED");
												if (Operators.CompareString(text13, text12, TextCompare: false) == 0)
												{
													goto end_IL_1656;
												}
												if (Operators.CompareString(text13, text12, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1656:
											break;
										}
										string text14 = Conversions.ToString(dr[25]);
										foreach (XmlNode item5 in xmlNodeList5)
										{
											if (!item5.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode5 in item5.ChildNodes)
											{
												innerText4 = childNode5.InnerText;
												if (Operators.CompareString(innerText4, text14, TextCompare: false) == 0)
												{
													goto end_IL_1732;
												}
												if (Operators.CompareString(innerText4, text14, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1732:
											break;
										}
										string text15 = Conversions.ToString(dr[24]);
										foreach (XmlNode item6 in xmlNodeList6)
										{
											if (!item6.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode6 in item6.ChildNodes)
											{
												innerText5 = childNode6.InnerText;
												if (Operators.CompareString(innerText5.ToLower(), text15.ToLower(), TextCompare: false) == 0)
												{
													goto end_IL_1825;
												}
												if (Operators.CompareString(innerText5.ToLower(), text15.ToLower(), TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1825:
											break;
										}
										string text16 = Conversions.ToString(dr[11]);
										foreach (XmlNode item7 in xmlNodeList7)
										{
											if (!item7.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode7 in item7.ChildNodes)
											{
												innerText6 = childNode7.InnerText;
												if (Operators.CompareString(innerText6.ToLower(), text16.ToLower(), TextCompare: false) == 0)
												{
													goto end_IL_1918;
												}
												if (Operators.CompareString(innerText6.ToLower(), text16.ToLower(), TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1918:
											break;
										}
										string text17 = Conversions.ToString(dr[12]);
										foreach (XmlNode item8 in xmlNodeList8)
										{
											if (!item8.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode8 in item8.ChildNodes)
											{
												innerText7 = childNode8.InnerText;
												if (Operators.CompareString(innerText7, text17, TextCompare: false) == 0)
												{
													goto end_IL_19f4;
												}
												if (Operators.CompareString(innerText7, text17, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_19f4:
											break;
										}
										string text18 = Conversions.ToString(dr[17]);
										foreach (XmlNode item9 in xmlNodeList9)
										{
											if (!item9.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode9 in item9.ChildNodes)
											{
												innerText8 = childNode9.InnerText;
												if (Operators.CompareString(innerText8, text18, TextCompare: false) == 0)
												{
													goto end_IL_1ad0;
												}
												if (Operators.CompareString(innerText8, text18, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1ad0:
											break;
										}
										string text19 = Conversions.ToString(dr[10]);
										string left6 = Conversions.ToString(dr[23]);
										foreach (XmlNode item10 in xmlNodeList10)
										{
											if (!item10.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode10 in item10.ChildNodes)
											{
												text20 = ((Operators.CompareString(left6, "CO2", TextCompare: false) == 0) ? "19" : childNode10.InnerText);
												if (Operators.CompareString(text20, text19, TextCompare: false) == 0)
												{
													goto end_IL_1be0;
												}
												if (Operators.CompareString(text20, text19, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_1be0:
											break;
										}
										string text21 = Conversions.ToString(dr[7]);
										string text22 = "";
										string text23 = Conversions.ToString(dr[3]);
										if ((Operators.CompareString(text4, "Module", TextCompare: false) == 0) | (Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) | (Operators.CompareString(text4, "Part", TextCompare: false) == 0) | (Operators.CompareString(text4, "Option-Class", TextCompare: false) == 0))
										{
											foreach (XmlNode item11 in xmlNodeList14)
											{
												if (!item11.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode11 in item11.ChildNodes)
												{
													text22 = childNode11.InnerText;
													if (Operators.CompareString(text22, text21, TextCompare: false) == 0)
													{
														goto end_IL_1d0b;
													}
												}
												continue;
												end_IL_1d0b:
												break;
											}
										}
										else if ((Operators.CompareString(text4, "Case", TextCompare: false) == 0) | (Operators.CompareString(text4, "M-Kit", TextCompare: false) == 0) | (Operators.CompareString(text4, "O-Kit", TextCompare: false) == 0) | (Operators.CompareString(text4, "S3C O-Kit", TextCompare: false) == 0))
										{
											text22 = text23;
											text21 = Conversions.ToString(dr[7]);
											if (Operators.CompareString(text21, text22, TextCompare: false) != 0)
											{
											}
										}
										else if ((Operators.CompareString(text4, "Retrofit-Kit", TextCompare: false) == 0) | (Operators.CompareString(text4, "Material Bill - Retrofit", TextCompare: false) == 0))
										{
											text22 = Strings.Right(Conversions.ToString(dr[7]), 1);
											text21 = "M";
											if (Operators.CompareString(text22, text21, TextCompare: false) != 0)
											{
											}
										}
										else if ((Operators.CompareString(text4, "Material Bill - ADD & Delete", TextCompare: false) == 0) | (Operators.CompareString(text4, "Material Bill - ADD", TextCompare: false) == 0) | (Operators.CompareString(text4, "S-Kit", TextCompare: false) == 0) | ((Operators.CompareString(text4, "Generic BOM", TextCompare: false) == 0) & (Operators.CompareString(text6, "Paint", TextCompare: false) != 0)))
										{
											text22 = Strings.Right(Conversions.ToString(dr[7]), 1);
											text21 = "M";
											right = "O";
											if (Operators.CompareString(text22, right, TextCompare: false) != 0 && Operators.CompareString(text22, text21, TextCompare: false) != 0 && Operators.CompareString(text22, "", TextCompare: false) == 0)
											{
											}
										}
										else if ((Operators.CompareString(text4, "Generic BOM", TextCompare: false) == 0) & (Operators.CompareString(text6, "Paint", TextCompare: false) == 0))
										{
											if (Operators.CompareString(text22, text21, TextCompare: false) != 0)
											{
											}
										}
										else if (Operators.CompareString(text4, "Material Bill - Case", TextCompare: false) == 0)
										{
											text22 = Conversions.ToString(dr[7]);
											text21 = Conversions.ToString(dr[7]);
											if (Operators.CompareString(text22, text21, TextCompare: false) != 0)
											{
											}
										}
										string text24 = Conversions.ToString(dr[28]);
										foreach (XmlNode item12 in xmlNodeList11)
										{
											if (!item12.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode12 in item12.ChildNodes)
											{
												innerText9 = childNode12.InnerText;
												if (Operators.CompareString(innerText9, text24, TextCompare: false) == 0)
												{
													goto end_IL_2086;
												}
												if (Operators.CompareString(innerText9, text24, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_2086:
											break;
										}
										string text25 = Conversions.ToString(dr[29]);
										foreach (XmlNode item13 in xmlNodeList12)
										{
											if (!item13.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode13 in item13.ChildNodes)
											{
												innerText10 = childNode13.InnerText;
												if (Operators.CompareString(innerText10, text25, TextCompare: false) == 0)
												{
													goto end_IL_21b8;
												}
												if (Operators.CompareString(innerText10, text25, TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_21b8:
											break;
										}
										string text26 = Conversions.ToString(dr[8]);
										foreach (XmlNode item14 in xmlNodeList13)
										{
											if (!item14.HasChildNodes)
											{
												continue;
											}
											foreach (XmlNode childNode14 in item14.ChildNodes)
											{
												innerText11 = childNode14.InnerText;
												if (Operators.CompareString(innerText11.ToUpper(), text26.ToUpper(), TextCompare: false) == 0)
												{
													goto end_IL_2300;
												}
												if (Operators.CompareString(innerText11.ToUpper(), text26.ToUpper(), TextCompare: false) == 0)
												{
												}
											}
											continue;
											end_IL_2300:
											break;
										}
										if (Operators.CompareString(innerText, text8, TextCompare: false) == 0)
										{
											if (xmlNodeList.Count >= 1)
											{
												text += ";4|14";
											}
											else
											{
												text += ";6|14";
												dr[32] = Operators.ConcatenateObject("Verify the High Level Catagory ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (Operators.CompareString(innerText, text8, TextCompare: false) != 0)
										{
											string text27;
											if ((xmlNodeList.Count == 1) & (Operators.CompareString(innerText, "", TextCompare: false) == 0))
											{
												text27 = "Should be None";
												text += ";3|14";
											}
											else if ((xmlNodeList.Count == 1) & (Operators.CompareString(innerText, "", TextCompare: false) != 0))
											{
												text27 = "Should be " + innerText;
												text += ";3|14";
											}
											else if (Operators.CompareString(text8, "", TextCompare: false) == 0)
											{
												text27 = "is Missing";
												text += ";3|14";
											}
											else
											{
												text27 = "is incorrect";
												text += ";3|14";
											}
											dr[32] = Operators.ConcatenateObject("High Level Catagory " + text27 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										if (Operators.CompareString(text26.ToUpper(), innerText11.ToUpper(), TextCompare: false) == 0)
										{
											text += ";4|8";
										}
										else if (Operators.CompareString(text26.ToUpper(), innerText11.ToUpper(), TextCompare: false) != 0)
										{
											string text28 = innerText11;
											dr[32] = Operators.ConcatenateObject("Sourcing Should be " + text28 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											text += ";3|8";
										}
										string left7 = Strings.Left(Conversions.ToString(dr[3]), 1);
										string left8 = Conversions.ToString(dr[4]);
										if (Operators.CompareString(text8, "Reference MOA & Diagram", TextCompare: false) != 0)
										{
											if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareString(text26, "Buy", TextCompare: false) == 0, Operators.CompareObjectEqual(dr[9], "", TextCompare: false)), Operators.CompareString(left7, "0", TextCompare: false) != 0), Operators.CompareString(left8, "A", TextCompare: false) == 0)))
											{
												text += ";6|9";
												dr[32] = Operators.ConcatenateObject("EAU Values are Missing ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(text26, "Buy", TextCompare: false) == 0, Operators.CompareObjectNotEqual(dr[9], "", TextCompare: false))))
											{
												text += ";4|9";
											}
										}
										if (Operators.CompareString(innerText2, text9, TextCompare: false) == 0)
										{
											if (xmlNodeList2.Count >= 1)
											{
												text += ";4|15";
											}
											else
											{
												text += ";6|15";
												dr[32] = Operators.ConcatenateObject("Verify the Subcategory ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (Operators.CompareString(innerText2, text9, TextCompare: false) != 0)
										{
											string text29;
											if ((xmlNodeList2.Count == 1) & (Operators.CompareString(innerText2, "", TextCompare: false) == 0))
											{
												text29 = "Should be None";
												text += ";3|15";
											}
											else if ((xmlNodeList2.Count == 1) & (Operators.CompareString(innerText2, "", TextCompare: false) != 0))
											{
												text29 = "Should be " + innerText2;
												text += ";3|15";
											}
											else if (Operators.CompareString(text9, "", TextCompare: false) == 0)
											{
												text29 = "is Missing";
												text += ";3|15";
											}
											else
											{
												text29 = "is incorrect";
												text += ";3|15";
											}
											dr[32] = Operators.ConcatenateObject("Subcategory " + text29 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											if ((Operators.CompareString(text4, "Material Bill - ADD", TextCompare: false) == 0) | (Operators.CompareString(text4, "Material Bill - ADD & Delete", TextCompare: false) == 0) | (Operators.CompareString(text4, "Material Bill - Retrofit", TextCompare: false) == 0))
											{
												text += ";6|15";
											}
										}
										if (Operators.CompareString(innerText3, text10, TextCompare: false) == 0)
										{
											text += ";4|22";
										}
										else if (Operators.CompareString(innerText3, text10, TextCompare: false) != 0)
										{
											string text30 = ((xmlNodeList3.Count != 1) ? "is incorrect" : ("Should be " + innerText3));
											dr[32] = Operators.ConcatenateObject("Unit " + text30 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											text += ";3|22";
										}
										string text31 = Conversions.ToString(dr[5]);
										if (Operators.CompareString(text13, text12, TextCompare: false) == 0)
										{
											if (xmlNodeList4.Count == 1)
											{
												text += ";4|23";
											}
											else
											{
												text += ";6|23";
												dr[32] = Operators.ConcatenateObject("Verify the Product Family ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (text31.Contains("00K") & (Operators.CompareString(text12, "", TextCompare: false) == 0))
										{
											text += ";4|23";
										}
										else if (Operators.CompareString(text13, text12, TextCompare: false) != 0)
										{
											string text32;
											if ((xmlNodeList4.Count == 1) & (Operators.CompareString(text13, "", TextCompare: false) == 0))
											{
												text32 = "Should be None";
												text += ";3|23";
											}
											else if ((xmlNodeList4.Count == 1) & (Operators.CompareString(text13, "", TextCompare: false) == 0))
											{
												text32 = "Should be " + text13;
												text += ";3|23";
											}
											else if (Operators.CompareString(text12, "", TextCompare: false) == 0)
											{
												text32 = "is Missing";
												text += ";3|23";
											}
											else if (text31.Contains("00K") & (Operators.CompareString(text12, "LED", TextCompare: false) != 0))
											{
												text32 = "needs to start with LED";
												text += ";3|23";
											}
											else
											{
												text32 = "is incorrect";
												text += ";3|23";
											}
											dr[32] = Operators.ConcatenateObject("Product Family " + text32 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										if (Operators.CompareString(innerText4, text14, TextCompare: false) == 0)
										{
											if (xmlNodeList5.Count == 1)
											{
												text += ";4|25";
											}
											else
											{
												text += ";6|25";
												dr[32] = Operators.ConcatenateObject("Verify the Model Group ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (Operators.CompareString(innerText4, text14, TextCompare: false) != 0)
										{
											string text33;
											if ((xmlNodeList5.Count == 1) & (Operators.CompareString(innerText4, "", TextCompare: false) == 0))
											{
												text33 = "Should be None";
												text += ";3|25";
											}
											else if ((xmlNodeList5.Count == 1) & (Operators.CompareString(innerText4, "", TextCompare: false) == 0))
											{
												text33 = "Should be " + innerText4;
												text += ";3|25";
											}
											else if (Operators.CompareString(text14, "", TextCompare: false) == 0)
											{
												text33 = "is Missing";
												text += ";3|25";
											}
											else
											{
												text33 = "is incorrect";
												text += ";3|25";
											}
											dr[32] = Operators.ConcatenateObject("Model Group " + text33 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										if ((Operators.CompareString(text8, "Material Bill", TextCompare: false) == 0) & (Operators.CompareString(innerText4, text14, TextCompare: false) != 0))
										{
											text += ";6|25";
										}
										if (Operators.CompareString(innerText5.ToLower(), text15.ToLower(), TextCompare: false) == 0)
										{
											if (xmlNodeList6.Count == 1)
											{
												text += ";4|24";
											}
											else
											{
												text += ";6|24";
												dr[32] = Operators.ConcatenateObject("Verify the Product Line ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (Operators.CompareString(innerText5.ToLower(), text15.ToLower(), TextCompare: false) != 0)
										{
											string text34;
											if ((xmlNodeList6.Count == 1) & (Operators.CompareString(innerText5, "", TextCompare: false) == 0))
											{
												text34 = "Should be None";
												text += ";3|24";
											}
											else if ((xmlNodeList6.Count == 1) & (Operators.CompareString(innerText5, "", TextCompare: false) != 0))
											{
												text34 = "Should be " + innerText5;
												text += ";3|24";
											}
											else if (Operators.CompareString(text15, "", TextCompare: false) == 0)
											{
												text34 = "is Missing";
												text += ";3|24";
											}
											else
											{
												text34 = "is incorrect";
												text += ";3|24";
											}
											dr[32] = Operators.ConcatenateObject("Product Line " + text34 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										if (Operators.CompareString(innerText6, text16, TextCompare: false) == 0)
										{
											if (xmlNodeList7.Count == 1)
											{
												text += ";4|11";
											}
											else
											{
												text += ";6|11";
												dr[32] = Operators.ConcatenateObject("Verify the Finish Code ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											if (((Operators.CompareString(text7, "Part-SMT", TextCompare: false) == 0) & (xmlNodeList7.Count >= 1)) | ((Operators.CompareString(text7, "Part-TUBE", TextCompare: false) == 0) & (xmlNodeList7.Count == 0)) | ((Operators.CompareString(text8, "Formed Metal - Outsourced", TextCompare: false) == 0) & (xmlNodeList7.Count >= 1)))
											{
												text += ";4|11";
											}
										}
										else if (Operators.CompareString(innerText6, text16, TextCompare: false) != 0)
										{
											string text35;
											if ((xmlNodeList7.Count == 1) & (Operators.CompareString(innerText6, "", TextCompare: false) == 0))
											{
												text35 = "should be None";
												text += ";3|11";
											}
											else if ((xmlNodeList7.Count == 1) & (Operators.CompareString(innerText6, "", TextCompare: false) != 0))
											{
												text35 = "Should be " + innerText6;
												text += ";3|11";
											}
											else if (Operators.CompareString(text16, "", TextCompare: false) == 0)
											{
												text35 = "is Missing";
												text += ";3|11";
											}
											else
											{
												text35 = "is incorrect";
												text += ";3|11";
											}
											dr[32] = Operators.ConcatenateObject("Finish Code " + text35 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										if ((Operators.CompareString(text16, "92", TextCompare: false) == 0) | (Operators.CompareString(text16, "93", TextCompare: false) == 0))
										{
											text += ";6|11";
											dr[32] = Operators.ConcatenateObject("Verify the Finish Code ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										if (Operators.CompareString(innerText7, text17, TextCompare: false) == 0)
										{
											if (xmlNodeList8.Count == 1)
											{
												text += ";4|12";
											}
											else
											{
												text += ";6|12";
												dr[32] = Operators.ConcatenateObject("Verify the Finish Color ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											if ((Operators.CompareString(text7, "Part-TUBE", TextCompare: false) == 0) | ((Operators.CompareString(text8, "Formed Metal - Outsourced", TextCompare: false) == 0) & (xmlNodeList7.Count >= 1)) | ((Operators.CompareString(text7, "Part-SMT", TextCompare: false) == 0) & (xmlNodeList7.Count >= 1)))
											{
												text += ";4|12";
											}
										}
										else if (Operators.CompareString(innerText7, text17, TextCompare: false) != 0)
										{
											string text36 = null;
											if ((xmlNodeList8.Count == 1) & (Operators.CompareString(innerText7, "", TextCompare: false) == 0))
											{
												text36 = "Should be None";
												text += ";3|12";
											}
											else if ((xmlNodeList8.Count == 1) & (Operators.CompareString(innerText7, "", TextCompare: false) != 0))
											{
												text36 = "Should be " + innerText7;
												text += ";3|12";
											}
											else if (Operators.CompareString(text17, "", TextCompare: false) == 0)
											{
												text36 = "Verify if kit needs Finish Color";
												text += ";6|12";
											}
											else
											{
												text36 = "is incorrect";
												text += ";3|12";
											}
											if (Operators.CompareString(text36, "", TextCompare: false) != 0)
											{
												dr[32] = Operators.ConcatenateObject("Finish Color" + text36 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if (Operators.CompareString(innerText8, text18, TextCompare: false) == 0)
										{
											if (xmlNodeList9.Count == 1)
											{
												text += ";4|17";
											}
											else
											{
												text += ";6|17";
												dr[32] = Operators.ConcatenateObject("Verify the Master Template ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (Operators.CompareString(innerText8, text18, TextCompare: false) != 0)
										{
											string text37;
											if ((xmlNodeList9.Count == 1) & (Operators.CompareString(innerText8, "", TextCompare: false) == 0))
											{
												text37 = "should be None";
												text += ";3|17";
											}
											else if ((xmlNodeList9.Count == 1) & (Operators.CompareString(innerText8, "", TextCompare: false) != 0))
											{
												text37 = "Should be " + innerText8;
												text += ";3|17";
											}
											else if (Operators.CompareString(text18, "", TextCompare: false) == 0)
											{
												text37 = "is Missing";
												text += ";3|17";
											}
											else
											{
												text37 = "is incorrect";
												text += ";3|17";
											}
											dr[32] = Operators.ConcatenateObject("Master Template " + text37 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										string left9 = Conversions.ToString(dr[23]);
										if (Operators.CompareString(text20, text19, TextCompare: false) == 0)
										{
											if (xmlNodeList10.Count == 1)
											{
												text += ";4|10";
											}
											else
											{
												text += ";6|10";
												dr[32] = Operators.ConcatenateObject("Verify the Bom Option Code ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (Operators.CompareString(text20, text19, TextCompare: false) != 0)
										{
											string text38;
											if ((xmlNodeList10.Count == 1) & (Operators.CompareString(text20, "", TextCompare: false) == 0))
											{
												text38 = "should be None";
												text += ";3|10";
											}
											else if ((xmlNodeList10.Count == 1) & (Operators.CompareString(text20, "", TextCompare: false) != 0))
											{
												text38 = "Should be " + text20;
												text += ";3|10";
											}
											else if (Operators.CompareString(text19, "", TextCompare: false) == 0)
											{
												text38 = "is Missing";
												text += ";3|10";
											}
											else
											{
												text38 = "is incorrect";
												text += ";3|10";
											}
											if (Operators.CompareString(left9, "CO2", TextCompare: false) == 0)
											{
												dr[32] = Operators.ConcatenateObject("Bom Option Code Should be 19 on Co2 Kit, \n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											else
											{
												dr[32] = Operators.ConcatenateObject("Bom Option Code" + text38 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if ((Operators.CompareString(text22, text21, TextCompare: false) == 0) | (Operators.CompareString(text22, right, TextCompare: false) == 0))
										{
											text += ";4|7";
										}
										else if ((Operators.CompareString(text22, text21, TextCompare: false) != 0) | (Operators.CompareString(text22, right, TextCompare: false) != 0))
										{
											string text39;
											if (Operators.CompareString(text22, "", TextCompare: false) == 0)
											{
												text39 = "Should be None";
												text += ";3|7";
											}
											else
											{
												text39 = "Kit-Letter is Missing (M/O)";
												text += ";6|7";
											}
											dr[32] = Operators.ConcatenateObject("Nomenclature - " + text39 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										if (Operators.CompareString(innerText9, text24, TextCompare: false) == 0)
										{
											if (xmlNodeList11.Count >= 1)
											{
												text += ";4|28";
											}
											else if (Operators.CompareString(text6, "Fabricated Parts", TextCompare: false) == 0)
											{
												text += ";4|28";
											}
											else
											{
												text += ";6|28";
												dr[32] = Operators.ConcatenateObject("Verify the Plant Template ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if (Operators.CompareString(innerText9, text24, TextCompare: false) != 0)
										{
											string text40;
											if ((xmlNodeList11.Count == 1) & (Operators.CompareString(innerText9, "", TextCompare: false) == 0))
											{
												text40 = "should be None";
												text += ";3|28";
											}
											else if ((xmlNodeList11.Count == 1) & (Operators.CompareString(innerText9, "", TextCompare: false) != 0))
											{
												text40 = "Should be " + innerText9;
												text += ";3|28";
											}
											else
											{
												text40 = "is incorrect";
												text += ";3|28";
											}
											if (Operators.CompareString(text24, "", TextCompare: false) == 0)
											{
												dr[32] = Operators.ConcatenateObject("Missing Plant Template ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												text += ";3|28";
											}
											else
											{
												dr[32] = Operators.ConcatenateObject("Plant Template " + text40 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												text += ";3|28";
											}
										}
										if ((Operators.CompareString(innerText10.ToUpper(), text25.ToUpper(), TextCompare: false) == 0) | (Operators.CompareString(text25, "TK INVENTORY WINDCHILL", TextCompare: false) == 0))
										{
											if (xmlNodeList12.Count >= 1)
											{
												text += ";4|29";
											}
											else
											{
												text += ";6|29";
												dr[32] = Operators.ConcatenateObject("Verify the Template Name ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if ((Operators.CompareString(innerText10, text25, TextCompare: false) != 0) & (Operators.CompareString(text25, "TK INVENTORY WINDCHILL", TextCompare: false) != 0))
										{
											string text41;
											if ((xmlNodeList12.Count == 1) & (Operators.CompareString(innerText10, "", TextCompare: false) == 0))
											{
												text41 = "should be None";
												text += ";3|29";
											}
											else if ((xmlNodeList12.Count == 1) & (Operators.CompareString(innerText10, "", TextCompare: false) != 0))
											{
												text41 = "Should be " + innerText10;
												text += ";3|29";
											}
											else
											{
												text41 = "is incorrect";
												text += ";3|29";
											}
											if (Operators.CompareString(text25, "", TextCompare: false) == 0)
											{
												dr[32] = Operators.ConcatenateObject("Missing Template Name ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												text += ";3|29";
											}
											else
											{
												dr[32] = Operators.ConcatenateObject("Template Name " + text41 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												text += ";3|29";
											}
										}
										string left10 = Conversions.ToString(dr[23]);
										if (Operators.ConditionalCompareObjectEqual(dr[5], dr[6], TextCompare: false))
										{
											text += ";4|5,6";
										}
										else
										{
											text += ";6|5,6";
											dr[32] = Operators.ConcatenateObject("Name and Descripton is Not Matching ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										string text42 = Conversions.ToString(dr[5]);
										if (text42.Contains("00K") & (Operators.CompareString(text4, "O-Kit", TextCompare: false) != 0))
										{
											dr[32] = Operators.ConcatenateObject("LED light kits are typically O-kits  ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											text += ";4|5,6";
										}
										if ((Operators.CompareString(text4, "M-Kit", TextCompare: false) == 0) & (Operators.CompareString(left10, "CO2", TextCompare: false) == 0))
										{
											string text43 = Conversions.ToString(dr[5]);
											if (text43.Contains("CO2"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("CO2 Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										string str = text2;
										string left11 = Strings.Right(str, 1);
										string left12 = Strings.Left(str, 2);
										if (text4.Contains("Kit") && ((Operators.CompareString(left11, "O", TextCompare: false) != 0) & (Operators.CompareString(left11, "M", TextCompare: false) != 0)))
										{
											dr[32] = "";
											dr[32] = "THIS H.I.T. IS NOT VALID FOR BGN";
											text += ";6|5,6";
										}
										if ((Operators.CompareString(left12, "17", TextCompare: false) == 0) | (Operators.CompareString(left12, "16", TextCompare: false) == 0))
										{
											dr[32] = Operators.ConcatenateObject("Verify Bom-should have negative qty item ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											text += ";6|5,6";
										}
										string left13 = Strings.Left(Conversions.ToString(dr[23]), 3);
										if (((Operators.CompareString(text4, "O-Kit", TextCompare: false) == 0) & (Operators.CompareString(left13, "LED", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "S3C O-Kit", TextCompare: false) == 0) & (Operators.CompareString(left13, "LED", TextCompare: false) == 0)))
										{
											string text44 = Conversions.ToString(dr[5]);
											if (text44.Contains("00K"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += "6|5,6";
												dr[32] = Operators.ConcatenateObject("00K Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if (((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(left3, "Welded", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(left3, "Welded", TextCompare: false) == 0)))
										{
											string text45 = Conversions.ToString(dr[5]);
											if (text45.Contains("WELD") | text45.Contains("WLD"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("WELD Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(left3, "Copper Tubing", TextCompare: false) == 0))
										{
											string text46 = Conversions.ToString(dr[5]);
											if (text46.Contains("TUBE"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("TUBE Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Fabricated Parts", TextCompare: false) == 0))
										{
											string text47 = Conversions.ToString(dr[5]);
											if (text47.Contains("SST") | text47.Contains("REFL") | text47.Contains("BASS"))
											{
												if ((Operators.CompareString(text17, "000", TextCompare: false) == 0) | (Operators.CompareString(text17, "", TextCompare: false) == 0))
												{
													text += ";4|12";
												}
												else
												{
													text += ";3|12";
													dr[32] = Operators.ConcatenateObject("Verify the Finish Color (SST, REFL, BASS) ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												}
											}
											if ((text47.Contains("OC") | text47.Contains("OPTIONAL COLOR") | text47.Contains("OPTNL COLOR")) && ((Operators.CompareString(text17, "000", TextCompare: false) == 0) | (Operators.CompareString(text17, "", TextCompare: false) == 0)))
											{
												text += ";3|12";
												dr[32] = Operators.ConcatenateObject("Verify the OPTIONAL Finish color ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										else if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Finished Tubes", TextCompare: false) == 0))
										{
											if (Operators.CompareString(text16, "", TextCompare: false) == 0)
											{
												text += ";4|11";
											}
											else
											{
												text += ";3|11";
												dr[32] = Operators.ConcatenateObject("Verify the Finish Code for Tubes ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text9, "Drawings MOA", TextCompare: false) == 0))
										{
											string text48 = Conversions.ToString(dr[5]);
											if (text48.Contains("INSTR") | text48.Contains("DIAGRAM") | text48.Contains("MANUAL") | text48.Contains("INSTRUCTION"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("INSTR or DIAGRAM, MANUAL Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text9, "Sticker Tags Etc", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text9, "Decal", TextCompare: false) == 0)))
										{
											string text49 = Conversions.ToString(dr[5]);
											if (text49.Contains("LABEL") | text49.Contains("STICKER"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("LABEL or STICKER Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										object objectValue = RuntimeHelpers.GetObjectValue(dr[9]);
										if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Adhesives and Sealants", TextCompare: false) == 0))
										{
											string text50 = Conversions.ToString(dr[5]);
											if (text50.Contains("ADHESIVE") | text50.Contains("GLUE") | text50.Contains("PASTE") | text50.Contains("PRIMER") | text50.Contains("SEAL") | text50.Contains("SEALANT") | text50.Contains("SEALER") | text50.Contains("TAPE"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("Adhesives & Sealants Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											if (Operators.ConditionalCompareObjectEqual(objectValue, "", TextCompare: false))
											{
												text += ";3|9";
												dr[32] = Operators.ConcatenateObject("Verify the EAU ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											else
											{
												text += ";6|9";
											}
										}
										if (Operators.CompareString(text26, "Buy", TextCompare: false) == 0)
										{
											if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Copper", TextCompare: false) == 0))
											{
												if (Operators.ConditionalCompareObjectEqual(objectValue, "", TextCompare: false))
												{
													text += ";3|9";
													dr[32] = Operators.ConcatenateObject("Verify the EAU for Copper Tube ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												}
												else
												{
													text += ";4|9";
												}
											}
											if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text9, "Lighting", TextCompare: false) == 0))
											{
												if (Operators.ConditionalCompareObjectEqual(objectValue, "", TextCompare: false))
												{
													text += ";3|9";
													dr[32] = Operators.ConcatenateObject("Verify the EAU for Lighting ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												}
												else
												{
													text += ";4|9";
												}
											}
											if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text9, "Sticker Tags Etc", TextCompare: false) == 0))
											{
												if (Operators.ConditionalCompareObjectEqual(objectValue, "", TextCompare: false))
												{
													text += ";3|9";
													dr[32] = Operators.ConcatenateObject("Verify the EAU for Sticker Tags Etc ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												}
												else
												{
													text += ";4|9";
												}
											}
											if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text9, "Decal", TextCompare: false) == 0))
											{
												if (Operators.ConditionalCompareObjectEqual(objectValue, "", TextCompare: false))
												{
													text += ";3|9";
													dr[32] = Operators.ConcatenateObject("Verify the EAU for Decal ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												}
												else
												{
													text += ";4|9";
												}
											}
											if ((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text10, "lb", TextCompare: false) == 0))
											{
												if (Operators.ConditionalCompareObjectEqual(objectValue, "", TextCompare: false))
												{
													text += ";3|9";
													dr[32] = Operators.ConcatenateObject("Verify the EAU Sheet Metal Raw Material ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
												}
												else
												{
													text += ";4|9";
												}
											}
										}
										if (((Operators.CompareString(text4, "Part", TextCompare: false) == 0) & (Operators.CompareString(text6, "Paint", TextCompare: false) == 0)) | ((Operators.CompareString(text4, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(text6, "Paint", TextCompare: false) == 0)))
										{
											string text51 = Conversions.ToString(dr[5]);
											if (text51.Contains("PAINT"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("Select the PAINT as noun in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if (Operators.CompareString(text4, "Retrofit-Kit", TextCompare: false) == 0)
										{
											string text52 = Conversions.ToString(dr[5]);
											if (text52.Contains("ECOV") & text52.Contains("RETROFIT"))
											{
												text += ";4|5,6";
											}
											else
											{
												text += ";6|5,6";
												dr[32] = Operators.ConcatenateObject("ECOV and RETROFIT Note Missing in Description ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
											}
										}
										if ((Operators.CompareString(left8, "I", TextCompare: false) == 0) | (Operators.CompareString(left8, "O", TextCompare: false) == 0) | (Operators.CompareString(left8, "Q", TextCompare: false) == 0) | (Operators.CompareString(left8, "S", TextCompare: false) == 0) | (Operators.CompareString(left8, "X", TextCompare: false) == 0) | (Operators.CompareString(left8, "Z", TextCompare: false) == 0))
										{
											text += ";3|4";
											dr[32] = Operators.ConcatenateObject("Revision Letter is not acceptable per ASME - Change the Revision Letter ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										else
										{
											text += ";4|4";
										}
										string text53 = string.Empty;
										int num3 = 5;
										do
										{
											string illegal_Character = MySettingsProperty.Settings.Illegal_Character;
											foreach (char c in illegal_Character)
											{
												try
												{
													if (Conversions.ToString(dr[num3]).Contains(Conversions.ToString(c)))
													{
														text53 = string.Concat(text53, "," + Conversions.ToString(num3));
														string text54 = Conversions.ToString(c);
														dr[32] = Operators.ConcatenateObject("Name has the illegal Character of : " + text54 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
														text += ";6|5";
													}
												}
												catch (Exception ex4)
												{
													ProjectData.SetProjectError(ex4);
													Exception ex5 = ex4;
													ProjectData.ClearProjectError();
												}
											}
											num3++;
										}
										while (num3 <= 5);
										string text55 = string.Empty;
										int num4 = 6;
										do
										{
											string illegal_Character2 = MySettingsProperty.Settings.Illegal_Character;
											foreach (char c2 in illegal_Character2)
											{
												try
												{
													if (Conversions.ToString(dr[num4]).Contains(Conversions.ToString(c2)))
													{
														text55 = string.Concat(text55, "," + Conversions.ToString(num4));
														string text56 = Conversions.ToString(c2);
														dr[32] = Operators.ConcatenateObject("Description has the illegal Character of : " + text56 + " ,\n", NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
														text += ";6|6";
													}
												}
												catch (Exception ex6)
												{
													ProjectData.SetProjectError(ex6);
													Exception ex7 = ex6;
													ProjectData.ClearProjectError();
												}
											}
											num4++;
										}
										while (num4 <= 6);
										string text57 = Conversions.ToString(dr[32]);
										if (!text57.Contains("Name and Descripton is Not Matching"))
										{
											text += ";4|5";
											text += ";4|6";
										}
										string value = "Pass";
										if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null), "", TextCompare: false))
										{
											dr[32] = value;
											text += ";4|32,2,3";
										}
										else if (Operators.ConditionalCompareObjectNotEqual(dr[32], "", TextCompare: false))
										{
											text += ";6|32,2,3";
										}
										string text58 = Conversions.ToString(NewLateBinding.LateGet(dr[32], null, "Substring", new object[1] { 0 }, null, null, null));
										if (Operators.ConditionalCompareObjectNotEqual(dr[32], "Pass", TextCompare: false))
										{
											dr[32] = text58.Remove(text58.LastIndexOf(","));
										}
									}
									if (Operators.CompareString(text4, "Legacy", TextCompare: false) == 0)
									{
										dr[32] = "Legacy Part";
										text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
									}
									if (Operators.CompareString(text7, "", TextCompare: false) == 0)
									{
										dr[32] = "Part Not Validated - ERD-0021 BGN-TC Attribute CheckSheet Program Rules";
										text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
									}
								}
							}
							else if (Operators.CompareString(Declarations.SiteLoc, "Monterrey", TextCompare: false) == 0)
							{
								if (((Operators.CompareString(left, "Monterrey", TextCompare: false) == 0) & (Operators.CompareString(left2, "Legacy", TextCompare: false) == 0)) | (text3.Contains("MTY RELEASED") & (Operators.CompareString(left2, "Legacy", TextCompare: false) == 0)))
								{
									dr[31] = "Legacy Part - Verification not Performed, Please Cross Check the Details";
									text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,28";
								}
								else if (((Operators.CompareString(left, "Monterrey", TextCompare: false) == 0) & (Operators.CompareString(left2, "Legacy", TextCompare: false) != 0)) | ((Operators.CompareString(left, "Tijuana", TextCompare: false) == 0) & (Operators.CompareString(left2, "Legacy", TextCompare: false) != 0)) | (text3.Contains("MTY RELEASED") & !text3.Contains("MTY Discontinued") & (Operators.CompareString(left2, "Legacy", TextCompare: false) != 0)))
								{
									XmlDocument xmlDocument2 = new XmlDocument();
									string text59 = Application.StartupPath + "\\MTY-DataBase.XML";
									if (!File.Exists(text59))
									{
										Interaction.MsgBox("File does not exist: " + text59);
										return;
									}
									try
									{
										xmlDocument2.Load(text59);
									}
									catch (Exception ex8)
									{
										ProjectData.SetProjectError(ex8);
										Exception prompt2 = ex8;
										Interaction.MsgBox(prompt2);
										ProjectData.ClearProjectError();
									}
									text60 = Conversions.ToString(dr[16]);
									string text61 = Conversions.ToString(dr[25]);
									string left14 = Conversions.ToString(dr[12]);
									string text62 = Conversions.ToString(dr[11]);
									string text63 = Conversions.ToString(dr[8]);
									string text64 = Conversions.ToString(dr[14]);
									text65 = Conversions.ToString(dr[15]);
									text66 = "";
									if (Operators.CompareString(left, "Tijuana", TextCompare: false) != 0)
									{
										text66 = Conversions.ToString(dr[28]);
									}
									string left15 = Conversions.ToString(dr[8]);
									text67 = null;
									string text68 = Conversions.ToString(dr[23]);
									string text69 = "";
									string text70 = null;
									text70 = Strings.Left(Conversions.ToString(dr[5]), 7).ToUpper();
									XmlNodeList xmlNodeList15 = xmlDocument2.SelectNodes("//Kit-1/Subcategory");
									if (Operators.CompareString(text60, "Case", TextCompare: false) == 0)
									{
										text67 = "Case";
									}
									string str2 = Conversions.ToString(dr[3]);
									string left16 = Strings.Left(str2, 1);
									string left17 = Strings.Left(str2, 2);
									string source = Strings.Left(str2, 3);
									string left18 = Strings.Right(str2, 1);
									string left19 = Strings.Right(str2, 3);
									string text71 = Conversions.ToString(dr[5]);
									string left20 = "";
									if ((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0 || ((Operators.CompareString(text60, "Assembly", TextCompare: false) == 0) & text71.Contains("ASSY"))) | text71.Contains("ASSEMBLY"))
									{
										text67 = "Assembly";
									}
									if (((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & text71.Contains("MODULE") & (Operators.CompareString(text60, "Module", TextCompare: false) == 0)) || Operators.CompareString(text60, "Module", TextCompare: false) == 0)
									{
										text67 = "Assy-Module";
										left20 = "Module";
									}
									if (((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & (Operators.CompareString(left20, "", TextCompare: false) == 0) & text71.Contains("TUBE")) | text71.Contains("TUBING"))
									{
										text67 = "Assy-Tube";
									}
									if ((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & (Operators.CompareString(text65, "Frames RI", TextCompare: false) == 0) & text71.Contains("FRAME"))
									{
										text67 = "Assy-Frame";
									}
									if ((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & (Operators.CompareString(text65, "Foam RI", TextCompare: false) == 0) & text71.Contains("FOAM"))
									{
										text67 = "Assy-Foam";
									}
									if ((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & (Operators.CompareString(text65, "Coil", TextCompare: false) == 0) & text71.Contains("COIL"))
									{
										text67 = "Assy-Coil";
									}
									if (((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & (Operators.CompareString(text65, "Welded", TextCompare: false) == 0) & text71.Contains("WELD")) || ((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & (Operators.CompareString(text65, "Welded", TextCompare: false) == 0)))
									{
										text67 = "Assy-Weld";
									}
									if ((Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0) & (Operators.CompareString(text65, "Doors RI", TextCompare: false) == 0) & text71.Contains("DOOR"))
									{
										text67 = "Assy-Door";
									}
									if ((Operators.CompareString(text60, "Assembly", TextCompare: false) == 0) & (Operators.CompareString(left15, "Buy", TextCompare: false) == 0))
									{
										text67 = "Assembly-Buy";
									}
									if ((Operators.CompareString(text60, "Kit", TextCompare: false) == 0) & (Operators.CompareString(text64, "Options", TextCompare: false) == 0) & (Operators.CompareString(text65, "Option Kit", TextCompare: false) == 0))
									{
										text67 = "Kit-1";
									}
									if ((Operators.CompareString(text60, "Kit", TextCompare: false) == 0) & (Operators.CompareString(text64, "Options", TextCompare: false) == 0) & (Operators.CompareString(text65, "Option Kit RI/FW/Insight", TextCompare: false) == 0))
									{
										text67 = "Kit-2";
									}
									if (((Operators.CompareString(text60, "Kit", TextCompare: false) == 0) & (Operators.CompareString(text65, "Option Kit", TextCompare: false) == 0) & (Operators.CompareString(text66, "0", TextCompare: false) == 0)) || ((Operators.CompareString(text60, "Kit", TextCompare: false) == 0) & (Operators.CompareString(text65, "Option Kit", TextCompare: false) == 0) & (Operators.CompareString(text66, "1", TextCompare: false) == 0)))
									{
										text67 = "Kit-1";
									}
									if (((Operators.CompareString(text60, "Kit", TextCompare: false) == 0) & (Operators.CompareString(text64, "Options", TextCompare: false) == 0) & (Operators.CompareString(text70, "KIT-EXT", TextCompare: false) == 0)) || ((Operators.CompareString(text60, "Kit", TextCompare: false) == 0) & (Operators.CompareString(text64, "Options", TextCompare: false) == 0) & (Operators.CompareString(text70, "KIT-INT", TextCompare: false) == 0)))
									{
										text67 = "Kit-3";
									}
									if ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(left15, "Buy", TextCompare: false) == 0) & (Operators.CompareString(text64, "Formed Metal - Outsourced", TextCompare: false) != 0))
									{
										text67 = "Purchased-Part";
									}
									if (Operators.CompareString(text64, "Formed Metal - Outsourced", TextCompare: false) == 0)
									{
										text67 = "Purchased-PartFM";
									}
									if ((Operators.CompareString(text64, "Reference MOA & Diagram", TextCompare: false) == 0) & (Operators.CompareString(text60, "Legacy", TextCompare: false) != 0))
									{
										text67 = "Part-MOA";
									}
									if ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(text64, "Fabricated Parts", TextCompare: false) == 0) & (Operators.CompareString(left14, "000", TextCompare: false) == 0))
									{
										text67 = "SheetMetal-NonPaint";
									}
									if ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(text64, "Fabricated Parts", TextCompare: false) == 0) & (Operators.CompareString(left14, "000", TextCompare: false) != 0))
									{
										text67 = "SheetMetal-Paint";
									}
									List<string> list = new List<string> { "Miscellaneous Tubing", "Tubing Fab Assemblies", "Tubing Fab Parts", "Copper Tubing", "Copper Tubing RI/FW/Insight", "Steel Tubing" };
									if (((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(text64, "Fabricated Parts", TextCompare: false) == 0) & text65.Contains("Tubing")) || ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(text64, "Finished Tubes", TextCompare: false) == 0) & text65.Contains("Tubing")))
									{
										text67 = "MP-CopperTube";
									}
									if ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(left15, "COP", TextCompare: false) == 0))
									{
										text67 = "COP";
									}
									List<string> list2 = new List<string> { "Acrylic", "Plastic", "Steel Tubing", "Wire Goods", "Wood", "Metal Cut Down", "Plastic RI/FW/Insight" };
									foreach (string item15 in list2)
									{
										if (Operators.CompareString(text65, item15, TextCompare: false) == 0)
										{
											if ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(text64, "Fabricated Parts", TextCompare: false) == 0))
											{
												text67 = "MF-Parts";
											}
											break;
										}
									}
									if ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(left15, "Buy", TextCompare: false) == 0) & (Operators.CompareString(text64, "Copper", TextCompare: false) == 0) & (Operators.CompareString(text65, "Copper Tubing", TextCompare: false) == 0))
									{
										text67 = "RM-Copper";
									}
									if ((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(left15, "Buy", TextCompare: false) == 0) & (Operators.CompareString(text64, "Steel", TextCompare: false) == 0))
									{
										text67 = "RM-SheetMetal";
									}
									if ((Operators.CompareString(left16, "Y", TextCompare: false) == 0 || Operators.CompareString(left17, "IC", TextCompare: false) == 0 || source.All(char.IsDigit)) && (((((((Operators.CompareString(text60, "Kit", TextCompare: false) == 0) | ((Operators.CompareString(text60, "S-Kit", TextCompare: false) == 0) & source.All(char.IsDigit))) || Operators.CompareString(text60, "Kit", TextCompare: false) == 0) | ((Operators.CompareString(text60, "S-Kit", TextCompare: false) == 0) & (Operators.CompareString(left16, "Y", TextCompare: false) == 0))) || Operators.CompareString(text60, "Kit", TextCompare: false) == 0) | ((Operators.CompareString(text60, "S-Kit", TextCompare: false) == 0) & (Operators.CompareString(left17, "IC", TextCompare: false) == 0))) || Operators.CompareString(text60, "S-Kit", TextCompare: false) == 0))
									{
										text67 = "S-Kit";
									}
									if (((Operators.CompareString(text60, "S-Kit", TextCompare: false) == 0) & (Operators.CompareString(left18, "K", TextCompare: false) == 0)) || ((Operators.CompareString(text60, "S-Kit", TextCompare: false) == 0) & (Operators.CompareString(left19, "KIT", TextCompare: false) == 0)))
									{
										text67 = "S-Kit1";
									}
									if (((Operators.CompareString(text64, "Option Class", TextCompare: false) == 0) & (Operators.CompareString(left17, "1H", TextCompare: false) == 0)) || ((Operators.CompareString(text64, "Option Class", TextCompare: false) == 0) & (Operators.CompareString(left17, "2H", TextCompare: false) == 0)) || ((Operators.CompareString(text64, "Option Class", TextCompare: false) == 0) & (Operators.CompareString(left17, "3H", TextCompare: false) == 0)))
									{
										text67 = "Option-Class";
									}
									if (Operators.CompareString(text60, "Legacy", TextCompare: false) == 0)
									{
										text67 = "Legacy";
									}
									if (!((Operators.CompareString(text60, "Part", TextCompare: false) == 0) & (Operators.CompareString(text64, "Assemblies", TextCompare: false) == 0)))
									{
										if ((Operators.CompareString(text67, "", TextCompare: false) == 0) & (Operators.CompareString(text67, "Legacy", TextCompare: false) == 0))
										{
											dr[31] = Operators.ConcatenateObject("Hussmann Item Type - Group is Missing : " + text60 + "High Level Cat : " + text64 + "\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
										}
										else if (Operators.CompareString(text67, "Legacy", TextCompare: false) == 0)
										{
											dr[31] = "Legacy Part";
											text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,28";
										}
										else if (text67 != null)
										{
											XmlNodeList xmlNodeList16 = xmlDocument2.SelectNodes("//" + text67 + "/High_Level_Category");
											xmlNodeList15 = xmlDocument2.SelectNodes("//" + text67 + "/Subcategory");
											XmlNodeList xmlNodeList17 = xmlDocument2.SelectNodes("//" + text67 + "/Unit_of_Measure");
											xmlNodeList18 = xmlDocument2.SelectNodes("//" + text67 + "/Product_Family");
											xmlNodeList19 = xmlDocument2.SelectNodes("//" + text67 + "/Model_Group");
											xmlNodeList20 = xmlDocument2.SelectNodes("//" + text67 + "/Product_Line");
											xmlNodeList21 = xmlDocument2.SelectNodes("//" + text67 + "/Finish_Code");
											xmlNodeList22 = xmlDocument2.SelectNodes("//" + text67 + "/Finish_Color");
											xmlNodeList23 = xmlDocument2.SelectNodes("//" + text67 + "/Master_Template");
											XmlNodeList xmlNodeList24 = xmlDocument2.SelectNodes("//" + text67 + "/Source");
											xmlNodeList25 = xmlDocument2.SelectNodes("//" + text67 + "/Mapics_Item_Type");
											string text72 = Conversions.ToString(dr[14]);
											foreach (XmlNode item16 in xmlNodeList16)
											{
												if (!item16.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode15 in item16.ChildNodes)
												{
													innerText12 = childNode15.InnerText;
													if (Operators.CompareString(innerText12, text72, TextCompare: false) == 0)
													{
														goto end_IL_68c8;
													}
													if (Operators.CompareString(innerText12, text72, TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_68c8:
												break;
											}
											string text73 = Conversions.ToString(dr[15]);
											foreach (XmlNode item17 in xmlNodeList15)
											{
												if (!item17.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode16 in item17.ChildNodes)
												{
													innerText13 = childNode16.InnerText;
													if (Operators.CompareString(innerText13, text73, TextCompare: false) == 0)
													{
														goto end_IL_6a2d;
													}
													if (Operators.CompareString(innerText13, text73, TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_6a2d:
												break;
											}
											string right2 = Conversions.ToString(dr[22]);
											foreach (XmlNode item18 in xmlNodeList17)
											{
												if (!item18.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode17 in item18.ChildNodes)
												{
													innerText14 = childNode17.InnerText;
													if (Operators.CompareString(innerText14, right2, TextCompare: false) == 0)
													{
														goto end_IL_6b92;
													}
													if (Operators.CompareString(innerText14, right2, TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_6b92:
												break;
											}
											string text74 = Conversions.ToString(dr[5]);
											text75 = ((!text74.Contains("00K")) ? Conversions.ToString(dr[23]) : Strings.Left(Conversions.ToString(dr[23]), 3));
											foreach (XmlNode item19 in xmlNodeList18)
											{
												if (!item19.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode18 in item19.ChildNodes)
												{
													innerText15 = childNode18.InnerText;
													if (Operators.CompareString(innerText15, text75, TextCompare: false) == 0)
													{
														goto end_IL_6d46;
													}
													if (Operators.CompareString(innerText15, text75, TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_6d46:
												break;
											}
											text76 = Conversions.ToString(dr[25]);
											foreach (XmlNode item20 in xmlNodeList19)
											{
												if (!item20.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode19 in item20.ChildNodes)
												{
													innerText16 = childNode19.InnerText;
													if (Operators.CompareString(innerText16, text76, TextCompare: false) == 0)
													{
														goto end_IL_6eab;
													}
													if (Operators.CompareString(innerText16, text76, TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_6eab:
												break;
											}
											text77 = Conversions.ToString(dr[24]);
											foreach (XmlNode item21 in xmlNodeList20)
											{
												if (!item21.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode20 in item21.ChildNodes)
												{
													innerText17 = childNode20.InnerText;
													if (Operators.CompareString(innerText17.ToLower(), text77.ToLower(), TextCompare: false) == 0)
													{
														goto end_IL_7027;
													}
													if (Operators.CompareString(innerText17.ToLower(), text77.ToLower(), TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_7027:
												break;
											}
											text78 = Conversions.ToString(dr[11]);
											foreach (XmlNode item22 in xmlNodeList21)
											{
												if (!item22.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode21 in item22.ChildNodes)
												{
													innerText18 = childNode21.InnerText;
													if (Operators.CompareString(innerText18.ToLower(), text78.ToLower(), TextCompare: false) == 0)
													{
														goto end_IL_71a3;
													}
													if (Operators.CompareString(innerText18.ToLower(), text78.ToLower(), TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_71a3:
												break;
											}
											text79 = Conversions.ToString(dr[12]);
											foreach (XmlNode item23 in xmlNodeList22)
											{
												if (!item23.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode22 in item23.ChildNodes)
												{
													innerText19 = childNode22.InnerText;
													if (Operators.CompareString(innerText19, text79, TextCompare: false) == 0)
													{
														goto end_IL_7308;
													}
													if (Operators.CompareString(innerText19, text79, TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_7308:
												break;
											}
											text80 = Conversions.ToString(dr[17]);
											foreach (XmlNode item24 in xmlNodeList23)
											{
												if (!item24.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode23 in item24.ChildNodes)
												{
													innerText20 = childNode23.InnerText;
													if (Operators.CompareString(innerText20.ToUpper(), text80.ToUpper(), TextCompare: false) == 0)
													{
														goto end_IL_7484;
													}
													if (Operators.CompareString(innerText20.ToUpper(), text80.ToUpper(), TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_7484:
												break;
											}
											text81 = Conversions.ToString(dr[8]);
											foreach (XmlNode item25 in xmlNodeList24)
											{
												if (!item25.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode24 in item25.ChildNodes)
												{
													innerText21 = childNode24.InnerText;
													if (Operators.CompareString(innerText21.ToUpper(), text81.ToUpper(), TextCompare: false) == 0)
													{
														goto end_IL_75ff;
													}
													if (Operators.CompareString(innerText21.ToUpper(), text81.ToUpper(), TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_75ff:
												break;
											}
											text82 = text66;
											foreach (XmlNode item26 in xmlNodeList25)
											{
												if (!item26.HasChildNodes)
												{
													continue;
												}
												foreach (XmlNode childNode25 in item26.ChildNodes)
												{
													innerText22 = childNode25.InnerText;
													if (Operators.CompareString(innerText22, text82, TextCompare: false) == 0)
													{
														goto end_IL_775d;
													}
													if (Operators.CompareString(innerText22, text82, TextCompare: false) == 0)
													{
													}
												}
												continue;
												end_IL_775d:
												break;
											}
											if (Operators.CompareString(innerText12, text72, TextCompare: false) == 0)
											{
												if (xmlNodeList16.Count == 1)
												{
													text += ";4|14";
												}
												else if (Operators.CompareString(text67, "S-Kit1", TextCompare: false) == 0)
												{
													text += ";4|14";
												}
												else
												{
													text += ";6|14";
													dr[31] = Operators.ConcatenateObject("Verify the High Level Catagory, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
												}
											}
											else if (Operators.CompareString(innerText12, text72, TextCompare: false) != 0)
											{
												string text83 = null;
												if ((xmlNodeList16.Count == 1) & (Operators.CompareString(innerText12, "", TextCompare: false) == 0))
												{
													text83 = "Should be None";
													text += ";3|14";
												}
												else if ((xmlNodeList16.Count == 1) & (Operators.CompareString(innerText12, "", TextCompare: false) != 0))
												{
													text83 = "Should be " + innerText12;
													text += ";3|14";
												}
												else if (Operators.CompareString(text72, "", TextCompare: false) == 0)
												{
													text83 = "is Missing";
													text += ";3|14";
												}
												else
												{
													text83 = "is incorrect";
													text += ";3|14";
												}
												dr[31] = Operators.ConcatenateObject("High Level Catagory " + text83 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											if (Operators.CompareString(text81.ToUpper(), innerText21.ToUpper(), TextCompare: false) == 0)
											{
												text += ";4|8";
											}
											else if (Operators.CompareString(text81.ToUpper(), innerText21.ToUpper(), TextCompare: false) != 0)
											{
												string text84 = null;
												text84 = innerText21;
												dr[31] = Operators.ConcatenateObject("Source Should be " + text84 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
												text += ";3|8";
											}
											if (Operators.CompareString(innerText13, text73, TextCompare: false) == 0)
											{
												if (xmlNodeList15.Count == 1)
												{
													text += ";4|15";
												}
												else
												{
													text += ";6|15";
													dr[31] = Operators.ConcatenateObject("Verify Subcategory, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
													if (Operators.CompareString(text67, "S-Kit1", TextCompare: false) == 0)
													{
														text += ";4|15";
													}
													else if (dr[31].ToString().Contains("Verify Subcategory"))
													{
														text += ";6|15";
													}
													else if (Operators.CompareString(text67, "Assembly", TextCompare: false) == 0)
													{
														text += ";6|15";
														dr[31] = Operators.ConcatenateObject("Verify Subcategory and Mapics Item type-Assemblies for non RI cases should be Assembly item type 0, Assemblies for RI cases should be either Frames RI or Doors RI with Mapics item type 1 OR Foam RI or Coil with Mapics item type 2 , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
													}
													else if (Operators.CompareString(text67, "Assy-Frame", TextCompare: false) == 0 || Operators.CompareString(text67, "Assy-Weld", TextCompare: false) == 0)
													{
														text += ";6|15";
														dr[31] = Operators.ConcatenateObject("Verify Subcategory-RI cases should be Frames RI, non RI cases should be Assembly or Welded , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
													}
													else
													{
														switch (text67)
														{
														case "Assy-Foam":
															text += ";6|15";
															dr[31] = Operators.ConcatenateObject("Verify Subcategory-RI cases should be Foam RI, non RI cases should be Assembly , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
															break;
														case "Assy-Door":
															text += ";6|15";
															dr[31] = Operators.ConcatenateObject("Verify Subcategory-RI cases should be Doors RI, non RI cases should be Assembly , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
															break;
														case "Assy-Coil":
															text += ";6|15";
															dr[31] = Operators.ConcatenateObject("Verify Subcategory-RI cases should be Coil, non RI cases should be Assembly , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
															break;
														default:
															if (Operators.CompareString(text67, "Purchased-Part", TextCompare: false) != 0)
															{
																if (Operators.CompareString(text67, "S-Kit1", TextCompare: false) == 0 || Operators.CompareString(text67, "Kit-1", TextCompare: false) == 0 || Operators.CompareString(text67, "Kit-2", TextCompare: false) == 0)
																{
																	text += ";6|15";
																	if (Operators.CompareString(text60, "Kit", TextCompare: false) == 0)
																	{
																		dr[31] = Operators.ConcatenateObject("Verify Subcategory and Mapics Item type-non Self-contained kits should be Option Kit RI/FW/Insight with Mapics item type 0, Self-contained kits should be Option Kit with Mapics item type 1 , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
																	}
																	else
																	{
																		dr[31] = Operators.ConcatenateObject("Verify the Subcategory , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
																	}
																}
																break;
															}
															goto case "Assembly-Buy";
														case "Assembly-Buy":
															text += ";6|15";
															dr[31] = Operators.ConcatenateObject("Verify the Subcategory , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
															break;
														}
													}
												}
											}
											else if (Operators.CompareString(innerText13, text73, TextCompare: false) != 0)
											{
												string text85 = null;
												if ((xmlNodeList15.Count == 1) & (Operators.CompareString(innerText13, "", TextCompare: false) == 0))
												{
													text85 = "Should be None";
													text += ";3|15";
												}
												else if ((xmlNodeList15.Count == 1) & (Operators.CompareString(innerText13, "", TextCompare: false) != 0))
												{
													text85 = "Should be " + innerText13;
													text += ";3|15";
												}
												else if (Operators.CompareString(text73, "", TextCompare: false) == 0)
												{
													text85 = "is Missing";
													text += ";3|15";
												}
												else
												{
													text85 = "is incorrect";
													text += ";3|15";
												}
												dr[31] = Operators.ConcatenateObject("Subcategory " + text85 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
											}
											if (Operators.CompareString(innerText14, right2, TextCompare: false) == 0)
											{
												text += ";4|22";
											}
											else if (Operators.CompareString(innerText14, right2, TextCompare: false) != 0)
											{
												string text86 = null;
												text86 = ((xmlNodeList17.Count != 1) ? "is incorrect" : ("Should be " + innerText14));
												dr[31] = Operators.ConcatenateObject("Unit " + text86 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
												text += ";3|22";
											}
											switch (text67)
											{
											default:
												if (Operators.CompareString(text67, "Kit-3", TextCompare: false) != 0)
												{
													if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(text81, "Make", TextCompare: false) == 0, Operators.CompareObjectEqual(dr[9], "", TextCompare: false))))
													{
														text += ";4|9";
													}
													else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(text81, "Make", TextCompare: false) == 0, Operators.CompareObjectNotEqual(dr[9], "", TextCompare: false))))
													{
														text += ";0|9";
													}
													break;
												}
												goto case "S-Kit";
											case "S-Kit":
											case "Kit-1":
											case "Kit-2":
												text += ";0|9";
												break;
											}
											string left21 = Conversions.ToString(dr[4]);
											if (Operators.CompareString(text73, "Drawings MOA", TextCompare: false) != 0)
											{
												if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dr[9], "", TextCompare: false), Operators.CompareString(text81, "Make", TextCompare: false) == 0), Operators.CompareString(left21, "A", TextCompare: false) != 0)) || Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dr[9], "", TextCompare: false), Operators.CompareString(text81, "Buy", TextCompare: false) == 0), Operators.CompareString(left21, "A", TextCompare: false) != 0))))
												{
													text += ";6|9";
													dr[31] = Operators.ConcatenateObject("Verify EAU ,\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
												}
												else if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dr[9], "", TextCompare: false), Operators.CompareString(text81, "Buy", TextCompare: false) == 0)) || Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(dr[9], "", TextCompare: false), Operators.CompareString(text81, "Make", TextCompare: false) == 0))))
												{
													text += ";4|9";
												}
												else if (Conversions.ToBoolean(Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dr[9], "", TextCompare: false), Operators.CompareString(text81, "Buy", TextCompare: false) == 0), Operators.CompareString(left21, "A", TextCompare: false) == 0)) || Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dr[9], "", TextCompare: false), Operators.CompareString(text81, "Make", TextCompare: false) == 0), Operators.CompareString(left21, "A", TextCompare: false) == 0))))
												{
													text += ";3|9";
													dr[31] = Operators.ConcatenateObject("EAU Values are Missing ,\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
												}
											}
											else
											{
												text += ";0|9";
											}
											if (Operators.CompareString(text67, "Option-Class", TextCompare: false) != 0)
											{
												switch (text60)
												{
												case "Kit":
												case "Module":
												case "S-Kit":
													goto IL_864d;
												}
												if (Operators.CompareString(text60, "Case", TextCompare: false) != 0)
												{
													goto IL_868c;
												}
											}
											goto IL_864d;
										}
										goto IL_a168;
									}
									text += ";3|14,15";
									text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,16,17,18,19,20,21,22,23,24,25,28";
									dr[31] = Operators.ConcatenateObject("Item Type 'Part' cannot have 'Assemblies' HLC or 'Phantom And Module SubCategory' - Part is not Valid ?\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							goto IL_a22c;
							IL_864d:
							text = ((!Operators.ConditionalCompareObjectEqual(dr[9], "", TextCompare: false)) ? (text + ";3|9") : (text + ";0|9"));
							goto IL_868c;
							IL_a22c:
							try
							{
								dt.Rows.Add(dr);
								dr[0] = text;
							}
							catch (Exception ex9)
							{
								ProjectData.SetProjectError(ex9);
								Exception ex10 = ex9;
								ProjectData.ClearProjectError();
							}
							objInput.Progress_bar.PerformStep();
							num2++;
							continue;
							IL_868c:
							string text87 = Conversions.ToString(dr[5]);
							if (Operators.CompareString(innerText15, text75, TextCompare: false) == 0)
							{
								if (xmlNodeList18.Count == 1)
								{
									text += ";4|23";
								}
								else
								{
									text += ";6|23";
									dr[31] = Operators.ConcatenateObject("Verify the Product Family, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							else if (Operators.CompareString(innerText15, text75, TextCompare: false) != 0)
							{
								string text88 = null;
								if ((xmlNodeList18.Count == 1) & (Operators.CompareString(innerText15, "", TextCompare: false) == 0))
								{
									text88 = "Should be None";
									text += ";3|23";
								}
								else if ((xmlNodeList18.Count == 1) & (Operators.CompareString(innerText15, "", TextCompare: false) != 0))
								{
									text88 = "Should be " + innerText15;
									text += ";3|23";
								}
								else if (Operators.CompareString(text75, "", TextCompare: false) == 0)
								{
									text88 = "is Missing";
									text += ";3|23";
								}
								else if (text87.Contains("00K") & (Operators.CompareString(text75, "LED", TextCompare: false) != 0))
								{
									text88 = "needs to start with LED";
									text += ";3|23";
								}
								else
								{
									text88 = "is incorrect";
									text += ";3|23";
								}
								dr[31] = Operators.ConcatenateObject("Product Family " + text88 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
							}
							if (Operators.CompareString(innerText16, text76, TextCompare: false) == 0)
							{
								if (xmlNodeList19.Count == 1)
								{
									text += ";4|25";
								}
								else
								{
									text += ";6|25";
									dr[31] = Operators.ConcatenateObject("Verify the Model Group, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							else if (Operators.CompareString(innerText16, text76, TextCompare: false) != 0)
							{
								string text89 = null;
								if ((xmlNodeList19.Count == 1) & (Operators.CompareString(innerText16, "", TextCompare: false) == 0))
								{
									text89 = "Should be None";
									text += ";3|25";
								}
								else if ((xmlNodeList19.Count == 1) & (Operators.CompareString(innerText16, "", TextCompare: false) != 0))
								{
									text89 = "Should be " + innerText16;
									text += ";3|25";
								}
								else if (Operators.CompareString(text76, "", TextCompare: false) == 0)
								{
									text89 = "is Missing";
									text += ";3|25";
								}
								else
								{
									text89 = "is incorrect";
									text += ";3|25";
								}
								dr[31] = Operators.ConcatenateObject("Model Group " + text89 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
							}
							if (Operators.CompareString(innerText17.ToLower(), text77.ToLower(), TextCompare: false) == 0)
							{
								if (xmlNodeList20.Count == 1)
								{
									text += ";4|24";
								}
								else
								{
									text += ";6|24";
									dr[31] = Operators.ConcatenateObject("Verify the Product Line, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							else if (Operators.CompareString(innerText17.ToLower(), text77.ToLower(), TextCompare: false) != 0)
							{
								string text90 = null;
								if ((xmlNodeList20.Count == 1) & (Operators.CompareString(innerText17, "", TextCompare: false) == 0))
								{
									text90 = "Should be None";
									text += ";3|24";
								}
								else if ((xmlNodeList20.Count == 0) & (Operators.CompareString(innerText17, "", TextCompare: false) != 0))
								{
									text90 = "Should be " + innerText17;
									text += ";3|24";
								}
								else if (Operators.CompareString(text77, "", TextCompare: false) == 0)
								{
									text90 = "is Missing";
									text += ";3|24";
								}
								else
								{
									text90 = "is incorrect";
									text += ";3|24";
								}
								if (Operators.CompareString(text67, "S-Kit", TextCompare: false) == 0)
								{
									text += ";4|24";
								}
								else
								{
									dr[31] = Operators.ConcatenateObject("Product Line " + text90 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							if (Operators.CompareString(innerText18, text78, TextCompare: false) == 0)
							{
								if (xmlNodeList21.Count == 1)
								{
									text += ";4|11";
								}
								else
								{
									text += ";6|11";
									dr[31] = Operators.ConcatenateObject("Verify the Finish Code, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
								if (Operators.CompareString(text67, "Assembly-Buy", TextCompare: false) == 0 || Operators.CompareString(text67, "Purchased-Part", TextCompare: false) == 0)
								{
									text += ";6|11";
									dr[31] = Operators.ConcatenateObject("Verify the Finish Code, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
								switch (text67)
								{
								default:
									if (Operators.CompareString(text81, "Buy", TextCompare: false) != 0)
									{
										break;
									}
									goto case "S-Kit";
								case "S-Kit":
								case "Kit-1":
								case "Kit-2":
								case "Kit-3":
								case "COP":
									text += ";0|11";
									break;
								}
							}
							else if (Operators.CompareString(innerText18, text78, TextCompare: false) != 0)
							{
								string text91 = null;
								if ((xmlNodeList21.Count == 1) & (Operators.CompareString(innerText18, "", TextCompare: false) == 0))
								{
									text91 = "should be None";
									text += ";3|11";
								}
								else if ((xmlNodeList21.Count == 1) & (Operators.CompareString(innerText18, "", TextCompare: false) != 0))
								{
									text91 = "Should be " + innerText18;
									text += ";3|11";
								}
								else if (Operators.CompareString(text78, "", TextCompare: false) == 0)
								{
									text91 = "is Missing";
									text += ";3|11";
								}
								switch (text67)
								{
								default:
									if (Operators.CompareString(text81, "Buy", TextCompare: false) != 0)
									{
										dr[31] = Operators.ConcatenateObject("Finish Code " + text91 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
										break;
									}
									goto case "S-Kit";
								case "S-Kit":
								case "Case":
								case "Kit-1":
								case "Kit-2":
								case "Kit-3":
								case "COP":
									text += ";0|11";
									break;
								}
							}
							if (Operators.CompareString(innerText19, text79, TextCompare: false) == 0)
							{
								if (xmlNodeList22.Count == 1)
								{
									text += ";4|12";
								}
								else
								{
									text += ";6|12";
									dr[31] = Operators.ConcatenateObject("Verify the Finish Color, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
								if (Operators.CompareString(text67, "Assembly-Buy", TextCompare: false) == 0 || Operators.CompareString(text67, "Purchased-Part", TextCompare: false) == 0)
								{
									text += ";6|12";
									dr[31] = Operators.ConcatenateObject("Verify the Finish Color, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
								switch (text67)
								{
								default:
									if (Operators.CompareString(text81, "Buy", TextCompare: false) != 0)
									{
										break;
									}
									goto case "S-Kit";
								case "S-Kit":
								case "Kit-1":
								case "Kit-2":
								case "Kit-3":
								case "COP":
									text += ";0|12";
									break;
								}
							}
							else if (Operators.CompareString(innerText19, text79, TextCompare: false) != 0)
							{
								string text92 = null;
								if ((xmlNodeList22.Count == 1) & (Operators.CompareString(innerText19, "", TextCompare: false) == 0))
								{
									text92 = "Should be None";
									text += ";3|12";
								}
								else if ((xmlNodeList22.Count == 1) & (Operators.CompareString(innerText19, "", TextCompare: false) != 0))
								{
									text92 = "Should be " + innerText19;
									text += ";3|12";
								}
								else if (Operators.CompareString(text79, "", TextCompare: false) == 0)
								{
									text92 = " - is Missing";
									text += ";3|12";
								}
								switch (text67)
								{
								default:
									if (Operators.CompareString(text81, "Buy", TextCompare: false) != 0)
									{
										dr[31] = Operators.ConcatenateObject("Finish Color " + text92 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
										break;
									}
									goto case "S-Kit";
								case "S-Kit":
								case "Case":
								case "Kit-1":
								case "Kit-2":
								case "Kit-3":
								case "COP":
									text += ";0|12";
									break;
								}
							}
							if (Operators.CompareString(text60, "Kit", TextCompare: false) == 0 || Operators.CompareString(text60, "S-Kit", TextCompare: false) == 0 || Operators.CompareString(text60, "Case", TextCompare: false) == 0)
							{
								if (Operators.ConditionalCompareObjectEqual(dr[3], dr[7], TextCompare: false))
								{
									text += ";4|7";
								}
								else if (Operators.ConditionalCompareObjectNotEqual(dr[3], dr[7], TextCompare: false))
								{
									string text93 = "Should be - " + dr[3].ToString();
									text += ";3|7";
									dr[31] = Operators.ConcatenateObject("Nomenclature - " + text93 + " ,\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							else
							{
								text += ";0|7";
							}
							if (Operators.CompareString(innerText20.ToUpper(), text80.ToUpper(), TextCompare: false) == 0)
							{
								if (xmlNodeList23.Count == 1)
								{
									text += ";4|17";
								}
								else
								{
									text += ";6|17";
									dr[31] = Operators.ConcatenateObject("Verify the Master Template, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							else if (Operators.CompareString(innerText20.ToUpper(), text80.ToUpper(), TextCompare: false) != 0)
							{
								string text94 = null;
								if ((xmlNodeList23.Count == 1) & (Operators.CompareString(innerText20, "", TextCompare: false) == 0))
								{
									text94 = "should be None";
									text += ";3|17";
								}
								else if ((xmlNodeList23.Count == 1) & (Operators.CompareString(innerText20, "", TextCompare: false) != 0))
								{
									text94 = "Should be " + innerText20;
									text += ";3|17";
								}
								else if (Operators.CompareString(text80, "", TextCompare: false) == 0)
								{
									text94 = "is Missing";
									text += ";3|17";
								}
								dr[31] = Operators.ConcatenateObject("Master Template " + text94 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
							}
							if (Operators.CompareString(innerText22, text82, TextCompare: false) == 0)
							{
								if (((Operators.CompareString(text65, "Option Kit RI/FW/Insight", TextCompare: false) == 0) & (Operators.CompareString(text66, "0", TextCompare: false) == 0)) || ((Operators.CompareString(text65, "Option Kit", TextCompare: false) == 0) & (Operators.CompareString(text66, "1", TextCompare: false) == 0)))
								{
									text += ";4|28";
								}
								else if (xmlNodeList25.Count == 1)
								{
									text += ";4|28";
								}
								else if (Operators.CompareString(text67, "Kit-2", TextCompare: false) == 0)
								{
									text += ";4|28";
								}
								else
								{
									text += ";6|28";
									dr[31] = Operators.ConcatenateObject("Verify the Mapics Item Type, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								}
							}
							else if (Operators.CompareString(innerText22, text82, TextCompare: false) != 0)
							{
								if (((Operators.CompareString(text65, "Option Kit RI/FW/Insight", TextCompare: false) == 0) & (Operators.CompareString(text66, "0", TextCompare: false) == 0)) || ((Operators.CompareString(text65, "Option Kit", TextCompare: false) == 0) & (Operators.CompareString(text66, "1", TextCompare: false) == 0)))
								{
									text += ";4|28";
								}
								else
								{
									string text95 = null;
									if ((xmlNodeList25.Count == 1) & (Operators.CompareString(innerText22, "", TextCompare: false) == 0))
									{
										text95 = "Mapics Item Type should be None";
										text += ";3|28";
									}
									else if ((xmlNodeList25.Count == 1) & (Operators.CompareString(innerText22, "", TextCompare: false) != 0))
									{
										text95 = "Mapics Item Type Should be " + innerText22;
										text += ";3|28";
									}
									else if (Operators.CompareString(text82, "", TextCompare: false) == 0)
									{
										text95 = " Mapics Item Type is Missing";
										text += ";3|28";
									}
									if (Operators.CompareString(text95, "", TextCompare: false) != 0)
									{
										dr[31] = Operators.ConcatenateObject(text95 + ", \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
									}
									if (Operators.CompareString(text67, "S-Kit", TextCompare: false) == 0 || Operators.CompareString(text67, "Kit-1", TextCompare: false) == 0 || Operators.CompareString(text67, "Kit-2", TextCompare: false) == 0)
									{
										text += ";6|15,28";
										dr[31] = Operators.ConcatenateObject("Verify Subcategory and Mapics Item type-non Self-contained kits should be Option Kit RI/FW/Insight with Mapics item type 0, Self-contained kits should be Option Kit with Mapics item type 1 , \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
									}
								}
							}
							string text96 = Conversions.ToString(dr[23]);
							if (Operators.ConditionalCompareObjectEqual(Conversions.ToString(dr[5]), dr[6], TextCompare: false))
							{
								text += ";4|5,6";
							}
							else
							{
								text += ";3|5,6";
								dr[31] = Operators.ConcatenateObject("Name and Descripton is Not Matching, \n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
							}
							string left22 = Conversions.ToString(dr[4]);
							if ((Operators.CompareString(left22, "I", TextCompare: false) == 0) | (Operators.CompareString(left22, "O", TextCompare: false) == 0) | (Operators.CompareString(left22, "Q", TextCompare: false) == 0) | (Operators.CompareString(left22, "S", TextCompare: false) == 0) | (Operators.CompareString(left22, "X", TextCompare: false) == 0) | (Operators.CompareString(left22, "Z", TextCompare: false) == 0))
							{
								text += ";3|4";
								dr[31] = Operators.ConcatenateObject("Revision Letter is not acceptable per ASME - Change the Revision Letter ,\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
							}
							else
							{
								text += ";4|4";
							}
							string text97 = string.Empty;
							int num5 = 5;
							do
							{
								string illegal_Character3 = MySettingsProperty.Settings.Illegal_Character;
								foreach (char c3 in illegal_Character3)
								{
									try
									{
										if (Conversions.ToString(dr[num5]).Contains(Conversions.ToString(c3)))
										{
											text97 = string.Concat(text97, "," + Conversions.ToString(num5));
											string text98 = Conversions.ToString(c3);
											dr[31] = Operators.ConcatenateObject("Name has the illegal Character of : " + text98 + " ,\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
											text += ";3|5";
										}
									}
									catch (Exception ex11)
									{
										ProjectData.SetProjectError(ex11);
										Exception ex12 = ex11;
										ProjectData.ClearProjectError();
									}
								}
								num5++;
							}
							while (num5 <= 5);
							string text99 = string.Empty;
							int num6 = 6;
							do
							{
								string illegal_Character4 = MySettingsProperty.Settings.Illegal_Character;
								foreach (char c4 in illegal_Character4)
								{
									try
									{
										if (Conversions.ToString(dr[num6]).Contains(Conversions.ToString(c4)))
										{
											text99 = string.Concat(text99, "," + Conversions.ToString(num6));
											string text100 = Conversions.ToString(c4);
											dr[31] = Operators.ConcatenateObject("Description has the illegal Character of : " + text100 + " ,\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
											text += ";3|6";
										}
									}
									catch (Exception ex13)
									{
										ProjectData.SetProjectError(ex13);
										Exception ex14 = ex13;
										ProjectData.ClearProjectError();
									}
								}
								num6++;
							}
							while (num6 <= 6);
							string text101 = Conversions.ToString(dr[31]);
							if (text101.Contains("Name and Descripton is Not Matching") || text101.Contains("Description has the illegal Character"))
							{
								text += ";3|5,6";
							}
							else
							{
								text += ";4|5";
								text += ";4|6";
							}
							string value2 = "Pass";
							if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null), "", TextCompare: false))
							{
								dr[31] = value2;
								text += ";4|31,2,3";
							}
							else if (Operators.ConditionalCompareObjectNotEqual(dr[31], "", TextCompare: false))
							{
								text += ";6|31,2,3";
							}
							string text102 = Conversions.ToString(NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
							if (Operators.ConditionalCompareObjectNotEqual(dr[31], "Pass", TextCompare: false))
							{
								dr[31] = text102.Remove(text102.LastIndexOf(","));
							}
							text += ";0|16,18,19,20,21";
							goto IL_a168;
							IL_a168:
							if (Operators.CompareString(text60, "Legacy", TextCompare: false) == 0)
							{
								dr[31] = "Legacy Part";
								text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,28";
							}
							else
							{
								text += ";0|10,13";
							}
							if (unchecked(Operators.CompareString(text67, "", TextCompare: false) == 0 || text67 == null))
							{
								dr[31] = Operators.ConcatenateObject("Part Not Validated - ERD-0020 MTY-TC Attribute CheckSheet Program Rules\n", NewLateBinding.LateGet(dr[31], null, "Substring", new object[1] { 0 }, null, null, null));
								text += ";6|2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,28";
							}
							goto IL_a22c;
						}
					}
					else
					{
						MessageBox.Show("No solution items for ECN (" + objInput.InputItem + ")", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				DataView dataView = new DataView(dt);
				string empty2 = string.Empty;
				empty2 = dt.Columns[8].ColumnName;
				dataView.Sort = empty2 + " ASC, High_Level_Category ASC, Sub_Category ASC,ID ASC";
				dt = dataView.ToTable();
				int num7 = dt.Rows.Count - 1;
				for (int m = 0; m <= num7; m++)
				{
					dt.Rows[m][1] = m + 1;
				}
				Functions.SetStatus(objInput.ProgressStatus, "Process Completed...");
				ECN_ID = objInput.InputItem.ToString();
				Functions.ViewReport(dt, "Check Sheet");
			}
			catch (Exception ex15)
			{
				ProjectData.SetProjectError(ex15);
				Exception prompt3 = ex15;
				Interaction.MsgBox(prompt3);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void UpdateFormProperty(Connection TC_Conn, ModelObject objMod, ref DataRow dr, string PlantCode)
	{
		try
		{
			List<ModelObject> list = null;
			string strRelationName = string.Empty;
			string strSecondaryObjectName = string.Empty;
			string left = string.Empty;
			switch (PlantCode.ToUpper())
			{
			case "BRIDGETON":
				strRelationName = "H4_bgn_plant_rel";
				strSecondaryObjectName = "H4_BGN_View_Form";
				break;
			case "MONTERREY":
				strRelationName = "H4_mty_plant_rel";
				strSecondaryObjectName = "H4_MTY_View_Form";
				left = "h4_MAPICS_Item_Type";
				break;
			case "CHINO":
				strRelationName = "H4_cno_plant_rel";
				strSecondaryObjectName = "H4_CNO_View_Form";
				left = "h4_US_Baan_Item_Type";
				break;
			case "SUWANEE":
				strRelationName = "H4_swn_plant_rel";
				strSecondaryObjectName = "H4_SWN_View_Form";
				left = "h4_US_Baan_Item_Type";
				break;
			case "BOLINGBROOK":
				strRelationName = "H4_bbk_plant_rel";
				strSecondaryObjectName = "H4_BBK_View_Form";
				break;
			case "AFTERMARKET":
				strRelationName = "H4_hab_plant_rel";
				strSecondaryObjectName = "H4_HAB_View_Form";
				break;
			}
			TCFunctions.setObjectPolicy_Form(TC_Conn, strSecondaryObjectName);
			list = TCFunctions.GetSecondaryObjects(TC_Conn, objMod, strRelationName, strSecondaryObjectName);
			if (list == null)
			{
				return;
			}
			int num = 0;
			if (Operators.CompareString(PlantCode.ToUpper(), "BRIDGETON", TextCompare: false) == 0)
			{
				dr[28] = TCFunctions.GetItemProperty(list[0], "h4_Plant_Template");
				dr[29] = TCFunctions.GetItemProperty(list[0], "h4_Template_Name");
				dr[30] = TCFunctions.GetItemProperty(list[0], "h4_Plant");
				dr[31] = TCFunctions.GetItemProperty(list[0], "h4_Plant_Coded");
			}
			if (Operators.CompareString(left, "", TextCompare: false) != 0)
			{
				if (Operators.CompareString(PlantCode.ToUpper(), "MONTERREY", TextCompare: false) == 0)
				{
					dr[28] = TCFunctions.GetItemProperty(list[0], "h4_MAPICS_Item_Type");
					dr[29] = TCFunctions.GetItemProperty(list[0], "h4_Plant");
					dr[30] = TCFunctions.GetItemProperty(list[0], "h4_Plant_Coded");
				}
				else
				{
					dr[28] = TCFunctions.GetItemProperty(list[0], "h4_US_Baan_Item_Type");
				}
				num = checked(num + 1);
			}
			if (Operators.CompareString(PlantCode.ToUpper(), "SUWANEE", TextCompare: false) == 0)
			{
				dr[28] = TCFunctions.GetItemProperty(list[0], "h4_US_Baan_Item_Type");
				dr[29] = TCFunctions.GetItemProperty(list[0], "h4_Cross_Ref_Part_No");
				dr[30] = TCFunctions.GetItemProperty(list[0], "h4_Plant_Coded");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
