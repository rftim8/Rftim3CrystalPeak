using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaTransport : RftComandaBaza
    {
        private readonly RftVedereModelContinutTransport rftVedereModelContinutTransport;

        public RftComandaReinitializareTabelaTransport(RftVedereModelContinutTransport rftVedereModelContinutTransport)
        {
            this.rftVedereModelContinutTransport = rftVedereModelContinutTransport;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutTransport.RftStergereDate();
            rftVedereModelContinutTransport.RftColectareDate();
            rftVedereModelContinutTransport.RftGraficTitlu = "Evolutia Tranzactiilor pentru Transport";
        }
    }
}
