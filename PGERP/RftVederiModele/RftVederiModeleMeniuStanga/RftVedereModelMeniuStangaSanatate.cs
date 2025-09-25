using PGERP.RftComenzi;
using PGERP.RftComenzi.RftAccesareVederi;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PGERP.RftVederiModele.RftVederiModeleMeniuStanga
{
    internal class RftVedereModelMeniuStangaSanatate : RftVedereModelBaza
    {
        public ICommand RftComandaAccesareVedereContinutActivitatiSportive { get; }
        public ICommand RftComandaAccesareVedereContinutMedical { get; }

        public RftVedereModelMeniuStangaSanatate(RftVedereModelContinut rftVedereModelContinut)
        {
            RftComandaAccesareVedereContinutActivitatiSportive = new RftComandaAccesareVedereContinutActivitatiSportive(rftVedereModelContinut);
            RftComandaAccesareVedereContinutMedical = new RftComandaAccesareVedereContinutMedical(rftVedereModelContinut);
        }
    }
}
