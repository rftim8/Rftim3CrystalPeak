using PGERP.RftComenzi.RftAccesareVederi;
using PGERP.RftComenzi.RftCont;
using PGERP.RftModele;
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
    internal class RftVedereModelSetariCont : RftVedereModelBaza
    {
        private string? rftNume;

        public string RftNume
        {
            get
            {
                if (!string.IsNullOrEmpty(rftNume))
                {
                    return rftNume;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                rftNume = value;
                RftSchimbareProprietate(nameof(RftNume));
            }
        }

        private string? rftPrenume;

        public string RftPrenume
        {
            get
            {
                if (!string.IsNullOrEmpty(rftPrenume))
                {
                    return rftPrenume;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                rftPrenume = value;
                RftSchimbareProprietate(nameof(RftPrenume));
            }
        }

        private string? rftEmail;

        public string RftEmail
        {
            get
            {
                if (!string.IsNullOrEmpty(rftEmail))
                {
                    return rftEmail;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                rftEmail = value;
                RftSchimbareProprietate(nameof(RftEmail));
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

        private string? rftMesajStareModificareCont;

        public string? RftMesajStareModificareCont
        {
            get
            {
                return rftMesajStareModificareCont;
            }
            set
            {
                rftMesajStareModificareCont = value;
                RftSchimbareProprietate(nameof(RftMesajStareModificareCont));
            }
        }
        
        private string? rftMesajStareModificareContSucces;

        public string? RftMesajStareModificareContSucces
        {
            get
            {
                return rftMesajStareModificareContSucces;
            }
            set
            {
                rftMesajStareModificareContSucces = value;
                RftSchimbareProprietate(nameof(RftMesajStareModificareContSucces));
            }
        }

        public ICommand RftComandaAccesareVedereContinut { get; }
        public ICommand RftComandaStergereCont { get; }
        public ICommand RftComandaModificareCont { get; }

        public RftVedereModelSetariCont(RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala, 
            RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat)
        {
            RftComandaAccesareVedereContinut = new RftComandaAccesareVedereContinut(rftVedereModelFereastraPrincipala);
            RftComandaStergereCont = new RftComandaStergereCont(rftModelUtilizatorAutentificat);
            RftComandaModificareCont = new RftComandaModificareCont(this, rftModelUtilizatorAutentificat);
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
                return RftMesajStareModificareCont = x.ToString();
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}
