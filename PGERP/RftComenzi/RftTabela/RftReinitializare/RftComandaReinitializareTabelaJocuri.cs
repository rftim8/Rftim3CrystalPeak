using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaJocuri : RftComandaBaza
    {
        private readonly RftVedereModelContinutJocuri rftVedereModelContinutJocuri;

        public RftComandaReinitializareTabelaJocuri(RftVedereModelContinutJocuri rftVedereModelContinutJocuri)
        {
            this.rftVedereModelContinutJocuri = rftVedereModelContinutJocuri;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutJocuri.RftStergereDate();
            rftVedereModelContinutJocuri.RftColectareDate();
            rftVedereModelContinutJocuri.RftGraficTitlu = "Evolutia Tranzactiilor pentru Jocuri";
        }
    }
}
