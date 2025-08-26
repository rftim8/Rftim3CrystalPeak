using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.Versioning;
using System.Diagnostics.CodeAnalysis;

namespace Rftim3Console.System.DirectoryServices
{
    [SupportedOSPlatform("windows")]
    public class RftADLocalGroups
    {
        public RftADLocalGroups()
        {
            RftPrintGroup();
            //RftPrintUserGroup();
        }

        private static void RftPrintGroup()
        {
            DirectoryEntry localMachine = new($"WinNT://{Environment.MachineName},Computer");
            Console.WriteLine($"WinNT://{Environment.MachineName}");
            DirectoryEntry admGroup = localMachine.Children.Find("users", "group");
            object? members = admGroup.Invoke("members", null);

            if (members is not null)
            {
                foreach (object groupMember in (IEnumerable)members)
                {
                    DirectoryEntry member = new(groupMember);
                    Console.WriteLine($"{member.Name}\n");
                }
            }
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private static void RftPrintUserGroup()
        {
            string groupName = @"Administrator";
            string domainName = @"domain.com";

            Console.WriteLine($"{groupName}\n");

            try
            {
                PrincipalContext ctx = new(ContextType.Domain, domainName);
                GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);
                if (grp is not null)
                {
                    foreach (Principal p in grp.GetMembers(false))
                    {
                        Console.WriteLine($"{p.SamAccountName} - {p.DisplayName}\n");
                    }
                }
                else Console.WriteLine("No users");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
