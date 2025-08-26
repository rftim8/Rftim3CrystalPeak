namespace Rftim3LeetCode.Temp
{
    public class _01323_Maximum69Number
    {
        /// <summary>
        /// You are given a positive integer num consisting only of digits 6 and 9.
        /// Return the maximum number you can get by changing at most one digit(6 becomes 9, and 9 becomes 6).
        /// </summary>
        public _01323_Maximum69Number()
        {
            Console.WriteLine(Maximum69Number(9669));
            Console.WriteLine(Maximum69Number(9996));
            Console.WriteLine(Maximum69Number(9999));
        }

        private static int Maximum69Number(int num)
        {
            char[] r = num.ToString().ToCharArray();

            for (int i = 0; i < r.Length; i++)
            {
                if (r[i] == '6')
                {
                    r[i] = '9';
                    break;
                }
            }

            return int.Parse(string.Concat(r));
        }
    }
}
