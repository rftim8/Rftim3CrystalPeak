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
    internal class RftVedereModelContinutSanatate : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        public ObservableCollection<RftModelSanatateActivitatiSportive>? RftModelSanatateActivitatiSportiveLista { get; set; }
        public ObservableCollection<RftModelSanatateMedical>? RftModelSanatateMedicalLista { get; set; }

        private ObservableCollection<RftModelTranzactieGeneralTabela> rftModelTranzactieGeneralTabelaLista = new();
        public ObservableCollection<RftModelTranzactieGeneralTabela> RftModelTranzactieGeneralTabelaLista
        {
            get => rftModelTranzactieGeneralTabelaLista;
            set
            {
                rftModelTranzactieGeneralTabelaLista = value;
                RftSchimbareProprietate(nameof(RftModelTranzactieGeneralTabelaLista));
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
        private readonly RftServiciuDeDateSanatateMedical<RftModelSanatateMedical> rftServiciuDeDateMedical = new(new RftContextGeneratorModel());
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

        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieMedical = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieMedical
        {
            get
            {
                if (rftLinieMedical is not null)
                {
                    return rftLinieMedical;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieMedical = value;
                RftSchimbareProprietate(nameof(RftLinieMedical));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Sanatate";

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
        public ICommand RftComandaExportPDFContinutSanatate { get; }
        public ICommand RftComandaExportExcelContinutSanatate { get; }
        public ICommand RftComandaExportCSVContinutSanatate { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutSanatate()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutSanatate(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutSanatate(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutSanatate(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutSanatate(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutSanatate(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutSanatate(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutSanatate(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutSanatate(this, 7);
            RftComandaExportPDFContinutSanatate = new RftComandaExportPDFContinutSanatate(this);
            RftComandaExportExcelContinutSanatate = new RftComandaExportExcelContinutSanatate(this);
            RftComandaExportCSVContinutSanatate = new RftComandaExportCSVContinutSanatate(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaSanatate(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelTranzactieGeneralTabelaLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelTranzactieGeneralTabela rftModelTranzactieGeneral)
            {
                return rftModelTranzactieGeneral.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            RftModelSanatateActivitatiSportiveLista = new ObservableCollection<RftModelSanatateActivitatiSportive>(rftServiciuDeDateActivitatiSportive.RftReturnareObiecteContinutPrincipala().Result);
            RftModelSanatateMedicalLista = new ObservableCollection<RftModelSanatateMedical>(rftServiciuDeDateMedical.RftReturnareObiecteContinutPrincipala().Result);

            List<RftModelTranzactieGeneralTabela> x = new();
            foreach (RftModelSanatateActivitatiSportive? item in RftModelSanatateActivitatiSportiveLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Categorie = item.Categorie,
                    SubCategorie = item.SubCategorie,
                    Data = item.Data,
                    Pret = item.Pret,
                    Tranzactie = item.Tranzactie,
                    MetodaPlata = item.MetodaPlata,
                    InstitutiaFinanciara = item.InstitutiaFinanciara,
                    LocatieDocumente = item.LocatieDocumente,
                    Notite = item.Notite
                });
            }
            foreach (RftModelSanatateMedical? item in RftModelSanatateMedicalLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Categorie = item.Categorie,
                    SubCategorie = item.SubCategorie,
                    Data = item.Data,
                    Pret = item.Pret,
                    Tranzactie = item.Tranzactie,
                    MetodaPlata = item.MetodaPlata,
                    InstitutiaFinanciara = item.InstitutiaFinanciara,
                    LocatieDocumente = item.LocatieDocumente,
                    Notite = item.Notite
                });
            }

            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelTranzactieGeneralTabela? item in x)
            {
                RftModelTranzactieGeneralTabelaLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelSanatateActivitatiSportive? item in RftModelSanatateActivitatiSportiveLista)
            {
                RftLinieActivitatiSportive.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieActivitatiSportive.Count != 0)
            {
                RftLinieActivitatiSportive.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftSanatate, SubCategorie = RftGeneral.RftActivitatiSportive, Data = DateTime.Now, Pret = RftLinieActivitatiSportive.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelSanatateMedical? item in RftModelSanatateMedicalLista)
            {
                RftLinieMedical.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieMedical.Count != 0)
            {
                RftLinieMedical.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftSanatate, SubCategorie = RftGeneral.RftMedical, Data = DateTime.Now, Pret = RftLinieMedical.OrderByDescending(o => o.Data).First().Pret });
            }

            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelSanatateActivitatiSportiveLista.Clear();
            RftModelSanatateMedicalLista.Clear();
            RftModelTranzactieGeneralTabelaLista.Clear();
            RftLinieActivitatiSportive.Clear();
            RftLinieMedical.Clear();
        }
    }
}
