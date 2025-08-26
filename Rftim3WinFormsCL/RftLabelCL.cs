using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftLabelCL : Label, IRftLabelCL
    {
        private static Label? rftLabel;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Label? RftLabel
        {
            get { return rftLabel; }
            set { rftLabel = value; }
        }

        public void RftLabelProperties() => LabelProperties();

        private static void LabelProperties()
        {
            if (rftLabel != null)
            {
                rftLabel.Width = 100;
                rftLabel.Height = 10;
                rftLabel.Font = new Font(FontFamily.GenericSansSerif, 10f);
            }
        }

        private static Label? capsLockStatus = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Label? CapsLockStatus
        {
            get { return capsLockStatus; }
            set { capsLockStatus = value; }
        }

        private static Label? numLockStatus = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Label? NumLockStatus
        {
            get { return numLockStatus; }
            set { numLockStatus = value; }
        }

        private static Label? insertStatus = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Label? InsertStatus
        {
            get { return insertStatus; }
            set { insertStatus = value; }
        }

    }
}
