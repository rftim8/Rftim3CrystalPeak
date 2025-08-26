namespace Rftim3LeetCode.Temp
{
    public class _02243_CalculateDigitSumOfAString
    {
        /// <summary>
        /// You are given a string s consisting of digits and an integer k.
        /// A round can be completed if the length of s is greater than k.
        /// In one round, do the following:
        /// Divide s into consecutive groups of size k such that the first k characters are in the first group, the next k characters are in the second group, and so on.
        /// Note that the size of the last group can be smaller than k.
        /// Replace each group of s with a string representing the sum of all its digits.
        /// For example, "346" is replaced with "13" because 3 + 4 + 6 = 13.
        /// Merge consecutive groups together to form a new string. 
        /// If the length of the string is greater than k, repeat from step 1.
        /// Return s after all rounds have been completed.
        /// </summary>
        public _02243_CalculateDigitSumOfAString()
        {
            Console.WriteLine(DigitSum("11111222223", 3));
            Console.WriteLine(DigitSum("00000000", 3));
        }

        private static string DigitSum(string s, int k)
        {
            while (s.Length > k)
            {
                string q = "";
                int n = s.Length;
                int m = n % k;

                for (int i = 0; i < n - m; i += k)
                {
                    string t = s[i..(i + k)];

                    int x = 0;
                    int j = 0;
                    while (j < t.Length)
                    {
                        x += int.Parse(t[j].ToString());
                        j++;
                    }
                    q += x.ToString();
                }
                if (m > 0)
                {
                    string t = s[^m..];

                    int x = 0;
                    int j = 0;
                    while (j < t.Length)
                    {
                        x += int.Parse(t[j].ToString());
                        j++;
                    }
                    q += x.ToString();
                }

                s = q;
            }

            return s;
        }
    }
}
