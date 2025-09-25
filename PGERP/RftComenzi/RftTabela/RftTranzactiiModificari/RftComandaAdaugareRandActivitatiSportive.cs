using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftTranzactiiModificari
{
    internal class RftComandaAdaugareRandActivitatiSportive : RftComandaBaza
    {
        private readonly RftVedereModelContinutActivitatiSportive rftVedereModelContinutActivitatiSportive;

        public RftComandaAdaugareRandActivitatiSportive(RftVedereModelContinutActivitatiSportive rftVedereModelContinutActivitatiSportive)
        {
            this.rftVedereModelContinutActivitatiSportive = rftVedereModelContinutActivitatiSportive;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutActivitatiSportive.RftVedereAdaugareVizibila = true;
        }
    }
}
