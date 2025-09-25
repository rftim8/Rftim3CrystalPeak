using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaInvatamant : RftComandaBaza
    {
        private readonly RftVedereModelContinutInvatamant rftVedereModelContinutInvatamant;

        public RftComandaReinitializareTabelaInvatamant(RftVedereModelContinutInvatamant rftVedereModelContinutInvatamant)
        {
            this.rftVedereModelContinutInvatamant = rftVedereModelContinutInvatamant;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutInvatamant.RftStergereDate();
            rftVedereModelContinutInvatamant.RftColectareDate();
            rftVedereModelContinutInvatamant.RftGraficTitlu = "Evolutia Tranzactiilor pentru Invatamant";
        }
    }
}
