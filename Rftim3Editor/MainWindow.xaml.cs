using Rftim3Editor.GameProject;
using System.Windows;

namespace Rftim3Editor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnMainWindowLoded;
        }

        private void OnMainWindowLoded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnMainWindowLoded;
            OpenProjectBrowserDialog();
        }

        private static void OpenProjectBrowserDialog()
        {
            ProjectBrowserDialog projectBrowserDialog = new();
            if (projectBrowserDialog.ShowDialog() == false)
                Application.Current.Shutdown();
            else { }
        }
    }
}