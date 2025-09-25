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
    internal class RftComandaSetareBugetCartiElectronice : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftServiciuDeDateBuget<RftModelBuget> rftServiciuDeDateBuget = new(new RftContextGeneratorModel());

        public RftComandaSetareBugetCartiElectronice(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelContinut.RftMesajEroare = "";

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetCartiElectroniceTemporar, out decimal rftBugetCartiElectroniceTemporar))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetNealocatActual, out decimal rftBugetNealocatActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetCartiElectroniceActual, out decimal rftBugetCartiElectroniceActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetEducatieActual, out decimal rftBugetEducatieActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (!decimal.TryParse(rftVedereModelContinut.RftBugetTotalActual, out decimal rftBugetTotalActual))
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }

            if (rftBugetCartiElectroniceTemporar < -RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMinim} -{RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetCartiElectroniceTemporar > RftGeneral.RftBugetMaxim)
            {
                rftVedereModelContinut.RftMesajEroare = $"{RftMesajePredefinite.RftEroareBugetMaxim} {RftGeneral.RftBugetMaxim}!";
                return;
            }

            if (rftBugetCartiElectroniceTemporar > rftBugetNealocatActual)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetNealocatDepasit;
                return;
            }

            if (rftBugetCartiElectroniceActual + rftBugetCartiElectroniceTemporar < 0)
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareBugetIndisponibil;
                return;
            }

            if (rftBugetCartiElectroniceTemporar.ToString("0.00") != rftBugetCartiElectroniceTemporar.ToString() &&
                rftBugetCartiElectroniceTemporar.ToString("0.0") != rftBugetCartiElectroniceTemporar.ToString() &&
                rftBugetCartiElectroniceTemporar.ToString("0") != rftBugetCartiElectroniceTemporar.ToString())
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
            if (rftBugetCartiElectroniceActual.ToString("0.00") != rftBugetCartiElectroniceActual.ToString() &&
                rftBugetCartiElectroniceActual.ToString("0.0") != rftBugetCartiElectroniceActual.ToString() &&
                rftBugetCartiElectroniceActual.ToString("0") != rftBugetCartiElectroniceActual.ToString())
            {
                rftVedereModelContinut.RftMesajEroare = RftMesajePredefinite.RftEroareFormatBugetGresit;
                return;
            }
            if (rftBugetEducatieActual.ToString("0.00") != rftBugetEducatieActual.ToString() &&
                rftBugetEducatieActual.ToString("0.0") != rftBugetEducatieActual.ToString() &&
                rftBugetEducatieActual.ToString("0") != rftBugetEducatieActual.ToString())
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

            rftBugetNealocatActual -= rftBugetCartiElectroniceTemporar;
            rftBugetCartiElectroniceActual += rftBugetCartiElectroniceTemporar;
            rftBugetEducatieActual += rftBugetCartiElectroniceTemporar;
            rftBugetTotalActual += rftBugetCartiElectroniceTemporar;

            rftVedereModelContinut.RftBugetNealocatActual = rftBugetNealocatActual.ToString();
            rftVedereModelContinut.RftBugetCartiElectroniceActual = rftBugetCartiElectroniceActual.ToString();
            rftVedereModelContinut.RftBugetEducatieActual = rftBugetEducatieActual.ToString();
            rftVedereModelContinut.RftBugetTotalActual = rftBugetTotalActual.ToString();
            rftVedereModelContinut.RftBugetCartiElectroniceTemporar = rftBugetCartiElectroniceTemporar.ToString();

            RftModelBuget x = rftServiciuDeDateBuget.RftReturnareObiectId(1).Result;
            x.Nealocat = rftBugetNealocatActual;
            x.EducatieCartiElectronice = rftBugetCartiElectroniceActual;
            x.Educatie = rftBugetEducatieActual;
            x.Total = rftBugetTotalActual;
            await rftServiciuDeDateBuget.RftActualizareObiect(1, x);
        }

    }
}
