using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace FileThief
{
	/// <summary>
	/// RichTextBoxEx is derived from RichTextBox and supports XP Visual Styles.
	/// </summary>
	public class RichTextBoxEx : RichTextBox
	{
		/// <summary>
		/// Contains the size of the visual style borders
		/// </summary>
		NativeMethods.RECT borderRect;

		
		public RichTextBoxEx()
		{
		}

/// <summary>
/// Filter some message we need to draw the border.
/// </summary>
protected override void WndProc(ref Message m)
{
	switch(m.Msg)
	{
		case NativeMethods.WM_NCPAINT: // the border painting is done here.
			WmNcpaint(ref m);
			break;
		case NativeMethods.WM_NCCALCSIZE: // the size of the client area is calcuated here.
			WmNccalcsize(ref m);
			break;
		case NativeMethods.WM_THEMECHANGED: // Updates styles when the theme is changing.
			UpdateStyles();
			break;
		default:
			base.WndProc (ref m);
			break;
	}
}

		/// <summary>
		/// Calculates the size of the window frame and client area of the RichTextBox
		/// </summary>
		void WmNccalcsize(ref Message m)
		{
			// let the richtextbox control draw the scrollbar if necessary.
			base.WndProc(ref m);

			// we visual styles are not enabled and BorderStyle is not Fixed3D then we have nothing more to do.
			if(!this.RenderWithVisualStyles())
				return;
			
			// contains detailed information about WM_NCCALCSIZE message
			NativeMethods.NCCALCSIZE_PARAMS par = new NativeMethods.NCCALCSIZE_PARAMS();
			
			// contains the window frame RECT
			NativeMethods.RECT windowRect;

			if(m.WParam == IntPtr.Zero) // LParam points to a RECT struct
			{
				windowRect = (NativeMethods.RECT)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.RECT));
			}
			else // LParam points to a NCCALCSIZE_PARAMS struct
			{
				par =  (NativeMethods.NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.NCCALCSIZE_PARAMS));
				windowRect = par.rgrc0;
			}

			// contains the client area of the control
			NativeMethods.RECT contentRect;

			// get the DC
			IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

			// open theme data
			IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "EDIT");

			// find out how much space the borders needs
			if(NativeMethods.GetThemeBackgroundContentRect(hTheme, hDC, NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL
				, ref windowRect
				, out contentRect) == NativeMethods.S_OK)
			{
				// shrink the client area the make more space for containing text.
				contentRect.Inflate(-1, -1);

				// remember the space of the borders
				this.borderRect = new NativeMethods.RECT(contentRect.Left-windowRect.Left
					, contentRect.Top-windowRect.Top
					, windowRect.Right-contentRect.Right
					, windowRect.Bottom-contentRect.Bottom); 

				// update LParam of the message with the new client area
				if(m.WParam == IntPtr.Zero)
				{
					Marshal.StructureToPtr(contentRect, m.LParam, false);
				}
				else
				{
					par.rgrc0 = contentRect;
					Marshal.StructureToPtr(par, m.LParam, false);
				}

				// force the control to redraw it´s client area
				m.Result = new IntPtr(NativeMethods.WVR_REDRAW);
			}

			// release theme data handle
			NativeMethods.CloseThemeData(hTheme);

			// release DC
			NativeMethods.ReleaseDC(this.Handle, hDC);
		}

		/// <summary>
		/// The border painting is done here.
		/// </summary>
		void WmNcpaint(ref Message m)
		{
			base.WndProc(ref m);

			if(!this.RenderWithVisualStyles())
			{
				return;
			}

			/////////////////////////////////////////////////////////////////////////////
			// Get the DC of the window frame and paint the border using uxTheme API´s
			/////////////////////////////////////////////////////////////////////////////

			// set the part id to TextBox
			int partId = NativeMethods.EP_EDITTEXT;

			// set the state id of the current TextBox
			int stateId;
			if(this.Enabled)
				if(this.ReadOnly)
					stateId = NativeMethods.ETS_READONLY;
				else
					stateId = NativeMethods.ETS_NORMAL;
			else
				stateId = NativeMethods.ETS_DISABLED;

			// define the windows frame rectangle of the TextBox
			NativeMethods.RECT windowRect;
			NativeMethods.GetWindowRect(this.Handle, out windowRect);
			windowRect.Right -= windowRect.Left; windowRect.Bottom -= windowRect.Top;
			windowRect.Top = windowRect.Left = 0;

			// get the device context of the window frame
			IntPtr hDC = NativeMethods.GetWindowDC(this.Handle);

			// define a rectangle inside the borders and exclude it from the DC
			NativeMethods.RECT clientRect = windowRect;
			clientRect.Left += this.borderRect.Left;
			clientRect.Top += this.borderRect.Top;
			clientRect.Right -= this.borderRect.Right;
			clientRect.Bottom -= this.borderRect.Bottom;
			NativeMethods.ExcludeClipRect(hDC, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Bottom);

			// open theme data
			IntPtr hTheme = NativeMethods.OpenThemeData(this.Handle, "EDIT");
			
			// make sure the background is updated when transparent background is used.
			if(NativeMethods.IsThemeBackgroundPartiallyTransparent(hTheme
				, NativeMethods.EP_EDITTEXT, NativeMethods.ETS_NORMAL) != 0)
			{
				NativeMethods.DrawThemeParentBackground(this.Handle, hDC, ref windowRect);
			}

			// draw background
			NativeMethods.DrawThemeBackground(hTheme, hDC, partId, stateId, ref windowRect, IntPtr.Zero);

			// close theme data
			NativeMethods.CloseThemeData(hTheme);

			// release dc
			NativeMethods.ReleaseDC(this.Handle, hDC);

			// we have processed the message so set the result to zero
			m.Result = IntPtr.Zero;
		}
		
		/// <summary>
		/// Returns true, when visual styles are enabled in this application.
		/// </summary>
		bool VisualStylesEnabled()
		{
			// Check if RenderWithVisualStyles property is available in the Application class (New feature in NET 2.0)
			Type t = typeof(Application);
			System.Reflection.PropertyInfo pi = t.GetProperty("RenderWithVisualStyles");
			
			if(pi == null)
			{
				// NET 1.1
				OperatingSystem os = System.Environment.OSVersion;
				if(os.Platform == PlatformID.Win32NT && (((os.Version.Major == 5) && (os.Version.Minor >= 1)) || (os.Version.Major > 5)) )
				{
					NativeMethods.DLLVersionInfo version = new NativeMethods.DLLVersionInfo();
					version.cbSize = Marshal.SizeOf(typeof(NativeMethods.DLLVersionInfo));
					if(NativeMethods.DllGetVersion(ref version) == 0)
					{
						return (version.dwMajorVersion > 5) && NativeMethods.IsThemeActive() && NativeMethods.IsAppThemed();
					}
				}

				return false;
			}
			else
			{
				// NET 2.0
				bool result = (bool)pi.GetValue(null, null);
				return result;
			}
		}

		/// <summary>
		/// Return true, when this control should render with visual styles.
		/// </summary>
		/// <returns></returns>
		bool RenderWithVisualStyles()
		{
			return (this.BorderStyle == BorderStyle.Fixed3D && this.VisualStylesEnabled());
		}

		/// <summary>
		/// Update the control parameters.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams p = base.CreateParams;

				// remove the Fixed3D border style
				if(this.RenderWithVisualStyles() && (p.ExStyle & NativeMethods.WS_EX_CLIENTEDGE) == NativeMethods.WS_EX_CLIENTEDGE)
					p.ExStyle ^= NativeMethods.WS_EX_CLIENTEDGE;
				
				return p;
			}
		}

	}
}
