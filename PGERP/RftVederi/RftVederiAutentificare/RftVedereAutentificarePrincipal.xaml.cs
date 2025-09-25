using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PGERP.RftVederi.RftVederiAutentificare
{
    /// <summary>
    /// Interaction logic for RftVedereAutentificarePrincipal.xaml
    /// </summary>
    public partial class RftVedereAutentificarePrincipal : UserControl
    {
        public RftVedereAutentificarePrincipal()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
        }

        private void RftCasetaParola_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).RftParola = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void RftButonAutentificare_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
