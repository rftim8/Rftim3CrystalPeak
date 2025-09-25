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
    internal class RftVedereModelContinutTelefonie : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelFacturiTelefonie> rftModelFacturiTelefonieLista = new();
        public ObservableCollection<RftModelFacturiTelefonie> RftModelFacturiTelefonieLista
        {
            get => rftModelFacturiTelefonieLista;
            set
            {
                rftModelFacturiTelefonieLista = value;
                RftSchimbareProprietate(nameof(RftModelFacturiTelefonieLista));
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
        private readonly RftServiciuDeDateFacturiTelefonie<RftModelFacturiTelefonie> rftServiciuDeDateTelefonie = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
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
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Telefonie";

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
        public ICommand RftComandaExportPDFContinutTelefonie { get; }
        public ICommand RftComandaExportExcelContinutTelefonie { get; }
        public ICommand RftComandaExportCSVContinutTelefonie { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutTelefonie()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutTelefonie(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutTelefonie(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutTelefonie(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutTelefonie(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutTelefonie(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutTelefonie(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutTelefonie(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutTelefonie(this, 7);
            RftComandaExportPDFContinutTelefonie = new RftComandaExportPDFContinutTelefonie(this);
            RftComandaExportExcelContinutTelefonie = new RftComandaExportExcelContinutTelefonie(this);
            RftComandaExportCSVContinutTelefonie = new RftComandaExportCSVContinutTelefonie(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaTelefonie(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelFacturiTelefonieLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelFacturiTelefonie rftModelTelefonie)
            {
                return rftModelTelefonie.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelFacturiTelefonie>? x = new ObservableCollection<RftModelFacturiTelefonie>(rftServiciuDeDateTelefonie.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelFacturiTelefonie? item in x)
            {
                RftModelFacturiTelefonieLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelFacturiTelefonie? item in RftModelFacturiTelefonieLista)
            {
                RftLinieTelefonie.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieTelefonie.Count != 0)
            {
                RftLinieTelefonie.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, Data = DateTime.Now, Pret = RftLinieTelefonie.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelFacturiTelefonieLista.Clear();
            RftLinieTelefonie.Clear();
        }
    }
}
