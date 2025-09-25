using PGERP.RftComenzi;
using PGERP.RftModele;
using PGERP.RftVederiModele.RftVederiModeleAutentificare;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PGERP.RftVederiModele
{
    /// <summary>
    ///     Clasa de tip vedere model care mosteneste clasa RftVedereModelBaza care la randul ei 
    /// mosteneste interfata de notificare a schimbarii unei proprietati
    ///     Vedere model care este legat de vederea RftFereastraAutentificare
    /// </summary>
    internal class RftVedereModelFereastraAutentificare : RftVedereModelBaza
    {
        /// <summary>
        ///     Camp pentru stocarea referintei catre proprietatea de tip RftVedereModelBaza
        /// </summary>
        private RftVedereModelBaza? rftVedereModelAutentificareCurent;
        public RftVedereModelBaza RftVedereModelAutentificareCurent
        {
            get
            {
                // Verificare pentru existenta unei vederi model
                if (rftVedereModelAutentificareCurent is not null)
                {
                    return rftVedereModelAutentificareCurent;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                rftVedereModelAutentificareCurent = value;
                //  Daca vederea se schimba atunci functia apeleaza interfata de notificare cu parametrul
                // setat pe vederea nou
                RftSchimbareProprietate(nameof(RftVedereModelAutentificareCurent));
            }
        }

        /// <summary>
        ///     Constructorul ferestrei
        /// </summary>
        public RftVedereModelFereastraAutentificare()
        {
            //  Setarea vederii model initiala pentru a putea apela notificarea de schimbare,
            // rezultand in afisarea vederii de autentificare principala
            RftVedereModelAutentificareCurent = new RftVedereModelAutentificarePrincipal(this);
        }
    }
}
