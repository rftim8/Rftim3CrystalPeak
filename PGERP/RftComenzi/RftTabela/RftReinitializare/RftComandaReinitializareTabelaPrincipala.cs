using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaPrincipala : RftComandaBaza
    {
        private readonly RftVedereModelContinutPrincipala rftVedereModelContinutPrincipala;

        public RftComandaReinitializareTabelaPrincipala(RftVedereModelContinutPrincipala rftVedereModelContinutPrincipala)
        {
            this.rftVedereModelContinutPrincipala = rftVedereModelContinutPrincipala;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutPrincipala.RftStergereDate();
            rftVedereModelContinutPrincipala.RftColectareDate();
            rftVedereModelContinutPrincipala.RftGraficTitlu = "Evolutia Generala a Tranzactiilor in Timp";
        }
    }
}
