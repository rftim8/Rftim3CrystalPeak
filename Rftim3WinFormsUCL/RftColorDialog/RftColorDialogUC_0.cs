using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftColorDialog
{
    public partial class RftColorDialogUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftColorDialogUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new()
            {
                AllowFullOpen = true,
                CustomColors = [
                    6916092,
                    15195440,
                    16107657,
                    1836924,
                    3758726,
                    12566463,
                    7526079,
                    7405793,
                    6945974,
                    241502,
                    2296476,
                    5130294,
                    3102017,
                    7324121,
                    14993507,
                    11730944,
                ],
                ShowHelp = true,
                Color = BackColor
            };

            MyDialog.ShowDialog();
            BackColor = MyDialog.Color;

            PrintCustomColors(MyDialog.CustomColors);
        }

        private void PrintCustomColors(int[] clrs)
        {
            
            TextWriter writer = new StreamWriter(@"/RftCS/RftWFCS/RftWFCS/RftOut/colors.txt");
            foreach (int item in clrs)
            {
                listView1.Items.Add(item.ToString());
                writer.WriteLine(item);
            }

            writer.Close();
        }
    }
}
