namespace Rftim3LeetCode.Temp
{
    public class CalculateMaximumInformationGain
    {
        /// <summary>
        /// Given a group of values, the entropy of the group is defined as the formula as following:
        /// Sum(from i = 1 to n) of P(xi) * log(base 2) of P(xi) * P(xi)
        /// where P(x) is the probability of appearance for the value x.
        /// e.g.
        /// the input group:  [1, 1, 2, 2]
        /// the probability of value 1 is:  2/4 = 1/2
        /// the probability of value 2 is:  2/4 = 1/2
        /// Therefore, its entropy can be obtained by:  - (1/2) * log2(1/2) - (1/2) * log2(1/2) = 1/2 + 1/2 = 1
        /// This exercise, however, is aimed to calculate the maximum information gain that one can obtain by splitting a group into two subgroups.
        /// The information gain is the difference of entropy before and after the splitting.
        /// For a group of L, we divide it into subgroups of { L1, L2}, then the information gain is calculated as following:
        /// The overall entropy of the splitted subgroups {L1, L2
        ///     } is the sum of entropy for each subgroup weighted by its proportion with regards to the original group.
        ///     Problem Description
        ///     In this exercise, one can expect a list of samples on Iris flowers. 
        ///     Each sample is represented with a tuple of two values: <petal_length, species>, where the first attribute is the measurement on the length of the petal for the sample, 
        ///     and the second attribute indicates the species of sample.
        ///     Here is an example.
        /// The task is to split the sample list into two sublists, while complying with the following two conditions:
        /// The petal_length of sample in one sublist is less or equal than that of any sample in the other sublist.
        ///     The information gain on the species attribute of the sublists is maximal among all possible splits.
        ///     As output, one should just return the information gain.
        ///     In addition, one can expect that each value of petal_length is unique.
        /// In the above example, the optimal split would be L1 = [(0.5, 'setosa'), (1.0, 'setosa')] and L2 = [(1.5, 'versicolor'), (2.3, 'versicolor')].
        /// According the above formulas, the maximum information gain for this example would be 1.0.
        /// </summary>
        public CalculateMaximumInformationGain()
        {
            Console.WriteLine(CalculateMaxInfoGain0(
                [0.5, 2.3, 1.0, 1.5],
                ["setosa", "versicolor", "setosa", "versicolor"]
                ));

            Console.WriteLine(CalculateMaxInfoGain0(
                [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
                ["versicolor", "versicolor", "setosa", "virginica", "virginica", "versicolor", "versicolor", "setosa", "versicolor", "versicolor"]
                ));
        }

        public static double CalculateMaxInfoGain0(double[] a0, string[] a1) => RftCalculateMaxInfoGain0(a0, a1);
        private static double RftCalculateMaxInfoGain0(double[] petal_length, string[] species)
        {
            int n = petal_length.Length;
            int distinct = species.Distinct().Count();
            if (n == 0 || species.Length == 0 || distinct == 1) return 0;

            List<(double, string)> y = [];

            for (int i = 0; i < n; i++)
            {
                y.Add((petal_length[i], species[i]));
            }

            double y0 = EntropyCall(y, n);
            if (distinct == 2 && y0 == 1) return y0;
            double r = 0;

            for (int i = 0; i < n; i++)
            {
                List<(double, string)> s1 = [];
                List<(double, string)> s2 = [];

                for (int j = 0; j < i; j++)
                {
                    s1.Add(y[j]);
                    Console.WriteLine($"s1: {y[j]}");
                }

                for (int j = i; j < n; j++)
                {
                    Console.WriteLine($"s2: {y[j]}");
                    s2.Add(y[j]);
                }
                double y1 = EntropyCall(s1, s1.Count);
                double y2 = EntropyCall(s2, s2.Count);
                r = Math.Max(r, y0 - y1 * ((double)s1.Count / n) - y2 * ((double)s2.Count / n));

                Console.WriteLine($"y0: {y0}");
                Console.WriteLine($"s1 entropy: {y1}");
                Console.WriteLine($"s2 entropy: {y2}");
                Console.WriteLine($"possible: {r}");
                Console.WriteLine();
            }

            foreach ((double, string) item in y)
            {
                Console.WriteLine($"{item.Item1}: {item.Item2}");
            }

            return r;
        }

        private static double EntropyCall(List<(double, string)> y, int n)
        {
            if (y.Count == 0) return 0;
            y = [.. y.OrderBy(o => o.Item2)];
            double x = 0;
            string c = y[0].Item2;
            int t = 1;

            for (int i = 1; i < n; i++)
            {
                if (y[i].Item2 == c) t++;
                else
                {
                    x -= (double)t / n * Math.Log2((double)t / n);
                    c = y[i].Item2;
                    t = 1;
                }
                if (i == n - 1) x -= (double)t / n * Math.Log2((double)t / n);
            }

            return x;
        }
    }
}
