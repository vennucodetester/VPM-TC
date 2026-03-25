using System;
using System.Drawing;
using System.Windows.Forms;

namespace Rapid_Check;

public class JTxtBox : TextBox
{
	public JTxtBox()
	{
		BackColor = Color.White;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		base.OnEnabledChanged(e);
		if (base.Enabled)
		{
			BackColor = Color.White;
		}
		else
		{
			BackColor = SystemColors.Control;
		}
	}
}
