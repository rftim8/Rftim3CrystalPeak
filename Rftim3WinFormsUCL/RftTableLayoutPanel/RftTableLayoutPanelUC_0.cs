using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftTableLayoutPanel
{
    public partial class RftTableLayoutPanelUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;
        private readonly IRftLabelCL rftLabelCL;
        private readonly IRftTableLayoutPanelCL rftTableLayoutPanelCL;
        private readonly IRftFormCL rftFormCL;

        public RftTableLayoutPanelUC_0(IHost host)
        {
            InitializeComponent();
            Application.Idle += Application_Idle;

            rftFormCL = host.Services.GetRequiredService<IRftFormCL>();
            rftFormCL.RftForm!.FormClosing += new FormClosingEventHandler(RftForm_FormClosing);

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftBottomBarProperties();

            rftTableLayoutPanelCL = host.Services.GetRequiredService<IRftTableLayoutPanelCL>();
            rftTableLayoutPanelCL.RftTableLayoutPanel = tableLayoutPanel1;
            rftTableLayoutPanelCL.RftTableLayoutPanel.RowStyles.Clear();
            rftTableLayoutPanelCL.RftTableLayoutPanel.ColumnStyles.Clear();
            rftTableLayoutPanelCL.RftDefaultProperties();

            rftTableLayoutPanelCL.RftTableLayoutPanel.Controls.Add(label1, 1, 0);
            rftTableLayoutPanelCL.RftTableLayoutPanel.Controls.Add(label2, 2, 0);
            rftTableLayoutPanelCL.RftTableLayoutPanel.Controls.Add(label3, 3, 0);

            rftLabelCL = host.Services.GetRequiredService<IRftLabelCL>();
            rftLabelCL.RftLabel = label1;
            rftLabelCL.RftLabelProperties();

            rftLabelCL.RftLabel = label2;
            rftLabelCL.RftLabelProperties();

            rftLabelCL.RftLabel = label3;
            rftLabelCL.RftLabelProperties();
        }

        private void Application_Idle(object? sender, EventArgs e)
        {
            label1.Text = IsKeyLocked(Keys.CapsLock) ? "CAPS: ON" : "CAPS: OFF";
            label2.Text = IsKeyLocked(Keys.NumLock) ? "NUM: ON" : "NUM: OFF";
            label3.Text = IsKeyLocked(Keys.Insert) ? "INS: ON" : "INS: OFF";
        }

        private void RftForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Idle -= Application_Idle;
        }
    }
}
