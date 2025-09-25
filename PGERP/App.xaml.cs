using PGERP.RftComenzi;
using PGERP.RftComenzi.RftTemaCulori;
using PGERP.RftModele;
using PGERP.RftSQL;
using PGERP.RftVederi;
using PGERP.RftVederiModele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace PGERP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ro-RO");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ro-RO");
            
            new RftComandaInitializareStilPrincipal().Execute(true);

            Window rftFereastra = new RftFereastraAutentificare
            {
                DataContext = new RftVedereModelFereastraAutentificare()
            };
            rftFereastra.Show();

            base.OnStartup(e);
        }
    }
}
