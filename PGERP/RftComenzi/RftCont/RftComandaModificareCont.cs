using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleAutentificare;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftCont
{
    internal class RftComandaModificareCont : RftComandaBaza
    {
        private readonly RftVedereModelSetariCont rftVedereModelSetariCont;
        private readonly RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat;
        private readonly RftServiciuDeDateUtilizatori<RftModelUtilizatori> rftServiciuDeDateUtilizatori = new(new RftContextGeneratorModel());

        public RftComandaModificareCont(
            RftVedereModelSetariCont rftVedereModelSetariCont,
            RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat)
        {
            this.rftVedereModelSetariCont = rftVedereModelSetariCont;
            this.rftModelUtilizatorAutentificat = rftModelUtilizatorAutentificat;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelSetariCont.RftMesajStareModificareContSucces = "";
            if (rftVedereModelSetariCont.RftParola is null || rftVedereModelSetariCont.RftParola.Length == 0)
            {
                rftVedereModelSetariCont.RftMesajStareModificareCont = RftMesajePredefinite.RftCampParolaNecesar;
                return;
            }

            if (string.IsNullOrEmpty(rftVedereModelSetariCont.RftEmail))
            {
                rftVedereModelSetariCont.RftMesajStareModificareCont = RftMesajePredefinite.RftCampEmailNecesar;
                return;
            }

            if (!rftVedereModelSetariCont.RftEmail.Contains('@') || !rftVedereModelSetariCont.RftEmail.Contains(".com"))
            {
                rftVedereModelSetariCont.RftMesajStareModificareCont = RftMesajePredefinite.RftFormatEmailGresit;
                return;
            }

            if (string.IsNullOrEmpty(rftVedereModelSetariCont.RftNume))
            {
                rftVedereModelSetariCont.RftMesajStareModificareCont = RftMesajePredefinite.RftCampNumeNecesar;
            }

            if (string.IsNullOrEmpty(rftVedereModelSetariCont.RftPrenume))
            {
                rftVedereModelSetariCont.RftMesajStareModificareCont = RftMesajePredefinite.RftCampPrenumeNecesar;
            }

            byte[] x = Encoding.ASCII.GetBytes(rftVedereModelSetariCont.HandleSecureString(rftVedereModelSetariCont.RftParola));
            string rftParola = RftCriptareSha256(x);

            RftModelUtilizatori y = rftServiciuDeDateUtilizatori.RftReturnareUtilizatorAutentificat(rftModelUtilizatorAutentificat.RftUtilizator).Result;

            y.Nume = rftVedereModelSetariCont.RftNume;
            y.Prenume = rftVedereModelSetariCont.RftPrenume;
            y.Email = rftVedereModelSetariCont.RftEmail;
            y.Parola = rftParola;

            await rftServiciuDeDateUtilizatori.RftActualizareObiect(rftModelUtilizatorAutentificat.RftUtilizator, y);
            rftVedereModelSetariCont.RftMesajStareModificareContSucces = RftMesajePredefinite.RftModificareContSucces;
            rftVedereModelSetariCont.RftParola = new SecureString();
        }

        private static string RftCriptareSha256(byte[] x)
        {
            using SHA256 mySHA256 = SHA256.Create();
            byte[] hashValue = mySHA256.ComputeHash(x);
            string rftParolaCriptata = Encoding.ASCII.GetString(hashValue);
            return rftParolaCriptata;
        }
    }
}
