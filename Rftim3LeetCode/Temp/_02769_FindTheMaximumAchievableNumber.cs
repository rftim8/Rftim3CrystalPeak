namespace Rftim3LeetCode.Temp
{
    public class _02769_FindTheMaximumAchievableNumber
    {
        /// <summary>
        /// You are given two integers, num and t.
        /// An integer x is called achievable if it can become equal to num after applying the following operation no more than t times:
        /// Increase or decrease x by 1, and simultaneously increase or decrease num by 1.
        /// Return the maximum possible achievable number.
        /// It can be proven that there exists at least one achievable number.
        /// </summary>
        public _02769_FindTheMaximumAchievableNumber()
        {
            Console.WriteLine(TheMaximumAchievableX(4, 1));
            Console.WriteLine(TheMaximumAchievableX(3, 2));
        }

        private static int TheMaximumAchievableX(int num, int t)
        {
            return num + t * 2;
        }
    }
}
