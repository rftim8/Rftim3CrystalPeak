using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederi;
using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleAutentificare;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows;

namespace PGERP.RftComenzi.RftCont
{
    internal class RftComandaAutentificare : RftComandaBaza
    {
        private readonly RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat = new();
        private readonly RftVedereModelAutentificarePrincipal rftVedereModelAutentificarePrincipal;
        private readonly RftServiciuDeDateUtilizatori<RftModelUtilizatori> rftServiciuDeDateUtilizatori = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateAutentificari<RftModelAutentificari> rftServiciuDeDateAutentificari = new(new RftContextGeneratorModel());

        public RftComandaAutentificare(RftVedereModelAutentificarePrincipal rftVedereModelAutentificarePrincipal)
        {
            this.rftVedereModelAutentificarePrincipal = rftVedereModelAutentificarePrincipal;
        }

        public override void Execute(object? parameter)
        {
            bool RftAutentificareEsuata = false;

            if (rftVedereModelAutentificarePrincipal.RftParola != null)
            {
                if (!string.IsNullOrEmpty(rftVedereModelAutentificarePrincipal.HandleSecureString(rftVedereModelAutentificarePrincipal.RftParola)) &&
                    !string.IsNullOrEmpty(rftVedereModelAutentificarePrincipal.RftUtilizator))
                {
                    if (!rftVedereModelAutentificarePrincipal.HandleSecureString(rftVedereModelAutentificarePrincipal.RftParola).Contains(' '))
                    {
                        byte[] x = Encoding.ASCII.GetBytes(rftVedereModelAutentificarePrincipal.HandleSecureString(rftVedereModelAutentificarePrincipal.RftParola));
                        string rftParola = RftCriptareSha256(x);

                        bool rftAutentificareCorecta = rftServiciuDeDateUtilizatori.RftReturnareObiectUtilizator(
                            rftVedereModelAutentificarePrincipal.RftUtilizator,
                            rftParola
                            ).Result;

                        if (rftAutentificareCorecta)
                        {
                            RftInregistrareAutentificare(rftAutentificareCorecta);
                            rftVedereModelAutentificarePrincipal.RftMesajStareAutentificare = "";
                            rftModelUtilizatorAutentificat.RftUtilizator = rftVedereModelAutentificarePrincipal.RftUtilizator;

                            Window window = new RftFereastraPrincipala
                            {
                                DataContext = new RftVedereModelFereastraPrincipala(rftModelUtilizatorAutentificat)
                            };
                            Application.Current.MainWindow.Close();

                            _ = Application.Current.MainWindow = window;
                            Application.Current.MainWindow.Show();
                        }
                        else
                        {
                            RftAutentificareEsuata = true;
                            rftVedereModelAutentificarePrincipal.RftMesajStareAutentificare = RftMesajePredefinite.RftCredentialeGresite;
                        }
                    }
                    else
                    {
                        RftAutentificareEsuata = true;
                        rftVedereModelAutentificarePrincipal.RftMesajStareAutentificare = RftMesajePredefinite.RftCredentialeCaractereIlegale;
                    }
                }
                else
                {
                    RftAutentificareEsuata = true;
                    rftVedereModelAutentificarePrincipal.RftMesajStareAutentificare = RftMesajePredefinite.RftCredentialeIncomplete;
                }
            }
            else
            {
                RftAutentificareEsuata = true;
                rftVedereModelAutentificarePrincipal.RftMesajStareAutentificare = RftMesajePredefinite.RftCredentialeIncomplete;
            }

            if (RftAutentificareEsuata)
            {
                RftInregistrareAutentificare(!RftAutentificareEsuata);
            }
        }

        private static string RftCriptareSha256(byte[] x)
        {
            using SHA256 mySHA256 = SHA256.Create();
            byte[] hashValue = mySHA256.ComputeHash(x);
            string rftParolaCriptata = Encoding.ASCII.GetString(hashValue);
            return rftParolaCriptata;
        }

        private void RftInregistrareAutentificare(bool rftAutentificareCorecta)
        {
            _ = rftServiciuDeDateAutentificari.RftAdaugareObiect(new RftModelAutentificari
            {
                DataAutentificare = DateTime.Now,
                Utilizator = rftVedereModelAutentificarePrincipal.RftUtilizator,
                IP = IPAddress.Loopback.ToString(),
                DNS = Dns.GetHostName(),
                Stare = rftAutentificareCorecta
            });

        }
    }
}
