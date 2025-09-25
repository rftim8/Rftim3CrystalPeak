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
    internal class RftVedereModelContinutComun : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelTransportComun> rftModelTransportComunLista = new();
        public ObservableCollection<RftModelTransportComun> RftModelTransportComunLista
        {
            get => rftModelTransportComunLista;
            set
            {
                rftModelTransportComunLista = value;
                RftSchimbareProprietate(nameof(RftModelTransportComunLista));
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
        private readonly RftServiciuDeDateTransportComun<RftModelTransportComun> rftServiciuDeDateTransportComun = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieTransportComun = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieTransportComun
        {
            get
            {
                if (rftLinieTransportComun is not null)
                {
                    return rftLinieTransportComun;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieTransportComun = value;
                RftSchimbareProprietate(nameof(RftLinieTransportComun));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Transport Comun";

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
        public ICommand RftComandaExportPDFContinutTransportComun { get; }
        public ICommand RftComandaExportExcelContinutTransportComun { get; }
        public ICommand RftComandaExportCSVContinutTransportComun { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutComun()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutComun(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutComun(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutComun(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutComun(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutComun(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutComun(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutComun(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutComun(this, 7);
            RftComandaExportPDFContinutTransportComun = new RftComandaExportPDFContinutTransportComun(this);
            RftComandaExportExcelContinutTransportComun = new RftComandaExportExcelContinutTransportComun(this);
            RftComandaExportCSVContinutTransportComun = new RftComandaExportCSVContinutTransportComun(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaComun(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelTransportComunLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelTransportComun rftModelComun)
            {
                return rftModelComun.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelTransportComun>? x = new ObservableCollection<RftModelTransportComun>(rftServiciuDeDateTransportComun.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelTransportComun? item in x)
            {
                RftModelTransportComunLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelTransportComun? item in RftModelTransportComunLista)
            {
                RftLinieTransportComun.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieTransportComun.Count != 0)
            {
                RftLinieTransportComun.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftTransport, Data = DateTime.Now, Pret = RftLinieTransportComun.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);

        }

        public void RftStergereDate()
        {
            RftModelTransportComunLista.Clear();
            RftLinieTransportComun.Clear();
        }
    }
}
