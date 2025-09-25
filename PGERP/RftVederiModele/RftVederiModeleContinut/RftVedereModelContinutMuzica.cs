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
    internal class RftVedereModelContinutMuzica : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelDivertismentMuzica> rftModelDivertismentMuzicaLista = new();
        public ObservableCollection<RftModelDivertismentMuzica> RftModelDivertismentMuzicaLista
        {
            get => rftModelDivertismentMuzicaLista;
            set
            {
                rftModelDivertismentMuzicaLista = value;
                RftSchimbareProprietate(nameof(RftModelDivertismentMuzicaLista));
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
        private readonly RftServiciuDeDateDivertismentMuzica<RftModelDivertismentMuzica> rftServiciuDeDateMuzica = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private List<RftModelTranzactieGeneralGrafic>? rftLinieMuzica = new();

        public List<RftModelTranzactieGeneralGrafic> RftLinieMuzica
        {
            get
            {
                if (rftLinieMuzica is not null)
                {
                    return rftLinieMuzica;
                }
                else
                {
                    return new List<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieMuzica = value;
                RftSchimbareProprietate(nameof(RftLinieMuzica));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Muzica";

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
        public ICommand RftComandaExportPDFContinutMuzica { get; }
        public ICommand RftComandaExportExcelContinutMuzica { get; }
        public ICommand RftComandaExportCSVContinutMuzica { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutMuzica()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutMuzica(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutMuzica(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutMuzica(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutMuzica(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutMuzica(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutMuzica(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutMuzica(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutMuzica(this, 7);
            RftComandaExportPDFContinutMuzica = new RftComandaExportPDFContinutMuzica(this);
            RftComandaExportExcelContinutMuzica = new RftComandaExportExcelContinutMuzica(this);
            RftComandaExportCSVContinutMuzica = new RftComandaExportCSVContinutMuzica(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaMuzica(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelDivertismentMuzicaLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelDivertismentMuzica rftModelMuzica)
            {
                return rftModelMuzica.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelDivertismentMuzica>? x = new ObservableCollection<RftModelDivertismentMuzica>(rftServiciuDeDateMuzica.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelDivertismentMuzica? item in x)
            {
                RftModelDivertismentMuzicaLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelDivertismentMuzica? item in RftModelDivertismentMuzicaLista)
            {
                RftLinieMuzica.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieMuzica.Count != 0)
            {
                RftLinieMuzica.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, Data = DateTime.Now, Pret = RftLinieMuzica.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelDivertismentMuzicaLista.Clear();
            RftLinieMuzica.Clear();
        }
    }
}
