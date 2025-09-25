using PGERP.RftComenzi.RftUtilitare;
using PGERPBiblioteca.RftMesaje;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace PGERP.RftVederiModele
{
    internal class RftVedereModelMeniuBottom : RftVedereModelBaza
    {
        private readonly DispatcherTimer RftDispatcherTimerTimpCurent = new();

        private string? rftTimpCurent;

        public string RftTimpCurent
        {
            get
            {
                if (rftTimpCurent is not null)
                {
                    return rftTimpCurent;
                }
                else
                {
                    return "";
                }
            }
            set
            {
                rftTimpCurent = value;
                RftSchimbareProprietate(nameof(RftTimpCurent));
            }
        }

        #region Setare Mseaj Timp
        private readonly string rftMesajCopiere = RftMesajePredefinite.RftCopiere;

        public string RftMesajCopiere
        {
            get { return rftMesajCopiere; }
            set { }
        }
        #endregion

        public ICommand RftComandaCopiereTimp { get; }

        public RftVedereModelMeniuBottom()
        {
            RftComandaCopiereTimp = new RftComandaCopiereTimp(this);
            RftSetareCeas();
        }

        #region Setare Cronometru Timp Curent
        private void RftSetareCeas()
        {
            RftDispatcherTimerTimpCurent.Interval = TimeSpan.FromSeconds(1);
            RftDispatcherTimerTimpCurent.Tick += RftTimpCurentTick;
            RftDispatcherTimerTimpCurent.Start();
        }

        private void RftTimpCurentTick(object? sender, EventArgs e)
        {
            RftTimpCurent = DateTime.Now.ToString();
        }
        #endregion

    }
}
