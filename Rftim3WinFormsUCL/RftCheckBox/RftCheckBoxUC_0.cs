using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftCheckBox
{
    public partial class RftCheckBoxUC_0 : UserControl
    {
        private readonly IRftCheckBoxCL rftCheckBoxCL;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftCheckBoxUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
            
            rftCheckBoxCL = host.Services.GetRequiredService<IRftCheckBoxCL>();
            rftCheckBoxCL.RftCheckBox = checkBox1;
        }
    }
}
