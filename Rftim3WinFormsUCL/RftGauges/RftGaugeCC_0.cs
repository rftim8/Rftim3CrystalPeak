using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;

namespace Rftim3WinFormsUCL.RftGauges
{
    [ToolboxBitmap(typeof(RftGaugeCC_0), "RftGauge.RftGauge.bmp"),
    DefaultEvent("ValueInRangeChanged"),
    Description("Displays a value on an analog gauge. Raises an event if the value enters one of the definable ranges.")]
    public partial class RftGaugeCC_0 : Control
    {
        #region Private Fields
        private float fontBoundY1;
        private float fontBoundY2;
        private Bitmap? gaugeBitmap;
        private bool drawGaugeBackground = true;

        private float m_value;
        //private Boolean m_AutoSize = false;
        private Point m_Center = new(100, 100);
        private float m_MinValue = -100;
        private float m_MaxValue = 400;

        private Color m_BaseArcColor = Color.Gray;
        private int m_BaseArcRadius = 80;
        private int m_BaseArcStart = 135;
        private int m_BaseArcSweep = 270;
        private int m_BaseArcWidth = 2;

        public RftGaugeCC_0(int baseArcWidth)
        {
            m_BaseArcWidth = baseArcWidth;
        }

        private Color m_ScaleLinesInterColor = Color.Black;
        private int m_ScaleLinesInterInnerRadius = 73;
        private int m_ScaleLinesInterOuterRadius = 80;
        private int m_ScaleLinesInterWidth = 1;

        private int m_ScaleLinesMinorTicks = 9;
        private Color m_ScaleLinesMinorColor = Color.Gray;
        private int m_ScaleLinesMinorInnerRadius = 75;
        private int m_ScaleLinesMinorOuterRadius = 80;
        private int m_ScaleLinesMinorWidth = 1;

        private float m_ScaleLinesMajorStepValue = 50.0f;
        private Color m_ScaleLinesMajorColor = Color.Black;
        private int m_ScaleLinesMajorInnerRadius = 70;
        private int m_ScaleLinesMajorOuterRadius = 80;
        private int m_ScaleLinesMajorWidth = 2;

        private int m_ScaleNumbersRadius = 95;
        private Color m_ScaleNumbersColor = Color.Black;
        private string? m_ScaleNumbersFormat;
        private int m_ScaleNumbersStartScaleLine;
        private int m_ScaleNumbersStepScaleLines = 1;
        private int m_ScaleNumbersRotation;

        private NeedleType m_NeedleType;
        private int m_NeedleRadius = 80;
        private RftGaugeNeedleColor m_NeedleColor1 = RftGaugeNeedleColor.Gray;
        private Color m_NeedleColor2 = Color.DimGray;
        private int m_NeedleWidth = 2;
        #endregion

        #region EventHandler
        [Description("This event is raised when gauge value changed.")]
        public event EventHandler? ValueChanged;
        private void OnValueChanged()
        {
            ValueChanged?.Invoke(this, null!);
        }

        [Description("This event is raised if the value is entering or leaving defined range.")]
        public event EventHandler<ValueInRangeChangedEventArgs>? ValueInRangeChanged;
        private void OnValueInRangeChanged(RftGaugeRange range, float value)
        {
            ValueInRangeChanged?.Invoke(this, new ValueInRangeChangedEventArgs(range, value, range.InRange));
        }
        #endregion

        #region Hidden and overridden inherited properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        #endregion

        #region Hidden and overridden inherited properties
        public new static bool AllowDrop
        {
            get { return false; }
            set { /*Do Nothing */ }
        }
        //public new Boolean AutoSize { get { return false; } set { /*Do Nothing */ } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public new Boolean AutoSize { get { return false; } set { /*Do Nothing */ } }
        public new static bool ForeColor
        {
            get { return false; }
            set { /*Do Nothing */ }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new static bool ImeMode
        {
            get { return false; }
            set { /*Do Nothing */ }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                drawGaugeBackground = true;
                Refresh();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                drawGaugeBackground = true;
                Refresh();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set
            {
                base.BackgroundImageLayout = value;
                drawGaugeBackground = true;
                Refresh();
            }
        }
        #endregion

        public RftGaugeCC_0()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            _GaugeRanges = new RftGaugeRangeCollection(this);
            _GaugeLabels = new RftGaugeLabelCollection(this);

            Size = new Size(205, 180);
        }

