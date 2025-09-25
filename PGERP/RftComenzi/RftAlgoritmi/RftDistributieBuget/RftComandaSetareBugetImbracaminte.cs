using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERPBiblioteca.RftGeneral;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAlgoritmi.RftDistributieBuget
{
    internal class RftComandaSetareBugetImbracaminte : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftServiciuDeDateBuget<RftModelBuget> rftServiciuDeDateBuget = new(new RftContextGeneratorModel());

        public RftComandaSetareBugetImbracaminte(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelContinut.RftMesajEroare = "";

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetImbracaminteTemporar, out decimal rftBugetImbracaminteTemporar))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetNealocatActual, out decimal rftBugetNealocatActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetImbracaminteActual, out decimal rftBugetImbracaminteActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetCumparaturiActual, out decimal rftBugetCumparaturiActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTotalActual, out decimal rftBugetTotalActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (rftBugetImbracaminteTemporar < -RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMinim} -{RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetImbracaminteTemporar > RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMaxim} {RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetImbracaminteTemporar > rftBugetNealocatActual)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetNealocatDepasit;
                return;
            }

            if (rftBugetImbracaminteActual + rftBugetImbracaminteTemporar < 0)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetIndisponibil;
                return;
            }

            if (rftBugetImbracaminteTemporar.ToString("0.00") != rftBugetImbracaminteTemporar.ToString() &&
                rftBugetImbracaminteTemporar.ToString("0.0") != rftBugetImbracaminteTemporar.ToString() &&
                rftBugetImbracaminteTemporar.ToString("0") != rftBugetImbracaminteTemporar.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetNealocatActual.ToString("0.00") != rftBugetNealocatActual.ToString() &&
                rftBugetNealocatActual.ToString("0.0") != rftBugetNealocatActual.ToString() &&
                rftBugetNealocatActual.ToString("0") != rftBugetNealocatActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetImbracaminteActual.ToString("0.00") != rftBugetImbracaminteActual.ToString() &&
                rftBugetImbracaminteActual.ToString("0.0") != rftBugetImbracaminteActual.ToString() &&
                rftBugetImbracaminteActual.ToString("0") != rftBugetImbracaminteActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetCumparaturiActual.ToString("0.00") != rftBugetCumparaturiActual.ToString() &&
                rftBugetCumparaturiActual.ToString("0.0") != rftBugetCumparaturiActual.ToString() &&
                rftBugetCumparaturiActual.ToString("0") != rftBugetCumparaturiActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetTotalActual.ToString("0.00") != rftBugetTotalActual.ToString() &&
                rftBugetTotalActual.ToString("0.0") != rftBugetTotalActual.ToString() &&
                rftBugetTotalActual.ToString("0") != rftBugetTotalActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            rftBugetNealocatActual -= rftBugetImbracaminteTemporar;
            rftBugetImbracaminteActual += rftBugetImbracaminteTemporar;
            rftBugetCumparaturiActual += rftBugetImbracaminteTemporar;
            rftBugetTotalActual += rftBugetImbracaminteTemporar;

            rftVedereModelContinut.RftBugetNealocatActual = rftBugetNealocatActual.ToString();
            rftVedereModelContinut.RftBugetImbracaminteActual = rftBugetImbracaminteActual.ToString();
            rftVedereModelContinut.RftBugetCumparaturiActual = rftBugetCumparaturiActual.ToString();
            rftVedereModelContinut.RftBugetTotalActual = rftBugetTotalActual.ToString();
            rftVedereModelContinut.RftBugetImbracaminteTemporar = rftBugetImbracaminteTemporar.ToString();

            RftModelBuget x = rftServiciuDeDateBuget.RftReturnareObiectId(1).Result;
            x.Nealocat = rftBugetNealocatActual;
            x.CumparaturiImbracaminte = rftBugetImbracaminteActual;
            x.Cumparaturi = rftBugetCumparaturiActual;
            x.Total = rftBugetTotalActual;
            await rftServiciuDeDateBuget.RftActualizareObiect(1, x);
        }

    }
}
