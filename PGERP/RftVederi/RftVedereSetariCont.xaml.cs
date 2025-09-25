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

namespace PGERP.RftVederi
{
    /// <summary>
    /// Interaction logic for RftVedereSetariCont.xaml
    /// </summary>
    public partial class RftVedereSetariCont : UserControl
    {
        public RftVedereSetariCont()
        {
            InitializeComponent();
        }

        private void RftCasetaParola_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic)DataContext).RftParola = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
