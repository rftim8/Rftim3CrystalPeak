namespace Rftim3WinFormsCL
{
    public interface IRftFormCL
    {
        public Form? RftForm { get; set; }
        void RftFormProperties();
        void RftMinimize();
        void RftNormal();
        void RftMaximize();
        void RftFullscreen();
        void RftCenterScreen();
        void RftExit();
    }
}
