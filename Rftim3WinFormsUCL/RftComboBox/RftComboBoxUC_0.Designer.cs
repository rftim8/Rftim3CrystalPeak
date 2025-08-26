namespace Rftim3WinFormsUCL.RftComboBox
{
    partial class RftComboBoxUC_0
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
            comboBox1 = new ComboBox();
            listView1 = new ListView();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += CursorSelectionComboBox_SelectedIndexChanged;
            // 
            // listView1
            // 
            listView1.Location = new Point(403, 3);
            listView1.Name = "listView1";
            listView1.Size = new Size(178, 327);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Location = new Point(161, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 2;
            panel1.CursorChanged += TestPanel_CursorChanged;
            // 
            // RftUCComboBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(listView1);
            Controls.Add(comboBox1);
            Name = "RftUCComboBox";
            Size = new Size(590, 338);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private ListView listView1;
        private Panel panel1;
    }
}
