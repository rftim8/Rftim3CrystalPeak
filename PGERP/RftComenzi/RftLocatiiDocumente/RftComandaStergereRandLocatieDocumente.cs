using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftLocatiiDocumente
{
    internal class RftComandaStergereRandLocatieDocumente : RftComandaBaza
    {
        private readonly RftVedereModelSetariLocatii rftVedereModelSetariLocatii;
        private readonly RftServiciuDeDateLocatieDocumente<RftModelLocatieDocumente> rftServiciuDeDateLocatieDocumente = new(new RftContextGeneratorModel());

        public RftComandaStergereRandLocatieDocumente(RftVedereModelSetariLocatii rftVedereModelSetariLocatii)
        {
            this.rftVedereModelSetariLocatii = rftVedereModelSetariLocatii;
        }

        public override async void Execute(object? parameter)
        {
            await rftServiciuDeDateLocatieDocumente.RftStergereLocatieDocumente(rftVedereModelSetariLocatii.RftLocatieSelectata.Id);
            rftVedereModelSetariLocatii.RftLocatii.Remove(rftVedereModelSetariLocatii.RftLocatieSelectata);
        }
    }
}
