namespace Rftim3WinFormsCL
{
    public interface IRftUserControlCL
    {
        public UserControl? RftUserControl { get; set; }
        void RftTopMenuBarProperties();
        void RftContentProperties();
        void RftBottomBarProperties();
    }
}
