using PGERP.RftComenzi;
using PGERP.RftComenzi.RftAlgoritmi;
using PGERP.RftComenzi.RftAlgoritmi.RftTopPret;
using PGERP.RftComenzi.RftExportCSV;
using PGERP.RftComenzi.RftExportExcel;
using PGERP.RftComenzi.RftExportPDF;
using PGERP.RftComenzi.RftTabela.RftReinitializare;
using PGERP.RftComenzi.RftTabela.RftTranzactiiModificari;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele.RftVederiModeleContinut.RftVedereModelActivitatiSportive;
using PGERPBiblioteca.RftGeneral;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PGERP.RftVederiModele.RftVederiModeleContinut
{
    internal class RftVedereModelContinutActivitatiSportive : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelSanatateActivitatiSportive> rftModelSanatateActivitatiSportiveLista = new();

        public ObservableCollection<RftModelSanatateActivitatiSportive> RftModelSanatateActivitatiSportiveLista
        {
            get { return rftModelSanatateActivitatiSportiveLista; }
            set
            {
                rftModelSanatateActivitatiSportiveLista = value;
                RftSchimbareProprietate(nameof(RftModelSanatateActivitatiSportiveLista));
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
        private readonly RftServiciuDeDateSanatateActivitatiSportive<RftModelSanatateActivitatiSportive> rftServiciuDeDateActivitatiSportive = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieActivitatiSportive = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieActivitatiSportive
        {
            get
            {
                if (rftLinieActivitatiSportive is not null)
                {
                    return rftLinieActivitatiSportive;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieActivitatiSportive = value;
                RftSchimbareProprietate(nameof(RftLinieActivitatiSportive));
            }
        }

        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Activitati Sportive";

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

        private RftModelSanatateActivitatiSportive? rftRandSelectat;

        public RftModelSanatateActivitatiSportive? RftRandSelectat
        {
            get { return rftRandSelectat; }
            set
            {
                rftRandSelectat = value;
                RftSchimbareProprietate(nameof(RftRandSelectat));
                Trace.WriteLine($"{RftRandSelectat.Data} => {RftRandSelectat.Pret}");
            }
        }

        #endregion

        #region Tabela Tranzactii
        private bool rftVedereModificariVizibila;

        public bool RftVedereModificariVizibila
        {
            get { return rftVedereModificariVizibila; }
            set
            {
                rftVedereModificariVizibila = value;
                RftSchimbareProprietate(nameof(RftVedereModificariVizibila));
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

        #region Vedere Afisare
        private bool rftVedereAdaugareVizibila;

        public bool RftVedereAdaugareVizibila
        {
            get { return rftVedereAdaugareVizibila; }
            set
            {
                rftVedereAdaugareVizibila = value;
                RftSchimbareProprietate(nameof(RftVedereAdaugareVizibila));
            }
        }

        private RftVedereModelBaza? rftVedereModelAdaugareActual;

        public RftVedereModelBaza? RftVedereModelAdaugareActual
        {
            get { return rftVedereModelAdaugareActual; }
            set { rftVedereModelAdaugareActual = value; }
        }
        #endregion

        #region Comenzi
        public ICommand RftComandaIntervalTimp24ore { get; }
        public ICommand RftComandaIntervalTimp7zile { get; }
        public ICommand RftComandaIntervalTimp1luna { get; }
        public ICommand RftComandaIntervalTimp1an { get; }
        public ICommand RftComandaIntervalTimpSfert1 { get; }
        public ICommand RftComandaIntervalTimpSfert2 { get; }
        public ICommand RftComandaIntervalTimpSfert3 { get; }
        public ICommand RftComandaIntervalTimpSfert4 { get; }
        public ICommand RftComandaExportPDFContinutActivitatiSportive { get; }
        public ICommand RftComandaExportExcelContinutActivitatiSportive { get; }
        public ICommand RftComandaExportCSVContinutActivitatiSportive { get; }
        public ICommand RftComandaReinitializareTabela { get; }
        public ICommand RftComandaAdaugareRand { get; }
        #endregion

        public RftVedereModelContinutActivitatiSportive(RftVedereModelContinut rftVedereModelContinut)
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutActivitatiSportive(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutActivitatiSportive(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutActivitatiSportive(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutActivitatiSportive(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutActivitatiSportive(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutActivitatiSportive(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutActivitatiSportive(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutActivitatiSportive(this, 7);
            RftComandaExportPDFContinutActivitatiSportive = new RftComandaExportPDFContinutActivitatiSportive(this);
            RftComandaExportExcelContinutActivitatiSportive = new RftComandaExportExcelContinutActivitatiSportive(this);
            RftComandaExportCSVContinutActivitatiSportive = new RftComandaExportCSVContinutActivitatiSportive(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaActivitatiSportive(this);
            RftComandaAdaugareRand = new RftComandaAdaugareRandActivitatiSportive(this);
            RftVedereModelAdaugareActual = new RftVedereModelActivitatiSportiveAdaugare(rftVedereModelContinut);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelSanatateActivitatiSportiveLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelSanatateActivitatiSportive rftModelActivitatiSportive)
            {
                return rftModelActivitatiSportive.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelSanatateActivitatiSportive>? x = new ObservableCollection<RftModelSanatateActivitatiSportive>(rftServiciuDeDateActivitatiSportive.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelSanatateActivitatiSportive? item in x)
            {
                RftModelSanatateActivitatiSportiveLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelSanatateActivitatiSportive? item in RftModelSanatateActivitatiSportiveLista)
            {
                RftLinieActivitatiSportive.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieActivitatiSportive.Count != 0)
            {
                RftLinieActivitatiSportive.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftSanatate, Data = DateTime.Now, Pret = RftLinieActivitatiSportive.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion

            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelSanatateActivitatiSportiveLista.Clear();
            RftLinieActivitatiSportive.Clear();
        }
    }
}
