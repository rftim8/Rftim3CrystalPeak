using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Windows.Forms.DataVisualization.Charting;

namespace Rftim3WinFormsUCL.RftBarChart
{
    public partial class RftBarChartUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftBarChartUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            CreateChartArea();
            PlotChart();
        }

        private readonly ChartArea chartArea4Area = new();

        public void CreateChartArea()
        {
            chartArea4Area.Name = "ChartArea1";
            chartArea4Area.BackColor = Color.LightGreen;
            chartArea4Area.Position = new ElementPosition { Height = 100, Width = 8, X = 5, Y = 5 };
            chartArea4Area.Position = new ElementPosition { Auto = true };
            chartArea4Area.AxisY = new Axis
            {
                Enabled = AxisEnabled.True,
                IsLabelAutoFit = true,
                IsMarginVisible = true,
                LabelStyle = new LabelStyle { Format = "P2", ForeColor = Color.DarkBlue, Font = new Font("Arial", 10, FontStyle.Regular) },
                LineColor = Color.Black,
                MajorGrid = new Grid { LineColor = Color.White, LineDashStyle = ChartDashStyle.Solid },
                MajorTickMark = new TickMark { LineColor = Color.Black }
            };

            chartArea4Area.AxisY2 = new Axis
            {
                Enabled = AxisEnabled.True,
                IsLabelAutoFit = true,
                IsMarginVisible = true,
                LabelStyle = new LabelStyle { Format = "P2", ForeColor = Color.DarkBlue, Font = new Font("Arial", 10, FontStyle.Regular) },
                LineColor = Color.Transparent,
                MajorGrid = new Grid { LineColor = Color.Yellow, LineDashStyle = ChartDashStyle.Solid },
                MajorTickMark = new TickMark { LineColor = Color.Blue }

            };

            chartArea4Area.AxisX = new Axis
            {
                Enabled = AxisEnabled.True,
                Crossing = double.NaN,
                //Crossing = 0,
                LineWidth = 1,
                IsLabelAutoFit = true,
                IsMarginVisible = false,
                LabelStyle = new LabelStyle { Angle = -45, Format = "N0", ForeColor = Color.Black, Font = new Font("Arial", 8, FontStyle.Regular) },
                LineColor = Color.Black,
                MajorGrid = new Grid { LineColor = Color.White, LineDashStyle = ChartDashStyle.Solid },
                MajorTickMark = new TickMark { LineColor = Color.LightGray, Size = 4.0f },
                Name = "Spot"

            };
        }

        public void PlotChart()
        {
            int[] Xseries = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] AXJO = { 0.0025, 0.0015, -0.001, 0.002, 0.0045, -0.002, -0.003, 0.0001, -0.004, -0.0075 };
            double[] ES = { 0.0020, 0.0010, -0.0005, 0.003, 0.0025, -0.001, -0.0015, 0.0005, -0.0032, -0.006 };
            double[] Diff = new double[10];

            // pair return
            for (int i = 0; i < 10; i++)
            {
                Diff[i] = AXJO[i] - ES[i];
            }

            chart1.BackColor = Color.LightGoldenrodYellow;
            chart1.BackSecondaryColor = Color.LightBlue;

            if (chart1.Series.IsUniqueName("AXJO"))
            {
                chart1.Series.Add("AXJO");
                chart1.Series["AXJO"].YAxisType = AxisType.Primary;
                chart1.Series["AXJO"].Color = Color.Green;
                chart1.Series["AXJO"].ChartType = SeriesChartType.Line;
                chart1.Series["AXJO"].Points.DataBindXY(Xseries, AXJO);
                chart1.Series["AXJO"].ChartArea = "ChartArea1";
            }

            if (chart1.Series.IsUniqueName("ES"))
            {
                chart1.Series.Add("ES");
                chart1.Series["ES"].YAxisType = AxisType.Primary;
                chart1.Series["ES"].Color = Color.Red;
                chart1.Series["ES"].ChartType = SeriesChartType.Line;
                chart1.Series["ES"].Points.DataBindXY(Xseries, ES);
                chart1.Series["ES"].ChartArea = "ChartArea1";
            }

            if (chart1.Series.IsUniqueName("Diff"))
            {
                chart1.Series.Add("Diff");
                chart1.Series["Diff"].YAxisType = AxisType.Secondary;
                chart1.Series["Diff"].Color = Color.Blue;
                chart1.Series["Diff"].ChartType = SeriesChartType.Line;
                chart1.Series["Diff"].Points.DataBindXY(Xseries, Diff);
                chart1.Series["Diff"].ChartArea = "ChartArea1";
            }
            AddStripLine();
        }

        public void AddStripLine()
        {
            // add stripline at Diff=zero
            StripLine ZeroDiff = new()
            {
                ForeColor = Color.Black,
                BackColor = Color.Black,
                StripWidth = 5,
                BorderWidth = 2,
                Interval = 1,
                IntervalOffset = 1
            };
            chart1.ChartAreas["ChartArea1"].AxisY2.StripLines.Add(ZeroDiff);
        }

    }
}
