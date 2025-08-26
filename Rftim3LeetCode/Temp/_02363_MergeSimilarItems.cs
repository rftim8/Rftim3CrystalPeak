using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02363_MergeSimilarItems
    {
        /// <summary>
        /// You are given two 2D integer arrays, items1 and items2, representing two sets of items. 
        /// Each array items has the following properties:
        /// items[i] = [valuei, weighti] where valuei represents the value and weighti represents the weight of the ith item.
        /// The value of each item in items is unique.
        /// Return a 2D integer array ret where ret[i] = [valuei, weighti], with weighti being the sum of weights of all items with value valuei.
        /// Note: ret should be returned in ascending order by value.
        /// </summary>
        public _02363_MergeSimilarItems()
        {
            IList<IList<int>> x = MergeSimilarItems(
                [
                    [1, 1],
                    [4, 5],
                    [3, 8]
                ],
                [
                    [3, 1],
                    [1, 5]
                ]
            );
            RftTerminal.RftReadResult(x);
            IList<IList<int>> x0 = MergeSimilarItems(
                [
                    [1, 1],
                    [3, 2],
                    [2, 3]
                ],
                [
                    [2, 1],
                    [3, 2],
                    [1, 3]
                ]
            );
            RftTerminal.RftReadResult(x0);
            IList<IList<int>> x1 = MergeSimilarItems(
                [
                    [1, 3],
                    [2, 2]
                ],
                [
                    [7, 1],
                    [2, 2],
                    [1, 4]
                ]
            );
            RftTerminal.RftReadResult(x1);
        }

        private static List<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
        {
            IList<IList<int>> result = [.. items1.ToList()];

            foreach (int[]? item in items2.ToList())
            {
                IList<int>? common = result.FirstOrDefault(r => r[0] == item[0]);

                if (common is not null) common[1] += item[1];
                else result.Add(item);
            }

            return [.. result.OrderBy(p => p[0])];
        }

        private static IList<IList<int>> MergeSimilarItems0(int[][] items1, int[][] items2)
        {
            Dictionary<int, int> dict = [];

            foreach (int[] item in items1)
            {
                dict[item[0]] = item[1];
            }

            foreach (int[] item in items2)
            {
                dict[item[0]] = item[1] + dict.GetValueOrDefault(item[0]);
            }

            return dict.Select(kvp => new int[] { kvp.Key, kvp.Value }).OrderBy(i => i[0]).ToArray();
        }
    }
}
