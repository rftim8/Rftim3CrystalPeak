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
    internal class RftVedereModelMeniuStangaDivertisment : RftVedereModelBaza
    {
        public ICommand RftComandaAccesareVedereContinutFilme { get; }
        public ICommand RftComandaAccesareVedereContinutMuzica { get; }
        public ICommand RftComandaAccesareVedereContinutJocuri { get; }

        public RftVedereModelMeniuStangaDivertisment(RftVedereModelContinut rftVedereModelContinut)
        {
            RftComandaAccesareVedereContinutFilme = new RftComandaAccesareVedereContinutFilme(rftVedereModelContinut);
            RftComandaAccesareVedereContinutMuzica = new RftComandaAccesareVedereContinutMuzica(rftVedereModelContinut);
            RftComandaAccesareVedereContinutJocuri = new RftComandaAccesareVedereContinutJocuri(rftVedereModelContinut);
        }
    }
}
