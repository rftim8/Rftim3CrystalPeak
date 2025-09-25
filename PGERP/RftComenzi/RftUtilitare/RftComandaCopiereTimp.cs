using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PGERP.RftComenzi.RftUtilitare
{
    internal class RftComandaCopiereTimp : RftComandaBaza
    {
        private readonly RftVedereModelMeniuBottom rftVedereModelMeniuBottom;

        public RftComandaCopiereTimp(RftVedereModelMeniuBottom rftVedereModelMeniuBottom)
        {
            this.rftVedereModelMeniuBottom = rftVedereModelMeniuBottom;
        }

        public override void Execute(object? parameter)
        {
            Clipboard.SetText(rftVedereModelMeniuBottom.RftTimpCurent);
        }
    }
}
