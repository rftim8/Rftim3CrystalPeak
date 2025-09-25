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
    internal class RftVedereModelContinutCumparaturi : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        public ObservableCollection<RftModelCumparaturiAlimente>? RftModelCumparaturiAlimenteLista { get; set; }
        public ObservableCollection<RftModelCumparaturiElectronice>? RftModelCumparaturiElectroniceLista { get; set; }
        public ObservableCollection<RftModelCumparaturiImbracaminte>? RftModelCumparaturiImbracaminteLista { get; set; }

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
        private readonly RftServiciuDeDateCumparaturiAlimente<RftModelCumparaturiAlimente> rftServiciuDeDateAlimente = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateCumparaturiElectronice<RftModelCumparaturiElectronice> rftServiciuDeDateElectronice = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateCumparaturiImbracaminte<RftModelCumparaturiImbracaminte> rftServiciuDeDateImbracaminte = new(new RftContextGeneratorModel());
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

        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieImbracaminte = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieImbracaminte
        {
            get
            {
                if (rftLinieImbracaminte is not null)
                {
                    return rftLinieImbracaminte;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieImbracaminte = value;
                RftSchimbareProprietate(nameof(RftLinieImbracaminte));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Cumparaturi";

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
        public ICommand RftComandaExportPDFContinutCumparaturi { get; }
        public ICommand RftComandaExportExcelContinutCumparaturi { get; }
        public ICommand RftComandaExportCSVContinutCumparaturi { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutCumparaturi()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutCumparaturi(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutCumparaturi(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutCumparaturi(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutCumparaturi(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutCumparaturi(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutCumparaturi(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutCumparaturi(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutCumparaturi(this, 7);
            RftComandaExportPDFContinutCumparaturi = new RftComandaExportPDFContinutCumparaturi(this);
            RftComandaExportExcelContinutCumparaturi = new RftComandaExportExcelContinutCumparaturi(this);
            RftComandaExportCSVContinutCumparaturi = new RftComandaExportCSVContinutCumparaturi(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaCumparaturi(this);

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
            RftModelCumparaturiAlimenteLista = new ObservableCollection<RftModelCumparaturiAlimente>(rftServiciuDeDateAlimente.RftReturnareObiecteContinutPrincipala().Result);
            RftModelCumparaturiElectroniceLista = new ObservableCollection<RftModelCumparaturiElectronice>(rftServiciuDeDateElectronice.RftReturnareObiecteContinutPrincipala().Result);
            RftModelCumparaturiImbracaminteLista = new ObservableCollection<RftModelCumparaturiImbracaminte>(rftServiciuDeDateImbracaminte.RftReturnareObiecteContinutPrincipala().Result);

            List<RftModelTranzactieGeneralTabela> x = new();
            foreach (RftModelCumparaturiAlimente? item in RftModelCumparaturiAlimenteLista)
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
            foreach (RftModelCumparaturiElectronice? item in RftModelCumparaturiElectroniceLista)
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
            foreach (RftModelCumparaturiImbracaminte? item in RftModelCumparaturiImbracaminteLista)
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
            foreach (RftModelCumparaturiAlimente? item in RftModelCumparaturiAlimenteLista)
            {
                RftLinieAlimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieAlimente.Count != 0)
            {
                RftLinieAlimente.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, SubCategorie = RftGeneral.RftAlimente, Data = DateTime.Now, Pret = RftLinieAlimente.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelCumparaturiElectronice? item in RftModelCumparaturiElectroniceLista)
            {
                RftLinieElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieElectronice.Count != 0)
            {
                RftLinieElectronice.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, SubCategorie = RftGeneral.RftElectronice, Data = DateTime.Now, Pret = RftLinieElectronice.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelCumparaturiImbracaminte? item in RftModelCumparaturiImbracaminteLista)
            {
                RftLinieImbracaminte.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieImbracaminte.Count != 0)
            {
                RftLinieImbracaminte.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, SubCategorie = RftGeneral.RftImbracaminte, Data = DateTime.Now, Pret = RftLinieImbracaminte.OrderByDescending(o => o.Data).First().Pret });
            }

            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelCumparaturiAlimenteLista.Clear();
            RftModelCumparaturiElectroniceLista.Clear();
            RftModelCumparaturiImbracaminteLista.Clear();
            RftModelTranzactieGeneralTabelaLista.Clear();
            RftLinieAlimente.Clear();
            RftLinieElectronice.Clear();
            RftLinieImbracaminte.Clear();
        }
    }
}
