namespace Rftim3WinFormsCL
{
    public interface IRftLabelCL
    {
        public Label? RftLabel { get; set; }
        void RftLabelProperties();
        Label? CapsLockStatus { get; set; }
        Label? NumLockStatus { get; set; }
        Label? InsertStatus { get; set; }
    }
}
