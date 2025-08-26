using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftNumericUpDown
{
    public partial class RftNumericUpDownUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftNumericUpDownUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }
    }
}
