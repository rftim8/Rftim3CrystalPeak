using Microsoft.Maps.MapControl.WPF;
using PGERP.RftComenzi.RftAlgoritmi.RftDistributieBuget;
using PGERP.RftComenzi.RftHarta;
using PGERP.RftModele;
using PGERP.RftSQL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Data;
using PGERP.RftComenzi.RftTabela;
using PGERP.RftComenzi.RftTabela.RftTranzactiiModificari;

namespace PGERP.RftVederiModele.RftVederiModeleContinut
{
    internal class RftVedereModelContinut : RftVedereModelBaza
    {
        private readonly RftServiciuDeDateBuget<RftModelBuget> rftServiciuDeDateBuget = new(new RftContextGeneratorModel());
        public RftVedereModelContinutActivitatiSportive rftVedereModelContinutActivitatiSportive;
        public RftVedereModelContinutAlimente rftVedereModelContinutAlimente = new();
        public RftVedereModelContinutApa rftVedereModelContinutApa = new();
        public RftVedereModelContinutCartiElectronice rftVedereModelContinutCartiElectronice = new();
        public RftVedereModelContinutComun rftVedereModelContinutComun = new();
        public RftVedereModelContinutCumparaturi rftVedereModelContinutCumparaturi = new();
        public RftVedereModelContinutCurent rftVedereModelContinutCurent = new();
        public RftVedereModelContinutDivertisment rftVedereModelContinutDivertisment = new();
        public RftVedereModelContinutEducatie rftVedereModelContinutEducatie = new();
        public RftVedereModelContinutElectronice rftVedereModelContinutElectronice = new();
        public RftVedereModelContinutEvenimente rftVedereModelContinutEvenimente = new();
        public RftVedereModelContinutFacturi rftVedereModelContinutFacturi = new();
        public RftVedereModelContinutFilme rftVedereModelContinutFilme = new();
        public RftVedereModelContinutImbracaminte rftVedereModelContinutImbracaminte = new();
        public RftVedereModelContinutInvatamant rftVedereModelContinutInvatamant = new();
        public RftVedereModelContinutJocuri rftVedereModelContinutJocuri = new();
        public RftVedereModelContinutMedical rftVedereModelContinutMedical = new();
        public RftVedereModelContinutMuzica rftVedereModelContinutMuzica = new();
        public RftVedereModelContinutPersonal rftVedereModelContinutPersonal = new();
        public RftVedereModelContinutPrincipala rftVedereModelContinutPrincipala = new();
        public RftVedereModelContinutSanatate rftVedereModelContinutSanatate = new();
        public RftVedereModelContinutTelefonie rftVedereModelContinutTelefonie = new();
        public RftVedereModelContinutTransport rftVedereModelContinutTransport = new();

        private RftVedereModelBaza? rftVedereModelContinutActual;

