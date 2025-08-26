namespace Rftim3LeetCode.Temp
{
    public class _02432_TheEmployeeThatWorkedOnTheLongestTask
    {
        /// <summary>
        /// There are n employees, each with a unique id from 0 to n - 1.
        /// You are given a 2D integer array logs where logs[i] = [idi, leaveTimei] where:
        /// idi is the id of the employee that worked on the ith task, and
        /// leaveTimei is the time at which the employee finished the ith task.
        /// All the values leaveTimei are unique.
        /// Note that the ith task starts the moment right after the (i - 1)th task ends, and the 0th task starts at time 0.
        /// Return the id of the employee that worked the task with the longest time.
        /// If there is a tie between two or more employees, return the smallest id among them.
        /// </summary>
        public _02432_TheEmployeeThatWorkedOnTheLongestTask()
        {
            Console.WriteLine(HardestWorker(
                10,
                [
                    [0, 3],
                    [2, 5],
                    [0, 9],
                    [1, 15]
                ]
            ));
            Console.WriteLine(HardestWorker(
                26,
                [
                    [1, 1],
                    [3, 7],
                    [2, 12],
                    [7, 17]
                ]
            ));
            Console.WriteLine(HardestWorker(
                2,
                [
                    [0, 10],
                    [1, 20]
                ]
            ));
        }

        private static int HardestWorker(int n, int[][] logs)
        {
            int maxLen = logs[0][1];
            int res = logs[0][0];
            int i = 1;

            while (i < logs.Length)
            {
                int curLen = logs[i][1] - logs[i - 1][1];

                if (curLen > maxLen)
                {
                    maxLen = curLen;
                    res = logs[i][0];
                }
                else if (curLen == maxLen) res = Math.Min(res, logs[i][0]);

                i++;
            }

            return res;
        }
    }
}
