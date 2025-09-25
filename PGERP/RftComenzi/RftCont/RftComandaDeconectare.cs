using PGERP.RftVederi;
using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PGERP.RftComenzi.RftCont
{
    internal class RftComandaDeconectare : RftComandaBaza
    {
        public RftComandaDeconectare()
        {

        }

        public override void Execute(object? parameter)
        {
            Window window = new RftFereastraAutentificare
            {
                DataContext = new RftVedereModelFereastraAutentificare()
            };
            Application.Current.MainWindow.Close();

            _ = Application.Current.MainWindow = window;
            Application.Current.MainWindow.Show();
        }
    }
}
