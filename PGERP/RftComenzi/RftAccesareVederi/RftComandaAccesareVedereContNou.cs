using PGERP.RftVederiModele;
using PGERP.RftVederiModele.RftVederiModeleAutentificare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftAccesareVederi
{
    internal class RftComandaAccesareVedereContNou : RftComandaBaza
    {
        private readonly RftVedereModelFereastraAutentificare rftVedereModelFereastraAutentificare;

        public RftComandaAccesareVedereContNou(RftVedereModelFereastraAutentificare rftVedereModelFereastraAutentificare)
        {
            this.rftVedereModelFereastraAutentificare = rftVedereModelFereastraAutentificare;
        }

        public override void Execute(object? parameter)
        {
            rftVedereModelFereastraAutentificare.RftVedereModelAutentificareCurent = new RftVedereModelAutentificareContNou(rftVedereModelFereastraAutentificare);
        }
    }
}
