using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02343_QueryTheKthSmallestTrimmedNumber
    {
        /// <summary>
        /// You are given a 0-indexed array of strings nums, where each string is of equal length and consists of only digits.
        /// You are also given a 0-indexed 2D integer array queries where queries[i] = [ki, trimi]. For each queries[i], you need to:
        /// Trim each number in nums to its rightmost trimi digits.
        /// Determine the index of the kith smallest trimmed number in nums.If two trimmed numbers are equal, the number with the lower index is considered to be smaller.
        /// Reset each number in nums to its original length.
        /// Return an array answer of the same length as queries, where answer[i] is the answer to the ith query.
        /// Note:
        /// To trim to the rightmost x digits means to keep removing the leftmost digit, until only x digits remain.
        /// Strings in nums may contain leading zeros.
        /// </summary>
        public _02343_QueryTheKthSmallestTrimmedNumber()
        {
            int[] x = SmallestTrimmedNumbers(["102", "473", "251", "814"], [
                [1,1],
                [2,3],
                [4,2],
                [1,2]
            ]);

            int[] x0 = SmallestTrimmedNumbers(["24", "37", "96", "04"], [
                [2,1],
                [2,2]
            ]);

            int[] x1 = SmallestTrimmedNumbers(["325240361872", "440618160237", "785744447413", "820980201297", "470082520306", "874146483840", "425300857082", "088636787077", "813218016629", "459000328006", "188683382600"], [
                [6,7],
                [4,4],
                [1,8],
                [11,10],
                [4,8],
                [11,6],
                [1,1],
                [3,1],
                [11,10]
            ]); // [10,0,9,9,1,6,5,0,9]

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
            RftTerminal.RftReadResult(x1);
        }

        private static int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
        {
            int n = queries.Length;
            int[] x = new int[n];
            List<string> y = [.. nums];

            for (int i = 0; i < n; i++)
            {
                List<string> z = [.. nums.OrderBy(o => o[^queries[i][1]..])];
                string s = z[queries[i][0] - 1];
                int c = queries[i][0];
                int m = -1;

                for (int j = 0; j < y.Count; j++)
                {
                    if (y[j] == s && c > 0)
                    {
                        m = j;
                        c--;
                        if (c == 0) x[i] = j;
                    }
                    if (c > 0 && j == y.Count - 1) x[i] = m;
                }
            }

            return x;
        }
    }
}
