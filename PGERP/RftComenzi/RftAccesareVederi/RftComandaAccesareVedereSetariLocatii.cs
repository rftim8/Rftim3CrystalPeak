using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereSetariLocatii : RftComandaBaza
    {
        private readonly RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala;
        private readonly RftVedereModelSetariLocatii rftVedereModelSetariLocatii;

        public RftComandaAccesareVedereSetariLocatii(RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala,
            RftVedereModelSetariLocatii rftVedereModelSetariLocatii)
        {
            this.rftVedereModelFereastraPrincipala = rftVedereModelFereastraPrincipala;
            this.rftVedereModelSetariLocatii = rftVedereModelSetariLocatii;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelSetariLocatii.RftMesajStareModificareLocatie = "";
            rftVedereModelFereastraPrincipala.RftVedereModelContinutCurent = rftVedereModelFereastraPrincipala.RftVedereModelSetariLocatii;
        }
    }
}
