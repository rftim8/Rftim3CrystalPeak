using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Rftim3WinFormsUCL.RftProgressBarHorizontal
{
    public partial class RftHProgressBarCC_0 : ProgressBar
    {
        public RftHProgressBarCC_0()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
        }

        private int numberChunksValue;
        private Rectangle[]? progressBarRectangles;
        private int paintedBarWidth;
        private int paintedBarHeight;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BarWidth
        {
            get { return paintedBarWidth; }
            set { if (value > 0) paintedBarWidth = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BarHeight
        {
            get { return paintedBarHeight; }
            set { if (value > 0) paintedBarHeight = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NumberChunks
        {
            get { return numberChunksValue; }
            set
            {
                if (value > 0)
                {
                    numberChunksValue = value;
                    SetupProgressBar();
                }
            }
        }

        private void SetupProgressBar()
        {
            if (!ProgressBarRenderer.IsSupported) return;

            progressBarRectangles = new Rectangle[NumberChunks];

            int filledRectangleWidth = 0;

            for (int i = 0; i < NumberChunks; i++)
            {
                if (i == NumberChunks - 1)
                {
                    filledRectangleWidth = (i) * (BarWidth / NumberChunks) + (BarWidth - filledRectangleWidth);
                    progressBarRectangles[i] = new Rectangle(ClientRectangle.X, ClientRectangle.Y, filledRectangleWidth, BarHeight);
                }
                else
                {
                    filledRectangleWidth = (i + 1) * (BarWidth / NumberChunks);
                    progressBarRectangles[i] = new Rectangle(ClientRectangle.X, ClientRectangle.Y, filledRectangleWidth, BarHeight);
                }
            }
        }

        public void Start()
        {
            for (int i = 0; i < NumberChunks; i++)
            {
                using Graphics g = CreateGraphics();
                ProgressBarRenderer.DrawHorizontalChunks(g, progressBarRectangles![i]);
                LinearGradientBrush backbrush = new(progressBarRectangles[i], Color.DodgerBlue, Color.Black, LinearGradientMode.Vertical);
                g.FillRectangle(backbrush, progressBarRectangles[i]);
            }
        }
    }
}
