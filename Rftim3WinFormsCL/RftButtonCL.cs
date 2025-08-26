using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftButtonCL : Button, IRftButtonCL
    {
        private Button? rftButton;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Button? RftButton
        {
            get { return rftButton; }
            set { rftButton = value; }
        }

        
    }
}
