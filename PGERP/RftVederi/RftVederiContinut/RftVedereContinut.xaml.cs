using Microsoft.Maps.MapControl.WPF;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PGERP.RftVederi
{
    /// <summary>
    /// Interaction logic for RftVedereContinut.xaml
    /// </summary>
    public partial class RftVedereContinut : UserControl
    {
        public RftVedereContinut()
        {
            InitializeComponent();
        }

        private async void RftHartaPrincipala_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RftServiciuDeDateLocatii<RftModelLocatie> rftServiciuDeDateLocatii = new(new RftContextGeneratorModel());
            string rftDenumireLocatieNoua = RftCasetaLocatieNoua.Text;

            if (rftDenumireLocatieNoua != "")
            {
                if (rftServiciuDeDateLocatii.RftReturnareDenumireLocatie(rftDenumireLocatieNoua).Result is null)
                {
                    e.Handled = true;

                    Point rftCoordonateApasareButon = e.GetPosition(this);
                    rftCoordonateApasareButon.Y += -100;
                    Location rftLocatieNoua = RftHartaPrincipala.ViewportPointToLocation(rftCoordonateApasareButon);

                    if (RftCasetaLocatieNoua.Text == "Acasa")
                    {
                        Pushpin rftIndicatorNou = new()
                        {
                            Location = rftLocatieNoua,
                            Background = new SolidColorBrush(Color.FromRgb(0, 88, 151)),
                            ToolTip = RftCasetaLocatieNoua.Text
                        };
                    }
                    else
                    {
                        Pushpin rftIndicatorNou = new()
                        {
                            Location = rftLocatieNoua,
                            ToolTip = RftCasetaLocatieNoua.Text
                        };
                    }

                    RftMesajEroareLocatieNoua.Text = "";

                    await rftServiciuDeDateLocatii.RftAdaugareLocatieNoua(new RftModelLocatie
                    {
                        DenumireLocatie = rftDenumireLocatieNoua,
                        Latitudine = rftLocatieNoua.Latitude,
                        Longitudine = rftLocatieNoua.Longitude
                    });

                    RftButonAduagareIndicatorNou.Command.Execute(true);
                    RftCasetaLocatieNoua.Text = "";
                }
                else
                {
                    RftMesajEroareLocatieNoua.Text = RftMesajePredefinite.RftEroareLocatieExistenta;
                    RftCasetaLocatieNoua.Text = "";
                }
            }
            else
            {
                RftMesajEroareLocatieNoua.Text = RftMesajePredefinite.RftEroareLocatieNoua;
                RftCasetaLocatieNoua.Text = "";
            }
        }
    }
}