using PGERP.RftComenzi;
using PGERP.RftComenzi.RftAccesareVederi;
using PGERP.RftComenzi.RftCont;
using PGERP.RftComenzi.RftDocumentatii;
using PGERP.RftComenzi.RftUtilitare;
using PGERP.RftModele;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PGERP.RftVederiModele.RftVederiModeleAutentificare
{
    internal class RftVedereModelAutentificarePrincipal : RftVedereModelBaza
    {
        private string? rftUtilizator;

        public string? RftUtilizator
        {
            get
            {
                return rftUtilizator;
            }
            set
            {
                rftUtilizator = value;
                RftSchimbareProprietate(nameof(RftUtilizator));
            }
        }

        private SecureString? rftParola;

        public SecureString? RftParola
        {
            get
            {
                return rftParola;
            }
            set
            {
                rftParola = value;
                RftSchimbareProprietate(nameof(RftParola));
            }
        }

        private string? rftMesajStareAutentificare;

        public string? RftMesajStareAutentificare
        {
            get
            {
                return rftMesajStareAutentificare;
            }
            set
            {
                rftMesajStareAutentificare = value;
                RftSchimbareProprietate(nameof(RftMesajStareAutentificare));
            }
        }


        private readonly string rftVersiuneProgram = $"v{Assembly.GetExecutingAssembly().GetName().Version}";

        public string? RftVerisuneProgram
        {
            get { return rftVersiuneProgram; }
            set { }
        }

        /// <summary>
        ///     Proprietate de tip ICommand setata doar pentru apelare comanda
        ///     Comanda este legata de un buton din interfata grafica xaml
        /// </summary>
        public ICommand RftComandaAccesareVedereContNou { get; }
        public ICommand RftComandaDocumentatieAutentificare { get; }
        public ICommand RftComandaMinimizareFereastra { get; }
        public ICommand RftComandaIesireProgram { get; }
        public ICommand RftComandaAutentificare { get; }

        #region Setare Mesaje Utilitare
        private readonly string rftMesajDocumentatie = RftMesajePredefinite.RftDocumentatie;

        public string RftMesajDocumentatie
        {
            get { return rftMesajDocumentatie; }
            set { }
        }

        private readonly string rftMesajMinimizare = RftMesajePredefinite.RftMinimizare;

        public string RftMesajMinimizare
        {
            get { return rftMesajMinimizare; }
            set { }
        }

        private readonly string rftMesajIesire = RftMesajePredefinite.RftIesire;

        public string RftMesajIesire
        {
            get { return rftMesajIesire; }
            set { }
        }
        #endregion

        public RftVedereModelAutentificarePrincipal(RftVedereModelFereastraAutentificare rftVedereModelFereastraAutentificare)
        {
            RftComandaAccesareVedereContNou = new RftComandaAccesareVedereContNou(rftVedereModelFereastraAutentificare);
            RftComandaDocumentatieAutentificare = new RftComandaDocumentatieAutentificare();
            RftComandaMinimizareFereastra = new RftComandaMinimizareFereastra();
            RftComandaIesireProgram = new RftComandaIesireProgram();
            RftComandaAutentificare = new RftComandaAutentificare(this);
        }

        public string HandleSecureString(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                string? x = Marshal.PtrToStringUni(valuePtr);

                if (x is not null)
                {
                    return x;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception x)
            {
                return RftMesajStareAutentificare = x.ToString();
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
