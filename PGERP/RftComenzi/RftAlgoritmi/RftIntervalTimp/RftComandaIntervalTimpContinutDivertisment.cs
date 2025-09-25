using PGERP.RftModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERPBiblioteca.RftGeneral;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAlgoritmi.RftTopPret
{
    internal class RftComandaIntervalTimpContinutDivertisment : RftComandaBaza
    {
        private readonly RftVedereModelContinutDivertisment rftVedereModelContinutDivertisment;
        private readonly int TipInterval;

        public RftComandaIntervalTimpContinutDivertisment(RftVedereModelContinutDivertisment rftVedereModelContinutDivertisment, int tipInterval)
        {
            this.rftVedereModelContinutDivertisment = rftVedereModelContinutDivertisment;
            TipInterval = tipInterval;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutDivertisment.RftStergereDate();
            rftVedereModelContinutDivertisment.RftColectareDate();

            List<RftModelTranzactieGeneralTabela>? z = rftVedereModelContinutDivertisment.RftModelTranzactieGeneralTabelaLista.ToList();
            rftVedereModelContinutDivertisment.RftModelTranzactieGeneralTabelaLista.Clear();

            switch (TipInterval)
            {
                // 24 ore
                case 0:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in ultimele 24 ore: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 7 zile
                case 1:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-7)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in ultimele 7 zile: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 luna
                case 2:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in aceasta luna: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 an
                case 3:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in acest an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 1
                case 4:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1) && o.Data < new DateTime(DateTime.Now.Year, 4, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in sfertul 1 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 2
                case 5:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 4, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in sfertul 2 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in sfertul 2 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 3
                case 6:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 7, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in sfertul 3 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in sfertul 3 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 4
                case 7:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 10, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in sfertul 4 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1).AddYears(1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutDivertisment.RftGraficTitlu = $"Suma totala in sfertul 4 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                default:
                    break;
            }

            foreach (RftModelTranzactieGeneralTabela? item in z)
            {
                rftVedereModelContinutDivertisment.RftModelTranzactieGeneralTabelaLista.Add(item);
            }

            rftVedereModelContinutDivertisment.RftLinieFilme.Clear();
            rftVedereModelContinutDivertisment.RftLinieJocuri.Clear();
            rftVedereModelContinutDivertisment.RftLinieMuzica.Clear();

            ObservableCollection<RftModelTranzactieGeneralGrafic> x = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x1 = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x2 = new();

            foreach (RftModelTranzactieGeneralTabela? item in z)
            {
                switch (item.SubCategorie)
                {
                    case RftGeneral.RftFilme:
                        x.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftFilme, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftJocuri:
                        x1.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftJocuri, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftMuzica:
                        x2.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftMuzica, Data = item.Data, Pret = item.Pret });
                        break;
                    default:
                        break;
                }
            }

            _ = x.OrderBy(o => o.Data);
            _ = x1.OrderBy(o => o.Data);
            _ = x2.OrderBy(o => o.Data);

            foreach (RftModelTranzactieGeneralGrafic? item in x)
            {
                rftVedereModelContinutDivertisment.RftLinieFilme.Add(item);
            }
            if (rftVedereModelContinutDivertisment.RftLinieFilme.Count != 0)
            {
                rftVedereModelContinutDivertisment.RftLinieFilme.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftFilme, Data = DateTime.Now, Pret = x.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x1)
            {
                rftVedereModelContinutDivertisment.RftLinieJocuri.Add(item);
            }
            if (rftVedereModelContinutDivertisment.RftLinieJocuri.Count != 0)
            {
                rftVedereModelContinutDivertisment.RftLinieJocuri.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftJocuri, Data = DateTime.Now, Pret = x1.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x2)
            {
                rftVedereModelContinutDivertisment.RftLinieMuzica.Add(item);
            }
            if (rftVedereModelContinutDivertisment.RftLinieMuzica.Count != 0)
            {
                rftVedereModelContinutDivertisment.RftLinieMuzica.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftMuzica, Data = DateTime.Now, Pret = x2.OrderByDescending(o => o.Data).First().Pret });
            }

            if (z.Count > 0)
            {
                rftVedereModelContinutDivertisment.RftBuget = z.Max(o => o.Pret);
            }
        }
    }
}
