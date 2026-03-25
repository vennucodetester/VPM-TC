using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Rapid_Check.My;
using SolidEdgeFileProperties;
using Teamcenter.Soa.Client;

namespace Rapid_Check;

public class InputInfo
{
	private Declarations.Input_type objInput_type;

	private string sInput;

	private string sFolderPath;

	private string sSite;

	private bool bFilleCntMatch;

	private ProgressBar lpbProgress;

	private TextBox ltxtStatus;

	private DataTable ldtRes;

	private Hashtable lhtFilenames;

	private PropertySets objSEps;

	private Connection objTCCon;

	private List<string> lItemID;

	public string InputItem
	{
		get
		{
			return sInput;
		}
		set
		{
			sInput = value;
		}
	}

	public Declarations.Input_type InputType
	{
		get
		{
			return objInput_type;
		}
		set
		{
			objInput_type = value;
		}
	}

	public string FolderPath
	{
		get
		{
			return sFolderPath;
		}
		set
		{
			sFolderPath = value;
		}
	}

	public bool IncludeFileCount
	{
		get
		{
			return bFilleCntMatch;
		}
		set
		{
			bFilleCntMatch = value;
		}
	}

	public ProgressBar Progress_bar
	{
		get
		{
			return lpbProgress;
		}
		set
		{
			lpbProgress = value;
		}
	}

	public TextBox ProgressStatus
	{
		get
		{
			return ltxtStatus;
		}
		set
		{
			ltxtStatus = value;
		}
	}

	public DataTable ResultTable
	{
		get
		{
			return ldtRes;
		}
		set
		{
			ldtRes = value;
		}
	}

	public Hashtable htFilenames
	{
		get
		{
			return lhtFilenames;
		}
		set
		{
			lhtFilenames = value;
		}
	}

	public PropertySets SEPropertySets
	{
		get
		{
			return objSEps;
		}
		set
		{
			objSEps = value;
		}
	}

	public Connection TCCon
	{
		get
		{
			return objTCCon;
		}
		set
		{
			objTCCon = value;
		}
	}

	public List<string> ItemIDs
	{
		get
		{
			return lItemID;
		}
		set
		{
			lItemID = value;
		}
	}

	public string ECNType
	{
		get
		{
			if ((objInput_type == Declarations.Input_type.ECN) | (objInput_type == Declarations.Input_type.ECN_CheckSheet))
			{
				if (sInput.ToUpper().Contains("CAP"))
				{
					return "H4_ECN_CAPRevision";
				}
				if (sInput.ToUpper().Contains("COD"))
				{
					return "H4_ECN_CODRevision";
				}
				if (sInput.ToUpper().Contains("NPD"))
				{
					return "H4_ECN_NPDRevision";
				}
				if (sInput.ToUpper().Contains("VAVE"))
				{
					return "H4_ECN_VAVERevision";
				}
				return "ChangeNoticeRevision";
			}
			return "ChangeNoticeRevision";
		}
	}

	public string Site
	{
		get
		{
			return sSite;
		}
		set
		{
			sSite = value;
		}
	}

