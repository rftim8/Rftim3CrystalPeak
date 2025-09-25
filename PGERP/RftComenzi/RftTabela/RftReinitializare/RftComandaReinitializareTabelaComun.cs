using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaComun : RftComandaBaza
    {
        private readonly RftVedereModelContinutComun rftVedereModelContinutComun;

        public RftComandaReinitializareTabelaComun(RftVedereModelContinutComun rftVedereModelContinutComun)
        {
            this.rftVedereModelContinutComun = rftVedereModelContinutComun;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutComun.RftStergereDate();
            rftVedereModelContinutComun.RftColectareDate();
            rftVedereModelContinutComun.RftGraficTitlu = "Evolutia Tranzactiilor pentru Transport Comun";
        }
    }
}
