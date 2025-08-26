using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftSystemInformation
{
    public partial class RftSystemInformationUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftSystemInformationUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            GatherSystemInformation();
        }

        private void GatherSystemInformation()
        {
            textBox1.Text = $"System{Environment.NewLine}{Environment.NewLine}" +
                $"Computer name: {SystemInformation.ComputerName}{Environment.NewLine}" +
                $"Username: {SystemInformation.UserName}{Environment.NewLine}" +
                $"User Domain Name: {SystemInformation.UserDomainName}{Environment.NewLine}" +
                $"Boot Mode: {SystemInformation.BootMode}{Environment.NewLine}" +
                $"Monitor Count: {SystemInformation.MonitorCount}{Environment.NewLine}" +
                $"Resolution: {SystemInformation.PrimaryMonitorSize.Width} x {SystemInformation.PrimaryMonitorSize.Height}{Environment.NewLine}" +
                $"Battery Status: {SystemInformation.PowerStatus.BatteryChargeStatus}{Environment.NewLine}" +
                $"Power Line: {SystemInformation.PowerStatus.PowerLineStatus}{Environment.NewLine}" +
                $"{Environment.NewLine}{Environment.NewLine}App details{Environment.NewLine}{Environment.NewLine}" +
                $"Company name: {Application.CompanyName}{Environment.NewLine}" +
                $"Product name: {Application.ProductName}{Environment.NewLine}" +
                $"Product version: {Application.ProductVersion}{Environment.NewLine}" +
                $"Startup path: {Application.StartupPath}{Environment.NewLine}" +
                $"Executable path: {Application.ExecutablePath}{Environment.NewLine}" +
                $"User app data path: {Application.UserAppDataPath}{Environment.NewLine}" +
                $"Local user app data path: {Application.LocalUserAppDataPath}{Environment.NewLine}" +
                $"Common app data path: {Application.CommonAppDataPath}{Environment.NewLine}" +
                $"User app data registry: {Application.UserAppDataRegistry}{Environment.NewLine}" +
                $"Opened forms count: {Application.OpenForms.Count}{Environment.NewLine}" +
                $"{Environment.NewLine}{Environment.NewLine}DateTime settings{Environment.NewLine}{Environment.NewLine}" +
                $"Culture: {Application.CurrentCulture.Name}{Environment.NewLine}" +
                $"System language: {Application.CurrentCulture.Parent.Name}{Environment.NewLine}" +
                $"Display language: {Application.CurrentCulture.Parent.DisplayName}{Environment.NewLine}" +
                $"Calendar name: {Application.CurrentCulture.DateTimeFormat.NativeCalendarName}{Environment.NewLine}" +
                $"Calendar algorithm: {Application.CurrentCulture.Calendar.AlgorithmType}{Environment.NewLine}" +
                $"Week rule: {Application.CurrentCulture.DateTimeFormat.CalendarWeekRule}{Environment.NewLine}" +
                $"First Day Of Week: {Application.CurrentCulture.DateTimeFormat.FirstDayOfWeek}{Environment.NewLine}" +
                $"Short time: {Application.CurrentCulture.DateTimeFormat.ShortTimePattern}{Environment.NewLine}" +
                $"Long time: {Application.CurrentCulture.DateTimeFormat.LongTimePattern}{Environment.NewLine}" +
                $"Short date: {Application.CurrentCulture.DateTimeFormat.ShortDatePattern}{Environment.NewLine}" +
                $"Long date: {Application.CurrentCulture.DateTimeFormat.LongDatePattern}{Environment.NewLine}" +
                $"Full date time: {Application.CurrentCulture.DateTimeFormat.FullDateTimePattern}{Environment.NewLine}" +
                $"RFC1123: {Application.CurrentCulture.DateTimeFormat.RFC1123Pattern}{Environment.NewLine}" +
                $"{Environment.NewLine}{Environment.NewLine}Input Settings{Environment.NewLine}{Environment.NewLine}" +
                $"Keyboard layout id: {Application.CurrentCulture.KeyboardLayoutId}{Environment.NewLine}" +
                $"Currency: {Application.CurrentCulture.NumberFormat.CurrencySymbol}{Environment.NewLine}" +
                $"Currency decimal separator: {Application.CurrentCulture.NumberFormat.CurrencyDecimalSeparator}{Environment.NewLine}" +
                $"Input language: {Application.CurrentInputLanguage.Culture.Name}{Environment.NewLine}" +
                $"Input language display: {Application.CurrentInputLanguage.Culture.DisplayName}";
        }

    }
}
