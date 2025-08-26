﻿using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;

namespace RftWinForms
{
    partial class RftMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RftMainForm));
            notifyIcon1 = new NotifyIcon(components);
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
            // 
            // RftMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RftMainForm";
            Text = "RftTester";
            ResumeLayout(false);
        }

        #endregion

        private NotifyIcon notifyIcon1;
    }
}
