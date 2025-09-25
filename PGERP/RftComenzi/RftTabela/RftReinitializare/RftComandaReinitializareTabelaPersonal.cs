using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaPersonal : RftComandaBaza
    {
        private readonly RftVedereModelContinutPersonal rftVedereModelContinutPersonal;

        public RftComandaReinitializareTabelaPersonal(RftVedereModelContinutPersonal rftVedereModelContinutPersonal)
        {
            this.rftVedereModelContinutPersonal = rftVedereModelContinutPersonal;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutPersonal.RftStergereDate();
            rftVedereModelContinutPersonal.RftColectareDate();
            rftVedereModelContinutPersonal.RftGraficTitlu = "Evolutia Tranzactiilor pentu Transport Personal";
        }
    }
}
