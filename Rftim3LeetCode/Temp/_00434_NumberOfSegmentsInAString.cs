namespace Rftim3LeetCode.Temp
{
    public class _00434_NumberOfSegmentsInAString
    {
        /// <summary>
        /// Given a string s, return the number of segments in the string.
        /// A segment is defined to be a contiguous sequence of non-space characters.
        /// </summary>
        public _00434_NumberOfSegmentsInAString()
        {
            Console.WriteLine(CountSegments0("Hello, my name is John"));
            Console.WriteLine(CountSegments0("Hello"));
        }

        public static int CountSegments0(string a0) => RftCountSegments0(a0);

        public static int CountSegments1(string a0) => RftCountSegments1(a0);

        private static int RftCountSegments0(string s)
        {
            s = s.Trim();
            if (s == "") return 0;

            int n = s.Length;
            int c = 1;
            bool d = false;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == ' ')
                {
                    if (!d)
                    {
                        c++;
                        d = true;
                    }
                }
                else d = false;
            }

            return c;
        }

        private static int RftCountSegments1(string s)
        {
            s = s.Trim();
            if (s == "") return 0;
            int count = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ' ' && s[i - 1] != ' ') count++;
            }

            return count;
        }
    }
}
