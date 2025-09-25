using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaImbracaminte : RftComandaBaza
    {
        private readonly RftVedereModelContinutImbracaminte rftVedereModelContinutImbracaminte;

        public RftComandaReinitializareTabelaImbracaminte(RftVedereModelContinutImbracaminte rftVedereModelContinutImbracaminte)
        {
            this.rftVedereModelContinutImbracaminte = rftVedereModelContinutImbracaminte;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutImbracaminte.RftStergereDate();
            rftVedereModelContinutImbracaminte.RftColectareDate();
            rftVedereModelContinutImbracaminte.RftGraficTitlu = "Evolutia Tranzactiilor pentru Imbracaminte";
        }
    }
}
