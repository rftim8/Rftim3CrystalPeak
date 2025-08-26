using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftFormCL : Form, IRftFormCL
    {
        private static Form? rftForm;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form? RftForm
        {
            get { return rftForm; }
            set { rftForm = value; }
        }

        public void RftFormProperties()
        {
            if (rftForm != null)
            {
                RftCenterScreen();
            }
        }

        private static readonly Size defaultFormSize = new(1920, 1080);

        private static Size rftSize = defaultFormSize;

        public static Size RftSize
        {
            get { return rftSize; }
            set { rftSize = value; }
        }

        public void RftMinimize() => Minimize_0();

        private static void Minimize_0()
        {
            if (rftForm != null)
            {
                rftForm.WindowState = FormWindowState.Minimized;
            }
        }

        public void RftNormal() => Normal_0();

        private static void Normal_0()
        {
            if (rftForm != null)
            {
                if (rftForm.WindowState != FormWindowState.Normal)
                {
                    rftForm.WindowState = FormWindowState.Normal;
                    RftSize = defaultFormSize;
                    CenterScreen_0();
                }
            }
        }

        public void RftMaximize() => Maximize_0();

        private static void Maximize_0()
        {
            if (rftForm != null)
            {
                if (rftForm.WindowState != FormWindowState.Maximized)
                {
                    rftForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    Normal_0();
                }
            }
        }

        public void RftFullscreen() => Fullscreen_0();

        private static void Fullscreen_0()
        {
            if (rftForm != null)
            {
                if (rftForm.WindowState != FormWindowState.Maximized)
                {
                    rftForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    Normal_0();
                }
            }
        }

        public void RftCenterScreen() => CenterScreen_0();

        private static void CenterScreen_0()
        {
            if (rftForm != null)
            {
                rftForm.Location = new Point(
                    Math.Max(Screen.GetWorkingArea(rftForm).X, Screen.GetWorkingArea(rftForm).X + (Screen.GetWorkingArea(rftForm).Width - rftForm.Width) / 2),
                    Math.Max(Screen.GetWorkingArea(rftForm).Y, Screen.GetWorkingArea(rftForm).Y + (Screen.GetWorkingArea(rftForm).Height - rftForm.Height) / 2)
                );
            }
        }

        public void RftExit() => Exit_0();

        private static void Exit_0()
        {
            RftKeyboardCtrlQ();
        }

        #region Keyboard
        public static bool RftKeyboardCtrlQ() => KeyboardCtrlQ_0();

        private static bool KeyboardCtrlQ_0()
        {
            Application.Exit();
            return true;
        }

        public static bool RftKeyboardF11() => KeyboardF11_0();

        private static bool KeyboardF11_0()
        {
            if (rftForm != null)
            {
                if (rftForm.WindowState == FormWindowState.Normal)
                {
                    Maximize_0();
                    //button1.Image = Resources.RftIconMinimize_16x;
                    return true;
                }
                else
                {
                    Normal_0();
                    //button1.Image = Resources.RftIconWindowMaximize_16x;
                    return true;
                }
            }

            return false;
        }

        public static bool RftKeyboardESC() => KeyboardESC_0();

        private static bool KeyboardESC_0()
        {
            MessageBox.Show("");
            if (rftForm != null)
            {
                if (rftForm.WindowState == FormWindowState.Maximized)
                {
                    Normal_0();
                    return true;
                }
            }

            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return keyData switch
            {
                Keys.Escape => RftKeyboardESC(),
                Keys.F11 => RftKeyboardF11(),
                Keys.Control | Keys.Q => RftKeyboardCtrlQ(),
                _ => base.ProcessCmdKey(ref msg, keyData),
            };
        }

        protected override void WndProc(ref Message m)
        {
            #region Resize Borderless Window
            const int wmNcHitTest = 0x84;
            const int htLeft = 10;
            const int htRight = 11;
            const int htTop = 12;
            const int htTopLeft = 13;
            const int htTopRight = 14;
            const int htBottom = 15;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            const int edgeSize = 2;

            if (m.Msg == wmNcHitTest)
            {
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point pt = PointToClient(new Point(x, y));
                Size clientSize = ClientSize;
                //SE
                if (pt.X >= clientSize.Width - edgeSize && pt.Y >= clientSize.Height - edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = IsMirrored ? htBottomLeft : htBottomRight;
                    return;
                }
                //SW
                if (pt.X <= 16 && pt.Y >= clientSize.Height - edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = IsMirrored ? htBottomRight : htBottomLeft;
                    return;
                }
                //NE
                if (pt.X <= edgeSize && pt.Y <= edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = IsMirrored ? htTopRight : htTopLeft;
                    return;
                }
                //NW
                if (pt.X >= clientSize.Width - edgeSize && pt.Y <= edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = IsMirrored ? htTopLeft : htTopRight;
                    return;
                }
                //N
                if (pt.Y <= edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = htTop;
                    return;
                }
                //S
                if (pt.Y >= clientSize.Height - edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = htBottom;
                    return;
                }
                //W
                if (pt.X <= edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = htLeft;
                    return;
                }
                //E
                if (pt.X >= clientSize.Width - edgeSize && clientSize.Height >= edgeSize)
                {
                    m.Result = htRight;
                    return;
                }
            }
            base.WndProc(ref m);
            #endregion
        }
        #endregion
    }
}
