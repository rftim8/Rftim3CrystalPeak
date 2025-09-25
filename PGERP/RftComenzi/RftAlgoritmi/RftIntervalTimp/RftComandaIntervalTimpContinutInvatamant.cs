using PGERP.RftModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERPBiblioteca.RftGeneral;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAlgoritmi.RftTopPret
{
    internal class RftComandaIntervalTimpContinutInvatamant : RftComandaBaza
    {
        private readonly RftVedereModelContinutInvatamant rftVedereModelContinutInvatamant;
        private readonly int TipInterval;

        public RftComandaIntervalTimpContinutInvatamant(RftVedereModelContinutInvatamant rftVedereModelContinutInvatamant, int tipInterval)
        {
            this.rftVedereModelContinutInvatamant = rftVedereModelContinutInvatamant;
            TipInterval = tipInterval;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelContinutInvatamant.RftStergereDate();
            rftVedereModelContinutInvatamant.RftColectareDate();

            List<RftModelEducatieInvatamant>? z = rftVedereModelContinutInvatamant.RftModelEducatieInvatamantLista.ToList();
            rftVedereModelContinutInvatamant.RftModelEducatieInvatamantLista.Clear();

            switch (TipInterval)
            {
                // 24 ore
                case 0:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in ultimele 24 ore: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 7 zile
                case 1:
                    z = z.Where(o => o.Data >= DateTime.Now.AddDays(-7)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in ultimele 7 zile: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 luna
                case 2:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in aceasta luna: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // 1 an
                case 3:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in acest an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 1
                case 4:
                    z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 1, 1) && o.Data < new DateTime(DateTime.Now.Year, 4, 1)).OrderBy(o => o.Data).ToList();
                    rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in sfertul 1 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    break;
                // Sfert 2
                case 5:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 4, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in sfertul 2 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 4, 1) && o.Data < new DateTime(DateTime.Now.Year, 7, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in sfertul 2 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 3
                case 6:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 7, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in sfertul 3 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 7, 1) && o.Data < new DateTime(DateTime.Now.Year, 10, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in sfertul 3 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                // Sfert 4
                case 7:
                    if (DateTime.Now < new DateTime(DateTime.Now.Year, 10, 1))
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1).AddYears(-1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in sfertul 4 al anului trecut: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    else
                    {
                        z = z.Where(o => o.Data >= new DateTime(DateTime.Now.Year, 10, 1) && o.Data < new DateTime(DateTime.Now.Year, 1, 1).AddYears(1)).OrderBy(o => o.Data).ToList();
                        rftVedereModelContinutInvatamant.RftGraficTitlu = $"Suma totala in sfertul 4 al acestui an: {z.Sum(o => o.Pret)} {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}";
                    }
                    break;
                default:
                    break;
            }

            foreach (RftModelEducatieInvatamant? item in z)
            {
                rftVedereModelContinutInvatamant.RftModelEducatieInvatamantLista.Add(item);
            }

            rftVedereModelContinutInvatamant.RftLinieInvatamant.Clear();

            foreach (RftModelEducatieInvatamant? item in z)
            {
                rftVedereModelContinutInvatamant.RftLinieInvatamant.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftInvatamant, Data = item.Data, Pret = item.Pret });
            }
            if (rftVedereModelContinutInvatamant.RftLinieInvatamant.Count != 0)
            {
                rftVedereModelContinutInvatamant.RftLinieInvatamant.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftInvatamant, Data = DateTime.Now, Pret = z.OrderByDescending(o => o.Data).First().Pret });
            }

            if (z.Count > 0)
            {
                rftVedereModelContinutInvatamant.RftBuget = z.Max(o => o.Pret);
            }
        }
    }
}
