using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Drawing.Printing;

namespace Rftim3WinFormsUCL.RftPrintDialog
{
    public partial class RftPrintDialogUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftPrintDialogUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private readonly PrintDocument docToPrint = new();

        private void Button1_Click(object? sender, EventArgs e)
        {
            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = docToPrint;

            DialogResult result = printDialog1.ShowDialog();

            if (result == DialogResult.OK) docToPrint.Print();
        }

        private void Document_PrintPage(object? sender, PrintPageEventArgs e)
        {
            string text = "In document_PrintPage method.";
            Font printFont = new("Arial", 35, FontStyle.Regular);

            e.Graphics!.DrawString(text, printFont, Brushes.Black, 10, 10);
        }
    }
}
