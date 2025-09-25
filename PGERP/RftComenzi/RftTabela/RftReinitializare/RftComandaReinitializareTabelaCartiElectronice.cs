using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaCartiElectronice : RftComandaBaza
    {
        private readonly RftVedereModelContinutCartiElectronice rftVedereModelContinutCartiElectronice;

        public RftComandaReinitializareTabelaCartiElectronice(RftVedereModelContinutCartiElectronice rftVedereModelContinutCartiElectronice)
        {
            this.rftVedereModelContinutCartiElectronice = rftVedereModelContinutCartiElectronice;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutCartiElectronice.RftStergereDate();
            rftVedereModelContinutCartiElectronice.RftColectareDate();
            rftVedereModelContinutCartiElectronice.RftGraficTitlu = "Evolutia Generala a Tranzactiilor in Timp";
        }
    }
}
