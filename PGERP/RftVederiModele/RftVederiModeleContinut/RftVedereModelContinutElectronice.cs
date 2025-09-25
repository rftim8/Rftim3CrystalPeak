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
    internal class RftVedereModelContinutElectronice : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelCumparaturiElectronice> rftModelCumparaturiElectroniceLista = new();
        public ObservableCollection<RftModelCumparaturiElectronice> RftModelCumparaturiElectroniceLista
        {
            get => rftModelCumparaturiElectroniceLista;
            set
            {
                rftModelCumparaturiElectroniceLista = value;
                RftSchimbareProprietate(nameof(RftModelCumparaturiElectroniceLista));
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
        private readonly RftServiciuDeDateCumparaturiElectronice<RftModelCumparaturiElectronice> rftServiciuDeDateElectronice = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieElectronice = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieElectronice
        {
            get
            {
                if (rftLinieElectronice is not null)
                {
                    return rftLinieElectronice;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieElectronice = value;
                RftSchimbareProprietate(nameof(RftLinieElectronice));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Electronice";

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
        public ICommand RftComandaExportPDFContinutElectronice { get; }
        public ICommand RftComandaExportExcelContinutElectronice { get; }
        public ICommand RftComandaExportCSVContinutElectronice { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutElectronice()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutElectronice(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutElectronice(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutElectronice(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutElectronice(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutElectronice(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutElectronice(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutElectronice(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutElectronice(this, 7);
            RftComandaExportPDFContinutElectronice = new RftComandaExportPDFContinutElectronice(this);
            RftComandaExportExcelContinutElectronice = new RftComandaExportExcelContinutElectronice(this);
            RftComandaExportCSVContinutElectronice = new RftComandaExportCSVContinutElectronice(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaElectronice(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelCumparaturiElectroniceLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelCumparaturiElectronice rftModelElectronice)
            {
                return rftModelElectronice.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelCumparaturiElectronice>? x = new ObservableCollection<RftModelCumparaturiElectronice>(rftServiciuDeDateElectronice.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelCumparaturiElectronice? item in x)
            {
                RftModelCumparaturiElectroniceLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelCumparaturiElectronice? item in RftModelCumparaturiElectroniceLista)
            {
                RftLinieElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieElectronice.Count != 0)
            {
                RftLinieElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, Data = DateTime.Now, Pret = RftLinieElectronice.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelCumparaturiElectroniceLista.Clear();
            RftLinieElectronice.Clear();
        }
    }
}
