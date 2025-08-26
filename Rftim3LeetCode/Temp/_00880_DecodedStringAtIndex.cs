namespace Rftim3LeetCode.Temp
{
    public class _00880_DecodedStringAtIndex
    {
        /// <summary>
        /// You are given an encoded string s. 
        /// To decode the string to a tape, the encoded string is read one character at a time and the following steps are taken:
        /// If the character read is a letter, that letter is written onto the tape.
        /// If the character read is a digit d, the entire current tape is repeatedly written d - 1 more times in total.
        /// Given an integer k, return the kth letter (1-indexed) in the decoded string.
        /// </summary>
        public _00880_DecodedStringAtIndex()
        {
            Console.WriteLine(DecodedStringAtIndex0("leet2code3", 10));
            Console.WriteLine(DecodedStringAtIndex0("ha22", 5));
            Console.WriteLine(DecodedStringAtIndex0("a2345678999999999999999", 1));
            Console.WriteLine(DecodedStringAtIndex0("y959q969u3hb22odq595", 222280369));
        }

        public static string DecodedStringAtIndex0(string a0, int a1) => RftDecodedStringAtIndex0(a0, a1);

        public static string DecodedStringAtIndex1(string a0, int a1) => RftDecodedStringAtIndex1(a0, a1);

        private static string RftDecodedStringAtIndex0(string s, int k)
        {
            long n = 0;
            int i;
            for (i = 0; n < k; i++)
            {
                n = char.IsDigit(s[i]) ? n * (s[i] - '0') : n + 1;
            }

            Console.WriteLine(n);

            i--;
            while (true)
            {
                if (char.IsDigit(s[i]))
                {
                    n /= s[i] - '0';
                    k %= (int)n;
                }
                else if (k % n == 0) return s[i].ToString();
                else n--;

                i--;
            }
        }

        private static string RftDecodedStringAtIndex1(string s, int k)
        {
            long size = 0;
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                char c = s[i];
                if (char.IsDigit(c)) size *= c - '0';
                else size++;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                char c = s[i];
                k = (int)(k % size);

                if (k == 0 && char.IsLetter(c)) return char.ToString(c);
                if (char.IsDigit(c)) size /= c - '0';
                else size--;
            }

            return "";
        }
    }
}