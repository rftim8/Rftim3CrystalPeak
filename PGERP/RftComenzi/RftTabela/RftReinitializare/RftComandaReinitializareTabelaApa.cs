using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaApa : RftComandaBaza
    {
        private readonly RftVedereModelContinutApa rftVedereModelContinutApa;

        public RftComandaReinitializareTabelaApa(RftVedereModelContinutApa rftVedereModelContinutApa)
        {
            this.rftVedereModelContinutApa = rftVedereModelContinutApa;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutApa.RftStergereDate();
            rftVedereModelContinutApa.RftColectareDate();
            rftVedereModelContinutApa.RftGraficTitlu = "Evolutia Tranzactiilor pentru Facturi Apa";
        }
    }
}
