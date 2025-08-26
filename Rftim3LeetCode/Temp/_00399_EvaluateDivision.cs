using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _00399_EvaluateDivision
    {
        /// <summary>
        /// You are given an array of variable pairs equations and an array of real numbers values, where equations[i] = [Ai, Bi] and values[i] 
        /// represent the equation Ai / Bi = values[i]. 
        /// Each Ai or Bi is a string that represents a single variable.
        /// You are also given some queries, where queries[j] = [Cj, Dj] represents the jth query where you must find the answer for Cj / Dj = ?.
        /// Return the answers to all queries.If a single answer cannot be determined, return -1.0.
        /// Note: The input is always valid. You may assume that evaluating the queries will not result in division by zero and that there is no contradiction.
        /// </summary>
        public _00399_EvaluateDivision()
        {
            double[] x = CalcEquation(
                [
                    new List<string>() { "a", "b" },
                    new List<string>() { "b", "c" }
                ],
                [2.0, 3.0],
                new List<IList<string>>()
                {
                    new List<string>() { "a", "c" },
                    new List<string>() { "b", "a" },
                    new List<string>() { "a", "e" },
                    new List<string>() { "a", "a" },
                    new List<string>() { "x", "x" }
                }
                );

            double[] x0 = CalcEquation(
                [
                    new List<string>() { "a", "b" },
                    new List<string>() { "b", "c" },
                    new List<string>() { "bc", "cd" }
                ],
                [1.5, 2.5, 5],
                [
                    new List<string>() { "a", "c" },
                    new List<string>() { "c", "b" },
                    new List<string>() { "bc", "cd" },
                    new List<string>() { "cd", "bc" }
                ]
                );

            RftTerminal.RftReadResult(x);
            RftTerminal.RftReadResult(x0);
        }

        private static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, Dictionary<string, double>> x = [];
            foreach (string? a in equations.SelectMany(eq => eq).Distinct())
            {
                Set(x, a, a, 1);
            }

            foreach ((IList<string> eq, double val) in equations.Zip(values, (eq, val) => (eq, val)))
            {
                Set(x, eq[0], eq[1], val);
                Set(x, eq[1], eq[0], 1 / val);
            }

            foreach (string k in x.Keys)
            {
                foreach ((string a, string b) in x.Keys.SelectMany(k => x.Keys, (a, b) => (a, b)))
                {
                    if (x.ContainsKey(a) && x[a].ContainsKey(k) && x[k].ContainsKey(b)) Set(x, a, b, x[a][k] * x[k][b]);
                }
            }

            return queries.Select(q => Get(x, q[0], q[1])).ToArray();
        }

        private static void Set(Dictionary<string, Dictionary<string, double>> x, string a, string b, double v)
        {
            if (!x.ContainsKey(a)) x[a] = [];

            x[a][b] = v;
        }

        private static double Get(Dictionary<string, Dictionary<string, double>> dict, string a, string b)
        {
            return dict.TryGetValue(a, out Dictionary<string, double>? dict1)
                ? dict1.TryGetValue(b, out double v) ? v : -1
                : -1;
        }

        private static double[] CalcEquation0(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            DSU dsu = new();
            double[] res = new double[queries.Count];
            for (var i = 0; i < values.Length; i++)
            {
                string x = equations[i][0];
                string y = equations[i][1];
                double z = values[i];
                dsu.Union(x, y, z);
            }

            for (var i = 0; i < queries.Count; i++)
            {
                string x = queries[i][0];
                string y = queries[i][1];
                res[i] = dsu.parents.ContainsKey(x) && dsu.parents.ContainsKey(y) && dsu.Find(x) == dsu.Find(y)
                    ? dsu.vals[x] / dsu.vals[y]
                    : -1.0;
            }
            return res;
        }

        private class DSU
        {
            public Dictionary<string, string> parents = [];
            public Dictionary<string, double> vals = [];

            public string Find(string x)
            {
                string p = parents[x]; // default?
                if (p != x)
                {
                    string pp = Find(p);
                    vals[x] *= vals[p];
                    parents[x] = pp;
                }

                return parents[x];
            }

            public void Union(string x, string y, double z)
            {
                if (!parents.ContainsKey(x))
                {
                    parents[x] = x;
                    vals[x] = 1.0;
                }

                if (!parents.ContainsKey(y))
                {
                    parents[y] = y;
                    vals[y] = 1.0;
                }

                string px = Find(x);
                string py = Find(y);
                parents[px] = py;
                vals[px] = z * vals[y] / vals[x];
            }
        }
    }
}
