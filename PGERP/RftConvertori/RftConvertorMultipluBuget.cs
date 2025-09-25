using PGERPBiblioteca.RftGeneral;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PGERP.RftConvertori
{
    public class RftConvertorMultipluBuget : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string? rftBugetNealocatActual = values[0].ToString();
            string? rftBugetSubCategorieTemporar = values[1].ToString();
            string? rftBugetSubCategorieActual = values[2].ToString();

            if (!decimal.TryParse(rftBugetNealocatActual, out decimal rftBugetNealocatActualCorect))
            {
                return true;
            }

            if (!decimal.TryParse(rftBugetSubCategorieTemporar, out decimal rftBugetSubCategorieTemporarCorect))
            {
                return true;
            }

            if (!decimal.TryParse(rftBugetSubCategorieActual, out decimal rftBugetSubCategorieActualCorect))
            {
                return true;
            }

            if (rftBugetSubCategorieTemporarCorect > RftGeneral.RftBugetMaxim)
            {
                return true;
            }

            if (rftBugetSubCategorieTemporarCorect < -RftGeneral.RftBugetMaxim)
            {
                return true;
            }

            if (rftBugetSubCategorieTemporarCorect > rftBugetNealocatActualCorect)
            {
                return true;
            }

            if (rftBugetSubCategorieTemporarCorect < 0 && rftBugetSubCategorieTemporarCorect - rftBugetNealocatActualCorect < -RftGeneral.RftBugetMaxim)
            {
                return true;
            }

            if (rftBugetSubCategorieTemporarCorect < 0 && rftBugetSubCategorieActualCorect + rftBugetSubCategorieTemporarCorect < 0)
            {
                return true;
            }

            if (rftBugetSubCategorieTemporarCorect + rftBugetSubCategorieActualCorect > RftGeneral.RftBugetMaxim)
            {
                return true;
            }

            if (rftBugetSubCategorieTemporarCorect.ToString("0.00") != rftBugetSubCategorieTemporarCorect.ToString() &&
                rftBugetSubCategorieTemporarCorect.ToString("0.0") != rftBugetSubCategorieTemporarCorect.ToString() &&
                rftBugetSubCategorieTemporarCorect.ToString("0") != rftBugetSubCategorieTemporarCorect.ToString())
            {
                return true;
            }
            
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
