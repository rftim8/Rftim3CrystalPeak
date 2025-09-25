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
    internal class RftVedereModelMeniuStangaTransport : RftVedereModelBaza
    {
        public ICommand RftComandaAccesareVedereContinutPersonal { get; }
        public ICommand RftComandaAccesareVedereContinutComun { get; }

        public RftVedereModelMeniuStangaTransport(RftVedereModelContinut rftVedereModelContinut)
        {
            RftComandaAccesareVedereContinutPersonal = new RftComandaAccesareVedereContinutPersonal(rftVedereModelContinut);
            RftComandaAccesareVedereContinutComun = new RftComandaAccesareVedereContinutComun(rftVedereModelContinut);
        }
    }
}
