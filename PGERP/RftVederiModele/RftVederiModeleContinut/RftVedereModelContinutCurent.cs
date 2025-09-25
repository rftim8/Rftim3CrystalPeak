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
    internal class RftVedereModelContinutCurent : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelFacturiCurent> rftModelFacturiCurentLista = new();
        public ObservableCollection<RftModelFacturiCurent> RftModelFacturiCurentLista
        {
            get => rftModelFacturiCurentLista;
            set
            {
                rftModelFacturiCurentLista = value;
                RftSchimbareProprietate(nameof(RftModelFacturiCurentLista));
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
        private readonly RftServiciuDeDateFacturiCurent<RftModelFacturiCurent> rftServiciuDeDateCurent = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieFacturiCurent = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieFacturiCurent
        {
            get
            {
                if (rftLinieFacturiCurent is not null)
                {
                    return rftLinieFacturiCurent;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieFacturiCurent = value;
                RftSchimbareProprietate(nameof(RftLinieFacturiCurent));
            }
        }

        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Facturi Curent";

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
        public ICommand RftComandaExportPDFContinutFacturiCurent { get; }
        public ICommand RftComandaExportExcelContinutFacturiCurent { get; }
        public ICommand RftComandaExportCSVContinutFacturiCurent { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutCurent()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutCurent(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutCurent(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutCurent(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutCurent(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutCurent(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutCurent(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutCurent(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutCurent(this, 7);
            RftComandaExportPDFContinutFacturiCurent = new RftComandaExportPDFContinutFacturiCurent(this);
            RftComandaExportExcelContinutFacturiCurent = new RftComandaExportExcelContinutFacturiCurent(this);
            RftComandaExportCSVContinutFacturiCurent = new RftComandaExportCSVContinutFacturiCurent(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaCurent(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelFacturiCurentLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelFacturiCurent rftModelCurent)
            {
                return rftModelCurent.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelFacturiCurent>? x = new ObservableCollection<RftModelFacturiCurent>(rftServiciuDeDateCurent.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelFacturiCurent? item in x)
            {
                RftModelFacturiCurentLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelFacturiCurent? item in RftModelFacturiCurentLista)
            {
                RftLinieFacturiCurent.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieFacturiCurent.Count != 0)
            {
                RftLinieFacturiCurent.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, Data = DateTime.Now, Pret = RftLinieFacturiCurent.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelFacturiCurentLista.Clear();
            RftLinieFacturiCurent.Clear();
        }
    }
}
