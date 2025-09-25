using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PGERP.RftComenzi.RftUtilitare
{
    internal class RftComandaIesireProgram : RftComandaBaza
    {
        public RftComandaIesireProgram()
        {

        }

        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
