namespace Rftim3LeetCode.Temp
{
    public class _00997_FindTheTownJudge
    {
        /// <summary>
        /// In a town, there are n people labeled from 1 to n. There is a rumor that one of these people is secretly the town judge.
        /// If the town judge exists, then:
        /// The town judge trusts nobody.
        /// Everybody(except for the town judge) trusts the town judge.
        /// There is exactly one person that satisfies properties 1 and 2.
        /// You are given an array trust where trust[i] = [ai, bi] representing that the person labeled ai trusts the person labeled bi.
        /// If a trust relationship does not exist in trust array, then such a trust relationship does not exist.
        /// Return the label of the town judge if the town judge exists and can be identified, or return -1 otherwise.
        /// </summary>
        public _00997_FindTheTownJudge()
        {
            Console.WriteLine(FindJudge(2,
            [
                [1,2]
            ]));
            Console.WriteLine(FindJudge(3,
            [
                [1,3],
                [2,3]
            ]));
            Console.WriteLine(FindJudge(3,
            [
                [1,3],
                [2,3],
                [3,1]
            ]));
            Console.WriteLine(FindJudge(3,
            [
                [1,2],
                [2,3]
            ]));
        }

        private static int FindJudge(int n, int[][] trust)
        {
            int m = trust.Length;
            if (n == 0) return -1;
            if (n == 1) return n;
            int c = -1;

            Dictionary<int, List<int>> x = [];
            for (int i = 1; i <= n; i++)
            {
                x.Add(i, []);
            }

            for (int i = 0; i < m; i++)
            {
                x[trust[i][1]].Add(trust[i][0]);
            }

            foreach (KeyValuePair<int, List<int>> item in x)
            {
                if (item.Value.Count == n - 1) c = item.Key;
            }

            foreach (KeyValuePair<int, List<int>> item in x)
            {
                if (item.Key != c)
                {
                    if (item.Value.Contains(c)) return -1;
                }
            }

            return c;
        }

        private static int FindJudge0(int n, int[][] trust)
        {
            int[] inn = new int[n + 1];

            foreach (int[] i in trust)
            {
                inn[i[0]]--;
                inn[i[1]]++;
            }

            for (int i = 1; i <= n; i++)
            {
                if (inn[i] == n - 1) return i;
            }

            return -1;
        }
    }
}
