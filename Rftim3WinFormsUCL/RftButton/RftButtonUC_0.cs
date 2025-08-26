using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Drawing.Drawing2D;

namespace Rftim3WinFormsUCL.RftButton
{
    public partial class RftButtonUC_0 : UserControl
    {
        private readonly IRftButtonCL rftButtonCL;
        private readonly IRftUserControlCL rftUserControlCL;

        public RftButtonUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            rftButtonCL = host.Services.GetRequiredService<IRftButtonCL>();
            rftButtonCL.RftButton = button1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UCButton");
        }

        private void Button1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath buttonPath = new();
            Rectangle newRectangle = button1.ClientRectangle;
            newRectangle.Inflate(-5, -5);
            buttonPath.AddEllipse(newRectangle);
            button1.Region = new Region(buttonPath);
        }
    }
}
