using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftProgressBarHorizontal
{
    public partial class RftHProgressBarUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftHProgressBarUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            rftccProgressBarHorizontal1.Start();
        }

        private void RftProgressBarHorizontal1Resize(object sender, EventArgs e)
        {
            rftccProgressBarHorizontal1.BarWidth = rftccProgressBarHorizontal1.Width;
            rftccProgressBarHorizontal1.BarHeight = rftccProgressBarHorizontal1.Height;
            rftccProgressBarHorizontal1.NumberChunks = 10;
        }

    }
}
