namespace Rftim3LeetCode.Temp
{
    public class _02160_MinimumSumOfFourDigitNumberAfterSplittingDigits
    {
        /// <summary>
        /// You are given a positive integer num consisting of exactly four digits. 
        /// Split num into two new integers new1 and new2 by using the digits found in num. 
        /// Leading zeros are allowed in new1 and new2, and all the digits found in num must be used.
        /// For example, given num = 2932, you have the following digits: two 2's, one 9 and one 3. 
        /// Some of the possible pairs [new1, new2] are [22, 93], [23, 92], [223, 9] and [2, 329].
        /// Return the minimum possible sum of new1 and new2.
        /// </summary>
        public _02160_MinimumSumOfFourDigitNumberAfterSplittingDigits()
        {
            Console.WriteLine(MinimumSum(2932));
            Console.WriteLine(MinimumSum(4009));
        }

        private static int MinimumSum(int num)
        {
            char[] r = num.ToString().ToCharArray();
            Array.Sort(r);

            string x0 = "", x1 = "";

            for (int i = 0; i < r.Length; i++)
            {
                if (i % 2 == 0) x0 += r[i];
                else x1 += r[i];
            }

            return int.Parse(x0) + int.Parse(x1);
        }
    }
}
