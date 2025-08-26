using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Rftim3WPFUCL.RftBorders
{
    public partial class RftBorder_0 : UserControl
    {
        public RftBorder_0()
        {
            InitializeComponent();
            Border myBorder = new()
            {
                Background = Brushes.LightBlue,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(45),
                Padding = new Thickness(25)
            };
            RftDock.Children.Add(myBorder);
        }
    }
}
