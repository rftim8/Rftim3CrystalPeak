using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftRichTextBox
{
    public partial class RftRichTextBoxUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftRichTextBoxUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }
    }
}
