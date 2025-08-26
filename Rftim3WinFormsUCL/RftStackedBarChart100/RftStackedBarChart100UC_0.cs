using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftStackedBarChart100
{
    public partial class RftStackedBarChart100UC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftStackedBarChart100UC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }
    }
}
