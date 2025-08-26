namespace Rftim3WinFormsUCL.RftDateTimePicker
{
    partial class RftDateTimePickerUC_0
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
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            comboBox1 = new ComboBox();
            monthCalendar1 = new MonthCalendar();
            button1 = new Button();
            textBox2 = new TextBox();
            listBox1 = new ListBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(77, 63);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(137, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(38, 23);
            textBox1.TabIndex = 1;
            textBox1.KeyPress += TextBox1_keypress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 13);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 2;
            label1.Text = "Max Selection Count";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 68);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 3;
            label2.Text = "Min Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 105);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Max Date";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(77, 101);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 5;
            dateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(16, 146);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(116, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Show Today Date";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(16, 180);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(122, 19);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Show Today Circle";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(16, 230);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(304, 10);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 9;
            monthCalendar1.DateSelected += MonthCalendar1_DateSelected;
            // 
            // button1
            // 
            button1.Location = new Point(304, 234);
            button1.Name = "button1";
            button1.Size = new Size(111, 23);
            button1.TabIndex = 10;
            button1.Text = "Add Description";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(304, 205);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(227, 23);
            textBox2.TabIndex = 11;
            textBox2.TextChanged += TextBox2_TextChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(554, 10);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(175, 154);
            listBox1.TabIndex = 12;
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Location = new Point(615, 180);
            button2.Name = "button2";
            button2.Size = new Size(114, 23);
            button2.TabIndex = 13;
            button2.Text = "Delete Selected";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(615, 209);
            button3.Name = "button3";
            button3.Size = new Size(114, 23);
            button3.TabIndex = 14;
            button3.Text = "Clear All";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(615, 241);
            button4.Name = "button4";
            button4.Size = new Size(114, 23);
            button4.TabIndex = 15;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(304, 181);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 16;
            label4.Text = "label4";
            // 
            // RftUCDateTimePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(listBox1);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(monthCalendar1);
            Controls.Add(comboBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Name = "RftUCDateTimePicker";
            Size = new Size(744, 362);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ComboBox comboBox1;
        private MonthCalendar monthCalendar1;
        private Button button1;
        private TextBox textBox2;
        private ListBox listBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label4;
    }
}
