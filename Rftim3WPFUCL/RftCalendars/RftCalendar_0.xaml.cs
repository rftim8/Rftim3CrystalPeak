using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Rftim3WPFUCL.RftCalendars
{
    public partial class RftCalendar_0 : UserControl
    {
        public RftCalendar_0()
        {
            InitializeComponent();

            UpdateClockAngles();

            DispatcherTimer timer = new()
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpdateClockAngles();
        }

        private void UpdateClockAngles()
        {
            RftLineHour.RenderTransform = new RotateTransform(DateTime.Now.Hour / 24.0 * 360, 0.5, 0.5);
            RftLineMinute.RenderTransform = new RotateTransform(DateTime.Now.Minute / 60.0 * 360, 0.5, 0.5);
            RftLineSecond.RenderTransform = new RotateTransform(DateTime.Now.Second / 60.0 * 360, 0.5, 0.5);
        }
    }
}
