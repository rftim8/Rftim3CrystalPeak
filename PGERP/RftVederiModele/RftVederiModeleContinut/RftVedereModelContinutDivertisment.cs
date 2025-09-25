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
    internal class RftVedereModelContinutDivertisment : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        public ObservableCollection<RftModelDivertismentFilme>? RftModelDivertismentFilmeLista { get; set; }
        public ObservableCollection<RftModelDivertismentJocuri>? RftModelDivertismentJocuriLista { get; set; }
        public ObservableCollection<RftModelDivertismentMuzica>? RftModelDivertismentMuzicaLista { get; set; }

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
        private readonly RftServiciuDeDateDivertismentFilme<RftModelDivertismentFilme> rftServiciuDeDateFilme = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateDivertismentJocuri<RftModelDivertismentJocuri> rftServiciuDeDateJocuri = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateDivertismentMuzica<RftModelDivertismentMuzica> rftServiciuDeDateMuzica = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieFilme = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieFilme
        {
            get
            {
                if (rftLinieFilme is not null)
                {
                    return rftLinieFilme;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieFilme = value;
                RftSchimbareProprietate(nameof(RftLinieFilme));
            }
        }

        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieJocuri = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieJocuri
        {
            get
            {
                if (rftLinieJocuri is not null)
                {
                    return rftLinieJocuri;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieJocuri = value;
                RftSchimbareProprietate(nameof(RftLinieJocuri));
            }
        }

        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieMuzica = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieMuzica
        {
            get
            {
                if (rftLinieMuzica is not null)
                {
                    return rftLinieMuzica;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieMuzica = value;
                RftSchimbareProprietate(nameof(RftLinieMuzica));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Divertisment";

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
        public ICommand RftComandaExportPDFContinutDivertisment { get; }
        public ICommand RftComandaExportExcelContinutDivertisment { get; }
        public ICommand RftComandaExportCSVContinutDivertisment { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutDivertisment()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutDivertisment(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutDivertisment(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutDivertisment(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutDivertisment(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutDivertisment(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutDivertisment(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutDivertisment(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutDivertisment(this, 7);
            RftComandaExportPDFContinutDivertisment = new RftComandaExportPDFContinutDivertisment(this);
            RftComandaExportExcelContinutDivertisment = new RftComandaExportExcelContinutDivertisment(this);
            RftComandaExportCSVContinutDivertisment = new RftComandaExportCSVContinutDivertisment(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaDivertisment(this);

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
            RftModelDivertismentFilmeLista = new ObservableCollection<RftModelDivertismentFilme>(rftServiciuDeDateFilme.RftReturnareObiecteContinutPrincipala().Result);
            RftModelDivertismentJocuriLista = new ObservableCollection<RftModelDivertismentJocuri>(rftServiciuDeDateJocuri.RftReturnareObiecteContinutPrincipala().Result);
            RftModelDivertismentMuzicaLista = new ObservableCollection<RftModelDivertismentMuzica>(rftServiciuDeDateMuzica.RftReturnareObiecteContinutPrincipala().Result);

            List<RftModelTranzactieGeneralTabela> x = new();
            foreach (RftModelDivertismentFilme? item in RftModelDivertismentFilmeLista)
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
            foreach (RftModelDivertismentJocuri? item in RftModelDivertismentJocuriLista)
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
            foreach (RftModelDivertismentMuzica? item in RftModelDivertismentMuzicaLista)
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
            foreach (RftModelDivertismentFilme? item in RftModelDivertismentFilmeLista)
            {
                RftLinieFilme.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = RftGeneral.RftFilme, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieFilme.Count != 0)
            {
                RftLinieFilme.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftFilme, Data = DateTime.Now, Pret = RftLinieFilme.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelDivertismentJocuri? item in RftModelDivertismentJocuriLista)
            {
                RftLinieJocuri.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = RftGeneral.RftJocuri, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieJocuri.Count != 0)
            {
                RftLinieJocuri.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftJocuri, Data = DateTime.Now, Pret = RftLinieJocuri.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelDivertismentMuzica? item in RftModelDivertismentMuzicaLista)
            {
                RftLinieMuzica.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = RftGeneral.RftMuzica, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieMuzica.Count != 0)
            {
                RftLinieMuzica.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, SubCategorie = RftGeneral.RftMuzica, Data = DateTime.Now, Pret = RftLinieMuzica.OrderByDescending(o => o.Data).First().Pret });
            }

            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelDivertismentFilmeLista.Clear();
            RftModelDivertismentJocuriLista.Clear();
            RftModelDivertismentMuzicaLista.Clear();
            RftModelTranzactieGeneralTabelaLista.Clear();
            RftLinieFilme.Clear();
            RftLinieJocuri.Clear();
            RftLinieMuzica.Clear();
        }
    }
}
