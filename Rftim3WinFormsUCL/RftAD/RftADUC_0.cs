using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Rftim3WinFormsUCL.RftAD
{
    public partial class RftADUC_0 : UserControl
    {
        private readonly IRftUserControlCL rftUserControlCL;

        public RftADUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DirectoryEntry localMachine = new($"WinNT://{Environment.MachineName},Computer");
            DirectoryEntry admGroup = localMachine.Children.Find("administrators", "group");
            object? members = admGroup.Invoke("members", null);

            if (members != null)
            {
                foreach (object groupMember in (IEnumerable)members)
                {
                    DirectoryEntry member = new(groupMember);
                    textBox1.Text += $"{member.Name}{Environment.NewLine}";
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string groupName = @"Administrator";
            string domainName = @"domain.com";

            textBox2.Text += $"{groupName}{Environment.NewLine}";
            try
            {
                PrincipalContext ctx = new(ContextType.Domain, domainName);
                GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);

                if (grp is not null)
                {
                    foreach (Principal p in grp.GetMembers(false))
                    {
                        textBox2.Text += $"{p.SamAccountName} - {p.DisplayName}\n";
                    }
                }
                else textBox2.Text += "No users";
            }
            catch (Exception ex)
            {
                textBox2.Text += ex.Message;
            }
        }
    }
}
