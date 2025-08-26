namespace Rftim3LeetCode.Temp
{
    public class _01784_CheckIfBinaryStringHasAtMostOneSegmentOfOnes
    {
        /// <summary>
        /// Given a binary string s ​​​​​without leading zeros, return true​​​ if s contains at most one contiguous segment of ones. 
        /// Otherwise, return false.
        /// </summary>
        public _01784_CheckIfBinaryStringHasAtMostOneSegmentOfOnes()
        {
            Console.WriteLine(CheckOnesSegment("1001"));
            Console.WriteLine(CheckOnesSegment("110"));
        }

        private static bool CheckOnesSegment(string s)
        {
            int n = s.Length;

            List<string> r = [];
            string t = "";
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    t += '1';
                    if (i == n - 1) r.Add(t);
                }
                else
                {
                    if (t != "") r.Add(t);
                    t = "";
                }
            }

            return r.Count == 1;
        }

        private static bool CheckOnesSegment0(string s)
        {
            bool wasZeroBefore = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0') wasZeroBefore = true;
                else if (wasZeroBefore) return false;
            }

            return true;
        }
    }
}
