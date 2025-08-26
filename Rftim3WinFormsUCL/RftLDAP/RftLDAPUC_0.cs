using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rftim3WinFormsCL;
using System.Collections;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace Rftim3WinFormsUCL.RftLDAP
{
    public partial class RftLDAPUC_0 : UserControl
    {
        //ADMethodsAccountManagement ADMethods = new ADMethodsAccountManagement();
        private readonly IRftUserControlCL rftUserControlCL;

        public RftLDAPUC_0(IHost host)
        {
            InitializeComponent();

            rftUserControlCL = host.Services.GetRequiredService<IRftUserControlCL>();
            rftUserControlCL.RftUserControl = this;
            rftUserControlCL.RftContentProperties();

            //UserPrincipal myUser = ADMethods.GetUser("rtimbul");

            //myUser.GivenName = "Remus";
            //myUser.Surname = "Timbuli";
            //myUser.MiddleName = "Flavius";
            //myUser.EmailAddress = "CompanyName.com";
            //myUser.EmployeeId = "90001534";
            //myUser.Save();
        }

        #region Optional
        public ArrayList EnumerateOU(string OuDn)
        {
            ArrayList alObjects = [];
            try
            {
                DirectoryEntry directoryObject = new("LDAP://" + OuDn);
                DirectorySearcher directorySearcher = new(directoryObject);
                textBox2.AppendText(directorySearcher.FindAll().ToString());
                foreach (DirectoryEntry child in directoryObject.Children)
                {
                    string childPath = child.Path.ToString();
                    textBox2.AppendText(childPath + "\n");
                }
            }
            catch (DirectoryServicesCOMException e)
            {
                Console.WriteLine("An Error Occurred: " + e.Message.ToString());
            }

            return alObjects;
        }

        public static bool Exists(string objectPath)
        {
            bool found = false;
            if (DirectoryEntry.Exists("LDAP://" + objectPath)) found = true;

            return found;
        }
        #endregion

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("Infrastructure Role Owner: " + FriendlyDomainToLdapDomain("domain.com") + "\n");
            textBox2.AppendText("Domain Name: " + FriendlyDomainToLdapDomain1("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - SiteName: " + FriendlyDomainToLdapDomain2("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - Roles Count: " + FriendlyDomainToLdapDomain3("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - OS Version: " + FriendlyDomainToLdapDomain4("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - IPAddress: " + FriendlyDomainToLdapDomain5("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - Highest Committed Usn: " + FriendlyDomainToLdapDomain6("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - Forest Root Domain: " + FriendlyDomainToLdapDomain7("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - Forest Mode Level: " + FriendlyDomainToLdapDomain8("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - Forest Schema: " + FriendlyDomainToLdapDomain9("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - Forest Schema Role Owner: " + FriendlyDomainToLdapDomain10("domain.com") + "\n");
            textBox2.AppendText("PdcRoleOwner - Outbound Connections: " + FriendlyDomainToLdapDomain11("domain.com") + "\n");
            textBox2.AppendText("RidRoleOwner: " + FriendlyDomainToLdapDomain12("domain.com") + "\n");
            textBox2.AppendText("Children: " + FriendlyDomainToLdapDomain13("domain.com") + "\n");
        }
        public static string FriendlyDomainToLdapDomain(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.InfrastructureRoleOwner.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain1(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.Name;
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain2(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.SiteName;
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain3(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.Roles.Count.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain4(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.OSVersion.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain5(string friendlyDomainName)
        {
            string? ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.IPAddress?.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath is not null ? ldapPath : "";
        }

        public static string FriendlyDomainToLdapDomain6(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.HighestCommittedUsn.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain7(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.Forest.RootDomain.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain8(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.Forest.ForestModeLevel.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain9(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.Forest.Schema.Name.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain10(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.Forest.SchemaRoleOwner.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain11(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.PdcRoleOwner.OutboundConnections.Count.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain12(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.RidRoleOwner.Name.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        public static string FriendlyDomainToLdapDomain13(string friendlyDomainName)
        {
            string ldapPath;
            try
            {
                DirectoryContext objContext = new(DirectoryContextType.Domain, friendlyDomainName);
                Domain objDomain = Domain.GetDomain(objContext);
                ldapPath = objDomain.Children.Count.ToString();
            }
            catch (DirectoryServicesCOMException e)
            {
                ldapPath = e.Message.ToString();
            }

            return ldapPath;
        }

        ////#######################################################      AD .NET 3.5     ######################################################
        //public class ADMethodsAccountManagement
        //{
        //    #region Variables
        //    private string sDomain = "test.com";
        //    private string sDefaultOU = "OU=Test Users,OU=Test,DC=test,DC=com";
        //    private string sDefaultRootOU = "DC=test,DC=com";
        //    private string sServiceUser = @"ServiceUser";
        //    private string sServicePassword = "ServicePassword";
        //    #endregion

        //    #region Validate Methods
        //    public bool ValidateCredentials(string sUserName, string sPassword)
        //    {
        //        PrincipalContext oPrincipalContext = GetPrincipalContext();
        //        return oPrincipalContext.ValidateCredentials(sUserName, sPassword);
        //    }
        //    public bool IsUserExpired(string sUserName)
        //    {
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);
        //        if (oUserPrincipal.AccountExpirationDate != null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    public bool IsUserExisiting(string sUserName)
        //    {
        //        if (GetUser(sUserName) == null)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    public bool IsAccountLocked(string sUserName)
        //    {
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);
        //        return oUserPrincipal.IsAccountLockedOut();
        //    }
        //    #endregion

        //    #region Search Methods
        //    public UserPrincipal GetUser(string sUserName)
        //    {
        //        PrincipalContext oPrincipalContext = GetPrincipalContext();

        //        UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
        //        return oUserPrincipal;
        //    }

        //    public GroupPrincipal GetGroup(string sGroupName)
        //    {
        //        PrincipalContext oPrincipalContext = GetPrincipalContext();

        //        GroupPrincipal oGroupPrincipal = GroupPrincipal.FindByIdentity(oPrincipalContext, sGroupName);
        //        return oGroupPrincipal;
        //    }
        //    #endregion

        //    #region User Account Methods

        //    public void SetUserPassword(string sUserName, string sNewPassword, out string sMessage)
        //    {
        //        try
        //        {
        //            UserPrincipal oUserPrincipal = GetUser(sUserName);
        //            oUserPrincipal.SetPassword(sNewPassword);
        //            sMessage = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            sMessage = ex.Message;
        //        }
        //    }

        //    public void EnableUserAccount(string sUserName)
        //    {
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);
        //        oUserPrincipal.Enabled = true;
        //        oUserPrincipal.Save();
        //    }

        //    public void DisableUserAccount(string sUserName)
        //    {
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);
        //        oUserPrincipal.Enabled = false;
        //        oUserPrincipal.Save();
        //    }

        //    public void ExpireUserPassword(string sUserName)
        //    {
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);
        //        oUserPrincipal.ExpirePasswordNow();
        //        oUserPrincipal.Save();
        //    }

        //    public void UnlockUserAccount(string sUserName)
        //    {
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);
        //        oUserPrincipal.UnlockAccount();
        //        oUserPrincipal.Save();
        //    }

        //    public UserPrincipal CreateNewUser(string sOU, string sUserName, string sPassword, string sGivenName, string sSurname)
        //    {
        //        if (!IsUserExisiting(sUserName))
        //        {
        //            PrincipalContext oPrincipalContext = GetPrincipalContext(sOU);

        //            UserPrincipal oUserPrincipal = new UserPrincipal(oPrincipalContext, sUserName, sPassword, true);

        //            oUserPrincipal.UserPrincipalName = sUserName;
        //            oUserPrincipal.GivenName = sGivenName;
        //            oUserPrincipal.Surname = sSurname;
        //            oUserPrincipal.Save();

        //            return oUserPrincipal;
        //        }
        //        else
        //        {
        //            return GetUser(sUserName);
        //        }
        //    }

        //    public bool DeleteUser(string sUserName)
        //    {
        //        try
        //        {
        //            UserPrincipal oUserPrincipal = GetUser(sUserName);

        //            oUserPrincipal.Delete();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //    #endregion

        //    #region Group Methods
        //    public GroupPrincipal CreateNewGroup(string sOU, string sGroupName, string sDescription, GroupScope oGroupScope, bool bSecurityGroup)
        //    {
        //        PrincipalContext oPrincipalContext = GetPrincipalContext(sOU);

        //        GroupPrincipal oGroupPrincipal = new GroupPrincipal(oPrincipalContext, sGroupName);
        //        oGroupPrincipal.Description = sDescription;
        //        oGroupPrincipal.GroupScope = oGroupScope;
        //        oGroupPrincipal.IsSecurityGroup = bSecurityGroup;
        //        oGroupPrincipal.Save();

        //        return oGroupPrincipal;
        //    }

        //    public bool AddUserToGroup(string sUserName, string sGroupName)
        //    {
        //        try
        //        {
        //            UserPrincipal oUserPrincipal = GetUser(sUserName);
        //            GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
        //            if (oUserPrincipal == null || oGroupPrincipal == null)
        //            {
        //                if (!IsUserGroupMember(sUserName, sGroupName))
        //                {
        //                    oGroupPrincipal.Members.Add(oUserPrincipal);
        //                    oGroupPrincipal.Save();
        //                }
        //            }
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    public bool RemoveUserFromGroup(string sUserName, string sGroupName)
        //    {
        //        try
        //        {
        //            UserPrincipal oUserPrincipal = GetUser(sUserName);
        //            GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);
        //            if (oUserPrincipal == null || oGroupPrincipal == null)
        //            {
        //                if (IsUserGroupMember(sUserName, sGroupName))
        //                {
        //                    oGroupPrincipal.Members.Remove(oUserPrincipal);
        //                    oGroupPrincipal.Save();
        //                }
        //            }
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }

        //    public bool IsUserGroupMember(string sUserName, string sGroupName)
        //    {
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);
        //        GroupPrincipal oGroupPrincipal = GetGroup(sGroupName);

        //        if (oUserPrincipal == null || oGroupPrincipal == null)
        //        {
        //            return oGroupPrincipal.Members.Contains(oUserPrincipal);
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    public ArrayList GetUserGroups(string sUserName)
        //    {
        //        ArrayList myItems = new ArrayList();
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);

        //        PrincipalSearchResult<Principal> oPrincipalSearchResult = oUserPrincipal.GetGroups();

        //        foreach (Principal oResult in oPrincipalSearchResult)
        //        {
        //            myItems.Add(oResult.Name);
        //        }
        //        return myItems;
        //    }

        //    public ArrayList GetUserAuthorizationGroups(string sUserName)
        //    {
        //        ArrayList myItems = new ArrayList();
        //        UserPrincipal oUserPrincipal = GetUser(sUserName);

        //        PrincipalSearchResult<Principal> oPrincipalSearchResult = oUserPrincipal.GetAuthorizationGroups();

        //        foreach (Principal oResult in oPrincipalSearchResult)
        //        {
        //            myItems.Add(oResult.Name);
        //        }
        //        return myItems;
        //    }
        //    #endregion

        //    #region Helper Methods
        //    public PrincipalContext GetPrincipalContext()
        //    {
        //        PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomain, sDefaultOU, ContextOptions.SimpleBind,sServiceUser, sServicePassword);
        //        return oPrincipalContext;
        //    }

        //    public PrincipalContext GetPrincipalContext(string sOU)
        //    {
        //        PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, sDomain, sOU, ContextOptions.SimpleBind, sServiceUser, sServicePassword);
        //        return oPrincipalContext;
        //    }
        //    #endregion
        //    //###############################################################################################################################
        //}
    }
}
