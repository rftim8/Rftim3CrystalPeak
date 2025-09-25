using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleAutentificare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereAutentificare : RftComandaBaza
    {
        private readonly RftVedereModelFereastraAutentificare rftVedereModelFereastraAutentificare;

        public RftComandaAccesareVedereAutentificare(RftVedereModelFereastraAutentificare rftVedereModelFereastraAutentificare)
        {
            this.rftVedereModelFereastraAutentificare = rftVedereModelFereastraAutentificare;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelFereastraAutentificare.RftVedereModelAutentificareCurent = new RftVedereModelAutentificarePrincipal(rftVedereModelFereastraAutentificare);
        }
    }
}