        public RftVedereModelBaza RftVedereModelContinutActual
        {
            get
            {
                if (rftVedereModelContinutActual is not null)
                {
                    return rftVedereModelContinutActual;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            set
            {
                rftVedereModelContinutActual = value;
                RftSchimbareProprietate(nameof(RftVedereModelContinutActual));
            }
        }

        #region Harta
        private ApplicationIdCredentialsProvider rftCheieHarta = new(RftChei.RftCheieHartaAscunsa);

        public ApplicationIdCredentialsProvider RftCheieHarta
        {
            get { return rftCheieHarta; }
            set
            {
                rftCheieHarta = value;
                RftSchimbareProprietate(nameof(RftCheieHarta));
            }
        }

        private readonly string rftLocatieOriginala = "45.7635499361502,21.2594036370978";

        private string? rftHartaCentru;

        public string RftHartaCentru
        {
            get
            {
                if (rftHartaCentru is not null)
                {
                    return rftHartaCentru;
                }
                else
                {
                    return rftLocatieOriginala;
                }
            }
            set
            {
                rftHartaCentru = value;
                RftSchimbareProprietate(nameof(RftHartaCentru));
            }
        }

        private ObservableCollection<Pushpin>? rftLocatii = new();

        public ObservableCollection<Pushpin> RftLocatii
        {
            get
            {
                if (rftLocatii is not null)
                {
                    return rftLocatii;
                }
                else
                {
                    return new ObservableCollection<Pushpin>();
                }
            }
            set
            {
                rftLocatii = value;
                RftSchimbareProprietate(nameof(RftLocatii));
            }
        }

        private ICollectionView? rftLocatiiFiltrate;

        public ICollectionView? RftLocatiiFiltrate
        {
            get { return rftLocatiiFiltrate; }
            set
            {
                rftLocatiiFiltrate = value;
                RftSchimbareProprietate(nameof(RftLocatiiFiltrate));
            }
        }

        private string? rftFiltruLocatii = string.Empty;

        public string? RftFiltruLocatii
        {
            get { return rftFiltruLocatii; }
            set
            {
                rftFiltruLocatii = value;
                RftSchimbareProprietate(nameof(RftFiltruLocatii));
                RftLocatiiFiltrate.Refresh();
            }
        }

        private Pushpin? rftLocatieSelectata;

        public Pushpin? RftLocatieSelectata
        {
            get { return rftLocatieSelectata; }
            set
            {
                rftLocatieSelectata = value;
                RftSchimbareProprietate(nameof(RftLocatieSelectata));
                if (RftLocatieSelectata is not null)
                {
                    RftHartaCentru = $"{RftLocatieSelectata.Location.Latitude.ToString().Replace(',', '.')},{RftLocatieSelectata.Location.Longitude.ToString().Replace(',', '.')}";
                }
            }
        }

        #endregion

        #region Mesaje Eroare
        private string? rftMesajEroare;

        public string? RftMesajEroare
        {
            get { return rftMesajEroare; }
            set
            {
                rftMesajEroare = value;
                RftSchimbareProprietate(nameof(RftMesajEroare));
            }
        }

        private string? rftMesajEroareLocatieNoua;

        public string? RftMesajEroareLocatieNoua
        {
            get { return rftMesajEroareLocatieNoua; }
            set
            {
                rftMesajEroareLocatieNoua = value;
                RftSchimbareProprietate(nameof(RftMesajEroareLocatieNoua));
            }
        }
        #endregion

        #region Buget Total Actual
        private string? rftBugetTotalActual;

        public string RftBugetTotalActual
        {
            get
            {
                if (rftBugetTotalActual is not null)
                {
                    return rftBugetTotalActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetTotalActual = value;
                RftSchimbareProprietate(nameof(RftBugetTotalActual));
            }
        }
        #endregion
        #region Buget Nealocat

        private string? rftBugetNealocatActual;

        public string RftBugetNealocatActual
        {
            get
            {
                if (rftBugetNealocatActual is not null)
                {
                    return rftBugetNealocatActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetNealocatActual = value;
                RftSchimbareProprietate(nameof(RftBugetNealocatActual));
            }
        }

        private string? rftBugetNealocatTemporar;

        public string RftBugetNealocatTemporar
        {
            get
            {
                if (rftBugetNealocatTemporar is not null)
                {
                    return rftBugetNealocatTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetNealocatTemporar = value;
                RftSchimbareProprietate(nameof(rftBugetNealocatTemporar));
            }
        }
        #endregion

        #region Buget Cumparaturi
        private string? rftBugetCumparaturiActual;

        public string RftBugetCumparaturiActual
        {
            get
            {
                if (rftBugetCumparaturiActual is not null)
                {
                    return rftBugetCumparaturiActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetCumparaturiActual = value;
                RftSchimbareProprietate(nameof(RftBugetCumparaturiActual));
            }
        }
        #endregion
        #region Buget Alimente

        private string? rftBugetAlimenteActual;

        public string RftBugetAlimenteActual
        {
            get
            {
                if (rftBugetAlimenteActual is not null)
                {
                    return rftBugetAlimenteActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetAlimenteActual = value;
                RftSchimbareProprietate(nameof(RftBugetAlimenteActual));
            }
        }

        private string? rftBugetAlimenteTemporar;

        public string RftBugetAlimenteTemporar
        {
            get
            {
                if (rftBugetAlimenteTemporar is not null)
                {
                    return rftBugetAlimenteTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetAlimenteTemporar = value;
                RftSchimbareProprietate(nameof(rftBugetAlimenteTemporar));
            }
        }
        #endregion
        #region Buget Electronice

        private string? rftBugetElectroniceActual;

        public string RftBugetElectroniceActual
        {
            get
            {
                if (rftBugetElectroniceActual is not null)
                {
                    return rftBugetElectroniceActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetElectroniceActual = value;
                RftSchimbareProprietate(nameof(RftBugetElectroniceActual));
            }
        }

        private string? rftBugetElectroniceTemporar;

        public string RftBugetElectroniceTemporar
        {
            get
            {
                if (rftBugetElectroniceTemporar is not null)
                {
                    return rftBugetElectroniceTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetElectroniceTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetElectroniceTemporar));
            }
        }
        #endregion
        #region Buget Imbracaminte

        private string? rftBugetImbracaminteActual;

        public string RftBugetImbracaminteActual
        {
            get
            {
                if (rftBugetImbracaminteActual is not null)
                {
                    return rftBugetImbracaminteActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetImbracaminteActual = value;
                RftSchimbareProprietate(nameof(RftBugetImbracaminteActual));
            }
        }

        private string? rftBugetImbracaminteTemporar;

        public string RftBugetImbracaminteTemporar
        {
            get
            {
                if (rftBugetImbracaminteTemporar is not null)
                {
                    return rftBugetImbracaminteTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetImbracaminteTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetImbracaminteTemporar));
            }
        }
        #endregion

        #region Buget Divertisment
        private string? rftBugetDivertismentActual;

        public string RftBugetDivertismentActual
        {
            get
            {
                if (rftBugetDivertismentActual is not null)
                {
                    return rftBugetDivertismentActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetDivertismentActual = value;
                RftSchimbareProprietate(nameof(RftBugetDivertismentActual));
            }
        }
        #endregion
        #region Buget Filme

        private string? rftBugetFilmeActual;

        public string RftBugetFilmeActual
        {
            get
            {
                if (rftBugetFilmeActual is not null)
                {
                    return rftBugetFilmeActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetFilmeActual = value;
                RftSchimbareProprietate(nameof(RftBugetFilmeActual));
            }
        }

        private string? rftBugetFilmeTemporar;

        public string RftBugetFilmeTemporar
        {
            get
            {
                if (rftBugetFilmeTemporar is not null)
                {
                    return rftBugetFilmeTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetFilmeTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetFilmeTemporar));
            }
        }
        #endregion
        #region Buget Jocuri

        private string? rftBugetJocuriActual;

        public string RftBugetJocuriActual
        {
            get
            {
                if (rftBugetJocuriActual is not null)
                {
                    return rftBugetJocuriActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetJocuriActual = value;
                RftSchimbareProprietate(nameof(RftBugetJocuriActual));
            }
        }

        private string? rftBugetJocuriTemporar;

        public string RftBugetJocuriTemporar
        {
            get
            {
                if (rftBugetJocuriTemporar is not null)
                {
                    return rftBugetJocuriTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetJocuriTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetJocuriTemporar));
            }
        }
        #endregion
        #region Buget Muzica

        private string? rftBugetMuzicaActual;

        public string RftBugetMuzicaActual
        {
            get
            {
                if (rftBugetMuzicaActual is not null)
                {
                    return rftBugetMuzicaActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetMuzicaActual = value;
                RftSchimbareProprietate(nameof(RftBugetMuzicaActual));
            }
        }

        private string? rftBugetMuzicaTemporar;

        public string RftBugetMuzicaTemporar
        {
            get
            {
                if (rftBugetMuzicaTemporar is not null)
                {
                    return rftBugetMuzicaTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetMuzicaTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetMuzicaTemporar));
            }
        }
        #endregion

        #region Buget Educatie
        private string? rftBugetEducatieActual;

        public string RftBugetEducatieActual
        {
            get
            {
                if (rftBugetEducatieActual is not null)
                {
                    return rftBugetEducatieActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetEducatieActual = value;
                RftSchimbareProprietate(nameof(RftBugetEducatieActual));
            }
        }
        #endregion
        #region Buget CartiElectronice

        private string? rftBugetCartiElectroniceActual;

        public string RftBugetCartiElectroniceActual
        {
            get
            {
                if (rftBugetCartiElectroniceActual is not null)
                {
                    return rftBugetCartiElectroniceActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetCartiElectroniceActual = value;
                RftSchimbareProprietate(nameof(RftBugetCartiElectroniceActual));
            }
        }

        private string? rftBugetCartiElectroniceTemporar;

        public string RftBugetCartiElectroniceTemporar
        {
            get
            {
                if (rftBugetCartiElectroniceTemporar is not null)
                {
                    return rftBugetCartiElectroniceTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetCartiElectroniceTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetCartiElectroniceTemporar));
            }
        }
        #endregion
        #region Buget Evenimente

        private string? rftBugetEvenimenteActual;

        public string RftBugetEvenimenteActual
        {
            get
            {
                if (rftBugetEvenimenteActual is not null)
                {
                    return rftBugetEvenimenteActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetEvenimenteActual = value;
                RftSchimbareProprietate(nameof(RftBugetEvenimenteActual));
            }
        }

        private string? rftBugetEvenimenteTemporar;

        public string RftBugetEvenimenteTemporar
        {
            get
            {
                if (rftBugetEvenimenteTemporar is not null)
                {
                    return rftBugetEvenimenteTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetEvenimenteTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetEvenimenteTemporar));
            }
        }
        #endregion
        #region Buget Invatamant

        private string? rftBugetInvatamantActual;

        public string RftBugetInvatamantActual
        {
            get
            {
                if (rftBugetInvatamantActual is not null)
                {
                    return rftBugetInvatamantActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetInvatamantActual = value;
                RftSchimbareProprietate(nameof(RftBugetInvatamantActual));
            }
        }

        private string? rftBugetInvatamantTemporar;

        public string RftBugetInvatamantTemporar
        {
            get
            {
                if (rftBugetInvatamantTemporar is not null)
                {
                    return rftBugetInvatamantTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetInvatamantTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetInvatamantTemporar));
            }
        }
        #endregion

        #region Buget Facturi
        private string? rftBugetFacturiActual;

        public string RftBugetFacturiActual
        {
            get
            {
                if (rftBugetFacturiActual is not null)
                {
                    return rftBugetFacturiActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetFacturiActual = value;
                RftSchimbareProprietate(nameof(RftBugetFacturiActual));
            }
        }
        #endregion
        #region Buget Apa

        private string? rftBugetApaActual;

        public string RftBugetApaActual
        {
            get
            {
                if (rftBugetApaActual is not null)
                {
                    return rftBugetApaActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetApaActual = value;
                RftSchimbareProprietate(nameof(RftBugetApaActual));
            }
        }

        private string? rftBugetApaTemporar;

        public string RftBugetApaTemporar
        {
            get
            {
                if (rftBugetApaTemporar is not null)
                {
                    return rftBugetApaTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetApaTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetApaTemporar));
            }
        }
        #endregion
        #region Buget Curent

        private string? rftBugetCurentActual;

        public string RftBugetCurentActual
        {
            get
            {
                if (rftBugetCurentActual is not null)
                {
                    return rftBugetCurentActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetCurentActual = value;
                RftSchimbareProprietate(nameof(RftBugetCurentActual));
            }
        }

        private string? rftBugetCurentTemporar;

        public string RftBugetCurentTemporar
        {
            get
            {
                if (rftBugetCurentTemporar is not null)
                {
                    return rftBugetCurentTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetCurentTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetCurentTemporar));
            }
        }
        #endregion
        #region Buget Telefonie

        private string? rftBugetTelefonieActual;

        public string RftBugetTelefonieActual
        {
            get
            {
                if (rftBugetTelefonieActual is not null)
                {
                    return rftBugetTelefonieActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetTelefonieActual = value;
                RftSchimbareProprietate(nameof(RftBugetTelefonieActual));
            }
        }

        private string? rftBugetTelefonieTemporar;

        public string RftBugetTelefonieTemporar
        {
            get
            {
                if (rftBugetTelefonieTemporar is not null)
                {
                    return rftBugetTelefonieTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetTelefonieTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetTelefonieTemporar));
            }
        }
        #endregion

        #region Buget Sanatate
        private string? rftBugetSanatateActual;

        public string RftBugetSanatateActual
        {
            get
            {
                if (rftBugetSanatateActual is not null)
                {
                    return rftBugetSanatateActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetSanatateActual = value;
                RftSchimbareProprietate(nameof(RftBugetSanatateActual));
            }
        }
        #endregion
        #region Buget ActivitatiSportive

        private string? rftBugetActivitatiSportiveActual;

        public string RftBugetActivitatiSportiveActual
        {
            get
            {
                if (rftBugetActivitatiSportiveActual is not null)
                {
                    return rftBugetActivitatiSportiveActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetActivitatiSportiveActual = value;
                RftSchimbareProprietate(nameof(RftBugetActivitatiSportiveActual));
            }
        }

        private string? rftBugetActivitatiSportiveTemporar;

        public string RftBugetActivitatiSportiveTemporar
        {
            get
            {
                if (rftBugetActivitatiSportiveTemporar is not null)
                {
                    return rftBugetActivitatiSportiveTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetActivitatiSportiveTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetActivitatiSportiveTemporar));
            }
        }
        #endregion
        #region Buget Medical

        private string? rftBugetMedicalActual;

        public string RftBugetMedicalActual
        {
            get
            {
                if (rftBugetMedicalActual is not null)
                {
                    return rftBugetMedicalActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetMedicalActual = value;
                RftSchimbareProprietate(nameof(RftBugetMedicalActual));
            }
        }

        private string? rftBugetMedicalTemporar;

        public string RftBugetMedicalTemporar
        {
            get
            {
                if (rftBugetMedicalTemporar is not null)
                {
                    return rftBugetMedicalTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetMedicalTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetMedicalTemporar));
            }
        }
        #endregion

        #region Buget Transport
        private string? rftBugetTransportActual;

        public string RftBugetTransportActual
        {
            get
            {
                if (rftBugetTransportActual is not null)
                {
                    return rftBugetTransportActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetTransportActual = value;
                RftSchimbareProprietate(nameof(RftBugetTransportActual));
            }
        }
        #endregion
        #region Buget Comun
        private string? rftBugetComunActual;

        public string RftBugetComunActual
        {
            get
            {
                if (rftBugetComunActual is not null)
                {
                    return rftBugetComunActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetComunActual = value;
                RftSchimbareProprietate(nameof(RftBugetComunActual));
            }
        }

        private string? rftBugetComunTemporar;

        public string RftBugetComunTemporar
        {
            get
            {
                if (rftBugetComunTemporar is not null)
                {
                    return rftBugetComunTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetComunTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetComunTemporar));
            }
        }
        #endregion
        #region Buget Personal

        private string? rftBugetPersonalActual;

        public string RftBugetPersonalActual
        {
            get
            {
                if (rftBugetPersonalActual is not null)
                {
                    return rftBugetPersonalActual;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetPersonalActual = value;
                RftSchimbareProprietate(nameof(RftBugetPersonalActual));
            }
        }

        private string? rftBugetPersonalTemporar;

        public string RftBugetPersonalTemporar
        {
            get
            {
                if (rftBugetPersonalTemporar is not null)
                {
                    return rftBugetPersonalTemporar;
                }
                else
                {
                    return "0";
                }
            }
            set
            {
                rftBugetPersonalTemporar = value;
                RftSchimbareProprietate(nameof(RftBugetPersonalTemporar));
            }
        }
        #endregion

        #region Extindere Meniu Buget
        private bool rftRandExtins;
        public bool RftRandExtins
        {
            get => rftRandExtins;
            set
            {
                rftRandExtins = value;
                RftSchimbareProprietate(nameof(RftRandExtins));
            }
        }
        #endregion

        #region Comenzi
        public ICommand RftComandaAdaugareIndicatorNou { get; }
        public ICommand RftComandaSetareBugetNealocat { get; }
        public ICommand RftComandaSetareBugetAlimente { get; }
        public ICommand RftComandaSetareBugetElectronice { get; }
        public ICommand RftComandaSetareBugetImbracaminte { get; }
        public ICommand RftComandaSetareBugetFilme { get; }
        public ICommand RftComandaSetareBugetJocuri { get; }
        public ICommand RftComandaSetareBugetMuzica { get; }
        public ICommand RftComandaSetareBugetCartiElectronice { get; }
        public ICommand RftComandaSetareBugetEvenimente { get; }
        public ICommand RftComandaSetareBugetInvatamant { get; }
        public ICommand RftComandaSetareBugetApa { get; }
        public ICommand RftComandaSetareBugetCurent { get; }
        public ICommand RftComandaSetareBugetTelefonie { get; }
        public ICommand RftComandaSetareBugetActivitatiSportive { get; }
        public ICommand RftComandaSetareBugetMedical { get; }
        public ICommand RftComandaSetareBugetPersonal { get; }
        public ICommand RftComandaSetareBugetComun { get; }
        public ICommand RftComandaStergereRand { get; }
        #endregion

        public RftVedereModelContinut()
        {
            RftColectareDate();
            RftComandaAdaugareIndicatorNou = new RftComandaAdaugareIndicatorNou(this);
            RftComandaSetareBugetNealocat = new RftComandaSetareBugetNealocat(this, rftVedereModelContinutPrincipala);
            RftComandaSetareBugetAlimente = new RftComandaSetareBugetAlimente(this);
            RftComandaSetareBugetElectronice = new RftComandaSetareBugetElectronice(this);
            RftComandaSetareBugetImbracaminte = new RftComandaSetareBugetImbracaminte(this);
            RftComandaSetareBugetFilme = new RftComandaSetareBugetFilme(this);
            RftComandaSetareBugetJocuri = new RftComandaSetareBugetJocuri(this);
            RftComandaSetareBugetMuzica = new RftComandaSetareBugetMuzica(this);
            RftComandaSetareBugetCartiElectronice = new RftComandaSetareBugetCartiElectronice(this);
            RftComandaSetareBugetEvenimente = new RftComandaSetareBugetEvenimente(this);
            RftComandaSetareBugetInvatamant = new RftComandaSetareBugetInvatamant(this);
            RftComandaSetareBugetApa = new RftComandaSetareBugetApa(this);
            RftComandaSetareBugetCurent = new RftComandaSetareBugetCurent(this);
            RftComandaSetareBugetTelefonie = new RftComandaSetareBugetTelefonie(this);
            RftComandaSetareBugetActivitatiSportive = new RftComandaSetareBugetActivitatiSportive(this);
            RftComandaSetareBugetMedical = new RftComandaSetareBugetMedical(this);
            RftComandaSetareBugetPersonal = new RftComandaSetareBugetPersonal(this);
            RftComandaSetareBugetComun = new RftComandaSetareBugetComun(this);
            rftVedereModelContinutActivitatiSportive = new RftVedereModelContinutActivitatiSportive(this);

            RftVedereModelContinutActual = rftVedereModelContinutPrincipala;

            RftComandaStergereRand = new RftComandaStergereRand(this);

            RftLocatiiFiltrate = CollectionViewSource.GetDefaultView(RftLocatii);
            RftLocatiiFiltrate.Filter = RftFiltrareLocatii;
        }

        private bool RftFiltrareLocatii(object obj)
        {
            if (obj is Pushpin pushpin)
            {
                return pushpin.ToolTip.ToString().Contains(RftFiltruLocatii, StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        private void RftColectareDate()
        {
            RftModelBuget rftBuget = rftServiciuDeDateBuget.RftReturnareObiectId(1).Result;
            RftBugetTotalActual = rftBuget.Total.ToString();
            RftBugetNealocatActual = rftBuget.Nealocat.ToString();
            RftBugetCumparaturiActual = rftBuget.Cumparaturi.ToString();
            RftBugetDivertismentActual = rftBuget.Divertisment.ToString();
            RftBugetEducatieActual = rftBuget.Educatie.ToString();
            RftBugetFacturiActual = rftBuget.Facturi.ToString();
            RftBugetSanatateActual = rftBuget.Sanatate.ToString();
            RftBugetTransportActual = rftBuget.Transport.ToString();
            RftBugetAlimenteActual = rftBuget.CumparaturiAlimente.ToString();
            RftBugetElectroniceActual = rftBuget.CumparaturiElectronice.ToString();
            RftBugetImbracaminteActual = rftBuget.CumparaturiImbracaminte.ToString();
            RftBugetFilmeActual = rftBuget.DivertismentFilme.ToString();
            RftBugetJocuriActual = rftBuget.DivertismentJocuri.ToString();
            RftBugetMuzicaActual = rftBuget.DivertismentMuzica.ToString();
            RftBugetCartiElectroniceActual = rftBuget.EducatieCartiElectronice.ToString();
            RftBugetEvenimenteActual = rftBuget.EducatieEvenimente.ToString();
            RftBugetInvatamantActual = rftBuget.EducatieInvatamant.ToString();
            RftBugetApaActual = rftBuget.FacturiApa.ToString();
            RftBugetCurentActual = rftBuget.FacturiCurent.ToString();
            RftBugetTelefonieActual = rftBuget.FacturiTelefonie.ToString();
            RftBugetActivitatiSportiveActual = rftBuget.SanatateActivitatiSportive.ToString();
            RftBugetMedicalActual = rftBuget.SanatateMedical.ToString();
            RftBugetComunActual = rftBuget.TransportComun.ToString();
            RftBugetPersonalActual = rftBuget.TransportPersonal.ToString();

            RftServiciuDeDateLocatii<RftModelLocatie> rftServiciuDeDateLocatii = new(new RftContextGeneratorModel());

            List<RftModelLocatie> x = rftServiciuDeDateLocatii.RftReturnareLocatii().Result.ToList();

            RftLocatii.Clear();
            foreach (RftModelLocatie? item in x)
            {
                if (item.DenumireLocatie == "Acasa")
                {
                    RftLocatii.Add(new Pushpin
                    {
                        Location = new(item.Latitudine, item.Longitudine),
                        Background = new SolidColorBrush(Color.FromRgb(0, 88, 151)),
                        ToolTip = item.DenumireLocatie
                    }
                    );
                }
                else
                {
                    RftLocatii.Add(new Pushpin
                    {
                        Location = new(item.Latitudine, item.Longitudine),
                        ToolTip = item.DenumireLocatie
                    }
                    );
                }
            }
        }
    }
}
