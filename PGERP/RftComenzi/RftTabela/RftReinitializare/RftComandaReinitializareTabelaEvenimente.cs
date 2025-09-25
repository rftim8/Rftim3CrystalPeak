using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaEvenimente : RftComandaBaza
    {
        private readonly RftVedereModelContinutEvenimente rftVedereModelContinutEvenimente;

        public RftComandaReinitializareTabelaEvenimente(RftVedereModelContinutEvenimente rftVedereModelContinutEvenimente)
        {
            this.rftVedereModelContinutEvenimente = rftVedereModelContinutEvenimente;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutEvenimente.RftStergereDate();
            rftVedereModelContinutEvenimente.RftColectareDate();
            rftVedereModelContinutEvenimente.RftGraficTitlu = "Evolutia Tranzactiilor pentru Evenimente";
        }
    }
}
