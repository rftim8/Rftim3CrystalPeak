using PGERP.RftVederiModele;
using System.Windows.Forms;

namespace PGERP.RftComenzi.RftLocatiiDocumente
{
    internal class RftComandaSelectareLocatie : RftComandaBaza
    {
        private readonly RftVedereModelSetariLocatii rftVedereModelSetariLocatii;

        public RftComandaSelectareLocatie(RftVedereModelSetariLocatii rftVedereModelSetariLocatii)
        {
            this.rftVedereModelSetariLocatii = rftVedereModelSetariLocatii;
        }

        public override void Execute(object? parameter)
        {
            FolderBrowserDialog folderBrowserDialog = new();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                rftVedereModelSetariLocatii.RftLocatie = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
