using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereSetariCont : RftComandaBaza
    {
        private readonly RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala;
        private readonly RftVedereModelSetariCont rftVedereModelSetariCont;
        private readonly RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat;
        private readonly RftServiciuDeDateUtilizatori<RftModelUtilizatori> rftServiciuDeDateUtilizatori = new(new RftContextGeneratorModel());

        public RftComandaAccesareVedereSetariCont(RftVedereModelFereastraPrincipala rftVedereModelFereastraPrincipala,
            RftVedereModelSetariCont rftVedereModelSetariCont,
            RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat)
        {
            this.rftVedereModelFereastraPrincipala = rftVedereModelFereastraPrincipala;
            this.rftVedereModelSetariCont = rftVedereModelSetariCont;
            this.rftModelUtilizatorAutentificat = rftModelUtilizatorAutentificat;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelFereastraPrincipala.RftVedereModelContinutCurent = rftVedereModelFereastraPrincipala.RftVedereModelSetariCont;

            RftModelUtilizatori x = rftServiciuDeDateUtilizatori.RftReturnareUtilizatorAutentificat(rftModelUtilizatorAutentificat.RftUtilizator).Result;

            rftVedereModelSetariCont.RftNume = x.Nume.ToString();
            rftVedereModelSetariCont.RftPrenume = x.Prenume.ToString();
            rftVedereModelSetariCont.RftEmail = x.Email.ToString();

            rftVedereModelSetariCont.RftMesajStareModificareCont = "";
            rftVedereModelSetariCont.RftMesajStareModificareContSucces = "";
        }
    }
}
