using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela.RftReinitializare
{
    internal class RftComandaReinitializareTabelaMuzica : RftComandaBaza
    {
        private readonly RftVedereModelContinutMuzica rftVedereModelContinutMuzica;

        public RftComandaReinitializareTabelaMuzica(RftVedereModelContinutMuzica rftVedereModelContinutMuzica)
        {
            this.rftVedereModelContinutMuzica = rftVedereModelContinutMuzica;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutMuzica.RftStergereDate();
            rftVedereModelContinutMuzica.RftColectareDate();
            rftVedereModelContinutMuzica.RftGraficTitlu = "Evolutia Tranzactiilor pentru Muzica";
        }
    }
}
