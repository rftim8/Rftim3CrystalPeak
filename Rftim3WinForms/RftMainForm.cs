using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using Rftim3WinFormsUCL.RftMenuStrip;
using Rftim3WinFormsUCL.RftTableLayoutPanel;

namespace RftWinForms
{
    public partial class RftMainForm : Form
    {
        private readonly IRftFormCL? rftFormCL;
        private ContextMenuStrip? notifyIconCM;
        private ToolStripMenuItem? notifyIconMI;

        public RftMainForm(IHost host)
        {
            InitializeComponent();

            rftFormCL = host!.Services.GetRequiredService<IRftFormCL>();
            rftFormCL.RftForm = this;
            rftFormCL.RftFormProperties();

            RftMenuStripUC_0 rftMenuStripUC_0 = host.Services.GetRequiredService<RftMenuStripUC_0>();
            rftFormCL.RftForm.Controls.Add(rftMenuStripUC_0);

            RftTableLayoutPanelUC_0 rftTableLayoutPanelUC_0 = host.Services.GetRequiredService<RftTableLayoutPanelUC_0>();
            rftFormCL.RftForm.Controls.Add(rftTableLayoutPanelUC_0);

            NotifyIconSetup();
        }

        #region Notify Icon
        private void NotifyIconSetup()
        {
            notifyIconCM = new ContextMenuStrip();
            notifyIconMI = new ToolStripMenuItem();
            notifyIconCM.Items.AddRange([notifyIconMI]);
            notifyIconMI.Text = "Exit";
            notifyIconMI.Click += new EventHandler(MenuItem1_Click);
            notifyIcon1.ContextMenuStrip = notifyIconCM;

            #region BalloonTip Setup
            notifyIcon1.BalloonTipTitle = "RftTester Startup";
            notifyIcon1.BalloonTipText = "Application initialized successfully!";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            #endregion

            notifyIcon1.ShowBalloonTip(30000);
        }

        private void NotifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) WindowState = FormWindowState.Normal;

            Activate();
        }

        private void MenuItem1_Click(object? Sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
