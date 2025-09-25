using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PGERP.RftComenzi.RftUtilitare
{
    internal class RftComandaMaximizareFereastra : RftComandaBaza
    {
        public RftComandaMaximizareFereastra()
        {

        }

        public override void Execute(object? parameter)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }
    }
}
