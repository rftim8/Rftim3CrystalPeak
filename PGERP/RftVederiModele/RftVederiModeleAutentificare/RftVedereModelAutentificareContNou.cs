using PGERP.RftComenzi;
using PGERP.RftComenzi.RftAccesareVederi;
using PGERP.RftComenzi.RftCont;
using PGERP.RftComenzi.RftDocumentatii;
using PGERP.RftComenzi.RftUtilitare;
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
    internal class RftVedereModelAutentificareContNou : RftVedereModelBaza
    {
        private string? rftPrenume;

        public string? RftPrenume
        {
            get
            {
                return rftPrenume;
            }
            set
            {
                rftPrenume = value;
                RftSchimbareProprietate(nameof(RftPrenume));
            }
        }

        private string? rftNume;

        public string? RftNume
        {
            get
            {
                return rftNume;
            }
            set
            {
                rftNume = value;
                RftSchimbareProprietate(nameof(RftNume));
            }
        }

        private string? rftEmail;

        public string? RftEmail
        {
            get
            {
                return rftEmail;
            }
            set
            {
                rftEmail = value;
                RftSchimbareProprietate(nameof(RftEmail));
            }
        }

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

        private string? rftMesajStareCreareContNou;

        public string? RftMesajStareCreareContNou
        {
            get
            {
                return rftMesajStareCreareContNou;
            }
            set
            {
                rftMesajStareCreareContNou = value;
                RftSchimbareProprietate(nameof(RftMesajStareCreareContNou));
            }
        }

        private readonly string rftVersiuneProgram = $"v{Assembly.GetExecutingAssembly().GetName().Version}";

        public string? RftVerisuneProgram
        {
            get { return rftVersiuneProgram; }
            set { }
        }

        public ICommand RftComandaCreareContNou { get; }
        public ICommand RftComandaDocumentatieContNou { get; }
        public ICommand RftComandaAccesareVedereAutentificare { get; }
        public ICommand RftComandaMinimizareFereastra { get; }
        public ICommand RftComandaIesireProgram { get; }

        #region Setare Mesaje Utilitare
        private readonly string rftMesajContNou = RftMesajePredefinite.RftDocumentatie;

        public string RftMesajContNou
        {
            get { return rftMesajContNou; }
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

        public RftVedereModelAutentificareContNou(RftVedereModelFereastraAutentificare rftVedereModelFereastraAutentificare)
        {
            RftComandaCreareContNou = new RftComandaCreareContNou(this);
            RftComandaAccesareVedereAutentificare = new RftComandaAccesareVedereAutentificare(rftVedereModelFereastraAutentificare);
            RftComandaDocumentatieContNou = new RftComandaDocumentatieContNou();
            RftComandaMinimizareFereastra = new RftComandaMinimizareFereastra();
            RftComandaIesireProgram = new RftComandaIesireProgram();
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
                return RftMesajStareCreareContNou = x.ToString();
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
