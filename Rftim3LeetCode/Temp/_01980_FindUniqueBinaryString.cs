using System.Text;

namespace Rftim3LeetCode.Temp
{
    public class _01980_FindUniqueBinaryString
    {
        /// <summary>
        /// Given an array of strings nums containing n unique binary strings each of length n, 
        /// return a binary string of length n that does not appear in nums.
        /// If there are multiple answers, you may return any of them.
        /// </summary>
        public _01980_FindUniqueBinaryString()
        {
            Console.WriteLine(FindDifferentBinaryString0(["01", "10"]));
            Console.WriteLine(FindDifferentBinaryString0(["00", "01"]));
            Console.WriteLine(FindDifferentBinaryString0(["111", "011", "001"]));
        }

        public static string FindDifferentBinaryString0(string[] a0) => RftFindDifferentBinaryString0(a0);

        public static string FindDifferentBinaryString1(string[] a0) => RftFindDifferentBinaryString1(a0);

        private static string RftFindDifferentBinaryString0(string[] nums)
        {
            int m = nums.Length;
            int n = (int)Math.Pow(2, m);

            for (int i = 0; i < n; i++)
            {
                string s = Convert.ToString(i, 2).PadLeft(m, '0');
                if (!nums.Contains(s)) return s;
            }

            return string.Empty;
        }

        private static string RftFindDifferentBinaryString1(string[] nums)
        {
            int n = nums.Length;
            StringBuilder sb = new();
            for (int i = 0; i < n; i++)
            {
                sb.Append(nums[i][i] == '0' ? '1' : '0');
            }

            return sb.ToString();
        }
    }
}
