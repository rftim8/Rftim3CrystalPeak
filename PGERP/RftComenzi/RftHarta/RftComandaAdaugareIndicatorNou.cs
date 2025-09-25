using Microsoft.Maps.MapControl.WPF;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederiModele.RftVederiModeleContinut;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PGERP.RftComenzi.RftHarta
{
    internal class RftComandaAdaugareIndicatorNou : RftComandaBaza
    {
        private readonly RftVedereModelContinut rftVedereModelContinut;

        public RftComandaAdaugareIndicatorNou(RftVedereModelContinut rftVedereModelContinut)
        {
            this.rftVedereModelContinut = rftVedereModelContinut;
        }

        public override void Execute(object? parameter)
        {
            RftServiciuDeDateLocatii<RftModelLocatie> rftServiciuDeDateLocatii = new(new RftContextGeneratorModel());

            List<RftModelLocatie> x = rftServiciuDeDateLocatii.RftReturnareLocatii().Result.ToList();

            rftVedereModelContinut.RftLocatii.Clear();
            foreach (RftModelLocatie? item in x)
            {
                if (item.DenumireLocatie == "Acasa")
                {
                    rftVedereModelContinut.RftLocatii.Add(new Pushpin
                    {
                        Location = new(item.Latitudine, item.Longitudine),
                        Background = new SolidColorBrush(Color.FromRgb(0, 88, 151)),
                        ToolTip = item.DenumireLocatie
                    });
                }
                else
                {
                    rftVedereModelContinut.RftLocatii.Add(new Pushpin
                    {
                        Location = new(item.Latitudine, item.Longitudine),
                        ToolTip = item.DenumireLocatie
                    });
                }
            }
        }
    }
}
