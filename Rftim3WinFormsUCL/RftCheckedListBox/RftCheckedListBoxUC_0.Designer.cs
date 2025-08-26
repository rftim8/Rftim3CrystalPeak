namespace Rftim3WinFormsUCL.RftCheckedListBox
{
    partial class RftCheckedListBoxUC_0
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            checkedListBox1 = new CheckedListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(20, 17);
            button1.Name = "button1";
            button1.Size = new Size(114, 23);
            button1.TabIndex = 0;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(20, 62);
            button2.Name = "button2";
            button2.Size = new Size(114, 23);
            button2.TabIndex = 1;
            button2.Text = "Check All";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(20, 107);
            button3.Name = "button3";
            button3.Size = new Size(114, 23);
            button3.TabIndex = 2;
            button3.Text = "Uncehck All";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(173, 17);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(440, 400);
            checkedListBox1.TabIndex = 3;
            // 
            // RftUCCheckedListBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkedListBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "RftUCCheckedListBox";
            Size = new Size(661, 453);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private CheckedListBox checkedListBox1;
    }
}
