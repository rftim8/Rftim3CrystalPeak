using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaMedical : RftComandaBaza
    {
        private readonly RftVedereModelContinutMedical rftVedereModelContinutMedical;

        public RftComandaReinitializareTabelaMedical(RftVedereModelContinutMedical rftVedereModelContinutMedical)
        {
            this.rftVedereModelContinutMedical = rftVedereModelContinutMedical;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutMedical.RftStergereDate();
            rftVedereModelContinutMedical.RftColectareDate();
            rftVedereModelContinutMedical.RftGraficTitlu = "Evolutia Tranzactiilor pentru Medical";
        }
    }
}
