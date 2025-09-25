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
    internal class RftComandaSetareBugetComun : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftServiciuDeDateBuget<RftModelBuget> rftServiciuDeDateBuget = new(new RftContextGeneratorModel());

        public RftComandaSetareBugetComun(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelContinut.RftMesajEroare = "";

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetComunTemporar, out decimal rftBugetComunTemporar))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetNealocatActual, out decimal rftBugetNealocatActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetComunActual, out decimal rftBugetComunActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTransportActual, out decimal rftBugetTransportActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTotalActual, out decimal rftBugetTotalActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (rftBugetComunTemporar < -RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMinim} -{RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetComunTemporar > RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMaxim} {RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetComunTemporar > rftBugetNealocatActual)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetNealocatDepasit;
                return;
            }

            if (rftBugetComunActual + rftBugetComunTemporar < 0)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetIndisponibil;
                return;
            }

            if (rftBugetComunTemporar.ToString("0.00") != rftBugetComunTemporar.ToString() &&
                rftBugetComunTemporar.ToString("0.0") != rftBugetComunTemporar.ToString() &&
                rftBugetComunTemporar.ToString("0") != rftBugetComunTemporar.ToString())
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
            if (rftBugetComunActual.ToString("0.00") != rftBugetComunActual.ToString() &&
                rftBugetComunActual.ToString("0.0") != rftBugetComunActual.ToString() &&
                rftBugetComunActual.ToString("0") != rftBugetComunActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetTransportActual.ToString("0.00") != rftBugetTransportActual.ToString() &&
                rftBugetTransportActual.ToString("0.0") != rftBugetTransportActual.ToString() &&
                rftBugetTransportActual.ToString("0") != rftBugetTransportActual.ToString())
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

            rftBugetNealocatActual -= rftBugetComunTemporar;
            rftBugetComunActual += rftBugetComunTemporar;
            rftBugetTransportActual += rftBugetComunTemporar;
            rftBugetTotalActual += rftBugetComunTemporar;

            rftVedereModelContinut.RftBugetNealocatActual = rftBugetNealocatActual.ToString();
            rftVedereModelContinut.RftBugetComunActual = rftBugetComunActual.ToString();
            rftVedereModelContinut.RftBugetTransportActual = rftBugetTransportActual.ToString();
            rftVedereModelContinut.RftBugetTotalActual = rftBugetTotalActual.ToString();
            rftVedereModelContinut.RftBugetComunTemporar = rftBugetComunTemporar.ToString();

            RftModelBuget x = rftServiciuDeDateBuget.RftReturnareObiectId(1).Result;
            x.Nealocat = rftBugetNealocatActual;
            x.TransportComun = rftBugetComunActual;
            x.Transport = rftBugetTransportActual;
            x.Total = rftBugetTotalActual;
            await rftServiciuDeDateBuget.RftActualizareObiect(1, x);
        }

    }
}
