namespace Rftim3WinFormsUCL.RftPrintPreviewControl
{
    partial class RftPrintPreviewControlUC_0
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
            printPreviewControl1 = new PrintPreviewControl();
            SuspendLayout();
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Location = new Point(0, 0);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(135, 118);
            printPreviewControl1.TabIndex = 0;
            // 
            // RftPrintPreviewControlUC_0
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(printPreviewControl1);
            Name = "RftPrintPreviewControlUC_0";
            ResumeLayout(false);
        }

        #endregion

        private PrintPreviewControl printPreviewControl1;
    }
}
