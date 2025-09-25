using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaTelefonie : RftComandaBaza
    {
        private readonly RftVedereModelContinutTelefonie rftVedereModelContinutTelefonie;

        public RftComandaReinitializareTabelaTelefonie(RftVedereModelContinutTelefonie rftVedereModelContinutTelefonie)
        {
            this.rftVedereModelContinutTelefonie = rftVedereModelContinutTelefonie;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutTelefonie.RftStergereDate();
            rftVedereModelContinutTelefonie.RftColectareDate();
            rftVedereModelContinutTelefonie.RftGraficTitlu = "Evolutia Tranzactiilor pentru Telefonie";
        }
    }
}