        #region Properties  
        [Browsable(true),
        Category("RftGauge"),
        Description("Gauge value.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Value
        {
            get { return m_value; }
            set
            {
                value = Math.Min(Math.Max(value, m_MinValue), m_MaxValue);
                if (m_value != value)
                {
                    m_value = value;
                    OnValueChanged();

                    if (DesignMode) drawGaugeBackground = true;

                    foreach (RftGaugeRange ptrRange in _GaugeRanges!)
                    {
                        if (m_value >= ptrRange.StartValue
                            && m_value <= ptrRange.EndValue)
                        {
                            //Entering Range
                            if (!ptrRange.InRange)
                            {
                                ptrRange.InRange = true;
                                OnValueInRangeChanged(ptrRange, m_value);
                            }
                        }
                        else
                        {
                            //Leaving Range
                            if (ptrRange.InRange)
                            {
                                ptrRange.InRange = false;
                                OnValueInRangeChanged(ptrRange, m_value);
                            }
                        }
                    }
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("Auto size Mode of the gauge.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool GaugeAutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("Gauge Ranges.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RftGaugeRangeCollection GaugeRanges
        {
            get { return _GaugeRanges!; }
        }

        private readonly RftGaugeRangeCollection? _GaugeRanges;

        [Browsable(true),
        Category("RftGauge"),
        Description("Gauge Labels.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RftGaugeLabelCollection? GaugeLabels
        {
            get { return _GaugeLabels; }
        }

        private readonly RftGaugeLabelCollection? _GaugeLabels;

        #region << Gauge Base >>
        [Browsable(true),
        Category("RftGauge"),
        Description("The center of the gauge (in the control's client area)."),
        DefaultValue(typeof(Point), "100, 100")]
        public Point Center
        {
            get { return m_Center; }
            set
            {
                if (m_Center != value)
                {
                    m_Center = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The color of the base arc.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BaseArcColor
        {
            get { return m_BaseArcColor; }
            set
            {
                if (m_BaseArcColor != value)
                {
                    m_BaseArcColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The radius of the base arc.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BaseArcRadius
        {
            get { return m_BaseArcRadius; }
            set
            {
                if (m_BaseArcRadius != value)
                {
                    m_BaseArcRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The start angle of the base arc.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BaseArcStart
        {
            get { return m_BaseArcStart; }
            set
            {
                if (m_BaseArcStart != value)
                {
                    m_BaseArcStart = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The sweep angle of the base arc.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BaseArcSweep
        {
            get { return m_BaseArcSweep; }
            set
            {
                if (m_BaseArcSweep != value)
                {
                    m_BaseArcSweep = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The width of the base arc.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BaseArcWidth
        {
            get { return m_BaseArcWidth; }
            set
            {
                if (m_BaseArcWidth != value)
                {
                    m_BaseArcWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region << Gauge Scale >>

        [Browsable(true),
        Category("RftGauge"),
        Description("The minimum value to show on the scale.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float MinValue
        {
            get { return m_MinValue; }
            set
            {
                if (m_MinValue != value && value < m_MaxValue)
                {
                    m_MinValue = value;
                    m_value = Math.Min(Math.Max(m_value, m_MinValue), m_MaxValue);
                    m_ScaleLinesMajorStepValue = Math.Min(m_ScaleLinesMajorStepValue, m_MaxValue - m_MinValue);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The maximum value to show on the scale.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float MaxValue
        {
            get { return m_MaxValue; }
            set
            {
                if (m_MaxValue != value && value > m_MinValue)
                {
                    m_MaxValue = value;
                    m_value = Math.Min(Math.Max(m_value, m_MinValue), m_MaxValue);
                    m_ScaleLinesMajorStepValue = Math.Min(m_ScaleLinesMajorStepValue, m_MaxValue - m_MinValue);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The color of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ScaleLinesInterColor
        {
            get { return m_ScaleLinesInterColor; }
            set
            {
                if (m_ScaleLinesInterColor != value)
                {
                    m_ScaleLinesInterColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The inner radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesInterInnerRadius
        {
            get { return m_ScaleLinesInterInnerRadius; }
            set
            {
                if (m_ScaleLinesInterInnerRadius != value)
                {
                    m_ScaleLinesInterInnerRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The outer radius of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesInterOuterRadius
        {
            get { return m_ScaleLinesInterOuterRadius; }
            set
            {
                if (m_ScaleLinesInterOuterRadius != value)
                {
                    m_ScaleLinesInterOuterRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The width of the inter scale lines which are the middle scale lines for an uneven number of minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesInterWidth
        {
            get { return m_ScaleLinesInterWidth; }
            set
            {
                if (m_ScaleLinesInterWidth != value)
                {
                    m_ScaleLinesInterWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The number of minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesMinorTicks
        {
            get { return m_ScaleLinesMinorTicks; }
            set
            {
                if (m_ScaleLinesMinorTicks != value)
                {
                    m_ScaleLinesMinorTicks = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The color of the minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ScaleLinesMinorColor
        {
            get { return m_ScaleLinesMinorColor; }
            set
            {
                if (m_ScaleLinesMinorColor != value)
                {
                    m_ScaleLinesMinorColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The inner radius of the minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesMinorInnerRadius
        {
            get { return m_ScaleLinesMinorInnerRadius; }
            set
            {
                if (m_ScaleLinesMinorInnerRadius != value)
                {
                    m_ScaleLinesMinorInnerRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The outer radius of the minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesMinorOuterRadius
        {
            get { return m_ScaleLinesMinorOuterRadius; }
            set
            {
                if (m_ScaleLinesMinorOuterRadius != value)
                {
                    m_ScaleLinesMinorOuterRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The width of the minor scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesMinorWidth
        {
            get { return m_ScaleLinesMinorWidth; }
            set
            {
                if (m_ScaleLinesMinorWidth != value)
                {
                    m_ScaleLinesMinorWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The step value of the major scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float ScaleLinesMajorStepValue
        {
            get { return m_ScaleLinesMajorStepValue; }
            set
            {
                if (m_ScaleLinesMajorStepValue != value && value > 0)
                {
                    m_ScaleLinesMajorStepValue = Math.Min(value, m_MaxValue - m_MinValue);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The color of the major scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ScaleLinesMajorColor
        {
            get { return m_ScaleLinesMajorColor; }
            set
            {
                if (m_ScaleLinesMajorColor != value)
                {
                    m_ScaleLinesMajorColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The inner radius of the major scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesMajorInnerRadius
        {
            get { return m_ScaleLinesMajorInnerRadius; }
            set
            {
                if (m_ScaleLinesMajorInnerRadius != value)
                {
                    m_ScaleLinesMajorInnerRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The outer radius of the major scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesMajorOuterRadius
        {
            get { return m_ScaleLinesMajorOuterRadius; }
            set
            {
                if (m_ScaleLinesMajorOuterRadius != value)
                {
                    m_ScaleLinesMajorOuterRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The width of the major scale lines.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleLinesMajorWidth
        {
            get { return m_ScaleLinesMajorWidth; }
            set
            {
                if (m_ScaleLinesMajorWidth != value)
                {
                    m_ScaleLinesMajorWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region << Gauge Scale Numbers >>
        [Browsable(true),
        Category("RftGauge"),
        Description("The radius of the scale numbers.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleNumbersRadius
        {
            get { return m_ScaleNumbersRadius; }
            set
            {
                if (m_ScaleNumbersRadius != value)
                {
                    m_ScaleNumbersRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The color of the scale numbers.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ScaleNumbersColor
        {
            get { return m_ScaleNumbersColor; }
            set
            {
                if (m_ScaleNumbersColor != value)
                {
                    m_ScaleNumbersColor = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The format of the scale numbers.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ScaleNumbersFormat
        {
            get { return m_ScaleNumbersFormat!; }
            set
            {
                if (m_ScaleNumbersFormat != value)
                {
                    m_ScaleNumbersFormat = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The number of the scale line to start writing numbers next to.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleNumbersStartScaleLine
        {
            get { return m_ScaleNumbersStartScaleLine; }
            set
            {
                if (m_ScaleNumbersStartScaleLine != value)
                {
                    m_ScaleNumbersStartScaleLine = Math.Max(value, 1);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The number of scale line steps for writing numbers.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleNumbersStepScaleLines
        {
            get { return m_ScaleNumbersStepScaleLines; }
            set
            {
                if (m_ScaleNumbersStepScaleLines != value)
                {
                    m_ScaleNumbersStepScaleLines = Math.Max(value, 1);
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The angle relative to the tangent of the base arc at a scale line that is used to rotate numbers. set to 0 for no rotation or e.g. set to 90.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ScaleNumbersRotation
        {
            get { return m_ScaleNumbersRotation; }
            set
            {
                if (m_ScaleNumbersRotation != value)
                {
                    m_ScaleNumbersRotation = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        #endregion

        #region << Gauge Needle >>
        [Browsable(true),
        Category("RftGauge"),
        Description("The type of the needle, currently only type 0 and 1 are supported. Type 0 looks nicers but if you experience performance problems you might consider using type 1.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NeedleType NeedleType
        {
            get { return m_NeedleType; }
            set
            {
                if (m_NeedleType != value)
                {
                    m_NeedleType = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The radius of the needle.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NeedleRadius
        {
            get { return m_NeedleRadius; }
            set
            {
                if (m_NeedleRadius != value)
                {
                    m_NeedleRadius = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The first color of the needle.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RftGaugeNeedleColor NeedleColor1
        {
            get { return m_NeedleColor1; }
            set
            {
                if (m_NeedleColor1 != value)
                {
                    m_NeedleColor1 = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The second color of the needle.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color NeedleColor2
        {
            get { return m_NeedleColor2; }
            set
            {
                if (m_NeedleColor2 != value)
                {
                    m_NeedleColor2 = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }

        [Browsable(true),
        Category("RftGauge"),
        Description("The width of the needle.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NeedleWidth
        {
            get { return m_NeedleWidth; }
            set
            {
                if (m_NeedleWidth != value)
                {
                    m_NeedleWidth = value;
                    drawGaugeBackground = true;
                    Refresh();
                }
            }
        }
        #endregion
        #endregion

        #region Helper
        private void FindFontBounds()
        {
            int c1;
            int c2;
            bool boundfound;
            using SolidBrush backBrush = new(Color.White);
            using SolidBrush foreBrush = new(Color.Black);
            using Bitmap bmpMeasure = new(5, 5);
            using Graphics gMeasure = Graphics.FromImage(bmpMeasure);
            SizeF boundingBox = gMeasure.MeasureString("0123456789", Font, -1, StringFormat.GenericTypographic);
            using Bitmap b = new((int)boundingBox.Width, (int)boundingBox.Height);
            using var g = Graphics.FromImage(b);
            g.FillRectangle(backBrush, 0.0F, 0.0F, boundingBox.Width, boundingBox.Height);
            g.DrawString("0123456789", Font, foreBrush, 0.0F, 0.0F, StringFormat.GenericTypographic);

            fontBoundY1 = 0;
            fontBoundY2 = 0;
            c1 = 0;
            boundfound = false;
            while (c1 < b.Height && !boundfound)
            {
                c2 = 0;
                while (c2 < b.Width && !boundfound)
                {
                    if (b.GetPixel(c2, c1) != backBrush.Color)
                    {
                        fontBoundY1 = c1;
                        boundfound = true;
                    }
                    c2++;
                }
                c1++;
            }

            c1 = b.Height - 1;
            boundfound = false;
            while (0 < c1 && !boundfound)
            {
                c2 = 0;
                while (c2 < b.Width && !boundfound)
                {
                    if (b.GetPixel(c2, c1) != backBrush.Color)
                    {
                        fontBoundY2 = c1;
                        boundfound = true;
                    }
                    c2++;
                }
                c1--;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public void RepaintControl()
        {
            drawGaugeBackground = true;
            Refresh();
        }
        #endregion

        #region Base member overrides
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width < 10 || Height < 10) return;

            #region AutoSize
            float centerFactor = 1;
            Point center = Center;


            if (AutoSize)
            {
                double widthFactor = 1.0 / (2 * Center.X) * Size.Width;
                double heightFactor = 1.0 / (2 * Center.Y) * Size.Height;
                centerFactor = (float)Math.Min(widthFactor, heightFactor);
                center = new Point((int)(Center.X * widthFactor), (int)(Center.Y * heightFactor));
            }
            #endregion

            #region drawGaugeBackground
            if (drawGaugeBackground)
            {
                drawGaugeBackground = false;

                FindFontBounds();

                if (gaugeBitmap != null)
                {
                    gaugeBitmap.Dispose();
                    gaugeBitmap = null;
                }

                gaugeBitmap = new Bitmap(Width, Height, e.Graphics);
                using Graphics ggr = Graphics.FromImage(gaugeBitmap);
                using GraphicsPath gp = new();
                using (SolidBrush brBackground = new(BackColor))
                {
                    ggr.FillRectangle(brBackground, ClientRectangle);
                }

                #region BackgroundImage
                if (BackgroundImage != null)
                {
                    switch (BackgroundImageLayout)
                    {
                        case ImageLayout.Center:
                            ggr.DrawImageUnscaled(BackgroundImage, Width / 2 - BackgroundImage.Width / 2, Height / 2 - BackgroundImage.Height / 2);
                            break;
                        case ImageLayout.None:
                            ggr.DrawImageUnscaled(BackgroundImage, 0, 0);
                            break;
                        case ImageLayout.Stretch:
                            ggr.DrawImage(BackgroundImage, 0, 0, Width, Height);
                            break;
                        case ImageLayout.Tile:
                            int pixelOffsetX = 0;
                            int pixelOffsetY = 0;
                            while (pixelOffsetX < Width)
                            {
                                pixelOffsetY = 0;
                                while (pixelOffsetY < Height)
                                {
                                    ggr.DrawImageUnscaled(BackgroundImage, pixelOffsetX, pixelOffsetY);
                                    pixelOffsetY += BackgroundImage.Height;
                                }
                                pixelOffsetX += BackgroundImage.Width;
                            }
                            break;
                        case ImageLayout.Zoom:
                            if (BackgroundImage.Width / Width < (float)(BackgroundImage.Height / Height)) ggr.DrawImage(BackgroundImage, 0, 0, Height, Height);
                            else ggr.DrawImage(BackgroundImage, 0, 0, Width, Width);
                            break;
                    }
                }
                #endregion

                ggr.SmoothingMode = SmoothingMode.HighQuality;
                ggr.PixelOffsetMode = PixelOffsetMode.HighQuality;


                #region _GaugeRanges
                float rangeStartAngle;
                float rangeSweepAngle;
                foreach (RftGaugeRange ptrRange in _GaugeRanges!)
                {
                    if (ptrRange.EndValue > ptrRange.StartValue)
                    {
                        rangeStartAngle = m_BaseArcStart + (ptrRange.StartValue - m_MinValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue);
                        rangeSweepAngle = (ptrRange.EndValue - ptrRange.StartValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue);
                        gp.Reset();
                        int outerRadius = (int)(ptrRange.OuterRadius * centerFactor);
                        gp.AddPie(new Rectangle(center.X - outerRadius, center.Y - outerRadius, 2 * outerRadius, 2 * outerRadius), rangeStartAngle, rangeSweepAngle);
                        gp.Reverse();
                        int innerRadius = (int)(ptrRange.InnerRadius * centerFactor);
                        gp.AddPie(new Rectangle(center.X - innerRadius, center.Y - innerRadius, 2 * innerRadius, 2 * innerRadius), rangeStartAngle, rangeSweepAngle);
                        gp.Reverse();
                        ggr.SetClip(gp);
                        using SolidBrush brRange = new(ptrRange.Color);
                        ggr.FillPie(brRange, new Rectangle(center.X - outerRadius, center.Y - outerRadius, 2 * outerRadius, 2 * outerRadius), rangeStartAngle, rangeSweepAngle);
                    }
                }
                #endregion

                ggr.SetClip(ClientRectangle);
                if (m_BaseArcRadius > 0)
                {
                    int baseArcRadius = (int)(m_BaseArcRadius * centerFactor);
                    using Pen pnArc = new(m_BaseArcColor, (int)(m_BaseArcWidth * centerFactor));
                    ggr.DrawArc(pnArc, new Rectangle(center.X - baseArcRadius, center.Y - baseArcRadius, 2 * baseArcRadius, 2 * baseArcRadius), m_BaseArcStart, m_BaseArcSweep);
                }

                #region ScaleNumbers
                string valueText = "";
                SizeF boundingBox;
                float countValue = 0;
                int counter1 = 0;
                StringFormat Format = StringFormat.GenericTypographic;
                Format.Alignment = StringAlignment.Near;

                using (Pen pnMajorScaleLines = new(m_ScaleLinesMajorColor, (int)(m_ScaleLinesMajorWidth * centerFactor)))
                using (SolidBrush brScaleNumbers = new(m_ScaleNumbersColor))
                {
                    while (countValue <= m_MaxValue - m_MinValue)
                    {
                        valueText = (m_MinValue + countValue).ToString(m_ScaleNumbersFormat);
                        ggr.ResetTransform();
                        boundingBox = ggr.MeasureString(valueText, Font, -1, StringFormat.GenericTypographic);

                        gp.Reset();
                        int scaleLinesMajorOuterRadius = (int)(m_ScaleLinesMajorOuterRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(center.X - scaleLinesMajorOuterRadius, center.Y - scaleLinesMajorOuterRadius, 2 * scaleLinesMajorOuterRadius, 2 * scaleLinesMajorOuterRadius));
                        gp.Reverse();
                        int scaleLinesMajorInnerRadius = (int)(m_ScaleLinesMajorInnerRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(center.X - scaleLinesMajorInnerRadius, center.Y - scaleLinesMajorInnerRadius, 2 * scaleLinesMajorInnerRadius, 2 * scaleLinesMajorInnerRadius));
                        gp.Reverse();
                        ggr.SetClip(gp);

                        ggr.DrawLine(pnMajorScaleLines,
                        center.X,
                        center.Y,
                        (float)(center.X + 2 * scaleLinesMajorOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0)),
                        (float)(center.Y + 2 * scaleLinesMajorOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0)));

                        gp.Reset();
                        int scaleLinesMinorOuterRadius = (int)(m_ScaleLinesMinorOuterRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(center.X - scaleLinesMinorOuterRadius, center.Y - scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius));
                        gp.Reverse();
                        int scaleLinesMinorInnerRadius = (int)(m_ScaleLinesMinorInnerRadius * centerFactor);
                        gp.AddEllipse(new Rectangle(center.X - scaleLinesMinorInnerRadius, center.Y - scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius));
                        gp.Reverse();
                        ggr.SetClip(gp);

                        if (countValue < m_MaxValue - m_MinValue)
                        {
                            using Pen pnScaleLinesInter = new(m_ScaleLinesInterColor, (int)(m_ScaleLinesInterWidth * centerFactor));
                            using Pen pnScaleLinesMinorColor = new(m_ScaleLinesMinorColor, (int)(m_ScaleLinesMinorWidth * centerFactor));
                            for (int counter2 = 1; counter2 <= m_ScaleLinesMinorTicks; counter2++)
                            {
                                if (m_ScaleLinesMinorTicks % 2 == 1 && m_ScaleLinesMinorTicks / 2 + 1 == counter2)
                                {
                                    gp.Reset();
                                    int scaleLinesInterOuterRadius = (int)(m_ScaleLinesInterOuterRadius * centerFactor);
                                    gp.AddEllipse(new Rectangle(center.X - scaleLinesInterOuterRadius, center.Y - scaleLinesInterOuterRadius, 2 * scaleLinesInterOuterRadius, 2 * scaleLinesInterOuterRadius));
                                    gp.Reverse();
                                    int scaleLinesInterInnerRadius = (int)(m_ScaleLinesInterInnerRadius * centerFactor);
                                    gp.AddEllipse(new Rectangle(center.X - scaleLinesInterInnerRadius, center.Y - scaleLinesInterInnerRadius, 2 * scaleLinesInterInnerRadius, 2 * scaleLinesInterInnerRadius));
                                    gp.Reverse();
                                    ggr.SetClip(gp);

                                    ggr.DrawLine(pnScaleLinesInter,
                                    center.X,
                                    center.Y,
                                    (float)(center.X + 2 * scaleLinesInterOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / ((float)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)),
                                    (float)(center.Y + 2 * scaleLinesInterOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / ((float)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)));

                                    gp.Reset();
                                    gp.AddEllipse(new Rectangle(center.X - scaleLinesMinorOuterRadius, center.Y - scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius, 2 * scaleLinesMinorOuterRadius));
                                    gp.Reverse();
                                    gp.AddEllipse(new Rectangle(center.X - scaleLinesMinorInnerRadius, center.Y - scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius, 2 * scaleLinesMinorInnerRadius));
                                    gp.Reverse();
                                    ggr.SetClip(gp);
                                }
                                else
                                {
                                    ggr.DrawLine(pnScaleLinesMinorColor,
                                    center.X,
                                    center.Y,
                                    (float)(center.X + 2 * scaleLinesMinorOuterRadius * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / ((float)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)),
                                    (float)(center.Y + 2 * scaleLinesMinorOuterRadius * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue) + counter2 * m_BaseArcSweep / ((float)((m_MaxValue - m_MinValue) / m_ScaleLinesMajorStepValue) * (m_ScaleLinesMinorTicks + 1))) * Math.PI / 180.0)));
                                }
                            }
                        }

                        ggr.SetClip(ClientRectangle);

                        if (m_ScaleNumbersRotation != 0)
                        {
                            ggr.TextRenderingHint = TextRenderingHint.AntiAlias;
                            ggr.RotateTransform(90.0F + m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue));
                        }

                        ggr.TranslateTransform((float)(center.X + m_ScaleNumbersRadius * centerFactor * Math.Cos((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0f)),
                                               (float)(center.Y + m_ScaleNumbersRadius * centerFactor * Math.Sin((m_BaseArcStart + countValue * m_BaseArcSweep / (m_MaxValue - m_MinValue)) * Math.PI / 180.0f)),
                                               MatrixOrder.Append);


                        if (counter1 >= ScaleNumbersStartScaleLine - 1)
                        {
                            PointF ptText = new(-boundingBox.Width / 2f, -fontBoundY1 - (fontBoundY2 - fontBoundY1 + 1f) / 2f);
                            ggr.DrawString(valueText, Font, brScaleNumbers, ptText.X, ptText.Y, Format);
                        }

                        countValue += m_ScaleLinesMajorStepValue;
                        counter1++;
                    }
                }
                #endregion

                ggr.ResetTransform();
                ggr.SetClip(ClientRectangle);

                if (m_ScaleNumbersRotation != 0)
                {
                    ggr.TextRenderingHint = TextRenderingHint.SystemDefault;
                }

                #region _GaugeLabels
                Format = StringFormat.GenericTypographic;
                Format.Alignment = StringAlignment.Center;
                foreach (RftGaugeLabel ptrGaugeLabel in _GaugeLabels!)
                {
                    if (!string.IsNullOrEmpty(ptrGaugeLabel.Text))
                    {
                        using var brGaugeLabel = new SolidBrush(ptrGaugeLabel.Color);
                        ggr.DrawString(ptrGaugeLabel.Text, ptrGaugeLabel.Font, brGaugeLabel,
                                       ptrGaugeLabel.Position.X * centerFactor + center.X,
                                       ptrGaugeLabel.Position.Y * centerFactor + center.Y, Format);
                    }
                }
                #endregion
            }
            #endregion

            e.Graphics.DrawImageUnscaled(gaugeBitmap!, 0, 0);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            #region Needle
            float brushAngle = (int)(m_BaseArcStart + (m_value - m_MinValue) * m_BaseArcSweep / (m_MaxValue - m_MinValue)) % 360;
            if (brushAngle < 0) brushAngle += 360;
            double needleAngle = brushAngle * Math.PI / 180;

            int needleWidth = (int)(m_NeedleWidth * centerFactor);
            int needleRadius = (int)(m_NeedleRadius * centerFactor);
            switch (m_NeedleType)
            {
                case NeedleType.Advance:
                    PointF[] points = new PointF[3];

                    int subcol = (int)((brushAngle + 225) % 180 * 100 / 180);
                    int subcol2 = (int)((brushAngle + 135) % 180 * 100 / 180);

                    using (SolidBrush brNeedle = new(m_NeedleColor2))
                    {
                        e.Graphics.FillEllipse(brNeedle, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                    }

                    Color clr1 = Color.White;
                    Color clr2 = Color.White;
                    Color clr3 = Color.White;
                    Color clr4 = Color.White;

                    switch (m_NeedleColor1)
                    {
                        case RftGaugeNeedleColor.Gray:
                            clr1 = Color.FromArgb(80 + subcol, 80 + subcol, 80 + subcol);
                            clr2 = Color.FromArgb(180 - subcol, 180 - subcol, 180 - subcol);
                            clr3 = Color.FromArgb(80 + subcol2, 80 + subcol2, 80 + subcol2);
                            clr4 = Color.FromArgb(180 - subcol2, 180 - subcol2, 180 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Gray, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case RftGaugeNeedleColor.Red:
                            clr1 = Color.FromArgb(145 + subcol, subcol, subcol);
                            clr2 = Color.FromArgb(245 - subcol, 100 - subcol, 100 - subcol);
                            clr3 = Color.FromArgb(145 + subcol2, subcol2, subcol2);
                            clr4 = Color.FromArgb(245 - subcol2, 100 - subcol2, 100 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Red, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case RftGaugeNeedleColor.Green:
                            clr1 = Color.FromArgb(subcol, 145 + subcol, subcol);
                            clr2 = Color.FromArgb(100 - subcol, 245 - subcol, 100 - subcol);
                            clr3 = Color.FromArgb(subcol2, 145 + subcol2, subcol2);
                            clr4 = Color.FromArgb(100 - subcol2, 245 - subcol2, 100 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Green, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case RftGaugeNeedleColor.Blue:
                            clr1 = Color.FromArgb(subcol, subcol, 145 + subcol);
                            clr2 = Color.FromArgb(100 - subcol, 100 - subcol, 245 - subcol);
                            clr3 = Color.FromArgb(subcol2, subcol2, 145 + subcol2);
                            clr4 = Color.FromArgb(100 - subcol2, 100 - subcol2, 245 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Blue, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case RftGaugeNeedleColor.Magenta:
                            clr1 = Color.FromArgb(subcol, 145 + subcol, 145 + subcol);
                            clr2 = Color.FromArgb(100 - subcol, 245 - subcol, 245 - subcol);
                            clr3 = Color.FromArgb(subcol2, 145 + subcol2, 145 + subcol2);
                            clr4 = Color.FromArgb(100 - subcol2, 245 - subcol2, 245 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Magenta, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case RftGaugeNeedleColor.Violet:
                            clr1 = Color.FromArgb(145 + subcol, subcol, 145 + subcol);
                            clr2 = Color.FromArgb(245 - subcol, 100 - subcol, 245 - subcol);
                            clr3 = Color.FromArgb(145 + subcol2, subcol2, 145 + subcol2);
                            clr4 = Color.FromArgb(245 - subcol2, 100 - subcol2, 245 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Violet, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                        case RftGaugeNeedleColor.Yellow:
                            clr1 = Color.FromArgb(145 + subcol, 145 + subcol, subcol);
                            clr2 = Color.FromArgb(245 - subcol, 245 - subcol, 100 - subcol);
                            clr3 = Color.FromArgb(145 + subcol2, 145 + subcol2, subcol2);
                            clr4 = Color.FromArgb(245 - subcol2, 245 - subcol2, 100 - subcol2);
                            e.Graphics.DrawEllipse(Pens.Violet, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                            break;
                    }

                    if (Math.Floor((float)((brushAngle + 225) % 360 / 180.0)) == 0)
                    {
                        (clr2, clr1) = (clr1, clr2);
                    }

                    if (Math.Floor((float)((brushAngle + 135) % 360 / 180.0)) == 0)
                    {
                        clr4 = clr3;
                    }

                    using (Brush brush1 = new SolidBrush(clr1))
                    using (Brush brush2 = new SolidBrush(clr2))
                    using (Brush brush3 = new SolidBrush(clr3))
                    using (Brush brush4 = new SolidBrush(clr4))
                    {
                        points[0].X = (float)(center.X + needleRadius * Math.Cos(needleAngle));
                        points[0].Y = (float)(center.Y + needleRadius * Math.Sin(needleAngle));
                        points[1].X = (float)(center.X - needleRadius / 20 * Math.Cos(needleAngle));
                        points[1].Y = (float)(center.Y - needleRadius / 20 * Math.Sin(needleAngle));
                        points[2].X = (float)(center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                        points[2].Y = (float)(center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                        e.Graphics.FillPolygon(brush1, points);

                        points[2].X = (float)(center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                        points[2].Y = (float)(center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                        e.Graphics.FillPolygon(brush2, points);

                        points[0].X = (float)(center.X - (needleRadius / 20 - 1) * Math.Cos(needleAngle));
                        points[0].Y = (float)(center.Y - (needleRadius / 20 - 1) * Math.Sin(needleAngle));
                        points[1].X = (float)(center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle + Math.PI / 2));
                        points[1].Y = (float)(center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle + Math.PI / 2));
                        points[2].X = (float)(center.X - needleRadius / 5 * Math.Cos(needleAngle) + needleWidth * 2 * Math.Cos(needleAngle - Math.PI / 2));
                        points[2].Y = (float)(center.Y - needleRadius / 5 * Math.Sin(needleAngle) + needleWidth * 2 * Math.Sin(needleAngle - Math.PI / 2));
                        e.Graphics.FillPolygon(brush4, points);

                        points[0].X = (float)(center.X - needleRadius / 20 * Math.Cos(needleAngle));
                        points[0].Y = (float)(center.Y - needleRadius / 20 * Math.Sin(needleAngle));
                        points[1].X = (float)(center.X + needleRadius * Math.Cos(needleAngle));
                        points[1].Y = (float)(center.Y + needleRadius * Math.Sin(needleAngle));

                        using Pen pnNeedle = new(m_NeedleColor2);
                        e.Graphics.DrawLine(pnNeedle, center.X, center.Y, points[0].X, points[0].Y);
                        e.Graphics.DrawLine(pnNeedle, center.X, center.Y, points[1].X, points[1].Y);
                    }
                    break;
                case NeedleType.Simple:
                    Point startPoint = new((int)(center.X - needleRadius / 8 * Math.Cos(needleAngle)), (int)(center.Y - needleRadius / 8 * Math.Sin(needleAngle)));
                    Point endPoint = new((int)(center.X + needleRadius * Math.Cos(needleAngle)), (int)(center.Y + needleRadius * Math.Sin(needleAngle)));

                    using (SolidBrush brDisk = new(m_NeedleColor2))
                    {
                        e.Graphics.FillEllipse(brDisk, center.X - needleWidth * 3, center.Y - needleWidth * 3, needleWidth * 6, needleWidth * 6);
                    }

                    using (Pen pnLine = new(GetColor(m_NeedleColor1), needleWidth))
                    {
                        e.Graphics.DrawLine(pnLine, center.X, center.Y, endPoint.X, endPoint.Y);
                        e.Graphics.DrawLine(pnLine, center.X, center.Y, startPoint.X, startPoint.Y);
                    }
                    break;
            }
            #endregion
        }

        private static Color GetColor(RftGaugeNeedleColor clr)
        {
            switch (clr)
            {
                case RftGaugeNeedleColor.Gray:
                    return Color.DarkGray;
                case RftGaugeNeedleColor.Red:
                    return Color.Red;
                case RftGaugeNeedleColor.Green:
                    return Color.Green;
                case RftGaugeNeedleColor.Blue:
                    return Color.Blue;
                case RftGaugeNeedleColor.Yellow:
                    return Color.Yellow;
                case RftGaugeNeedleColor.Violet:
                    return Color.Violet;
                case RftGaugeNeedleColor.Magenta:
                    return Color.Magenta;
                default:
                    Debug.Fail("Missing enumeration");
                    return Color.DarkGray;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            drawGaugeBackground = true;
            Refresh();
        }
        #endregion
    }

    #region[ Gauge Range ]
    public class RftGaugeRangeCollection(RftGaugeCC_0 sender) : CollectionBase
    {
        private readonly RftGaugeCC_0 Owner = sender;

        public RftGaugeRange this[int index]
        {
            get { return (RftGaugeRange)List[index]!; }
        }
        public bool Contains(RftGaugeRange itemType)
        {
            return List.Contains(itemType);
        }
        public int Add(RftGaugeRange itemType)
        {
            itemType.SetOwner(Owner);
            if (string.IsNullOrEmpty(itemType.Name)) itemType.Name = GetUniqueName();
            int ret = List.Add(itemType);
            Owner?.RepaintControl();
            return ret;
        }
        public void Remove(RftGaugeRange itemType)
        {
            List.Remove(itemType);
            Owner?.RepaintControl();
        }
        public void Insert(int index, RftGaugeRange itemType)
        {
            itemType.SetOwner(Owner);
            if (string.IsNullOrEmpty(itemType.Name)) itemType.Name = GetUniqueName();
            List.Insert(index, itemType);
            Owner?.RepaintControl();
        }
        public int IndexOf(RftGaugeRange itemType)
        {
            return List.IndexOf(itemType);
        }
        public RftGaugeRange? FindByName(string name)
        {
            foreach (RftGaugeRange ptrRange in List)
            {
                if (ptrRange.Name == name) return ptrRange;
            }
            return null;
        }

        protected override void OnInsert(int index, object? value)
        {
            if (string.IsNullOrEmpty(((RftGaugeRange)value!).Name)) ((RftGaugeRange)value).Name = GetUniqueName();
            base.OnInsert(index, value);
            ((RftGaugeRange)value).SetOwner(Owner);
        }
        protected override void OnRemove(int index, object? value)
        {
            Owner?.RepaintControl();
        }
        protected override void OnClear()
        {
            Owner?.RepaintControl();
        }

        private string GetUniqueName()
        {
            const string Prefix = "GaugeRange";
            int index = 1;
            bool valid;
            while (Count != 0)
            {
                valid = true;
                for (int x = 0; x < Count; x++)
                {
                    if (this[x].Name == Prefix + index.ToString())
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid) break;
                index++;
            };
            return Prefix + index.ToString();
        }
    }

    public class RftGaugeRange
    {
        public RftGaugeRange() { }

        public RftGaugeRange(Color color, float startValue, float endValue)
        {
            Color = color;
            _StartValue = startValue;
            _EndValue = endValue;
        }

        public RftGaugeRange(Color color, float startValue, float endValue, int innerRadius, int outerRadius)
        {
            Color = color;
            _StartValue = startValue;
            _EndValue = endValue;
            InnerRadius = innerRadius;
            OuterRadius = outerRadius;
        }

        [Browsable(true),
        Category("Design"),
        DisplayName("(Name)"),
        Description("Instance Name.")]
        public string? Name { get; set; }

        [Browsable(false)]
        public bool InRange { get; set; }

        private RftGaugeCC_0? Owner;
        [Browsable(false)]
        public void SetOwner(RftGaugeCC_0 value)
        {
            Owner = value;
        }
        private void NotifyOwner()
        {
            Owner?.RepaintControl();
        }

        [Browsable(true),
        Category("Appearance"),
        Description("The color of the range.")]
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; NotifyOwner(); }
        }
        private Color _Color;

        [Browsable(true),
        Category("Limits"),
        Description("The start value of the range, must be less than RangeEndValue.")]
        public float StartValue
        {
            get { return _StartValue; }
            set
            {
                if (Owner != null)
                {
                    if (value < Owner.MinValue) value = Owner.MinValue;
                    if (value > Owner.MaxValue) value = Owner.MaxValue;
                }
                _StartValue = value; NotifyOwner();
            }
        }
        private float _StartValue;

        [Browsable(true),
        Category("Limits"),
        Description("The end value of the range. Must be greater than RangeStartValue.")]
        public float EndValue
        {
            get { return _EndValue; }
            set
            {
                if (Owner != null)
                {
                    if (value < Owner.MinValue) value = Owner.MinValue;
                    if (value > Owner.MaxValue) value = Owner.MaxValue;
                }
                _EndValue = value; NotifyOwner();
            }
        }
        private float _EndValue;

        [Browsable(true),
        Category("Appearance"),
        Description("The inner radius of the range.")]
        public int InnerRadius
        {
            get { return _InnerRadius; }
            set { if (value > 0) _InnerRadius = value; NotifyOwner(); }
        }
        private int _InnerRadius = 70;

        [Browsable(true),
        Category("Appearance"),
        Description("The outer radius of the range.")]
        public int OuterRadius
        {
            get { return _OuterRadius; }
            set { if (value > 0) _OuterRadius = value; NotifyOwner(); }
        }
        private int _OuterRadius = 80;
    }
    #endregion

    #region [ Gauge Label ]
    public class RftGaugeLabelCollection(RftGaugeCC_0 sender) : CollectionBase
    {
        private readonly RftGaugeCC_0 Owner = sender;

        public RftGaugeLabel this[int index]
        {
            get { return (RftGaugeLabel)List[index]!; }
        }
        public bool Contains(RftGaugeLabel itemType)
        {
            return List.Contains(itemType);
        }
        public int Add(RftGaugeLabel itemType)
        {
            itemType.SetOwner(Owner);
            if (string.IsNullOrEmpty(itemType.Name)) itemType.Name = GetUniqueName();
            int ret = List.Add(itemType);
            Owner?.RepaintControl();
            return ret;
        }
        public void Remove(RftGaugeLabel itemType)
        {
            List.Remove(itemType);
            Owner?.RepaintControl();
        }
        public void Insert(int index, RftGaugeLabel itemType)
        {
            itemType.SetOwner(Owner);
            if (string.IsNullOrEmpty(itemType.Name)) itemType.Name = GetUniqueName();
            List.Insert(index, itemType);
            Owner?.RepaintControl();
        }
        public int IndexOf(RftGaugeLabel itemType)
        {
            return List.IndexOf(itemType);
        }
        public RftGaugeLabel? FindByName(string name)
        {
            foreach (RftGaugeLabel ptrRange in List)
            {
                if (ptrRange.Name == name) return ptrRange;
            }
            return null;
        }

        protected override void OnInsert(int index, object? value)
        {
            if (string.IsNullOrEmpty(((RftGaugeLabel)value!).Name)) ((RftGaugeLabel)value).Name = GetUniqueName();
            base.OnInsert(index, value);
            ((RftGaugeLabel)value).SetOwner(Owner);
        }
        protected override void OnRemove(int index, object? value)
        {
            Owner?.RepaintControl();
        }
        protected override void OnClear()
        {
            Owner?.RepaintControl();
        }

        private string GetUniqueName()
        {
            const string Prefix = "GaugeLabel";
            int index = 1;
            while (Count != 0)
            {
                for (int x = 0; x < Count; x++)
                {
                    if (this[x].Name == Prefix + index.ToString()) continue;
                    else return Prefix + index.ToString();
                }
                index++;
            };
            return Prefix + index.ToString();
        }
    }

    public class RftGaugeLabel
    {
        [Browsable(true),
        Category("Design"),
        DisplayName("(Name)"),
        Description("Instance Name.")]
        public string? Name { get; set; }

        private RftGaugeCC_0? Owner;
        [Browsable(false)]
        public void SetOwner(RftGaugeCC_0 value)
        {
            Owner = value;
        }
        private void NotifyOwner()
        {
            Owner?.RepaintControl();
        }

        [Browsable(true),
        Category("Appearance"),
        Description("The color of the caption text.")]
        public Color Color
        {
            get { return _Color; }
            set { _Color = value; NotifyOwner(); }
        }
        private Color _Color = Color.FromKnownColor(KnownColor.WindowText);

        [Browsable(true),
        Category("Appearance"),
        Description("The text of the caption.")]
        public string? Text
        {
            get { return _Text; }
            set { _Text = value; NotifyOwner(); }
        }
        private string? _Text;

        [Browsable(true),
        Category("Appearance"),
        Description("The position of the caption.")]
        public Point Position
        {
            get { return _Position; }
            set { _Position = value; NotifyOwner(); }
        }
        private Point _Position;

        [Browsable(true),
        Category("Appearance"),
        Description("Font of Text.")]
        public Font Font
        {
            get { return _Font; }
            set { _Font = value; NotifyOwner(); }
        }
        private Font _Font = DefaultFont;

        public void ResetFont()
        {
            _Font = DefaultFont;
        }
        private bool ShouldSerializeFont()
        {
            return _Font != DefaultFont;
        }
        private static readonly Font DefaultFont = Control.DefaultFont;
    }
    #endregion

    #region [ Gauge Enum ]

    public enum RftGaugeNeedleColor
    {
        Gray = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Yellow = 4,
        Violet = 5,
        Magenta = 6
    };

    public enum NeedleType
    {
        Advance,
        Simple
    }

    #endregion

    #region [ EventArgs ]
    public class ValueInRangeChangedEventArgs(RftGaugeRange range, float value, bool inRange) : EventArgs
    {
        public RftGaugeRange Range { get; private set; } = range;
        public float Value { get; private set; } = value;
        public bool InRange { get; private set; } = inRange;
    }
    #endregion

    [CompilerGenerated]
    class NamespaceDoc { }
}
