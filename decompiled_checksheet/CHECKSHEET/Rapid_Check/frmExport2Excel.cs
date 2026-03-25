using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Rapid_Check;

[DesignerGenerated]
public class frmExport2Excel : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExport")]
	private Button _btnExport;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgResult")]
	private DataGrid _dgResult;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mnuiRemove")]
	private ToolStripMenuItem _mnuiRemove;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("groFilter")]
	private GroupBox _groFilter;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("txtColname")]
	private TextBox _txtColname;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private Button _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAdd")]
	private Button _btnAdd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("txtFilter")]
	private TextBox _txtFilter;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnClear")]
	private Button _btnClear;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnClose")]
	private Button _btnClose;

	public Label lblStatus;

	public string strExcelFileName;

	private DataTable dtaMain;

	internal virtual Button btnExport
	{
		[CompilerGenerated]
		get
		{
			return _btnExport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnExport_Click;
			Button button = _btnExport;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnExport = value;
			button = _btnExport;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("txtCount")]
	internal virtual TextBox txtCount
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("pbReport")]
	internal virtual ProgressBar pbReport
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblCount")]
	internal virtual Label lblCount
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual DataGrid dgResult
	{
		[CompilerGenerated]
		get
		{
			return _dgResult;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dgResult_DataSourceChanged;
			MouseEventHandler value3 = dgResult_MouseDown;
			DataGrid dataGrid = _dgResult;
			if (dataGrid != null)
			{
				dataGrid.DataSourceChanged -= value2;
				dataGrid.MouseDown -= value3;
			}
			_dgResult = value;
			dataGrid = _dgResult;
			if (dataGrid != null)
			{
				dataGrid.DataSourceChanged += value2;
				dataGrid.MouseDown += value3;
			}
		}
	}

	[field: AccessedThroughProperty("SaveFile")]
	internal virtual SaveFileDialog SaveFile
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CmnuRemove")]
	internal virtual ContextMenuStrip CmnuRemove
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuiRemove
	{
		[CompilerGenerated]
		get
		{
			return _mnuiRemove;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mnuiRemove_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuiRemove;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_mnuiRemove = value;
			toolStripMenuItem = _mnuiRemove;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual GroupBox groFilter
	{
		[CompilerGenerated]
		get
		{
			return _groFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DragEventHandler value2 = Filter_DragDrop;
			DragEventHandler value3 = Filter_DragEnter;
			GroupBox groupBox = _groFilter;
			if (groupBox != null)
			{
				groupBox.DragDrop -= value2;
				groupBox.DragEnter -= value3;
			}
			_groFilter = value;
			groupBox = _groFilter;
			if (groupBox != null)
			{
				groupBox.DragDrop += value2;
				groupBox.DragEnter += value3;
			}
		}
	}

	[field: AccessedThroughProperty("txtColData")]
	internal virtual TextBox txtColData
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtColname
	{
		[CompilerGenerated]
		get
		{
			return _txtColname;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = txtColname_TextChanged;
			TextBox textBox = _txtColname;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
			}
			_txtColname = value;
			textBox = _txtColname;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
			}
		}
	}

	internal virtual Button btnOk
	{
		[CompilerGenerated]
		get
		{
			return _btnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnOk_Click;
			Button button = _btnOk;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnOk = value;
			button = _btnOk;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btnAdd
	{
		[CompilerGenerated]
		get
		{
			return _btnAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnAdd_Click;
			Button button = _btnAdd;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnAdd = value;
			button = _btnAdd;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox txtFilter
	{
		[CompilerGenerated]
		get
		{
			return _txtFilter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DragEventHandler value2 = Filter_DragEnter;
			EventHandler value3 = txtFilter_TextChanged;
			TextBox textBox = _txtFilter;
			if (textBox != null)
			{
				textBox.DragEnter -= value2;
				textBox.TextChanged -= value3;
			}
			_txtFilter = value;
			textBox = _txtFilter;
			if (textBox != null)
			{
				textBox.DragEnter += value2;
				textBox.TextChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label2")]
	internal virtual Label Label2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnClear
	{
		[CompilerGenerated]
		get
		{
			return _btnClear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnClear_Click;
			Button button = _btnClear;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnClear = value;
			button = _btnClear;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("PanButton")]
	internal virtual Panel PanButton
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("rbtCSV")]
	internal virtual RadioButton rbtCSV
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("rbtExcel")]
	internal virtual RadioButton rbtExcel
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("rbtText")]
	internal virtual RadioButton rbtText
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button btnClose
	{
		[CompilerGenerated]
		get
		{
			return _btnClose;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnClose_Click;
			Button button = _btnClose;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnClose = value;
			button = _btnClose;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("cmbOperator")]
	internal virtual ComboBox cmbOperator
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblECNDesc")]
	internal virtual Label lblECNDesc
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public frmExport2Excel()
	{
		base.Load += frmExport2Excel_Load;
		lblStatus = null;
		strExcelFileName = string.Empty;
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.btnExport = new System.Windows.Forms.Button();
		this.txtCount = new System.Windows.Forms.TextBox();
		this.pbReport = new System.Windows.Forms.ProgressBar();
		this.lblCount = new System.Windows.Forms.Label();
		this.dgResult = new System.Windows.Forms.DataGrid();
		this.SaveFile = new System.Windows.Forms.SaveFileDialog();
		this.CmnuRemove = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.mnuiRemove = new System.Windows.Forms.ToolStripMenuItem();
		this.groFilter = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.cmbOperator = new System.Windows.Forms.ComboBox();
		this.btnClear = new System.Windows.Forms.Button();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtFilter = new System.Windows.Forms.TextBox();
		this.btnOk = new System.Windows.Forms.Button();
		this.btnAdd = new System.Windows.Forms.Button();
		this.txtColData = new System.Windows.Forms.TextBox();
		this.txtColname = new System.Windows.Forms.TextBox();
		this.PanButton = new System.Windows.Forms.Panel();
		this.btnClose = new System.Windows.Forms.Button();
		this.rbtExcel = new System.Windows.Forms.RadioButton();
		this.rbtCSV = new System.Windows.Forms.RadioButton();
		this.rbtText = new System.Windows.Forms.RadioButton();
		this.lblECNDesc = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.dgResult).BeginInit();
		this.CmnuRemove.SuspendLayout();
		this.groFilter.SuspendLayout();
		this.PanButton.SuspendLayout();
		base.SuspendLayout();
		this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnExport.Location = new System.Drawing.Point(0, 2);
		this.btnExport.Name = "btnExport";
		this.btnExport.Size = new System.Drawing.Size(64, 24);
		this.btnExport.TabIndex = 0;
		this.btnExport.Text = "&Export";
		this.btnExport.UseVisualStyleBackColor = false;
		this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCount.Location = new System.Drawing.Point(530, 322);
		this.txtCount.Name = "txtCount";
		this.txtCount.ReadOnly = true;
		this.txtCount.Size = new System.Drawing.Size(72, 20);
		this.txtCount.TabIndex = 7;
		this.pbReport.ForeColor = System.Drawing.Color.Maroon;
		this.pbReport.Location = new System.Drawing.Point(125, 139);
		this.pbReport.Name = "pbReport";
		this.pbReport.Size = new System.Drawing.Size(356, 20);
		this.pbReport.Step = 0;
		this.pbReport.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
		this.pbReport.TabIndex = 8;
		this.lblCount.AutoSize = true;
		this.lblCount.ForeColor = System.Drawing.Color.Navy;
		this.lblCount.Location = new System.Drawing.Point(493, 325);
		this.lblCount.Name = "lblCount";
		this.lblCount.Size = new System.Drawing.Size(35, 13);
		this.lblCount.TabIndex = 6;
		this.lblCount.Text = "Count";
		this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.dgResult.CaptionBackColor = System.Drawing.Color.LightSteelBlue;
		this.dgResult.DataMember = "";
		this.dgResult.HeaderFont = new System.Drawing.Font("Comic Sans MS", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.dgResult.HeaderForeColor = System.Drawing.Color.Green;
		this.dgResult.Location = new System.Drawing.Point(5, 5);
		this.dgResult.Name = "dgResult";
		this.dgResult.ReadOnly = true;
		this.dgResult.RowHeadersVisible = false;
		this.dgResult.Size = new System.Drawing.Size(597, 312);
		this.dgResult.TabIndex = 0;
		this.dgResult.TabStop = false;
		this.CmnuRemove.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.CmnuRemove.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.mnuiRemove });
		this.CmnuRemove.Name = "CmnuRemove";
		this.CmnuRemove.Size = new System.Drawing.Size(118, 26);
		this.mnuiRemove.Name = "mnuiRemove";
		this.mnuiRemove.Size = new System.Drawing.Size(117, 22);
		this.mnuiRemove.Text = "&Remove";
		this.groFilter.Controls.Add(this.Label2);
		this.groFilter.Controls.Add(this.cmbOperator);
		this.groFilter.Controls.Add(this.btnClear);
		this.groFilter.Controls.Add(this.Label3);
		this.groFilter.Controls.Add(this.Label1);
		this.groFilter.Controls.Add(this.txtFilter);
		this.groFilter.Controls.Add(this.btnOk);
		this.groFilter.Controls.Add(this.btnAdd);
		this.groFilter.Controls.Add(this.txtColData);
		this.groFilter.Controls.Add(this.txtColname);
		this.groFilter.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groFilter.ForeColor = System.Drawing.Color.Green;
		this.groFilter.Location = new System.Drawing.Point(5, 344);
		this.groFilter.Name = "groFilter";
		this.groFilter.Size = new System.Drawing.Size(597, 110);
		this.groFilter.TabIndex = 4;
		this.groFilter.TabStop = false;
		this.groFilter.Text = "Filter";
		this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.ForeColor = System.Drawing.Color.Crimson;
		this.Label2.Location = new System.Drawing.Point(206, 20);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(69, 24);
		this.Label2.TabIndex = 5;
		this.Label2.Text = "Operator";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.cmbOperator.FormattingEnabled = true;
		this.cmbOperator.Items.AddRange(new object[12]
		{
			"=", "<>", ">", "<", ">=", "<=", "Like", "Not Like", "Start With", "End With",
			"Is Null", "Is Not Null"
		});
		this.cmbOperator.Location = new System.Drawing.Point(275, 20);
		this.cmbOperator.Name = "cmbOperator";
		this.cmbOperator.Size = new System.Drawing.Size(98, 27);
		this.cmbOperator.TabIndex = 9;
		this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnClear.Location = new System.Drawing.Point(545, 46);
		this.btnClear.Name = "btnClear";
		this.btnClear.Size = new System.Drawing.Size(46, 29);
		this.btnClear.TabIndex = 8;
		this.btnClear.Text = "&Clear";
		this.btnClear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btnClear.UseVisualStyleBackColor = false;
		this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label3.ForeColor = System.Drawing.Color.Crimson;
		this.Label3.Location = new System.Drawing.Point(374, 20);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(70, 24);
		this.Label3.TabIndex = 6;
		this.Label3.Text = "Value";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.Crimson;
		this.Label1.Location = new System.Drawing.Point(6, 20);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(100, 24);
		this.Label1.TabIndex = 4;
		this.Label1.Text = "Column Name";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtFilter.Font = new System.Drawing.Font("Comic Sans MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtFilter.ForeColor = System.Drawing.Color.DarkGoldenrod;
		this.txtFilter.Location = new System.Drawing.Point(6, 46);
		this.txtFilter.Multiline = true;
		this.txtFilter.Name = "txtFilter";
		this.txtFilter.ReadOnly = true;
		this.txtFilter.Size = new System.Drawing.Size(537, 59);
		this.txtFilter.TabIndex = 3;
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnOk.Location = new System.Drawing.Point(545, 76);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(46, 29);
		this.btnOk.TabIndex = 9;
		this.btnOk.Text = "&Ok";
		this.btnOk.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btnOk.UseVisualStyleBackColor = false;
		this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnAdd.Location = new System.Drawing.Point(545, 20);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Size = new System.Drawing.Size(46, 24);
		this.btnAdd.TabIndex = 7;
		this.btnAdd.Text = "&Add";
		this.btnAdd.UseVisualStyleBackColor = false;
		this.txtColData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtColData.Font = new System.Drawing.Font("Comic Sans MS", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtColData.Location = new System.Drawing.Point(443, 20);
		this.txtColData.Name = "txtColData";
		this.txtColData.Size = new System.Drawing.Size(100, 24);
		this.txtColData.TabIndex = 2;
		this.txtColname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtColname.Font = new System.Drawing.Font("Comic Sans MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtColname.Location = new System.Drawing.Point(105, 20);
		this.txtColname.Name = "txtColname";
		this.txtColname.ReadOnly = true;
		this.txtColname.Size = new System.Drawing.Size(100, 24);
		this.txtColname.TabIndex = 0;
		this.txtColname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.PanButton.Controls.Add(this.btnClose);
		this.PanButton.Controls.Add(this.btnExport);
		this.PanButton.Location = new System.Drawing.Point(242, 322);
		this.PanButton.Name = "PanButton";
		this.PanButton.Size = new System.Drawing.Size(136, 28);
		this.PanButton.TabIndex = 5;
		this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnClose.Location = new System.Drawing.Point(70, 2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(64, 24);
		this.btnClose.TabIndex = 1;
		this.btnClose.Text = "&Close";
		this.btnClose.UseVisualStyleBackColor = false;
		this.rbtExcel.AutoSize = true;
		this.rbtExcel.Checked = true;
		this.rbtExcel.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold);
		this.rbtExcel.ForeColor = System.Drawing.Color.Chocolate;
		this.rbtExcel.Location = new System.Drawing.Point(12, 323);
		this.rbtExcel.Name = "rbtExcel";
		this.rbtExcel.Size = new System.Drawing.Size(61, 23);
		this.rbtExcel.TabIndex = 1;
		this.rbtExcel.TabStop = true;
		this.rbtExcel.Text = "Excel";
		this.rbtExcel.UseVisualStyleBackColor = true;
		this.rbtCSV.AutoSize = true;
		this.rbtCSV.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold);
		this.rbtCSV.ForeColor = System.Drawing.Color.Chocolate;
		this.rbtCSV.Location = new System.Drawing.Point(79, 323);
		this.rbtCSV.Name = "rbtCSV";
		this.rbtCSV.Size = new System.Drawing.Size(53, 23);
		this.rbtCSV.TabIndex = 2;
		this.rbtCSV.Text = "CSV";
		this.rbtCSV.UseVisualStyleBackColor = true;
		this.rbtText.AutoSize = true;
		this.rbtText.Font = new System.Drawing.Font("Comic Sans MS", 9.75f, System.Drawing.FontStyle.Bold);
		this.rbtText.ForeColor = System.Drawing.Color.Chocolate;
		this.rbtText.Location = new System.Drawing.Point(138, 323);
		this.rbtText.Name = "rbtText";
		this.rbtText.Size = new System.Drawing.Size(57, 23);
		this.rbtText.TabIndex = 3;
		this.rbtText.Text = "Text";
		this.rbtText.UseVisualStyleBackColor = true;
		this.lblECNDesc.AutoSize = true;
		this.lblECNDesc.Location = new System.Drawing.Point(411, 324);
		this.lblECNDesc.Name = "lblECNDesc";
		this.lblECNDesc.Size = new System.Drawing.Size(0, 13);
		this.lblECNDesc.TabIndex = 9;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(606, 459);
		base.Controls.Add(this.lblECNDesc);
		base.Controls.Add(this.pbReport);
		base.Controls.Add(this.rbtText);
		base.Controls.Add(this.PanButton);
		base.Controls.Add(this.rbtCSV);
		base.Controls.Add(this.txtCount);
		base.Controls.Add(this.rbtExcel);
		base.Controls.Add(this.groFilter);
		base.Controls.Add(this.lblCount);
		base.Controls.Add(this.dgResult);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.Name = "frmExport2Excel";
		this.Text = "Export2Excel";
		((System.ComponentModel.ISupportInitialize)this.dgResult).EndInit();
		this.CmnuRemove.ResumeLayout(false);
		this.groFilter.ResumeLayout(false);
		this.groFilter.PerformLayout();
		this.PanButton.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void frmExport2Excel_Load(object sender, EventArgs e)
	{
		dtaMain = (DataTable)dgResult.DataSource;
		checked
		{
			int num = dtaMain.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dtaMain.Columns[i].ColumnName = dtaMain.Columns[i].ColumnName.Replace(" ", "_");
			}
			groFilter.AllowDrop = true;
			if (cmbOperator.Items.Count > 0)
			{
				cmbOperator.SelectedIndex = 0;
			}
			foreach (Control control in groFilter.Controls)
			{
				control.AllowDrop = true;
				control.DragDrop += Filter_DragDrop;
				control.DragEnter += Filter_DragEnter;
			}
			pbReport.Visible = false;
			btnAdd.Enabled = false;
			btnClear.Enabled = false;
			btnOk.Enabled = false;
		}
	}

	private void dgResult_DataSourceChanged(object sender, EventArgs e)
	{
		try
		{
			if (dgResult.DataSource != null)
			{
				DataTable dataTable = (DataTable)dgResult.DataSource;
				txtCount.Text = Conversions.ToString(dataTable.Rows.Count);
			}
			else
			{
				txtCount.Text = Conversions.ToString(0);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void Excel_Report()
	{
		try
		{
			DataTable dataTable = (DataTable)dgResult.DataSource;
			if (dataTable == null)
			{
				return;
			}
			if (lblStatus != null)
			{
				Functions.SetStatus(lblStatus, "Wait...");
			}
			if (dataTable.Rows.Count > 0)
			{
				Cursor = Cursors.WaitCursor;
				btnExport.Enabled = false;
				btnClose.Enabled = false;
				if (rbtExcel.Checked)
				{
					if (dataTable.Columns[0].ColumnMapping == MappingType.Hidden)
					{
						Functions.Export2excel_WithColour(dataTable, pbReport, lblStatus, dgResult.CaptionText, strExcelFileName);
					}
					else
					{
						Functions.Export2excel(dataTable, pbReport, lblStatus, dgResult.CaptionText, strExcelFileName);
					}
				}
				else
				{
					Functions.Export2CSVorTXT(dataTable, pbReport, rbtCSV.Checked, lblStatus, dgResult.CaptionText);
				}
			}
			else
			{
				MessageBox.Show("No Records to Export", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		finally
		{
			Cursor = Cursors.Default;
			btnExport.Enabled = true;
			btnClose.Enabled = true;
		}
	}

	public void btnExport_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dataTable = (DataTable)dgResult.DataSource;
			if (dataTable == null)
			{
				return;
			}
			if (lblStatus != null)
			{
				Functions.SetStatus(lblStatus, "Wait...");
			}
			if (dataTable.Rows.Count > 0)
			{
				Cursor = Cursors.WaitCursor;
				btnExport.Enabled = false;
				btnClose.Enabled = false;
				if (rbtExcel.Checked)
				{
					if (dataTable.Columns[0].ColumnMapping == MappingType.Hidden)
					{
						Functions.Export2excel_WithColour(dataTable, pbReport, lblStatus, dgResult.CaptionText, strExcelFileName);
					}
					else
					{
						Functions.Export2excel(dataTable, pbReport, lblStatus, dgResult.CaptionText, strExcelFileName);
					}
				}
				else
				{
					Functions.Export2CSVorTXT(dataTable, pbReport, rbtCSV.Checked, lblStatus, dgResult.CaptionText);
				}
			}
			else
			{
				MessageBox.Show("No Records to Export", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		finally
		{
			Cursor = Cursors.Default;
			btnExport.Enabled = true;
			btnClose.Enabled = true;
		}
		if (lblStatus != null)
		{
			Functions.SetStatus(lblStatus);
		}
		Application.DoEvents();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void mnuiRemove_Click(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		try
		{
			DataTable dataTable = (DataTable)dgResult.DataSource;
			dataTable.Rows.RemoveAt(dgResult.CurrentRowIndex);
			dgResult.DataSource = dataTable;
			txtCount.Text = Conversions.ToString(dataTable.Rows.Count);
			if (dataTable.Rows.Count <= 0)
			{
				dgResult.ContextMenuStrip = CmnuRemove;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		finally
		{
			Cursor = Cursors.Default;
		}
	}

	private void dgResult_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			if (e.Button != MouseButtons.Left || ((dgResult.Cursor == Cursors.SizeWE) | (dgResult.Cursor == Cursors.SizeNS)))
			{
				return;
			}
			DataGrid.HitTestInfo hitTestInfo = dgResult.HitTest(e.Location);
			if (dgResult.DataSource == null)
			{
				return;
			}
			DataTable dataTable = (DataTable)dgResult.DataSource;
			if (hitTestInfo.Column != -1)
			{
				DragObject dragObject = new DragObject();
				int num = ((dataTable.Columns[0].ColumnMapping != MappingType.Hidden) ? hitTestInfo.Column : checked(hitTestInfo.Column + 1));
				dragObject.ColumnName = dataTable.Columns[num].ColumnName.ToUpper().ToString();
				if (hitTestInfo.Row == -1)
				{
					dragObject.Value = "";
				}
				else
				{
					dragObject.Value = Conversions.ToString(Interaction.IIf(dataTable.Rows[hitTestInfo.Row].IsNull(num), "", RuntimeHelpers.GetObjectValue(dataTable.Rows[hitTestInfo.Row][num])));
				}
				dgResult.DoDragDrop(dragObject, DragDropEffects.Copy);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Filter_DragDrop(object sender, DragEventArgs e)
	{
		try
		{
			if (e.Effect == DragDropEffects.Copy)
			{
				DragObject dragObject = new DragObject();
				dragObject = (DragObject)e.Data.GetData(DataFormats.Serializable);
				txtColname.Text = dragObject.ColumnName;
				txtColData.Text = dragObject.Value;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void Filter_DragEnter(object sender, DragEventArgs e)
	{
		try
		{
			if (e.Data.GetData(DataFormats.Serializable) is DragObject)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void txtFilter_TextChanged(object sender, EventArgs e)
	{
		btnClear.Enabled = Operators.CompareString(Strings.Trim(txtFilter.Text), "", TextCompare: false) != 0;
		btnOk.Enabled = Operators.CompareString(Strings.Trim(txtFilter.Text), "", TextCompare: false) != 0;
	}

	private void txtColname_TextChanged(object sender, EventArgs e)
	{
		btnAdd.Enabled = Operators.CompareString(Strings.Trim(txtColname.Text), "", TextCompare: false) != 0;
	}

	private void btnClear_Click(object sender, EventArgs e)
	{
		txtFilter.Text = "";
		dgResult.DataSource = dtaMain;
	}

	private void btnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			Cursor = Cursors.WaitCursor;
			string empty = string.Empty;
			if (cmbOperator.SelectedItem == null)
			{
				throw new Exception("Select the Operator");
			}
			empty = cmbOperator.GetItemText(RuntimeHelpers.GetObjectValue(cmbOperator.SelectedItem)).ToUpper();
			if (!((Operators.CompareString(empty, "IS NULL", TextCompare: false) == 0) | (Operators.CompareString(empty, "IS NOT NULL", TextCompare: false) == 0)) && Operators.CompareString(txtColData.Text.Trim(), "", TextCompare: false) == 0)
			{
				throw new Exception("Enter the Value");
			}
			if (Operators.CompareString(txtFilter.Text, "", TextCompare: false) != 0)
			{
				txtFilter.Text += "\r\n";
			}
			switch (empty)
			{
			case "START WITH":
				if ((object)dtaMain.Columns[txtColname.Text.Trim()].DataType == typeof(string))
				{
					TextBox textBox;
					(textBox = txtFilter).Text = textBox.Text + txtColname.Text.Trim() + " like '" + txtColData.Text + "%' ";
					break;
				}
				throw new Exception("Start With operator does not support in " + txtColname.Text.Trim() + " column.");
			case "END WITH":
				if ((object)dtaMain.Columns[txtColname.Text.Trim()].DataType == typeof(string))
				{
					TextBox textBox;
					(textBox = txtFilter).Text = textBox.Text + txtColname.Text.Trim() + " like '%" + txtColData.Text + "' ";
					break;
				}
				throw new Exception("End With operator does not support in " + txtColname.Text.Trim() + " column.");
			case "LIKE":
			case "NOT LIKE":
				if ((object)dtaMain.Columns[txtColname.Text.Trim()].DataType == typeof(string))
				{
					TextBox textBox;
					(textBox = txtFilter).Text = textBox.Text + txtColname.Text.Trim() + " " + empty + " '%" + txtColData.Text + "%' ";
					break;
				}
				throw new Exception("Like operator does not support in " + txtColname.Text.Trim() + " column.");
			case "IS NULL":
			case "IS NOT NULL":
			{
				TextBox textBox;
				(textBox = txtFilter).Text = textBox.Text + txtColname.Text.Trim() + " " + empty;
				break;
			}
			default:
			{
				TextBox textBox;
				(textBox = txtFilter).Text = textBox.Text + txtColname.Text.Trim() + " " + empty + " '" + txtColData.Text + "' ";
				break;
			}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			ProjectData.ClearProjectError();
		}
		finally
		{
			Cursor = Cursors.Default;
		}
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		try
		{
			Cursor = Cursors.WaitCursor;
			if (Operators.CompareString(txtFilter.Text, "", TextCompare: false) != 0)
			{
				DataView dataView = new DataView(dtaMain, txtFilter.Text.Replace("\r\n", " And "), "", DataViewRowState.CurrentRows);
				DataTable dataTable = dataView.ToTable();
				if (dataTable.Columns[0].ColumnMapping == MappingType.Hidden)
				{
					dataTable.Columns.RemoveAt(0);
				}
				dgResult.DataSource = dataTable;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			ProjectData.ClearProjectError();
		}
		finally
		{
			Cursor = Cursors.Default;
		}
	}
}
