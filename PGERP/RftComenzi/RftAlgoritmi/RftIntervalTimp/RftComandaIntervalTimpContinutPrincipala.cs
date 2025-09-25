using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele;
using PGERPBiblioteca.RftGeneral;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PGERP.RftComenzi.RftAlgoritmi.RftTopPret
{
    internal class RftComandaIntervalTimpContinutPrincipala : RftComandaBaza
    {
        private readonly RftVedereModelContinutPrincipala rftVedereModelContinutPrincipala;
        private readonly int TipInterval;

        public RftComandaIntervalTimpContinutPrincipala(RftVedereModelContinutPrincipala rftVedereModelContinutPrincipala, int tipInterval)
        {
            this.rftVedereModelContinutPrincipala = rftVedereModelContinutPrincipala;
            TipInterval = tipInterval;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutPrincipala.RftStergereDate();
            rftVedereModelContinutPrincipala.RftColectareDate();

            List<RftModelTranzactieGeneralTabela>? z = rftVedereModelContinutPrincipala.RftModelTranzactieGeneralTabelaLista.ToList();
            rftVedereModelContinutPrincipala.RftModelTranzactieGeneralTabelaLista.Clear();

            switch (TipInterval)
            {
                // 24 ore
                case 0:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in ultimele 24 ore: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 7 zile
                case 1:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-7)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in ultimele 7 zile: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 luna
                case 2:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in aceasta luna: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 an
                case 3:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in acest an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 1
                case 4:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1) && o.Data < new DateTime(DateTime.Now.Year, 4, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in sfertul 1 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 2
                case 5:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 4, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in sfertul 2 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in sfertul 2 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 3
                case 6:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 7, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in sfertul 3 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in sfertul 3 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 4
                case 7:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 10, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in sfertul 4 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1).AddYears(1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutPrincipala.RftGraficTitlu = $"Suma totala in sfertul 4 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                default:
                    break;
            }

            foreach (RftModelTranzactieGeneralTabela? item in z)
            {
                rftVedereModelContinutPrincipala.RftModelTranzactieGeneralTabelaLista.Add(item);
            }

            #region Grafic
            rftVedereModelContinutPrincipala.RftLinieCumparaturi.Clear();
            rftVedereModelContinutPrincipala.RftLinieDivertisment.Clear();
            rftVedereModelContinutPrincipala.RftLinieEducatie.Clear();
            rftVedereModelContinutPrincipala.RftLinieFacturi.Clear();
            rftVedereModelContinutPrincipala.RftLinieSanatate.Clear();
            rftVedereModelContinutPrincipala.RftLinieTransport.Clear();

            ObservableCollection<RftModelTranzactieGeneralGrafic> x = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x1 = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x2 = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x3 = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x4 = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x5 = new();

            foreach (RftModelTranzactieGeneralTabela? item in z)
            {
                switch (item.Categorie)
                {
                    case RftGeneral.RftCumparaturi:
                        x.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftDivertisment:
                        x1.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftEducatie:
                        x2.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftFacturi:
                        x3.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftSanatate:
                        x4.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftSanatate, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftTransport:
                        x5.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftTransport, Data = item.Data, Pret = item.Pret });
                        break;
                    default:
                        break;
                }
            }

            _ = x.OrderBy(o => o.Data);
            _ = x1.OrderBy(o => o.Data);
            _ = x2.OrderBy(o => o.Data);
            _ = x3.OrderBy(o => o.Data);
            _ = x4.OrderBy(o => o.Data);
            _ = x5.OrderBy(o => o.Data);

            foreach (RftModelTranzactieGeneralGrafic? item in x)
            {
                rftVedereModelContinutPrincipala.RftLinieCumparaturi.Add(item);
            }
            if (rftVedereModelContinutPrincipala.RftLinieCumparaturi.Count != 0)
            {
                rftVedereModelContinutPrincipala.RftLinieCumparaturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, Data = DateTime.Now, Pret = x.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x1)
            {
                rftVedereModelContinutPrincipala.RftLinieDivertisment.Add(item);
            }
            if (rftVedereModelContinutPrincipala.RftLinieDivertisment.Count != 0)
            {
                rftVedereModelContinutPrincipala.RftLinieDivertisment.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, Data = DateTime.Now, Pret = x1.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x2)
            {
                rftVedereModelContinutPrincipala.RftLinieEducatie.Add(item);
            }
            if (rftVedereModelContinutPrincipala.RftLinieEducatie.Count != 0)
            {
                rftVedereModelContinutPrincipala.RftLinieEducatie.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, Data = DateTime.Now, Pret = x2.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x3)
            {
                rftVedereModelContinutPrincipala.RftLinieFacturi.Add(item);
            }
            if (rftVedereModelContinutPrincipala.RftLinieFacturi.Count != 0)
            {
                rftVedereModelContinutPrincipala.RftLinieFacturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, Data = DateTime.Now, Pret = x3.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x4)
            {
                rftVedereModelContinutPrincipala.RftLinieSanatate.Add(item);
            }
            if (rftVedereModelContinutPrincipala.RftLinieSanatate.Count != 0)
            {
                rftVedereModelContinutPrincipala.RftLinieSanatate.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftSanatate, Data = DateTime.Now, Pret = x4.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x5)
            {
                rftVedereModelContinutPrincipala.RftLinieTransport.Add(item);
            }
            if (rftVedereModelContinutPrincipala.RftLinieTransport.Count != 0)
            {
                rftVedereModelContinutPrincipala.RftLinieTransport.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftTransport, Data = DateTime.Now, Pret = x5.OrderByDescending(o => o.Data).First().Pret });
            }

            if (z.Count > 0)
            {
                rftVedereModelContinutPrincipala.RftBuget = z.Max(o => o.Pret);
            }
            #endregion
        }
    }
}