using PGERP.RftComenzi;
using PGERP.RftComenzi.RftCont;
using PGERP.RftComenzi.RftTemaCulori;
using PGERP.RftComenzi.RftUtilitare;
using PGERP.RftModele;
using PGERP.RftSQL;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RftFereastraPrincipala : Window
    {
        public RftFereastraPrincipala()
        {
            InitializeComponent();
        }

        private void RftGrilaMeniuTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.H:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        new RftComandaDocumentatie().Execute(true);
                    }
                    break;
                case Key.F11:
                    new RftComandaMaximizareFereastra().Execute(true);
                    break;
                case Key.M:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        new RftComandaMinimizareFereastra().Execute(true);
                    }
                    break;
                case Key.I:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        new RftComandaSchimbareTemaCulori().Execute(true);
                    }
                    break;
                case Key.L:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        new RftComandaDeconectare().Execute(true);
                    }
                    break;
                case Key.Q:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        new RftComandaIesireProgram().Execute(true);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
