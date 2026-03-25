#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Rapid_Check.My;
using Rapid_Check.My.Resources;
using SolidEdgeFileProperties;

namespace Rapid_Check;

[DesignerGenerated]
public class frmMain : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cmsTextbox")]
	private ContextMenuStrip _cmsTextbox;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cmiCopy")]
	private ToolStripMenuItem _cmiCopy;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cmiPaste")]
	private ToolStripMenuItem _cmiPaste;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cmiSelectAll")]
	private ToolStripMenuItem _cmiSelectAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExecute")]
	private Button _btnExecute;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnClose")]
	private Button _btnClose;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pbLogo")]
	private PictureBox _pbLogo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbChkSheet")]
	private RadioButton _rbChkSheet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MFldr")]
	private CheckBox _MFldr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox2")]
	private CheckBox _CheckBox2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("OpenRpt")]
	private CheckBox _OpenRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("comSite")]
	private JCombo _comSite;

	[field: AccessedThroughProperty("txtFolder")]
	internal virtual JTxtBox txtFolder
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanFolder")]
	internal virtual Panel PanFolder
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanNumber")]
	internal virtual Panel PanNumber
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtNumber_ID")]
	internal virtual JTxtBox txtNumber_ID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ContextMenuStrip cmsTextbox
	{
		[CompilerGenerated]
		get
		{
			return _cmsTextbox;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CancelEventHandler value2 = cmsTextbox_Opening;
			ContextMenuStrip contextMenuStrip = _cmsTextbox;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= value2;
			}
			_cmsTextbox = value;
			contextMenuStrip = _cmsTextbox;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem cmiCopy
	{
		[CompilerGenerated]
		get
		{
			return _cmiCopy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cmiCopy_Click;
			ToolStripMenuItem toolStripMenuItem = _cmiCopy;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_cmiCopy = value;
			toolStripMenuItem = _cmiCopy;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem cmiPaste
	{
		[CompilerGenerated]
		get
		{
			return _cmiPaste;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PasteFolder_or_File_Path;
			ToolStripMenuItem toolStripMenuItem = _cmiPaste;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_cmiPaste = value;
			toolStripMenuItem = _cmiPaste;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem cmiSelectAll
	{
		[CompilerGenerated]
		get
		{
			return _cmiSelectAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cmiSelectAll_Click;
			ToolStripMenuItem toolStripMenuItem = _cmiSelectAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click -= value2;
			}
			_cmiSelectAll = value;
			toolStripMenuItem = _cmiSelectAll;
			if (toolStripMenuItem != null)
			{
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual Button btnExecute
	{
		[CompilerGenerated]
		get
		{
			return _btnExecute;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = btnExecute_Click;
			Button button = _btnExecute;
			if (button != null)
			{
				button.Click -= value2;
			}
			_btnExecute = value;
			button = _btnExecute;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("pbProcess")]
	internal virtual ProgressBar pbProcess
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtStatus")]
	internal virtual TextBox txtStatus
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

	[field: AccessedThroughProperty("Label9")]
	internal virtual Label Label9
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Panel4")]
	internal virtual Panel Panel4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblFolder")]
	internal virtual Label lblFolder
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label7")]
	internal virtual Label Label7
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Panel5")]
	internal virtual Panel Panel5
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label3")]
	internal virtual Label Label3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtTC_Url")]
	internal virtual TextBox txtTC_Url
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label4")]
	internal virtual Label Label4
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtPassword")]
	internal virtual TextBox txtPassword
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("txtUserID")]
	internal virtual TextBox txtUserID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Label6")]
	internal virtual Label Label6
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("lblID")]
	internal virtual Label lblID
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual PictureBox pbLogo
	{
		[CompilerGenerated]
		get
		{
			return _pbLogo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pbLogo_Click;
			PictureBox pictureBox = _pbLogo;
			if (pictureBox != null)
			{
				pictureBox.Click -= value2;
			}
			_pbLogo = value;
			pictureBox = _pbLogo;
			if (pictureBox != null)
			{
				pictureBox.Click += value2;
			}
		}
	}

	internal virtual RadioButton rbChkSheet
	{
		[CompilerGenerated]
		get
		{
			return _rbChkSheet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rbChkSheet_CheckedChanged;
			RadioButton radioButton = _rbChkSheet;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			_rbChkSheet = value;
			radioButton = _rbChkSheet;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox MFldr
	{
		[CompilerGenerated]
		get
		{
			return _MFldr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox1_CheckedChanged;
			CheckBox checkBox = _MFldr;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_MFldr = value;
			checkBox = _MFldr;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CheckBox2
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox2_CheckedChanged;
			CheckBox checkBox = _CheckBox2;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_CheckBox2 = value;
			checkBox = _CheckBox2;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox OpenRpt
	{
		[CompilerGenerated]
		get
		{
			return _OpenRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OpenRpt_CheckedChanged;
			CheckBox checkBox = _OpenRpt;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_OpenRpt = value;
			checkBox = _OpenRpt;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ValBGN")]
	internal virtual CheckBox ValBGN
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public virtual JCombo comSite
	{
		[CompilerGenerated]
		get
		{
			return _comSite;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = comSite_SelectedIndexChanged;
			JCombo jCombo = _comSite;
			if (jCombo != null)
			{
				jCombo.SelectedIndexChanged -= value2;
			}
			_comSite = value;
			jCombo = _comSite;
			if (jCombo != null)
			{
				jCombo.SelectedIndexChanged += value2;
			}
		}
	}

	public frmMain()
	{
		base.Load += frmMain_Load;
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.PanFolder = new System.Windows.Forms.Panel();
		this.MFldr = new System.Windows.Forms.CheckBox();
		this.cmsTextbox = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.cmiCopy = new System.Windows.Forms.ToolStripMenuItem();
		this.cmiPaste = new System.Windows.Forms.ToolStripMenuItem();
		this.cmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
		this.PanNumber = new System.Windows.Forms.Panel();
		this.btnExecute = new System.Windows.Forms.Button();
		this.pbProcess = new System.Windows.Forms.ProgressBar();
		this.txtStatus = new System.Windows.Forms.TextBox();
		this.btnClose = new System.Windows.Forms.Button();
		this.Label9 = new System.Windows.Forms.Label();
		this.Panel4 = new System.Windows.Forms.Panel();
		this.ValBGN = new System.Windows.Forms.CheckBox();
		this.OpenRpt = new System.Windows.Forms.CheckBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.CheckBox2 = new System.Windows.Forms.CheckBox();
		this.rbChkSheet = new System.Windows.Forms.RadioButton();
		this.lblID = new System.Windows.Forms.Label();
		this.lblFolder = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Panel5 = new System.Windows.Forms.Panel();
		this.pbLogo = new System.Windows.Forms.PictureBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.txtTC_Url = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.txtUserID = new System.Windows.Forms.TextBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.comSite = new Rapid_Check.JCombo();
		this.txtNumber_ID = new Rapid_Check.JTxtBox();
		this.txtFolder = new Rapid_Check.JTxtBox();
		this.PanFolder.SuspendLayout();
		this.cmsTextbox.SuspendLayout();
		this.PanNumber.SuspendLayout();
		this.Panel4.SuspendLayout();
		this.Panel5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pbLogo).BeginInit();
		base.SuspendLayout();
		this.PanFolder.AllowDrop = true;
		this.PanFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PanFolder.Controls.Add(this.MFldr);
		this.PanFolder.Controls.Add(this.txtFolder);
		this.PanFolder.Location = new System.Drawing.Point(4, 118);
		this.PanFolder.Margin = new System.Windows.Forms.Padding(4);
		this.PanFolder.Name = "PanFolder";
		this.PanFolder.Size = new System.Drawing.Size(554, 46);
		this.PanFolder.TabIndex = 7;
		this.MFldr.AutoSize = true;
		this.MFldr.Location = new System.Drawing.Point(431, 12);
		this.MFldr.Name = "MFldr";
		this.MFldr.Size = new System.Drawing.Size(106, 21);
		this.MFldr.TabIndex = 1;
		this.MFldr.Text = "Modify Loc..";
		this.MFldr.UseVisualStyleBackColor = true;
		this.cmsTextbox.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.cmsTextbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.cmiCopy, this.cmiPaste, this.cmiSelectAll });
		this.cmsTextbox.Name = "ContextMenuStrip1";
		this.cmsTextbox.Size = new System.Drawing.Size(193, 76);
		this.cmiCopy.Name = "cmiCopy";
		this.cmiCopy.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;
		this.cmiCopy.Size = new System.Drawing.Size(192, 24);
		this.cmiCopy.Text = "&Copy";
		this.cmiPaste.Name = "cmiPaste";
		this.cmiPaste.ShortcutKeys = System.Windows.Forms.Keys.V | System.Windows.Forms.Keys.Control;
		this.cmiPaste.Size = new System.Drawing.Size(192, 24);
		this.cmiPaste.Text = "&Paste";
		this.cmiSelectAll.Name = "cmiSelectAll";
		this.cmiSelectAll.ShortcutKeys = System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control;
		this.cmiSelectAll.Size = new System.Drawing.Size(192, 24);
		this.cmiSelectAll.Text = "&Select All";
		this.PanNumber.AllowDrop = true;
		this.PanNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PanNumber.Controls.Add(this.txtNumber_ID);
		this.PanNumber.Location = new System.Drawing.Point(4, 59);
		this.PanNumber.Margin = new System.Windows.Forms.Padding(4);
		this.PanNumber.Name = "PanNumber";
		this.PanNumber.Size = new System.Drawing.Size(554, 46);
		this.PanNumber.TabIndex = 6;
		this.btnExecute.AllowDrop = true;
		this.btnExecute.BackColor = System.Drawing.Color.DimGray;
		this.btnExecute.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnExecute.ForeColor = System.Drawing.Color.White;
		this.btnExecute.Location = new System.Drawing.Point(16, 175);
		this.btnExecute.Margin = new System.Windows.Forms.Padding(4);
		this.btnExecute.Name = "btnExecute";
		this.btnExecute.Size = new System.Drawing.Size(258, 28);
		this.btnExecute.TabIndex = 9;
		this.btnExecute.Text = "&Execute";
		this.btnExecute.UseVisualStyleBackColor = false;
		this.pbProcess.Location = new System.Drawing.Point(7, 359);
		this.pbProcess.Margin = new System.Windows.Forms.Padding(4);
		this.pbProcess.Name = "pbProcess";
		this.pbProcess.Size = new System.Drawing.Size(570, 28);
		this.pbProcess.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
		this.pbProcess.TabIndex = 5;
		this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtStatus.Enabled = false;
		this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		this.txtStatus.ForeColor = System.Drawing.Color.Chocolate;
		this.txtStatus.Location = new System.Drawing.Point(7, 393);
		this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
		this.txtStatus.Multiline = true;
		this.txtStatus.Name = "txtStatus";
		this.txtStatus.ReadOnly = true;
		this.txtStatus.Size = new System.Drawing.Size(570, 33);
		this.txtStatus.TabIndex = 6;
		this.txtStatus.Text = "Ready...";
		this.btnClose.BackColor = System.Drawing.Color.DimGray;
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnClose.ForeColor = System.Drawing.Color.White;
		this.btnClose.Location = new System.Drawing.Point(298, 175);
		this.btnClose.Margin = new System.Windows.Forms.Padding(4);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(255, 28);
		this.btnClose.TabIndex = 2;
		this.btnClose.Text = "&Close";
		this.btnClose.UseVisualStyleBackColor = false;
		this.Label9.AutoSize = true;
		this.Label9.ForeColor = System.Drawing.Color.Navy;
		this.Label9.Location = new System.Drawing.Point(15, 127);
		this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label9.Name = "Label9";
		this.Label9.Size = new System.Drawing.Size(59, 17);
		this.Label9.TabIndex = 4;
		this.Label9.Text = "Process";
		this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel4.Controls.Add(this.ValBGN);
		this.Panel4.Controls.Add(this.OpenRpt);
		this.Panel4.Controls.Add(this.Label1);
		this.Panel4.Controls.Add(this.CheckBox2);
		this.Panel4.Controls.Add(this.comSite);
		this.Panel4.Controls.Add(this.rbChkSheet);
		this.Panel4.Controls.Add(this.btnExecute);
		this.Panel4.Controls.Add(this.lblID);
		this.Panel4.Controls.Add(this.lblFolder);
		this.Panel4.Controls.Add(this.PanNumber);
		this.Panel4.Controls.Add(this.PanFolder);
		this.Panel4.Controls.Add(this.btnClose);
		this.Panel4.Location = new System.Drawing.Point(7, 132);
		this.Panel4.Margin = new System.Windows.Forms.Padding(4);
		this.Panel4.Name = "Panel4";
		this.Panel4.Size = new System.Drawing.Size(570, 215);
		this.Panel4.TabIndex = 1;
		this.ValBGN.AutoSize = true;
		this.ValBGN.Location = new System.Drawing.Point(311, 2);
		this.ValBGN.Name = "ValBGN";
		this.ValBGN.Size = new System.Drawing.Size(155, 21);
		this.ValBGN.TabIndex = 14;
		this.ValBGN.Text = "Validate BGN Rules";
		this.ValBGN.UseVisualStyleBackColor = true;
		this.OpenRpt.AutoSize = true;
		this.OpenRpt.Location = new System.Drawing.Point(436, 71);
		this.OpenRpt.Name = "OpenRpt";
		this.OpenRpt.Size = new System.Drawing.Size(112, 21);
		this.OpenRpt.TabIndex = 2;
		this.OpenRpt.Text = "Open Report";
		this.OpenRpt.UseVisualStyleBackColor = true;
		this.Label1.AutoSize = true;
		this.Label1.Location = new System.Drawing.Point(3, 20);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(91, 17);
		this.Label1.TabIndex = 13;
		this.Label1.Text = "Select Plant :";
		this.CheckBox2.AutoSize = true;
		this.CheckBox2.Location = new System.Drawing.Point(311, 29);
		this.CheckBox2.Name = "CheckBox2";
		this.CheckBox2.Size = new System.Drawing.Size(130, 21);
		this.CheckBox2.TabIndex = 12;
		this.CheckBox2.Text = "HSM-Bangalore";
		this.CheckBox2.UseVisualStyleBackColor = true;
		this.rbChkSheet.AutoSize = true;
		this.rbChkSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.rbChkSheet.ForeColor = System.Drawing.Color.SaddleBrown;
		this.rbChkSheet.Location = new System.Drawing.Point(453, 29);
		this.rbChkSheet.Margin = new System.Windows.Forms.Padding(4);
		this.rbChkSheet.Name = "rbChkSheet";
		this.rbChkSheet.Size = new System.Drawing.Size(92, 21);
		this.rbChkSheet.TabIndex = 4;
		this.rbChkSheet.Text = "Check Sht";
		this.rbChkSheet.UseVisualStyleBackColor = true;
		this.lblID.AutoSize = true;
		this.lblID.ForeColor = System.Drawing.Color.Navy;
		this.lblID.Location = new System.Drawing.Point(12, 49);
		this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblID.Name = "lblID";
		this.lblID.Size = new System.Drawing.Size(90, 17);
		this.lblID.TabIndex = 10;
		this.lblID.Text = "ECN Number";
		this.lblFolder.AutoSize = true;
		this.lblFolder.ForeColor = System.Drawing.Color.Navy;
		this.lblFolder.Location = new System.Drawing.Point(12, 105);
		this.lblFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblFolder.Name = "lblFolder";
		this.lblFolder.Size = new System.Drawing.Size(95, 17);
		this.lblFolder.TabIndex = 11;
		this.lblFolder.Text = "Report Folder";
		this.Label7.AutoSize = true;
		this.Label7.ForeColor = System.Drawing.Color.Navy;
		this.Label7.Location = new System.Drawing.Point(15, 4);
		this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(120, 17);
		this.Label7.TabIndex = 3;
		this.Label7.Text = "TC Authentication";
		this.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel5.Controls.Add(this.pbLogo);
		this.Panel5.Controls.Add(this.Label3);
		this.Panel5.Controls.Add(this.txtTC_Url);
		this.Panel5.Controls.Add(this.Label4);
		this.Panel5.Controls.Add(this.txtPassword);
		this.Panel5.Controls.Add(this.txtUserID);
		this.Panel5.Controls.Add(this.Label6);
		this.Panel5.Cursor = System.Windows.Forms.Cursors.Default;
		this.Panel5.Location = new System.Drawing.Point(7, 11);
		this.Panel5.Margin = new System.Windows.Forms.Padding(4);
		this.Panel5.Name = "Panel5";
		this.Panel5.Size = new System.Drawing.Size(570, 113);
		this.Panel5.TabIndex = 0;
		this.pbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
		this.pbLogo.Image = Rapid_Check.My.Resources.Resources._4686888;
		this.pbLogo.Location = new System.Drawing.Point(510, 44);
		this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
		this.pbLogo.Name = "pbLogo";
		this.pbLogo.Size = new System.Drawing.Size(48, 48);
		this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.pbLogo.TabIndex = 7;
		this.pbLogo.TabStop = false;
		this.Label3.AutoSize = true;
		this.Label3.ForeColor = System.Drawing.Color.SaddleBrown;
		this.Label3.Location = new System.Drawing.Point(4, 14);
		this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(46, 17);
		this.Label3.TabIndex = 3;
		this.Label3.Text = "TC url";
		this.txtTC_Url.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTC_Url.Enabled = false;
		this.txtTC_Url.ForeColor = System.Drawing.Color.Navy;
		this.txtTC_Url.Location = new System.Drawing.Point(101, 14);
		this.txtTC_Url.Margin = new System.Windows.Forms.Padding(4);
		this.txtTC_Url.Name = "txtTC_Url";
		this.txtTC_Url.Size = new System.Drawing.Size(391, 22);
		this.txtTC_Url.TabIndex = 0;
		this.Label4.AutoSize = true;
		this.Label4.ForeColor = System.Drawing.Color.SaddleBrown;
		this.Label4.Location = new System.Drawing.Point(4, 47);
		this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(79, 17);
		this.Label4.TabIndex = 4;
		this.Label4.Text = "User Name";
		this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPassword.ForeColor = System.Drawing.Color.Navy;
		this.txtPassword.Location = new System.Drawing.Point(101, 79);
		this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = '*';
		this.txtPassword.Size = new System.Drawing.Size(390, 22);
		this.txtPassword.TabIndex = 2;
		this.txtUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtUserID.ForeColor = System.Drawing.Color.Navy;
		this.txtUserID.Location = new System.Drawing.Point(101, 47);
		this.txtUserID.Margin = new System.Windows.Forms.Padding(4);
		this.txtUserID.Name = "txtUserID";
		this.txtUserID.Size = new System.Drawing.Size(390, 22);
		this.txtUserID.TabIndex = 1;
		this.Label6.AutoSize = true;
		this.Label6.ForeColor = System.Drawing.Color.SaddleBrown;
		this.Label6.Location = new System.Drawing.Point(4, 79);
		this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(69, 17);
		this.Label6.TabIndex = 5;
		this.Label6.Text = "Password";
		this.comSite.BorderColor = System.Drawing.Color.Black;
		this.comSite.DropDownArrowColor = System.Drawing.SystemColors.ControlText;
		this.comSite.DropDownButtonColor = System.Drawing.SystemColors.Control;
		this.comSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comSite.ForeColor = System.Drawing.Color.Navy;
		this.comSite.FormattingEnabled = true;
		this.comSite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.comSite.Items.AddRange(new object[6] { "Aftermarket", "Bolingbrook", "Bridgeton", "Chino", "Monterrey", "Suwanee" });
		this.comSite.Location = new System.Drawing.Point(101, 17);
		this.comSite.Margin = new System.Windows.Forms.Padding(4);
		this.comSite.Name = "comSite";
		this.comSite.Size = new System.Drawing.Size(197, 24);
		this.comSite.Sorted = true;
		this.comSite.TabIndex = 5;
		this.txtNumber_ID.AllowDrop = true;
		this.txtNumber_ID.BackColor = System.Drawing.Color.White;
		this.txtNumber_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtNumber_ID.ContextMenuStrip = this.cmsTextbox;
		this.txtNumber_ID.ForeColor = System.Drawing.Color.Navy;
		this.txtNumber_ID.Location = new System.Drawing.Point(11, 11);
		this.txtNumber_ID.Margin = new System.Windows.Forms.Padding(4);
		this.txtNumber_ID.Name = "txtNumber_ID";
		this.txtNumber_ID.Size = new System.Drawing.Size(413, 22);
		this.txtNumber_ID.TabIndex = 0;
		this.txtFolder.AllowDrop = true;
		this.txtFolder.BackColor = System.Drawing.Color.White;
		this.txtFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtFolder.ContextMenuStrip = this.cmsTextbox;
		this.txtFolder.ForeColor = System.Drawing.Color.Navy;
		this.txtFolder.Location = new System.Drawing.Point(11, 11);
		this.txtFolder.Margin = new System.Windows.Forms.Padding(4);
		this.txtFolder.Name = "txtFolder";
		this.txtFolder.Size = new System.Drawing.Size(413, 22);
		this.txtFolder.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.ButtonFace;
		base.ClientSize = new System.Drawing.Size(582, 434);
		base.Controls.Add(this.Label9);
		base.Controls.Add(this.Panel4);
		base.Controls.Add(this.Label7);
		base.Controls.Add(this.Panel5);
		base.Controls.Add(this.pbProcess);
		base.Controls.Add(this.txtStatus);
		this.Cursor = System.Windows.Forms.Cursors.Default;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.MaximizeBox = false;
		base.Name = "frmMain";
		this.Text = "frmMain";
		this.PanFolder.ResumeLayout(false);
		this.PanFolder.PerformLayout();
		this.cmsTextbox.ResumeLayout(false);
		this.PanNumber.ResumeLayout(false);
		this.PanNumber.PerformLayout();
		this.Panel4.ResumeLayout(false);
		this.Panel4.PerformLayout();
		this.Panel5.ResumeLayout(false);
		this.Panel5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pbLogo).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void setComponentVisible(bool bVis = true)
	{
		try
		{
			btnClose.Enabled = bVis;
			btnExecute.Enabled = bVis;
			pbProcess.MarqueeAnimationSpeed = 0;
			Functions.SetProgressBar(pbProcess);
			Functions.SetStatus(txtStatus);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private bool validateInputs()
	{
		bool result = false;
		string text = string.Empty;
		try
		{
			if (Operators.CompareString(txtTC_Url.Text.Trim(), "", TextCompare: false) == 0)
			{
				text = "Please enter the TC Url....\r\n";
			}
			if (Operators.CompareString(txtUserID.Text.Trim(), "", TextCompare: false) == 0)
			{
				text += "Please enter the TC User Name....\r\n";
			}
			if (!rbChkSheet.Checked && Operators.CompareString(txtFolder.Text.Trim(), "", TextCompare: false) == 0)
			{
				text += "Please select Folder....\r\n";
			}
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				MessageBox.Show(text, Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (!rbChkSheet.Checked)
			{
				PropertySets objSEptyset = null;
				if (SolidEdgeFunctions.ConnectSE(ref objSEptyset))
				{
					SolidEdgeFunctions.CloseSE(ref objSEptyset);
				}
				else
				{
					text = "Unable to open the SolidEdge";
					MessageBox.Show(text, Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			result = Operators.CompareString(text, "", TextCompare: false) == 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void pbLogo_Click(object sender, EventArgs e)
	{
		try
		{
			Cursor = Cursors.WaitCursor;
			if (TCFunctions.TC_login(txtTC_Url.Text, txtUserID.Text, txtPassword.Text) != null)
			{
				MessageBox.Show("Test connection succeeded.", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		Cursor = Cursors.Default;
	}

	private void rbItemIDList_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			txtNumber_ID.Text = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void rbChkSheet_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			txtFolder.Text = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void PasteFolder_or_File_Path(object sender, EventArgs e)
	{
		string empty = string.Empty;
		try
		{
			empty = Clipboard.GetText(TextDataFormat.Text);
			if (Operators.CompareString(empty, "", TextCompare: false) == 0)
			{
				return;
			}
			Control sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl;
			if (sourceControl == null)
			{
				sourceControl = base.ActiveControl;
			}
			if (sourceControl == txtFolder)
			{
				if (Directory.Exists(empty))
				{
					txtFolder.Text = empty;
					btnExecute.Enabled = true;
				}
				else
				{
					MessageBox.Show("Invalid Folder....", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				txtNumber_ID.Text = empty;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void cmsTextbox_Opening(object sender, CancelEventArgs e)
	{
		try
		{
			cmiSelectAll.Enabled = Operators.CompareString((sender as ContextMenuStrip).SourceControl.Text, "", TextCompare: false) != 0;
			cmiCopy.Enabled = Operators.CompareString(((sender as ContextMenuStrip).SourceControl as JTxtBox).SelectedText, "", TextCompare: false) != 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void cmiSelectAll_Click(object sender, EventArgs e)
	{
		try
		{
			Control sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl;
			if (sourceControl == null)
			{
				(base.ActiveControl as JTxtBox).SelectAll();
			}
			else if (sourceControl == txtFolder)
			{
				txtFolder.SelectAll();
			}
			else
			{
				txtNumber_ID.SelectAll();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void cmiCopy_Click(object sender, EventArgs e)
	{
		try
		{
			Control sourceControl = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl;
			sourceControl = ((sourceControl == null) ? base.ActiveControl : ((sourceControl != txtFolder) ? txtNumber_ID : txtFolder));
			Clipboard.SetText((sourceControl as JTxtBox).SelectedText);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void frmMain_Load(object sender, EventArgs e)
	{
		try
		{
			ToolTip toolTip = new ToolTip();
			Text = "CheckSheet - Ver : " + Declarations.gToolVersion;
			Functions.AddFolderCtr(PanFolder, txtFolder);
			txtTC_Url.Text = MySettingsProperty.Settings.TC_Url;
			txtUserID.Text = MySettingsProperty.Settings.TC_UserName;
			txtPassword.Text = MySettingsProperty.Settings.TC_Password;
			txtFolder.Enabled = false;
			setComponentVisible();
			rbChkSheet.Checked = true;
			OpenRpt.Checked = true;
			Functions.RemoveFolderCtr(PanNumber, txtNumber_ID, IsFile: true);
			toolTip.AutoPopDelay = 5000;
			toolTip.InitialDelay = 500;
			toolTip.ReshowDelay = 500;
			toolTip.ShowAlways = true;
			toolTip.SetToolTip(rbChkSheet, "TC attribute check-ECN Items");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void GetFolderPath(object sender, EventArgs e)
	{
		try
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				txtFolder.Text = folderBrowserDialog.SelectedPath;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void btnFile_Click(object sender, EventArgs e)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;
			openFileDialog.Filter = "Item ID list |" + MySettingsProperty.Settings.InputFileType.Replace(".", "*.");
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				txtNumber_ID.Text = openFileDialog.FileName;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void btnExecute_Click(object sender, EventArgs e)
	{
		try
		{
			Cursor = Cursors.WaitCursor;
			Functions.SetStatus(txtStatus, "Validating Inputs...");
			if (validateInputs())
			{
				InputInfo objInput = new InputInfo();
				Functions.SetProgressBar(pbProcess);
				pbProcess.Style = ProgressBarStyle.Marquee;
				pbProcess.MarqueeAnimationSpeed = 50;
				Application.DoEvents();
				setComponentVisible(bVis: false);
				objInput.InputItem = txtNumber_ID.Text;
				objInput.FolderPath = txtFolder.Text;
				DataCompare.ECN_name = txtNumber_ID.Text;
				if (rbChkSheet.Checked)
				{
					objInput.InputType = Declarations.Input_type.ECN_CheckSheet;
					objInput.Site = comSite.GetItemText(RuntimeHelpers.GetObjectValue(comSite.SelectedItem));
				}
				objInput.Progress_bar = pbProcess;
				objInput.ProgressStatus = txtStatus;
				bool flag = false;
				if (rbChkSheet.Checked)
				{
					flag = true;
				}
				else
				{
					Functions.SetStatus(txtStatus, "Connecting to SolidEdge...");
					InputInfo inputInfo;
					PropertySets objSEptyset = (inputInfo = objInput).SEPropertySets;
					bool num = SolidEdgeFunctions.ConnectSE(ref objSEptyset);
					inputInfo.SEPropertySets = objSEptyset;
					flag = num;
				}
				if (flag)
				{
					Functions.SetStatus(txtStatus, "Connecting to TC...");
					objInput.TCCon = null;
					objInput.TCCon = TCFunctions.TC_login(txtTC_Url.Text, txtUserID.Text, txtPassword.Text);
					if (objInput.TCCon != null)
					{
						if (rbChkSheet.Checked)
						{
							if (MFldr.Checked)
							{
								Functions.MFldrPath = "Changed";
							}
							Functions.FldrPath = txtFolder.Text;
							if (OpenRpt.Checked)
							{
								Functions.RptSts = "Open";
							}
							else if (!OpenRpt.Checked)
							{
								Functions.RptSts = "";
							}
							CheckSheetFunctios.Generate_CheckSheet(ref objInput);
						}
						else
						{
							DataCompare.CompareIteams(ref objInput);
						}
						TCFunctions.TC_Logout(objInput.TCCon);
					}
				}
				else
				{
					MessageBox.Show("Unable to open/Connect the SolidEdge Application", Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			Debug.Print("End : " + DateTime.Now.ToString());
			setComponentVisible();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, Declarations.gToolName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			GC.Collect();
			Cursor = Cursors.Default;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void comSite_SelectedIndexChanged(object sender, EventArgs e)
	{
		Loc_Update();
		if (Operators.CompareString(txtFolder.Text, "", TextCompare: false) == 0)
		{
			btnExecute.Enabled = false;
		}
		else
		{
			btnExecute.Enabled = true;
		}
	}

	private void Loc_Update()
	{
		if (Operators.CompareString(comSite.Text, "Aftermarket", TextCompare: false) == 0)
		{
			MFldr.Checked = true;
			txtFolder.Text = "\\\\internal.hussmann.com\\sites\\Apps\\CAX\\CaxData\\projects\\se\\misc_ecos\\_TC_ECNs";
			Declarations.SiteLoc = "Aftermarket";
		}
		else if (Operators.CompareString(comSite.Text, "Bolingbrook", TextCompare: false) == 0)
		{
			MFldr.Checked = false;
			txtFolder.Text = "\\\\Mryv-engfs02\\Caxdata\\projects\\se\\misc_ecos\\_TC_ECNs";
			Declarations.SiteLoc = "Bolingbrook";
		}
		else if (Operators.CompareString(comSite.Text, "Bridgeton", TextCompare: false) == 0)
		{
			MFldr.Checked = false;
			txtFolder.Text = "\\\\STLV-ENGFS01\\Caxdata\\projects\\se\\misc_ecos\\_TC_ECNs";
			Declarations.SiteLoc = "Bridgeton";
		}
		else if (Operators.CompareString(comSite.Text, "Monterrey", TextCompare: false) == 0)
		{
			MFldr.Checked = false;
			txtFolder.Text = "\\\\Mryv-engfs02\\Caxdata\\projects\\se\\misc_ecos\\_TC_ECNs";
			Declarations.SiteLoc = "Monterrey";
		}
		else if (Operators.CompareString(comSite.Text, "Chino", TextCompare: false) == 0)
		{
			MFldr.Checked = false;
			txtFolder.Text = "\\\\internal.hussmann.com\\sites\\Apps\\CAX\\CaxData\\projects\\se\\misc_ecos\\_TC_ECNs";
			Declarations.SiteLoc = "Chino";
		}
		else if (Operators.CompareString(comSite.Text, "Suwanee", TextCompare: false) == 0)
		{
			MFldr.Checked = false;
			txtFolder.Text = "\\\\SWNV-ENGFS01\\Caxdata\\projects\\se\\misc_ecos\\_TC_ECNs";
			Declarations.SiteLoc = "Suwanee";
		}
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (MFldr.Checked)
		{
			txtFolder.Enabled = true;
		}
		else
		{
			txtFolder.Enabled = false;
		}
	}

	private void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		MFldr.Checked = false;
		if (CheckBox2.Checked)
		{
			txtFolder.Text = "\\\\internal.hussmann.com\\Sites\\Apps\\CaxPublic\\1_ECNs";
		}
		else
		{
			Loc_Update();
		}
	}

	private void OpenRpt_CheckedChanged(object sender, EventArgs e)
	{
		if (OpenRpt.Checked)
		{
			Functions.RptSts = "Open";
		}
		else if (!OpenRpt.Checked)
		{
			Functions.RptSts = "";
		}
	}
}
