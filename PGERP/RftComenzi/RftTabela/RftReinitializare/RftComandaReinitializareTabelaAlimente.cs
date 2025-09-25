using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaAlimente : RftComandaBaza
    {
        private readonly RftVedereModelContinutAlimente rftVedereModelContinutAlimente;

        public RftComandaReinitializareTabelaAlimente(RftVedereModelContinutAlimente rftVedereModelContinutAlimente)
        {
            this.rftVedereModelContinutAlimente = rftVedereModelContinutAlimente;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutAlimente.RftStergereDate();
            rftVedereModelContinutAlimente.RftColectareDate();
            rftVedereModelContinutAlimente.RftGraficTitlu = "Evolutia Tranzactiilor pentru Alimente";
        }
    }
}
