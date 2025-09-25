using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaCumparaturi : RftComandaBaza
    {
        private readonly RftVedereModelContinutCumparaturi rftVedereModelContinutCumparaturi;

        public RftComandaReinitializareTabelaCumparaturi(RftVedereModelContinutCumparaturi rftVedereModelContinutCumparaturi)
        {
            this.rftVedereModelContinutCumparaturi = rftVedereModelContinutCumparaturi;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutCumparaturi.RftStergereDate();
            rftVedereModelContinutCumparaturi.RftColectareDate();
            rftVedereModelContinutCumparaturi.RftGraficTitlu = "Evolutia Tranzactiilor pentru Cumparaturi";
        }
    }
}
