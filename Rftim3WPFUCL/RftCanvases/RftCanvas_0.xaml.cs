using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Rftim3WPFUCL.RftCanvases
{
    public partial class RftCanvas_0 : UserControl
    {
        public RftCanvas_0()
        {
            InitializeComponent();
            Render();
        }

        private void Render()
        {
            Line l0 = new()
            {
                X1 = 0,
                Y1 = 100,
                X2 = 1000,
                Y2 = 100,
                StrokeThickness = 5,
                Stroke = new SolidColorBrush(Color.FromArgb(150, 0, 150, 255))
            };

            Ellipse e0 = new()
            {
                Width = 50,
                Height = 50,
                Margin = new Thickness(0, 75, 0, 75),
                Fill = new SolidColorBrush(Color.FromRgb(255, 0, 0))
            };

            Ellipse e1 = new()
            {
                Width = 50,
                Height = 50,
                Margin = new Thickness(75, 75, 0, 75),
                Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0))
            };

            Ellipse e2 = new()
            {
                Width = 50,
                Height = 50,
                Margin = new Thickness(150, 75, 0, 75),
                Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255))
            };

            RftCanv.Children.Add(l0);
            RftCanv.Children.Add(e0);
            RftCanv.Children.Add(e1);
            RftCanv.Children.Add(e2);
        }
    }
}
