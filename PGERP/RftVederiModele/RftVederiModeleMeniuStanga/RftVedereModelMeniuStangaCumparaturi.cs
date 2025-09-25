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
    internal class RftVedereModelMeniuStangaCumparaturi : RftVedereModelBaza
    {
        public ICommand RftComandaAccesareVedereContinutAlimente { get; }
        public ICommand RftComandaAccesareVedereContinutImbracaminte { get; }
        public ICommand RftComandaAccesareVedereContinutElectronice { get; }

        public RftVedereModelMeniuStangaCumparaturi(RftVedereModelContinut rftVedereModelContinut)
        {
            RftComandaAccesareVedereContinutAlimente = new RftComandaAccesareVedereContinutAlimente(rftVedereModelContinut);
            RftComandaAccesareVedereContinutImbracaminte = new RftComandaAccesareVedereContinutImbracaminte(rftVedereModelContinut);
            RftComandaAccesareVedereContinutElectronice = new RftComandaAccesareVedereContinutElectronice(rftVedereModelContinut);
        }
    }
}
