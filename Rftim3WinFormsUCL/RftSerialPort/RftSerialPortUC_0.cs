using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftSerialPort
{
    public partial class RftSerialPortUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftSerialPortUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }
    }
}
