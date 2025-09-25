using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaElectronice : RftComandaBaza
    {
        private readonly RftVedereModelContinutElectronice rftVedereModelContinutElectronice;

        public RftComandaReinitializareTabelaElectronice(RftVedereModelContinutElectronice rftVedereModelContinutElectronice)
        {
            this.rftVedereModelContinutElectronice = rftVedereModelContinutElectronice;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutElectronice.RftStergereDate();
            rftVedereModelContinutElectronice.RftColectareDate();
            rftVedereModelContinutElectronice.RftGraficTitlu = "Evolutia Tranzactiilor pentru Electronice";
        }
    }
}
