using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaActivitatiSportive : RftComandaBaza
    {
        private readonly RftVedereModelContinutActivitatiSportive rftVedereModelContinutActivitatiSportive;

        public RftComandaReinitializareTabelaActivitatiSportive(RftVedereModelContinutActivitatiSportive rftVedereModelContinutActivitatiSportive)
        {
            this.rftVedereModelContinutActivitatiSportive = rftVedereModelContinutActivitatiSportive;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutActivitatiSportive.RftStergereDate();
            rftVedereModelContinutActivitatiSportive.RftColectareDate();
            rftVedereModelContinutActivitatiSportive.RftGraficTitlu = "Evolutia Tranzactiilor pentru Activitati Sportive";
        }
    }
}
