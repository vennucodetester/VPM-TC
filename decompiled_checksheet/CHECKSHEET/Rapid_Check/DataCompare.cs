using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DesignManager;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Rapid_Check.My;
using SolidEdgeFileProperties;
using Teamcenter.Soa.Client.Model;

namespace Rapid_Check;

[StandardModule]
internal sealed class DataCompare
{
	public static string ECN_name;

	public static string UpdateSEvariables(Declarations.Input_type in_Type, ref DataRow dtRow, ref PropertySets objSEps, bool isDft = false)
	{
		string text = string.Empty;
		checked
		{
			try
			{
				string empty = string.Empty;
				string text2 = string.Empty;
				dtRow[5] = SolidEdgeFunctions.GetSEFileProperty(objSEps, "ProjectInformation", "Document Number");
				dtRow[7] = SolidEdgeFunctions.GetSEFileProperty(objSEps, "SummaryInformation", "Title");
				dtRow[9] = SolidEdgeFunctions.GetSEFileProperty(objSEps, "ProjectInformation", "Revision");
				dtRow[10] = SolidEdgeFunctions.GetSEFileProperty(objSEps, "CUSTOM", "TCMIG-OSM");
				dtRow[11] = SolidEdgeFunctions.GetSEFileProperty(objSEps, "CUSTOM", "TCMIG-OSD");
				dtRow[12] = SolidEdgeFunctions.GetSEFileProperty(objSEps, "CUSTOM", "TCMIG-DVI");
				dtRow[13] = SolidEdgeFunctions.GetSEFileProperty(objSEps, "CUSTOM", "IR LOGO");
				empty = SolidEdgeFunctions.GetSEFileProperty(objSEps, "SummaryInformation", "Template");
				int num = 0;
				if (in_Type == Declarations.Input_type.ECN)
				{
					num = 1;
				}
				if (Operators.CompareString(Conversions.ToString(dtRow[5]).Trim(), "", TextCompare: false) == 0)
				{
					text2 = text2 + "," + Conversions.ToString(5 + num);
				}
				if (Operators.CompareString(Conversions.ToString(dtRow[7]).Trim(), "", TextCompare: false) == 0)
				{
					text2 = text2 + "," + Conversions.ToString(7 + num);
				}
				if (Operators.CompareString(Conversions.ToString(dtRow[9]).Trim(), "", TextCompare: false) == 0)
				{
					text2 = text2 + "," + Conversions.ToString(9 + num);
				}
				if (Operators.CompareString(text2, "", TextCompare: false) != 0)
				{
					text = text + ";3|" + text2.Substring(1);
				}
				text = ((Operators.CompareString(Conversions.ToString(dtRow[10]).ToUpper(), "Complete".ToUpper(), TextCompare: false) != 0) ? Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";6|11", ";6|10"))) : Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";4|11", ";4|10"))));
				text = ((Operators.CompareString(Conversions.ToString(dtRow[11]).ToUpper(), "Complete".ToUpper(), TextCompare: false) != 0) ? Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";6|12", ";6|11"))) : Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";4|12", ";4|11"))));
				string left = Conversions.ToString(dtRow[12]).ToUpper();
				text = ((Operators.CompareString(left, "PASS".ToUpper(), TextCompare: false) == 0) ? Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";4|13", ";4|12"))) : ((Operators.CompareString(left, "FAIL".ToUpper(), TextCompare: false) != 0) ? Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";6|13", ";6|12"))) : Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";3|13", ";3|12")))));
				if (isDft)
				{
					text = (((Operators.CompareString(Conversions.ToString(dtRow[13]).ToUpper(), "No".ToUpper(), TextCompare: false) == 0) | (Operators.CompareString(Conversions.ToString(dtRow[13]).ToUpper(), "removed".ToUpper(), TextCompare: false) == 0)) ? Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";4|14", ";4|13"))) : ((!((Operators.CompareString(Conversions.ToString(dtRow[13]).Trim(), "", TextCompare: false) == 0) & empty.ToUpper().Contains("GDF"))) ? Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";6|14", ";6|13"))) : Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(in_Type == Declarations.Input_type.ECN, ";4|14", ";4|13")))));
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
	}

	public static void CompareIteams(ref InputInfo objInput)
	{
		checked
		{
			try
			{
				Hashtable hashtable = new Hashtable();
				List<ModelObject> list = new List<ModelObject>();
				System.Windows.Forms.Application.DoEvents();
				switch (objInput.InputType)
				{
				case Declarations.Input_type.ItemID:
					objInput.ItemIDs.Add(objInput.InputItem);
					break;
				case Declarations.Input_type.MultipleItemID:
				{
					string text = File.ReadAllText(objInput.InputItem);
					objInput.ItemIDs.AddRange(text.Split('\r'));
					break;
				}
				case Declarations.Input_type.MultipleItemIDFolder:
				{
					string[] array = new string[6] { "DFT", "ASM", "PAR", "PSM", "DWG", "CFG" };
					foreach (string text2 in array)
					{
						string[] files = Directory.GetFiles(objInput.FolderPath, "*." + text2, SearchOption.TopDirectoryOnly);
						foreach (string path in files)
						{
							try
							{
								string empty = string.Empty;
								empty = Path.GetFileNameWithoutExtension(path).ToUpper();
								if (!objInput.ItemIDs.Contains(empty))
								{
									objInput.ItemIDs.Add(empty);
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
					break;
				}
				case Declarations.Input_type.ECN:
				{
					Functions.SetStatus(objInput.ProgressStatus, "Collecting solution items...");
					string strError = string.Empty;
					System.Windows.Forms.Application.DoEvents();
					ModelObject latestItemRevision = TCFunctions.GetLatestItemRevision(objInput.TCCon, objInput.ECNType, objInput.InputItem, ref strError);
					string itemProperty = TCFunctions.GetItemProperty(latestItemRevision, "object_desc");
					if (latestItemRevision == null)
					{
						MessageBox.Show("ECN (" + objInput.InputItem + ") not available in TC", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					TCFunctions.setObjectPolicy_ItemRev(objInput.TCCon);
					List<ModelObject> secondaryObjects = TCFunctions.GetSecondaryObjects(objInput.TCCon, latestItemRevision, "CMHasSolutionItem", "H4_Hussmann_ItemRevision");
					if (secondaryObjects.Count > 0)
					{
						int num = secondaryObjects.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							string itemProperty2 = TCFunctions.GetItemProperty(secondaryObjects[i], "item_id");
							if (!objInput.ItemIDs.Contains(itemProperty2))
							{
								objInput.ItemIDs.Add(itemProperty2);
							}
							if (hashtable.Contains(itemProperty2.ToUpper()))
							{
								if (Operators.CompareString(TCFunctions.GetItemProperty((ModelObject)hashtable[itemProperty2.ToUpper()], "item_revision_id"), TCFunctions.GetItemProperty(secondaryObjects[i], "item_revision_id"), TextCompare: false) > 0)
								{
									list.Add(secondaryObjects[i]);
									continue;
								}
								list.Add((ModelObject)hashtable[itemProperty2.ToUpper()]);
								hashtable.Remove(itemProperty2.ToUpper());
								hashtable.Add(itemProperty2.ToUpper(), secondaryObjects[i]);
							}
							else
							{
								hashtable.Add(itemProperty2.ToUpper(), secondaryObjects[i]);
							}
						}
						break;
					}
					MessageBox.Show("No solution items for ECN (" + objInput.InputItem + ")", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				}
				if (objInput.ItemIDs.Count > 0)
				{
					if (objInput.IncludeFileCount)
					{
						Functions.SetStatus(objInput.ProgressStatus, "Collecting SE files from Folder...");
						System.Windows.Forms.Application.DoEvents();
						objInput.CollectSEFilesfromFolder();
						Functions.SetStatus(objInput.ProgressStatus, "Compare TC item with SE file(s)...");
						System.Windows.Forms.Application.DoEvents();
						CompareTCobjectWithSEfiles(ref objInput, hashtable, list);
						Functions.SetStatus(objInput.ProgressStatus, "Updating additional SE Files info...");
						System.Windows.Forms.Application.DoEvents();
						objInput.AddAdditionalFiles2Result();
					}
					else
					{
						Functions.SetStatus(objInput.ProgressStatus, "Compare TC item with SE file(s)...");
						System.Windows.Forms.Application.DoEvents();
						CompareTCobjectWithSEfiles(ref objInput, hashtable, list);
					}
					if (objInput.InputType == Declarations.Input_type.ECN)
					{
						InputInfo obj = objInput;
						DataTable dt = obj.ResultTable;
						Functions.SetSno2datatableWith_ECN(ref dt, objInput.InputItem, 1);
						obj.ResultTable = dt;
					}
					else
					{
						InputInfo obj2 = objInput;
						DataTable dt = obj2.ResultTable;
						Functions.SetSno2datatable(ref dt, 1);
						obj2.ResultTable = dt;
					}
					Functions.SetStatus(objInput.ProgressStatus, "Process Completed...");
					Functions.ViewReport(objInput.ResultTable, "Compare Result", null, OnlyExoprt: true, objInput.FolderPath + "\\RC_" + ECN_name + ".xlsx");
				}
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CompareTCobjectWithSEfiles(ref InputInfo objInput, Hashtable htModObject, List<ModelObject> lDuplist)
	{
		checked
		{
			try
			{
				Functions.SetProgressBar(objInput.Progress_bar, objInput.ItemIDs.Count);
				foreach (string itemID in objInput.ItemIDs)
				{
					string empty = string.Empty;
					string empty2 = string.Empty;
					string text = string.Empty;
					string empty3 = string.Empty;
					string empty4 = string.Empty;
					string empty5 = string.Empty;
					ArrayList arrayList = new ArrayList();
					int num = 0;
					int num2 = 0;
					bool flag = false;
					ModelObject modelObject = null;
					DataRow dataRow = objInput.ResultTable.NewRow();
					dataRow[0] = RuntimeHelpers.GetObjectValue(Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, "3|15", "3|14"));
					dataRow[1] = objInput.ResultTable.Rows.Count + 1;
					dataRow[2] = "";
					dataRow[3] = "";
					dataRow[4] = itemID;
					dataRow[5] = "";
					dataRow[6] = "";
					dataRow[7] = "";
					dataRow[8] = "";
					dataRow[9] = "";
					dataRow[10] = "";
					dataRow[11] = "";
					dataRow[12] = "";
					dataRow[13] = "";
					dataRow[14] = "Missing in TC";
					dataRow[15] = "";
					dataRow[16] = "";
					dataRow[17] = "";
					dataRow[18] = "";
					dataRow[19] = "";
					dataRow[20] = "";
					dataRow[21] = "";
					Functions.SetStatus(objInput.ProgressStatus, "ItemID (" + Conversions.ToString(objInput.Progress_bar.Value) + "/" + Conversions.ToString(objInput.Progress_bar.Maximum) + ")");
					System.Windows.Forms.Application.DoEvents();
					if (htModObject.Count > 0)
					{
						if (htModObject.Contains(itemID.ToUpper()))
						{
							modelObject = (ModelObject)htModObject[itemID.ToUpper()];
						}
					}
					else
					{
						string strError = string.Empty;
						TCFunctions.setObjectPolicy_ItemRev(objInput.TCCon);
						modelObject = TCFunctions.GetLatestItemRevision(objInput.TCCon, "H4_Hussmann_ItemRevision", itemID, ref strError);
					}
					if (modelObject != null)
					{
						empty = TCFunctions.GetItemProperty(modelObject, "item_id");
						empty2 = TCFunctions.GetItemProperty(modelObject, "object_desc");
						empty3 = TCFunctions.GetItemProperty(modelObject, "item_revision_id");
						empty4 = "";
						string itemProperty = TCFunctions.GetItemProperty(modelObject, "h4_Hussmann_Item_Type");
						dataRow[6] = empty2;
						dataRow[8] = empty3;
						dataRow[18] = empty4;
						dataRow[14] = "";
						dataRow[20] = "";
						string[] array = new string[10] { "DFT", "ASM", "PAR", "PSM", "CFG", "DWG", "STP", "IGS", "DXF", "PDF" };
						foreach (string text2 in array)
						{
							empty4 = "";
							string[] files = Directory.GetFiles(objInput.FolderPath, itemID + "." + text2, SearchOption.TopDirectoryOnly);
							foreach (string text3 in files)
							{
								DataRow dtRow = objInput.ResultTable.NewRow();
								string empty6 = string.Empty;
								string empty7 = string.Empty;
								dtRow[1] = objInput.ResultTable.Rows.Count + 1;
								dtRow[2] = Path.GetFileName(text3);
								dtRow[3] = Path.GetExtension(text3);
								dtRow[4] = itemID;
								dtRow[5] = "";
								dtRow[6] = "";
								dtRow[7] = "";
								dtRow[8] = "";
								dtRow[9] = "";
								dtRow[10] = "";
								dtRow[11] = "";
								dtRow[12] = "";
								dtRow[13] = "";
								dtRow[14] = "";
								dtRow[15] = "";
								dtRow[16] = "";
								dtRow[17] = "";
								dtRow[18] = "";
								dtRow[19] = "";
								dtRow[20] = "";
								dtRow[21] = "";
								if (objInput.htFilenames.Contains(Path.GetFileName(text3).ToUpper()))
								{
									objInput.htFilenames[Path.GetFileName(text3).ToUpper()] = 1;
								}
								if (Operators.CompareString(text2.ToUpper(), "CFG", TextCompare: false) == 0)
								{
									if (Directory.GetFiles(objInput.FolderPath, itemID + ".ASM", SearchOption.TopDirectoryOnly).Count() <= 0)
									{
										dtRow[0] = RuntimeHelpers.GetObjectValue(Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, "6|15", "6|14"));
										dtRow[14] = "CFG File without assembly";
										objInput.ResultTable.Rows.Add(dtRow);
									}
									continue;
								}
								flag = true;
								empty7 = "";
								try
								{
									if (Operators.CompareString(text2.ToUpper(), "ASM", TextCompare: false) == 0)
									{
										string withOutExt = string.Empty;
										bool flag2 = false;
										string text4 = string.Empty;
										string text5 = string.Empty;
										empty4 = (string)(dtRow[18] = TCFunctions.GetChildNames(objInput.TCCon, modelObject));
										dtRow[19] = SolidEdgeFunctions.GetSEChildFilenames(text3, ref withOutExt);
										string[] array2 = empty4.Split('|');
										foreach (string text6 in array2)
										{
											if (!withOutExt.ToUpper().Contains(text6.ToUpper().Trim()))
											{
												text5 = text5 + "," + text6;
												flag2 = true;
											}
										}
										string[] array3 = withOutExt.Split('|');
										foreach (string text7 in array3)
										{
											if (!empty4.ToUpper().Contains(text7.ToUpper().Trim()))
											{
												flag2 = true;
												text4 = text4 + "," + text7;
											}
										}
										if (flag2)
										{
											string text8 = string.Empty;
											dtRow[16] = "Reference Mismatch";
											if (Operators.CompareString(text5.Trim(), "", TextCompare: false) != 0)
											{
												text8 = "Missing in SE : " + text5.Substring(1) + "\r\n";
											}
											if (Operators.CompareString(text4.Trim(), "", TextCompare: false) != 0)
											{
												text8 = text8 + "Missing in TC : " + text4.Substring(1);
											}
											dtRow[17] = text8;
											empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|18", ";3|17")));
										}
										if (Directory.GetFiles(objInput.FolderPath, itemID + ".CFG", SearchOption.TopDirectoryOnly).Count() <= 0)
										{
											empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";6|15", ";6|14")));
											dtRow[10] = "Assembly File without CFG";
										}
									}
									if (Operators.CompareString(text2.ToUpper(), "DWG", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "STP", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "IGS", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "DXF", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "PDF", TextCompare: false) == 0)
									{
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";6|15", ";6|14")));
										dtRow[14] = "Additional File Please Remove from the Folder";
									}
									dtRow[6] = empty2;
									dtRow[8] = empty3;
									if ((Operators.CompareString(text2.ToUpper(), "DWG", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "PDF", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "DXF", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "IGS", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "STP", TextCompare: false) != 0))
									{
										objInput.SEPropertySets.Open(text3, true);
										string text9 = empty7;
										Declarations.Input_type inputType = objInput.InputType;
										InputInfo inputInfo;
										PropertySets objSEps = (inputInfo = objInput).SEPropertySets;
										string text10 = UpdateSEvariables(inputType, ref dtRow, ref objSEps, Operators.CompareString(text2.ToUpper(), "DFT", TextCompare: false) == 0);
										inputInfo.SEPropertySets = objSEps;
										empty7 = text9 + text10;
										objInput.SEPropertySets.Close();
									}
									empty6 = "";
									if (Operators.CompareString(Conversions.ToString(dtRow[4]), Conversions.ToString(dtRow[5]), TextCompare: false) == 0)
									{
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|5,6", ";4|4,5")));
									}
									else
									{
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|5,6", ";3|4,5")));
										empty6 += ", ItemID-Doc Number";
									}
									string text11 = Conversions.ToString(dtRow[6]);
									string left = "";
									if (text11.Contains("OPTIONS"))
									{
										left = "OPTIONS";
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|7,8", ";4|6,7")));
									}
									if (Operators.CompareString(left, "OPTIONS", TextCompare: false) != 0)
									{
										if (Operators.CompareString(Conversions.ToString(dtRow[6]), Conversions.ToString(dtRow[7]), TextCompare: false) == 0)
										{
											empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|7,8", ";4|6,7")));
										}
										else
										{
											empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|7,8", ";3|6,7")));
											empty6 += ", Title-Item Name";
										}
									}
									if (Operators.CompareString(Conversions.ToString(dtRow[8]), Conversions.ToString(dtRow[9]), TextCompare: false) == 0)
									{
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|9,10", ";4|8,9")));
									}
									else
									{
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|9,10", ";3|8,9")));
										empty6 += ", Revision";
									}
									if (Operators.CompareString(Conversions.ToString(dtRow[8]), "NON-GRAPHIC", TextCompare: false) == 0 || Operators.CompareString(Conversions.ToString(dtRow[8]), "COP", TextCompare: false) == 0 || Operators.CompareString(Conversions.ToString(dtRow[8]), "AS-INSTALLED", TextCompare: false) == 0)
									{
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|4,6,8,9", ";4|5,7,9,10")));
									}
									if (Operators.CompareString(Conversions.ToString(dtRow[9]), "NON-GRAPHIC", TextCompare: false) == 0 || Operators.CompareString(Conversions.ToString(dtRow[9]), "COP", TextCompare: false) == 0 || Operators.CompareString(Conversions.ToString(dtRow[9]), "AS-INSTALLED", TextCompare: false) == 0)
									{
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|4,6,8,9", ";4|5,7,9,10")));
									}
									if (Operators.CompareString(empty6, "", TextCompare: false) != 0)
									{
										empty6 = empty6.Substring(2);
										if (empty6.Contains(","))
										{
											int startIndex = empty6.LastIndexOf(",");
											empty6 = empty6.Remove(startIndex, 2);
											empty6 = empty6.Insert(startIndex, " and ");
										}
										empty6 += " mismatch";
									}
									dtRow[15] = empty6;
									string text12 = string.Empty;
									int num3 = 6;
									do
									{
										string illegal_Character = MySettingsProperty.Settings.Illegal_Character;
										foreach (char c in illegal_Character)
										{
											try
											{
												if (Conversions.ToString(dtRow[num3]).Contains(Conversions.ToString(c)))
												{
													text12 = Conversions.ToString(Operators.ConcatenateObject(text12, Operators.ConcatenateObject(Operators.ConcatenateObject(",", Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, num3 + 1, num3)), "")));
													string text13 = Conversions.ToString(c);
													dtRow[21] = Operators.ConcatenateObject("Description-TC has the illegal Character of : " + text13 + ", ", NewLateBinding.LateGet(dtRow[21], null, "Substring", new object[1] { 0 }, null, null, null));
													empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|7,22", ";3|6,21")));
												}
											}
											catch (Exception ex)
											{
												ProjectData.SetProjectError(ex);
												Exception ex2 = ex;
												ProjectData.ClearProjectError();
											}
										}
										num3++;
									}
									while (num3 <= 6);
									string left2 = string.Empty;
									int num4 = 7;
									do
									{
										string illegal_Character2 = MySettingsProperty.Settings.Illegal_Character;
										foreach (char c2 in illegal_Character2)
										{
											try
											{
												if (Conversions.ToString(dtRow[num4]).Contains(Conversions.ToString(c2)))
												{
													left2 = Conversions.ToString(Operators.ConcatenateObject(left2, Operators.ConcatenateObject(Operators.ConcatenateObject(",", Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, num4 + 1, num4)), "")));
													string text14 = Conversions.ToString(c2);
													dtRow[21] = Operators.ConcatenateObject("Title-SE has the illegal Character of : " + text14 + ", ", NewLateBinding.LateGet(dtRow[21], null, "Substring", new object[1] { 0 }, null, null, null));
													empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|8,22", ";3|7,21")));
												}
											}
											catch (Exception ex3)
											{
												ProjectData.SetProjectError(ex3);
												Exception ex4 = ex3;
												ProjectData.ClearProjectError();
											}
										}
										num4++;
									}
									while (num4 <= 7);
									if ((Operators.CompareString(text2.ToUpper(), "DWG", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "PDF", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "DXF", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "IGS", TextCompare: false) != 0) | (Operators.CompareString(text2.ToUpper(), "STP", TextCompare: false) != 0))
									{
										string value = "T:\\RELEASED\\SE";
										string value2 = "\\\\INTERNAL.HUSSMANN.COM\\SITES\\APPS\\CAX\\CAXDATA\\RELEASED\\SE";
										string value3 = "T:\\PROJECTS\\SE\\MISC_ECOS\\_TC_ECNS";
										string value4 = "\\\\INTERNAL.HUSSMANN.COM\\SITES\\APPS\\CAX\\CAXDATA\\PROJECTS\\SE\\MISC_ECOS\\_TC_ECNS";
										string value5 = "SEParts\\STPart\\Standard parts";
										DesignManager.Application application = null;
										Document document = null;
										LinkedDocuments linkedDocuments = null;
										Document document2 = null;
										try
										{
											application = (DesignManager.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("F3C2777E-C913-4859-96BA-722B5F0276E7")));
											document = (Document)application.Open(text3, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
											linkedDocuments = (LinkedDocuments)((IDocAuto)document).get_LinkedDocuments((object)LinkTypeConstants.seLinkTypeAll);
											int count = linkedDocuments.Count;
											for (int num5 = 1; num5 <= count; num5++)
											{
												document2 = (Document)((ILinkedDocsAuto)linkedDocuments).get_Item((object)num5);
												FileInfo fileInfo = new FileInfo(document2.FullName);
												string text15 = fileInfo.ToString();
												string left3 = "";
												if (fileInfo.ToString().ToUpper().Contains(value) || fileInfo.ToString().ToUpper().Contains(value2))
												{
													left3 = "Release";
												}
												string text16 = "";
												text16 = Conversions.ToString(unchecked((int)document2.Status));
												string text17 = "";
												if (Operators.CompareString(left3, "", TextCompare: false) == 0)
												{
													if (text15.ToUpper().Contains(value))
													{
														empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|22", ";4|21")));
														text17 = "Pass";
													}
													else if (text15.ToUpper().Contains(value2))
													{
														empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|22", ";4|21")));
														text17 = "Pass";
													}
													else if (text15.ToUpper().Contains(value3))
													{
														empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|22", ";4|21")));
														text17 = "Pass";
													}
													else if (text15.ToUpper().Contains(value4))
													{
														empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|22", ";4|21")));
														text17 = "Pass";
													}
													else if (text15.ToUpper().Contains(value5))
													{
														empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|22", ";4|21")));
														text17 = "Pass";
													}
													else
													{
														empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|22", ";3|21")));
														text17 = "Fail";
													}
													if (Operators.CompareString(text17, "Fail", TextCompare: false) == 0)
													{
														if (dtRow[21].ToString().Contains("File Links are not Proper Kindly check and update"))
														{
															dtRow[21] = Operators.ConcatenateObject(dtRow[21], text3);
															empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|22", ";3|21")));
														}
														else
														{
															dtRow[21] = Operators.ConcatenateObject(dtRow[21], text3 + "-File Links are not Proper Kindly check and update");
															empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|22", ";3|21")));
														}
													}
													if (Operators.CompareString(text16, "", TextCompare: false) == 0)
													{
														if (dtRow[21].ToString().Contains("Child Part File is Missing please update the Assembly"))
														{
															dtRow[21] = Operators.ConcatenateObject(dtRow[21], fileInfo.ToString());
														}
														else
														{
															dtRow[21] = Operators.ConcatenateObject(dtRow[21], fileInfo.ToString() + "-Child Part File is Missing please update the Assembly");
														}
														empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";3|22", ";3|21")));
													}
												}
												document.Close();
											}
										}
										catch (Exception ex5)
										{
											ProjectData.SetProjectError(ex5);
											Exception value6 = ex5;
											Console.WriteLine(value6);
											ProjectData.ClearProjectError();
										}
									}
									string text18 = "";
									if (Operators.CompareString(text2.ToUpper(), "DWG", TextCompare: false) == 0)
									{
										object secondaryObjects = TCFunctions.GetSecondaryObjects(objInput.TCCon, modelObject, "IMAN_specification", "H4_DWG_ACAD");
										text18 = "DWG";
									}
									else if (Operators.CompareString(text2.ToUpper(), "PAR", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "ASM", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "PSM", TextCompare: false) == 0)
									{
										object secondaryObjects = TCFunctions.GetSecondaryObjects(objInput.TCCon, modelObject, "IMAN_specification", "PDF");
										text18 = "PDF";
									}
									string text19 = "";
									if (Operators.CompareString(text2.ToUpper(), "PAR", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "ASM", TextCompare: false) == 0 || Operators.CompareString(text2.ToUpper(), "PSM", TextCompare: false) == 0)
									{
										if (Operators.CompareString(text18, "", TextCompare: false) != 0)
										{
											dtRow[20] = text18 + "-DataSet Found";
											empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|21", ";4|20")));
											text19 = "Pass";
										}
										else if (Operators.CompareString(text18, "", TextCompare: false) == 0)
										{
											dtRow[20] = text18 + "-DataSet NotFound";
											empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";6|21", ";6|20")));
											text19 = "Fail";
										}
									}
									if (Operators.CompareString(text12.Trim(), "", TextCompare: false) != 0)
									{
										empty7 = empty7 + ";3|" + text12.Substring(1);
									}
									if ((Operators.CompareString(dtRow[21].ToString(), "", TextCompare: false) == 0) & (Operators.CompareString(dtRow[14].ToString(), "", TextCompare: false) == 0))
									{
										dtRow[21] = "Pass";
										empty7 = Conversions.ToString(Operators.ConcatenateObject(empty7, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";4|22", ";4|21")));
									}
									if (Conversions.ToString(dtRow[4]).Contains("-") & (Operators.CompareString(text2.ToUpper(), "CFG", TextCompare: false) == 0))
									{
										dtRow[14] = "";
									}
									if (Operators.CompareString(empty7, "", TextCompare: false) != 0)
									{
										dtRow[0] = empty7.Substring(1);
									}
									switch (Conversions.ToString(dtRow[3]).ToUpper())
									{
									case ".DFT":
										num++;
										break;
									case ".PAR":
									case ".PSM":
									case ".ASM":
										num2++;
										break;
									case ".CFG":
										break;
									}
								}
								catch (Exception ex6)
								{
									ProjectData.SetProjectError(ex6);
									Exception ex7 = ex6;
									ProjectData.ClearProjectError();
								}
								arrayList.Add(dtRow);
								dtRow[0] = empty7;
							}
						}
						empty5 = "";
						if (num > 1)
						{
							empty5 += ", Multiple drawing";
						}
						if (num2 > 1)
						{
							empty5 += ", Multiple CAD File";
						}
						if (Operators.CompareString(empty5, "", TextCompare: false) != 0)
						{
							empty5 = empty5.Substring(2);
							if (empty5.Contains(","))
							{
								int startIndex2 = empty5.LastIndexOf(",");
								empty5 = empty5.Remove(startIndex2, 2);
								empty5 = empty5.Insert(startIndex2, " and ");
							}
						}
						foreach (DataRow item in arrayList)
						{
							item[1] = objInput.ResultTable.Rows.Count + 1;
							if (Operators.CompareString(Conversions.ToString(item[14]).Trim(), "", TextCompare: false) != 0)
							{
								DataRow dataRow3;
								(dataRow3 = item)[14] = Operators.ConcatenateObject(dataRow3[14], ";" + empty5);
							}
							else
							{
								item[14] = empty5;
							}
							objInput.ResultTable.Rows.Add(item);
						}
						string text20 = empty2.ToUpper();
						string left4 = "";
						if (itemProperty.Contains("Kit") || itemProperty.Contains("Material Bill") || itemProperty.Contains("Option-Class"))
						{
							left4 = "NonCad";
						}
						else if (Operators.CompareString(itemProperty, "Module", TextCompare: false) == 0)
						{
							left4 = "Module";
						}
						string left5 = "";
						if (text20.Contains("DATASHEET"))
						{
							left5 = "DataSheet";
						}
						else if (text20.Contains("MANUAL"))
						{
							left5 = "Manual";
						}
						if (!flag & (Operators.CompareString(left4, "", TextCompare: false) == 0) & (Operators.CompareString(left5, "", TextCompare: false) == 0))
						{
							text = Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";6|15", ";6|14")));
							dataRow[14] = "Unable to find the SE Files.";
							objInput.ResultTable.Rows.Add(dataRow);
							dataRow[21] = "Fail";
							text += ";3|22";
						}
						else if (!flag & (Operators.CompareString(left4, "NonCad", TextCompare: false) == 0))
						{
							objInput.ResultTable.Rows.Add(dataRow);
						}
						else if ((!flag & (Operators.CompareString(left4, "", TextCompare: false) == 0) & (Operators.CompareString(left5, "DataSheet", TextCompare: false) == 0)) || (!flag & (Operators.CompareString(left4, "", TextCompare: false) == 0) & (Operators.CompareString(left5, "Manual", TextCompare: false) == 0)))
						{
							text = Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";6|15", ";6|14")));
							dataRow[14] = "PDF Provided by TECH-PUBB Team";
							objInput.ResultTable.Rows.Add(dataRow);
							dataRow[21] = "Pass";
							text += ";4|22";
						}
						else if (!flag & (Operators.CompareString(left4, "Module", TextCompare: false) == 0))
						{
							text = Conversions.ToString(Operators.ConcatenateObject(text, Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, ";6|15", ";6|14")));
							dataRow[14] = "Unable to find the SE Files.";
							objInput.ResultTable.Rows.Add(dataRow);
						}
						dataRow[0] = text;
					}
					else
					{
						objInput.ResultTable.Rows.Add(dataRow);
					}
					objInput.Progress_bar.PerformStep();
				}
				foreach (ModelObject item2 in lDuplist)
				{
					try
					{
						DataRow dataRow4 = objInput.ResultTable.NewRow();
						dataRow4[0] = RuntimeHelpers.GetObjectValue(Interaction.IIf(objInput.InputType == Declarations.Input_type.ECN, "6|1,2,3,4,5,6,7,8,9,10,11,12,13,14,15", "6|1,2,3,4,5,6,7,8,9,10,11,12,13,14"));
						dataRow4[1] = objInput.ResultTable.Rows.Count + 1;
						dataRow4[2] = "";
						dataRow4[3] = "";
						dataRow4[4] = TCFunctions.GetItemProperty(item2, "item_id");
						dataRow4[5] = "";
						dataRow4[6] = TCFunctions.GetItemProperty(item2, "object_desc");
						dataRow4[7] = "";
						dataRow4[8] = TCFunctions.GetItemProperty(item2, "item_revision_id");
						dataRow4[9] = "";
						dataRow4[10] = "";
						dataRow4[11] = "";
						dataRow4[12] = "";
						dataRow4[13] = "";
						dataRow4[14] = "Duplicate Item ID";
						dataRow4[15] = "";
						dataRow4[16] = "";
						dataRow4[17] = "";
						dataRow4[18] = "";
						dataRow4[19] = "";
						dataRow4[20] = "";
						dataRow4[21] = "";
						objInput.ResultTable.Rows.Add(dataRow4);
					}
					catch (Exception ex8)
					{
						ProjectData.SetProjectError(ex8);
						Exception ex9 = ex8;
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10);
				Exception ex11 = ex10;
				ProjectData.ClearProjectError();
			}
		}
	}
}
