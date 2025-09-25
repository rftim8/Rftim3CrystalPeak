using PGERP.RftModele;
using PGERP.RftSQL;
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
    internal class RftComandaSetareBugetActivitatiSportive : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftServiciuDeDateBuget<RftModelBuget> rftServiciuDeDateBuget = new(new RftContextGeneratorModel());

        public RftComandaSetareBugetActivitatiSportive(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelContinut.RftMesajEroare = "";

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetActivitatiSportiveTemporar, out decimal rftBugetActivitatiSportiveTemporar))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetNealocatActual, out decimal rftBugetNealocatActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetActivitatiSportiveActual, out decimal rftBugetActivitatiSportiveActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetSanatateActual, out decimal rftBugetSanatateActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTotalActual, out decimal rftBugetTotalActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (rftBugetActivitatiSportiveTemporar < -RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMinim} -{RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetActivitatiSportiveTemporar > RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMaxim} {RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetActivitatiSportiveTemporar > rftBugetNealocatActual)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetNealocatDepasit;
                return;
            }

            if (rftBugetActivitatiSportiveActual + rftBugetActivitatiSportiveTemporar < 0)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetIndisponibil;
                return;
            }

            if (rftBugetActivitatiSportiveTemporar.ToString("0.00") != rftBugetActivitatiSportiveTemporar.ToString() &&
                rftBugetActivitatiSportiveTemporar.ToString("0.0") != rftBugetActivitatiSportiveTemporar.ToString() &&
                rftBugetActivitatiSportiveTemporar.ToString("0") != rftBugetActivitatiSportiveTemporar.ToString())
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
            if (rftBugetActivitatiSportiveActual.ToString("0.00") != rftBugetActivitatiSportiveActual.ToString() &&
                rftBugetActivitatiSportiveActual.ToString("0.0") != rftBugetActivitatiSportiveActual.ToString() &&
                rftBugetActivitatiSportiveActual.ToString("0") != rftBugetActivitatiSportiveActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetSanatateActual.ToString("0.00") != rftBugetSanatateActual.ToString() &&
                rftBugetSanatateActual.ToString("0.0") != rftBugetSanatateActual.ToString() &&
                rftBugetSanatateActual.ToString("0") != rftBugetSanatateActual.ToString())
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

            rftBugetNealocatActual -= rftBugetActivitatiSportiveTemporar;
            rftBugetActivitatiSportiveActual += rftBugetActivitatiSportiveTemporar;
            rftBugetSanatateActual += rftBugetActivitatiSportiveTemporar;
            rftBugetTotalActual += rftBugetActivitatiSportiveTemporar;

            rftVedereModelContinut.RftBugetNealocatActual = rftBugetNealocatActual.ToString();
            rftVedereModelContinut.RftBugetActivitatiSportiveActual = rftBugetActivitatiSportiveActual.ToString();
            rftVedereModelContinut.RftBugetSanatateActual = rftBugetSanatateActual.ToString();
            rftVedereModelContinut.RftBugetTotalActual = rftBugetTotalActual.ToString();
            rftVedereModelContinut.RftBugetActivitatiSportiveTemporar = rftBugetActivitatiSportiveTemporar.ToString();

            RftModelBuget x = rftServiciuDeDateBuget.RftReturnareObiectId(1).Result;
            x.Nealocat = rftBugetNealocatActual;
            x.SanatateActivitatiSportive = rftBugetActivitatiSportiveActual;
            x.Sanatate = rftBugetSanatateActual;
            x.Total = rftBugetTotalActual;
            await rftServiciuDeDateBuget.RftActualizareObiect(1, x);
        }

    }
}
