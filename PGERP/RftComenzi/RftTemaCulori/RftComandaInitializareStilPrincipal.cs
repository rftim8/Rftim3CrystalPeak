using PGERP.RftModele;
using PGERP.RftSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PGERP.RftComenzi.RftTemaCulori
{
    internal class RftComandaInitializareStilPrincipal : RftComandaBaza
    {
        private readonly ResourceDictionary RftTemaCuloriInchise = new();
        private readonly ResourceDictionary RftTemaCuloriDeschise = new();
        private readonly IRftServiciuDeDate<RftModelTemaCulori> rftServiciuDeDate = new RftServiciuDeDateGeneric<RftModelTemaCulori>(new RftContextGeneratorModel());
        public RftComandaInitializareStilPrincipal()
        {
            RftTemaCuloriInchise.Source = new Uri("/RftStiluri/RftGeneral/RftTemaCuloriInchise.xaml", UriKind.Relative);
            RftTemaCuloriDeschise.Source = new Uri("/RftStiluri/RftGeneral/RftTemaCuloriDeschise.xaml", UriKind.Relative);
        }

        public override void Execute(object? parameter)
        {
            int x = rftServiciuDeDate.RftReturnareObiecte().Result.Count();

            if (x == 0)
            {
                rftServiciuDeDate.RftAdaugareObiect(new RftModelTemaCulori { CuloriDeschise = true, CuloriInchise = false });
            }

            bool rftCuloriInchise = rftServiciuDeDate.RftReturnareObiectId(1).Result.CuloriInchise;
            bool rftCuloriDeschise = rftServiciuDeDate.RftReturnareObiectId(1).Result.CuloriDeschise;

            if (rftCuloriDeschise)
            {
                Application.Current.Resources.MergedDictionaries.Add(RftTemaCuloriDeschise);

            }
            else if (rftCuloriInchise)
            {
                Application.Current.Resources.MergedDictionaries.Add(RftTemaCuloriInchise);
            }
        }
    }
}
