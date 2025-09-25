using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaEducatie : RftComandaBaza
    {
        private readonly RftVedereModelContinutEducatie rftVedereModelContinutEducatie;

        public RftComandaReinitializareTabelaEducatie(RftVedereModelContinutEducatie rftVedereModelContinutEducatie)
        {
            this.rftVedereModelContinutEducatie = rftVedereModelContinutEducatie;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutEducatie.RftStergereDate();
            rftVedereModelContinutEducatie.RftColectareDate();
            rftVedereModelContinutEducatie.RftGraficTitlu = "Evolutia Tranzactiilor pentru Educatie";
        }
    }
}
