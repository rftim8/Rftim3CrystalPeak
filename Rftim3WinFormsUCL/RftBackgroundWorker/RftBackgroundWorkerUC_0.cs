using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.ComponentModel;

namespace Rftim3WinFormsUCL.RftBackgroundWorker
{
    public partial class RftBackgroundWorkerUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftBackgroundWorkerUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        struct ProgressParameter
        {
            public int Process;
            public int Delay;
        }

        private ProgressParameter progressParameter;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressParameter.Delay = 10;
                progressParameter.Process = 1200;
                backgroundWorker1.RunWorkerAsync(progressParameter);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int process = ((ProgressParameter)e.Argument!).Process;
            int delay = ((ProgressParameter)e.Argument).Delay;
            int index = 1;
            try
            {
                for (int i = 0; i < process; i++)
                {
                    if (!backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.ReportProgress(index++ * 100 / process, string.Format("Process data {0}", i));
                        Thread.Sleep(delay);
                    }
                    else e.Cancel = true;
                }
            }
            catch (Exception r)
            {
                backgroundWorker1.CancelAsync();
                MessageBox.Show(r.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = $"Processing...{e.ProgressPercentage}%";
            progressBar1.Update();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Process stopped!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Process completed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
