using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.DirectoryServices;

namespace Rftim3WinFormsUCL.RftAuthentication
{
    public partial class RftAuthenticationUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftAuthenticationUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RftADAuthenticateUser(textBox1.Text, textBox2.Text, maskedTextBox1.Text);
        }

        private bool RftADAuthenticateUser(string path, string user, string pswd)
        {
            DirectoryEntry directoryEntry = new(path, user, pswd, AuthenticationTypes.Secure);

            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pswd))
            {
                try
                {
                    foreach (string strAttrName in directoryEntry.Properties.PropertyNames)
                    {
                        textBox4.Text += $"{strAttrName}{Environment.NewLine}";
                    }

                    DirectorySearcher ds = new(directoryEntry);
                    ds.FindOne();
                    textBox4.Text += "Succedded";
                    return true;
                }
                catch (DirectoryServicesCOMException)
                {
                    textBox4.Text += "Error";
                    return false;
                }
            }

            return false;
        }
    }
}
