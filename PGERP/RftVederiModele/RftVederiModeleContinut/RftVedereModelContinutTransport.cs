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
    internal class RftVedereModelContinutTransport : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        public ObservableCollection<RftModelTransportComun>? RftModelTransportComunLista { get; set; }
        public ObservableCollection<RftModelTransportPersonal>? RftModelTransportPersonalLista { get; set; }

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
        private readonly RftServiciuDeDateTransportComun<RftModelTransportComun> rftServiciuDeDateTransportComun = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateTransportPersonal<RftModelTransportPersonal> rftServiciuDeDateTransportPersonal = new(new RftContextGeneratorModel());
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
        
        private string? rftGraficTitlu = $"Evolutia Tranzactiilor pentru Transport";

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
        public ICommand RftComandaExportPDFContinutTransport { get; }
        public ICommand RftComandaExportExcelContinutTransport { get; }
        public ICommand RftComandaExportCSVContinutTransport { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutTransport()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutTransport(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutTransport(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutTransport(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutTransport(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutTransport(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutTransport(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutTransport(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutTransport(this, 7);
            RftComandaExportPDFContinutTransport = new RftComandaExportPDFContinutTransport(this);
            RftComandaExportExcelContinutTransport = new RftComandaExportExcelContinutTransport(this);
            RftComandaExportCSVContinutTransport = new RftComandaExportCSVContinutTransport(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaTransport(this);

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
            RftModelTransportComunLista = new ObservableCollection<RftModelTransportComun>(rftServiciuDeDateTransportComun.RftReturnareObiecteContinutPrincipala().Result);
            RftModelTransportPersonalLista = new ObservableCollection<RftModelTransportPersonal>(rftServiciuDeDateTransportPersonal.RftReturnareObiecteContinutPrincipala().Result);

            List<RftModelTranzactieGeneralTabela> x = new();
            foreach (RftModelTransportComun? item in RftModelTransportComunLista)
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
            foreach (RftModelTransportPersonal? item in RftModelTransportPersonalLista)
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
            foreach (RftModelTransportComun? item in RftModelTransportComunLista)
            {
                RftLinieTransportComun.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieTransportComun.Count != 0)
            {
                RftLinieTransportComun.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftTransport, SubCategorie = RftGeneral.RftComun, Data = DateTime.Now, Pret = RftLinieTransportComun.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTransportPersonal? item in RftModelTransportPersonalLista)
            {
                RftLinieTransportPersonal.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, SubCategorie = item.SubCategorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieTransportPersonal.Count != 0)
            {
                RftLinieTransportPersonal.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftTransport, SubCategorie = RftGeneral.RftPersonal, Data = DateTime.Now, Pret = rftLinieTransportPersonal.OrderByDescending(o => o.Data).First().Pret });
            }

            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelTransportComunLista.Clear();
            RftModelTransportPersonalLista.Clear();
            RftModelTranzactieGeneralTabelaLista.Clear();
            RftLinieTransportComun.Clear();
            RftLinieTransportPersonal.Clear();
        }
    }
}
