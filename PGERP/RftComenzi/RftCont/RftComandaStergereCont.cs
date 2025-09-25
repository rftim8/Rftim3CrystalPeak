using PGERP.RftModele;
using PGERP.RftSQL;
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
    internal class RftComandaStergereCont : RftComandaBaza
    {
        private readonly RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat;
        private readonly RftServiciuDeDateUtilizatori<RftModelUtilizatori> rftServiciuDeDateUtilizatori = new(new RftContextGeneratorModel());

        public RftComandaStergereCont(RftModelUtilizatorAutentificat rftModelUtilizatorAutentificat)
        {
            this.rftModelUtilizatorAutentificat = rftModelUtilizatorAutentificat;
        }

        public override async void Execute(object? parameter)
        {
            string rftUtilizator = rftModelUtilizatorAutentificat.RftUtilizator;

            if (!string.IsNullOrEmpty(rftUtilizator))
            {
                await rftServiciuDeDateUtilizatori.RftStergereObiect(rftUtilizator);

                rftModelUtilizatorAutentificat.RftUtilizator = "";

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
}
