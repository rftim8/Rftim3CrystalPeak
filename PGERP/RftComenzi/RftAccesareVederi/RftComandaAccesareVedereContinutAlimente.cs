using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERP.RftVederiModele.RftVederiModeleMeniuStanga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereContinutAlimente : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;

        public RftComandaAccesareVedereContinutAlimente(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinut.RftVedereModelContinutActual = rftVedereModelContinut.rftVedereModelContinutAlimente;
        }
    }
}
