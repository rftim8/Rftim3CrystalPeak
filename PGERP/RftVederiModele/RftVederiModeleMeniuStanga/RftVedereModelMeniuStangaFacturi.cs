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
    internal class RftVedereModelMeniuStangaFacturi : RftVedereModelBaza
    {
        public ICommand RftComandaAccesareVedereContinutApa { get; }
        public ICommand RftComandaAccesareVedereContinutCurent { get; }
        public ICommand RftComandaAccesareVedereContinutTelefonie { get; }

        public RftVedereModelMeniuStangaFacturi(RftVedereModelContinut rftVedereModelContinut)
        {
            RftComandaAccesareVedereContinutApa = new RftComandaAccesareVedereContinutApa(rftVedereModelContinut);
            RftComandaAccesareVedereContinutCurent = new RftComandaAccesareVedereContinutCurent(rftVedereModelContinut);
            RftComandaAccesareVedereContinutTelefonie = new RftComandaAccesareVedereContinutTelefonie(rftVedereModelContinut);
        }
    }
}
