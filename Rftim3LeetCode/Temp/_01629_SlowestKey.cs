namespace Rftim3LeetCode.Temp
{
    public class _01629_SlowestKey
    {
        /// <summary>
        /// A newly designed keypad was tested, where a tester pressed a sequence of n keys, one at a time.
        /// You are given a string keysPressed of length n, where keysPressed[i] was the ith key pressed in the testing sequence, 
        /// and a sorted list releaseTimes, where releaseTimes[i] was the time the ith key was released.Both arrays are 0-indexed.
        /// The 0th key was pressed at the time 0, and every subsequent key was pressed at the exact time the previous key was released.
        /// The tester wants to know the key of the keypress that had the longest duration.
        /// The ith keypress had a duration of releaseTimes[i] - releaseTimes[i - 1], 
        /// and the 0th keypress had a duration of releaseTimes[0].
        /// Note that the same key could have been pressed multiple times during the test, and these multiple presses of the same key may not have had the same duration.
        /// Return the key of the keypress that had the longest duration.If there are multiple such keypresses, return the lexicographically largest key of the keypresses.
        /// </summary>
        public _01629_SlowestKey()
        {
            Console.WriteLine(SlowestKey([9, 29, 49, 50], "cbcd"));
            Console.WriteLine(SlowestKey([12, 23, 36, 46, 62], "spuda"));
        }
        private static char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            int n = releaseTimes.Length;

            Dictionary<char, int> r = [];

            for (int i = 0; i < n; i++)
            {
                if (i == 0) r.Add(keysPressed[i], releaseTimes[i]);
                else
                {
                    if (r.ContainsKey(keysPressed[i])) r[keysPressed[i]] = Math.Max(r[keysPressed[i]], releaseTimes[i] - releaseTimes[i - 1]);
                    else r[keysPressed[i]] = releaseTimes[i] - releaseTimes[i - 1];
                }
            }

            List<KeyValuePair<char, int>> x = [.. r.OrderByDescending(o => o.Value).ThenByDescending(o => o.Key)];

            return x[0].Key;
        }
    }
}
