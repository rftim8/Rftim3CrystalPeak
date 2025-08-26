namespace Rftim3LeetCode.Temp
{
    public class _01108_DefangingAnIPAddress
    {
        /// <summary>
        /// Given a valid (IPv4) IP address, return a defanged version of that IP address.
        /// A defanged IP address replaces every period "." with "[.]".
        /// </summary>
        public _01108_DefangingAnIPAddress()
        {
            Console.WriteLine(DefangIPaddr("1.1.1.1"));
            Console.WriteLine(DefangIPaddr("255.100.50.0"));
        }

        private static string DefangIPaddr(string address)
        {
            return address.Replace(".", "[.]");
        }
    }
}
