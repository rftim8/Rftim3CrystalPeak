using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PGERP.RftComenzi.RftUtilitare
{
    internal class RftComandaMinimizareFereastra : RftComandaBaza
    {
        public RftComandaMinimizareFereastra()
        {

        }

        public override void Execute(object? parameter)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
