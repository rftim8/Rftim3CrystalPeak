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
    internal class RftComandaSetareBugetTelefonie : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftServiciuDeDateBuget<RftModelBuget> rftServiciuDeDateBuget = new(new RftContextGeneratorModel());

        public RftComandaSetareBugetTelefonie(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelContinut.RftMesajEroare = "";

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTelefonieTemporar, out decimal rftBugetTelefonieTemporar))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetNealocatActual, out decimal rftBugetNealocatActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTelefonieActual, out decimal rftBugetTelefonieActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetFacturiActual, out decimal rftBugetFacturiActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTotalActual, out decimal rftBugetTotalActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (rftBugetTelefonieTemporar < -RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMinim} -{RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetTelefonieTemporar > RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMaxim} {RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetTelefonieTemporar > rftBugetNealocatActual)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetNealocatDepasit;
                return;
            }

            if (rftBugetTelefonieActual + rftBugetTelefonieTemporar < 0)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetIndisponibil;
                return;
            }

            if (rftBugetTelefonieTemporar.ToString("0.00") != rftBugetTelefonieTemporar.ToString() &&
                rftBugetTelefonieTemporar.ToString("0.0") != rftBugetTelefonieTemporar.ToString() &&
                rftBugetTelefonieTemporar.ToString("0") != rftBugetTelefonieTemporar.ToString())
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
            if (rftBugetTelefonieActual.ToString("0.00") != rftBugetTelefonieActual.ToString() &&
                rftBugetTelefonieActual.ToString("0.0") != rftBugetTelefonieActual.ToString() &&
                rftBugetTelefonieActual.ToString("0") != rftBugetTelefonieActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetFacturiActual.ToString("0.00") != rftBugetFacturiActual.ToString() &&
                rftBugetFacturiActual.ToString("0.0") != rftBugetFacturiActual.ToString() &&
                rftBugetFacturiActual.ToString("0") != rftBugetFacturiActual.ToString())
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

            rftBugetNealocatActual -= rftBugetTelefonieTemporar;
            rftBugetTelefonieActual += rftBugetTelefonieTemporar;
            rftBugetFacturiActual += rftBugetTelefonieTemporar;
            rftBugetTotalActual += rftBugetTelefonieTemporar;

            rftVedereModelContinut.RftBugetNealocatActual = rftBugetNealocatActual.ToString();
            rftVedereModelContinut.RftBugetTelefonieActual = rftBugetTelefonieActual.ToString();
            rftVedereModelContinut.RftBugetFacturiActual = rftBugetFacturiActual.ToString();
            rftVedereModelContinut.RftBugetTotalActual = rftBugetTotalActual.ToString();
            rftVedereModelContinut.RftBugetTelefonieTemporar = rftBugetTelefonieTemporar.ToString();

            RftModelBuget x = rftServiciuDeDateBuget.RftReturnareObiectId(1).Result;
            x.Nealocat = rftBugetNealocatActual;
            x.FacturiTelefonie = rftBugetTelefonieActual;
            x.Facturi = rftBugetFacturiActual;
            x.Total = rftBugetTotalActual;
            await rftServiciuDeDateBuget.RftActualizareObiect(1, x);
        }

    }
}
