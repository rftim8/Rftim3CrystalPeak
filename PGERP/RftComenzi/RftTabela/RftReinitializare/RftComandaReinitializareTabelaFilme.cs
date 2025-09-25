using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaFilme : RftComandaBaza
    {
        private readonly RftVedereModelContinutFilme rftVedereModelContinutFilme;

        public RftComandaReinitializareTabelaFilme(RftVedereModelContinutFilme rftVedereModelContinutFilme)
        {
            this.rftVedereModelContinutFilme = rftVedereModelContinutFilme;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutFilme.RftStergereDate();
            rftVedereModelContinutFilme.RftColectareDate();
            rftVedereModelContinutFilme.RftGraficTitlu = "Evolutia Tranzactiilor pentru Filme";
        }
    }
}
