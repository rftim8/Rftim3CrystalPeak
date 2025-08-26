namespace Rftim3LeetCode.Temp
{
    public class _02511_MaximumEnemyFortsThatCanBeCaptured
    {
        /// <summary>
        /// You are given a 0-indexed integer array forts of length n representing the positions of several forts. 
        /// forts[i] can be -1, 0, or 1 where:
        /// -1 represents there is no fort at the ith position.
        /// 0 indicates there is an enemy fort at the ith position.
        /// 1 indicates the fort at the ith the position is under your command.
        /// Now you have decided to move your army from one of your forts at position i to an empty position j such that:
        /// 0 <= i, j <= n - 1
        /// The army travels over enemy forts only.Formally, for all k where min(i, j) < k<max(i, j), forts[k] == 0.
        /// While moving the army, all the enemy forts that come in the way are captured.
        /// Return the maximum number of enemy forts that can be captured.
        /// In case it is impossible to move your army, or you do not have any fort under your command, return 0.
        /// </summary>
        public _02511_MaximumEnemyFortsThatCanBeCaptured()
        {
            Console.WriteLine(CaptureForts([1, 0, 0, -1, 0, 0, 0, 0, 1]));
            Console.WriteLine(CaptureForts([0, 0, 1, -1]));
        }

        private static int CaptureForts(int[] forts)
        {
            int n = forts.Length;
            HashSet<int> r = [0];

            for (int i = 0; i < n; i++)
            {
                if (forts[i] == 1)
                {
                    int c = 0;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (forts[j] == 0) c++;
                        if (forts[j] == 1) break;
                        if (forts[j] == -1)
                        {
                            r.Add(c);
                            break;
                        }
                    }
                }
            }

            for (int i = n - 1; i > -1; i--)
            {
                if (forts[i] == 1)
                {
                    int c = 0;
                    for (int j = i - 1; j > -1; j--)
                    {
                        if (forts[j] == 0) c++;
                        if (forts[j] == 1) break;
                        if (forts[j] == -1)
                        {
                            r.Add(c);
                            break;
                        }
                    }
                }
            }

            return r.Max();
        }

        private static int CaptureForts0(int[] forts)
        {
            int cnt = 0;
            int enemyCnt = 0;
            int prevDelimiter = 2;

            foreach (int fort in forts)
            {
                switch (fort)
                {
                    case -1:
                        if (prevDelimiter == 1 && enemyCnt > cnt) cnt = enemyCnt;
                        enemyCnt = 0;
                        prevDelimiter = -1;
                        break;
                    case 0:
                        enemyCnt++;
                        break;
                    case 1:
                        if (prevDelimiter == -1 && enemyCnt > cnt) cnt = enemyCnt;
                        enemyCnt = 0;
                        prevDelimiter = 1;
                        break;
                }
            }

            return cnt;
        }
    }
}
