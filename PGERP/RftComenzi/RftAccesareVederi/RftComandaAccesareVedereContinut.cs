using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereContinut : RftComandaBaza
    {
        private readonly RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala;

        public RftComandaAccesareVedereContinut(RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala)
        {
            this.rftVedereModelFereastraPrincipala = rftVedereModelFereastraPrincipala;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelFereastraPrincipala.RftVedereModelContinutCurent = rftVedereModelFereastraPrincipala.RftVedereModelContinut;
        }
    }
}
