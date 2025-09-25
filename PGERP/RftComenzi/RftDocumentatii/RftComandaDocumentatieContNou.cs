﻿using PGERPBiblioteca.RftLinkuri;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftDocumentatii
{
    class RftComandaDocumentatieContNou : RftComandaBaza
    {
        public RftComandaDocumentatieContNou()
        {

        }

        public override void Execute(object? parameter)
        {
            Process.Start(new ProcessStartInfo(RftLinkuriDocumentatie.RftLinkDocumentatieCont) { UseShellExecute = true });
        }
    }
}
