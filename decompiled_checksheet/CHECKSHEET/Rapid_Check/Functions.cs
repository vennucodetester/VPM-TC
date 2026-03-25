using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Rapid_Check.My;

namespace Rapid_Check;

[StandardModule]
internal sealed class Functions
{
	public static string FldrPath = "";

	public static string MFldrPath = "";

	public static string RptSts = "";

	public static void SetStatus(Control txt, string message = "Ready...")
	{
		try
		{
			txt.Text = message;
			txt.Refresh();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void SetProgressBar(ProgressBar pb, int max = 0)
	{
		try
		{
			pb.Style = ProgressBarStyle.Continuous;
			pb.Minimum = 0;
			pb.Maximum = max;
			pb.Value = 0;
			pb.Step = 1;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void AddPath2ListBox(ListBox ListBx, string strPth)
	{
		try
		{
			if (ListBx.Items.Contains(strPth))
			{
				MessageBox.Show("\"" + strPth + "\" is already added", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				ListBx.Items.Add(strPth);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void SetSno2datatable(ref DataTable dt, int iCol = 0)
	{
		checked
		{
			try
			{
				int num = dt.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dt.Rows[i][iCol] = i + 1;
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

	public static void SetSno2datatableWith_ECN(ref DataTable dt, string strECN, int iCol = 0, string ECNDec = "")
	{
		checked
		{
			try
			{
				DataColumn dataColumn = dt.Columns.Add("ECN");
				dataColumn.SetOrdinal(2);
				int num = dt.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dt.Rows[i][iCol] = i + 1;
					dt.Rows[i][2] = strECN;
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

	public static void AddFolderCtr(Control ctr, Control txtBox, bool IsFile = false)
	{
		ctr.DragDrop += Folder_DragDrop;
		if (IsFile)
		{
			ctr.DragEnter += File_DragEnter;
		}
		else
		{
			ctr.DragEnter += Folder_DragEnter;
		}
		ctr.Tag = txtBox;
		ctr.AllowDrop = true;
		foreach (Control control in ctr.Controls)
		{
			AddFolderCtr(control, txtBox, IsFile);
		}
	}

	public static void RemoveFolderCtr(Control ctr, Control txtBox, bool IsFile = false)
	{
		ctr.DragDrop -= Folder_DragDrop;
		if (IsFile)
		{
			ctr.DragEnter -= File_DragEnter;
		}
		else
		{
			ctr.DragEnter -= Folder_DragEnter;
		}
		ctr.AllowDrop = false;
		foreach (Control control in ctr.Controls)
		{
			RemoveFolderCtr(control, txtBox, IsFile);
		}
	}

	private static void Folder_DragDrop(object sender, DragEventArgs e)
	{
		if (e.Effect != DragDropEffects.Copy || NewLateBinding.LateGet(sender, null, "tag", new object[0], null, null, null) == null)
		{
			return;
		}
		if (sender is ListBox)
		{
			foreach (object item in (IEnumerable)e.Data.GetData(DataFormats.FileDrop))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				AddPath2ListBox((ListBox)NewLateBinding.LateGet(sender, null, "tag", new object[0], null, null, null), Conversions.ToString(objectValue));
			}
			return;
		}
		(NewLateBinding.LateGet(sender, null, "tag", new object[0], null, null, null) as TextBox).Text = Conversions.ToString(NewLateBinding.LateIndexGet(e.Data.GetData(DataFormats.FileDrop), new object[1] { 0 }, null));
	}

	private static void Folder_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.None;
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			if ((array.Length == 1 || sender is ListBox) && Directory.Exists(array[0]))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
	}

	private static void File_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.None;
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (array.Length == 1 && (File.Exists(array[0]) & (MySettingsProperty.Settings.InputFileType.ToUpper() + ";").Contains((Path.GetExtension(array[0]) + ";").ToUpper())))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
	}

	public static void ViewReport(DataTable dt, string Caption, Label StatusLabel = null, bool OnlyExoprt = true, string ExcelFilename = "")
	{
		checked
		{
			try
			{
				if (dt != null)
				{
					if (dt.Rows.Count > 0)
					{
						if (StatusLabel == null)
						{
							StatusLabel = new Label();
						}
						frmExport2Excel frmExport2Excel2 = new frmExport2Excel();
						int num = 0;
						string captionText = "CheckSheet - Ver : " + Declarations.gToolVersion;
						frmExport2Excel2.dgResult.CaptionText = captionText;
						frmExport2Excel2.dgResult.DataSource = dt;
						frmExport2Excel2.lblStatus = StatusLabel;
						if (Operators.CompareString(ExcelFilename, "", TextCompare: false) != 0)
						{
							frmExport2Excel2.strExcelFileName = ExcelFilename;
						}
						frmExport2Excel2.PanButton.Left = (int)Math.Round((double)frmExport2Excel2.Width / 2.0 - (double)frmExport2Excel2.PanButton.Width / 2.0);
						frmExport2Excel2.groFilter.Left = (int)Math.Round((double)frmExport2Excel2.Width / 2.0 - (double)frmExport2Excel2.groFilter.Width / 2.0);
						frmExport2Excel2.pbReport.Left = (int)Math.Round((double)frmExport2Excel2.Width / 2.0 - (double)frmExport2Excel2.pbReport.Width / 2.0);
						if (OnlyExoprt)
						{
							frmExport2Excel2.Show();
							frmExport2Excel2.btnExport.PerformClick();
							frmExport2Excel2.Close();
						}
						else
						{
							frmExport2Excel2.ShowDialog();
						}
					}
					else
					{
						MessageBox.Show("No Records", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else
				{
					MessageBox.Show("No Records", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show("Error to show the Data", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void Export2excel(DataTable Result, ProgressBar PB, Label StatusLabel = null, string Caption = "", string ExcelFilename = "")
	{
		Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		Workbook workbook = application.Application.Workbooks.Add(true);
		Worksheet worksheet = null;
		if (StatusLabel == null)
		{
			StatusLabel = new Label();
		}
		if (PB == null)
		{
			PB = new ProgressBar();
		}
		while (workbook.Sheets.Count > 1)
		{
			NewLateBinding.LateCall(workbook.Sheets[1], null, "Delete", new object[0], null, null, null, IgnoreReturn: true);
		}
		worksheet = (Worksheet)workbook.Sheets[1];
		worksheet.Name = "Report";
		checked
		{
			try
			{
				object[,] array = new object[Result.Rows.Count + 1, Result.Columns.Count - 1 + 1];
				PB.Visible = true;
				PB.Maximum = Result.Rows.Count;
				PB.Minimum = 0;
				PB.Value = 0;
				PB.Visible = true;
				PB.Step = 1;
				System.Windows.Forms.Application.DoEvents();
				int num = Result.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					array[0, i] = Result.Columns[i].Caption;
				}
				PB.PerformStep();
				SetStatus(StatusLabel, Conversions.ToString(PB.Value) + " Of " + Conversions.ToString(PB.Maximum));
				int num2 = Result.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = Result.Columns.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						if (Result.Rows[j][k] is TimeSpan)
						{
							array[j + 1, k] = ((TimeSpan)Result.Rows[j][k]/*cast due to .constrained prefix*/).ToString();
						}
						else
						{
							array[j + 1, k] = RuntimeHelpers.GetObjectValue(Result.Rows[j][k]);
						}
					}
					PB.PerformStep();
					SetStatus(StatusLabel, Conversions.ToString(PB.Value) + " Of " + Conversions.ToString(PB.Maximum));
					System.Windows.Forms.Application.DoEvents();
				}
				PB.Visible = false;
				Range range = ((_Worksheet)worksheet).get_Range((object)"D1", RuntimeHelpers.GetObjectValue(Missing.Value));
				range.Value2 = Caption;
				application.Cells.Borders.ColorIndex = 2;
				application.Cells.NumberFormat = "@";
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[2, Result.Columns.Count + 1])).Interior.ColorIndex = 15;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[2, Result.Columns.Count + 1])).Font.Bold = true;
				range = ((_Worksheet)worksheet).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[Result.Rows.Count + 2, Result.Columns.Count + 1]));
				range.Value2 = array;
				((_Application)application).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(worksheet.Cells[1, worksheet.Cells.Columns.Count])).Font.Bold = true;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[Result.Rows.Count + 2, Result.Columns.Count + 1])).Borders.LineStyle = XlLineStyle.xlContinuous;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[Result.Rows.Count + 2, Result.Columns.Count + 1])).Borders.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[Result.Rows.Count + 2, Result.Columns.Count + 1])).Columns.AutoFit();
				try
				{
					bool flag = false;
					if (Operators.CompareString(ExcelFilename.Trim(), "", TextCompare: false) != 0)
					{
						if (File.Exists(ExcelFilename))
						{
							if (MessageBox.Show("\"" + ExcelFilename + "\"\r\nThe above file is already Exists. Do you want to replace it ...?", Declarations.gToolName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								try
								{
									File.Delete(ExcelFilename);
									flag = true;
								}
								catch (Exception ex)
								{
									ProjectData.SetProjectError(ex);
									Exception ex2 = ex;
									MessageBox.Show("\"" + ExcelFilename + "\"\r\nUnable to remove the old file", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									ProjectData.ClearProjectError();
								}
							}
						}
						else
						{
							flag = true;
						}
					}
					string text = MyProject.Forms.frmMain.txtFolder.Text;
					if (flag)
					{
						worksheet.SaveAs(ExcelFilename, text, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
					}
					application.Visible = true;
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				Exception ex6 = ex5;
				MessageBox.Show("Error in Excel File Creation", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				bool flag2 = false;
				workbook.Close(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				application.Application.Quit();
				application.Quit();
				application = null;
				GC.Collect();
				ProjectData.ClearProjectError();
			}
			finally
			{
				PB.Visible = false;
			}
			System.Windows.Forms.Application.DoEvents();
		}
	}

	public static void Export2excel_WithColour(DataTable dtResult, ProgressBar PB, Label StatusLabel = null, string Caption = "", string ExcelFilename = "", string ECNDesc = "")
	{
		ExcelFilename = "CS_" + CheckSheetFunctios.ECN_ID;
		Microsoft.Office.Interop.Excel.Application application = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
		Workbook workbook = application.Application.Workbooks.Add(true);
		Worksheet worksheet = null;
		DataTable dataTable = new DataTable();
		if (StatusLabel == null)
		{
			StatusLabel = new Label();
		}
		if (PB == null)
		{
			PB = new ProgressBar();
		}
		while (workbook.Sheets.Count > 1)
		{
			NewLateBinding.LateCall(workbook.Sheets[1], null, "Delete", new object[0], null, null, null, IgnoreReturn: true);
		}
		worksheet = (Worksheet)workbook.Sheets[1];
		worksheet.Name = "Report";
		checked
		{
			try
			{
				dataTable = dtResult.Copy();
				dataTable.Columns.RemoveAt(0);
				object[,] array = new object[dataTable.Rows.Count + 1, dataTable.Columns.Count - 1 + 1];
				PB.Visible = true;
				PB.Maximum = dataTable.Rows.Count;
				PB.Minimum = 0;
				PB.Value = 0;
				PB.Visible = true;
				PB.Step = 1;
				System.Windows.Forms.Application.DoEvents();
				int num = dataTable.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					array[0, i] = dataTable.Columns[i].Caption;
				}
				Range range = ((_Worksheet)worksheet).get_Range((object)"B1", RuntimeHelpers.GetObjectValue(Missing.Value));
				range.Value2 = Caption;
				application.Cells.Borders.ColorIndex = 2;
				application.Cells.NumberFormat = "@";
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[2, dataTable.Columns.Count + 1])).Interior.ColorIndex = 16;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[2, dataTable.Columns.Count + 1])).Font.Bold = true;
				((_Application)application).get_Range((object)"A1", RuntimeHelpers.GetObjectValue(worksheet.Cells[1, worksheet.Cells.Columns.Count])).Font.Bold = true;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[dataTable.Rows.Count + 2, dataTable.Columns.Count + 1])).Borders.LineStyle = XlLineStyle.xlContinuous;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[dataTable.Rows.Count + 2, dataTable.Columns.Count + 1])).Borders.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
				PB.PerformStep();
				SetStatus(StatusLabel, Conversions.ToString(PB.Value) + " Of " + Conversions.ToString(PB.Maximum));
				int num2 = dataTable.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = dataTable.Columns.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						if (dataTable.Rows[j][k] is TimeSpan)
						{
							array[j + 1, k] = ((TimeSpan)dataTable.Rows[j][k]/*cast due to .constrained prefix*/).ToString();
						}
						else
						{
							array[j + 1, k] = RuntimeHelpers.GetObjectValue(dataTable.Rows[j][k]);
						}
					}
					string left = (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dtResult.AsEnumerable().ElementAtOrDefault(j)[0])) ? "" : NewLateBinding.LateGet(dtResult.AsEnumerable().ElementAtOrDefault(j)[0], null, "Trim", new object[0], null, null, null).ToString());
					if (Operators.CompareString(left, "", TextCompare: false) != 0)
					{
						string[] array2 = Conversions.ToString(dtResult.AsEnumerable().ElementAtOrDefault(j)[0]).Split(';');
						foreach (string text in array2)
						{
							try
							{
								string[] array3 = text.Split('|');
								if (array3.Length <= 1)
								{
									continue;
								}
								Declarations.Excel_Colour excel_Colour;
								string[] array4;
								unchecked
								{
									excel_Colour = (Declarations.Excel_Colour)Conversions.ToInteger(array3[0]);
									excel_Colour = (Declarations.Excel_Colour)Conversions.ToInteger(array3[0]);
									array4 = array3[1].Split(',');
								}
								foreach (string value in array4)
								{
									try
									{
										NewLateBinding.LateSetComplex(NewLateBinding.LateGet(worksheet.Cells[j + 3, Conversions.ToInteger(value) + 1], null, "Interior", new object[0], null, null, null), null, "ColorIndex", new object[1] { excel_Colour }, null, null, OptimisticSet: false, RValueBase: true);
									}
									catch (Exception ex)
									{
										ProjectData.SetProjectError(ex);
										Exception ex2 = ex;
										ProjectData.ClearProjectError();
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
					}
					PB.PerformStep();
					SetStatus(StatusLabel, Conversions.ToString(PB.Value) + " Of " + Conversions.ToString(PB.Maximum));
					System.Windows.Forms.Application.DoEvents();
				}
				PB.Visible = false;
				range = ((_Worksheet)worksheet).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[dataTable.Rows.Count + 2, dataTable.Columns.Count + 1]));
				range.Value2 = array;
				((_Application)application).get_Range(RuntimeHelpers.GetObjectValue(worksheet.Cells[2, 2]), RuntimeHelpers.GetObjectValue(worksheet.Cells[dataTable.Rows.Count + 2, dataTable.Columns.Count + 1])).Columns.AutoFit();
				worksheet.Activate();
				worksheet.Application.ActiveWindow.SplitRow = 2;
				worksheet.Application.ActiveWindow.FreezePanes = true;
				Range range2 = (Range)worksheet.Rows[2, RuntimeHelpers.GetObjectValue(Missing.Value)];
				range2.AutoFilter(2, RuntimeHelpers.GetObjectValue(Type.Missing), XlAutoFilterOperator.xlAnd, RuntimeHelpers.GetObjectValue(Type.Missing), true);
				NewLateBinding.LateSetComplex(application.Columns["Y:Y", RuntimeHelpers.GetObjectValue(Missing.Value)], null, "ColumnWidth", new object[1] { 60 }, null, null, OptimisticSet: false, RValueBase: true);
				((_Application)application).get_Range((object)"C:Z", RuntimeHelpers.GetObjectValue(Missing.Value)).Columns.AutoFit();
				NewLateBinding.LateSetComplex(NewLateBinding.LateGet(application.Columns["AF:AF", RuntimeHelpers.GetObjectValue(Missing.Value)], null, "Columns", new object[0], null, null, null), null, "Wraptext", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex(application.Columns["AF:AF", RuntimeHelpers.GetObjectValue(Missing.Value)], null, "ColumnWidth", new object[1] { 60 }, null, null, OptimisticSet: false, RValueBase: true);
				((_Application)application).get_Range((object)"AF:AF", RuntimeHelpers.GetObjectValue(Missing.Value)).Columns.AutoFit();
				try
				{
					bool flag = false;
					if (Operators.CompareString(ExcelFilename.Trim(), "", TextCompare: false) != 0)
					{
						string path = FldrPath + "\\" + ExcelFilename + ".xlsx";
						if (File.Exists(path))
						{
							try
							{
								File.Delete(path);
								flag = true;
							}
							catch (Exception ex5)
							{
								ProjectData.SetProjectError(ex5);
								Exception ex6 = ex5;
								MessageBox.Show("\"" + ExcelFilename + "\"\r\nUnable to remove the old file", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								ProjectData.ClearProjectError();
							}
						}
						else
						{
							flag = true;
						}
					}
					string text2 = ((Operators.CompareString(MFldrPath, "", TextCompare: false) == 0) ? (FldrPath + "\\" + CheckSheetFunctios.ECN_ID) : FldrPath);
					string left2 = "Save";
					if (Operators.CompareString(MFldrPath, "", TextCompare: false) == 0 && !Directory.Exists(text2))
					{
						switch (MessageBox.Show(CheckSheetFunctios.ECN_ID + "- Folder Not Exists Do youwant to Create", " Folder Info...", MessageBoxButtons.YesNo))
						{
						case DialogResult.Yes:
							Directory.CreateDirectory(text2);
							break;
						case DialogResult.No:
							left2 = "";
							break;
						}
					}
					if (Operators.CompareString(left2, "", TextCompare: false) != 0 && flag)
					{
						worksheet.SaveAs(text2 + "\\" + ExcelFilename, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
					}
				}
				catch (Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					Exception ex8 = ex7;
					ProjectData.ClearProjectError();
				}
				if (Operators.CompareString(RptSts, "Open", TextCompare: false) == 0)
				{
					application.Visible = true;
				}
				else
				{
					Marshal.ReleaseComObject(worksheet);
					workbook.Close(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
					Marshal.ReleaseComObject(workbook);
					application.Application.Quit();
					Marshal.FinalReleaseComObject(application);
					Marshal.CleanupUnusedObjectsInCurrentContext();
					application = null;
					GC.Collect();
				}
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				Exception ex10 = ex9;
				MessageBox.Show("Error in Excel File Creation", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Interaction.MsgBox(ex10.ToString());
				MessageBox.Show((IWin32Window)ex10, Declarations.gToolName, Conversions.ToString(0), (MessageBoxButtons)16);
				Marshal.ReleaseComObject(worksheet);
				workbook.Close(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
				Marshal.ReleaseComObject(workbook);
				application.Application.Quit();
				Marshal.FinalReleaseComObject(application);
				Marshal.CleanupUnusedObjectsInCurrentContext();
				application = null;
				GC.Collect();
				ProjectData.ClearProjectError();
			}
			finally
			{
				PB.Visible = false;
				GC.Collect();
			}
			System.Windows.Forms.Application.DoEvents();
		}
	}

	public static void Export2CSVorTXT(DataTable Result, ProgressBar PB, bool isCSV = true, Label StatusLabel = null, string Caption = "")
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		string empty = string.Empty;
		if (isCSV)
		{
			saveFileDialog.DefaultExt = "*.csv";
			saveFileDialog.Filter = "CSV File |*.csv";
			empty = ",";
		}
		else
		{
			saveFileDialog.DefaultExt = "*.txt";
			saveFileDialog.Filter = "Text File |*.txt";
			empty = "|";
		}
		saveFileDialog.AddExtension = true;
		if (StatusLabel == null)
		{
			StatusLabel = new Label();
		}
		if (PB == null)
		{
			PB = new ProgressBar();
		}
		checked
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				StreamWriter streamWriter = null;
				string fileName = saveFileDialog.FileName;
				try
				{
					if (File.Exists(saveFileDialog.FileName))
					{
						File.Delete(fileName);
					}
					FileStream fileStream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write, FileShare.None);
					streamWriter = new StreamWriter(fileStream);
					string empty2 = string.Empty;
					PB.Visible = true;
					PB.Maximum = Result.Rows.Count;
					PB.Minimum = 0;
					PB.Value = 0;
					PB.Visible = true;
					PB.Step = 1;
					System.Windows.Forms.Application.DoEvents();
					empty2 = "";
					if (Result.Columns[0].ColumnMapping == MappingType.Hidden)
					{
						Result.Columns.RemoveAt(0);
					}
					int num = Result.Columns.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						empty2 = ((Operators.CompareString(empty2, "", TextCompare: false) != 0) ? (empty2 + empty + Result.Columns[i].Caption) : (empty2 + Result.Columns[i].Caption));
					}
					streamWriter.WriteLine(empty2);
					PB.PerformStep();
					SetStatus(StatusLabel, Conversions.ToString(PB.Value) + " Of " + Conversions.ToString(PB.Maximum));
					int num2 = Result.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						empty2 = "";
						int num3 = Result.Columns.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							if (Operators.CompareString(empty2, "", TextCompare: false) != 0)
							{
								empty2 += empty;
							}
							empty2 = ((!(Result.Rows[j][k] is TimeSpan)) ? Conversions.ToString(Operators.ConcatenateObject(empty2, Result.Rows[j][k])) : (empty2 + ((TimeSpan)Result.Rows[j][k]/*cast due to .constrained prefix*/).ToString()));
						}
						streamWriter.WriteLine(empty2);
						PB.PerformStep();
						SetStatus(StatusLabel, Conversions.ToString(PB.Value) + " Of " + Conversions.ToString(PB.Maximum));
						System.Windows.Forms.Application.DoEvents();
					}
					PB.Visible = false;
					streamWriter.Close();
					fileStream.Close();
					MessageBox.Show("File Successfully Created", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					MessageBox.Show("Error in File Creation", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					bool flag = false;
					GC.Collect();
					ProjectData.ClearProjectError();
				}
				finally
				{
					FileStream fileStream = null;
					streamWriter = null;
					PB.Visible = false;
				}
			}
			System.Windows.Forms.Application.DoEvents();
		}
	}
}
