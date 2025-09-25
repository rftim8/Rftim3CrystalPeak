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
    internal class RftVedereModelContinutPersonal : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelTransportPersonal> rftModelTransportPersonalLista = new();
        public ObservableCollection<RftModelTransportPersonal> RftModelTransportPersonalLista
        {
            get => rftModelTransportPersonalLista;
            set
            {
                rftModelTransportPersonalLista = value;
                RftSchimbareProprietate(nameof(RftModelTransportPersonalLista));
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
        private readonly RftServiciuDeDateTransportPersonal<RftModelTransportPersonal> rftServiciuDeDateTransportPersonal = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieTransportPersonal = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieTransportPersonal
        {
            get
            {
                if (rftLinieTransportPersonal is not null)
                {
                    return rftLinieTransportPersonal;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieTransportPersonal = value;
                RftSchimbareProprietate(nameof(RftLinieTransportPersonal));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentu Transport Personal";

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
        public ICommand RftComandaExportPDFContinutTransportPersonal { get; }
        public ICommand RftComandaExportExcelContinutTransportPersonal { get; }
        public ICommand RftComandaExportCSVContinutTransportPersonal { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutPersonal()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutPersonal(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutPersonal(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutPersonal(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutPersonal(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutPersonal(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutPersonal(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutPersonal(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutPersonal(this, 7);
            RftComandaExportPDFContinutTransportPersonal = new RftComandaExportPDFContinutTransportPersonal(this);
            RftComandaExportExcelContinutTransportPersonal = new RftComandaExportExcelContinutTransportPersonal(this);
            RftComandaExportCSVContinutTransportPersonal = new RftComandaExportCSVContinutTransportPersonal(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaPersonal(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelTransportPersonalLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelTransportPersonal rftModelPersonal)
            {
                return rftModelPersonal.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelTransportPersonal>? x = new ObservableCollection<RftModelTransportPersonal>(rftServiciuDeDateTransportPersonal.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelTransportPersonal? item in x)
            {
                RftModelTransportPersonalLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelTransportPersonal? item in RftModelTransportPersonalLista)
            {
                RftLinieTransportPersonal.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieTransportPersonal.Count != 0)
            {
                RftLinieTransportPersonal.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftTransport, Data = DateTime.Now, Pret = RftLinieTransportPersonal.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelTransportPersonalLista.Clear();
            RftLinieTransportPersonal.Clear();
        }
    }
}
