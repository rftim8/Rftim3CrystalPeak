using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftMenuStripCL : MenuStrip, IRftMenuStripCL
    {
        private static MenuStrip? rftMenuStrip;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MenuStrip? RftMenuStrip
        {
            get { return rftMenuStrip; }
            set { rftMenuStrip = value; }
        }
    }
}
