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
    internal class RftComandaAccesareVedereContinutSanatate : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftVedereModelMeniuStanga rftVedereModelMeniuStanga;
        private readonly RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala;

        public RftComandaAccesareVedereContinutSanatate(RftVedereModelContinut rftVedereModelContinut,
            RftVedereModelMeniuStanga rftVedereModelMeniuStanga,
            RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
            this.rftVedereModelMeniuStanga = rftVedereModelMeniuStanga;
            this.rftVedereModelFereastraPrincipala = rftVedereModelFereastraPrincipala;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinut.RftVedereModelContinutActual = rftVedereModelContinut.rftVedereModelContinutSanatate;
            rftVedereModelMeniuStanga.RftVedereModelMeniuStangaCurent = new RftVedereModelMeniuStangaSanatate(rftVedereModelContinut);
            rftVedereModelFereastraPrincipala.RftTextCategorieCurenta = "Sanatate";
        }
    }
}
