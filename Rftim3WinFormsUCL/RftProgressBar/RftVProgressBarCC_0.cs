using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;
using System.ComponentModel;

namespace Rftim3WinFormsUCL.RftProgressBarVertical
{
    public partial class RftVProgressBarCC_0 : ProgressBar
    {
        public RftVProgressBarCC_0()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            Location = new Point(10, 10);
            Width = 50;

            progressTimer.Interval = 1000;
            progressTimer.Tick += new EventHandler(ProgressTimer_Tick);

            NumberChunks = 20;

            if (!ProgressBarRenderer.IsSupported) Height = 100;
        }

        private int numberChunksValue;
        private int ticks;
        private readonly Timer progressTimer = new();
        private Rectangle[]? progressBarRectangles;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NumberChunks
        {
            get { return numberChunksValue; }
            set
            {
                if (value <= 50 && value > 0) numberChunksValue = value;
                else
                {
                    MessageBox.Show("Number of chunks must be between 0 and 50; defaulting to 10");
                    numberChunksValue = 10;
                }

                if (ProgressBarRenderer.IsSupported) SetupProgressBar();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawVerticalBar(e.Graphics, ClientRectangle);
                Parent!.Text = "VerticalProgressBar Enabled";
            }
            else Parent!.Text = "VerticalProgressBar Disabled";
        }

        private void SetupProgressBar()
        {
            if (!ProgressBarRenderer.IsSupported) return;

            Size = new Size(ClientRectangle.Width, NumberChunks * (ProgressBarRenderer.ChunkThickness + (2 * ProgressBarRenderer.ChunkSpaceThickness)) + 6);

            progressBarRectangles = new Rectangle[NumberChunks];

            for (int i = 0; i < NumberChunks; i++)
            {
                int filledRectangleHeight = (i + 1) * (ProgressBarRenderer.ChunkThickness + (2 * ProgressBarRenderer.ChunkSpaceThickness));

                progressBarRectangles[i] = new Rectangle(ClientRectangle.X + 3, ClientRectangle.Y + ClientRectangle.Height - 3 - filledRectangleHeight, ClientRectangle.Width - 6, filledRectangleHeight);
            }
        }

        private void ProgressTimer_Tick(object? myObject, EventArgs e)
        {
            if (ticks < NumberChunks)
            {
                using Graphics g = CreateGraphics();
                ProgressBarRenderer.DrawVerticalChunks(g, progressBarRectangles![ticks]);
                LinearGradientBrush backbrush = new(progressBarRectangles[ticks], Color.DodgerBlue, Color.Black, LinearGradientMode.Vertical);
                g.FillRectangle(backbrush, progressBarRectangles[ticks]);
                ticks++;
            }
            else progressTimer.Enabled = false;
        }

        public void Start()
        {
            if (ProgressBarRenderer.IsSupported) progressTimer.Start();
            else MessageBox.Show("VerticalScrollBar requires visual styles");
        }


        //protected override void OnPaintBackground(PaintEventArgs pevent)
        //{

        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    const int inset = 0;

        //    using (Image offscreenImage = new Bitmap(Width, Height))
        //    {
        //        using (Graphics offscreen = Graphics.FromImage(offscreenImage))
        //        {
        //            Rectangle rectangle = new Rectangle(0, 0, Width, Height);

        //            rectangle.Inflate(new Size(inset, inset));
        //            rectangle.Width = (int)(rectangle.Width * ((double)Value / Maximum));

        //            if (rectangle.Width == 0)
        //            {
        //                rectangle.Width = 1;
        //            }

        //            LinearGradientBrush backbrush = new LinearGradientBrush(e.ClipRectangle, Color.Black, Color.Black, LinearGradientMode.Vertical);
        //            offscreen.FillRectangle(backbrush, inset, inset, Width, Height);
        //            LinearGradientBrush brush = new LinearGradientBrush(rectangle, BackColor, ForeColor, LinearGradientMode.Horizontal);
        //            offscreen.FillRectangle(brush, inset, inset, rectangle.Width, Height);
        //            e.Graphics.DrawImage(offscreenImage, 0, 0);
        //            offscreenImage.Dispose();
        //        }
        //    }

        //}
    }
}
