namespace Rftim3LeetCode.Temp
{
    public class _00621_TaskScheduler
    {
        /// <summary>
        /// Given a characters array tasks, representing the tasks a CPU needs to do, where each letter represents a different task. 
        /// Tasks could be done in any order. Each task is done in one unit of time. For each unit of time, the CPU could complete either one task or just be idle.
        /// However, there is a non-negative integer n that represents the cooldown period between two same tasks(the same letter in the array), 
        /// that is that there must be at least n units of time between any two same tasks.
        /// Return the least number of units of times that the CPU will take to finish all the given tasks.
        /// </summary>
        public _00621_TaskScheduler()
        {
            Console.WriteLine(LeastInterval(['A', 'A', 'A', 'B', 'B', 'B'], 2));
            Console.WriteLine(LeastInterval(['A', 'A', 'A', 'B', 'B', 'B'], 0));
            Console.WriteLine(LeastInterval(['A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G'], 2));
        }

        private static int LeastInterval(char[] tasks, int n)
        {
            int max = 0, c = 0;
            int[] chars = new int[26];

            foreach (char item in tasks)
            {
                chars[item - 'A']++;

                if (chars[item - 'A'] > max)
                {
                    max = chars[item - 'A'];
                    c = 1;
                }
                else if (chars[item - 'A'] == max) c++;
            }

            int interval = (max - 1) * (n + 1) + c;

            return interval < tasks.Length ? tasks.Length : interval;
        }
    }
}
