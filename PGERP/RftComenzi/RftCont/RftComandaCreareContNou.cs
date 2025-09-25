using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederi;
using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleAutentificare;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PGERP.RftComenzi.RftCont
{
    internal class RftComandaCreareContNou : RftComandaBaza
    {
        private readonly RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat = new();
        private readonly RftVedereModelAutentificareContNou rftVedereModelAutentificareContNou;
        private readonly RftServiciuDeDateUtilizatori<RftModelUtilizatori> rftServiciuDeDateUtilizatori = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateGeneric<RftModelUtilizatori> rftServiciuDeDateGeneric = new(new RftContextGeneratorModel());

        public RftComandaCreareContNou(RftVedereModelAutentificareContNou rftVedereModelAutentificareContNou)
        {
            this.rftVedereModelAutentificareContNou = rftVedereModelAutentificareContNou;
        }

        public override void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(rftVedereModelAutentificareContNou.RftUtilizator))
            {
                rftVedereModelAutentificareContNou.RftMesajStareCreareContNou = RftMesajePredefinite.RftCampUtilizatorNecesar;
            }
            else
            {
                if (rftServiciuDeDateUtilizatori.RftReturnareObiectUtilizator(rftVedereModelAutentificareContNou.RftUtilizator).Result)
                {
                    rftVedereModelAutentificareContNou.RftMesajStareCreareContNou = RftMesajePredefinite.RftUtilizatorUnic;
                }
                else
                {
                    if (rftVedereModelAutentificareContNou.RftParola is null)
                    {
                        rftVedereModelAutentificareContNou.RftMesajStareCreareContNou = RftMesajePredefinite.RftCampParolaNecesar;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(rftVedereModelAutentificareContNou.RftEmail))
                        {
                            rftVedereModelAutentificareContNou.RftMesajStareCreareContNou = RftMesajePredefinite.RftCampEmailNecesar;
                        }
                        else
                        {
                            if (!rftVedereModelAutentificareContNou.RftEmail.Contains('@') || !rftVedereModelAutentificareContNou.RftEmail.EndsWith(".com"))
                            {
                                rftVedereModelAutentificareContNou.RftMesajStareCreareContNou = RftMesajePredefinite.RftFormatEmailGresit;
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(rftVedereModelAutentificareContNou.RftNume))
                                {
                                    rftVedereModelAutentificareContNou.RftMesajStareCreareContNou = RftMesajePredefinite.RftCampNumeNecesar;
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(rftVedereModelAutentificareContNou.RftPrenume))
                                    {
                                        rftVedereModelAutentificareContNou.RftMesajStareCreareContNou = RftMesajePredefinite.RftCampPrenumeNecesar;
                                    }
                                    else
                                    {
                                        byte[] x = Encoding.ASCII.GetBytes(rftVedereModelAutentificareContNou.HandleSecureString(rftVedereModelAutentificareContNou.RftParola));
                                        string rftParola = RftCriptareSha256(x);


                                        _ = rftServiciuDeDateGeneric.RftAdaugareObiect(new RftModelUtilizatori
                                        {
                                            DataInregistrare = DateTime.Now,
                                            Utilizator = rftVedereModelAutentificareContNou.RftUtilizator,
                                            Parola = rftParola,
                                            Prenume = rftVedereModelAutentificareContNou.RftPrenume,
                                            Nume = rftVedereModelAutentificareContNou.RftNume,
                                            Email = rftVedereModelAutentificareContNou.RftEmail
                                        });
                                        rftModelUtilizatorAutentificat.RftUtilizator = rftVedereModelAutentificareContNou.RftUtilizator;

                                        Window window = new RftFereastraPrincipala
                                        {
                                            DataContext = new RftVedereModelFereastraPrincipala(rftModelUtilizatorAutentificat)
                                        };
                                        Application.Current.MainWindow.Close();

                                        _ = Application.Current.MainWindow = window;
                                        Application.Current.MainWindow.Show();
                                    }
                                }
                            }
                        }
                    }
                }
            }
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
