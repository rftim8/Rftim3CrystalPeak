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
    internal class RftVedereModelContinutApa : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelFacturiApa> rftModelFacturiApaLista = new();
        public ObservableCollection<RftModelFacturiApa> RftModelFacturiApaLista
        {
            get { return rftModelFacturiApaLista; }
            set
            {
                rftModelFacturiApaLista = value;
                RftSchimbareProprietate(nameof(RftModelFacturiApaLista));
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
        private readonly RftServiciuDeDateFacturiApa<RftModelFacturiApa> rftServiciuDeDateApa = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieFacturiApa = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieFacturiApa
        {
            get
            {
                if (rftLinieFacturiApa is not null)
                {
                    return rftLinieFacturiApa;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieFacturiApa = value;
                RftSchimbareProprietate(nameof(rftLinieFacturiApa));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Facturi Apa";

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
        public ICommand RftComandaExportPDFContinutFacturiApa { get; }
        public ICommand RftComandaExportExcelContinutFacturiApa { get; }
        public ICommand RftComandaExportCSVContinutFacturiApa { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutApa()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutApa(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutApa(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutApa(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutApa(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutApa(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutApa(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutApa(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutApa(this, 7);
            RftComandaExportPDFContinutFacturiApa = new RftComandaExportPDFContinutFacturiApa(this);
            RftComandaExportExcelContinutFacturiApa = new RftComandaExportExcelContinutFacturiApa(this);
            RftComandaExportCSVContinutFacturiApa = new RftComandaExportCSVContinutFacturiApa(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaApa(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelFacturiApaLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelFacturiApa rftModelApa)
            {
                return rftModelApa.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelFacturiApa>? x = new ObservableCollection<RftModelFacturiApa>(rftServiciuDeDateApa.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelFacturiApa? item in x)
            {
                RftModelFacturiApaLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelFacturiApa? item in RftModelFacturiApaLista)
            {
                RftLinieFacturiApa.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieFacturiApa.Count != 0)
            {
                RftLinieFacturiApa.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, Data = DateTime.Now, Pret = RftLinieFacturiApa.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelFacturiApaLista.Clear();
            RftLinieFacturiApa.Clear();
        }
    }
}
