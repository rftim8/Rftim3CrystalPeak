using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftTableLayoutPanel
{
    public partial class RftTableLayoutPanelUC_1 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftTableLayoutPanelUC_1(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }
    }
}
