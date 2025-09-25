using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaFacturi : RftComandaBaza
    {
        private readonly RftVedereModelContinutFacturi rftVedereModelContinutFacturi;

        public RftComandaReinitializareTabelaFacturi(RftVedereModelContinutFacturi rftVedereModelContinutFacturi)
        {
            this.rftVedereModelContinutFacturi = rftVedereModelContinutFacturi;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutFacturi.RftStergereDate();
            rftVedereModelContinutFacturi.RftColectareDate();
            rftVedereModelContinutFacturi.RftGraficTitlu = "Evolutia Tranzactiilor pentru Facturi";
        }
    }
}
