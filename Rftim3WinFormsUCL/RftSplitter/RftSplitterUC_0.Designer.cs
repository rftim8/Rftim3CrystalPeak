namespace Rftim3WinFormsUCL.RftSplitter
{
    partial class RftSplitterUC_0
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
            splitter1 = new Splitter();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.BackColor = Color.MediumTurquoise;
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 150);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // RftSplitterUC_0
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitter1);
            Name = "RftSplitterUC_0";
            ResumeLayout(false);
        }

        #endregion

        private Splitter splitter1;
    }
}
