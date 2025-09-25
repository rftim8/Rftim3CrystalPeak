using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaSanatate : RftComandaBaza
    {
        private readonly RftVedereModelContinutSanatate rftVedereModelContinutSanatate;

        public RftComandaReinitializareTabelaSanatate(RftVedereModelContinutSanatate rftVedereModelContinutSanatate)
        {
            this.rftVedereModelContinutSanatate = rftVedereModelContinutSanatate;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutSanatate.RftStergereDate();
            rftVedereModelContinutSanatate.RftColectareDate();
            rftVedereModelContinutSanatate.RftGraficTitlu = "Evolutia Tranzactiilor pentru Sanatate";
        }
    }
}
