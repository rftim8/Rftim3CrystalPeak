using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _00482_LicenseKeyFormatting
    {
        /// <summary>
        /// You are given a license key represented as a string s that consists of only alphanumeric characters and dashes. 
        /// The string is separated into n + 1 groups by n dashes. You are also given an integer k.
        /// We want to reformat the string s such that each group contains exactly k characters, except for the first group, 
        /// which could be shorter than k but still must contain at least one character.
        /// Furthermore, there must be a dash inserted between two groups, and you should convert all lowercase letters to uppercase.
        /// Return the reformatted license key.
        /// </summary>
        public _00482_LicenseKeyFormatting()
        {
            Console.WriteLine(LicenseKeyFormatting0("5F3Z-2e-9-w", 4));
            Console.WriteLine(LicenseKeyFormatting0("2-5g-3-J", 2));
        }

        public static string LicenseKeyFormatting0(string a0, int a1) => RftLicenseKeyFormatting0(a0, a1);

        public static string LicenseKeyFormatting1(string a0, int a1) => RftLicenseKeyFormatting1(a0, a1);

        private static string RftLicenseKeyFormatting0(string s, int k)
        {
            string r = string.Empty;
            s = s.Replace("-", "");
            int n = s.Length;
            int rem = n % k;

            r += s[..rem].ToUpper();

            int j = 1;
            for (int i = rem; i < n; i++, j++)
            {
                if (j == 1 && i > 0) r += '-';
                r += s[i].ToString().ToUpper();
                if (j == k) j = 0;
            }

            return r;
        }

        private static string RftLicenseKeyFormatting1(string s, int k)
        {
            s = s.Replace("-", "").ToUpper();

            StringBuilder sb = new();

            int firstPartLen = s.Length % k;
            sb.Append(s[0..firstPartLen]);
            sb.Append('-');
            int start = firstPartLen;

            while (start != s.Length)
            {
                sb.Append(s[start..(start + k)]);
                start += k;
                if (start < s.Length) sb.Append('-');
            }
            s = sb.ToString().Trim('-');

            return s;
        }
    }
}
