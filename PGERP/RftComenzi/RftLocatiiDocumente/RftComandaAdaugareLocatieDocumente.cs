using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGERP.RftComenzi.RftLocatiiDocumente
{
    internal class RftComandaAdaugareLocatieDocumente : RftComandaBaza
    {
        private readonly RftVedereModelSetariLocatii rftVedereModelSetariLocatii;
        private readonly RftServiciuDeDateLocatieDocumente<RftModelLocatieDocumente> rftServiciuDeDateLocatieDocumente = new(new RftContextGeneratorModel());

        public RftComandaAdaugareLocatieDocumente(RftVedereModelSetariLocatii rftVedereModelSetariLocatii)
        {
            this.rftVedereModelSetariLocatii = rftVedereModelSetariLocatii;
        }

        public override async void Execute(object? parameter)
        {
            rftVedereModelSetariLocatii.RftMesajStareModificareLocatie = "";

            if (string.IsNullOrEmpty(rftVedereModelSetariLocatii.RftDenumire))
            {
                rftVedereModelSetariLocatii.RftMesajStareModificareLocatie = RftMesajePredefinite.RftEroareDenumireLocatieCampNecesar;
                return;
            }

            if (string.IsNullOrEmpty(rftVedereModelSetariLocatii.RftLocatie))
            {
                rftVedereModelSetariLocatii.RftMesajStareModificareLocatie = RftMesajePredefinite.RftEroareLocatieDocumente;
                return;
            }

            RftModelLocatieDocumente q = rftServiciuDeDateLocatieDocumente.RftReturnareLocatieDenumire(rftVedereModelSetariLocatii.RftDenumire).Result;

            if (q is not null)
            {
                rftVedereModelSetariLocatii.RftMesajStareModificareLocatie = RftMesajePredefinite.RftEroareDenumireLocatieDocumente;
                return;
            }

            rftVedereModelSetariLocatii.RftLocatii.Clear();

            RftModelLocatieDocumente x = new()
            {
                Denumire = rftVedereModelSetariLocatii.RftDenumire,
                Locatie = rftVedereModelSetariLocatii.RftLocatie
            };

            await rftServiciuDeDateLocatieDocumente.RftAdaugareLocatie(x);

            List<RftModelLocatieDocumente> y = rftServiciuDeDateLocatieDocumente.RftReturnareLocatii().Result.ToList();

            foreach (RftModelLocatieDocumente item in y)
            {
                rftVedereModelSetariLocatii.RftLocatii.Add(item);
            }
        }
    }
}
