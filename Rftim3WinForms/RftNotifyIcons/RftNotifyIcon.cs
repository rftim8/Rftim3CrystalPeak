using RftWinForms;

namespace Rftim3WinForms.RftNotifyIcons
{
    internal class RftNotifyIcon
    {
        private readonly Form form;
        private static ToolStripMenuItem? tsmiMainFormNotifyIcon;
        private static ContextMenuStrip? cmsMainFormNotifyIcon;

        public RftNotifyIcon(Form form)
        {
            this.form = form;

            ToolStripMenuItemSetup();
            ContextMenuStripSetup();
            NotifyIconSetup();
        }

        private void ToolStripMenuItemSetup()
        {
            tsmiMainFormNotifyIcon = new ToolStripMenuItem
            {
                Text = "Exit"
            };
            tsmiMainFormNotifyIcon.Click += new EventHandler(TsmiMainFormNotifyIcon_Click);
        }

        private static void ContextMenuStripSetup()
        {
            cmsMainFormNotifyIcon = new ContextMenuStrip();
            cmsMainFormNotifyIcon.Items.AddRange(
                [
                    tsmiMainFormNotifyIcon!
                ]);
        }

        private void NotifyIconSetup()
        {
            Bitmap bitmap = new(RftResources.RftIconNotifyIcon_16x);
            nint iconFromBitmap = bitmap.GetHicon();

            NotifyIcon mainFormNotifyIcon = new()
            {
                ContextMenuStrip = cmsMainFormNotifyIcon,
                BalloonTipTitle = "RftWinForms Startup",
                BalloonTipText = "Application initialized successfully!",
                BalloonTipIcon = ToolTipIcon.Info,
                Icon = Icon.FromHandle(iconFromBitmap),
                Visible = true
            };
            mainFormNotifyIcon.DoubleClick += new EventHandler(MainFormNotifyIcon_DoubleClick);
            mainFormNotifyIcon.ShowBalloonTip(30000);
        }

        private void MainFormNotifyIcon_DoubleClick(object? sender, EventArgs e)
        {
            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;

            form.Activate();
        }

        private void TsmiMainFormNotifyIcon_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
