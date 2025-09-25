using PGERPBiblioteca.RftGeneral;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PGERP.RftConvertori
{
    /// <summary>
    ///     Convertor pentru a schimba proprietatea RftMesajEroare din vederi model
    /// </summary>
    public class RftConvertorBuget : IValueConverter
    {
        /// <summary>
        ///     Functia care este apelata in interfata xaml pentru a verifica
        /// daca sirul de caractere este de forma decimala
        /// </summary>
        /// <param name="value">Parametrul care stocheaza stringul din interfata xaml</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Colectare sir de caractere din caseta buget nealocat
            string? rftBugetNealocat = value as string;

            // Verificare daca valoarea din caseta pentru bugetul nealocat poate fi convertita in decimal
            if (!decimal.TryParse(rftBugetNealocat, out decimal rftBugetNealocatCorect))
            {
                // Daca nu atunci executia se opreste in acest punct si se returneaza eroare
                return true;
            }

            // Verificare daca valoarea din caseta pentru bugetul nealocat nu depaseste bugetul maxim admis
            if (rftBugetNealocatCorect > RftGeneral.RftBugetMaxim)
            {
                // Daca nu atunci executia se opreste in acest punct si se returneaza eroare
                return true;
            }

            // Verificare daca valoarea din caseta pentru bugetul nealocat nu este mai mica decat 0
            if (rftBugetNealocatCorect < 0)
            {
                // Daca nu atunci executia se opreste in acest punct si se returneaza eroare
                return true;
            }

            if (rftBugetNealocatCorect.ToString("0.00") != rftBugetNealocatCorect.ToString() &&
                rftBugetNealocatCorect.ToString("0.0") != rftBugetNealocatCorect.ToString() &&
                rftBugetNealocatCorect.ToString("0") != rftBugetNealocatCorect.ToString())
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
