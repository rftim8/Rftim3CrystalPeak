namespace Rftim3LeetCode.Temp
{
    public class _02515_ShortestDistanceToTargetStringInACircularArray
    {
        /// <summary>
        /// You are given a 0-indexed circular string array words and a string target. 
        /// A circular array means that the array's end connects to the array's beginning.
        /// Formally, the next element of words[i] is words[(i + 1) % n] and the previous element of words[i] is words[(i - 1 + n) % n], where n is the length of words.
        /// Starting from startIndex, you can move to either the next word or the previous word with 1 step at a time.
        /// Return the shortest distance needed to reach the string target. 
        /// If the string target does not exist in words, return -1.
        /// </summary>
        public _02515_ShortestDistanceToTargetStringInACircularArray()
        {
            Console.WriteLine(ClosetTarget(["hello", "i", "am", "leetcode", "hello"], "hello", 1));
            Console.WriteLine(ClosetTarget(["a", "b", "leetcode"], "leetcode", 0));
            Console.WriteLine(ClosetTarget(["i", "eat", "leetcode"], "ate", 0));
        }

        private static int ClosetTarget(string[] words, string target, int startIndex)
        {
            int n = words.Length;
            HashSet<int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (words[i] == target)
                {
                    if (Math.Abs(startIndex - i) <= n / 2) r.Add(Math.Abs(startIndex - i));
                    else r.Add(n - Math.Abs(startIndex - i));
                }
            }

            return r.Count == 0 ? -1 : r.Min();
        }
    }
}
