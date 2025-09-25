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
    internal class RftVedereModelMeniuStangaEducatie : RftVedereModelBaza
    {
        public ICommand RftComandaAccesareVedereContinutCartiElectronice { get; }
        public ICommand RftComandaAccesareVedereContinutInvatamant { get; }
        public ICommand RftComandaAccesareVedereContinutEvenimente { get; }

        public RftVedereModelMeniuStangaEducatie(RftVedereModelContinut rftVedereModelContinut)
        {
            RftComandaAccesareVedereContinutCartiElectronice = new RftComandaAccesareVedereContinutCartiElectronice(rftVedereModelContinut);
            RftComandaAccesareVedereContinutInvatamant = new RftComandaAccesareVedereContinutInvatamant(rftVedereModelContinut);
            RftComandaAccesareVedereContinutEvenimente = new RftComandaAccesareVedereContinutEvenimente(rftVedereModelContinut);
        }
    }
}
