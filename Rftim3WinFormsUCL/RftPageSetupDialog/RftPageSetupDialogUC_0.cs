using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Drawing.Printing;

namespace Rftim3WinFormsUCL.RftPageSetupDialog
{
    public partial class RftPageSetupDialogUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftPageSetupDialogUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = new PageSettings();
            pageSetupDialog1.PrinterSettings = new PrinterSettings();
            pageSetupDialog1.ShowNetwork = false;

            DialogResult result = pageSetupDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                object[] results = [
                pageSetupDialog1.PageSettings.Margins,
                pageSetupDialog1.PageSettings.PaperSize,
                pageSetupDialog1.PageSettings.Landscape,
                pageSetupDialog1.PrinterSettings.PrinterName,
                pageSetupDialog1.PrinterSettings.PrintRange];
                listBox1.Items.AddRange(results);
            }
        }
    }
}
