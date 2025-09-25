using PGERP.RftComenzi;
using PGERP.RftComenzi.RftAccesareVederi;
using PGERP.RftComenzi.RftCont;
using PGERP.RftComenzi.RftTemaCulori;
using PGERP.RftComenzi.RftUtilitare;
using PGERP.RftModele;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using PGERP.RftVederiModele.RftVederiModeleMeniuStanga;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PGERP.RftVederiModele
{
    internal class RftVedereModelMeniuTop : RftVedereModelBaza
    {
        #region Comenzi pentru Accesare Vederi
        public ICommand RftComandaAccesareVedereContinutCumparaturi { get; }
        public ICommand RftComandaAccesareVedereContinutDivertisment { get; }
        public ICommand RftComandaAccesareVedereContinutEducatie { get; }
        public ICommand RftComandaAccesareVedereContinutFacturi { get; }
        public ICommand RftComandaAccesareVedereContinutSanatate { get; }
        public ICommand RftComandaAccesareVedereContinutTransport { get; }
        public ICommand RftComandaAccesareVedereContinutPrincipal { get; }
        public ICommand RftComandaAccesareVedereSetariCont { get; }
        public ICommand RftComandaAccesareVedereSetariLocatii { get; }
        #endregion

        private string? rftNumeUtilizator;

        public string? RftNumeUtilizator
        {
            get { return rftNumeUtilizator; }
            set { rftNumeUtilizator = value; }
        }

        #region Comenzi Utilitare
        public ICommand RftComandaDocumentatie { get; }
        public ICommand RftComandaDeconectare { get; }
        public ICommand RftComandaSchimbareTemaCulori { get; }
        public ICommand RftComandaMinimizareFereastra { get; }
        public ICommand RftComandaMaximizareFereastra { get; }
        public ICommand RftComandaIesireProgram { get; }
        #endregion

        #region Setare Mesaje Utilitare
        private readonly string rftMesajLuminozitate = RftMesajePredefinite.RftLuminozitate;

        public string RftMesajLuminozitate
        {
            get { return rftMesajLuminozitate; }
            set { }
        }

        private readonly string rftMesajMinimizare = RftMesajePredefinite.RftMinimizare;

        public string RftMesajMinimizare
        {
            get { return rftMesajMinimizare; }
            set { }
        }

        private readonly string rftMesajMaximizare = RftMesajePredefinite.RftMaximizare;

        public string RftMesajMaximizare
        {
            get { return rftMesajMaximizare; }
            set { }
        }

        private readonly string rftMesajIesire = RftMesajePredefinite.RftIesire;

        public string RftMesajIesire
        {
            get { return rftMesajIesire; }
            set { }
        }
        #endregion

        public RftVedereModelMeniuTop(RftVedereModelContinut rftVedereModelContinut,
            RftVedereModelMeniuStanga rftVedereModelMeniuStanga,
            RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala,
            RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat,
            RftVedereModelSetariCont rftVedereModelSetariCont,
            RftVedereModelSetariLocatii rftVedereModelSetariLocatii)
        {
            #region Initializare Comenzi
            RftComandaAccesareVedereContinutCumparaturi = new RftComandaAccesareVedereContinutCumparaturi(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                rftVedereModelFereastraPrincipala
                );
            RftComandaAccesareVedereContinutDivertisment = new RftComandaAccesareVedereContinutDivertisment(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                rftVedereModelFereastraPrincipala
                );
            RftComandaAccesareVedereContinutEducatie = new RftComandaAccesareVedereContinutEducatie(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                rftVedereModelFereastraPrincipala
                );
            RftComandaAccesareVedereContinutFacturi = new RftComandaAccesareVedereContinutFacturi(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                rftVedereModelFereastraPrincipala
                );
            RftComandaAccesareVedereContinutSanatate = new RftComandaAccesareVedereContinutSanatate(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                rftVedereModelFereastraPrincipala
                );
            RftComandaAccesareVedereContinutTransport = new RftComandaAccesareVedereContinutTransport(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                rftVedereModelFereastraPrincipala
                );
            RftComandaAccesareVedereContinutPrincipal = new RftComandaAccesareVedereContinutPrincipal(
                rftVedereModelContinut,
                rftVedereModelMeniuStanga,
                rftVedereModelFereastraPrincipala
                );

            RftComandaDocumentatie = new RftComandaDocumentatie();
            RftComandaAccesareVedereSetariCont = new RftComandaAccesareVedereSetariCont(
                rftVedereModelFereastraPrincipala,
                rftVedereModelSetariCont,
                rftModelUtilizatorAutentificat
                );
            RftComandaAccesareVedereSetariLocatii = new RftComandaAccesareVedereSetariLocatii(rftVedereModelFereastraPrincipala, rftVedereModelSetariLocatii);
            RftComandaDeconectare = new RftComandaDeconectare();
            RftComandaSchimbareTemaCulori = new RftComandaSchimbareTemaCulori();
            RftComandaMinimizareFereastra = new RftComandaMinimizareFereastra();
            RftComandaMaximizareFereastra = new RftComandaMaximizareFereastra();
            RftComandaIesireProgram = new RftComandaIesireProgram();

            RftNumeUtilizator = rftModelUtilizatorAutentificat.RftUtilizator;
            #endregion
        }
    }
}
