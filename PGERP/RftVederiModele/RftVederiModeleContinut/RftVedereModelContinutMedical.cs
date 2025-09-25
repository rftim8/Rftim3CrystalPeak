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
    internal class RftVedereModelContinutMedical : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelSanatateMedical> rftModelSanatateMedicalLista = new();
        public ObservableCollection<RftModelSanatateMedical> RftModelSanatateMedicalLista
        {
            get => rftModelSanatateMedicalLista;
            set
            {
                rftModelSanatateMedicalLista = value;
                RftSchimbareProprietate(nameof(RftModelSanatateMedicalLista));
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
        private readonly RftServiciuDeDateSanatateMedical<RftModelSanatateMedical> rftServiciuDeDateMedical = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic>? rftLinieMedical = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieMedical
        {
            get
            {
                if (rftLinieMedical is not null)
                {
                    return rftLinieMedical;
                }
                else
                {
                    return new ObservableCollection<RftModelTranzactieGeneralGrafic>();
                }
            }
            set
            {
                rftLinieMedical = value;
                RftSchimbareProprietate(nameof(RftLinieMedical));
            }
        }
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Medical";

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
        public ICommand RftComandaExportPDFContinutMedical { get; }
        public ICommand RftComandaExportExcelContinutMedical { get; }
        public ICommand RftComandaExportCSVContinutMedical { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutMedical()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutMedical(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutMedical(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutMedical(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutMedical(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutMedical(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutMedical(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutMedical(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutMedical(this, 7);
            RftComandaExportPDFContinutMedical = new RftComandaExportPDFContinutMedical(this);
            RftComandaExportExcelContinutMedical = new RftComandaExportExcelContinutMedical(this);
            RftComandaExportCSVContinutMedical = new RftComandaExportCSVContinutMedical(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaMedical(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelSanatateMedicalLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelSanatateMedical rftModelMedical)
            {
                return rftModelMedical.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelSanatateMedical>? x = new ObservableCollection<RftModelSanatateMedical>(rftServiciuDeDateMedical.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelSanatateMedical? item in x)
            {
                RftModelSanatateMedicalLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelSanatateMedical? item in RftModelSanatateMedicalLista)
            {
                RftLinieMedical.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieMedical.Count != 0)
            {
                RftLinieMedical.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftSanatate, Data = DateTime.Now, Pret = RftLinieMedical.OrderByDescending(o => o.Data).First().Pret });
            }

            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelSanatateMedicalLista.Clear();
            RftLinieMedical.Clear();
        }
    }
}
