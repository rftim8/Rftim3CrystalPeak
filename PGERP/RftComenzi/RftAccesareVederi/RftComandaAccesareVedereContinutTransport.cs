using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERP.RftVederiModele.RftVederiModeleMeniuStanga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereContinutTransport : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftVedereModelMeniuStanga rftVedereModelMeniuStanga;
        private readonly RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala;

        public RftComandaAccesareVedereContinutTransport(RftVedereModelContinut rftVedereModelContinut,
            RftVedereModelMeniuStanga rftVedereModelMeniuStanga,
            RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
            this.rftVedereModelMeniuStanga = rftVedereModelMeniuStanga;
            this.rftVedereModelFereastraPrincipala = rftVedereModelFereastraPrincipala;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinut.RftVedereModelContinutActual = rftVedereModelContinut.rftVedereModelContinutTransport;
            rftVedereModelMeniuStanga.RftVedereModelMeniuStangaCurent = new RftVedereModelMeniuStangaTransport(rftVedereModelContinut);
            rftVedereModelFereastraPrincipala.RftTextCategorieCurenta = "Transport";
        }
    }
}
