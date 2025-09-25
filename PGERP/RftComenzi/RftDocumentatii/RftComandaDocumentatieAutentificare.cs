using PGERPBiblioteca.RftLinkuri;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftDocumentatii
{
    class RftComandaDocumentatieAutentificare : RftComandaBaza
    {
        public override void Execute(object? parameter)
        {
            Process.Start(new ProcessStartInfo(RftLinkuriDocumentatie.RftLinkDocumentatieCont) { UseShellExecute = true });
        }
    }
}
