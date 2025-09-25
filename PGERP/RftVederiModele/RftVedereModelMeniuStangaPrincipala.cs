using PGERP.RftComenzi.RftAccesareVederi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PGERP.RftVederiModele
{
    internal class RftVedereModelMeniuStangaPrincipala : RftVedereModelBaza
    {
        public ICommand RftComandaAccesareVedereContinutSetariCont { get; }
        public ICommand RftComandaAccesareVedereContinutSetariProgram { get; }

        public RftVedereModelMeniuStangaPrincipala()
        {
            RftComandaAccesareVedereContinutSetariCont = new RftComandaAccesareVedereContinutSetariCont();
            RftComandaAccesareVedereContinutSetariProgram = new RftComandaAccesareVedereContinutSetariProgram();
        }
    }
}
