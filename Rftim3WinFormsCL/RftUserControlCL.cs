using System.ComponentModel;

namespace Rftim3WinFormsCL
{
    public class RftUserControlCL : UserControl, IRftUserControlCL
    {
        private static UserControl? rftUserControl;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UserControl? RftUserControl
        {
            get { return rftUserControl; }
            set { rftUserControl = value; }
        }

        public void RftTopMenuBarProperties() => TopMenuBarProperties();

        private static void TopMenuBarProperties()
        {
            if (rftUserControl != null)
            {
                rftUserControl.Dock = DockStyle.Top;
            }
        }

        public void RftContentProperties() => ContentProperties();

        private static void ContentProperties()
        {
            if (rftUserControl != null)
            {
                rftUserControl.Dock = DockStyle.Fill;
            }
        }

        public void RftBottomBarProperties() => BottomBarProperties();

        private static void BottomBarProperties()
        {
            if (rftUserControl != null)
            {
                rftUserControl.Dock = DockStyle.Bottom;
                rftUserControl.Height = 30;
            }
        }
    }
}
