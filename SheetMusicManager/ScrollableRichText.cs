using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SheetMusicManager
{
    public class ScrollableRichText : RichTextBox
    {
        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEWHEEL = 0x020A;

            if (m.Msg == WM_MOUSEWHEEL && Parent != null)
            {
                SendMessage(Parent.Handle, m.Msg, m.WParam, m.LParam);
                return;
            }
            base.WndProc(ref m);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")] 
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
    }
}
