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
    internal class RftVedereModelContinutAlimente : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelCumparaturiAlimente> rftModelCumparaturiAlimenteLista = new();
        public ObservableCollection<RftModelCumparaturiAlimente> RftModelCumparaturiAlimenteLista
        {
            get => rftModelCumparaturiAlimenteLista;
            set
            {
                rftModelCumparaturiAlimenteLista = value;
                RftSchimbareProprietate(nameof(RftModelCumparaturiAlimenteLista));
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
        private readonly RftServiciuDeDateCumparaturiAlimente<RftModelCumparaturiAlimente> rftServiciuDeDateAlimente = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieAlimente = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieAlimente
        {
            get
            {
                if (rftLinieAlimente is not null)
                {
                    return rftLinieAlimente;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieAlimente = value;
                RftSchimbareProprietate(nameof(RftLinieAlimente));
            }
        }

        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Alimente";

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
        public ICommand RftComandaExportPDFContinutAlimente { get; }
        public ICommand RftComandaExportExcelContinutAlimente { get; }
        public ICommand RftComandaExportCSVContinutAlimente { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutAlimente()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutAlimente(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutAlimente(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutAlimente(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutAlimente(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutAlimente(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutAlimente(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutAlimente(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutAlimente(this, 7);
            RftComandaExportPDFContinutAlimente = new RftComandaExportPDFContinutAlimente(this);
            RftComandaExportExcelContinutAlimente = new RftComandaExportExcelContinutAlimente(this);
            RftComandaExportCSVContinutAlimente = new RftComandaExportCSVContinutAlimente(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaAlimente(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelCumparaturiAlimenteLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelCumparaturiAlimente rftModelAlimente)
            {
                return rftModelAlimente.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelCumparaturiAlimente>? x = new ObservableCollection<RftModelCumparaturiAlimente>(rftServiciuDeDateAlimente.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelCumparaturiAlimente? item in x)
            {
                RftModelCumparaturiAlimenteLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelCumparaturiAlimente? item in RftModelCumparaturiAlimenteLista)
            {
                RftLinieAlimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieAlimente.Count != 0)
            {
                RftLinieAlimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, Data = DateTime.Now, Pret = RftLinieAlimente.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion

            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelCumparaturiAlimenteLista.Clear();
            RftLinieAlimente.Clear();
        }
    }
}
