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
    internal class RftComandaIntervalTimpContinutFacturi : RftComandaBaza
    {
        private readonly RftVedereModelContinutFacturi rftVedereModelContinutFacturi;
        private readonly int TipInterval;

        public RftComandaIntervalTimpContinutFacturi(RftVedereModelContinutFacturi rftVedereModelContinutFacturi, int tipInterval)
        {
            this.rftVedereModelContinutFacturi = rftVedereModelContinutFacturi;
            TipInterval = tipInterval;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutFacturi.RftStergereDate();
            rftVedereModelContinutFacturi.RftColectareDate();

            List<RftModelTranzactieGeneralTabela>? z = rftVedereModelContinutFacturi.RftModelTranzactieGeneralTabelaLista.ToList();
            rftVedereModelContinutFacturi.RftModelTranzactieGeneralTabelaLista.Clear();

            switch (TipInterval)
            {
                // 24 ore
                case 0:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in ultimele 24 ore: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 7 zile
                case 1:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-7)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in ultimele 7 zile: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 luna
                case 2:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in aceasta luna: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 an
                case 3:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in acest an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 1
                case 4:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1) && o.Data < new DateTime(DateTime.Now.Year, 4, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in sfertul 1 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 2
                case 5:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 4, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in sfertul 2 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in sfertul 2 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 3
                case 6:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 7, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in sfertul 3 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in sfertul 3 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 4
                case 7:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 10, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in sfertul 4 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1).AddYears(1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutFacturi.RftGraficTitlu = $"Suma totala in sfertul 4 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                default:
                    break;
            }

            foreach (RftModelTranzactieGeneralTabela? item in z)
            {
                rftVedereModelContinutFacturi.RftModelTranzactieGeneralTabelaLista.Add(item);
            }

            rftVedereModelContinutFacturi.RftLinieApa.Clear();
            rftVedereModelContinutFacturi.RftLinieCurent.Clear();
            rftVedereModelContinutFacturi.RftLinieTelefonie.Clear();

            ObservableCollection<RftModelTranzactieGeneralGrafic> x = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x1 = new();
            ObservableCollection<RftModelTranzactieGeneralGrafic> x2 = new();

            foreach (RftModelTranzactieGeneralTabela? item in z)
            {
                switch (item.SubCategorie)
                {
                    case RftGeneral.RftApa:
                        x.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftApa, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftCurent:
                        x1.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftCurent, Data = item.Data, Pret = item.Pret });
                        break;
                    case RftGeneral.RftTelefonie:
                        x2.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftTelefonie, Data = item.Data, Pret = item.Pret });
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
                rftVedereModelContinutFacturi.RftLinieApa.Add(item);
            }
            if (rftVedereModelContinutFacturi.RftLinieApa.Count != 0)
            {
                rftVedereModelContinutFacturi.RftLinieApa.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftApa, Data = DateTime.Now, Pret = x.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x1)
            {
                rftVedereModelContinutFacturi.RftLinieCurent.Add(item);
            }
            if (rftVedereModelContinutFacturi.RftLinieCurent.Count != 0)
            {
                rftVedereModelContinutFacturi.RftLinieCurent.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftCurent, Data = DateTime.Now, Pret = x1.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTranzactieGeneralGrafic? item in x2)
            {
                rftVedereModelContinutFacturi.RftLinieTelefonie.Add(item);
            }
            if (rftVedereModelContinutFacturi.RftLinieTelefonie.Count != 0)
            {
                rftVedereModelContinutFacturi.RftLinieTelefonie.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftTelefonie, Data = DateTime.Now, Pret = x2.OrderByDescending(o => o.Data).First().Pret });
            }

            if (z.Count > 0)
            {
                rftVedereModelContinutFacturi.RftBuget = z.Max(o => o.Pret);
            }
        }
    }
}
