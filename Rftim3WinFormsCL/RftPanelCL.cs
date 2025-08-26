using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftPanelCL : Panel, IRftPanelCL
    {
        private Panel? rftPanel;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Panel? RftPanel
        {
            get { return rftPanel; }
            set { rftPanel = value; }
        }

    }
}
