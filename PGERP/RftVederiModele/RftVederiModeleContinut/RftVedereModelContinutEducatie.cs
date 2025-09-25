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
    internal class RftVedereModelContinutEducatie : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        public ObservableCollection<RftModelEducatieCartiElectronice>? RftModelEducatieCartiElectroniceLista { get; set; }
        public ObservableCollection<RftModelEducatieEvenimente>? RftModelEducatieEvenimenteLista { get; set; }
        public ObservableCollection<RftModelEducatieInvatamant>? RftModelEducatieInvatamantLista { get; set; }

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
        private readonly RftServiciuDeDateEducatieCartiElectronice<RftModelEducatieCartiElectronice> rftServiciuDeDateCartiElectronice = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateEducatieEvenimente<RftModelEducatieEvenimente> rftServiciuDeDateEvenimente = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateEducatieInvatamant<RftModelEducatieInvatamant> rftServiciuDeDateInvatamant = new(new RftContextGeneratorModel());
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
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Educatie";

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
        public ICommand RftComandaExportPDFContinutEducatie { get; }
        public ICommand RftComandaExportExcelContinutEducatie { get; }
        public ICommand RftComandaExportCSVContinutEducatie { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutEducatie()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutEducatie(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutEducatie(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutEducatie(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutEducatie(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutEducatie(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutEducatie(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutEducatie(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutEducatie(this, 7);
            RftComandaExportPDFContinutEducatie = new RftComandaExportPDFContinutEducatie(this);
            RftComandaExportExcelContinutEducatie = new RftComandaExportExcelContinutEducatie(this);
            RftComandaExportCSVContinutEducatie = new RftComandaExportCSVContinutEducatie(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaEducatie(this);

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
            RftModelEducatieCartiElectroniceLista = new ObservableCollection<RftModelEducatieCartiElectronice>(rftServiciuDeDateCartiElectronice.RftReturnareObiecteContinutPrincipala().Result);
            RftModelEducatieEvenimenteLista = new ObservableCollection<RftModelEducatieEvenimente>(rftServiciuDeDateEvenimente.RftReturnareObiecteContinutPrincipala().Result);
            RftModelEducatieInvatamantLista = new ObservableCollection<RftModelEducatieInvatamant>(rftServiciuDeDateInvatamant.RftReturnareObiecteContinutPrincipala().Result);

            List<RftModelTranzactieGeneralTabela> x = new();
            foreach (RftModelEducatieCartiElectronice? item in RftModelEducatieCartiElectroniceLista)
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
            foreach (RftModelEducatieEvenimente? item in RftModelEducatieEvenimenteLista)
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
            foreach (RftModelEducatieInvatamant? item in RftModelEducatieInvatamantLista)
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

            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelTranzactieGeneralTabela? item in x)
            {
                RftModelTranzactieGeneralTabelaLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelEducatieCartiElectronice? item in RftModelEducatieCartiElectroniceLista)
            {
                RftLinieCartiElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = RftGeneral.RftCartiElectronice, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieCartiElectronice.Count != 0)
            {
                RftLinieCartiElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, SubCategorie = RftGeneral.RftCartiElectronice, Data = DateTime.Now, Pret = RftLinieCartiElectronice.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelEducatieEvenimente? item in RftModelEducatieEvenimenteLista)
            {
                RftLinieEvenimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = RftGeneral.RftEvenimente, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieEvenimente.Count != 0)
            {
                RftLinieEvenimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, SubCategorie = RftGeneral.RftEvenimente, Data = DateTime.Now, Pret = RftLinieEvenimente.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelEducatieInvatamant? item in RftModelEducatieInvatamantLista)
            {
                RftLinieInvatamant.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieInvatamant.Count != 0)
            {
                RftLinieInvatamant.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, SubCategorie = RftGeneral.RftInvatamant, Data = DateTime.Now, Pret = RftLinieInvatamant.OrderByDescending(o => o.Data).First().Pret });
            }

            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelEducatieCartiElectroniceLista.Clear();
            RftModelEducatieEvenimenteLista.Clear();
            RftModelEducatieInvatamantLista.Clear();
            RftModelTranzactieGeneralTabelaLista.Clear();
            RftLinieCartiElectronice.Clear();
            RftLinieEvenimente.Clear();
            RftLinieInvatamant.Clear();
        }
    }
}
