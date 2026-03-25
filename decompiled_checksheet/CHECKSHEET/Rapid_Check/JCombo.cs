using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Rapid_Check;

public class JCombo : ComboBox
{
	private Color _BorderColor;

	private Color _DropDownButtonColor;

	private Color _DropDownArrowColor;

	public Color BorderColor
	{
		get
		{
			return _BorderColor;
		}
		set
		{
			_BorderColor = value;
		}
	}

	public Color DropDownButtonColor
	{
		get
		{
			return _DropDownButtonColor;
		}
		set
		{
			_DropDownButtonColor = value;
		}
	}

	public Color DropDownArrowColor
	{
		get
		{
			return _DropDownArrowColor;
		}
		set
		{
			_DropDownArrowColor = value;
		}
	}

	public JCombo()
	{
		_BorderColor = Color.LightGray;
		_DropDownButtonColor = SystemColors.Control;
		_DropDownArrowColor = SystemColors.ControlText;
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
		int msg = m.Msg;
		checked
		{
			if (msg == 15)
			{
				Graphics graphics = CreateGraphics();
				Pen pen = new Pen(_BorderColor, 2f);
				Pen pen2 = new Pen(_BorderColor, 1f);
				Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
				Brush brush = new SolidBrush(BackColor);
				Brush brush2 = new SolidBrush(_DropDownButtonColor);
				Brush brush3 = new SolidBrush(_DropDownArrowColor);
				Brush brush4 = new SolidBrush(ForeColor);
				if (!base.Enabled)
				{
					brush = new SolidBrush(_DropDownButtonColor);
				}
				graphics.FillRectangle(brush, base.ClientRectangle);
				graphics.DrawRectangle(pen, rect);
				rect = new Rectangle(base.Width - 15, 3, 12, base.Height - 6);
				graphics.FillRectangle(brush2, rect);
				graphics.DrawLine(pen2, base.Width - 17, 0, base.Width - 17, base.Height);
				GraphicsPath graphicsPath = new GraphicsPath();
				PointF pt = new PointF(base.Width - 13, (float)((double)(base.Height - 5) / 2.0));
				PointF pointF = new PointF(base.Width - 6, (float)((double)(base.Height - 5) / 2.0));
				PointF pt2 = new PointF(base.Width - 9, (float)((double)(base.Height + 2) / 2.0));
				graphicsPath.AddLine(pt, pointF);
				graphicsPath.AddLine(pointF, pt2);
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				brush3 = ((!base.DroppedDown) ? new SolidBrush(SystemColors.ControlText) : new SolidBrush(SystemColors.HighlightText));
				graphics.FillPath(brush3, graphicsPath);
				graphics.DrawString(Text, Font, brush4, 1f, 3f);
			}
		}
	}
}
