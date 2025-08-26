namespace Rftim3LeetCode.Temp
{
    public class _00551_StudentAttendanceRecord1
    {
        /// <summary>
        /// You are given a string s representing an attendance record for a student where each character signifies whether the student was absent, late, or present on that day. 
        /// The record only contains the following three characters:
        /// 'A': Absent.
        /// 'L': Late.
        /// 'P': Present.
        /// The student is eligible for an attendance award if they meet both of the following criteria:
        /// The student was absent('A') for strictly fewer than 2 days total.
        /// The student was never late ('L') for 3 or more consecutive days.
        /// Return true if the student is eligible for an attendance award, or false otherwise.
        /// </summary>
        public _00551_StudentAttendanceRecord1()
        {
            Console.WriteLine(CheckRecord0("PPALLP"));
            Console.WriteLine(CheckRecord0("PPALLL"));
        }

        public static bool CheckRecord0(string a0) => RftCheckRecord0(a0);

        public static bool CheckRecord1(string a0) => RftCheckRecord1(a0);

        private static bool RftCheckRecord0(string s)
        {
            int n = s.Length;
            int a = 0, l = 0;

            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'A')
                {
                    a++;
                    if (a > 1) return false;
                }

                if (s[i] == 'L')
                {
                    l++;
                    if (l > 2) return false;
                }
                else l = 0;
            }

            return true;
        }

        private static bool RftCheckRecord1(string s)
        {
            int a = 0;
            int l = 0;

            foreach (char c in s)
            {
                if (c == 'A')
                {
                    a++;
                    l = 0;
                }
                else if (c == 'L')
                {
                    l++;
                    if (l >= 3) return false;
                }
                else l = 0;

                if (a >= 2) return false;
            }

            return true;
        }
    }
}
