namespace Rftim3WinFormsUCL.RftPropertyGrid
{
    partial class RftPropertyGridUC_0
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
            checkedListBox1 = new CheckedListBox();
            propertyGrid1 = new PropertyGrid();
            button1 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(3, 59);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(170, 364);
            checkedListBox1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Location = new Point(332, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(271, 566);
            propertyGrid1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(6, 438);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            // 
            // RftUCPropertyGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(propertyGrid1);
            Controls.Add(checkedListBox1);
            Name = "RftUCPropertyGrid";
            Size = new Size(837, 572);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private PropertyGrid propertyGrid1;
        private Button button1;
        private TextBox textBox1;
    }
}
