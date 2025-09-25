using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaDivertisment : RftComandaBaza
    {
        private readonly RftVedereModelContinutDivertisment rftVedereModelContinutDivertisment;

        public RftComandaReinitializareTabelaDivertisment(RftVedereModelContinutDivertisment rftVedereModelContinutDivertisment)
        {
            this.rftVedereModelContinutDivertisment = rftVedereModelContinutDivertisment;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutDivertisment.RftStergereDate();
            rftVedereModelContinutDivertisment.RftColectareDate();
            rftVedereModelContinutDivertisment.RftGraficTitlu = "Evolutia Tranzactiilor pentru Divertisment";
        }
    }
}
