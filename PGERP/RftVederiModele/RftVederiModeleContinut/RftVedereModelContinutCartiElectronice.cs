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
    internal class RftVedereModelContinutCartiElectronice : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelEducatieCartiElectronice> rftModelEducatieCartiElectroniceLista = new();
        public ObservableCollection<RftModelEducatieCartiElectronice> RftModelEducatieCartiElectroniceLista
        {
            get => rftModelEducatieCartiElectroniceLista;
            set
            {
                rftModelEducatieCartiElectroniceLista = value;
                RftSchimbareProprietate(nameof(RftModelEducatieCartiElectroniceLista));
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
        private readonly RftServiciuDeDateEducatieCartiElectronice<RftModelEducatieCartiElectronice> rftServiciuDeDateCartiElectronice = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieCartiElectronice = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieCartiElectronice
        {
            get
            {
                if (rftLinieCartiElectronice is not null)
                {
                    return rftLinieCartiElectronice;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieCartiElectronice = value;
                RftSchimbareProprietate(nameof(RftLinieCartiElectronice));
            }
        }

        private string? rftGraficTitlu = $"Evolutia Generala a Tranzactiilor in Timp";

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
        public ICommand RftComandaExportPDFContinutCartiElectronice { get; }
        public ICommand RftComandaExportExcelContinutCartiElectronice { get; }
        public ICommand RftComandaExportCSVContinutCartiElectronice { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutCartiElectronice()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutCartiElectronice(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutCartiElectronice(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutCartiElectronice(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutCartiElectronice(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutCartiElectronice(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutCartiElectronice(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutCartiElectronice(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutCartiElectronice(this, 7);
            RftComandaExportPDFContinutCartiElectronice = new RftComandaExportPDFContinutCartiElectronice(this);
            RftComandaExportExcelContinutCartiElectronice = new RftComandaExportExcelContinutCartiElectronice(this);
            RftComandaExportCSVContinutCartiElectronice = new RftComandaExportCSVContinutCartiElectronice(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaCartiElectronice(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelEducatieCartiElectroniceLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelEducatieCartiElectronice rftModelCartiElectronice)
            {
                return rftModelCartiElectronice.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelEducatieCartiElectronice>? x = new ObservableCollection<RftModelEducatieCartiElectronice>(rftServiciuDeDateCartiElectronice.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelEducatieCartiElectronice? item in x)
            {
                RftModelEducatieCartiElectroniceLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelEducatieCartiElectronice? item in RftModelEducatieCartiElectroniceLista)
            {
                RftLinieCartiElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }

            if (RftLinieCartiElectronice.Count != 0)
            {
                RftLinieCartiElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, Data = DateTime.Now, Pret = RftLinieCartiElectronice.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelEducatieCartiElectroniceLista.Clear();
            RftLinieCartiElectronice.Clear();
        }
    }
}
