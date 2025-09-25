using Microsoft.Maps.MapControl.WPF;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftTabela
{
    internal class RftComandaStergereRand : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;
        private readonly RftServiciuDeDateLocatii<RftModelLocatie> rftServiciuDeDateLocatii = new(new RftContextGeneratorModel());


        public RftComandaStergereRand(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override async void Execute(object? parameter)
        {
            await rftServiciuDeDateLocatii.RftStergereLocatie(rftVedereModelContinut.RftLocatieSelectata.ToolTip.ToString());

            rftVedereModelContinut.RftLocatii.Remove(rftVedereModelContinut.RftLocatieSelectata);
        }
    }
}
