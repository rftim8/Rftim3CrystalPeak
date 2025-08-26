using Rftim3Convoy.Temp.Construct.Terminal;

namespace Rftim3LeetCode.Temp
{
    public class _02418_SortThePeople
    {
        /// <summary>
        /// You are given an array of strings names, and an array heights that consists of distinct positive integers. 
        /// Both arrays are of length n.
        /// For each index i, names[i] and heights[i] denote the name and height of the ith person.
        /// Return names sorted in descending order by the people's heights.
        /// </summary>
        public _02418_SortThePeople()
        {
            string[] x = SortPeople(["Mary", "John", "Emma"], [180, 165, 170]);
            RftTerminal.RftReadResult(x);
            string[] x0 = SortPeople(["Alice", "Bob", "Bob"], [155, 185, 150]);
            RftTerminal.RftReadResult(x0);
        }

        private static string[] SortPeople(string[] names, int[] heights)
        {
            int m = heights.Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    if (heights[i] < heights[j])
                    {
                        (heights[i], heights[j]) = (heights[j], heights[i]);
                        (names[i], names[j]) = (names[j], names[i]);
                    }
                }
            }

            return names;
        }
    }
}
