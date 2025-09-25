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
    internal class RftVedereModelContinutFilme : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelDivertismentFilme> rftModelDivertismentFilmeLista = new();
        public ObservableCollection<RftModelDivertismentFilme> RftModelDivertismentFilmeLista
        {
            get => rftModelDivertismentFilmeLista;
            set
            {
                rftModelDivertismentFilmeLista = value;
                RftSchimbareProprietate(nameof(RftModelDivertismentFilmeLista));
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
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Filme";

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
        public ICommand RftComandaExportPDFContinutFilme { get; }
        public ICommand RftComandaExportExcelContinutFilme { get; }
        public ICommand RftComandaExportCSVContinutFilme { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutFilme()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutFilme(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutFilme(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutFilme(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutFilme(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutFilme(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutFilme(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutFilme(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutFilme(this, 7);
            RftComandaExportPDFContinutFilme = new RftComandaExportPDFContinutFilme(this);
            RftComandaExportExcelContinutFilme = new RftComandaExportExcelContinutFilme(this);
            RftComandaExportCSVContinutFilme = new RftComandaExportCSVContinutFilme(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaFilme(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelDivertismentFilmeLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelDivertismentFilme rftModelFilme)
            {
                return rftModelFilme.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelDivertismentFilme>? x = new ObservableCollection<RftModelDivertismentFilme>(rftServiciuDeDateFilme.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelDivertismentFilme? item in x)
            {
                RftModelDivertismentFilmeLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelDivertismentFilme? item in RftModelDivertismentFilmeLista)
            {
                RftLinieFilme.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieFilme.Count != 0)
            {
                RftLinieFilme.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, Data = DateTime.Now, Pret = RftLinieFilme.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelDivertismentFilmeLista.Clear();
            RftLinieFilme.Clear();
        }
    }
}
