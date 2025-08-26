namespace Rftim3LeetCode.Temp
{
    public class _02709_GreatestCommonDivisorTraversal
    {
        /// <summary>
        /// You are given a 0-indexed integer array nums, and you are allowed to traverse between its indices. 
        /// You can traverse between index i and index j, i != j, if and only if gcd(nums[i], nums[j]) > 1, where gcd is the greatest common divisor.
        /// 
        /// Your task is to determine if for every pair of indices i and j in nums, where i<j, there exists a sequence of traversals that can take us from i to j.
        /// 
        /// Return true if it is possible to traverse between all such pairs of indices, or false otherwise.
        /// </summary>
        public _02709_GreatestCommonDivisorTraversal()
        {
            Console.WriteLine(GreatestCommonDivisorTraversal0([2, 3, 6]));
            Console.WriteLine(GreatestCommonDivisorTraversal0([3, 9, 5]));
            Console.WriteLine(GreatestCommonDivisorTraversal0([4, 3, 12, 8]));
        }

        public static bool GreatestCommonDivisorTraversal0(int[] a0) => RftGreatestCommonDivisorTraversal0(a0);

        public static bool GreatestCommonDivisorTraversal1(int[] a0) => RftGreatestCommonDivisorTraversal1(a0);

        // Creating a graph with dummy nodes and edges
        private static bool RftGreatestCommonDivisorTraversal0(int[] nums)
        {
            int MAX = 100000;
            int N = nums.Length;
            bool[] has = new bool[MAX + 1];
            foreach (int x in nums)
            {
                has[x] = true;
            }

            if (N == 1) return true;
            if (has[1]) return false;

            int[] sieve = new int[MAX + 1];
            for (int d = 2; d <= MAX; d++)
            {
                if (sieve[d] == 0)
                {
                    for (int v = d; v <= MAX; v += d)
                    {
                        sieve[v] = d;
                    }
                }
            }

            DSU union = new(2 * MAX + 1);
            foreach (int x in nums)
            {
                int val = x;
                while (val > 1)
                {
                    int prime = sieve[val];
                    int root = prime + MAX;
                    if (union.Find(root) != union.Find(x)) union.Merge(root, x);

                    while (val % prime == 0)
                    {
                        val /= prime;
                    }
                }
            }

            int cnt = 0;
            for (int i = 2; i <= MAX; i++)
            {
                if (has[i] && union.Find(i) == i) cnt++;
            }

            return cnt == 1;
        }

        private class DSU
        {
            public int[] dsu;
            public int[] size;

            public DSU(int N)
            {
                dsu = new int[N + 1];
                size = new int[N + 1];
                for (int i = 0; i <= N; i++)
                {
                    dsu[i] = i;
                    size[i] = 1;
                }
            }
            public int Find(int x) => dsu[x] == x ? x : (dsu[x] = Find(dsu[x]));

            public void Merge(int x, int y)
            {
                int fx = Find(x);
                int fy = Find(y);

                if (fx == fy) return;
                if (size[fx] > size[fy]) (fy, fx) = (fx, fy);

                dsu[fx] = fy;
                size[fy] += size[fx];
            }
        }

        private static readonly List<int> primes = GetPrimes();
        private static readonly Dictionary<int, int> father = [];
        private static bool RftGreatestCommonDivisorTraversal1(int[] nums)
        {
            father.Clear();
            int unions = 0;
            foreach (int num in nums)
            {
                if (father.ContainsKey(num))
                {
                    unions++;
                    continue;
                }
                int v = num;
                foreach (int p in primes)
                {
                    if (p * p > num) break;

                    if (v % p == 0)
                    {
                        if (father.ContainsKey(p) && Find(num) != Find(p)) unions++;

                        Union(num, p);

                        while (v % p == 0)
                        {
                            v /= p;
                        }
                    }
                }

                if (v > 1)
                {
                    if (father.ContainsKey(v) && Find(num) != Find(v)) unions++;

                    Union(num, v);
                }
            }

            return nums.Length == unions + 1;

            int Find(int x)
            {
                if (!father.ContainsKey(x)) father[x] = x;
                if (father[x] != x) father[x] = Find(father[x]);

                return father[x];
            }

            void Union(int x, int y)
            {
                int xr = Find(x), yr = Find(y);

                if (xr == yr) return;

                if (xr < yr) father[yr] = xr;
                else father[xr] = yr;
            }
        }

        private static List<int> GetPrimes()
        {
            bool[] isNotPrime = new bool[(int)Math.Sqrt(1e5) + 1];
            isNotPrime[0] = isNotPrime[1] = true;
            for (int i = 4; i < isNotPrime.Length; i += 2)
            {
                isNotPrime[i] = true;
            }

            for (int i = 3; i < isNotPrime.Length; i += 2)
            {
                int num = i + i;
                while (num < isNotPrime.Length)
                {
                    isNotPrime[num] = true;
                    num += i;
                }
            }

            List<int> results = [2];
            for (int i = 3; i < isNotPrime.Length; i += 2)
            {
                if (!isNotPrime[i]) results.Add(i);
            }

            return results;
        }
    }
}
