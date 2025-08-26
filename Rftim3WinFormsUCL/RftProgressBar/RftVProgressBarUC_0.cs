using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftProgressBarVertical
{
    public partial class RftVProgressBarUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftVProgressBarUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            rftccProgressBarVertical1.Start();
        }
    }
}
