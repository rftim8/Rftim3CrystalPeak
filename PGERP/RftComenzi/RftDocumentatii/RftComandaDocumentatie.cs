using PGERPBiblioteca.RftLinkuri;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftUtilitare
{
    class RftComandaDocumentatie : RftComandaBaza
    {
        public RftComandaDocumentatie()
        {

        }
        public override void Execute(object? parameter)
        {
            Process.Start(new ProcessStartInfo(RftLinkuriDocumentatie.RftLinkDocumentatiePrincipala) { UseShellExecute = true });
        }
    }
}
