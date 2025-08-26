using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftMonthCalendar
{
    public partial class RftMonthCalendarUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftMonthCalendarUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            Form1_Load();
        }

        private void Form1_Load()
        {
            // Change the color.
            monthCalendar1.BackColor = SystemColors.Info;
            monthCalendar1.ForeColor = Color.FromArgb(192, 0, 192);
            monthCalendar1.TitleBackColor = Color.Purple;
            monthCalendar1.TitleForeColor = Color.Yellow;
            monthCalendar1.TrailingForeColor = Color.FromArgb(192, 192, 0);

            // Add dates to the AnnuallyBoldedDates array.
            monthCalendar1.AnnuallyBoldedDates =
            [
                new DateTime(2002, 4, 20, 0, 0, 0, 0),
                new DateTime(2002, 4, 28, 0, 0, 0, 0),
                new DateTime(2002, 5, 5, 0, 0, 0, 0),
                new DateTime(2002, 7, 4, 0, 0, 0, 0),
                new DateTime(2002, 12, 15, 0, 0, 0, 0),
                new DateTime(2002, 12, 18, 0, 0, 0, 0)
            ];

            // Add dates to BoldedDates array.
            monthCalendar1.BoldedDates = [new DateTime(2002, 9, 26, 0, 0, 0, 0)];

            // Add dates to MonthlyBoldedDates array.
            monthCalendar1.MonthlyBoldedDates = [
                new DateTime(2002, 1, 15, 0, 0, 0, 0),
                new DateTime(2002, 1, 30, 0, 0, 0, 0)
            ];

            // Configure the calendar to display 3 rows by 4 columns of months.
            monthCalendar1.CalendarDimensions = new Size(1, 1);

            // Set week to begin on Monday.
            monthCalendar1.FirstDayOfWeek = Day.Monday;

            // Set the maximum visible date on the calendar to 12/31/2010.
            monthCalendar1.MaxDate = new DateTime(2010, 12, 31, 0, 0, 0, 0);

            // Set the minimum visible date on calendar to 12/31/2010.
            monthCalendar1.MinDate = new DateTime(1999, 1, 1, 0, 0, 0, 0);

            // Only allow 21 days to be selected at the same time.
            monthCalendar1.MaxSelectionCount = 7;

            // Set the calendar to move one month at a time when navigating using the arrows.
            monthCalendar1.ScrollChange = 1;

            // Show the week numbers to the left of each week.
            monthCalendar1.ShowWeekNumbers = true;
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Show the start and end dates in the text box.
            textBox1.Text = $"Date Selected: Start = {e.Start.ToShortDateString()} : End = {e.End.ToShortDateString()}";
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Show the start and end dates in the text box.
            textBox1.Text = $"Date Changed: Start = {e.Start.ToShortDateString()} : End = {e.End.ToShortDateString()}";
        }
    }
}
