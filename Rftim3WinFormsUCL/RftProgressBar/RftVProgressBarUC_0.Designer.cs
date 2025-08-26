namespace Rftim3WinFormsUCL.RftProgressBarVertical
{
    partial class RftVProgressBarUC_0
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
            rftccProgressBarVertical1 = new Rftim3WinFormsUCL.RftProgressBarVertical.RftVProgressBarCC_0();
            button1 = new Button();
            SuspendLayout();
            // 
            // rftccProgressBarVertical1
            // 
            rftccProgressBarVertical1.Location = new Point(283, 3);
            rftccProgressBarVertical1.Name = "rftccProgressBarVertical1";
            rftccProgressBarVertical1.NumberChunks = 20;
            rftccProgressBarVertical1.Size = new Size(50, 598);
            rftccProgressBarVertical1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // RftUCProgressBarVertical
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(rftccProgressBarVertical1);
            Name = "RftUCProgressBarVertical";
            Size = new Size(336, 604);
            ResumeLayout(false);
        }

        #endregion

        private Rftim3WinFormsUCL.RftProgressBarVertical.RftVProgressBarCC_0 rftccProgressBarVertical1;
        private Button button1;
    }
}
