using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftTextBox
{
    public partial class RftTextBoxUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftTextBoxUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            //AutoComplete();
        }

        private void AutoComplete()
        {
            Thread t = new(() =>
            {
                AutoCompleteStringCollection source =
                [
                    "January",
                    "February",
                    "March",
                    "April",
                    "May",
                    "June",
                    "July",
                    "August",
                    "September",
                    "October",
                    "November",
                    "December"
                ];

                textBox1.AutoCompleteCustomSource = source;
                textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
    }
}
