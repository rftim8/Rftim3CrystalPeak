namespace Rftim3WinFormsUCL.RftListBox
{
    partial class RftListBoxUC_0
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
            label1 = new Label();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 613);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(390, 604);
            listBox1.TabIndex = 3;
            listBox1.QueryContinueDrag += ListDragSource_QueryContinueDrag;
            listBox1.MouseDown += ListDragSource_MouseDown;
            listBox1.MouseMove += ListDragSource_MouseMove;
            listBox1.MouseUp += ListDragSource_MouseUp;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(396, 0);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(386, 604);
            listBox2.TabIndex = 4;
            listBox2.DragDrop += ListDragTarget_DragDrop;
            listBox2.DragEnter += ListDragTarget_DragEnter;
            listBox2.DragOver += ListDragTarget_DragOver;
            listBox2.DragLeave += ListDragTarget_DragLeave;
            // 
            // RftListBoxUC_0
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Name = "RftListBoxUC_0";
            Size = new Size(782, 657);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListBox listBox1;
        private ListBox listBox2;
    }
}
