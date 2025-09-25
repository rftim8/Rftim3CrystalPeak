using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERPBiblioteca.RftGeneral;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAlgoritmi.RftDistributieBuget
{
    internal class RftComandaSetareBugetNealocat : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftVedereModelContinutPrincipala rftVedereModelContinutPrincipala;
        private readonly RftServiciuDeDateBuget<RftModelBuget> rftServiciuDeDateBuget = new(new RftContextGeneratorModel());

        public RftComandaSetareBugetNealocat(RftVedereModelContinut rftVedereModelContinut, RftVedereModelContinutPrincipala rftVedereModelContinutPrincipala)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
            this.rftVedereModelContinutPrincipala = rftVedereModelContinutPrincipala;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelContinut.RftMesajEroare = "";

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetNealocatTemporar, out decimal rftBugetNealocatTemporar))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (rftBugetNealocatTemporar < 0)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMinim} 0!";
                return;
            }

            if (rftBugetNealocatTemporar > RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMaxim} {RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetNealocatTemporar.ToString("0.00") != rftBugetNealocatTemporar.ToString() &&
                rftBugetNealocatTemporar.ToString("0.0") != rftBugetNealocatTemporar.ToString() &&
                rftBugetNealocatTemporar.ToString("0") != rftBugetNealocatTemporar.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            rftVedereModelContinut.RftBugetNealocatActual = rftBugetNealocatTemporar.ToString();
            rftVedereModelContinut.RftBugetNealocatTemporar = rftBugetNealocatTemporar.ToString();
            Trace.WriteLine($"{rftBugetNealocatTemporar}");

            RftModelBuget x = rftServiciuDeDateBuget.RftReturnareObiectId(1).Result;
            x.Nealocat = rftBugetNealocatTemporar;
            await rftServiciuDeDateBuget.RftActualizareObiect(1, x);
        }
    }
}
