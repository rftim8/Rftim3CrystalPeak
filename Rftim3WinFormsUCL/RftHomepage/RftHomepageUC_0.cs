using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace Rftim3WinFormsUCL.RftHomepage
{
    public partial class RftHomepageUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftHomepageUC_0(IHost host)
        {
            InitializeComponent();

            WelcomePanelInformation();
            GetSystemInformation();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        #region App Info
        private void WelcomePanelInformation()
        {
            #region App Details
            listView1.Items.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnHeader0 = new()
            {
                Width = 250
            };
            ColumnHeader columnHeader1 = new()
            {
                Width = 450
            };
            listView1.Columns.AddRange([columnHeader0, columnHeader1]);

            ListViewItem titleSeparator0 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };
            ListViewItem item0 = new(["App Details"])
            {
                ForeColor = Color.DodgerBlue,
                Font = new Font("Verdana", 12f)
            };
            ListViewItem titleSeparator1 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };

            ListViewItem item1 = new(["Company Name:", Application.CompanyName!]);
            ListViewItem item2 = new(["Product Name:", Application.ProductName!]);
            ListViewItem item3 = new(["Product Version:", Application.ProductVersion]);
            ListViewItem item4 = new(["Startup Path:", Application.StartupPath]);
            ListViewItem item5 = new(["Executable Path:", Application.ExecutablePath]);
            ListViewItem item6 = new(["User App Data Path:", Application.UserAppDataPath]);
            ListViewItem item7 = new(["LocalUser App Data Path:", Application.LocalUserAppDataPath]);
            ListViewItem item8 = new(["Common App Data Path:", Application.CommonAppDataPath]);
            ListViewItem item9 = new(["User App Data Registry:", Application.UserAppDataRegistry.ToString()]);
            ListViewItem item10 = new(["OpenForms Count:", Application.OpenForms.Count.ToString()]);

            ListViewItem titleSeparato2 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };
            ListViewItem item11 = new(["Date Time Settings"])
            {
                ForeColor = Color.DodgerBlue,
                Font = new Font("Verdana", 12f)
            };
            ListViewItem titleSeparato3 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };

            ListViewItem item12 = new(["Culture:", Application.CurrentCulture.Name]);
            ListViewItem item13 = new(["System Language:", Application.CurrentCulture.Parent.Name]);
            ListViewItem item14 = new(["Display Language:", Application.CurrentCulture.Parent.DisplayName]);
            ListViewItem item15 = new(["Calendar Name:", Application.CurrentCulture.DateTimeFormat.NativeCalendarName.ToString()]);
            ListViewItem item16 = new(["Calendar Algorithm:", Application.CurrentCulture.Calendar.AlgorithmType.ToString()]);
            ListViewItem item17 = new(["Week Rule:", Application.CurrentCulture.DateTimeFormat.CalendarWeekRule.ToString()]);
            ListViewItem item18 = new(["First Day Of Week:", Application.CurrentCulture.DateTimeFormat.FirstDayOfWeek.ToString()]);
            ListViewItem item19 = new(["Short Time:", Application.CurrentCulture.DateTimeFormat.ShortTimePattern]);
            ListViewItem item20 = new(["Long Time:", Application.CurrentCulture.DateTimeFormat.LongTimePattern]);
            ListViewItem item21 = new(["Short Date:", Application.CurrentCulture.DateTimeFormat.ShortDatePattern]);
            ListViewItem item22 = new(["Long Date:", Application.CurrentCulture.DateTimeFormat.LongDatePattern]);
            ListViewItem item23 = new(["Full Date Time:", Application.CurrentCulture.DateTimeFormat.FullDateTimePattern.ToString()]);
            ListViewItem item24 = new(["RFC1123:", Application.CurrentCulture.DateTimeFormat.RFC1123Pattern.ToString()]);

            ListViewItem titleSeparato4 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };
            ListViewItem item25 = new(["Input Settings"])
            {
                ForeColor = Color.DodgerBlue,
                Font = new Font("Verdana", 12f)
            };
            ListViewItem titleSeparato5 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };

            ListViewItem item26 = new(["Keyboard Layout Id:", Application.CurrentCulture.KeyboardLayoutId.ToString()]);
            ListViewItem item27 = new(["Currency:", Application.CurrentCulture.NumberFormat.CurrencySymbol]);
            ListViewItem item28 = new(["Currency Decimal Separator:", Application.CurrentCulture.NumberFormat.CurrencyDecimalSeparator]);
            ListViewItem item29 = new(["Input Language:", Application.CurrentInputLanguage.Culture.Name]);
            ListViewItem item30 = new(["Input Language Display:", Application.CurrentInputLanguage.Culture.DisplayName]);

            listView1.Items.AddRange(
                [
                    titleSeparator0,
                    item0,
                    titleSeparator1,
                    item1,
                    item2,
                    item3,
                    item4,
                    item5,
                    item6,
                    item7,
                    item8,
                    item9,
                    item10,
                    titleSeparato2,
                    item11,
                    titleSeparato3,
                    item12,
                    item13,
                    item14,
                    item15,
                    item16,
                    item17,
                    item18,
                    item19,
                    item20,
                    item21,
                    item22,
                    item23,
                    item24,
                    titleSeparato4,
                    item25,
                    titleSeparato5,
                    item26,
                    item27,
                    item28,
                    item29,
                    item30
                ]);

            #endregion

            #region Latest Updates
            listView2.Items.Clear();
            listView2.Columns.Clear();

            ColumnHeader columnHeader0List2 = new()
            {
                Width = 348
            };
            listView2.Columns.AddRange([columnHeader0List2]);

            ListViewItem titleSeparator0List2 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };
            ListViewItem item0List2 = new(["Latest Updates"])
            {
                ForeColor = Color.DodgerBlue,
                Font = new Font("Verdana", 12f)
            };
            ListViewItem titleSeparator1List2 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };

            ListViewItem item1List2 = new(["1. Added customized gauges to the welcome panel"]);
            ListViewItem item2List2 = new(["2. Refined welcome panel layout"]);

            listView2.Items.AddRange(
                [
                    titleSeparator0List2,
                    item0List2,
                    titleSeparator1List2,
                    item1List2,
                    item2List2
                ]);

            #endregion

            #region App Structure
            listView3.Items.Clear();
            listView3.Columns.Clear();

            ColumnHeader columnHeader0List3 = new()
            {
                Width = 348
            };
            listView3.Columns.AddRange([columnHeader0List3]);

            ListViewItem titleSeparator0List3 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };
            ListViewItem item0List3 = new(["App Structure"])
            {
                ForeColor = Color.DodgerBlue,
                Font = new Font("Verdana", 12f)
            };
            ListViewItem titleSeparator1List3 = new(["", ""])
            {
                Font = new Font("Verdana", 5f)
            };

            ListViewItem item1List3 = new(["1. 69 user controls at C# level"]);
            ListViewItem item2List3 = new(["2. paint on demand"]);

            listView3.Items.AddRange(
                [
                    titleSeparator0List3,
                    item0List3,
                    titleSeparator1List3,
                    item1List3,
                    item2List3
                ]);
            #endregion

        }
        #endregion

        #region System Info
        private void GetSystemInformation()
        {
            label7.Text = SystemInformation.ComputerName.ToString();
            label8.Text = SystemInformation.UserName.ToString();
            label9.Text = SystemInformation.UserDomainName.ToString();
            label10.Text = SystemInformation.BootMode.ToString();
            label11.Text = SystemInformation.MonitorCount.ToString();
            label12.Text = $"{SystemInformation.PrimaryMonitorSize.Width} x {SystemInformation.PrimaryMonitorSize.Height}";
            label13.Text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
            label14.Text = SystemInformation.PowerStatus.PowerLineStatus.ToString();
        }
        #endregion
    }
}
