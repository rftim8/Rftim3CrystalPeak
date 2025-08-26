using System.Windows.Forms;

namespace Rftim3WinFormsUCL.RftFactory
{
    partial class RftRepairUC_0
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            menuStrip1 = new MenuStrip();
            sToolStripMenuItem = new ToolStripMenuItem();
            sendShiftReportToolStripMenuItem = new ToolStripMenuItem();
            sendFullReportToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            progressBar1 = new ProgressBar();
            tableLayoutPanel1 = new TableLayoutPanel();
            Counter_box = new GroupBox();
            Counter_lbl = new Label();
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            Result_group_box = new GroupBox();
            Result_label = new Label();
            groupBox4 = new GroupBox();
            IN_grid = new DataGridView();
            groupBox5 = new GroupBox();
            Excel_grid = new DataGridView();
            Email_To_Grid = new DataGridView();
            Email_CC_grid = new DataGridView();
            Email_shift_grid = new DataGridView();
            OUT_grid = new DataGridView();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox7 = new GroupBox();
            SerialnumberOUT_text_box = new TextBox();
            groupBox6 = new GroupBox();
            SerialnumberIN_text_box = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            Counter_box.SuspendLayout();
            groupBox2.SuspendLayout();
            Result_group_box.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)IN_grid).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Excel_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Email_To_Grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Email_CC_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Email_shift_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OUT_grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.Items.AddRange(new ToolStripItem[] { sToolStripMenuItem, sendShiftReportToolStripMenuItem, sendFullReportToolStripMenuItem, logOutToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(966, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.Image = Properties.Resources.RftIconSaveAs_16x;
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(75, 29);
            sToolStripMenuItem.Text = "Save As";
            sToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // sendShiftReportToolStripMenuItem
            // 
            sendShiftReportToolStripMenuItem.Image = Properties.Resources.RftIconSendEmail_16x;
            sendShiftReportToolStripMenuItem.Name = "sendShiftReportToolStripMenuItem";
            sendShiftReportToolStripMenuItem.Size = new Size(126, 29);
            sendShiftReportToolStripMenuItem.Text = "Send Shift Report";
            sendShiftReportToolStripMenuItem.Click += SendReportToolStripMenuItem1_Click;
            // 
            // sendFullReportToolStripMenuItem
            // 
            sendFullReportToolStripMenuItem.Image = Properties.Resources.RftIconSendEmail_16x;
            sendFullReportToolStripMenuItem.Name = "sendFullReportToolStripMenuItem";
            sendFullReportToolStripMenuItem.Size = new Size(121, 29);
            sendFullReportToolStripMenuItem.Text = "Send Full Report";
            sendFullReportToolStripMenuItem.Click += SendFullReportToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Image = Properties.Resources.RftIconLogin_16x;
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(78, 29);
            logOutToolStripMenuItem.Text = "Log Out";
            logOutToolStripMenuItem.Click += LogOutToolStripMenuItem1_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.RftIconExit_16x;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(53, 29);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItem1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Fill;
            progressBar1.Location = new Point(969, 3);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(960, 27);
            progressBar1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(menuStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(progressBar1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1932, 33);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // Counter_box
            // 
            Counter_box.Controls.Add(Counter_lbl);
            Counter_box.Dock = DockStyle.Fill;
            Counter_box.Location = new Point(3, 3);
            Counter_box.Name = "Counter_box";
            Counter_box.Size = new Size(269, 152);
            Counter_box.TabIndex = 3;
            Counter_box.TabStop = false;
            Counter_box.Text = "Counter";
            // 
            // Counter_lbl
            // 
            Counter_lbl.AutoSize = true;
            Counter_lbl.Location = new Point(3, 19);
            Counter_lbl.Name = "Counter_lbl";
            Counter_lbl.Size = new Size(38, 15);
            Counter_lbl.TabIndex = 0;
            Counter_lbl.Text = "label1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(3, 161);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(269, 99);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Database";
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.Location = new Point(3, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(263, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // Result_group_box
            // 
            tableLayoutPanel2.SetColumnSpan(Result_group_box, 2);
            Result_group_box.Controls.Add(Result_label);
            Result_group_box.Dock = DockStyle.Fill;
            Result_group_box.Location = new Point(278, 3);
            Result_group_box.Name = "Result_group_box";
            Result_group_box.Size = new Size(546, 152);
            Result_group_box.TabIndex = 0;
            Result_group_box.TabStop = false;
            Result_group_box.Text = "Result";
            // 
            // Result_label
            // 
            Result_label.AutoSize = true;
            Result_label.Dock = DockStyle.Fill;
            Result_label.Location = new Point(3, 19);
            Result_label.Name = "Result_label";
            Result_label.Size = new Size(38, 15);
            Result_label.TabIndex = 0;
            Result_label.Text = "label1";
            // 
            // groupBox4
            // 
            tableLayoutPanel2.SetColumnSpan(groupBox4, 3);
            groupBox4.Controls.Add(IN_grid);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(3, 266);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(821, 417);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Register IN";
            // 
            // IN_grid
            // 
            IN_grid.AllowUserToAddRows = false;
            IN_grid.AllowUserToDeleteRows = false;
            IN_grid.AllowUserToResizeColumns = false;
            IN_grid.AllowUserToResizeRows = false;
            IN_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            IN_grid.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            IN_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            IN_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            IN_grid.DefaultCellStyle = dataGridViewCellStyle2;
            IN_grid.Dock = DockStyle.Fill;
            IN_grid.Location = new Point(3, 19);
            IN_grid.Name = "IN_grid";
            IN_grid.ReadOnly = true;
            IN_grid.RowHeadersVisible = false;
            IN_grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            IN_grid.Size = new Size(815, 395);
            IN_grid.TabIndex = 0;
            // 
            // groupBox5
            // 
            tableLayoutPanel2.SetColumnSpan(groupBox5, 3);
            groupBox5.Controls.Add(Excel_grid);
            groupBox5.Controls.Add(Email_To_Grid);
            groupBox5.Controls.Add(Email_CC_grid);
            groupBox5.Controls.Add(Email_shift_grid);
            groupBox5.Controls.Add(OUT_grid);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Location = new Point(3, 689);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(821, 417);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Register OUT";
            // 
            // Excel_grid
            // 
            Excel_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Excel_grid.Location = new Point(575, 35);
            Excel_grid.Name = "Excel_grid";
            Excel_grid.Size = new Size(240, 150);
            Excel_grid.TabIndex = 4;
            Excel_grid.Visible = false;
            // 
            // Email_To_Grid
            // 
            Email_To_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Email_To_Grid.Location = new Point(575, 221);
            Email_To_Grid.Name = "Email_To_Grid";
            Email_To_Grid.Size = new Size(240, 150);
            Email_To_Grid.TabIndex = 3;
            Email_To_Grid.Visible = false;
            // 
            // Email_CC_grid
            // 
            Email_CC_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Email_CC_grid.Location = new Point(302, 221);
            Email_CC_grid.Name = "Email_CC_grid";
            Email_CC_grid.Size = new Size(240, 150);
            Email_CC_grid.TabIndex = 2;
            Email_CC_grid.Visible = false;
            // 
            // Email_shift_grid
            // 
            Email_shift_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Email_shift_grid.Location = new Point(302, 35);
            Email_shift_grid.Name = "Email_shift_grid";
            Email_shift_grid.Size = new Size(240, 150);
            Email_shift_grid.TabIndex = 1;
            Email_shift_grid.Visible = false;
            // 
            // OUT_grid
            // 
            OUT_grid.AllowUserToAddRows = false;
            OUT_grid.AllowUserToDeleteRows = false;
            OUT_grid.AllowUserToResizeColumns = false;
            OUT_grid.AllowUserToResizeRows = false;
            OUT_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OUT_grid.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            OUT_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            OUT_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            OUT_grid.DefaultCellStyle = dataGridViewCellStyle4;
            OUT_grid.Dock = DockStyle.Fill;
            OUT_grid.Location = new Point(3, 19);
            OUT_grid.Name = "OUT_grid";
            OUT_grid.ReadOnly = true;
            OUT_grid.RowHeadersVisible = false;
            OUT_grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            OUT_grid.Size = new Size(815, 395);
            OUT_grid.TabIndex = 0;
            // 
            // chart1
            // 
            chart1.BackColor = Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap;
            chartArea1.AxisX.LabelStyle.Angle = 90;
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.AxisX.MajorGrid.Interval = 1D;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisX.ScaleBreakStyle.CollapsibleSpaceThreshold = 10;
            chartArea1.AxisY.MajorGrid.LineWidth = 0;
            chartArea1.BackColor = Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.Dock = DockStyle.Fill;
            legend1.BackColor = Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(830, 3);
            chart1.Name = "chart1";
            tableLayoutPanel2.SetRowSpan(chart1, 4);
            series1.ChartArea = "ChartArea1";
            series1.IsValueShownAsLabel = true;
            series1.LabelAngle = 90;
            series1.Legend = "Legend1";
            series1.Name = "Default";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1099, 1103);
            chart1.TabIndex = 4;
            chart1.Text = "chart1";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57.1428566F));
            tableLayoutPanel2.Controls.Add(groupBox7, 2, 1);
            tableLayoutPanel2.Controls.Add(Counter_box, 0, 0);
            tableLayoutPanel2.Controls.Add(chart1, 3, 0);
            tableLayoutPanel2.Controls.Add(groupBox2, 0, 1);
            tableLayoutPanel2.Controls.Add(groupBox4, 0, 2);
            tableLayoutPanel2.Controls.Add(Result_group_box, 1, 0);
            tableLayoutPanel2.Controls.Add(groupBox5, 0, 3);
            tableLayoutPanel2.Controls.Add(groupBox6, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 33);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.523809F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 38.0952377F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 38.0952377F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1932, 1131);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(SerialnumberOUT_text_box);
            groupBox7.Dock = DockStyle.Fill;
            groupBox7.Location = new Point(554, 161);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(270, 99);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "Register OUT";
            // 
            // SerialnumberOUT_text_box
            // 
            SerialnumberOUT_text_box.Dock = DockStyle.Fill;
            SerialnumberOUT_text_box.Location = new Point(3, 19);
            SerialnumberOUT_text_box.Name = "SerialnumberOUT_text_box";
            SerialnumberOUT_text_box.Size = new Size(264, 23);
            SerialnumberOUT_text_box.TabIndex = 0;
            SerialnumberOUT_text_box.Click += SerialnumberOUT_text_box_Click;
            SerialnumberOUT_text_box.PreviewKeyDown += SerialnumberOUT_text_box_PreviewKeyDown;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(SerialnumberIN_text_box);
            groupBox6.Dock = DockStyle.Fill;
            groupBox6.Location = new Point(278, 161);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(270, 99);
            groupBox6.TabIndex = 4;
            groupBox6.TabStop = false;
            groupBox6.Text = "Register IN";
            // 
            // SerialnumberIN_text_box
            // 
            SerialnumberIN_text_box.Dock = DockStyle.Fill;
            SerialnumberIN_text_box.Location = new Point(3, 19);
            SerialnumberIN_text_box.Name = "SerialnumberIN_text_box";
            SerialnumberIN_text_box.Size = new Size(264, 23);
            SerialnumberIN_text_box.TabIndex = 0;
            SerialnumberIN_text_box.Click += SerialnumberIN_text_box_Click;
            SerialnumberIN_text_box.PreviewKeyDown += SerialnumberIN_text_box_PreviewKeyDown;
            // 
            // statusStrip1
            // 
            statusStrip1.AutoSize = false;
            statusStrip1.GripStyle = ToolStripGripStyle.Visible;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel3 });
            statusStrip1.Location = new Point(0, 1142);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(1932, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.Stretch = false;
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Image = Properties.Resources.RftIconAssembly_16x;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(639, 17);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Image = Properties.Resources.RftIconUser_16x;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(639, 17);
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Image = Properties.Resources.RftIconStation_16x;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(639, 17);
            toolStripStatusLabel3.Spring = true;
            toolStripStatusLabel3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RftRepairUC_0
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusStrip1);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "RftRepairUC_0";
            Size = new Size(1932, 1164);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            Counter_box.ResumeLayout(false);
            Counter_box.PerformLayout();
            groupBox2.ResumeLayout(false);
            Result_group_box.ResumeLayout(false);
            Result_group_box.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)IN_grid).EndInit();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Excel_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Email_To_Grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Email_CC_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Email_shift_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)OUT_grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem sendShiftReportToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem sendFullReportToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ProgressBar progressBar1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox Counter_box;
        private GroupBox groupBox2;
        private GroupBox Result_group_box;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private TableLayoutPanel tableLayoutPanel2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private ComboBox comboBox1;
        private TextBox SerialnumberOUT_text_box;
        private TextBox SerialnumberIN_text_box;
        private DataGridView IN_grid;
        private DataGridView OUT_grid;
        private DataGridView Email_shift_grid;
        private DataGridView Email_CC_grid;
        private DataGridView Excel_grid;
        private DataGridView Email_To_Grid;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private Label Result_label;
        private Label Counter_lbl;
    }
}
