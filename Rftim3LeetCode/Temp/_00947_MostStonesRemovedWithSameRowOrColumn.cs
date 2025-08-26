namespace Rftim3LeetCode.Temp
{
    public class _00947_MostStonesRemovedWithSameRowOrColumn
    {
        /// <summary>
        /// On a 2D plane, we place n stones at some integer coordinate points. Each coordinate point may have at most one stone.
        /// A stone can be removed if it shares either the same row or the same column as another stone that has not been removed.
        /// Given an array stones of length n where stones[i] = [xi, yi] represents the location of the ith stone, 
        /// return the largest possible number of stones that can be removed.
        /// </summary>
        public _00947_MostStonesRemovedWithSameRowOrColumn()
        {
            Console.WriteLine(MostStonesRemovedWithSameRowOrColumn0(
            [
                [0, 0],
                [0, 1],
                [1, 0],
                [1, 2],
                [2, 1],
                [2, 2]
            ]));
            Console.WriteLine(MostStonesRemovedWithSameRowOrColumn0(
            [
                [0, 0],
                [0, 2],
                [1, 1],
                [2, 0],
                [2, 2]
            ]));
            Console.WriteLine(MostStonesRemovedWithSameRowOrColumn0(
            [
                [0, 0]
            ]));
        }

        public static int MostStonesRemovedWithSameRowOrColumn0(int[][] a0) => RftMostStonesRemovedWithSameRowOrColumn0(a0);

        public static int MostStonesRemovedWithSameRowOrColumn1(int[][] a0) => RftMostStonesRemovedWithSameRowOrColumn1(a0);

        public static int MostStonesRemovedWithSameRowOrColumn2(int[][] a0) => RftMostStonesRemovedWithSameRowOrColumn2(a0);

        private static int RftMostStonesRemovedWithSameRowOrColumn0(int[][] stones)
        {
            HashSet<(int, int)> visited = [];
            int island = 0;

            foreach (int[] s in stones)
            {
                if (visited.Contains((s[0], s[1]))) continue;
                Queue<(int, int)> q = new();

                q.Enqueue((s[0], s[1]));
                visited.Add((s[0], s[1]));

                while (q.Count != 0)
                {
                    (int, int) crt = q.Dequeue();

                    foreach (int[] stone in stones)
                    {
                        if (!visited.Contains((stone[0], stone[1])) && (stone[0] == crt.Item1 || stone[1] == crt.Item2))
                        {
                            visited.Add((stone[0], stone[1]));
                            q.Enqueue((stone[0], stone[1]));
                        }
                    }
                }
                ++island;
            }

            return stones.Length - island;
        }

        private const int MAX = 10000;

        private class Unions
        {
            private readonly int[] root;
            private readonly int[] rank;

            public Unions(int n)
            {
                root = new int[n];
                rank = new int[n];
                for (int i = 0; i < n; i++)
                {
                    root[i] = i;
                }
            }

            public int Find(int x)
            {
                if (x != root[x]) x = Find(root[x]);

                return root[x];
            }

            public bool Union(int x, int y)
            {
                int px = Find(x);
                int py = Find(y);
                if (px == py) return false;

                if (rank[px] > rank[py])
                {
                    root[py] = px;
                    rank[px]++;
                }
                else
                {
                    root[px] = py;
                    rank[py]++;
                }

                return true;
            }
        }

        private static int RftMostStonesRemovedWithSameRowOrColumn1(int[][] stones)
        {
            Unions sets = new(MAX * 2);
            foreach (int[] stone in stones)
            {
                sets.Union(stone[0], stone[1] + MAX);
            }

            HashSet<int> roots = [];
            foreach (int[] stone in stones)
            {
                roots.Add(sets.Find(stone[0]));
                roots.Add(sets.Find(stone[1] + MAX));
            }

            return stones.Length - roots.Count;
        }

        private static int RftMostStonesRemovedWithSameRowOrColumn2(int[][] stones)
        {
            int components = 0;
            HashSet<int[]> visited = [];

            foreach (int[] stone in stones)
            {
                if (!visited.Contains(stone))
                {
                    Dfs(stone, stones, visited);
                    components++;
                }
            }

            return stones.Length - components;
        }

        private static void Dfs(int[] stone, int[][] stones, HashSet<int[]> visited)
        {
            visited.Add(stone);

            foreach (int[] next in stones)
            {
                if (!visited.Contains(next))
                {
                    if (stone[0] == next[0] || stone[1] == next[1]) Dfs(next, stones, visited);
                }
            }
        }
    }
}