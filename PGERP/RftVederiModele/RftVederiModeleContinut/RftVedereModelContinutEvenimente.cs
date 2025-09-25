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
    internal class RftVedereModelContinutEvenimente : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelEducatieEvenimente> rftModelEducatieEvenimenteLista = new();
        public ObservableCollection<RftModelEducatieEvenimente> RftModelEducatieEvenimenteLista
        {
            get => rftModelEducatieEvenimenteLista;
            set
            {
                rftModelEducatieEvenimenteLista = value;
                RftSchimbareProprietate(nameof(RftModelEducatieEvenimenteLista));
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
        private readonly RftServiciuDeDateEducatieEvenimente<RftModelEducatieEvenimente> rftServiciuDeDateEvenimente = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieEvenimente = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieEvenimente
        {
            get
            {
                if (rftLinieEvenimente is not null)
                {
                    return rftLinieEvenimente;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieEvenimente = value;
                RftSchimbareProprietate(nameof(RftLinieEvenimente));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Evenimente";

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
        public ICommand RftComandaExportPDFContinutEvenimente { get; }
        public ICommand RftComandaExportExcelContinutEvenimente { get; }
        public ICommand RftComandaExportCSVContinutEvenimente { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutEvenimente()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutEvenimente(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutEvenimente(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutEvenimente(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutEvenimente(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutEvenimente(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutEvenimente(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutEvenimente(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutEvenimente(this, 7);
            RftComandaExportPDFContinutEvenimente = new RftComandaExportPDFContinutEvenimente(this);
            RftComandaExportExcelContinutEvenimente = new RftComandaExportExcelContinutEvenimente(this);
            RftComandaExportCSVContinutEvenimente = new RftComandaExportCSVContinutEvenimente(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaEvenimente(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelEducatieEvenimenteLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelEducatieEvenimente rftModelEvenimente)
            {
                return rftModelEvenimente.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelEducatieEvenimente>? x = new ObservableCollection<RftModelEducatieEvenimente>(rftServiciuDeDateEvenimente.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelEducatieEvenimente? item in x)
            {
                RftModelEducatieEvenimenteLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelEducatieEvenimente? item in RftModelEducatieEvenimenteLista)
            {
                RftLinieEvenimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieEvenimente.Count != 0)
            {
                RftLinieEvenimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, Data = DateTime.Now, Pret = RftLinieEvenimente.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelEducatieEvenimenteLista.Clear();
            RftLinieEvenimente.Clear();
        }
    }
}
