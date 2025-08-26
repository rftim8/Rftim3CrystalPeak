using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftPropertyGrid
{
    public partial class RftPropertyGridUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftPropertyGridUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            InitializeCheckedListBox();
        }

        private void InitializeCheckedListBox()
        {
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.SelectionMode = SelectionMode.One;
            checkedListBox1.ThreeDCheckBoxes = true;

            //foreach (Control aControl in Controls)
            //{
            //    checkedListBox1.Items.Add(aControl, false);
            //}

            checkedListBox1.Items.Add(button1, false);
            checkedListBox1.Items.Add(textBox1, false);
            checkedListBox1.Items.Add(checkedListBox1, false);
            checkedListBox1.DisplayMember = "Name";
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            propertyGrid1.Visible = true;
            Control[] selectedControls = new Control[checkedListBox1.CheckedItems.Count];

            for (int counter = 0; counter < checkedListBox1.CheckedItems.Count; counter++)
            {
                selectedControls[counter] = (Control)checkedListBox1.CheckedItems[counter]!;
            }
            propertyGrid1.SelectedObjects = selectedControls;
        }
    }
}
