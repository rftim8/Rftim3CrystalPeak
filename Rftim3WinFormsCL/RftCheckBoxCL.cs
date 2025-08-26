using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftCheckBoxCL : CheckBox, IRftCheckBoxCL
    {
        private CheckBox? rftCheckBox;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckBox? RftCheckBox
        {
            get { return rftCheckBox; }
            set { rftCheckBox = value; }
        }

    }
}
