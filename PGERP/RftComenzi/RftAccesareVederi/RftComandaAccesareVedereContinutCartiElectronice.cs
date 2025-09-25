using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereContinutCartiElectronice : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;

        public RftComandaAccesareVedereContinutCartiElectronice(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinut.RftVedereModelContinutActual = rftVedereModelContinut.rftVedereModelContinutCartiElectronice;
        }
    }
}