	public InputInfo()
	{
		objInput_type = Declarations.Input_type.Unknown;
		sInput = string.Empty;
		sFolderPath = string.Empty;
		sSite = string.Empty;
		bFilleCntMatch = false;
		lpbProgress = new ProgressBar();
		ltxtStatus = new TextBox();
		lhtFilenames = new Hashtable();
		lItemID = new List<string>();
		try
		{
			ldtRes = new DataTable();
			ldtRes.Columns.Add("Colour");
			ldtRes.Columns[0].ColumnMapping = MappingType.Hidden;
			ldtRes.Columns.Add("S.No", Type.GetType("System.Int32"));
			ldtRes.Columns.Add("File Name");
			ldtRes.Columns.Add("File Ext");
			ldtRes.Columns.Add("ItemID-TC");
			ldtRes.Columns.Add("Doc Numner-SE");
			ldtRes.Columns.Add("Description-TC");
			ldtRes.Columns.Add("Title-SE");
			ldtRes.Columns.Add("Revision-TC");
			ldtRes.Columns.Add("Revision-SE");
			ldtRes.Columns.Add("TCMIG-OSM");
			ldtRes.Columns.Add("TCMIG-OSD");
			ldtRes.Columns.Add("TCMIG-DVI");
			ldtRes.Columns.Add("IR LOGO");
			ldtRes.Columns.Add("File Remarks");
			ldtRes.Columns.Add("Property Remarks");
			ldtRes.Columns.Add("Ref Remarks");
			ldtRes.Columns.Add("Ref Mismatch");
			ldtRes.Columns.Add("RefFiles-TC");
			ldtRes.Columns.Add("RefFiles-SE");
			ldtRes.Columns.Add("DataSet Remarks");
			ldtRes.Columns.Add("Remarks");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void CollectSEFilesfromFolder()
	{
		try
		{
			if (!(bFilleCntMatch & (Operators.CompareString(sFolderPath, "", TextCompare: false) != 0)))
			{
				return;
			}
			lhtFilenames = new Hashtable();
			string[] array = new string[6] { "DFT", "ASM", "PAR", "PSM", "CFG", "DWG" };
			foreach (string text in array)
			{
				string[] files = Directory.GetFiles(sFolderPath, "*." + text, SearchOption.TopDirectoryOnly);
				foreach (string path in files)
				{
					try
					{
						lhtFilenames.Add(Path.GetFileName(path).ToUpper(), 0);
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			ProjectData.ClearProjectError();
		}
	}

	public void AddAdditionalFiles2Result()
	{
		checked
		{
			try
			{
				objSEps = new PropertySetsClass();
				foreach (object key in htFilenames.Keys)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(key);
					string empty = string.Empty;
					if (Conversions.ToInteger(htFilenames[RuntimeHelpers.GetObjectValue(objectValue)]) != 0)
					{
						continue;
					}
					try
					{
						DataRow dtRow = ldtRes.NewRow();
						empty = ((InputType != Declarations.Input_type.ECN) ? "6|14" : "6|15");
						dtRow[1] = ldtRes.Rows.Count + 1;
						dtRow[2] = Conversions.ToString(objectValue);
						dtRow[3] = Path.GetExtension(Conversions.ToString(objectValue));
						dtRow[4] = "";
						dtRow[5] = "";
						dtRow[6] = "";
						dtRow[7] = "";
						dtRow[8] = "";
						dtRow[9] = "";
						dtRow[10] = "";
						dtRow[11] = "";
						dtRow[12] = "";
						dtRow[13] = "";
						dtRow[14] = "Additional File Please Remove from the Folder";
						dtRow[15] = "";
						dtRow[16] = "";
						dtRow[17] = "";
						dtRow[18] = "";
						dtRow[19] = "";
						dtRow[20] = "";
						dtRow[21] = "";
						switch (Path.GetExtension(Conversions.ToString(objectValue)).ToUpper())
						{
						case ".ASM":
						case ".PAR":
						case ".PSM":
						case ".DFT":
						case "CFG":
						{
							SEPropertySets.Open(sFolderPath + "\\" + Conversions.ToString(objectValue), true);
							string text = empty;
							Declarations.Input_type inputType = InputType;
							PropertySets sEPropertySets = SEPropertySets;
							string text2 = DataCompare.UpdateSEvariables(inputType, ref dtRow, ref sEPropertySets, Operators.CompareString(Path.GetExtension(Conversions.ToString(objectValue)).ToUpper(), ".DFT", TextCompare: false) == 0);
							SEPropertySets = sEPropertySets;
							empty = text + text2;
							string left = Conversions.ToString(dtRow[9]).ToUpper().Trim();
							if (Operators.CompareString(left, "as-installed".ToUpper(), TextCompare: false) == 0 || Operators.CompareString(left, "COP".ToUpper(), TextCompare: false) == 0 || Operators.CompareString(left, "Non-Graphic".ToUpper(), TextCompare: false) == 0)
							{
								dtRow[14] = "";
								empty = Conversions.ToString(Operators.ConcatenateObject(empty, Interaction.IIf(InputType == Declarations.Input_type.ECN, ";4|6,8,9,10", ";4|5,7,8,9")));
							}
							else
							{
								empty = Conversions.ToString(Operators.ConcatenateObject(empty, Interaction.IIf(InputType == Declarations.Input_type.ECN, ";3|6,8,9,10", ";3|5,7,8,9")));
							}
							string left2 = string.Empty;
							int num = 7;
							do
							{
								string illegal_Character = MySettingsProperty.Settings.Illegal_Character;
								foreach (char c in illegal_Character)
								{
									try
									{
										if (Conversions.ToString(dtRow[num]).Contains(Conversions.ToString(c)))
										{
											left2 = Conversions.ToString(Operators.ConcatenateObject(left2, Operators.ConcatenateObject(Operators.ConcatenateObject(",", Interaction.IIf(InputType == Declarations.Input_type.ECN, num + 1, num)), "")));
											string text3 = Conversions.ToString(c);
											dtRow[21] = Operators.ConcatenateObject("Title-SE has the illegal Character of : " + text3 + ", ", NewLateBinding.LateGet(dtRow[21], null, "Substring", new object[1] { 0 }, null, null, null));
											empty = Conversions.ToString(Operators.ConcatenateObject(empty, Interaction.IIf(InputType == Declarations.Input_type.ECN, ";3|8,22", ";3|7,21")));
										}
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception ex2 = ex;
										ProjectData.ClearProjectError();
									}
								}
								num++;
							}
							while (num <= 7);
							SEPropertySets.Close();
							break;
						}
						}
						dtRow[0] = empty;
						string empty2 = string.Empty;
						empty2 = Path.GetFileNameWithoutExtension(Conversions.ToString(objectValue)).ToUpper();
						string text4 = Path.GetExtension(Conversions.ToString(objectValue)).ToUpper();
						if (Operators.CompareString(text4.ToUpper(), ".CFG", TextCompare: false) == 0 && Directory.GetFiles(sFolderPath, empty2 + ".ASM", SearchOption.TopDirectoryOnly).Count() > 0)
						{
							dtRow[14] = "";
							empty = Conversions.ToString(Operators.ConcatenateObject(empty, Interaction.IIf(InputType == Declarations.Input_type.ECN, ";0|14", ";0|15")));
						}
						ldtRes.Rows.Add(dtRow);
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				MessageBox.Show("Faild to add addtional files in result", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				ProjectData.ClearProjectError();
			}
		}
	}
}
