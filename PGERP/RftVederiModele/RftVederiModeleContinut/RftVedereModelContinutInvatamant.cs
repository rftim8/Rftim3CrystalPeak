using PGERP.RftComenzi;
using PGERP.RftComenzi.RftAlgoritmi;
using PGERP.RftComenzi.RftAlgoritmi.RftTopPret;
using PGERP.RftComenzi.RftExportCSV;
using PGERP.RftComenzi.RftExportExcel;
using PGERP.RftComenzi.RftExportPDF;
using PGERP.RftComenzi.RftTabela.RftReinitializare;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERPBiblioteca.RftGeneral;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PGERP.RftVederiModele.RftVederiModeleContinut
{
    internal class RftVedereModelContinutInvatamant : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelEducatieInvatamant> rftModelEducatieInvatamantLista = new();
        public ObservableCollection<RftModelEducatieInvatamant> RftModelEducatieInvatamantLista
        {
            get => rftModelEducatieInvatamantLista;
            set
            {
                rftModelEducatieInvatamantLista = value;
                RftSchimbareProprietate(nameof(RftModelEducatieInvatamantLista));
            }
        }

        private ICollectionView? rftTranzactiiFiltrate;

        public ICollectionView? RftTranzactiiFiltrate
        {
            get { return rftTranzactiiFiltrate; }
            set { rftTranzactiiFiltrate = value; }
        }

        private string? rftFiltruTranzactii = string.Empty;

        public string? RftFiltruTranzactii
        {
            get { return rftFiltruTranzactii; }
            set
            {
                rftFiltruTranzactii = value;
                RftSchimbareProprietate(nameof(RftFiltruTranzactii));
                RftTranzactiiFiltrate.Refresh();
            }
        }
        #endregion

        #region Colectare Date Tabela si Grafic
        private readonly RftServiciuDeDateEducatieInvatamant<RftModelEducatieInvatamant> rftServiciuDeDateInvatamant = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieInvatamant = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieInvatamant
        {
            get
            {
                if (rftLinieInvatamant is not null)
                {
                    return rftLinieInvatamant;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieInvatamant = value;
                RftSchimbareProprietate(nameof(RftLinieInvatamant));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Invatamant";

        public string RftGraficTitlu
        {
            get
            {
                if (rftGraficTitlu is not null)
                {
                    return rftGraficTitlu;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                rftGraficTitlu = value;
                RftSchimbareProprietate(nameof(RftGraficTitlu));
            }
        }
        #endregion

        #region Mesaje Predefinite
        private readonly string? rftMesajExportPDF = RftMesajePredefinite.RftExportPDF;

        public string? RftMesajExportPDF
        {
            get { return rftMesajExportPDF; }
            set { }
        }
        private readonly string? rftMesajExportExcel = RftMesajePredefinite.RftExportExcel;

        public string? RftMesajExportExcel
        {
            get { return rftMesajExportExcel; }
            set { }
        }
        private readonly string? rftMesajExportCSV = RftMesajePredefinite.RftExportCSV;

        public string? RftMesajExportCSV
        {
            get { return rftMesajExportCSV; }
            set { }
        }
        private readonly string? rftMesajExportImagine = RftMesajePredefinite.RftExportImagine;

        public string? RftMesajExportImagine
        {
            get { return rftMesajExportImagine; }
            set { }
        }

        private readonly string? rftMesajReinitializareTabela = RftMesajePredefinite.RftReinitializareTabela;

        public string? RftMesajReinitializareTabela
        {
            get { return rftMesajReinitializareTabela; }
            set { }
        }
        #endregion

        private decimal rftBuget;

        public decimal RftBuget
        {
            get { return rftBuget; }
            set
            {
                rftBuget = value;
                RftSchimbareProprietate(nameof(RftBuget));
            }
        }

        public ICommand RftComandaIntervalTimp24ore { get; }
        public ICommand RftComandaIntervalTimp7zile { get; }
        public ICommand RftComandaIntervalTimp1luna { get; }
        public ICommand RftComandaIntervalTimp1an { get; }
        public ICommand RftComandaIntervalTimpSfert1 { get; }
        public ICommand RftComandaIntervalTimpSfert2 { get; }
        public ICommand RftComandaIntervalTimpSfert3 { get; }
        public ICommand RftComandaIntervalTimpSfert4 { get; }
        public ICommand RftComandaExportPDFContinutInvatamant { get; }
        public ICommand RftComandaExportExcelContinutInvatamant { get; }
        public ICommand RftComandaExportCSVContinutInvatamant { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutInvatamant()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutInvatamant(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutInvatamant(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutInvatamant(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutInvatamant(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutInvatamant(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutInvatamant(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutInvatamant(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutInvatamant(this, 7);
            RftComandaExportPDFContinutInvatamant = new RftComandaExportPDFContinutInvatamant(this);
            RftComandaExportExcelContinutInvatamant = new RftComandaExportExcelContinutInvatamant(this);
            RftComandaExportCSVContinutInvatamant = new RftComandaExportCSVContinutInvatamant(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaInvatamant(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelEducatieInvatamantLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelEducatieInvatamant rftModelInvatamant)
            {
                return rftModelInvatamant.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelEducatieInvatamant>? x = new ObservableCollection<RftModelEducatieInvatamant>(rftServiciuDeDateInvatamant.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelEducatieInvatamant? item in x)
            {
                RftModelEducatieInvatamantLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelEducatieInvatamant? item in RftModelEducatieInvatamantLista)
            {
                RftLinieInvatamant.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieInvatamant.Count != 0)
            {
                RftLinieInvatamant.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, Data = DateTime.Now, Pret = RftLinieInvatamant.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelEducatieInvatamantLista.Clear();
            RftLinieInvatamant.Clear();
        }
    }
}
