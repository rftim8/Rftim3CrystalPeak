using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaCurent : RftComandaBaza
    {
        private readonly RftVedereModelContinutCurent rftVedereModelContinutCurent;

        public RftComandaReinitializareTabelaCurent(RftVedereModelContinutCurent rftVedereModelContinutCurent)
        {
            this.rftVedereModelContinutCurent = rftVedereModelContinutCurent;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutCurent.RftStergereDate();
            rftVedereModelContinutCurent.RftColectareDate();
            rftVedereModelContinutCurent.RftGraficTitlu = "Evolutia Tranzactiilor pentru Facturi Curent";
        }
    }
}
