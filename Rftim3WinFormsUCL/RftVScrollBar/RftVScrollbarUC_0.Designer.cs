namespace Rftim3WinFormsUCL.RftVScrollBar
{
    partial class RftVScrollBarUC_0
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
            vScrollBar1 = new VScrollBar();
            SuspendLayout();
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(0, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(37, 176);
            vScrollBar1.TabIndex = 0;
            // 
            // RftVScrollBarUC_0
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(vScrollBar1);
            Name = "RftVScrollBarUC_0";
            ResumeLayout(false);
        }

        #endregion

        private VScrollBar vScrollBar1;
    }
}
