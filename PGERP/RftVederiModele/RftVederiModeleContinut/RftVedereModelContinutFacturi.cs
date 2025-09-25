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
    internal class RftVedereModelContinutFacturi : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        public ObservableCollection<RftModelFacturiApa>? RftModelFacturiApaLista { get; set; }
        public ObservableCollection<RftModelFacturiCurent>? RftModelFacturiCurentLista { get; set; }
        public ObservableCollection<RftModelFacturiTelefonie>? RftModelFacturiTelefonieLista { get; set; }

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
        private readonly RftServiciuDeDateFacturiApa<RftModelFacturiApa> rftServiciuDeDateApa = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateFacturiCurent<RftModelFacturiCurent> rftServiciuDeDateCurent = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateFacturiTelefonie<RftModelFacturiTelefonie> rftServiciuDeDateTelefonie = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieApa = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieApa
        {
            get
            {
                if (rftLinieApa is not null)
                {
                    return rftLinieApa;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieApa = value;
                RftSchimbareProprietate(nameof(RftLinieApa));
            }
        }

        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieCurent = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieCurent
        {
            get
            {
                if (rftLinieCurent is not null)
                {
                    return rftLinieCurent;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieCurent = value;
                RftSchimbareProprietate(nameof(RftLinieCurent));
            }
        }

        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieTelefonie = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieTelefonie
        {
            get
            {
                if (rftLinieTelefonie is not null)
                {
                    return rftLinieTelefonie;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieTelefonie = value;
                RftSchimbareProprietate(nameof(RftLinieTelefonie));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Facturi";

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
        public ICommand RftComandaExportPDFContinutFacturi { get; }
        public ICommand RftComandaExportExcelContinutFacturi { get; }
        public ICommand RftComandaExportCSVContinutFacturi { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutFacturi()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutFacturi(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutFacturi(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutFacturi(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutFacturi(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutFacturi(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutFacturi(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutFacturi(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutFacturi(this, 7);
            RftComandaExportPDFContinutFacturi = new RftComandaExportPDFContinutFacturi(this);
            RftComandaExportExcelContinutFacturi = new RftComandaExportExcelContinutFacturi(this);
            RftComandaExportCSVContinutFacturi = new RftComandaExportCSVContinutFacturi(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaFacturi(this);

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
            RftModelFacturiApaLista = new ObservableCollection<RftModelFacturiApa>(rftServiciuDeDateApa.RftReturnareObiecteContinutPrincipala().Result);
            RftModelFacturiCurentLista = new ObservableCollection<RftModelFacturiCurent>(rftServiciuDeDateCurent.RftReturnareObiecteContinutPrincipala().Result);
            RftModelFacturiTelefonieLista = new ObservableCollection<RftModelFacturiTelefonie>(rftServiciuDeDateTelefonie.RftReturnareObiecteContinutPrincipala().Result);

            List<RftModelTranzactieGeneralTabela> x = new();
            foreach (RftModelFacturiApa? item in RftModelFacturiApaLista)
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
            foreach (RftModelFacturiCurent? item in RftModelFacturiCurentLista)
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
            foreach (RftModelFacturiTelefonie? item in RftModelFacturiTelefonieLista)
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
            foreach (RftModelFacturiApa? item in RftModelFacturiApaLista)
            {
                RftLinieApa.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieApa.Count != 0)
            {
                RftLinieApa.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftApa, Data = DateTime.Now, Pret = RftLinieApa.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelFacturiCurent? item in RftModelFacturiCurentLista)
            {
                RftLinieCurent.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieCurent.Count != 0)
            {
                RftLinieCurent.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftCurent, Data = DateTime.Now, Pret = RftLinieCurent.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelFacturiTelefonie? item in RftModelFacturiTelefonieLista)
            {
                RftLinieTelefonie.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieTelefonie.Count != 0)
            {
                RftLinieTelefonie.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, SubCategorie = RftGeneral.RftTelefonie, Data = DateTime.Now, Pret = RftLinieTelefonie.OrderByDescending(o => o.Data).First().Pret });
            }

            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelFacturiApaLista.Clear();
            RftModelFacturiCurentLista.Clear();
            RftModelFacturiTelefonieLista.Clear();
            RftModelTranzactieGeneralTabelaLista.Clear();
            RftLinieApa.Clear();
            RftLinieCurent.Clear();
            RftLinieTelefonie.Clear();
        }
    }
}
