using PGERP.RftModele;
using PGERP.RftSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PGERP.RftComenzi.RftTemaCulori
{
    internal class RftComandaSchimbareTemaCulori : RftComandaBaza
    {
        private readonly ResourceDictionary RftTemaCuloriInchise = new();
        private readonly ResourceDictionary RftTemaCuloriDeschise = new();
        private readonly IRftServiciuDeDate<RftModelTemaCulori> rftServiciuDeDate = new RftServiciuDeDateGeneric<RftModelTemaCulori>(new RftContextGeneratorModel());

        public RftComandaSchimbareTemaCulori()
        {
            RftTemaCuloriInchise.Source = new Uri("/RftStiluri/RftGeneral/RftTemaCuloriInchise.xaml", UriKind.Relative);
            RftTemaCuloriDeschise.Source = new Uri("/RftStiluri/RftGeneral/RftTemaCuloriDeschise.xaml", UriKind.Relative);
        }

        public override void Execute(object? parameter)
        {
            bool rftCuloriInchise = rftServiciuDeDate.RftReturnareObiectId(1).Result.CuloriInchise;
            bool rftCuloriDeschise = rftServiciuDeDate.RftReturnareObiectId(1).Result.CuloriDeschise;

            if (rftCuloriDeschise)
            {
                if (Application.Current.Resources.MergedDictionaries.Contains(RftTemaCuloriDeschise))
                {
                    _ = Application.Current.Resources.MergedDictionaries.Remove(RftTemaCuloriDeschise);
                }
                rftServiciuDeDate.RftActualizareObiect(1, new RftModelTemaCulori { CuloriDeschise = false, CuloriInchise = true });
                if (!Application.Current.Resources.MergedDictionaries.Contains(RftTemaCuloriInchise))
                {
                    Application.Current.Resources.MergedDictionaries.Add(RftTemaCuloriInchise);
                }
            }
            else if (rftCuloriInchise)
            {
                if (Application.Current.Resources.MergedDictionaries.Contains(RftTemaCuloriInchise))
                {
                    _ = Application.Current.Resources.MergedDictionaries.Remove(RftTemaCuloriInchise);
                }

                rftServiciuDeDate.RftActualizareObiect(1, new RftModelTemaCulori { CuloriInchise = false, CuloriDeschise = true });

                if (!Application.Current.Resources.MergedDictionaries.Contains(RftTemaCuloriDeschise))
                {
                    Application.Current.Resources.MergedDictionaries.Add(RftTemaCuloriDeschise);
                }
            }
        }
    }
}
