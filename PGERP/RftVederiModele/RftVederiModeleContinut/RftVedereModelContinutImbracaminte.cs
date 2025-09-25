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
    internal class RftVedereModelContinutImbracaminte : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        private ObservableCollection<RftModelCumparaturiImbracaminte> rftModelCumparaturiImbracaminteLista = new();
        public ObservableCollection<RftModelCumparaturiImbracaminte> RftModelCumparaturiImbracaminteLista
        {
            get => rftModelCumparaturiImbracaminteLista;
            set
            {
                rftModelCumparaturiImbracaminteLista = value;
                RftSchimbareProprietate(nameof(RftModelCumparaturiImbracaminteLista));
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
        private readonly RftServiciuDeDateCumparaturiImbracaminte<RftModelCumparaturiImbracaminte> rftServiciuDeDateImbracaminte = new(new RftContextGeneratorModel());
        #endregion

        #region Setare Date Grafic
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
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Imbracaminte";

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
        public ICommand RftComandaExportPDFContinutImbracaminte { get; }
        public ICommand RftComandaExportExcelContinutImbracaminte { get; }
        public ICommand RftComandaExportCSVContinutImbracaminte { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutImbracaminte()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutImbracaminte(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutImbracaminte(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutImbracaminte(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutImbracaminte(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutImbracaminte(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutImbracaminte(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutImbracaminte(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutImbracaminte(this, 7);
            RftComandaExportPDFContinutImbracaminte = new RftComandaExportPDFContinutImbracaminte(this);
            RftComandaExportExcelContinutImbracaminte = new RftComandaExportExcelContinutImbracaminte(this);
            RftComandaExportCSVContinutImbracaminte = new RftComandaExportCSVContinutImbracaminte(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaImbracaminte(this);

            RftTranzactiiFiltrate = CollectionViewSource.GetDefaultView(RftModelCumparaturiImbracaminteLista);
            RftTranzactiiFiltrate.Filter = RftFiltrareTranzactii;
        }

        private bool RftFiltrareTranzactii(object obj)
        {
            if (obj is RftModelCumparaturiImbracaminte rftModelImbracaminte)
            {
                return rftModelImbracaminte.Tranzactie.Contains(RftFiltruTranzactii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public void RftColectareDate()
        {
            #region RftCompletareTabel
            List<RftModelCumparaturiImbracaminte>? x = new ObservableCollection<RftModelCumparaturiImbracaminte>(rftServiciuDeDateImbracaminte.RftReturnareObiecteContinutPrincipala().Result).ToList();
            x = x.OrderByDescending(o => o.Pret).Take(30).ToList();

            foreach (RftModelCumparaturiImbracaminte? item in x)
            {
                RftModelCumparaturiImbracaminteLista.Add(item);
            }
            #endregion

            #region RftCompletareGrafic
            foreach (RftModelCumparaturiImbracaminte? item in RftModelCumparaturiImbracaminteLista)
            {
                RftLinieImbracaminte.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieImbracaminte.Count != 0)
            {
                RftLinieImbracaminte.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, Data = DateTime.Now, Pret = RftLinieImbracaminte.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelCumparaturiImbracaminteLista.Clear();
            RftLinieImbracaminte.Clear();
        }
    }
}
