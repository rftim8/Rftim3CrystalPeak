using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rftim3WinFormsUCL.RftBarChart
{
    public partial class RftBarChartUC_1 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftBarChartUC_1(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            Chart1();
        }

        #region Chart1
        public void Chart1()
        {
            chart1.Width = 700;
            chart1.Height = 300;
            chart1.BackColor = Color.FromArgb(211, 223, 240);
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            chart1.BackSecondaryColor = Color.White;
            chart1.BackGradientStyle = GradientStyle.TopBottom;
            chart1.BorderlineWidth = 1;
            chart1.Palette = ChartColorPalette.BrightPastel;
            chart1.BorderlineColor = Color.FromArgb(26, 59, 105);
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            chart1.AntiAliasing = AntiAliasingStyles.All;
            chart1.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
            chart1.Titles.Add(CreateTitle());
            chart1.Legends.Add(CreateLegend());
            List<Tuple<int, string>> peoples =
            [
                new(5, "wqrwer"),
                new(32, "wqrwer"),
                new(45, "wqrwer"),
                new(1, "wqrwer")
            ];

            SeriesChartType seriesChartType = SeriesChartType.Bar;
            chart1.Series.Add(CreateSeries(peoples, seriesChartType, Color.Azure));
            chart1.ChartAreas.Add(CreateChartArea());
        }

        public static Title CreateTitle()
        {
            Title title = new()
            {
                Text = "Result Chart",
                ShadowColor = Color.FromArgb(32, 0, 0, 0),
                Font = new Font("Trebuchet MS", 14F, FontStyle.Bold),
                ShadowOffset = 3,
                ForeColor = Color.FromArgb(26, 59, 105)
            };

            return title;
        }

        public static Series CreateSeries(IList<Tuple<int, string>> results,
               SeriesChartType chartType,
               Color color)
        {
            Series? seriesDetail = new()
            {
                Name = "Result Chart",
                IsValueShownAsLabel = false,
                Color = color,
                ChartType = chartType,
                BorderWidth = 2
            };
            seriesDetail["DrawingStyle"] = "Cylinder";
            seriesDetail["PieDrawingStyle"] = "SoftEdge";
            DataPoint point;

            foreach (Tuple<int, string>? result in results)
            {
                point = new DataPoint
                {
                    AxisLabel = result.Item2,
                    YValues = [result.Item1]
                };
                seriesDetail.Points.Add(point);
            }
            seriesDetail.ChartArea = "Result Chart";

            return seriesDetail;
        }

        public static Legend CreateLegend()
        {
            Legend? legend = new()
            {
                Name = "Result Chart",
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                BackColor = Color.Transparent,
                Font = new Font(new FontFamily("Trebuchet MS"), 9),
                LegendStyle = LegendStyle.Row
            };

            return legend;
        }

        public static ChartArea CreateChartArea()
        {
            ChartArea? chartArea = new()
            {
                Name = "Result Chart",
                BackColor = Color.Transparent
            };
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 8F, FontStyle.Regular);
            chartArea.AxisY.LabelStyle.Font = new Font("Verdana,Arial,Helvetica,sans-serif", 8F, FontStyle.Regular);
            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.Interval = 1;
            return chartArea;
        }
        #endregion
    }
}
