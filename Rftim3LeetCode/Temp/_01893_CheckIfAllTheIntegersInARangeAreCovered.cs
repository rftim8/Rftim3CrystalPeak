namespace Rftim3LeetCode.Temp
{
    public class _01893_CheckIfAllTheIntegersInARangeAreCovered
    {
        /// <summary>
        /// You are given a 2D integer array ranges and two integers left and right. 
        /// Each ranges[i] = [starti, endi] represents an inclusive interval between starti and endi.
        /// Return true if each integer in the inclusive range[left, right] is covered by at least one interval in ranges.
        /// Return false otherwise.
        /// An integer x is covered by an interval ranges[i] = [starti, endi] if starti <= x <= endi.
        /// </summary>
        public _01893_CheckIfAllTheIntegersInARangeAreCovered()
        {
            Console.WriteLine(CheckIfAllTheIntegersInARangeAreCovered0(
                [
                    [1, 2],
                    [3, 4],
                    [5, 6]
                ],
                2,
                5
            ));

            Console.WriteLine(CheckIfAllTheIntegersInARangeAreCovered0(
                [
                    [1, 10],
                    [10, 20]
                ],
                21,
                21
            ));
        }

        public static bool CheckIfAllTheIntegersInARangeAreCovered0(int[][] a0, int a1, int a2) => RftCheckIfAllTheIntegersInARangeAreCovered0(a0, a1, a2);

        public static bool CheckIfAllTheIntegersInARangeAreCovered1(int[][] a0, int a1, int a2) => RftCheckIfAllTheIntegersInARangeAreCovered1(a0, a1, a2);

        private static bool RftCheckIfAllTheIntegersInARangeAreCovered0(int[][] ranges, int left, int right)
        {
            int n = ranges.Length;

            HashSet<int> r = [];

            for (int i = left; i <= right; i++)
            {
                r.Add(i);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = ranges[i][0]; j <= ranges[i][1]; j++)
                {
                    r.Remove(j);
                }
            }

            return r.Count == 0;
        }

        private static bool RftCheckIfAllTheIntegersInARangeAreCovered1(int[][] ranges, int left, int right)
        {
            for (int i = left; i <= right; i++)
            {
                bool satisfy = ranges.Any(t => i >= t[0] && i <= t[1]);

                if (!satisfy) return false;
            }

            return true;
        }
    }
}