using PGERP.RftComenzi;
using PGERP.RftComenzi.RftAlgoritmi;
using PGERP.RftComenzi.RftAlgoritmi.RftTopPret;
using PGERP.RftComenzi.RftExportCSV;
using PGERP.RftComenzi.RftExportExcel;
using PGERP.RftComenzi.RftExportPDF;
using PGERP.RftComenzi.RftTabela.RftReinitializare;
using PGERP.RftComenzi.RftTabela.RftTranzactiiModificari;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERPBiblioteca.RftGeneral;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PGERP.RftVederiModele
{
    internal class RftVedereModelContinutPrincipala : RftVedereModelBaza
    {
        #region Stocare Date Tabela si Grafic
        public ObservableCollection<RftModelCumparaturiAlimente>? RftModelCumparaturiAlimenteLista { get; set; }
        public ObservableCollection<RftModelCumparaturiElectronice>? RftModelCumparaturiElectroniceLista { get; set; }
        public ObservableCollection<RftModelCumparaturiImbracaminte>? RftModelCumparaturiImbracaminteLista { get; set; }
        public ObservableCollection<RftModelDivertismentFilme>? RftModelDivertismentFilmeLista { get; set; }
        public ObservableCollection<RftModelDivertismentJocuri>? RftModelDivertismentJocuriLista { get; set; }
        public ObservableCollection<RftModelDivertismentMuzica>? RftModelDivertismentMuzicaLista { get; set; }
        public ObservableCollection<RftModelEducatieCartiElectronice>? RftModelEducatieCartiElectroniceLista { get; set; }
        public ObservableCollection<RftModelEducatieEvenimente>? RftModelEducatieEvenimenteLista { get; set; }
        public ObservableCollection<RftModelEducatieInvatamant>? RftModelEducatieInvatamantLista { get; set; }
        public ObservableCollection<RftModelFacturiApa>? RftModelFacturiApaLista { get; set; }
        public ObservableCollection<RftModelFacturiCurent>? RftModelFacturiCurentLista { get; set; }
        public ObservableCollection<RftModelFacturiTelefonie>? RftModelFacturiTelefonieLista { get; set; }
        public ObservableCollection<RftModelSanatateActivitatiSportive>? RftModelSanatateActivitatiSportiveLista { get; set; }
        public ObservableCollection<RftModelSanatateMedical>? RftModelSanatateMedicalLista { get; set; }
        public ObservableCollection<RftModelTransportComun>? RftModelTransportComunLista { get; set; }
        public ObservableCollection<RftModelTransportPersonal>? RftModelTransportPersonalLista { get; set; }

        private ObservableCollection<RftModelTranzactieGeneralTabela> rftModelTranzactieGeneralTabelaLista = new();

        public ObservableCollection<RftModelTranzactieGeneralTabela> RftModelTranzactieGeneralTabelaLista
        {
            get { return rftModelTranzactieGeneralTabelaLista; }
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

        #region Setare Date Grafic
        private ObservableCollection<RftModelTranzactieGeneralGrafic> rftLinieCumparaturi = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieCumparaturi
        {
            get { return rftLinieCumparaturi; }
            set
            {
                rftLinieCumparaturi = value;
                RftSchimbareProprietate(nameof(RftLinieCumparaturi));
            }
        }
        private ObservableCollection<RftModelTranzactieGeneralGrafic> rftLinieDivertisment = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieDivertisment
        {
            get { return rftLinieDivertisment; }
            set
            {
                rftLinieDivertisment = value;
                RftSchimbareProprietate(nameof(RftLinieDivertisment));
            }
        }
        private ObservableCollection<RftModelTranzactieGeneralGrafic> rftLinieEducatie = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieEducatie
        {
            get { return rftLinieEducatie; }
            set
            {
                rftLinieEducatie = value;
                RftSchimbareProprietate(nameof(RftLinieEducatie));
            }
        }
        private ObservableCollection<RftModelTranzactieGeneralGrafic> rftLinieFacturi = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieFacturi
        {
            get { return rftLinieFacturi; }
            set
            {
                rftLinieFacturi = value;
                RftSchimbareProprietate(nameof(RftLinieFacturi));
            }
        }
        private ObservableCollection<RftModelTranzactieGeneralGrafic> rftLinieSanatate = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieSanatate
        {
            get { return rftLinieSanatate; }
            set
            {
                rftLinieSanatate = value;
                RftSchimbareProprietate(nameof(RftLinieSanatate));
            }
        }
        private ObservableCollection<RftModelTranzactieGeneralGrafic> rftLinieTransport = new();

        public ObservableCollection<RftModelTranzactieGeneralGrafic> RftLinieTransport
        {
            get { return rftLinieTransport; }
            set
            {
                rftLinieTransport = value;
                RftSchimbareProprietate(nameof(RftLinieTransport));
            }
        }

        private string? rftGraficTitlu = $"Evolutia Generala a Tranzactiilor in Timp";

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

        #region Colectare Date Tabela si Grafic
        private readonly RftServiciuDeDateCumparaturiAlimente<RftModelCumparaturiAlimente> rftServiciuDeDateAlimente = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateCumparaturiElectronice<RftModelCumparaturiElectronice> rftServiciuDeDateElectronice = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateCumparaturiImbracaminte<RftModelCumparaturiImbracaminte> rftServiciuDeDateImbracaminte = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateDivertismentFilme<RftModelDivertismentFilme> rftServiciuDeDateFilme = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateDivertismentJocuri<RftModelDivertismentJocuri> rftServiciuDeDateJocuri = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateDivertismentMuzica<RftModelDivertismentMuzica> rftServiciuDeDateMuzica = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateEducatieCartiElectronice<RftModelEducatieCartiElectronice> rftServiciuDeDateCartiElectronice = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateEducatieEvenimente<RftModelEducatieEvenimente> rftServiciuDeDateEvenimente = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateEducatieInvatamant<RftModelEducatieInvatamant> rftServiciuDeDateInvatamant = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateFacturiApa<RftModelFacturiApa> rftServiciuDeDateApa = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateFacturiCurent<RftModelFacturiCurent> rftServiciuDeDateCurent = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateFacturiTelefonie<RftModelFacturiTelefonie> rftServiciuDeDateTelefonie = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateSanatateActivitatiSportive<RftModelSanatateActivitatiSportive> rftServiciuDeDateActivitatiSportive = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateSanatateMedical<RftModelSanatateMedical> rftServiciuDeDateMedical = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateTransportComun<RftModelTransportComun> rftServiciuDeDateTransportComun = new(new RftContextGeneratorModel());
        private readonly RftServiciuDeDateTransportPersonal<RftModelTransportPersonal> rftServiciuDeDateTransportPersonal = new(new RftContextGeneratorModel());
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

        private readonly string rftVersiuneProgram = $"v{Assembly.GetExecutingAssembly().GetName().Version}";

        public string? RftVerisuneProgram
        {
            get { return rftVersiuneProgram; }
            set { }
        }


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
        public ICommand RftComandaExportPDFContinutPrincipal { get; }
        public ICommand RftComandaExportExcelContinutPrincipal { get; }
        public ICommand RftComandaExportCSVContinutPrincipal { get; }
        public ICommand RftComandaReinitializareTabela { get; }

        public RftVedereModelContinutPrincipala()
        {
            RftColectareDate();
            RftComandaIntervalTimp24ore = new RftComandaIntervalTimpContinutPrincipala(this, 0);
            RftComandaIntervalTimp7zile = new RftComandaIntervalTimpContinutPrincipala(this, 1);
            RftComandaIntervalTimp1luna = new RftComandaIntervalTimpContinutPrincipala(this, 2);
            RftComandaIntervalTimp1an = new RftComandaIntervalTimpContinutPrincipala(this, 3);
            RftComandaIntervalTimpSfert1 = new RftComandaIntervalTimpContinutPrincipala(this, 4);
            RftComandaIntervalTimpSfert2 = new RftComandaIntervalTimpContinutPrincipala(this, 5);
            RftComandaIntervalTimpSfert3 = new RftComandaIntervalTimpContinutPrincipala(this, 6);
            RftComandaIntervalTimpSfert4 = new RftComandaIntervalTimpContinutPrincipala(this, 7);
            RftComandaExportPDFContinutPrincipal = new RftComandaExportPDFContinutPrincipal(this);
            RftComandaExportExcelContinutPrincipal = new RftComandaExportExcelContinutPrincipal(this);
            RftComandaExportCSVContinutPrincipal = new RftComandaExportCSVContinutPrincipal(this);
            RftComandaReinitializareTabela = new RftComandaReinitializareTabelaPrincipala(this);

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
            RftModelCumparaturiAlimenteLista = new ObservableCollection<RftModelCumparaturiAlimente>(rftServiciuDeDateAlimente.RftReturnareObiecteContinutPrincipala().Result);
            RftModelCumparaturiElectroniceLista = new ObservableCollection<RftModelCumparaturiElectronice>(rftServiciuDeDateElectronice.RftReturnareObiecteContinutPrincipala().Result);
            RftModelCumparaturiImbracaminteLista = new ObservableCollection<RftModelCumparaturiImbracaminte>(rftServiciuDeDateImbracaminte.RftReturnareObiecteContinutPrincipala().Result);
            RftModelDivertismentFilmeLista = new ObservableCollection<RftModelDivertismentFilme>(rftServiciuDeDateFilme.RftReturnareObiecteContinutPrincipala().Result);
            RftModelDivertismentJocuriLista = new ObservableCollection<RftModelDivertismentJocuri>(rftServiciuDeDateJocuri.RftReturnareObiecteContinutPrincipala().Result);
            RftModelDivertismentMuzicaLista = new ObservableCollection<RftModelDivertismentMuzica>(rftServiciuDeDateMuzica.RftReturnareObiecteContinutPrincipala().Result);
            RftModelEducatieCartiElectroniceLista = new ObservableCollection<RftModelEducatieCartiElectronice>(rftServiciuDeDateCartiElectronice.RftReturnareObiecteContinutPrincipala().Result);
            RftModelEducatieEvenimenteLista = new ObservableCollection<RftModelEducatieEvenimente>(rftServiciuDeDateEvenimente.RftReturnareObiecteContinutPrincipala().Result);
            RftModelEducatieInvatamantLista = new ObservableCollection<RftModelEducatieInvatamant>(rftServiciuDeDateInvatamant.RftReturnareObiecteContinutPrincipala().Result);
            RftModelFacturiApaLista = new ObservableCollection<RftModelFacturiApa>(rftServiciuDeDateApa.RftReturnareObiecteContinutPrincipala().Result);
            RftModelFacturiCurentLista = new ObservableCollection<RftModelFacturiCurent>(rftServiciuDeDateCurent.RftReturnareObiecteContinutPrincipala().Result);
            RftModelFacturiTelefonieLista = new ObservableCollection<RftModelFacturiTelefonie>(rftServiciuDeDateTelefonie.RftReturnareObiecteContinutPrincipala().Result);
            RftModelSanatateActivitatiSportiveLista = new ObservableCollection<RftModelSanatateActivitatiSportive>(rftServiciuDeDateActivitatiSportive.RftReturnareObiecteContinutPrincipala().Result);
            RftModelSanatateMedicalLista = new ObservableCollection<RftModelSanatateMedical>(rftServiciuDeDateMedical.RftReturnareObiecteContinutPrincipala().Result);
            RftModelTransportComunLista = new ObservableCollection<RftModelTransportComun>(rftServiciuDeDateTransportComun.RftReturnareObiecteContinutPrincipala().Result);
            RftModelTransportPersonalLista = new ObservableCollection<RftModelTransportPersonal>(rftServiciuDeDateTransportPersonal.RftReturnareObiecteContinutPrincipala().Result);

            List<RftModelTranzactieGeneralTabela> x = new();
            foreach (RftModelCumparaturiAlimente? item in RftModelCumparaturiAlimenteLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelCumparaturiElectronice? item in RftModelCumparaturiElectroniceLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelCumparaturiImbracaminte? item in RftModelCumparaturiImbracaminteLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelDivertismentFilme? item in RftModelDivertismentFilmeLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
                    Id = item.Id,
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
                    Id = item.Id,
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
            foreach (RftModelEducatieCartiElectronice? item in RftModelEducatieCartiElectroniceLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelEducatieEvenimente? item in RftModelEducatieEvenimenteLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelEducatieInvatamant? item in RftModelEducatieInvatamantLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelFacturiApa? item in RftModelFacturiApaLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelFacturiCurent? item in RftModelFacturiCurentLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelFacturiTelefonie? item in RftModelFacturiTelefonieLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelSanatateActivitatiSportive? item in RftModelSanatateActivitatiSportiveLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelSanatateMedical? item in RftModelSanatateMedicalLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
            foreach (RftModelTransportComun? item in RftModelTransportComunLista)
            {
                x.Add(new RftModelTranzactieGeneralTabela
                {
                    Id = item.Id,
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
                    Id = item.Id,
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
            #endregion

            x = x.OrderByDescending(o => o.Pret).ToList();

            foreach (RftModelTranzactieGeneralTabela? item in x)
            {
                RftModelTranzactieGeneralTabelaLista.Add(item);
            }

            #region RftCompletareGrafic
            foreach (RftModelCumparaturiAlimente? item in RftModelCumparaturiAlimenteLista)
            {
                RftLinieCumparaturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelCumparaturiElectronice? item in RftModelCumparaturiElectroniceLista)
            {
                RftLinieCumparaturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelCumparaturiImbracaminte? item in RftModelCumparaturiImbracaminteLista)
            {
                RftLinieCumparaturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieCumparaturi.Count != 0)
            {
                RftLinieCumparaturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftCumparaturi, Data = DateTime.Now, Pret = RftLinieCumparaturi.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelDivertismentFilme? item in RftModelDivertismentFilmeLista)
            {
                RftLinieDivertisment.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelDivertismentJocuri? item in RftModelDivertismentJocuriLista)
            {
                RftLinieDivertisment.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelDivertismentMuzica? item in RftModelDivertismentMuzicaLista)
            {
                RftLinieDivertisment.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieDivertisment.Count != 0)
            {
                RftLinieDivertisment.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftDivertisment, Data = DateTime.Now, Pret = RftLinieDivertisment.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelEducatieCartiElectronice? item in RftModelEducatieCartiElectroniceLista)
            {
                RftLinieEducatie.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelEducatieEvenimente? item in RftModelEducatieEvenimenteLista)
            {
                RftLinieEducatie.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelEducatieInvatamant? item in RftModelEducatieInvatamantLista)
            {
                RftLinieEducatie.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieEducatie.Count != 0)
            {
                RftLinieEducatie.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftEducatie, Data = DateTime.Now, Pret = RftLinieEducatie.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelFacturiApa? item in RftModelFacturiApaLista)
            {
                RftLinieFacturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelFacturiCurent? item in RftModelFacturiCurentLista)
            {
                RftLinieFacturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelFacturiTelefonie? item in RftModelFacturiTelefonieLista)
            {
                RftLinieFacturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieFacturi.Count != 0)
            {
                RftLinieFacturi.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftFacturi, Data = DateTime.Now, Pret = RftLinieFacturi.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelSanatateActivitatiSportive? item in RftModelSanatateActivitatiSportiveLista)
            {
                RftLinieSanatate.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelSanatateMedical? item in RftModelSanatateMedicalLista)
            {
                RftLinieSanatate.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieSanatate.Count != 0)
            {
                RftLinieSanatate.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftSanatate, Data = DateTime.Now, Pret = RftLinieSanatate.OrderByDescending(o => o.Data).First().Pret });
            }

            foreach (RftModelTransportComun? item in RftModelTransportComunLista)
            {
                RftLinieTransport.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            foreach (RftModelTransportPersonal? item in RftModelTransportPersonalLista)
            {
                RftLinieTransport.Add(new RftModelTranzactieGeneralGrafic { Categorie = item.Categorie, Pret = item.Pret, Data = item.Data });
            }
            if (RftLinieTransport.Count != 0)
            {
                RftLinieTransport.Add(new RftModelTranzactieGeneralGrafic { Categorie = RftGeneral.RftTransport, Data = DateTime.Now, Pret = RftLinieTransport.OrderByDescending(o => o.Data).First().Pret });
            }
            #endregion
            RftBuget = x.Max(o => o.Pret);
        }

        public void RftStergereDate()
        {
            RftModelCumparaturiAlimenteLista.Clear();
            RftModelCumparaturiElectroniceLista.Clear();
            RftModelCumparaturiImbracaminteLista.Clear();
            RftModelDivertismentFilmeLista.Clear();
            RftModelDivertismentJocuriLista.Clear();
            RftModelDivertismentMuzicaLista.Clear();
            RftModelEducatieCartiElectroniceLista.Clear();
            RftModelEducatieEvenimenteLista.Clear();
            RftModelEducatieInvatamantLista.Clear();
            RftModelFacturiApaLista.Clear();
            RftModelFacturiCurentLista.Clear();
            RftModelFacturiTelefonieLista.Clear();
            RftModelSanatateActivitatiSportiveLista.Clear();
            RftModelSanatateMedicalLista.Clear();
            RftModelTransportComunLista.Clear();
            RftModelTransportPersonalLista.Clear();
            RftModelTranzactieGeneralTabelaLista.Clear();
            RftLinieCumparaturi.Clear();
            RftLinieDivertisment.Clear();
            RftLinieEducatie.Clear();
            RftLinieFacturi.Clear();
            RftLinieSanatate.Clear();
            RftLinieTransport.Clear();
        }
    }
}
